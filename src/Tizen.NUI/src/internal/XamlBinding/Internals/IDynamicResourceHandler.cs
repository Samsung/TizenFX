using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Internals
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal interface IDynamicResourceHandler
	{
		void SetDynamicResource(BindableProperty property, string key);
	}
}
