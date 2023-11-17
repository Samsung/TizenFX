using NUnit.Framework;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;
    public partial class I8 : View
    {
        public long l0 { get; set; }
        public long l1 { get; set; }
        public long l2 { get; set; }
        public long l3 { get; set; }
        public long l4 { get; set; }
        public long l5 { get; set; }
        public ulong ul0 { get; set; }
        public ulong ul1 { get; set; }
        public ulong ul2 { get; set; }

        public I8()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(I8));
#pragma warning restore Reflection // The code contains reflection
        }
    }

    [TestFixture]
    public class I8Tests
    {
        private const string tag = "NUITEST";

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
        public void I8AreConverted()
        {
            I8 p = new I8();
            tlog.Debug(tag, "p.l0" + p.l0);
        }
    }
}