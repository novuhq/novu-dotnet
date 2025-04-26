# Versioning instructions

There are two folders for versions:

* [refitter](./refitter): contains the C# code
* [specs](./specs): contains openapi specs and diffs

## Basic approach

1. Download the version of the openapi spec
2. Label it by version
3. Generate a diff (markdown, HTML, asciidoc)
4. Generate C# code

## Steps

### Download version

The version that is downloaded must be labelled with its version that is then used through the scripts.

1. Use the relevant `go.sh` script to download either:
    * Self-Hosted [./go-self-hosted.sh](./specs/go-self-hosted.sh)
    * the Cloud version [./go-cloud.sh](./specs/go-cloud.sh)
2. Rename the `openapi.json` with the version --> `openapi-[version].json`

### Generate a diff

The script works by diffing between the versions in order.

1. Add the version into the [`openapi-diff.sh`](./specs/openapi-diff.sh)
    ```
    PREVIOUS="0.18.0"
    VERSIONS=('0.19.0' '0.24.0' '0.24.7' '2.1.1')
    ```
2. Run the script

The folder of the new version should now appear with the diffs inside

### Generate a C# refitter class code

The script works by diffing between the versions in order.

1. Add the version into the [`refitter/make.sh`](./refitter/make.sh)
    ```
    PREVIOUS="0.18.0"
    VERSIONS=('0.19.0' '0.24.0' '0.24.7' '2.1.1')
    ```
2. Run the script [`refitter/make.sh`](./refitter/make.sh)

The folder of the new version should now appear with the code inside:

* `Contracts.cs`
* `INovuAPI.cs`

### Start understanding the differences

Now you can also use standard code diff tools to see actual differences in the code and also use this code as a basis
for generation of code/copy-and-paste