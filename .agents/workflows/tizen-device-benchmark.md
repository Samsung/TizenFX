---
description: Deploy benchmark app to Tizen device via sdb, run benchmarks, and collect console logs
---

# Tizen Device Benchmark Execution

This skill deploys and runs the `Tizen.Benchmark.Gallery` app on a Tizen target device connected to the host PC via `sdb`.

## Prerequisites
- Host PC has `sdb` available in PATH
- Target device is connected and visible via `sdb devices`
- Benchmark `.tpk` is built (run `dotnet build` on the project first)

## Steps

### 1. Build the benchmark tpk
```bash
dotnet build test/Tizen.Benchmark.Gallery/Tizen.Benchmark.Gallery.csproj -c Release
```
The `.tpk` file will be generated at:
`test/Tizen.Benchmark.Gallery/bin/Release/net8.0/org.tizen.example.Tizen.Benchmark.Gallery-1.0.0.tpk`

### 2. Install on device
```bash
sdb install test/Tizen.Benchmark.Gallery/bin/Release/net8.0/org.tizen.example.Tizen.Benchmark.Gallery-1.0.0.tpk
```

### 3. Launch the app
```bash
sdb shell app_launcher -s org.tizen.example.Tizen.Benchmark.Gallery
```

### 4. Collect real-time logs
Open a separate terminal and run:
```bash
sdb shell dlogutil STDOUT
```
This streams the `Console.WriteLine` output from the benchmark app in real-time.
Benchmark results will appear as the user taps buttons or runs "Run All Benchmarks".

### 5. Stop the app (when done)
```bash
sdb shell app_launcher -k org.tizen.example.Tizen.Benchmark.Gallery
```

## App ID Reference
- Package: `org.tizen.example.Tizen.Benchmark.Gallery`
- App ID: `org.tizen.example.Tizen.Benchmark.Gallery`

## Notes
- For benchmark accuracy, run each benchmark **3~5 times** and use the median result.
- Wait a few seconds between runs to allow device to stabilize (CPU cooldown).
- If `sdb devices` shows no device, check USB connection or run `sdb start-server`.
