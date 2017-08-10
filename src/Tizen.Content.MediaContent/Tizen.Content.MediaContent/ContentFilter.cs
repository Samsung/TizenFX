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
using System.Runtime.InteropServices;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// The Content Filter API provides functions to manage media filters.
    /// </summary>
    /// <remarks>
    /// A Content filter is required for filtering information associated with Media Folder, Tag, Audio, MediaBookmark and Media Information on basis of details like offset, count, order and condition for searching.
    /// It provide functionality to set properties associated with a given content filter.
    /// Setting content filter properties helps to limit the number of filtered items as following:
    /// <list>
    /// <item><description>
    /// Offset - Used to set starting position of the filter's search
    /// </description></item>
    /// <item><description>
    /// Count - Used to set number of items to be searched from offset
    /// </description></item>
    /// <item><description>
    /// Condition - Used to set keyword which user want to search
    /// </description></item>
    /// <item><description>
    /// Order - Used to set type of media to be ordered by the filter
    /// </description></item>
    /// </list>
    /// Searchable expression can use one of the following forms:
    /// <list>
    /// <item><description>
    /// column = value
    /// </description></item>
    /// <item><description>
    /// column > value
    /// </description></item>
    /// <item><description>
    /// column >= value
    /// </description></item>
    /// <item><description>
    /// column < value
    /// </description></item>
    /// <item><description>
    /// column <= value
    /// </description></item>
    /// <item><description>
    /// value = column
    /// </description></item>
    /// <item><description>
    /// value >= column
    /// </description></item>
    /// <item><description>
    /// value < column
    /// </description></item>
    /// <item><description>
    /// value <= column
    /// </description></item>
    /// <item><description>
    /// column IN (value)
    /// </description></item>
    /// <item><description>
    /// column IN(value-list)
    /// </description></item>
    /// <item><description>
    /// column NOT IN(value)
    /// </description></item>
    /// <item><description>
    /// column NOT IN(value-list)
    /// </description></item>
    /// <item><description>
    /// column LIKE value
    /// </description></item>
    /// <item><description>
    /// expression1 AND expression2 OR expression3
    /// </description></item>
    /// </list>
    /// Note that if you want to set qoutation(" ' " or " " ") as value of LIKE operator, you should use two times.(" '' " or " "" ") \n And the optional ESCAPE clause is supported. Both percent symbol("%") and underscore symbol("_") are used in the LIKE pattern.
    /// If these characters are used as value of LIKE operation, then the expression following the ESCAPE caluse of sqlite.
    /// </remarks>
    public class ContentFilter : IDisposable
    {
        private IntPtr _filterHandle = IntPtr.Zero;
        private bool _disposedValue = false;
        private ContentCollation _conditionCollate = ContentCollation.Default;
        private ContentCollation _orderCollate = ContentCollation.Default;
        private ContentOrder _orderType = ContentOrder.Asc;
        private string _orderKeyword = null;
        private string _conditionMsg = null;

        internal IntPtr Handle
        {
            get
            {
                if (_filterHandle == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(nameof(ContentFilter));
                }

                return _filterHandle;
            }
        }
        /// <summary>
        /// The start position of the given filter Starting from zero.
        /// Please note that count value has to be set properly for correct result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Offset
        {
            get
            {
                int offset;
                int count;
                MediaContentValidator.ThrowIfError(
                    Interop.Filter.GetOffset(Handle, out offset, out count), "Failed to get offset");

                return offset;
            }

            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Filter.SetOffset(Handle, value, this.Count), "Failed to set offset");
            }
        }

        public ContentFilter()
        {
            MediaContentValidator.ThrowIfError(
                Interop.Filter.Create(out _filterHandle), "Failed to Create Filter handle.");
        }

        /// <summary>
        /// The number of items to be searched with respect to the offset
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Count
        {
            get
            {
                int offset;
                int count;
                MediaContentValidator.ThrowIfError(
                    Interop.Filter.GetOffset(Handle, out offset, out count), "Failed to get count");

                return count;
            }

            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Filter.SetOffset(Handle, this.Offset, value), "Failed to set count");
            }
        }

        /// <summary>
        /// Gets the media filter content order and order keyword.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ContentOrder Order
        {
            get
            {
                return _orderType;
            }

            set
            {
                if (_orderKeyword != null)
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Filter.SetOrder(Handle, value, _orderKeyword, _orderCollate), "Failed to set order");
                }

                _orderType = value;
            }
        }

        /// <summary>
        /// The search order keyword
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string OrderKey
        {
            get
            {
                ContentOrder order;
                IntPtr val = IntPtr.Zero;
                ContentCollation type;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Filter.GetOrder(Handle, out order, out val, out type), "Failed to GetOrder for OrderKey");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }

            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Filter.SetOrder(Handle, _orderType, value, _orderCollate), "Failed to set OrderKey");

                _orderKeyword = value;
            }
        }

        /// <summary>
        /// The collate type for comparing two strings
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ContentCollation OrderCollationType
        {
            get
            {
                return _orderCollate;
            }

            set
            {
                if (_orderKeyword != null)
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Filter.SetOrder(Handle, _orderType, _orderKeyword, value), "Failed to set collation");
                }

                _orderCollate = value;
            }
        }

        /// <summary>
        /// Gets/Sets the condition for the given filter.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Condition
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                ContentCollation type;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Filter.GetCondition(Handle, out val, out type), "Failed to get condition");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }

            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Filter.SetCondition(Handle, value, _conditionCollate), "Failed to set condition");

                _conditionMsg = value;
            }
        }

        /// <summary>
        /// The collate type for comparing two strings
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ContentCollation ConditionCollationType
        {
            get
            {
                return _conditionCollate;
            }

            set
            {
                if (_conditionMsg != null)
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Filter.SetCondition(Handle, _conditionMsg, value), "Failed to set collation");
                }

                _conditionCollate = value;
            }
        }

        /// <summary>
        /// Sets the storage id for the given filter.
        /// You can use this property when you want to search items only in the specific storage
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string StorageId
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Filter.GetStorage(Handle, out val), "Failed to get condition");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }

            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Filter.SetStorage(Handle, value), "Failed to set condition");
            }
        }

        /// <summary>
        /// The type of the media group
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public MediaGroupType GroupType { get; set; }

        /// <summary>
        /// Dispose API for closing the internal resources.
        /// This function can be used to stop all effects started by Vibrate().
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (_filterHandle != IntPtr.Zero)
                {
                    Interop.Filter.Destroy(_filterHandle);
                    _filterHandle = IntPtr.Zero;
                }

                _disposedValue = true;
            }
        }
    }
}
