/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Specifies the database errors.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum MediaDatabaseError
    {
        /// <summary>
        /// Operation failed.
        /// </summary>
        OperationFailed,

        /// <summary>
        /// Operation failed because the database is busy.
        /// </summary>
        DatabaseBusy
    }

    /// <summary>
    /// The exception that is thrown when a database operation failed.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class MediaDatabaseException : Exception
    {
        internal MediaDatabaseException(MediaDatabaseError error) : this(error, error.ToString())
        {
        }

        internal MediaDatabaseException(MediaDatabaseError error, string message) : this(error, message, null)
        {
        }

        internal MediaDatabaseException(MediaDatabaseError error, string message, Exception innerException) :
            base(message, innerException)
        {
            Error = error;
        }

        /// <summary>
        /// Gets the error that causes the exception.
        /// </summary>
        /// <value>The <see cref="MediaDatabaseError"/> that causes the exception.</value>
        /// <since_tizen> 4 </since_tizen>
        public MediaDatabaseError Error { get; }
    }
}
