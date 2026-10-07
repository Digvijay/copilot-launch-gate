# GitHub Copilot App product feedback

## Workflow step

Delegate parallel, read-only reviewers for a pinned GitHub repository revision.

## Observed behavior

In this synthetic rehearsal, the parallel reviewer sessions could not read the selected commit's Git objects and returned without verified findings. After the coordinator supplied the committed file contents, sequential reviews returned reports.

## Impact

The coordinator had to gather and relay evidence manually, and the intended parallel handoff did not produce usable reports on its first attempt. This is one observed rehearsal, not a claim about all Copilot App sessions.

## Requested improvement

Have orchestrated child sessions inherit the coordinator's selected repository revision and report status only after a usable review report has returned. If that context is unavailable, surface the access limitation so the coordinator can choose a fallback immediately.