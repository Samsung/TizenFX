using System.ComponentModel;
using System.Threading.Tasks;
using Tizen.NUI;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// For internal use.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class NavigationRequestedEventArgs : NavigationEventArgs
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="animated"></param>
        /// <param name="realize"></param>
        public NavigationRequestedEventArgs(Page page, bool animated, bool realize = true) : base(page)
        {
            Animated = animated;
            Realize = realize;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="before"></param>
        /// <param name="animated"></param>
        public NavigationRequestedEventArgs(Page page, Page before, bool animated) : this(page, animated)
        {
            BeforePage = before;
        }

        /// <summary>
        /// Gets or Sets the whether animate.
        /// </summary>
        public bool Animated { get; set; }

        /// <summary>
        /// Gets or Sets the before page.
        /// </summary>
        public Page BeforePage { get; set; }

        /// <summary>
        /// Gets or Sets the realize.
        /// </summary>
        public bool Realize { get; set; }

        /// <summary>
        /// Gets or Sets the Task.
        /// </summary>
        public Task<bool> Task { get; set; }
    }
}