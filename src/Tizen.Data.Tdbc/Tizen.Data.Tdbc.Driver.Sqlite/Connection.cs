/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.ComponentModel;

namespace Tizen.Data.Tdbc.Driver.Sqlite
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Connection : Tdbc.Connection
    {
        private bool _opened;
        private IntPtr _db;
        private bool disposedValue;
        private object _lock = new object();
        private EventHandler<RecordChangedEventArgs> _recordChanged;


        static Connection()
        {
            Interop.Sqlite.Init();
        }

        public Connection()
        {
        }

        public event EventHandler<RecordChangedEventArgs> RecordChanged
        {
            add
            {
                lock (_lock)
                {
                    _recordChanged += value;
                }
            }

            remove
            {
                lock (_lock)
                {
                    _recordChanged -= value;
                }
            }
        }

        public void Open(String openString)
        {
        }
        
        public void Close()
        {
            if (_opened)
            {
                Interop.Sqlite.UpdateHook(_db, null, IntPtr.Zero);
                Interop.Sqlite.Close(_db);
                _opened = false;
            }
        }

        private void UpdateHookCallback(IntPtr data, int action, string db_name, string table_name, long rowid)
        {
            // TODO: public enumeration type
            int operationType = -1;
            switch (((Interop.Sqlite.UpdateHookAction)action))
            {
                case Interop.Sqlite.UpdateHookAction.SQLITE_UPDATE:
                    operationType = 0;
                    break;
                case Interop.Sqlite.UpdateHookAction.SQLITE_INSERT:
                    operationType = 1;
                    break;
                case Interop.Sqlite.UpdateHookAction.SQLITE_DELETE:
                    operationType = 2;
                    break;
            }

            RecordChangedEventArgs ev = new RecordChangedEventArgs(operationType, db_name, table_name, rowid);
            _recordChanged?.Invoke(this, ev);
        }

        internal IntPtr GetHandle()
        {
            return _db;
        }

        public void Open(Uri uri)
        {
            if (uri.Scheme != "tdbc")
                throw new ArgumentException("Wrong scheme:" + uri.Scheme);

            if (uri.Host != "localhost")
                throw new ArgumentException("Host should be 'localhost':" + uri.Host);

            string query = uri.Query;
            var queryDictionary = System.Web.HttpUtility.ParseQueryString(query);
            int mode = (int)Interop.Sqlite.OpenParameter.SQLITE_OPEN_READWRITE |
                (int)Interop.Sqlite.OpenParameter.SQLITE_OPEN_CREATE;

            if (queryDictionary.Get("mode") == "ro")
            {
                mode = (int)Interop.Sqlite.OpenParameter.SQLITE_OPEN_READONLY;
            }
            else if (queryDictionary.Get("mode") == "rw")
            {
                mode = (int)Interop.Sqlite.OpenParameter.SQLITE_OPEN_READWRITE;
            }
            else if (queryDictionary.Get("mode") == "rwc")
            {
                mode = (int)Interop.Sqlite.OpenParameter.SQLITE_OPEN_READWRITE |
                    (int)Interop.Sqlite.OpenParameter.SQLITE_OPEN_CREATE;
            }
            else if (queryDictionary.Get("mode") == "memory")
            {
                mode = (int)Interop.Sqlite.OpenParameter.SQLITE_OPEN_MEMORY;
            }

            if (queryDictionary.Get("cache") == "shared")
            {
                mode |= (int)Interop.Sqlite.OpenParameter.SQLITE_OPEN_SHAREDCACHE;
            }
            else if (queryDictionary.Get("cache") == "private")
            {
                mode |= (int)Interop.Sqlite.OpenParameter.SQLITE_OPEN_PRIVATECACHE;
            }

            int ret = Interop.Sqlite.OpenV2(uri.LocalPath, out _db, mode, IntPtr.Zero);
            if (ret != (int)Interop.Sqlite.ResultCode.SQLITE_OK)
                throw new InvalidOperationException("code:" + ret);

            Interop.Sqlite.UpdateHook(_db, UpdateHookCallback, IntPtr.Zero);
            _opened = true;
        }

        public Tdbc.Statement CreateStatement()
        {
            if (IsClosed())
                throw new InvalidOperationException("Not opened");

            return new Statement(this);
        }

        public bool IsClosed()
        {
            return !_opened;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                if (_opened)
                    Close();
                disposedValue = true;
            }
        }

         ~Connection()
         {
             Dispose(disposing: false);
         }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
