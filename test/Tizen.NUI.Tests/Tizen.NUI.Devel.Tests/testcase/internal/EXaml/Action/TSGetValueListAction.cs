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
        
        [Test]
        [Category("P1")]
        [Description("GetValueListAction OnActive.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GetValueListAction.OnActive M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGetValueListActionOnActive()
        {
            tlog.Debug(tag, $"EXamlGetValueListActionOnActive START");
            
            var testingTarget = new Tizen.NUI.EXaml.GetValueListAction(')', new MyAction());
            Assert.IsNotNull(testingTarget, "Can't create success object GetValueListAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.GetValueListAction>(testingTarget, "Should be an instance of GetValueListAction type.");

            try
            {
                testingTarget.OnActive();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlGetValueListActionOnActive END (OK)");
        }
        
        [Test]
        [Category("P1")]
        [Description("GetValueListAction DealChar.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GetValueListAction.DealChar M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGetValueListActionDealChar()
        {
            tlog.Debug(tag, $"EXamlGetValueListActionDealChar START");

            var testingTarget = new Tizen.NUI.EXaml.GetValueListAction(')', new MyAction());
            Assert.IsNotNull(testingTarget, "Can't create success object GetValueListAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.GetValueListAction>(testingTarget, "Should be an instance of GetValueListAction type.");

            try
            {
                testingTarget.DealChar(' ');
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            try
            {
                testingTarget.DealChar('(');
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            try
            {
                testingTarget.DealChar('m');
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            
             try
            {
                testingTarget.DealChar(')');
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlGetValueListActionDealChar END (OK)");
        }
    }
}
