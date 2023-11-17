using NUnit.Framework;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    public partial class XReference : View
    {
        public XReference()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(XReference));
#pragma warning restore Reflection // The code contains reflection

            label0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label0");
            label1 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label1");
            entry = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextField>(this, "entry");
        }
    }

    [TestFixture]
    public class XReferenceTests
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
        public void XReferenceAsBindingSource()
        {
            var layout = new XReference();

            Assert.AreEqual("foo", layout.entry.Text);
            Assert.AreEqual("bar", layout.entry.PlaceholderText);
            //Assert.AreSame(layout.label0, layout.label1.BindingContext);
            //Assert.AreSame(layout.label1, layout.label0.BindingContext);
        }
    }
}