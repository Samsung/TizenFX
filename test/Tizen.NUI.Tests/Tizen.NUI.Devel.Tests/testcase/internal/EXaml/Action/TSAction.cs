using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/Action")]
    public class InternalEXamlActionTest
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
        [Description("Action Instance.")]
        [Property("SPEC", "Tizen.NUI.EXaml.Action.Instance C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlActionInstance()
        {
            tlog.Debug(tag, $"EXamlActionInstance START");

            var testingTarget = new Tizen.NUI.EXaml.Instance(1);
            Assert.IsNotNull(testingTarget, "Can't create success object Instance");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.Instance>(testingTarget, "Should be an instance of Instance type.");

            var result = testingTarget.Index;
            Assert.AreEqual(1, result, "Should be equal!");

            tlog.Debug(tag, $"EXamlActionInstance END (OK)");
        }
    }
}
