using System;

using NUnit.Framework;
using Tizen.NUI.BaseComponents;

[assembly: global::Tizen.NUI.Xaml.XamlResourceIdAttribute("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.BuiltInConversions.xaml",
    "testcase.public.Xaml.TotalSample.BuiltInConversions.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.BuiltInConversions))]

namespace Tizen.NUI.Devel.Tests
{
    [Tizen.NUI.Xaml.XamlFilePathAttribute("testcase\\public\\Xaml\\TotalSample\\BuiltInConversions.xaml")]
    [Tizen.NUI.Xaml.XamlCompilationAttribute(global::Tizen.NUI.Xaml.XamlCompilationOptions.Compile)]
    public partial class BuiltInConversions : View
	{
        public TextLabel label0;
        public TextLabel label1;
        public TextLabel label2;

        public BuiltInConversions ()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(BuiltInConversions));

            label0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label0");
            label1 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label1");
            label2 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label2");
        }

		[TestFixture]
		public class Tests
		{
			[SetUp]
			public void Setup()
			{
			}

			[TearDown]
			public void TearDown()
			{
			}

			[Test]
			public void String ()
			{
				var layout = new BuiltInConversions ();

				Assert.AreEqual ("foobar", layout.label0.Text);
				Assert.AreEqual ("foobar", layout.label1.Text);

				//Issue #2122, implicit content property not trimmed
				Assert.AreEqual (string.Empty, layout.label2.Text);
			}
		}
	}
}