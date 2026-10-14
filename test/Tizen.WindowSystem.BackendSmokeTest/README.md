# Tizen WindowSystem backend smoke test

This app exercises the `Tizen.WindowSystem.Shell.TizenShell` and
`Tizen.NUI.WindowSystem.Shell.TizenShell` constructors. Both wrappers select
their native backend at build time: EFL by default, or tcore Wayland when
`BUILD_TCORE_ENABLE` is enabled.

Build from this directory with the .NET 8 SDK:

```sh
dotnet build \
  -p:NuGetAudit=false \
  -p:RestoreIgnoreFailedSources=true \
  -p:RestoreBuildInParallel=false \
  -p:BuildInParallel=false
```

The build produces a TPK under `bin/Debug/net8.0/`. Install and launch it on a
Tizen 11 device. Build the tcore variant by adding `-p:BUILD_TCORE_ENABLE=1` to
the command. That variant requires the device image to include the
`tizen-ws-shell` tcore backend library. Results are shown on screen and written
to the `TzShellBackendTest` log tag.
