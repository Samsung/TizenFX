using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    public partial class CustomXamlView : View
	{	
		public CustomXamlView ()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(CustomXamlView));

        }
	}
}
