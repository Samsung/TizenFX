---
uid: Tizen.Data.Tdbc
summary: TDBC provides a uniform interface for accessing various database systems in Tizen applications.
remarks: *content
---
## Overview
Tizen.Data.Tdbc provides developers with access to the Tizen Database Connectivity (TDBC) layer. The TDBC layer provides a uniform interface for accessing various database systems in Tizen. With Tizen.Data.Tdbc, developers can easily connect to and perform operations on different database systems without having to learn each system's specific API.

## Connecting to database
To use a variant database driver with Tdbc, you'll need to register the driver before using the Tizen.Data.Tdbc.DriverManager.RegisterDriver() method. This method registers a driver with TDBC, making it available for use in connecting to specific databases.

Here's an example of how to connect to Sqlite database:
```cs
using Tizen.Data.Tdbc;
// ...

DriverManager.RegisterDriver("Tizen.Data.Tdbc.Driver.Sqlite");
var conn = DriverManager.GetConnection(new Uri("tdbc://localhost/sqlite_test.db?mode=rwc"));
```
