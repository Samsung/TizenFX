using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// EventArgs for the NavigationPage's navigation events.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NavigationEventArgs : EventArgs
	{
        /// <summary>
        /// Create a NavigationEventArgs instance.
        /// </summary>
        /// <param name="page">The page that was popped or is newly visible.</param>
		public NavigationEventArgs(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			Page = page;
		}

        /// <summary>
        /// Gets the page that was removed or is newly visible.
        /// </summary>
		public Page Page { get; private set; }
	}
}