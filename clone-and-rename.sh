#!/bin/bash

cd "$(dirname "${BASH_SOURCE[0]}")"

cd ../lr_dotnet_standard || exit 1

rm -rf src
git add --all

rsync -av ../nowy_core/ ./ --exclude .git --exclude build --exclude bin --exclude obj --exclude .vs --exclude temp --exclude .idea

git add --all

../code-rename/coderename.pl "Nowy" "LR"

git add --all

