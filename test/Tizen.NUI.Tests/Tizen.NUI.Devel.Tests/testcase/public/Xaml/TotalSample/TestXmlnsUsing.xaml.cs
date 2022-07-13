using System;
using System.Collections.Generic;
using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    public partial class TestXmlnsUsing : View
	{
        public TestXmlnsUsing()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(TestXmlnsUsing));

            view0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<CustomXamlView>(this, "view0");
        }

	}


	[TestFixture]
	class TestXmlnsUsingTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TearDown]
		public void TearDown()
		{
			//Application.Current = null;
		}

		[Test]
		[Category("P1")]
		[Description("Extensions LoadFromXaml.")]
		[Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
		[Property("SPEC_URL", "-")]
		[Property("CRITERIA", "MR")]
		public void SupportUsingXmlns()
		{
			var page = new TestXmlnsUsing();
			Assert.That(page.view0, Is.Not.Null);
			Assert.That(page.view0, Is.TypeOf<CustomXamlView>());
		}
	}
}
