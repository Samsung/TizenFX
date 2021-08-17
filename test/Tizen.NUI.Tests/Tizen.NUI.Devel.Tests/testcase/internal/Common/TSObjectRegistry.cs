using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ObjectRegistry")]
    public class InternalObjectRegistryTest
    {
        private const string tag = "NUITEST";
        private ObjectRegistry registry = null;

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
        [Description("ObjectRegistry constructor.")]
        [Property("SPEC", "Tizen.NUI.ObjectRegistry.ObjectRegistry C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectRegistryConstructor()
        {
            tlog.Debug(tag, $"ObjectRegistryConstructor START");

            var testingTarget = new ObjectRegistry();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ObjectRegistry>(testingTarget, "Should return ObjectRegistry instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ObjectRegistryConstructor END (OK)");
        }
    }
}
