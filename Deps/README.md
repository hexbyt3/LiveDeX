# 📦 Dependencies

This folder contains the PKHeX.Core.dll dependency required to build the Living Dex Builder plugin.

## Updating PKHeX.Core.dll

When you want to update the plugin to work with a newer version of PKHeX:

1. Build PKHeX in Debug mode
2. Copy `PKHeX\PKHeX.Core\bin\Debug\net9.0\PKHeX.Core.dll` to this folder
3. Commit and push the change
4. GitHub Actions will automatically build and release the plugin with the new version

The version number for releases is automatically extracted from the PKHeX.Core.dll assembly version.
