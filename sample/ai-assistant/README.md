# Synthetic AI assistant release candidate

This small ASP.NET Core app is for trying the AI Launch Gate workflow. It has a raw-request logging issue for reviewers to flag and a check to verify an approved fix. It contains no customer data, credentials, or Azure connection. Do not deploy it.

Review `src/Program.cs`, `src/RequestAuditLog.cs`, `evals/cases.json`, and the snapshot in `evidence/`. Run the API locally with `dotnet run --project src/AiAssistant.Api.csproj`.

The privacy check reproduces the issue before a fix:

```powershell
dotnet run --project tests/LogPrivacyChecks.csproj
```

After an approved fix, verify redaction with:

```powershell
dotnet run --project tests/LogPrivacyChecks.csproj -- --expect-redaction
dotnet build src/AiAssistant.Api.csproj
```

The Foundry snapshot and evaluation cases are fictional demo data. They are not connected to Azure and are not executed model evaluations.