using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Size calculation strategy for CollectionView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ItemSizingStrategy
    {

        /// <summary>
        /// Measure all items in advanced.
        /// Estimate first item size for all, and when scroll reached position,
        /// measure strictly. Note : This will make scroll bar trembling.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MeasureAll,
        /// <summary>
        /// Measure first item and deligate size for all items.
        /// if template is selector, the size of first item from each template will be deligated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MeasureFirst,
    }
}
