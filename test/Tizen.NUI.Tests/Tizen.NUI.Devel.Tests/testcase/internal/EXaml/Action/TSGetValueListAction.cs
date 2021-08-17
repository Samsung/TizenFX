using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/GetValueListAction")]
    public class InternalGetValueListActionTest
    {
        private const string tag = "NUITEST";

        internal class MyAction : Tizen.NUI.EXaml.Action
        {
            public void Init() { }

            public void OnActive() { }

            EXaml.Action EXaml.Action.DealChar(char c)
            {
                return this;
            }
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
        [Description("GetValueListAction constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GetValueListAction.GetValueListAction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGetValueListActionConstructor()
        {
            tlog.Debug(tag, $"EXamlGetValueListActionConstructor START");

            var testingTarget = new Tizen.NUI.EXaml.GetValueListAction(')', new MyAction());
            Assert.IsNotNull(testingTarget, "Can't create success object GetValueListAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.GetValueListAction>(testingTarget, "Should be an instance of GetValueListAction type.");

            tlog.Debug(tag, $"EXamlGetValueListActionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GetValueListAction Init.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GetValueListAction.Init M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGetValueListActionInit()
        {
            tlog.Debug(tag, $"EXamlGetValueListActionInit START");

            var testingTarget = new Tizen.NUI.EXaml.GetValueListAction(')', new MyAction());
            Assert.IsNotNull(testingTarget, "Can't create success object GetValueListAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.GetValueListAction>(testingTarget, "Should be an instance of GetValueListAction type.");

            try
            {
                testingTarget.Init();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlGetValueListActionInit END (OK)");
        }
    }
}
