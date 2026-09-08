using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Tizen.Data.Tdbc;
using Tizen.Data.Tdbc.Driver.Sqlite;

internal static class CallbackRegression
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int Authorizer(IntPtr data, int action, IntPtr first,
        IntPtr second, IntPtr database, IntPtr source);

    [DllImport("libsqlite3.so.0", EntryPoint = "sqlite3_set_authorizer", CallingConvention = CallingConvention.Cdecl)]
    private static extern int SetAuthorizer(IntPtr database, Authorizer callback, IntPtr data);

    private sealed class ThrowingWriter : TextWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
        public override void WriteLine(string value) => throw new IOException("Diagnostic sink failed");
    }

    internal static void Run(string path)
    {
        using var connection = new Connection();
        connection.Open(new UriBuilder("tdbc", "localhost") { Path = path, Query = "mode=rwc" }.Uri);
        using var statement = connection.CreateStatement();
        void Execute(string command)
        {
            if (!statement.Execute(new Sql(command)))
                throw new Exception("Command failed: " + command);
        }

        Execute("CREATE TABLE callback_records(id INTEGER PRIMARY KEY, data TEXT)");
        EventHandler<RecordChangedEventArgs> throwing = (_, __) =>
            throw new InvalidOperationException("synthetic-sensitive-detail");
        int received = 0;
        EventHandler<RecordChangedEventArgs> counting = (_, __) => received++;
        connection.RecordChanged += throwing;
        connection.RecordChanged += counting;
        TextWriter originalError = Console.Error;
        using var diagnostics = new StringWriter();
        try
        {
            Console.SetError(diagnostics);
            Execute("INSERT INTO callback_records VALUES(1, 'subscriber failure')");
            if (received != 0)
                throw new Exception("The failed notification should stop at the throwing subscriber");

            using (var writer = new ThrowingWriter())
            {
                Console.SetError(writer);
                Execute("INSERT INTO callback_records VALUES(2, 'diagnostic failure')");
            }
            Console.SetError(diagnostics);
            connection.RecordChanged -= throwing;
            Execute("INSERT INTO callback_records VALUES(3, 'recovered')");

            // SQLITE_SELECT = 21, SQLITE_DENY = 1. Deny only the SELECT prepared
            // by the native update callback, while allowing the outer INSERT.
            Authorizer denySelect = (_, action, first, second, database, source) => action == 21 ? 1 : 0;
            if (SetAuthorizer(connection.GetHandle(), denySelect, IntPtr.Zero) != 0)
                throw new Exception("Could not install the test authorizer");
            try
            {
                Execute("INSERT INTO callback_records VALUES(4, 'query failure')");
            }
            finally
            {
                SetAuthorizer(connection.GetHandle(), null, IntPtr.Zero);
                GC.KeepAlive(denySelect);
            }
            Execute("INSERT INTO callback_records VALUES(5, 'recovered again')");
        }
        finally
        {
            Console.SetError(originalError);
            connection.RecordChanged -= throwing;
            connection.RecordChanged -= counting;
        }

        using (var result = statement.ExecuteQuery(new Sql("SELECT COUNT(*) FROM callback_records")))
        {
            if (result.First().GetInt(0) != 5 || received != 2)
                throw new Exception("Callback failures disrupted writes or later notifications");
        }
        string output = diagnostics.ToString();
        if (string.IsNullOrWhiteSpace(output) || output.Contains("synthetic-sensitive-detail") ||
            output.Contains("callback_records"))
            throw new Exception("Expected a diagnostic without sensitive exception or SQL details");
        Console.WriteLine("PASS: subscriber/query/diagnostic exceptions contained; writes and later notifications preserved");
    }
}
