using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/OtherAction")]
    public class InternalEXamlOtherActionTest
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
        //[Description("OtherAction constructor.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.OtherAction.OtherAction C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlOtherActionConstructor()
        //{
        //    tlog.Debug(tag, $"EXamlOtherActionConstructor START");

        //    var testingTarget = new Tizen.NUI.EXaml.OtherAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object OtherAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.OtherAction>(testingTarget, "Should be an instance of OtherAction type.");

        //    tlog.Debug(tag, $"EXamlOtherActionConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("OtherAction Init.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.OtherAction.Init M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlOtherActionInit()
        //{
        //    tlog.Debug(tag, $"EXamlOtherActionInit START");

        //    var testingTarget = new Tizen.NUI.EXaml.OtherAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object OtherAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.OtherAction>(testingTarget, "Should be an instance of OtherAction type.");

        //    try
        //    {
        //        testingTarget.Init();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    tlog.Debug(tag, $"EXamlOtherActionInit END (OK)");
        //}
    }
}
