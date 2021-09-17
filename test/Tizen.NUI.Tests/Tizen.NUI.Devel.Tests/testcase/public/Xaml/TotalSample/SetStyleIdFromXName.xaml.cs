using System;
using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

[assembly: XamlResourceId("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.SetStyleIdFromXName.xaml",
    "testcase.public.Xaml.TotalSample.SetStyleIdFromXName.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.SetStyleIdFromXName))]

namespace Tizen.NUI.Devel.Tests
{
    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\SetStyleIdFromXName.xaml")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class SetStyleIdFromXName : View
	{
        public TextLabel label0;
        public TextLabel label1;
        public TextLabel label2;

        public SetStyleIdFromXName()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(SetStyleIdFromXName));

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
			public void SetStyleId()
			{
				var layout = new SetStyleIdFromXName();
				Assert.That(layout.label0.StyleId, Is.EqualTo("label0"));
				Assert.That(layout.label1.StyleId, Is.EqualTo("foo"));
				Assert.That(layout.label2.StyleId, Is.EqualTo("bar"));
			}
		}
	}
}
