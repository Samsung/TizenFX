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
        /// Notify the range of observable items from start to end are changed.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void NotifyItemRangeChanged(IItemSource source, int start, int end);

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