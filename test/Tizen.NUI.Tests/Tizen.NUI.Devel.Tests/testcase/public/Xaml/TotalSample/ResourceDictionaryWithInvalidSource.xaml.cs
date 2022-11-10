using System.IO;
using NUnit.Framework;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    public partial class ResourceDictionaryWithInvalidSource : View
    {
        public ResourceDictionaryWithInvalidSource()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(ResourceDictionaryWithInvalidSource));
#pragma warning restore Reflection // The code contains reflection
        }
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
        [Category("P1")]
        [Description("Extensions LoadFromXaml.")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void InvalidSourceThrows()
        {
            Assert.Throws<FileNotFoundException>(() => new ResourceDictionaryWithInvalidSource());
        }
    }
}