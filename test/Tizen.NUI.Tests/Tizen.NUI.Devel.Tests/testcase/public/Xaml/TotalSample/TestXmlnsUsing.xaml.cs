using System;
using System.Collections.Generic;
using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

[assembly: XamlResourceId("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.TestXmlnsUsing.xaml",
    "testcase.public.Xaml.TotalSample.TestXmlnsUsing.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.TestXmlnsUsing))]

namespace Tizen.NUI.Devel.Tests
{
    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\TestXmlnsUsing.xaml")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class TestXmlnsUsing : View
	{
        public CustomXamlView view0;

        public TestXmlnsUsing()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(TestXmlnsUsing));

            view0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<CustomXamlView>(this, "view0");
        }

		[TestFixture]
		class Tests
		{
			[SetUp]
			public void Setup()
			{
			}

			[TearDown]
			public void TearDown()
			{
				Application.Current = null;
			}

			[Test]
			public void SupportUsingXmlns()
			{
				var page = new TestXmlnsUsing();
				Assert.That(page.view0, Is.Not.Null);
				Assert.That(page.view0, Is.TypeOf<CustomXamlView>());
			}
		}
	}
}
