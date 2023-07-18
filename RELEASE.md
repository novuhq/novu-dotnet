# Releasing a new Version

Releases are triggered via a GitHub Action. In order for this Action to be triggered, a new release must be made via the UI in GitHub.

## Current Process

Once it has been deteremed that a new release is ready, create a new branch called `release/<version>`. This branch will serve as a place where you can do 
version bumps prior to triggering a release in the UI.

For the sake of documentation, we will be releasing `1.0.0`.

- Create a `release/v1.0.0`
- Update the following file for the version bump:
  - `src/Novu/Novu.csproj` and update the `<Version></Version>` tag to the new version
    ```csharp
    ...
      <Version>1.0.0</Version>
    ...
    ```
- Merge this new change back into `main`
- Navigate to Releases, Draft a new Release
- Create a new tag with the name `v1.0.0`.
  - NOTE: The `v` prefix is required. The GitHub Action will not trigger withouth it.
- The release title should be the same name as the new tag created
- Enter your release notes
- Check the `Set as the latest release` box and publish release

From here, GitHub Actions will trigger and publish the new release to Nuget. It generally takes around 5-10 minutes for the release to run and be available 
on Nuget.

## How to release a new Feature branch

All deployments should take place from the `main` branch. To release a new feature branch, you will need to create a PR to the main branch, have it reviewed and merged. Once merged into the
main branch, you will follow the `Current Process` section to release a new version.
