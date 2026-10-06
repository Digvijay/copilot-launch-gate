using Microsoft.Extensions.Logging;

public static class RequestAuditLog
{
    public static void Write(ILogger logger, string tenantId, string message, string correlationId)
    {
        logger.LogInformation(
            "Chat request tenant={TenantId} message={Message} correlationId={CorrelationId}",
            tenantId,
            message,
            correlationId);
    }
}