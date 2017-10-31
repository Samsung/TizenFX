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
    /// This class contains the insert operation result.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class InsertResult
    {
        /// <summary>
        /// Gets the insert data's row ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public long RowID
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the insert operation result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the InsertResult class with columnNames and columnTypes.
        /// </summary>
        /// <param name="rowID">The inserted row ID.</param>
        /// <param name="result">The insert request result.</param>
        /// <since_tizen> 3 </since_tizen>
        public InsertResult(long rowID, bool result)
        {
            RowID = rowID;
            Result = result;
        }
    }

    /// <summary>
    /// This class contains the bulk insert operation result.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BulkInsertResult
    {
        /// <summary>
        /// Gets the bulk insert operation result data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BulkResultData BulkResultData
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the bulk insert operation result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the InsertResult class with the bulkResultData and the result.
        /// </summary>
        /// <param name="bulkResultData">The bulk insert request result data.</param>
        /// <param name="result">The bulk insert request result.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <since_tizen> 3 </since_tizen>
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
    /// This class contains the update operation result.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class UpdateResult
    {
        /// <summary>
        /// Gets the update operation result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the UpdateResult class with the result.
        /// </summary>
        /// <param name="result">The update request result.</param>
        /// <since_tizen> 3 </since_tizen>
        public UpdateResult(bool result)
        {
            Result = result;
        }
    }

    /// <summary>
    /// This class contains the delete operation result.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class DeleteResult
    {
        /// <summary>
        /// Gets the delete operation result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the DeleteResult class with the result.
        /// </summary>
        /// <param name="result">The delete request result.</param>
        /// <since_tizen> 3 </since_tizen>
        public DeleteResult(bool result)
        {
            Result = result;
        }
    }

    /// <summary>
    /// This class contains the select operation result.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class SelectResult
    {
        /// <summary>
        /// Gets the select operation result cursor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ICursor ResultCursor
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the select operation result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the SelectResult class with the cursor and the result.
        /// </summary>
        /// <param name="cursor">The cursor with the selected data.</param>
        /// <param name="result">The select request result.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <since_tizen> 3 </since_tizen>
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
    /// This class contains the MapAdd operation result.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MapAddResult
    {

        /// <summary>
        /// Gets the MapAdd operation result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the MapAddResult class with the result.
        /// </summary>
        /// <param name="result">The MapAdd request result.</param>
        /// <since_tizen> 3 </since_tizen>
        public MapAddResult(bool result)
        {
            Result = result;
        }
    }

    /// <summary>
    /// This class contains the MapBulkAdd operation result.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MapBulkAddResult
    {
        /// <summary>
        /// Gets the MapBulkAdd operation result data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BulkResultData BulkResultData
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the MapBulkAdd operation result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the MapBulkAddResult class with the bulkResultData and the result.
        /// </summary>
        /// <param name="bulkResultData">The MapBulkAdd request result data.</param>
        /// <param name="result">The MapBulkAdd request result.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <since_tizen> 3 </since_tizen>
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
    /// This class contains the MapSet operation result.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MapSetResult
    {
        /// <summary>
        /// Gets the MapSet operation result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the MapSetResult class with the result.
        /// </summary>
        /// <param name="result">MapSet request result</param>
        /// <since_tizen> 3 </since_tizen>
        public MapSetResult(bool result)
        {
            Result = result;
        }
    }

    /// <summary>
    /// This class contains the MapRemove operation result.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MapRemoveResult
    {
        /// <summary>
        /// Gets the MapRemove operation result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the MapRemoveResult class with the result.
        /// </summary>
        /// <param name="result">The MapRemove request result.</param>
        /// <since_tizen> 3 </since_tizen>
        public MapRemoveResult(bool result)
        {
            Result = result;
        }
    }

    /// <summary>
    /// This class contains the MapGet operation result.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MapGetResult
    {
        /// <summary>
        /// Gets the result value list of the MapGet operation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string[] ValueList
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the MapGet operation result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the MapGetResult class with the data and the result.
        /// </summary>
        /// <param name="valueLIst">The MapGet request result data.</param>
        /// <param name="result">The MapGet request result.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <since_tizen> 3 </since_tizen>
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
    /// This class contains the DataChangeListen operation result.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class DataChangeListenResult
    {
        /// <summary>
        /// Gets the DataChangeListen operation result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ResultType Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the DataChangeListenResult class with the result.
        /// </summary>
        /// <param name="result">The DataChangeListen request result.</param>
        /// <since_tizen> 3 </since_tizen>
        public DataChangeListenResult(ResultType result)
        {
            Result = result;
        }
    }
}
