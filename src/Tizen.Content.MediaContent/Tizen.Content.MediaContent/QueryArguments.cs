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
using System.Diagnostics;
using FilterHandle = Interop.FilterHandle;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// The Base class for query arguments.
    /// </summary>
    /// <remarks>
    /// A filter is required for filtering information associated with Album, Folder, Tag, Bookmark, Playlist,
    /// and MediaInfo on the basis of details like limit, order, and condition.
    /// </remarks>
    /// <since_tizen> 4 </since_tizen>
    public class QueryArguments
    {
        private string _filter;

        /// <summary>
        /// Gets or sets the filtering expression that is applied.
        /// </summary>
        /// <value>A string that represents a filtering expression applied when data is retrieved.</value>
        /// <remarks>
        /// Expressions for the filter can be one of the following forms:<br/>
        /// - column = value
        /// - column > value
        /// - column >= value
        /// - <![CDATA[column < value]]>
        /// - <![CDATA[column <= value]]>
        /// - value = column
        /// - value >= column
        /// - <![CDATA[value < column]]>
        /// - <![CDATA[value <= column]]>
        /// - column IN (value)
        /// - column IN(value-list)
        /// - column NOT IN(value)
        /// - column NOT IN(value-list)
        /// - column LIKE value
        /// - expression COLLATE NOCASE
        /// - expression COLLATE RTRIM
        /// - expression COLLATE LOCALIZED
        /// - expression1 AND expression2 OR expression3 ...
        /// <br/>
        /// Note that if you want to set quotation (" ' " or " " ") as value of LIKE operator, you should use two times. (" '' " or " "" ").
        /// And the optional ESCAPE clause is supported. Both percent symbol("%") and underscore symbol("_") are used in the LIKE pattern.
        /// If these characters are used as values of the LIKE operation, then the expression following the ESCAPE clause of sqlite will be ignored.<br/>
        /// <br/>
        /// For example, column LIKE ('#%') ESCAPE ('#') - "#" is an escape character, it will be ignored.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="value"/> is a zero-length string, contains only white space.</exception>
        /// <seealso cref="MediaInfoColumns"/>
        /// <seealso cref="AlbumColumns"/>
        /// <seealso cref="FolderColumns"/>
        /// <seealso cref="PlaylistColumns"/>
        /// <seealso cref="TagColumns"/>
        /// <seealso cref="BookmarkColumns"/>
        /// <seealso cref="FaceInfoColumns"/>
        /// <since_tizen> 4 </since_tizen>
        public string FilterExpression
        {
            get => _filter;
            set
            {
                if (value != null)
                {
                    ValidationUtil.ValidateNotNullOrEmpty(value, nameof(value));
                }

                _filter = value;
            }
        }

        private string _storageId;

        /// <summary>
        /// Gets or sets the storage ID for the given filter.
        /// You can use this property when you want to search items only in the specific storage.
        /// </summary>
        /// <value>The storage ID to restrict storage to search, or null for all storages.</value>
        /// <exception cref="ArgumentException"><paramref name="value"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public string StorageId
        {
            get => _storageId;
            set
            {
                if (value != null)
                {
                    ValidationUtil.ValidateNotNullOrEmpty(value, nameof(value));
                }

                _storageId = value;
            }
        }

        internal static FilterHandle ToNativeHandle(QueryArguments arguments)
        {
            if (arguments == null || arguments.IsEmpty())
            {
                return FilterHandle.Null;
            }

            Interop.Filter.Create(out var handle).ThrowIfError("Failed to apply arguments.");

            try
            {
                arguments.FillHandle(handle);
            }
            catch (Exception)
            {
                handle.Dispose();
                throw;
            }

            return handle;
        }

        internal static FilterHandle CreateNativeHandle(string filterExpression)
        {
            Debug.Assert(filterExpression != null);

            Interop.Filter.Create(out var handle).ThrowIfError("Failed to apply arguments.");

            Interop.Filter.SetCondition(handle, filterExpression, Collation.Default).
                ThrowIfError("Failed to create filter handle.");

            return handle;
        }

#pragma warning disable CS0618 // Type or member is obsolete
        internal virtual bool IsEmpty()
        {
            return StorageId == null && FilterExpression == null;
        }

        internal virtual void FillHandle(FilterHandle handle)
        {
            if (FilterExpression != null)
            {
                Interop.Filter.SetCondition(handle, FilterExpression, Collation.Default).
                    ThrowIfError("Failed to create filter handle(condition)");
            }

            if (StorageId != null)
            {
                Interop.Filter.SetStorage(handle, StorageId).
                    ThrowIfError("Failed to create filter handle(storage id)"); ;
            }
        }
#pragma warning restore CS0618 // Type or member is obsolete

    }

    /// <summary>
    /// Provides the ability to filter the result of a Select command.
    /// </summary>
    /// <remarks>
    /// A filter is required for filtering information associated with Album, Folder, Tag, Bookmark, Playlist,
    /// and MediaInfo.
    /// </remarks>
    /// <since_tizen> 4 </since_tizen>
    public class SelectArguments : QueryArguments
    {
        private int _startRowIndex;

        /// <summary>
        /// Gets or sets the starting row position of a query (starting from zero).
        /// </summary>
        /// <value>An integer value that indicates the starting row position of a query.</value>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.<br/></exception>
        /// <since_tizen> 4 </since_tizen>
        public int StartRowIndex
        {
            get => _startRowIndex;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "StartRowIndex can't be less than zero.");
                }

                _startRowIndex = value;
            }
        }

        private int _totalRowCount;

        /// <summary>
        /// Gets or sets the number of rows to be retrieved.
        /// </summary>
        /// <value>An integer value that indicates the limit of rows of the result.</value>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int TotalRowCount
        {
            get => _totalRowCount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "TotalRowCount can't be less than zero.");
                }

                _totalRowCount = value;
            }
        }

        private string _sortOrder;

        /// <summary>
        /// Gets or sets the sort order of the results.
        /// </summary>
        /// <value>The expression for the sort order.</value>
        /// <remarks>
        /// Expressions for the sort order can be:<br/>
        /// column [COLLATE NOCASE/RTRIM/LOCALIZED] [ASC/DESC], column2 ...
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="value"/> is a zero-length string, contains only white space.</exception>
        /// <seealso cref="MediaInfoColumns"/>
        /// <seealso cref="AlbumColumns"/>
        /// <seealso cref="FolderColumns"/>
        /// <seealso cref="PlaylistColumns"/>
        /// <seealso cref="TagColumns"/>
        /// <seealso cref="BookmarkColumns"/>
        /// <seealso cref="FaceInfoColumns"/>
        /// <since_tizen> 4 </since_tizen>
        public string SortOrder
        {
            get => _sortOrder;
            set
            {
                if (value != null)
                {
                    ValidationUtil.ValidateNotNullOrEmpty(value, nameof(value));
                }

                _sortOrder = value;
            }
        }

        internal override bool IsEmpty()
        {
            return base.IsEmpty() && StartRowIndex == 0 && TotalRowCount == 0 && SortOrder == null;
        }

        internal override void FillHandle(FilterHandle handle)
        {
            base.FillHandle(handle);

            if (StartRowIndex != 0 || TotalRowCount != 0)
            {
                Interop.Filter.SetOffset(handle, StartRowIndex, TotalRowCount).
                    ThrowIfError("Failed to create filter handle(limit)");
            }

            if (SortOrder != null)
            {
                Interop.Filter.SetOrder(handle, SortOrder).ThrowIfError("Failed to create filter handle(order)");
            }
        }
    }

    /// <summary>
    /// Provides the ability to filter the result of the Count command.
    /// </summary>
    /// <remarks>
    /// A filter is required for filtering information associated with Album, Folder, Tag, Bookmark, Playlist,
    /// and MediaInfo.
    /// </remarks>
    /// <since_tizen> 4 </since_tizen>
    public class CountArguments : QueryArguments
    {
    }
}
