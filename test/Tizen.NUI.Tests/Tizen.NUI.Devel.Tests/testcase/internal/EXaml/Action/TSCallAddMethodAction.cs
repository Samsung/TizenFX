using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/CallAddMethodAction")]
    public class InternalCallAddMethodActionTest
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

        //[Test]
        //[Category("P1")]
        //[Description("CallAddMethodAction construtor.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.CallAddMethodAction.CallAddMethodAction C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlCallAddMethodActionConstructor()
        //{
        //    tlog.Debug(tag, $"EXamlCallAddMethodActionConstructor START");

        //    var testingTarget = new Tizen.NUI.EXaml.CallAddMethodAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object CallAddMethodAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.CallAddMethodAction>(testingTarget, "Should be an instance of CallAddMethodAction type.");

        //    tlog.Debug(tag, $"EXamlCallAddMethodActionConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("CallAddMethodAction Init.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.CallAddMethodAction.Init M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlCallAddMethodActionInit()
        //{
        //    tlog.Debug(tag, $"EXamlCallAddMethodActionInit START");

        //    var testingTarget = new Tizen.NUI.EXaml.CallAddMethodAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object CallAddMethodAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.CallAddMethodAction>(testingTarget, "Should be an instance of CallAddMethodAction type.");

        //    try
        //    {
        //        testingTarget.Init();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    tlog.Debug(tag, $"EXamlCallAddMethodActionInit END (OK)");
        //}
    }
}
