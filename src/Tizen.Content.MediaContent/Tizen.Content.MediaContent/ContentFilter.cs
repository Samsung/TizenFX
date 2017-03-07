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
        //private ContentOrder _order = ContentOrder.Asc;
        //private string _orderKey = "MEDIA_ID";
        private ContentCollation _collationType = ContentCollation.Default;
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
                MediaContentRetValidator.ThrowIfError(
                    Interop.Filter.GetOffset(_filterHandle, out offset, out count), "Failed to Get offset");

                return offset;
            }
            set
            {
                MediaContentRetValidator.ThrowIfError(
                    Interop.Filter.SetOffset(_filterHandle, value, this.Count), "Failed to Set offset");
            }
        }
        public ContentFilter()
        {
            MediaContentRetValidator.ThrowIfError(
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
                MediaContentRetValidator.ThrowIfError(
                    Interop.Filter.GetOffset(_filterHandle, out offset, out count), "Failed to Getoffset/count");

                return count;
            }
            set
            {
                MediaContentRetValidator.ThrowIfError(
                    Interop.Filter.SetOffset(_filterHandle, this.Offset, value), "Failed to Setoffset/Count");
            }
        }
        /// <summary>
        /// Gets the media filter content order and order keyword.
        /// </summary>
        public ContentOrder Order
        {
            get
            {
                int orderType;
                string orderKey;
                int collatetType;
                MediaContentRetValidator.ThrowIfError(
                    Interop.Filter.GetOrder(_filterHandle, out orderType, out orderKey, out collatetType), "Failed to GetOrder");

                return (ContentOrder)orderType;
            }
        }
        /// <summary>
        /// The collate type for comparing two strings
        /// </summary>
        public ContentCollation CollationType
        {
            get
            {
                string condition;
                int collatetType;
                MediaContentRetValidator.ThrowIfError(
                    Interop.Filter.GetCondition(_filterHandle, out condition, out collatetType), "Failed to GetCondition for CollationType");

                return (ContentCollation)collatetType;
            }
            set
            {
                _collationType = value;
                MediaContentRetValidator.ThrowIfError(
                    Interop.Filter.SetCondition(_filterHandle, this.Condition, (int)value), "Failed to SetCondition for CollationType");
            }
        }
        /// <summary>
        /// Gets/Sets the condition for the given filter.
        /// </summary>
        public string Condition
        {
            get
            {
                string conditionVal = "";
                int collatetType;
                MediaContentRetValidator.ThrowIfError(
                    Interop.Filter.GetCondition(_filterHandle, out conditionVal, out collatetType), "Failed to GetCondition");

                return conditionVal;
            }
            set
            {
                MediaContentRetValidator.ThrowIfError(
                    Interop.Filter.SetCondition(_filterHandle, value, (int)_collationType), "Failed to SetCondition");
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
                string storageId;
                MediaContentRetValidator.ThrowIfError(
                    Interop.Filter.GetStorage(_filterHandle, out storageId), "Failed to GetCondition");

                return storageId;
            }
            set
            {
                MediaContentRetValidator.ThrowIfError(
                    Interop.Filter.SetStorage(_filterHandle, value), "Failed to SetCondition");
            }
        }
        /// <summary>
        /// The search order keyword
        /// </summary>
        public string OrderKey
        {
            get
            {
                int orderType;
                string orderKey;
                int collatetType;
                MediaContentRetValidator.ThrowIfError(
                    Interop.Filter.GetOrder(_filterHandle, out orderType, out orderKey, out collatetType), "Failed to GetOrder for OrderKey");

                return orderKey;
            }
        }
        /// <summary>
        /// The type of the media group
        /// </summary>
        public MediaGroupType GroupType
        {
            get; set;
        }
        /// <summary>
        /// SetOrderProperties like OrderType and OrderKey.
        /// </summary>
        public void SetOrderProperties(ContentOrder order, string oderKey)
        {
            MediaContentRetValidator.ThrowIfError(
                Interop.Filter.SetOrder(_filterHandle, order, oderKey, CollationType), "Failed to SetOrder");
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
                    Interop.Filter.Destroy(_filterHandle); //destroy filterHandle

                    _filterHandle = IntPtr.Zero;
                }
                _disposedValue = true;
            }
        }
    }
}
