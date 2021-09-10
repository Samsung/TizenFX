using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Events;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/CustomView/CustomViewRegistry")]
    public class PublicCustomViewRegistryTest
    {
        private const string tag = "NUITEST";
        static CustomView CreateInstance()
        {
            return new Spin();
        }

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
        [Description("ScriptableProperty Type")]
        [Property("SPEC", "Tizen.NUI.ScriptableProperty.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScriptablePropertyType()
        {
            tlog.Debug(tag, $"ScriptablePropertyType START");

            var testingTarget = new ScriptableProperty();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ScriptableProperty>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Type;
            tlog.Debug(tag, "Type : " + result);

            tlog.Debug(tag, $"ScriptablePropertyType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomViewRegistry Register")]
        [Property("SPEC", "Tizen.NUI.CustomViewRegistry.Register M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomViewRegistryRegister()
        {
            tlog.Debug(tag, $"CustomViewRegistryRegister START");

            try
            {
                CustomViewRegistry.Instance.Register(CreateInstance, typeof(Spin));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"CustomViewRegistryRegister END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("CustomViewRegistry Register")]
        [Property("SPEC", "Tizen.NUI.CustomViewRegistry.Register M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomViewRegistryRegisterNullViewType()
        {
            tlog.Debug(tag, $"CustomViewRegistryRegisterNullViewType START");

            try
            {
                CustomViewRegistry.Instance.Register(CreateInstance, null);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"CustomViewRegistryRegisterNullViewType END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }
    }
}
