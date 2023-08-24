using NUnit.Framework;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    public partial class McIgnorable : View
    {
        public McIgnorable()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(McIgnorable));
#pragma warning restore Reflection // The code contains reflection
        }
    }

    [TestFixture]
    public class McIgnorableTests
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
        public void DoesNotThrow()
        {
            McIgnorable layout = new McIgnorable();
        }
    }
}