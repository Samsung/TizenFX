using System;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Base interface for encapsulated data source in ItemsView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IItemSource : IDisposable
    {
        /// <summary>
        /// Count of data source.
        /// </summary>
       [EditorBrowsable(EditorBrowsableState.Never)]
        int Count { get; }

        /// <summary>
        /// Position integer value of data object.
        /// </summary>
       [EditorBrowsable(EditorBrowsableState.Never)]
        int GetPosition(object item);

        /// <summary>
        /// Item object in position.
        /// </summary>
       [EditorBrowsable(EditorBrowsableState.Never)]
        object GetItem(int position);

        /// <summary>
        /// Flag of header existence.
        /// </summary>
       [EditorBrowsable(EditorBrowsableState.Never)]
        bool HasHeader { get; set; }

        /// <summary>
        /// Flag of Footer existence.
        /// </summary>
       [EditorBrowsable(EditorBrowsableState.Never)]
        bool HasFooter { get; set; }

        /// <summary>
        /// Boolean checker for position is header or not.
        /// 0 index will be header if header exist.
        /// warning: if header exist, all item index will be increased.
        /// </summary>
        /// <param name="position">The position for checking header.</param>
       [EditorBrowsable(EditorBrowsableState.Never)]
        bool IsHeader(int position);

        /// <summary>
        /// Boolean checker for position is footer or not.
        /// last index will be footer if footer exist.
        /// warning: footer will be place original data count or data count + 1.
        /// </summary>
        /// <param name="position">The position for checking footer.</param>
       [EditorBrowsable(EditorBrowsableState.Never)]
        bool IsFooter(int position);
    }

    /// <summary>
    /// Base interface for encapsulated data source with group structure in CollectionView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGroupableItemSource : IItemSource
    {
        /// <summary>
        /// Boolean checker for position is group header or not
        /// </summary>
        /// <param name="position">The position for checking group header.</param>
       [EditorBrowsable(EditorBrowsableState.Never)]
        bool IsGroupHeader(int position);

        /// <summary>
        /// Boolean checker for position is group footer or not
        /// </summary>
        /// <param name="position">The position for checking group footer.</param>
       [EditorBrowsable(EditorBrowsableState.Never)]
        bool IsGroupFooter(int position);

        /// <summary>
        /// Boolean checker for position is group footer or not
        /// </summary>
        /// <param name="position">The position for checking group footer.</param>
       [EditorBrowsable(EditorBrowsableState.Never)]
        object GetGroupParent(int position);

    }
}
