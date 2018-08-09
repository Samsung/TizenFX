using System.Diagnostics;

namespace Tizen.NUI.Binding
{
	[DebuggerDisplay("Request={Request.Width}x{Request.Height}, Minimum={Minimum.Width}x{Minimum.Height}")]
	public struct SizeRequest
	{
		public Size Request { get; set; }

		public Size Minimum { get; set; }

		public SizeRequest(Size request, Size minimum)
		{
			Request = request;
			Minimum = minimum;
		}

		public SizeRequest(Size request)
		{
			Request = request;
			Minimum = request;
		}

		public override string ToString()
		{
			return string.Format("{{Request={0} Minimum={1}}}", Request, Minimum);
		}
	}
}
