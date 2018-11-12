/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Enumeration for the complication error.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum ComplicationError
    {
        /// <summary>
        /// Error none.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        None = Interop.WatchfaceComplication.ErrorType.None,
        /// <summary>
        /// Out of memory error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        OutOfMemory = Interop.WatchfaceComplication.ErrorType.OutOfMemory,
        /// <summary>
        /// Invalid parameter error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        InvalidParam = Interop.WatchfaceComplication.ErrorType.InvalidParam,
        /// <summary>
        /// IO error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        IO = Interop.WatchfaceComplication.ErrorType.IO,
        /// <summary>
        /// No data error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        NoData = Interop.WatchfaceComplication.ErrorType.NoData,
        /// <summary>
        /// Permission deny error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        PermissionDeny = Interop.WatchfaceComplication.ErrorType.PermissionDeny,
        /// <summary>
        /// The complication API is not supported error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        NotSupported = Interop.WatchfaceComplication.ErrorType.NotSupported,
        /// <summary>
        /// DB operation error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DB = Interop.WatchfaceComplication.ErrorType.DB,
        /// <summary>
        /// DBus operation error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DBus = Interop.WatchfaceComplication.ErrorType.DBus,
        /// <summary>
        /// The editor is not ready for editing error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        EditNotReady = Interop.WatchfaceComplication.ErrorType.EditNotReady,
        /// <summary>
        /// Already exist ID error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ExistID = Interop.WatchfaceComplication.ErrorType.ExistID,
        /// <summary>
        /// Not exist error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        NotExist = Interop.WatchfaceComplication.ErrorType.NotExist,
        /// <summary>
        /// Not available error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        NotAvailable = Interop.WatchfaceComplication.ErrorType.NotAvailable
    }
}
