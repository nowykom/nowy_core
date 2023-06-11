#!/bin/bash

cd "$(dirname "${BASH_SOURCE[0]}")"

cd ../lr_dotnet_standard || exit 1

rm -rf src
git add --all

rsync -av ../nowy_core/ ./ --exclude .git --exclude build --exclude bin --exclude obj --exclude .vs --exclude temp --exclude .idea --exclude clone-and-rename.sh

git add --all

gsed -i 's@nowy_core@lr_dotnet_standard@gm' .github/workflows/deploy-nuget.yml .nuke/parameters.json
gsed -i 's@Nowy@LR@gm' .github/workflows/deploy-nuget.yml .nuke/parameters.json
gsed -i 's@nowy@lr@gm' .github/workflows/deploy-nuget.yml .nuke/parameters.json

../code-rename/coderename.pl "Nowy" "LR"

gsed -i 's@lr/_packaging/LR/nuget/v3/index.json@nowy/_packaging/Nowy/nuget/v3/index.json@gm' nuget.config

git add --all
