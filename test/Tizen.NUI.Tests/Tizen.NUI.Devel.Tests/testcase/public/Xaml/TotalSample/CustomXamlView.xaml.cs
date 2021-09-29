using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

[assembly: XamlResourceId("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.CustomXamlView.xaml",
    "testcase.public.Xaml.TotalSample.CustomXamlView.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.CustomXamlView))]

namespace Tizen.NUI.Devel.Tests
{
    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\CustomXamlView.xaml")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class CustomXamlView : View
	{	
		public CustomXamlView ()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(CustomXamlView));

        }
	}
}
