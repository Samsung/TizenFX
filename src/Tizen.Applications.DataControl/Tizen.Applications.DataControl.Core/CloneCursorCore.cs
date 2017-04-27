/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading;

namespace Tizen.Applications.DataControl.Core
{
    internal class CloneCursorCore : ICursor
    {
        internal const int MaxColumnNameSize = 1024;
        private const string LogTag = "Tizen.Applications.DataControl";
        private long _rowCount;
        private int _columnCount;
        private const int ResultNoData = -1;
        private Interop.DataControl.SafeCursorHandle _cursor;
        internal CloneCursorCore(Interop.DataControl.SafeCursorHandle cursor)
        {
            _cursor = cursor;
            _columnCount = Interop.DataControl.GetColumnCount(cursor);

            if (_columnCount == ResultNoData)
            {
                _rowCount = 0;
                return;
            }

            Interop.DataControl.First(cursor);

            do
            {
                _rowCount++;
            }
            while (Interop.DataControl.Next(cursor) == (int)ResultType.Success);
            Interop.DataControl.First(cursor);
        }

        public int GetColumnCount()
        {
            return Interop.DataControl.GetColumnCount(_cursor);
        }

        public ColumnType GetColumnType(int index)
        {
            int type;
            ResultType ret;

            if (index < 0 || index >= _columnCount)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            ret = Interop.DataControl.GetItemType(_cursor, index, out type);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "Column Index " + index.ToString());
            }

            return (ColumnType)type;
        }

        public string GetColumnName(int index)
        {
            string retStr;
            ResultType ret;
            StringBuilder columnName = new StringBuilder();

            if (index < 0 || index >= _columnCount)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            columnName.Length = MaxColumnNameSize;
            ret = Interop.DataControl.GetColumnName(_cursor, index, columnName);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "Column Index " + index.ToString());
            }

            retStr = columnName.ToString();
            columnName.Clear();
            columnName = null;

            return retStr;
        }

        public long GetRowCount()
        {
            return _rowCount;
        }

        public bool Next()
        {
            ResultType type = Interop.DataControl.Next(_cursor);

            if (type != ResultType.Success)
            {
                return false;
            }

            return true;
        }

        public bool Prev()
        {
            ResultType type = Interop.DataControl.Prev(_cursor);

            if (type != ResultType.Success)
            {
                return false;
            }

            return true;
        }

        public bool Reset()
        {
            ResultType type = Interop.DataControl.First(_cursor);

            if (type != ResultType.Success)
            {
                return false;
            }

            return true;
        }

        public int GetIntValue(int index)
        {
            ResultType ret;
            int value;

            if (index < 0 || index >= _columnCount)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            ret = Interop.DataControl.GetInt(_cursor, index, out value);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "Column Index " + index.ToString());
            }

            return value;
        }

        public Int64 GetInt64Value(int index)
        {
            ResultType ret;
            Int64 value;

            if (index < 0 || index >= _columnCount)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            ret = Interop.DataControl.GetInt64(_cursor, index, out value);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "Column Index " + index.ToString());
            }

            return value;
        }

        public double GetDoubleValue(int index)
        {
            ResultType ret;
            double value;

            if (index < 0 || index >= _columnCount)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            ret = Interop.DataControl.Getdouble(_cursor, index, out value);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false, "Column Index " + index.ToString());
            }

            return value;
        }

        public string GetStringValue(int index)
        {
            ResultType ret;
            int size;
            byte[] value;
            string text;

            if (index < 0 || index >= _columnCount)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            size = Interop.DataControl.GetItemSize(_cursor, index);
            if (size < 0)
            {
                ErrorFactory.ThrowException(ResultType.IoError, false, "Invalid size");
            }

            value = new byte[size + 1];
            ret = Interop.DataControl.GetText(_cursor, index, value);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false);
            }

            text = Encoding.UTF8.GetString(value);

            return text;
        }

        public byte[] GetBlobValue(int index)
        {
            ResultType ret;
            int size;
            byte[] byte_array;

            if (index < 0 || index >= _columnCount)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            size = Interop.DataControl.GetItemSize(_cursor, index);
            if (size < 0)
            {
                ErrorFactory.ThrowException(ResultType.IoError, false, "Invalid size");
            }

            byte_array = new byte[size];
            ret = Interop.DataControl.GetBlob(_cursor, index, byte_array, size);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, false);
            }

            return byte_array;
        }
    }
}