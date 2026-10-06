using Microsoft.Extensions.Logging;

const string privateMessage = "synthetic-private-message-123";
const string tenantId = "synthetic-tenant-123";
const string correlationId = "trace-123";

var logger = new CapturingLogger();
RequestAuditLog.Write(logger, tenantId, privateMessage, correlationId);

var output = string.Join(Environment.NewLine, logger.Entries);
var leaksMessage = output.Contains(privateMessage, StringComparison.Ordinal);
var leaksTenant = output.Contains(tenantId, StringComparison.Ordinal);
var hasCorrelationId = output.Contains(correlationId, StringComparison.Ordinal);
var expectsRedaction = args.Contains("--expect-redaction", StringComparer.Ordinal);

if (expectsRedaction)
{
    if (leaksMessage || leaksTenant || !hasCorrelationId)
    {
        Console.Error.WriteLine("FAIL: request logs must omit message and tenant values and retain the correlation ID.");
        return 1;
    }

    Console.WriteLine("PASS: request logs omit message and tenant values and retain the correlation ID.");
    return 0;
}

if (!leaksMessage || !leaksTenant)
{
    Console.Error.WriteLine("FAIL: baseline no longer reproduces the expected logging risk.");
    return 1;
}

Console.WriteLine("Baseline reproduced: request logs contain message and tenant values.");
return 0;

sealed class CapturingLogger : ILogger
{
    public List<string> Entries { get; } = [];

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => NullScope.Instance;

    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        Entries.Add(formatter(state, exception));
    }

    private sealed class NullScope : IDisposable
    {
        public static NullScope Instance { get; } = new();

        public void Dispose()
        {
        }
    }
}