#!/bin/sh
set -e

INDEX="/app/SmartFranCloudApp/wwwroot/index.html"
BACKUP="/tmp/index.html.bak"

cp "$INDEX" "$BACKUP"
sed -i 's|<base href="/smartfran-cloud/"|<base href="/"|g' "$INDEX"

cleanup() { cp "$BACKUP" "$INDEX"; }
trap cleanup EXIT INT TERM

exec dotnet watch run \
    --project SmartFranCloudApp/SmartFranCloudApp.csproj \
    --urls "http://0.0.0.0:5000"
