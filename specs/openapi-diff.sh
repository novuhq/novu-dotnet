#!/usr/bin/env bash

set -e

PREVIOUS="0.18.0"
VERSIONS=('0.19.0' '0.24.0' '0.24.7' '2.1.1')

for version in "${VERSIONS[@]}"; do
    echo "Processing version $version"
    
    mkdir -p "$version"
    
    # see https://github.com/OpenAPITools/openapi-diff
    docker run --rm -t \
      -v $(pwd):/spec \
      openapitools/openapi-diff:latest \
      /spec/openapi-$PREVIOUS.json /spec/openapi-$version.json \
      --asciidoc /spec/$version/diff.ascidoc \
      --html /spec/$version/diff.html \
      --markdown /spec/$version/diff.md
    
    PREVIOUS=$version
done