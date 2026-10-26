# Tizen WindowSystem backend smoke test

This app exercises the `Tizen.WindowSystem.Shell.TizenShell` and
`Tizen.NUI.WindowSystem.Shell.TizenShell` constructors, plus QuickPanelClient
constructors that obtain the current window ID and screen geometry. Both
wrappers select their native backend at build time: EFL by default, or tcore
Wayland when `BUILD_TCORE_ENABLE` is enabled.

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
the command. Before launching that variant, install both matching
`Tizen.WindowSystem.dll` and `Tizen.NUI.WindowSystem.dll` builds into the
device framework directory. The test app resolves these framework assemblies
from the device, so updating only the NUI DLL leaves the `Tizen.WindowSystem`
case on the image's existing build.

The image also needs compatible `libtzsh_common.so.0` and
`libtzsh_backend_tcore.so` versions. The backend must keep its Tcore display
connected until `tzsh_destroy_internal()` releases the common Wayland proxies
(the backend's `destroy_post` phase). An older backend that disconnects the
display inside its `destroy` callback can crash during `TizenShell.Dispose()`.
Results are shown on screen and written to the `TzShellBackendTest` log tag.
