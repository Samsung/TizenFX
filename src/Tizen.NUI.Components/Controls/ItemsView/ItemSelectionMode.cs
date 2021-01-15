using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Selection mode of CollecitonView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ItemSelectionMode
    {
        /// <summary>
        /// None of item can be selected.
        /// </summary>
       [EditorBrowsable(EditorBrowsableState.Never)]
        None,
        /// <summary>
        /// Single selection. select item exculsively so previous selected item will be unselected.
        /// </summary>
       [EditorBrowsable(EditorBrowsableState.Never)]
        SingleSelection,
        /// <summary>
        /// Multiple selections. select multiple items and previous selected item still remains selected.
        /// </summary>
       [EditorBrowsable(EditorBrowsableState.Never)]
        MultipleSelections
    }
}
