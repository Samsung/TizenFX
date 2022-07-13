using System;
using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    public partial class SetStyleIdFromXName : View
	{
        public SetStyleIdFromXName()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(SetStyleIdFromXName));

            label0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label0");
            label1 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label1");
            label2 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label2");
        }
	}

	[TestFixture]
	public class SetStyleIdFromXNameTests
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
		[Category("P1")]
		[Description("Extensions LoadFromXaml.")]
		[Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
		[Property("SPEC_URL", "-")]
		[Property("CRITERIA", "MR")]
		public void SetStyleId()
		{
			var layout = new SetStyleIdFromXName();
			Assert.That(layout.label0.StyleId, Is.EqualTo("label0"));
			Assert.That(layout.label1.StyleId, Is.EqualTo("foo"));
			Assert.That(layout.label2.StyleId, Is.EqualTo("bar"));
		}
	}
}
