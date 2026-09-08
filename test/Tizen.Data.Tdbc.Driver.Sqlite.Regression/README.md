# SQLite identifier regression tests

Run on Linux with the .NET 8 SDK/runtime and `libsqlite3.so.0`:

```sh
dotnet run --project test/Tizen.Data.Tdbc.Driver.Sqlite.Regression/Regression.csproj
```

The executable compiles the production TDBC sources directly to access the internal
driver without adding public APIs or test packages. It creates a temporary database
and removes it after normal completion or a managed failure.

Coverage includes SQL syntax embedded in table names, quoted and Unicode names,
INSERT/UPDATE/DELETE notifications, signed 64-bit rowids, a custom negative sign,
and identical table names in main, attached, and temporary databases. Assertions
run outside the native callback; failures exit with a nonzero status.

This verifies identifier handling, not the safety of querying within an update
hook. The existing same-connection callback reentrancy is unchanged. Tizen runtime
validation remains necessary. On a host with only .NET 9, build the net8.0 project
and use `DOTNET_ROLL_FORWARD=Major dotnet` to execute its output; that does not
constitute a .NET 8 runtime test.
