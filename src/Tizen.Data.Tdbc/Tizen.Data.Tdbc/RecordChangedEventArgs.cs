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

namespace Tizen.Data.Tdbc
{
    /// <summary>
    /// RecordChangedEventArgs class. This class is an event arguments of the RecordChanged events.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public class RecordChangedEventArgs : EventArgs
    {
        private readonly OperationType _operationType;
        private readonly string _database;
        private readonly string _table;
        private readonly IRecord _record;

        /// <summary>
        /// Creates and initializes a new instance of type of the RecordChangedEventArgs class.
        /// </summary>
        /// <param name="operationType">The operation type of the changed record.</param>
        /// <param name="database">The database of the changed record.</param>
        /// <param name="table">The table of the changed record.</param>
        /// <param name="record">The changed record.</param>
        /// <since_tizen> 11 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecordChangedEventArgs(OperationType operationType, string database, string table, IRecord record)
        {
            _operationType = operationType;
            _database = database;
            _table = table;
            _record = record;
        }

        /// <summary>
        /// Gets the operation type of the record changed event.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public OperationType OperationType { get { return _operationType; } }

        /// <summary>
        /// Gets the database name of the record chagned event.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public string Database { get { return _database; } }

        /// <summary>
        /// Gets the table name of the record changed event.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public string Table { get { return _table; } }

        /// <summary>
        /// Gets the changed record.
        /// </summary>
        /// <remarks>If the operation type is Delete, the changed record may by empty.</remarks>
        /// <since_tizen> 11 </since_tizen>
        public IRecord Record { get { return _record; } }
    }
}
