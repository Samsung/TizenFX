using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/RegisterXNameAction")]
    public class InternalEXamlRegisterXNameActionTest
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
        [Description("RegisterXNameAction constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.RegisterXNameAction.RegisterXNameAction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlRegisterXNameActionConstructor()
        {
            tlog.Debug(tag, $"EXamlRegisterXNameActionConstructor START");

            var testingTarget = new Tizen.NUI.EXaml.RegisterXNameAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
            Assert.IsNotNull(testingTarget, "Can't create success object RegisterXNameAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.RegisterXNameAction>(testingTarget, "Should be an instance of RegisterXNameAction type.");

            tlog.Debug(tag, $"EXamlRegisterXNameActionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RegisterXNameAction Init.")]
        [Property("SPEC", "Tizen.NUI.EXaml.RegisterXNameAction.Init M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlRegisterXNameActionInit()
        {
            tlog.Debug(tag, $"EXamlRegisterXNameActionInit START");

            var testingTarget = new Tizen.NUI.EXaml.RegisterXNameAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
            Assert.IsNotNull(testingTarget, "Can't create success object RegisterXNameAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.RegisterXNameAction>(testingTarget, "Should be an instance of RegisterXNameAction type.");

            try
            {
                testingTarget.Init();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlRegisterXNameActionInit END (OK)");
        }
    }
}
