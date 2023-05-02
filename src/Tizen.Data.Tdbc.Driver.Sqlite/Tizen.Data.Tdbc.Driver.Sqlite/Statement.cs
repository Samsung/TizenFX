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
using System.Threading.Tasks;

namespace Tizen.Data.Tdbc.Driver.Sqlite
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Statement : IStatement
    {
        Connection _conn;
        private IntPtr _stmt;
        private bool disposedValue;

        private void Clear()
        {
            if (_stmt != IntPtr.Zero)
            {
                Interop.Sqlite.Finalize(_stmt);
                _stmt = IntPtr.Zero;
            }
        }

        private bool Prepare(Sql sql)
        {
            Clear();
            Console.WriteLine("Prepare: " + sql.Command);
            int ret = Interop.Sqlite.Prepare(_conn.GetHandle(), sql.Command, -1, out _stmt, IntPtr.Zero);
            if (ret != (int)Interop.Sqlite.ResultCode.SQLITE_OK)
            {
                Console.WriteLine("Prepare: failed " + ret);
                return false;
            }

            foreach (var i in sql.Bindings)
            {
                string key = i.Key;
                Object obj = i.Value;
                int pos = Interop.Sqlite.GetParameterIndex(_stmt, key);
                if (pos == 0)
                    throw new InvalidOperationException("Invalid binding");

                // TODO: consider null binding
                if (obj == null)
                    continue;

                Type type = obj.GetType();
                if (typeof(int) == type)
                {
                    Interop.Sqlite.BindInt(_stmt, pos, (int)obj);
                }
                else if (typeof(bool) == type)
                {
                    bool val = (bool)obj;
                    Interop.Sqlite.BindInt(_stmt, pos, val ? 1 : 0);
                }
                else if (typeof(double) == type)
                {
                    Interop.Sqlite.BindDouble(_stmt, pos, (double)obj);
                }
                else if (typeof(string) == type)
                {
                    Interop.Sqlite.BindText(_stmt, pos, (string)obj, -1, (IntPtr)(-1));
                }
                else if (typeof(byte[]) == type)
                {
                    Interop.Sqlite.BindData(_stmt, pos, (byte[])obj, ((byte[])obj).Length, IntPtr.Zero);
                }
            }

            return true;
        }

        internal Statement(Connection conn)
        {
            _conn = conn;
        }

        public bool Execute(Sql sql)
        {
            if (!Prepare(sql))
                return false;
            int ret = Interop.Sqlite.Step(_stmt);
            Console.WriteLine("Execute: " + ret); 
            if (ret != (int)Interop.Sqlite.ResultCode.SQLITE_ROW &&
                ret != (int)Interop.Sqlite.ResultCode.SQLITE_DONE)
                return false;
            return true;
        }

        public int ExecuteUpdate(Sql sql)
        {
            if (!Prepare(sql))
                return 0;
            int ret = Interop.Sqlite.Step(_stmt);
            if (ret != (int)Interop.Sqlite.ResultCode.SQLITE_ROW &&
                ret != (int)Interop.Sqlite.ResultCode.SQLITE_DONE)
                return 0;
            return Interop.Sqlite.Changes(_conn.GetHandle());
        }

        public IResultSet ExecuteQuery(Sql sql)
        {
            bool prepared = Prepare(sql);

            if (!prepared)
                throw new InvalidOperationException("Couldn't prepare");

            var set = new ResultSet(_stmt, _conn);
            _stmt = IntPtr.Zero;

            return set;
        }

        public async Task<IResultSet> ExecuteQueryAsync(Sql sql)
        {
            return await Task.Run(() =>
            {
                return ExecuteQuery(sql);
            }).ConfigureAwait(false);
        }

        public async Task<int> ExecuteUpdateAsync(Sql sql)
        {
            return await Task.Run(() =>
            {
                return ExecuteUpdate(sql);
            }).ConfigureAwait(false);
        }

        public async Task<bool> ExecuteAsync(Sql sql)
        {
            return await Task.Run(() =>
            {
                return Execute(sql);
            }).ConfigureAwait(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                Clear();
                disposedValue = true;
            }
        }

        ~Statement()
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
