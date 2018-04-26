using System;

namespace Tizen.NUI.Binding
{
	public sealed class BindablePropertyKey
	{
		internal BindablePropertyKey(BindableProperty property)
		{
			if (property == null)
				throw new ArgumentNullException("property");

			BindableProperty = property;
		}

		public BindableProperty BindableProperty { get; private set; }
	}
}