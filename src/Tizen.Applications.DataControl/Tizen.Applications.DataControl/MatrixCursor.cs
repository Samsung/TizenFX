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
using System.Diagnostics;

namespace Tizen.Applications.DataControl
{
    /// <summary>
    /// Represents MatrixCursor class for DataControl provider's matrix cursor.
    /// </summary>
    public class MatrixCursor : IDisposable, ICursor
    {
        private const string LogTag = "Tizen.Applications.DataControl";
        private FileStream _fs;
        private bool _disposed = false;
        private string _cursorPath;
        private long _rowCount = 0;
        private long _rowCountPosition = 0;
        private int _currentRowIndex = 0;
        private IList<long> _rowFieldOffset = new List<long>();
        private string[] _columnNames;
        private ColumnType[] _columnTypes;
        private const int ColumnTypeNull = 5;

        private byte[] GetValue(int index)
        {
            byte[] int_tmp = new byte[sizeof(int)];
            byte[] ret_array;
            ColumnType type;
            int size, read_len;

            MoveToColumn(index);

            read_len = _fs.Read(int_tmp, 0, int_tmp.Length);
            if (read_len != int_tmp.Length)
            {
                ErrorFactory.ThrowException(ResultType.IoError, true, "Column Type " + index.ToString());
            }

            type = (ColumnType)BitConverter.ToInt32(int_tmp, 0);

            if (type != _columnTypes[index])
            {
                if ((int)type == ColumnTypeNull &&
                    (_columnTypes[index] == ColumnType.ColumnTypeBlob || _columnTypes[index] == ColumnType.ColumnTypeString))
                {
                    return null; /* null type */
                }

                ErrorFactory.ThrowException(ResultType.IoError, true, "Type mismatch " + index.ToString());
            }

            read_len = _fs.Read(int_tmp, 0, int_tmp.Length);
            if (read_len != int_tmp.Length)
            {
                ErrorFactory.ThrowException(ResultType.IoError, true, "Column size " + index.ToString());
            }

            size = BitConverter.ToInt32(int_tmp, 0);

            if (size < 0)
            {
                ErrorFactory.ThrowException(ResultType.IoError, true, "Invalid data size " + index.ToString());
            }

            ret_array = new byte[size];
            read_len = _fs.Read(ret_array, 0, ret_array.Length);
            if (read_len != ret_array.Length)
            {
                ErrorFactory.ThrowException(ResultType.IoError, true, "Column value size " + index.ToString());
                return null;
            }

            return ret_array;
        }

        private void MoveToColumn(int ColumnIndex)
        {
            int i, tmp_position;
            byte[] int_tmp = new byte[sizeof(int)];
            int read_len;
            long seek_len;

            seek_len = _fs.Seek(_rowFieldOffset[_currentRowIndex], SeekOrigin.Begin);
            if (seek_len != _rowFieldOffset[_currentRowIndex])
            {
                ErrorFactory.ThrowException(ResultType.IoError, true, "Row index " + _currentRowIndex.ToString());
            }

            for (i = 0; i < ColumnIndex; i++)
            {
                /* type(int) size(int) value */
                switch (_columnTypes[i])
                {
                    case ColumnType.ColumnTypeInt:
                        tmp_position = sizeof(int) * 2 + sizeof(Int64);
                        _fs.Seek(tmp_position, SeekOrigin.Current);
                        break;
                    case ColumnType.ColumnTypeDouble:
                        tmp_position = sizeof(int) * 2 + sizeof(double);
                        _fs.Seek(tmp_position, SeekOrigin.Current);
                        break;
                    case ColumnType.ColumnTypeString:
                        tmp_position = sizeof(int);
                        _fs.Seek(tmp_position, SeekOrigin.Current);
                        read_len = _fs.Read(int_tmp, 0, int_tmp.Length);
                        if (read_len != int_tmp.Length)
                        {
                            ErrorFactory.ThrowException(ResultType.IoError, true, "Column Index " + ColumnIndex.ToString());
                        }

                        tmp_position = BitConverter.ToInt32(int_tmp, 0);

                        if (tmp_position > 0)
                        {
                            _fs.Seek(tmp_position, SeekOrigin.Current);
                        }

                        break;
                    case ColumnType.ColumnTypeBlob:
                        tmp_position = sizeof(int);
                        _fs.Seek(tmp_position, SeekOrigin.Current);

                        read_len = _fs.Read(int_tmp, 0, int_tmp.Length);
                        if (read_len != int_tmp.Length)
                        {
                            ErrorFactory.ThrowException(ResultType.IoError, true, "Column Index " + ColumnIndex.ToString());
                        }

                        tmp_position = BitConverter.ToInt32(int_tmp, 0);

                        if (tmp_position > 0)
                        {
                            _fs.Seek(tmp_position, SeekOrigin.Current);
                        }

                        break;
                }
            }

        }

        internal FileStream GetFileStream()
        {
            return _fs;
        }

        /// <summary>
        /// Gets column count of MatrixCursor.
        /// </summary>
        public int GetColumnCount()
        {
            return _columnTypes.Length;
        }

        /// <summary>
        /// Returns the column type at the given zero-based column index.
        /// </summary>
        /// <param name="index">Target column index</param>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        public ColumnType GetColumnType(int index)
        {
            if (index < 0 || index >= _columnTypes.Length)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            return _columnTypes[index];
        }

        /// <summary>
        /// Returns the column name at the given zero-based column index.
        /// </summary>
        /// <param name="index">Target column index</param>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        public string GetColumnName(int index)
        {
            if (index < 0 || index >= _columnTypes.Length)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            return _columnNames[index];
        }

        /// <summary>
        /// Gets MatrixCursor's row count.
        /// </summary>
        public long GetRowCount()
        {
            return _rowCount;
        }

        /// <summary>
        /// Move the MatrixCursor to the next row.
        /// </summary>
        public bool Next()
        {
            if (_currentRowIndex >= _rowCount - 1)
            {
                return false;
            }

            _currentRowIndex++;
            return true;
        }

        /// <summary>
        /// Move the MatrixCursor to the previous row.
        /// </summary>
        public bool Prev()
        {
            if (_currentRowIndex <= 0)
            {
                return false;
            }

            _currentRowIndex--;
            return true;
        }

        /// <summary>
        /// Move the MatrixCursor to the first row.
        /// </summary>
        public bool Reset()
        {
            _currentRowIndex = 0;
            return true;
        }

        /// <summary>
        /// Returns the value of the requested column as a int.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        public int GetIntValue(int index)
        {
            int ret;
            byte[] byte_array;

            if (index < 0 || index >= _columnTypes.Length)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            byte_array = GetValue(index);
            if (byte_array == null)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }
            ret = BitConverter.ToInt32(byte_array, 0);

            return ret;
        }

        /// <summary>
        /// Returns the value of the requested column as a int64.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        public Int64 GetInt64Value(int index)
        {
            Int64 ret;
            byte[] byte_array;

            if (index < 0 || index >= _columnTypes.Length)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            byte_array = GetValue(index);
            if (byte_array == null)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }
            ret = BitConverter.ToInt64(byte_array, 0);

            return ret;
        }

        /// <summary>
        /// Returns the value of the requested column as a double.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        public double GetDoubleValue(int index)
        {
            double ret;
            byte[] byte_array;

            if (index < 0 || index >= _columnTypes.Length)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            byte_array = GetValue(index);
            if (byte_array == null)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }
            ret = BitConverter.ToDouble(byte_array, 0);

            return ret;
        }

        /// <summary>
        /// Returns the value of the requested column as a string.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        public string GetStringValue(int index)
        {
            string ret;
            byte[] byte_array;

            if (index < 0 || index >= _columnTypes.Length)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            byte_array = GetValue(index);

            if (byte_array == null)
            {
                return null;
            }

            ret = Encoding.UTF8.GetString(byte_array);
            return ret;

        }

        /// <summary>
        /// Returns the value of the requested column as a blob.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        public byte[] GetBlobValue(int index)
        {
            byte[] byte_array;

            if (index < 0 || index >= _columnTypes.Length)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            byte_array = GetValue(index);
            return byte_array;
        }

        private static class FileManager
        {
            private static readonly string DATACONTROL_DIRECTORY = "/tmp/";
            private static Dictionary<int, int> fileTable = new Dictionary<int, int>();
            public static string OpenFileStream(int threadID)
            {
                string path;
                int index;

                if (threadID < 0)
                {
                    Log.Error(LogTag, "threadID is " + threadID.ToString());
                    return null;
                }

                if (fileTable.ContainsKey(threadID) == false)
                {
                    fileTable.Add(threadID, 0);
                }

                index = fileTable[threadID];
                index++;
                fileTable[threadID] = index;

                path = DATACONTROL_DIRECTORY + Application.Current.ApplicationInfo.ApplicationId + "_" + Process.GetCurrentProcess().Id.ToString() + "_" + threadID.ToString() + "_" + index.ToString();

                return path;
            }
        }

        /// <summary>
        /// Initializes MatrixCursor class with columnNames and columnTypes.
        /// </summary>
        /// <param name="columnNames">MatrixCursor's column name list</param>
        /// <param name="columnTypes">MatrixCursor's column type list</param>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        ///  <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        public MatrixCursor(string[] columnNames, ColumnType[] columnTypes)
        {
            byte[] byte_tmp, length_tmp, string_tmp;
            int i, total_len_of_column_names = 0;

            if (columnNames == null || columnTypes == null ||
                (columnNames.Length != columnTypes.Length) || columnNames.Length < 1)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            for (i = 0; i < columnNames.Length; i++)
            {
                if (string.IsNullOrEmpty(columnNames[i]))
                {
                    ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "columnNames index " + i.ToString());
                }
            }

            for (i = 0; i < columnTypes.Length; i++)
            {
                if ( columnTypes[i] < ColumnType.ColumnTypeInt || columnTypes[i] > ColumnType.ColumnTypeBlob)
                {
                    ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "columnTypes index" + i.ToString());
                }
            }

            _columnNames = columnNames;
            _columnTypes = columnTypes;

            _cursorPath = FileManager.OpenFileStream(Thread.CurrentThread.ManagedThreadId);
            if (_cursorPath == null)
            {
                Log.Error(LogTag, "Unable to create a cursor file : " + _cursorPath);
                ErrorFactory.ThrowException(ResultType.IoError, true);
            }

            _fs = new FileStream(_cursorPath, FileMode.Create);
            /* column count */
            byte_tmp = BitConverter.GetBytes(columnNames.Length);
            _fs.Write(byte_tmp, 0, byte_tmp.Length);

            /* column type */
            for (i = 0; i < columnTypes.Length; i++)
            {
                byte_tmp = BitConverter.GetBytes((int)_columnTypes[i]);
                _fs.Write(byte_tmp, 0, byte_tmp.Length);
            }

            /* column name */
            for (i = 0; i < columnTypes.Length; i++)
            {
                string_tmp = Encoding.UTF8.GetBytes(columnNames[i]);
                byte_tmp = new byte[string_tmp.Length + 1];/*insert null */

                string_tmp.CopyTo(byte_tmp, 0);

                length_tmp = BitConverter.GetBytes(byte_tmp.Length);
                total_len_of_column_names += length_tmp.Length;

                _fs.Write(length_tmp, 0, length_tmp.Length);
                _fs.Write(byte_tmp, 0, byte_tmp.Length);
            }

            /* total length of column names */
            byte_tmp = BitConverter.GetBytes(total_len_of_column_names);
            _fs.Write(byte_tmp, 0, byte_tmp.Length);

            _rowCountPosition = _fs.Position;
            /* row count */
            byte_tmp = BitConverter.GetBytes(_rowCount);
            _fs.Write(byte_tmp, 0, byte_tmp.Length);
            _fs.Flush();
        }

        internal MatrixCursor()
        {
            _columnNames = new string[0];
            _columnTypes = new ColumnType[0];
            _fs = null;
            _cursorPath = null;
        }

        /// <summary>
        /// Adds a new row to the end with the given column values.
        /// </summary>
        /// <param name="columnValues">New column values</param>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        public void AddRow(object[] columnValues)
        {
            int i, size = 0;
            byte[] type_array, length_array, value_array = null, string_array, byte_tmp;

            if (columnValues == null || columnValues.Length <= 0 || columnValues.Length != _columnTypes.Length)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false);
            }

            using (MemoryStream ms = new MemoryStream())
            {
                for (i = 0; i < _columnTypes.Length; i++)
                {
                    type_array = BitConverter.GetBytes((int)_columnTypes[i]);
                    switch (_columnTypes[i])
                    {
                        case ColumnType.ColumnTypeInt:
                            if (!(columnValues[i] is Int64) && !(columnValues[i] is Int32))
                            {
                                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "Type mismatch :Index "  + i.ToString());
                            }

                            value_array = BitConverter.GetBytes(Convert.ToUInt64(columnValues[i]));
                            size = value_array.Length;
                            break;
                        case ColumnType.ColumnTypeDouble:
                            if (!(columnValues[i] is Double))
                            {
                                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "Type mismatch :Index " + i.ToString());
                            }

                            value_array = BitConverter.GetBytes(Convert.ToDouble(columnValues[i]));
                            size = value_array.Length;
                            break;
                        case ColumnType.ColumnTypeString:
                            if (columnValues[i] == null)
                            {
                                type_array = BitConverter.GetBytes(ColumnTypeNull);
                                size = 0;
                                break;
                            }

                            if (!(columnValues[i] is string))
                            {
                                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "Type mismatch :Index " + i.ToString());
                            }

                            string_array = Encoding.UTF8.GetBytes(Convert.ToString(columnValues[i]));
                            value_array = new byte[string_array.Length + 1];/*insert null */
                            string_array.CopyTo(value_array, 0);
                            size = value_array.Length;
                            break;

                        case ColumnType.ColumnTypeBlob:
                            if (columnValues[i] == null)
                            {
                                type_array = BitConverter.GetBytes(ColumnTypeNull);
                                size = 0;
                                break;
                            }

                            if (!(columnValues[i] is byte[]))
                            {
                                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "Type mismatch :Index " + i.ToString());
                            }

                            value_array = (byte[])columnValues[i];
                            size = value_array.Length;
                            break;
                    }

                    ms.Write(type_array, 0, type_array.Length);

                    length_array = BitConverter.GetBytes(size);
                    ms.Write(length_array, 0, length_array.Length);
                    if (size > 0)
                    {
                        ms.Write(value_array, 0, value_array.Length);
                    }
                }

                /* update row count */
                _rowCount++;
                byte_tmp = BitConverter.GetBytes(_rowCount);
                _fs.Seek(_rowCountPosition, SeekOrigin.Begin);
                _fs.Write(byte_tmp, 0, byte_tmp.Length);

                _fs.Seek(0, SeekOrigin.End);

                _rowFieldOffset.Add(_fs.Position);
                ms.WriteTo(_fs);/* row data */
                _fs.Flush();

                Log.Debug(LogTag, "_fs pos = " + _fs.Position.ToString());
                Log.Debug(LogTag, "_fs len = " + _fs.Length.ToString());
            }
        }

        /// <summary>
        /// Releases all resources used by the MatrixCursor class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (!string.IsNullOrEmpty(_cursorPath))
                {
                    FileInfo fi = new FileInfo(_cursorPath);

                    if (_fs != null)
                    {
                        _fs.Dispose();
                    }

                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                }

                _disposed = true;
            }

            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        ~MatrixCursor()
        {
            Dispose(false);
        }
    }
}
