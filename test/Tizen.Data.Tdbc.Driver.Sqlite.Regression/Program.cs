using System;
using System.Globalization;
using System.IO;
using Tizen.Data.Tdbc;
using Tizen.Data.Tdbc.Driver.Sqlite;

// Run on Linux with libsqlite3.so.0: dotnet run --project Regression.csproj
// Compile the production sources to exercise the internal driver without publishing APIs.
internal static class Program
{
    private static string Quote(string value) => "\"" + value.Replace("\"", "\"\"") + "\"";

    private static void Main()
    {
        string path = Path.GetTempFileName();
        try
        {
            Run(path);
        }
        finally
        {
            File.Delete(path);
        }
    }

    private static void Run(string path)
    {
        using var connection = new Connection();
        connection.Open(new UriBuilder("tdbc", "localhost") { Path = path, Query = "mode=rwc" }.Uri);
        using var statement = connection.CreateStatement();
        void Execute(string command)
        {
            if (!statement.Execute(new Sql(command)))
                throw new Exception("Command failed: " + command);
        }

        Execute("CREATE TABLE normal_table(id INTEGER PRIMARY KEY, data TEXT)");
        Execute("INSERT INTO normal_table VALUES(1, 'decoy')");
        Execute("CREATE TABLE secret_users(id INTEGER PRIMARY KEY, password TEXT)");
        Execute("INSERT INTO secret_users VALUES(1, 'synthetic-secret')");

        int notifications = 0;
        int deletions = 0;
        bool wrongRecord = false;
        string expected = "expected";
        connection.RecordChanged += (_, e) =>
        {
            if (e.OperationType == OperationType.Delete)
            {
                deletions++;
                return;
            }
            if (e.Record == null || e.Record.GetString(1) != expected)
                wrongRecord = true;
            notifications++;
        };

        foreach (string name in new[] { "normal_table JOIN secret_users --", "my table", "order-log", "order", "tbl\"quote", "한글" })
        {
            Execute($"CREATE TABLE {Quote(name)}(id INTEGER PRIMARY KEY, data TEXT)");
            Execute($"INSERT INTO {Quote(name)} VALUES(1, 'expected')");
            expected = "updated";
            Execute($"UPDATE {Quote(name)} SET data = 'updated' WHERE id = 1");
            Execute($"DELETE FROM {Quote(name)} WHERE id = 1");
            expected = "expected";
        }

        Execute("CREATE TABLE boundary(id INTEGER PRIMARY KEY, data TEXT)");
        var originalCulture = CultureInfo.CurrentCulture;
        try
        {
            var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            culture.NumberFormat.NegativeSign = "~";
            CultureInfo.CurrentCulture = culture;
            foreach (long id in new[] { long.MinValue, -1L, 0L, 9007199254740993L, long.MaxValue })
                Execute($"INSERT INTO boundary VALUES({id.ToString(CultureInfo.InvariantCulture)}, 'expected')");
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }

        Execute("ATTACH DATABASE ':memory:' AS \"attached\"\"db\"");
        Execute("CREATE TABLE main.shared(id INTEGER PRIMARY KEY, data TEXT)");
        Execute("CREATE TABLE \"attached\"\"db\".shared(id INTEGER PRIMARY KEY, data TEXT)");
        expected = "main";
        Execute("INSERT INTO main.shared VALUES(1, 'main')");
        expected = "attached";
        Execute("INSERT INTO \"attached\"\"db\".shared VALUES(1, 'attached')");
        Execute("CREATE TEMP TABLE shared(id INTEGER PRIMARY KEY, data TEXT)");
        expected = "temp";
        Execute("INSERT INTO temp.shared VALUES(1, 'temp')");
        expected = "main-updated";
        Execute("UPDATE main.shared SET data = 'main-updated' WHERE id = 1");

        if (wrongRecord)
            throw new Exception("Event returned data from the wrong table or row");
        if (notifications != 21 || deletions != 6)
            throw new Exception($"Expected 21 row notifications and 6 deletions, got {notifications} and {deletions}");
        Console.WriteLine("PASS: identifier injection, special names, INSERT/UPDATE/DELETE, Int64 boundaries, culture, attached/temp schema isolation");
    }
}
