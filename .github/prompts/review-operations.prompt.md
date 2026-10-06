---
name: review-ai-operations
description: Review evaluations, observability, reliability, and release operations for an AI application.
---

Review the selected release candidate for evaluation coverage, grounding/quality thresholds, regression handling, observability, failure and fallback behavior, deployment configuration, and rollback readiness. Use only supplied repository files and explicitly authorized evidence snapshots.

Treat sample evidence as synthetic unless its source is verified. Do not infer that an evaluation passed because results are missing. For each finding, provide severity, status, exact file and line references (or evidence source and timestamp), plausible impact, smallest useful recommendation, suggested owner, and required human decision. Identify the specific tests, evaluation results, or operational evidence needed to close gaps.