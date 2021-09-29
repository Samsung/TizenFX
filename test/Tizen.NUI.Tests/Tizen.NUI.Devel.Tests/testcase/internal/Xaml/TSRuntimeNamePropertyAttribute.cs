using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/RuntimeNamePropertyAttribute")]
    public class InternalRuntimeNamePropertyAttributeTest
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
        [Description("RuntimeNamePropertyAttribute RuntimeNamePropertyAttribute")]
        [Property("SPEC", "Tizen.NUI.Xaml.RuntimeNamePropertyAttribute.RuntimeNamePropertyAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void RuntimeNamePropertyAttributeConstructor()
        {
            tlog.Debug(tag, $"RuntimeNamePropertyAttributeConstructor START");

            try
            {
                var rnp = new RuntimeNamePropertyAttribute("Content");
                Assert.IsNotNull(rnp, "Should not be null");
                Assert.AreEqual("Content", rnp.Name, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"RuntimeNamePropertyAttributeConstructor END");
        }

    }
}