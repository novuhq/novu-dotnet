# Creating releases

Releases are triggered via a GitHub Action. In order for this Action to be triggered, a new release must be made via the UI in GitHub.

Main Conventions:

- product releases are versioned via X.X.X (eg 0.1.0)
- tags have prefix 'v' (eg v0.1.0)

NOTE: The `v` prefix is required. The GitHub Action will not trigger withouth it.

## Step One: making changes and merging

All deployments should take place from the `main` branch. To release a new feature branch, you will need to create a PR to the main branch from another branch or fork, have it reviewed and merged.

- Merge this new change back into `main`

## Step Two: drafting

- Navigate to [Releases](https://github.com/novuhq/novu-dotnet/releases)
- [Draft a new Release](https://github.com/novuhq/novu-dotnet/releases/new)
- Create a new tag
  - Choose a tag > Find or crate a new tag > vX.X.X > Create new tag
- Create release
  - Release title: `vX.X.X`
  - Content (example):

```
## What's Changed
* Nothing functionality from 0.3.1—had a problem in the build scripts for publishing to nuget


**Full Changelog**: https://github.com/novuhq/novu-dotnet/compare/vX.X.last)...vX.X.latest)
```

- [x] Set as the latest release
- Save as draft [ready for others to review]

## Step Three: releasing

From here, GitHub Actions will trigger and publish the new release to Nuget. It generally takes around 5-10 minutes for the release to run and be available
on Nuget.

- open your draft in [releases](https://github.com/novuhq/novu-dotnet/releases)
- Publish release

## Step Four: post-release checks

- Check that it exists on nuget
- Ideally update a project that uses the version
