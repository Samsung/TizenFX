using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/SetBindingAction")]
    public class InternalEXamlSetBindingActionTest
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
        [Description("SetBindingAction constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.SetBindingAction.SetBindingAction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlSetBindingActionConstructor()
        {
            tlog.Debug(tag, $"EXamlSetBindingActionConstructor START");

            var testingTarget = new Tizen.NUI.EXaml.SetBindingAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
            Assert.IsNotNull(testingTarget, "Can't create success object SetBindingAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.SetBindingAction>(testingTarget, "Should be an instance of SetBindingAction type.");

            tlog.Debug(tag, $"EXamlSetBindingActionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SetBindingAction Init.")]
        [Property("SPEC", "Tizen.NUI.EXaml.SetBindingAction.Init M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlSetBindingActionInit()
        {
            tlog.Debug(tag, $"EXamlSetBindingActionInit START");

            var testingTarget = new Tizen.NUI.EXaml.SetBindingAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
            Assert.IsNotNull(testingTarget, "Can't create success object SetBindingAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.SetBindingAction>(testingTarget, "Should be an instance of SetBindingAction type.");

            try
            {
                testingTarget.Init();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlSetBindingActionInit END (OK)");
        }
    }
}
