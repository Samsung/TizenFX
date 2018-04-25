using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
	internal interface IViewContainer<T> where T : /*VisualElement*/BaseHandle
	{
		IList<T> Children { get; }
	}
}