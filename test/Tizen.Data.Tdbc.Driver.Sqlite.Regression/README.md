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

Callback tests cover a throwing subscriber, an authorizer-denied callback SELECT,
and a throwing diagnostic writer. All five INSERTs must persist, and notifications
must resume after the failures. A throwing subscriber stops the current multicast
notification; later subscribers are not invoked for that notification. The driver
contains ordinary managed notification exceptions and emits a fixed diagnostic
without exception details. Notification failure does not signal a failed write.

Before the callback guard, the throwing-subscriber test exits with code 134 and
`PAL_SEHException` on the Linux .NET 9 host. This confirms a host availability
impact; it does not establish a Tizen runtime result or an external attack path.
Sensitive data reaching an unauthorized recipient remains unproven, so this
observation alone does not establish a higher security severity.

This verifies identifiers and managed exception containment, not the safety of
querying within an update hook or recovery from fatal runtime/native failures.
The existing same-connection callback reentrancy is unchanged. Tizen runtime
validation remains necessary. On a host with only .NET 9, build the net8.0 project
and use `DOTNET_ROLL_FORWARD=Major dotnet` to execute its output; that does not
constitute a .NET 8 runtime test.
