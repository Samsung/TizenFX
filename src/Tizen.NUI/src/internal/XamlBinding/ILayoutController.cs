using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
	internal interface ILayoutController
	{
		IReadOnlyList<Element> Children { get; }
	}
}