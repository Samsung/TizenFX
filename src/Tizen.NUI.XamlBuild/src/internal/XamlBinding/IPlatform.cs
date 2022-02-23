using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// For internal use.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IPlatform
    {
        /// <summary>
        /// Returns the native size.
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="widthConstraint">The width constraint.</param>
        /// <param name="heightConstraint">The height constraint.</param>
        /// <returns>The native size.</returns>
        //SizeRequest GetNativeSize(BaseHandle view, double widthConstraint, double heightConstraint);
    }
}
