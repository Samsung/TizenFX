/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

/// <summary>
/// The Content Filter API provides functions to manage media filters.
/// </summary>
/// <remarks>
/// A Content filter is required for filtering information associated with Media Folder, Tag, Audio, MediaBookmark and Media Information on basis of details like offset, count, order and condition for searching.
/// It provide functionality to set properties associated with a given content filter.

/// Setting content filter properties helps to limit the number of filtered items as following:

/// Offset - Used to set starting position of the filter's search
/// Count - Used to set number of items to be searched from offset
/// Condition - Used to set keyword which user want to search
/// Order - Used to set type of media to be ordered by the filter

/// Searchable expression can use one of the following forms:

/// column = value
/// column > value
/// column >= value
/// column < value
/// column <= value
/// value = column
/// * - value > column
/// value >= column
/// value < column
/// value <= column
/// column IN (value)
/// column IN(value-list)
/// column NOT IN(value)
/// column NOT IN(value-list)
/// column LIKE value
/// expression1 AND expression2 OR expression3

/// Note that if you want to set qoutation(" ' " or " " ") as value of LIKE operator, you should use two times.(" '' " or " "" ") \n And the optional ESCAPE clause is supported. Both percent symbol("%") and underscore symbol("_") are used in the LIKE pattern.
/// If these characters are used as value of LIKE operation, then the expression following the ESCAPE caluse of sqlite.
/// For example,

/// column LIKE ('#') ESCAPE('#') - "#" is escape character, it will be ignored.
/// Similarly, call respective get function to get filter properties e.g.call media_filter_get_condition() function to get condition of the media filter and call media_filter_get_order() function to get order(media_content_order_e) of the filtered items and so on.
/// </remarks>


using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Tizen;

namespace Tizen.Content.MediaContent
{
    public class ContentFilter : IDisposable
    {
        private IntPtr _filterHandle;
        private bool _disposedValue = false;
        private ContentOrder _order = ContentOrder.Asc;
        private string _orderKey = "MEDIA_ID";
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
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.GetOffset(_filterHandle, out offset, out count);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to Get offset");
                }
                return offset;
            }
            set
            {
                //TOD: check if we can convert this as method to club offset and count.
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.SetOffset(_filterHandle, value, this.Count);
                if (res != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(res, "Failed to Setoffset");
                }
            }
        }
        public ContentFilter()
        {
            MediaContentError res;
            res = (MediaContentError)Interop.Filter.Create(out _filterHandle);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to Create Filter handle.");
            }
            //res = (MediaContentError)Interop.Filter.SetOrder(_filterHandle,(int) _order, _orderKey, (int) _collationType);
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
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.GetOffset(_filterHandle, out offset, out count);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to Getoffset/count");
                }
                return count;
            }
            set
            {
                //TOD: check if we can convert this as method to club offset and count.
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.SetOffset(_filterHandle, this.Offset, value);
                if (res != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(res, "Failed to Setoffset/Count");
                }
            }
        }
        /// <summary>
        /// Sets the media filter content order and order keyword.
        /// </summary>
        public ContentOrder Order
        {
            get
            {
                //check If we can create multiple variables in a property itself..
                //Guess.. This might be need to change as method.
                int orderType;
                string orderKey;
                int collatetType;
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.GetOrder(_filterHandle, out orderType, out orderKey, out collatetType);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to GetOrder");
                }
                if ( orderKey.Length == 0)
                {
                    orderKey = _orderKey;
                }
                return (ContentOrder)orderType;
            }
            set
            {
                //TOD: check if we can convert this as method to club offset and count.
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.SetOrder(_filterHandle, (int)value, this.OrderKey, (int)this.CollationType);
                if (res != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(res, "Failed to SetOrder");
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
                //check If we can create multiple variables in a property itself..
                //Guess.. This might be need to change as method.
                int orderType;
                string orderKey;
                int collatetType;
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.GetOrder(_filterHandle, out orderType, out orderKey, out collatetType);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to GetOrder");
                }
                 return (ContentCollation)collatetType;
            }
            set
            {
                _collationType = value;
                //TOD: check if we can convert this as method to club offset and count.
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.SetOrder(_filterHandle, (int)this.Order, this.OrderKey, (int)value);
                if (res != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(res, "Failed to SetOrder");
                }
            }
        }
        /// <summary>
        /// Sets the condition for the given filter.
        /// </summary>
        public string Condition
        {
            get
            {
                //check If we can create multiple variables in a property itself..
                //Guess.. This might be need to change as method.
                string conditionVal;
                MediaContentError res;
                int collatetType;
                res = (MediaContentError)Interop.Filter.GetCondition(_filterHandle, out conditionVal, out collatetType);
                _collationType = (ContentCollation)collatetType;
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to GetCondition");
                }
                return conditionVal;
            }
            set
            {
                //TOD: check if we can convert this as method to club offset and count.
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.SetCondition(_filterHandle, value, (int) _collationType);
                if (res != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(res, "Failed to SetCondition");
                }
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
                //check If we can create multiple variables in a property itself..
                //Guess.. This might be need to change as method.
                string storageId;
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.GetStorage(_filterHandle, out storageId);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to GetCondition");
                }
                return storageId;
            }
            set
            {
                //TOD: check if we can convert this as method to club offset and count.
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.SetStorage(_filterHandle, value);
                if (res != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(res, "Failed to SetCondition");
                }
            }
        }
        /// <summary>
        /// The search order keyword
        /// </summary>
        public string OrderKey
        {
            get
            {
                //check If we can create multiple variables in a property itself..
                //Guess.. This might be need to change as method.
                int orderType;
                string orderKey;
                int collatetType;
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.GetOrder(_filterHandle, out orderType, out orderKey, out collatetType);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to GetOrder");
                }
                if (orderKey.Length == 0)
                {
                    orderKey = _orderKey;
                }
                return orderKey;
            }
            set
            {
                _orderKey = value;
                //TOD: check if we can convert this as method to club offset and count.
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.SetOrder(_filterHandle, (int)this.Order, value, (int)this.CollationType);
                if (res != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(res, "Failed to SetOrder");
                }
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
