var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var documents = new[]
{
    new SupportDocument("northwind", "Northwind support policy"),
    new SupportDocument("contoso", "Contoso support policy")
};

app.MapPost("/chat", (ChatRequest request, HttpContext context, ILogger<Program> logger) =>
{
    RequestAuditLog.Write(logger, request.TenantId, request.Message, context.TraceIdentifier);

    var matches = documents
        .Where(document => document.TenantId == request.TenantId)
        .ToArray();

    return Results.Ok(new ChatResponse($"Draft answer based on {matches.Length} documents"));
});

app.Run();

public sealed record ChatRequest(string TenantId, string Message);

public sealed record ChatResponse(string Answer);

public sealed record SupportDocument(string TenantId, string Text);