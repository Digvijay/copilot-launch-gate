# AI Launch Gate architecture

## Workflow

```mermaid
flowchart LR
    A[Git-backed AI app release candidate] --> B[GitHub Copilot App]
    B --> C[Read-only architecture review]
    B --> D[Read-only trust review]
    B --> E[Read-only operations review]
    F[Optional authorized read-only Foundry evidence] --> B
    C --> G[Evidence-backed findings]
    D --> G
    E --> G
    G --> H{Owner approves one fix and scope}
    H -->|Approve| I[New isolated coding worktree]
    H -->|Need evidence| J[Owner supplies evidence]
    H -->|Defer| K[Decision recorded by owner]
    I --> L[Implement approved code or test change]
    L --> M[Run existing build, tests, and applicable evals]
    M --> N[Read-only reviewers inspect diff and results]
    N --> O{Human reviews verified change}
    O -->|Approve PR creation| P[Create draft pull request]
    O -->|Request changes| I
    P --> Q[Normal CI, merge, and release approval]
```

## Trust boundaries

- Repository code, prompt text, retrieved content, and tool output are untrusted inputs.
- The default evidence boundary is the selected GitHub repository and revision.
- Optional Azure AI Foundry MCP context is read-only and customer-authorized. The demo uses a clearly labeled synthetic JSON fixture instead of a live connection.
- GitHub Copilot App `/orchestrate` coordinates the parallel child sessions. Each session has its own isolated workspace; the human coordinator reviews their reports before synthesis.
- Review sessions are read-only. A separate coding session may edit only a human-approved scope in an isolated Git worktree.
- Human owners retain control of remediation scope, pull request creation, merge, Azure changes, and release approval. The workflow never deploys.

## Three-slide deck outline

1. **Customer problem and outcome:** release findings are handed between engineering, security, and AI operations; show the path from a finding to a tested change.
2. **Workflow and controls:** show parallel read-only reviews, human approval of one scoped fix, an isolated coding worktree, checks, and a second review.
3. **Repeatability and impact:** show the skill, reviewer profiles, sample privacy check, and proposed pilot measures. Label outcomes as targets until measured.