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
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.Data.Tdbc.Driver.Sqlite
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class Record : IRecord
    {
        private IntPtr _stmt;
        IRecord IEnumerator<IRecord>.Current => this;
        public object Current => this.Current;

        internal Record(IntPtr stmt)
        {
            _stmt = stmt;
        }

        public bool MoveNext()
        {
            int ret = Interop.Sqlite.Step(_stmt);
            if (ret != (int)Interop.Sqlite.ResultCode.SQLITE_ROW)
                return false;

            return true;
        }

        public void Reset()
        {
            Interop.Sqlite.Reset(_stmt);
        }

        public bool GetBool(int columnIndex)
        {
            int ret = Interop.Sqlite.ColumnInt(_stmt, columnIndex);
            if (ret == 0)
                return false;
            return true;
        }

        public byte[] GetData(int columnIndex)
        {
            IntPtr raw = Interop.Sqlite.ColumnBlob(_stmt, columnIndex);
            if (raw == IntPtr.Zero)
                return null;

            int size = Interop.Sqlite.ColumnBytes(_stmt, columnIndex);
            byte[] ret = new byte[size];
            Marshal.Copy((IntPtr)raw, (byte[])ret, 0, (int)size);

            return ret;
        }

        public double GetDouble(int columnIndex)
        {
            return Interop.Sqlite.ColumnDouble(_stmt, columnIndex);
        }

        public int GetInt(int columnIndex)
        {
            return Interop.Sqlite.ColumnInt(_stmt, columnIndex);
        }

        public string GetString(int columnIndex)
        {
            IntPtr raw = Interop.Sqlite.ColumnText(_stmt, columnIndex);

            return Marshal.PtrToStringAnsi(raw);
        }

        public char GetChar(int columnIndex)
        {
            throw new NotImplementedException();
        }

        public char[] GetChars(int columnIndex)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDate(int columnIndex)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int columnIndex)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int columnIndex)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int columnIndex)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int columnIndex)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int columnIndex)
        {
            throw new NotImplementedException();
        }

        public TimeSpan GetTime(int columnIndex)
        {
            throw new NotImplementedException();
        }

        public string GetName(int columnIndex)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
