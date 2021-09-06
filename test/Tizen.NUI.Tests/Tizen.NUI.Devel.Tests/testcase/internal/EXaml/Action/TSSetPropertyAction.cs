using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/SetPropertyAction")]
    public class InternalEXamlSetPropertyActionTest
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
        [Description("SetPropertyAction constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.SetPropertyAction.SetPropertyAction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlSetPropertyActionConstructor()
        {
            tlog.Debug(tag, $"EXamlSetPropertyActionConstructor START");

            var testingTarget = new Tizen.NUI.EXaml.SetPropertyAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
            Assert.IsNotNull(testingTarget, "Can't create success object SetPropertyAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.SetPropertyAction>(testingTarget, "Should be an instance of SetPropertyAction type.");

            tlog.Debug(tag, $"EXamlSetPropertyActionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SetPropertyAction Init.")]
        [Property("SPEC", "Tizen.NUI.EXaml.SetPropertyAction.Init M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlSetPropertyActionInit()
        {
            tlog.Debug(tag, $"EXamlSetPropertyActionInit START");

            var testingTarget = new Tizen.NUI.EXaml.SetPropertyAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
            Assert.IsNotNull(testingTarget, "Can't create success object SetPropertyAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.SetPropertyAction>(testingTarget, "Should be an instance of SetPropertyAction type.");

            try
            {
                testingTarget.Init();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlSetPropertyActionInit END (OK)");
        }
    }
}
