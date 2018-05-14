using System.ComponentModel;

namespace Tizen.NUI.Binding
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IPlatform
	{
		SizeRequest GetNativeSize(BaseHandle view, double widthConstraint, double heightConstraint);
	}
}
