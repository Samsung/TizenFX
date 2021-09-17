using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

[assembly: global::Tizen.NUI.Xaml.XamlResourceIdAttribute("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.DuplicateXArgumentsElements.xaml",
    "testcase.public.Xaml.TotalSample.DuplicateXArgumentsElements.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.DuplicateXArgumentsElements))]

namespace Tizen.NUI.Devel.Tests
{
    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\DuplicateXArgumentsElements.xaml")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class DuplicateXArgumentsElements : BindableObject
	{
		public DuplicateXArgumentsElements()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(DuplicateXArgumentsElements));
        }

		[TestFixture]
		public static class Tests
		{
			[Test]
			public static void ThrowXamlParseException()
			{
				Assert.Throws<ArgumentException>(() => new DuplicateXArgumentsElements());
			}
		}
	}
}
