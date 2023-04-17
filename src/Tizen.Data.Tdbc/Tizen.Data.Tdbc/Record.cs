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

namespace Tizen.Data.Tdbc
{
    /// <summary>
    /// Record class. This class provides the result of query.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public interface IRecord : IEnumerator<IRecord>
    {
        /// <summary>
        /// Get integer type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        int GetInt(int columnIndex);

        /// <summary>
        /// Get string type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        string GetString(int columnIndex);

        /// <summary>
        /// Get double type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        double GetDouble(int columnIndex);

        /// <summary>
        /// Get bool type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        bool GetBool(int columnIndex);

        /// <summary>
        /// Get blob type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        byte[] GetData(int columnIndex);

        /// <summary>
        /// Get char type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        char GetChar(int columnIndex);

        /// <summary>
        /// Get chars type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        char[] GetChars(int columnIndex);

        /// <summary>
        /// Get date type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        DateTime GetDate(int columnIndex);

        /// <summary>
        /// Get datetime type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        DateTime GetDateTime(int columnIndex);

        /// <summary>
        /// Get decimal type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        Decimal GetDecimal(int columnIndex);

        /// <summary>
        /// Get float type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        float GetFloat(int columnIndex);

        /// <summary>
        /// Get 16-bit signed integer type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        short GetInt16(int columnIndex);

        /// <summary>
        /// Get 64-bit signed integer type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        long GetInt64(int columnIndex);

        /// <summary>
        /// Get time type value from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        TimeSpan GetTime(int columnIndex);

        /// <summary>
        /// Get the name from the record with given index.
        /// </summary>
        /// <param name="columnIndex">The index of value.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <exception cref="NotSupportedException">This type is not supported.</exception>
        /// <since_tizen> 11 </since_tizen>
        string GetName(int columnIndex);
    }
}
