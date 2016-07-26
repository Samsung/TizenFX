/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

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
        /// Gets the media filter content order and order keyword.
        /// </summary>
        public ContentOrder Order
        {
            get
            {
                int orderType;
                string orderKey;
                int collatetType;
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.GetOrder(_filterHandle, out orderType, out orderKey, out collatetType);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to GetOrder");
                }
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
                //check If we can create multiple variables in a property itself..
                //Guess.. This might be need to change as method.
                string condition;
                int collatetType;
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.GetCondition(_filterHandle, out condition, out collatetType);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to GetCondition for CollationType");
                }
                return (ContentCollation)collatetType;
            }
            set
            {
                _collationType = value;
                //TOD: check if we can convert this as method to club offset and count.
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.SetCondition(_filterHandle, this.Condition, (int)value);
                if (res != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(res, "Failed to SetCondition for CollationType");
                }
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
                res = (MediaContentError)Interop.Filter.SetCondition(_filterHandle, value, (int)_collationType);
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
                int orderType;
                string orderKey;
                int collatetType;
                MediaContentError res;
                res = (MediaContentError)Interop.Filter.GetOrder(_filterHandle, out orderType, out orderKey, out collatetType);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to GetOrder for OrderKey");
                }
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
            MediaContentError res = (MediaContentError)Interop.Filter.SetOrder(_filterHandle, order, oderKey, CollationType);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to SetOrder");
            }
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
