using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    const string Lib = "libsqlite3.so.0";

    internal static partial class Sqlite
    {
        internal static void Init()
        {
        }

        [Flags]
        internal enum OpenParameter : int
        {
            SQLITE_OPEN_READONLY = 0x00000001,
            SQLITE_OPEN_READWRITE = 0x00000002,
            SQLITE_OPEN_CREATE = 0x00000004,
            SQLITE_OPEN_DELETEONCLOSE = 0x00000008,
            SQLITE_OPEN_EXCLUSIVE = 0x00000010,
            SQLITE_OPEN_AUTOPROXY = 0x00000020,
            SQLITE_OPEN_URI = 0x00000040,
            SQLITE_OPEN_MEMORY = 0x00000080,
            SQLITE_OPEN_MAIN_DB = 0x00000100,
            SQLITE_OPEN_TEMP_DB = 0x00000200,
            SQLITE_OPEN_TRANSIENT_DB = 0x00000400,
            SQLITE_OPEN_MAIN_JOURNAL = 0x00000800,
            SQLITE_OPEN_TEMP_JOURNAL = 0x00001000,
            SQLITE_OPEN_SUBJOURNAL = 0x00002000,
            SQLITE_OPEN_MASTER_JOURNAL = 0x00004000,
            SQLITE_OPEN_NOMUTEX = 0x00008000,
            SQLITE_OPEN_FULLMUTEX = 0x00010000,
            SQLITE_OPEN_SHAREDCACHE = 0x00020000,
            SQLITE_OPEN_PRIVATECACHE = 0x00040000,
            SQLITE_OPEN_WAL = 0x00080000
        }

        internal enum ResultCode : int
        {
            SQLITE_OK = 0,
            SQLITE_ERROR = 1,
            SQLITE_INTERNAL = 2,
            SQLITE_PERM = 3,
            SQLITE_ABORT = 4,
            SQLITE_BUSY = 5,
            SQLITE_LOCKED = 6,
            SQLITE_NOMEM = 7,
            SQLITE_READONLY = 8,
            SQLITE_INTERRUPT = 9,
            SQLITE_IOERR = 10,
            SQLITE_CORRUPT = 11,
            SQLITE_NOTFOUND = 12,
            SQLITE_FULL = 13,
            SQLITE_CANTOPEN = 14,
            SQLITE_PROTOCOL = 15,
            SQLITE_EMPTY = 16,
            SQLITE_SCHEMA = 17,
            SQLITE_TOOBIG = 18,
            SQLITE_CONSTRAINT = 19,
            SQLITE_MISMATCH = 20,
            SQLITE_MISUSE = 21,
            SQLITE_NOLFS = 22,
            SQLITE_AUTH = 23,
            SQLITE_FORMAT = 24,
            SQLITE_RANGE = 25,
            SQLITE_NOTADB = 26,
            SQLITE_NOTICE = 27,
            SQLITE_WARNING = 28,
            SQLITE_ROW = 100,
            SQLITE_DONE = 101
        }

        //int sqlite3_open_v2(const char* filename, sqlite3** ppDb, int flags, const char* zVfs)
        [DllImport(Lib, EntryPoint = "sqlite3_open_v2")]
        internal static extern int OpenV2(string filename, out IntPtr ppDb, int flags, IntPtr zVfs);

        //int sqlite3_close_v2(sqlite3*)
        [DllImport(Lib, EntryPoint = "sqlite3_close_v2")]
        internal static extern int Close(IntPtr pDb);

        //int sqlite3_prepare_v2(sqlite3* db, const char* zSql, int nByte, sqlite3_stmt** ppStmt, const char** pzTail)
        [DllImport(Lib, EntryPoint = "sqlite3_prepare_v2")]
        internal static extern int Prepare(IntPtr pDb, string zSql, int nByte, out IntPtr ppStmt, IntPtr pzTail);

        //int sqlite3_bind_text(sqlite3_stmt*, int,const char*,int,void (*) (void*));
        [DllImport(Lib, EntryPoint = "sqlite3_bind_text")]
        internal static extern int BindText(IntPtr stmt, int pos, string text, int size, IntPtr mode);

        //int sqlite3_bind_int(sqlite3_stmt*, int, int);
        [DllImport(Lib, EntryPoint = "sqlite3_bind_int")]
        internal static extern int BindInt(IntPtr stmt, int pos, int val);

        //int sqlite3_bind_double(sqlite3_stmt*, int, double);
        [DllImport(Lib, EntryPoint = "sqlite3_bind_double")]
        internal static extern int BindDouble(IntPtr stmt, int pos, double val);

        //int sqlite3_bind_blob(sqlite3_stmt*, int, const void*, int n, void (*) (void*));
        [DllImport(Lib, EntryPoint = "sqlite3_bind_blob")]
        internal static extern int BindData(IntPtr stmt, int pos, byte[] val, int size, IntPtr mode);

        //int sqlite3_bind_parameter_index(sqlite3_stmt*, const char *zName);
        [DllImport(Lib, EntryPoint = "sqlite3_bind_parameter_index")]
        internal static extern int GetParameterIndex(IntPtr stmt, string zName);

        //int sqlite3_step(sqlite3_stmt*)
        [DllImport(Lib, EntryPoint = "sqlite3_step")]
        internal static extern int Step(IntPtr stmt);

        //int sqlite3_finalize(sqlite3_stmt *pStmt);
        [DllImport(Lib, EntryPoint = "sqlite3_finalize")]
        internal static extern int Finalize(IntPtr stmt);

        //int sqlite3_changes(sqlite3*)
        [DllImport(Lib, EntryPoint = "sqlite3_changes")]
        internal static extern int Changes(IntPtr db);

        //const unsigned char *sqlite3_column_text(sqlite3_stmt*, int iCol);
        [DllImport(Lib, EntryPoint = "sqlite3_column_text")]
        internal static extern IntPtr ColumnText(IntPtr stmt, int col);

        //int sqlite3_column_int(sqlite3_stmt*, int iCol);
        [DllImport(Lib, EntryPoint = "sqlite3_column_int")]
        internal static extern int ColumnInt(IntPtr stmt, int col);

        //double sqlite3_column_double(sqlite3_stmt*, int iCol);
        [DllImport(Lib, EntryPoint = "sqlite3_column_double")]
        internal static extern double ColumnDouble(IntPtr stmt, int col);

        //const void* sqlite3_column_blob(sqlite3_stmt *, int iCol);
        [DllImport(Lib, EntryPoint = "sqlite3_column_blob")]
        internal static extern IntPtr ColumnBlob(IntPtr stmt, int col);

        //int sqlite3_reset(sqlite3_stmt* pStmt);
        [DllImport(Lib, EntryPoint = "sqlite3_reset")]
        internal static extern int Reset(IntPtr stmt);

        //int sqlite3_column_bytes(sqlite3_stmt*, int iCol);
        [DllImport(Lib, EntryPoint = "sqlite3_column_bytes")]
        internal static extern int ColumnBytes(IntPtr stmt, int col);

        internal enum UpdateHookAction : int
        {
            SQLITE_DELETE = 9,
            SQLITE_INSERT = 18,
            SQLITE_UPDATE = 23
        }

        internal delegate void UpdateHookCallback(IntPtr data, int action, string db_name, string table_name, long rowid);

        //void* sqlite3_update_hook(sqlite3*, void(*)(void* data, int action, char const* db_name, char const* table_name, sqlite3_int64 rowid), void* data);
        [DllImport(Lib, EntryPoint = "sqlite3_update_hook")]
        internal static extern IntPtr UpdateHook(IntPtr db, UpdateHookCallback cb, IntPtr data);
    }
}
