using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.EXaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/RootAction")]
    public class InternalRootActionTest
    {
        private const string tag = "NUITEST";

        internal class MyRootAction : Tizen.NUI.EXaml.Action
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
        [Description("RootAction constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.RootAction.RootAction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlRootActionConstructor()
        {
            tlog.Debug(tag, $"EXamlRootActionConstructor START");

            var globalDataList = new GlobalDataList();

            var testingTarget = new Tizen.NUI.EXaml.RootAction(globalDataList);
            Assert.IsNotNull(testingTarget, "Can't create success object RootAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.RootAction>(testingTarget, "Should be an instance of RootAction type.");

            tlog.Debug(tag, $"EXamlRootActionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RootAction Init.")]
        [Property("SPEC", "Tizen.NUI.EXaml.RootAction.Init M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlRootActionInit()
        {
            tlog.Debug(tag, $"EXamlRootActionInit START");

            var globalDataList = new GlobalDataList();
            
            var testingTarget = new Tizen.NUI.EXaml.RootAction(globalDataList);
            Assert.IsNotNull(testingTarget, "Can't create success object RootAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.RootAction>(testingTarget, "Should be an instance of RootAction type.");

            try
            {
                testingTarget.Init();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlRootActionInit END (OK)");
        }
        
        [Test]
        [Category("P1")]
        [Description("RootAction DealChar.")]
        [Property("SPEC", "Tizen.NUI.EXaml.RootAction.DealChar M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlRootActionDealChar()
        {
            tlog.Debug(tag, $"EXamlRootActionDealChar START");

            var globalDataList = new GlobalDataList();

            var testingTarget = new Tizen.NUI.EXaml.RootAction(globalDataList);
            Assert.IsNotNull(testingTarget, "Can't create success object RootAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.RootAction>(testingTarget, "Should be an instance of RootAction type.");

            try
            {
                testingTarget.DealChar('(');
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlRootActionDealChar END (OK)");
        }
    }
}