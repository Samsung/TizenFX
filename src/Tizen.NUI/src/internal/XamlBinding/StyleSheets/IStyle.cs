using System;
using Tizen.NUI.Binding;

namespace Tizen.NUI.StyleSheets
{
	interface IStyle
	{
		Type TargetType { get; }

		void Apply(BindableObject bindable);
		void UnApply(BindableObject bindable);
	}
}
