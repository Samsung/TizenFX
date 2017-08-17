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
    /// Enumeration for the DataControl column types.
    /// </summary>
    public enum ColumnType : short
    {
        /// <summary>
        /// Value representing DataControl operation success.
        /// </summary>
        ColumnTypeInt = 1,
        /// <summary>
        /// Value representing DataControl operation success.
        /// </summary>
        ColumnTypeDouble = 2,
        /// <summary>
        /// Value representing DataControl operation success.
        /// </summary>
        ColumnTypeString = 3,
        /// <summary>
        /// Value representing DataControl operation success.
        /// </summary>
        ColumnTypeBlob = 4
    }

    /// <summary>
    /// Enumeration for the DataControl column types.
    /// </summary>
    public enum ChangeType : short
    {
        /// <summary>
        /// Value representing DataControl provider data changed by update.
        /// </summary>
        Update,
        /// <summary>
        /// Value representing DataControl provider data changed by insert.
        /// </summary>
        Insert,
        /// <summary>
        /// Value representing DataControl provider data changed by delete.
        /// </summary>
        Delete,
        /// <summary>
        /// Value representing DataControl provider data changed by map add.
        /// </summary>
        MapAdd,
        /// <summary>
        /// Value representing  DataControl provider data changed by map remove.
        /// </summary>
        MapRemove,
        /// <summary>
        /// Value representing DataControl provider data changed by map set.
        /// </summary>
        MapSet,
    }

    /// <summary>
    /// Enumeration for the DataControl result types.
    /// </summary>
    public enum ResultType : int
    {
        /// <summary>
        /// Value representing DataControl operation success.
        /// </summary>
        Success = Interop.DataControl.NativeResultType.Success,
        /// <summary>
        /// Value representing DataControl operation causing out of memory error.
        /// </summary>
        OutOfMemory = Interop.DataControl.NativeResultType.OutOfMemory,
        /// <summary>
        /// Value representing DataControl operation causing I/O error.
        /// </summary>
        IoError = Interop.DataControl.NativeResultType.IoError,
        /// <summary>
        /// Value representing DataControl operation causing invalid parameter error.
        /// </summary>
        InvalidParameter = Interop.DataControl.NativeResultType.InvalidParameter,
        /// <summary>
        /// Value representing DataControl operation causing permission denied error.
        /// </summary>
        PermissionDenied = Interop.DataControl.NativeResultType.PermissionDenied,
        /// <summary>
        /// Value representing DataControl operation causing max exceed error.
        /// </summary>
        MaxExceed = Interop.DataControl.NativeResultType.MaxExceed,
    }
}
