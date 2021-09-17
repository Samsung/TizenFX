using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

[assembly: global::Tizen.NUI.Xaml.XamlResourceIdAttribute("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.DuplicatePropertyElements.xaml",
    "testcase.public.Xaml.TotalSample.DuplicatePropertyElements.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.DuplicatePropertyElements))]

namespace Tizen.NUI.Devel.Tests
{
    [Tizen.NUI.Xaml.XamlFilePathAttribute("testcase\\public\\Xaml\\TotalSample\\DuplicatePropertyElements.xaml")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class DuplicatePropertyElements : BindableObject
	{
		public DuplicatePropertyElements()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(DuplicatePropertyElements));
        }

		[TestFixture]
		public static class Tests
		{
			[Test]
			public static void ThrowXamlParseException()
			{
				Assert.Throws<ArgumentException>(() => new DuplicatePropertyElements());
			}
		}
	}
}
