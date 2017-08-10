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

namespace Tizen.Applications.DataControl
{
    /// <summary>
    /// This class is for containing insert operation result.
    /// </summary>
    public class InsertResult
    {
        /// <summary>
        /// Gets the insert data's row id.
        /// </summary>
        public long RowID
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the insert operation result.
        /// </summary>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes InsertResult class with columnNames and columnTypes.
        /// </summary>
        /// <param name="rowID">Inserted row ID</param>
        /// <param name="result">Insert request result</param>
        public InsertResult(long rowID, bool result)
        {
            RowID = rowID;
            Result = result;
        }
    }

    /// <summary>
    /// This class is for containing bulk insert operation result.
    /// </summary>
    public class BulkInsertResult
    {
        /// <summary>
        /// Gets the bulk insert operation result data.
        /// </summary>
        public BulkResultData BulkResultData
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the bulk insert operation result.
        /// </summary>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes InsertResult class with bulkResultData and result.
        /// </summary>
        /// <param name="bulkResultData">Bulk insert request result data</param>
        /// <param name="result">Bulk insert request result</param>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        public BulkInsertResult(BulkResultData bulkResultData, bool result)
        {
            if (result == true && (bulkResultData == null || bulkResultData.SafeBulkDataHandle.IsInvalid))
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "bulkResultData");
            }

            BulkResultData = bulkResultData;
            Result = result;
        }
    }

    /// <summary>
    /// This class is for containing update operation result.
    /// </summary>
    public class UpdateResult
    {
        /// <summary>
        /// Gets the update operation result.
        /// </summary>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes UpdateResult class with result.
        /// </summary>
        /// <param name="result">Update request result</param>
        public UpdateResult(bool result)
        {
            Result = result;
        }
    }

    /// <summary>
    /// This class is for containing delete operation result.
    /// </summary>
    public class DeleteResult
    {
        /// <summary>
        /// Gets the delete operation result.
        /// </summary>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes DeleteResult class with result.
        /// </summary>
        /// <param name="result">Delete request result</param>
        public DeleteResult(bool result)
        {
            Result = result;
        }
    }

    /// <summary>
    /// This class is for containing select operation result.
    /// </summary>
    public class SelectResult
    {
        /// <summary>
        /// Gets the select operation result cursor.
        /// </summary>
        public ICursor ResultCursor
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the select operation result.
        /// </summary>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes SelectResult class with cursor and result.
        /// </summary>
        /// <param name="cursor">Cursor with selected data</param>
        /// <param name="result">Select request result</param>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        public SelectResult(ICursor cursor, bool result)
        {
            int i;

            if (result == true && cursor == null)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "cursor");
            }

            if (result == true && (cursor is MatrixCursor) == false)
            {
                if (cursor.GetColumnCount() <= 0)
                {
                    ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "column count");
                }

                for (i = 0; i < cursor.GetColumnCount(); i++)
                {
                    if (string.IsNullOrEmpty(cursor.GetColumnName(i)))
                    {
                        ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "column name index " + i.ToString());
                    }

                    if (cursor.GetColumnType(i) < ColumnType.ColumnTypeInt || cursor.GetColumnType(i) > ColumnType.ColumnTypeBlob)
                    {
                        ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "column type index" + i.ToString());
                    }
                }
            }

            ResultCursor = cursor;
            Result = result;
        }
    }

    /// <summary>
    /// This class is for containing MapAdd operation result.
    /// </summary>
    public class MapAddResult
    {

        /// <summary>
        /// Gets the MapAdd operation result.
        /// </summary>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes MapAddResult class with result.
        /// </summary>
        /// <param name="result">MapAdd request result</param>
        public MapAddResult(bool result)
        {
            Result = result;
        }
    }

    /// <summary>
    /// This class is for containing MapBulkAdd operation result.
    /// </summary>
    public class MapBulkAddResult
    {
        /// <summary>
        /// Gets the MapBulkAdd operation result data.
        /// </summary>
        public BulkResultData BulkResultData
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the MapBulkAdd operation result.
        /// </summary>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes MapBulkAddResult class with bulkResultData and result.
        /// </summary>
        /// <param name="bulkResultData">MapBulkAdd request result data</param>
        /// <param name="result">MapBulkAdd request result</param>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        public MapBulkAddResult(BulkResultData bulkResultData, bool result)
        {
            if (result == true && (bulkResultData == null || bulkResultData.SafeBulkDataHandle.IsInvalid))
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "bulkResultData");
            }

            BulkResultData = bulkResultData;
            Result = result;
        }
    }

    /// <summary>
    /// This class is for containing MapSet operation result.
    /// </summary>
    public class MapSetResult
    {
        /// <summary>
        /// Gets the MapSet operation result.
        /// </summary>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes MapSetResult class with result.
        /// </summary>
        /// <param name="result">MapSet request result</param>
        public MapSetResult(bool result)
        {
            Result = result;
        }
    }

    /// <summary>
    /// This class is for containing MapRemove operation result.
    /// </summary>
    public class MapRemoveResult
    {
        /// <summary>
        /// Gets the MapRemove operation result.
        /// </summary>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes MapRemoveResult class with result.
        /// </summary>
        /// <param name="result">MapRemove request result</param>
        public MapRemoveResult(bool result)
        {
            Result = result;
        }
    }

    /// <summary>
    /// This class is for containing MapGet operation result.
    /// </summary>
    public class MapGetResult
    {
        /// <summary>
        /// Gets the result value list of the MapGet operation.
        /// </summary>
        public string[] ValueList
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the MapGet operation result.
        /// </summary>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes MapGetResult class with data and result.
        /// </summary>
        /// <param name="valueLIst">MapGet request result data</param>
        /// <param name="result">MapGet request result</param>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        public MapGetResult(string[] valueLIst, bool result)
        {
            if (result == true && valueLIst == null)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "valueLIst");
            }

            ValueList = valueLIst;
            Result = result;
        }
    }

    /// <summary>
    /// This class is for containing DataChangeListen operation result.
    /// </summary>
    public class DataChangeListenResult
    {
        /// <summary>
        /// Gets the DataChangeListen operation result.
        /// </summary>
        public ResultType Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes DataChangeListenResult class with result.
        /// </summary>
        /// <param name="result">DataChangeListen request result</param>
        public DataChangeListenResult(ResultType result)
        {
            Result = result;
        }
    }
}
