using System.Diagnostics;
using Tizen.NUI;

namespace Tizen.NUI.XamlBinding
{
    /// <summary>
    /// Struct that defines minimum and maximum Sizes.
    /// </summary>
    [DebuggerDisplay("Request={Request.Width}x{Request.Height}, Minimum={Minimum.Width}x{Minimum.Height}")]
    internal struct SizeRequest
    {
        /// <summary>
        /// The requested size.
        /// </summary>
        public Size Request { get; set; }

        /// <summary>
        /// The minimum acceptable size.
        /// </summary>
        public Size Minimum { get; set; }

        /// <summary>
        /// Creates a new SizeRequest object that requests at least the size minimum, but preferably the size request.
        /// </summary>
        /// <param name="request">The size of the request.</param>
        /// <param name="minimum">The minimum size for the request.</param>
        public SizeRequest(Size request, Size minimum)
        {
            Request = request;
            Minimum = minimum;
        }

        /// <summary>
        /// Creates a new SizeRequest with the specified request size.
        /// </summary>
        /// <param name="request">The size of the request.</param>
        public SizeRequest(Size request)
        {
            Request = request;
            Minimum = request;
        }

        /// <summary>
        /// Returns a string representation of the size request.
        /// </summary>
        /// <returns>a string representation of the size request.</returns>
        public override string ToString()
        {
            return string.Format("{{Request={0} Minimum={1}}}", Request, Minimum);
        }
    }
}
