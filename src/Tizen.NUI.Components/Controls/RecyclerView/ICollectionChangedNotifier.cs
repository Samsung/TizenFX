/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Notify observers about dataset changes of observable items.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICollectionChangedNotifier
    {

        /// <summary>
        /// Notify the dataset is Changed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void NotifyDataSetChanged();

        /// <summary>
        /// Notify the observable item in startIndex is changed.
        /// </summary>
        /// <param name="source">dataset source</param>
        /// <param name="startIndex">changed item index</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void NotifyItemChanged(IItemSource source, int startIndex);

        /// <summary>
        /// Notify the observable item is inserted in dataset.
        /// </summary>
        /// <param name="source">dataset source</param>
        /// <param name="startIndex">Inserted item index</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void NotifyItemInserted(IItemSource source, int startIndex);

        /// <summary>
        /// Notify the observable item is moved from fromPosition to ToPosition.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fromPosition"></param>
        /// <param name="toPosition"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void NotifyItemMoved(IItemSource source, int fromPosition, int toPosition);

        /// <summary>
        /// Notify the range of the observable items are moved from fromPosition to ToPosition.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fromPosition"></param>
        /// <param name="toPosition"></param>
        /// <param name="count"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void NotifyItemRangeMoved(IItemSource source, int fromPosition, int toPosition, int count);

        /// <summary>
        /// Notify the range of observable items from start to end are changed.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void NotifyItemRangeChanged(IItemSource source, int startIndex, int endIndex);

        /// <summary>
        /// Notify the count range of observable items are inserted in startIndex.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void NotifyItemRangeInserted(IItemSource source, int startIndex, int count);

        /// <summary>
        /// Notify the count range of observable items from the startIndex are removed.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void NotifyItemRangeRemoved(IItemSource source, int startIndex, int count);

        /// <summary>
        /// Notify the observable item in startIndex is removed.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="startIndex"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void NotifyItemRemoved(IItemSource source, int startIndex);
    }
}