using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/GetValueAction")]
    public class InternalGetValueActionTest
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
        [Description("GetValueAction constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GetValueAction.GetValueAction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGetValueActionConstructor()
        {
            tlog.Debug(tag, $"EXamlGetValueActionConstructor START");

            var testingTarget = new Tizen.NUI.EXaml.GetValueAction(')', new MyAction());
            Assert.IsNotNull(testingTarget, "Can't create success object GetValueAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.GetValueAction>(testingTarget, "Should be an instance of GetValueAction type.");

            tlog.Debug(tag, $"EXamlGetValueActionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GetValueAction Init.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GetValueAction.Init M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGetValueActionInit()
        {
            tlog.Debug(tag, $"EXamlGetValueActionInit START");

            var testingTarget = new Tizen.NUI.EXaml.GetValueAction(')', new MyAction());
            Assert.IsNotNull(testingTarget, "Can't create success object GetValueAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.GetValueAction>(testingTarget, "Should be an instance of GetValueAction type.");

            try
            {
                testingTarget.Init();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlGetValueActionInit END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GetValueAction DealChar.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GetValueAction.DealChar M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGetValueActionDealChar()
        {
            tlog.Debug(tag, $"EXamlGetValueActionDealChar START");

            var testingTarget = new Tizen.NUI.EXaml.GetValueAction('\"', new MyAction());
            Assert.IsNotNull(testingTarget, "Can't create success object GetValueAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.GetValueAction>(testingTarget, "Should be an instance of GetValueAction type.");

            try
            {
                testingTarget.DealChar('\"');
            }
            catch (Exception e)
            {
                tlog.Error(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            var testingTarget1 = new Tizen.NUI.EXaml.GetValueAction('y', new MyAction());
            try
            {
                testingTarget1.DealChar('y');
            }
            catch (Exception e)
            {
                tlog.Error(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            var testingTarget2 = new Tizen.NUI.EXaml.GetValueAction('z', new MyAction());
            try
            {
                testingTarget2.DealChar('z');
            }
            catch (Exception e)
            {
                tlog.Error(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            var testingTarget3 = new Tizen.NUI.EXaml.GetValueAction('m', new MyAction());
            try
            {
                testingTarget3.DealChar('3');
            }
            catch (Exception e)
            {
                tlog.Info(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlGetValueActionDealChar END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GetValueAction DealChar, ('\"' != sign)")]
        [Property("SPEC", "Tizen.NUI.EXaml.GetValueAction.DealChar M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGetValueActionDealChar2()
        {
            tlog.Debug(tag, $"EXamlGetValueActionDealChar2 START");

            var testingTarget = new Tizen.NUI.EXaml.GetValueAction('\'', new MyAction());
            Assert.IsNotNull(testingTarget, "Can't create success object GetValueAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.GetValueAction>(testingTarget, "Should be an instance of GetValueAction type.");

            try
            {
                testingTarget.DealChar(' ');
            }
            catch (Exception e)
            {
                tlog.Error(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            try
            {
                testingTarget.DealChar('(');
            }
            catch (Exception e)
            {
                tlog.Error(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            try
            {
                testingTarget.DealChar('\\');
            }
            catch (Exception e)
            {
                tlog.Error(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlGetValueActionDealChar2 END (OK)");
        }
    }
}
