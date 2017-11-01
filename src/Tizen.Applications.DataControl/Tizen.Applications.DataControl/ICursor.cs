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
    /// This interface is for the DataControl cursor.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public interface ICursor
    {
        /// <summary>
        /// Gets a column count.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        int GetColumnCount();
        /// <summary>
        /// Gets a column type.
        /// </summary>
        /// <param name="index">The index of column.</param>
        /// <since_tizen> 3 </since_tizen>
        ColumnType GetColumnType(int index);
        /// <summary>
        /// Gets a column name.
        /// </summary>
        /// <param name="index">The index of column.</param>
        /// <since_tizen> 3 </since_tizen>
        string GetColumnName(int index);
        /// <summary>
        /// Gets the numbers of rows in the cursor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        long GetRowCount();
        /// <summary>
        /// Gets a next row.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        bool Next();
        /// <summary>
        /// Gets a prev row.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        bool Prev();
        /// <summary>
        /// Gets a first row.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        bool Reset();
        /// <summary>
        /// Gets an integer value.
        /// </summary>
        /// <param name="index">The index of row.</param>
        /// <since_tizen> 3 </since_tizen>
        int GetIntValue(int index);
        /// <summary>
        /// Gets an int64 value.
        /// </summary>
        /// <param name="index">The index of row.</param>
        /// <since_tizen> 3 </since_tizen>
        Int64 GetInt64Value(int index);
        /// <summary>
        /// Gets a double value.
        /// </summary>
        /// <param name="index">The index of row.</param>
        /// <since_tizen> 3 </since_tizen>
        double GetDoubleValue(int index);
        /// <summary>
        /// Gets a string value.
        /// </summary>
        /// <param name="index">The index of row.</param>
        /// <since_tizen> 3 </since_tizen>
        string GetStringValue(int index);
        /// <summary>
        /// Gets a BLOB value.
        /// </summary>
        /// <param name="index">The index of row.</param>
        /// <since_tizen> 3 </since_tizen>
        byte[] GetBlobValue(int index);
    }
}