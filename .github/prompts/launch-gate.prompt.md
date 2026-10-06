---
name: ai-launch-gate
description: Coordinate a human-reviewed readiness assessment for an AI application release.
---

Fallback for hosts that do not load the AI Launch Gate skill or support `/orchestrate`. Use these prompts for the review stage. Continue to a code change only after a person approves the exact finding and scope. Prefer the App skill and `/orchestrate` when available.

## Review sequence

1. Establish the exact repository revision and the evidence supplied. Do not assume Azure access or production state.
2. Delegate architecture/data-flow, trust/responsible-AI, and evaluation/operations checks to separate sessions through `/orchestrate` when the Copilot App supports it. If not, run each specialist prompt in a separate session and state that this is a fallback.
3. Ask each reviewer to return only evidence-backed findings in the shared finding format. Challenge unsupported severity, duplicated findings, and conclusions based on absent evidence.
4. Reconcile the results into a release brief. Preserve disagreement and uncertainty; do not silently resolve them.
5. Present the findings and ask the named owner which, if any, they approve for remediation. Do not implement a fix or declare the release approved without explicit approval.

## Release brief

Return:

- Scope: repository, revision, files/evidence reviewed, and exclusions.
- Decision status: **Ready for human decision**, **Needs remediation**, or **Insufficient evidence**. This is not release approval.
- Findings table: ID, severity, status, evidence, impact, recommended next step, suggested owner, and required human gate.
- Not-assessed items and the precise evidence needed to assess them.
- Questions for the application owner and security/release reviewers.
- Optional remediation candidates with proposed files and acceptance checks. Do not implement them unless a human separately approves a specific scope.

Do not claim that this workflow guarantees security, safety, compliance, or production readiness.