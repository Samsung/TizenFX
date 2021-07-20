using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/ProvideCompiledAttribute")]
    internal class PublicProvideCompiledAttributeTest
    {
        private const string tag = "NUITEST";
        private static ProvideCompiledAttribute p1;

        [SetUp]
        public void Init()
        {
            p1 = new ProvideCompiledAttribute("mytestAttribute");
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            p1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("ProvideCompiledAttribute ProvideCompiledAttribute")]
        [Property("SPEC", "Tizen.NUI.ProvideCompiledAttribute.ProvideCompiledAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ProvideCompiledAttributeConstructor()
        {
            tlog.Debug(tag, $"ProvideCompiledAttributeConstructor START");
            ProvideCompiledAttribute p2 = new ProvideCompiledAttribute("testAttribute");

            p2 = null;
            tlog.Debug(tag, $"ProvideCompiledAttributeConstructor END (OK)");
            Assert.Pass("ProvideCompiledAttributeConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("ProvideCompiledAttribute CompiledVersion")]
        [Property("SPEC", "Tizen.NUI.ProvideCompiledAttribute.CompiledVersion A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ProvideCompiledAttributeCompiledVersion()
        {
            tlog.Debug(tag, $"ProvideCompiledAttributeCompiledVersion START");
            try
            {
                string attribute = p1.CompiledVersion;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ProvideCompiledAttributeCompiledVersion END (OK)");
            Assert.Pass("ProvideCompiledAttributeCompiledVersion");
        }
    }
}