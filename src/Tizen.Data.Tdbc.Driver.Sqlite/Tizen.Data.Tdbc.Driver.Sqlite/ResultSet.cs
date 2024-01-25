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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.Data.Tdbc.Driver.Sqlite
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ResultSet : IResultSet
    {
        private IntPtr _stmt;
        private bool disposedValue;
        private Connection _conn;

        private void Clear()
        {
            if (_stmt != IntPtr.Zero)
            {
                Interop.Sqlite.Finalize(_stmt);
                _stmt = IntPtr.Zero;
            }
        }

        internal ResultSet(IntPtr stmt, Connection conn)
        {
            _stmt = stmt;
            _conn = conn;
        }

        public IEnumerator<IRecord> GetEnumerator()
        {
            return new Record(_stmt);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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

        ~ResultSet()
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
