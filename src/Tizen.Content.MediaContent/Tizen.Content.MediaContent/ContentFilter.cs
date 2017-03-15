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
    ///<list>
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

    ///<list>
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

        internal IntPtr Handle
        {
            get
            {
                return _filterHandle;
            }
        }
        /// <summary>
        /// The start position of the given filter Starting from zero.
        /// Please note that count value has to be set properly for correct result.
        /// </summary>
        public int Offset
        {
            get
            {
                int offset;
                int count;
                MediaContentValidator.ThrowIfError(
                    Interop.Filter.GetOffset(_filterHandle, out offset, out count), "Failed to get offset");

                return offset;
            }

            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Filter.SetOffset(_filterHandle, value, this.Count), "Failed to set offset");
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
        public int Count
        {
            get
            {
                int offset;
                int count;
                MediaContentValidator.ThrowIfError(
                    Interop.Filter.GetOffset(_filterHandle, out offset, out count), "Failed to get count");

                return count;
            }

            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Filter.SetOffset(_filterHandle, this.Offset, value), "Failed to set count");
            }
        }

        /// <summary>
        /// Gets the media filter content order and order keyword.
        /// </summary>
        public ContentOrder Order
        {
            get
            {
                ContentOrder order;
                IntPtr val = IntPtr.Zero;
                ContentCollation collate;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Filter.GetOrder(_filterHandle, out order, out val, out collate), "Failed to get order");

                    return order;
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// The collate type for comparing two strings
        /// </summary>
        public ContentCollation CollationType
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                ContentCollation type;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Filter.GetCondition(_filterHandle, out val, out type), "Failed to get collation");

                    return type;
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }

            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Filter.SetCondition(_filterHandle, this.Condition, value), "Failed to set collation");
            }
        }

        /// <summary>
        /// Gets/Sets the condition for the given filter.
        /// </summary>
        public string Condition
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                ContentCollation type;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Filter.GetCondition(_filterHandle, out val, out type), "Failed to get condition");

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
                    Interop.Filter.SetCondition(_filterHandle, value, this.CollationType), "Failed to set condition");
            }
        }

        /// <summary>
        /// Sets the storage id for the given filter.
        /// You can use this property when you want to search items only in the specific storage
        /// </summary>
        public string StorageId
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Filter.GetStorage(_filterHandle, out val), "Failed to get condition");

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
                    Interop.Filter.SetStorage(_filterHandle, value), "Failed to set condition");
            }
        }

        /// <summary>
        /// The search order keyword
        /// </summary>
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
                        Interop.Filter.GetOrder(_filterHandle, out order, out val, out type), "Failed to GetOrder for OrderKey");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// The type of the media group
        /// </summary>
        public MediaGroupType GroupType { get; set; }

        /// <summary>
        /// SetOrderProperties like OrderType and OrderKey.
        /// </summary>
        /// <param name="order">ordering type</param>
        /// <param name="oderKey">Keywords to sort</param>
        public void SetOrderProperties(ContentOrder order, string oderKey)
        {
            MediaContentValidator.ThrowIfError(
                Interop.Filter.SetOrder(_filterHandle, order, oderKey, CollationType), "Failed to set order");
        }


        /// <summary>
        /// Dispose API for closing the internal resources.
        /// This function can be used to stop all effects started by Vibrate().
        /// </summary>
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
