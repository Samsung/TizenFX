using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/ProvideCompiledAttribute")]
    public class PublicProvideCompiledAttributeTest
    {
        private const string tag = "NUITEST";

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
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

            var testingTarget = new ProvideCompiledAttribute("testAttribute");
            Assert.IsNotNull(testingTarget, "null ProvideCompiledAttribute");
            Assert.IsInstanceOf<ProvideCompiledAttribute>(testingTarget, "Should return ProvideCompiledAttribute instance.");
            
            testingTarget = null;
            tlog.Debug(tag, $"ProvideCompiledAttributeConstructor END");
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
                var testingTarget = new ProvideCompiledAttribute("testAttribute");
                Assert.IsNotNull(testingTarget, "null ProvideCompiledAttribute");
                Assert.IsInstanceOf<ProvideCompiledAttribute>(testingTarget, "Should return ProvideCompiledAttribute instance.");
                
                string result = testingTarget.CompiledVersion;
                tlog.Debug(tag, "CompiledVersion : " + result);

            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            tlog.Debug(tag, $"ProvideCompiledAttributeCompiledVersion END");
        }
    }
}