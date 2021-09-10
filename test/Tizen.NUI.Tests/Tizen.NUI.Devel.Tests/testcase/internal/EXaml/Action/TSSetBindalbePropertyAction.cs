using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/SetBindalbePropertyAction")]
    public class InternalEXamlSetBindalbePropertyActionTest
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
        //[Description("SetBindalbePropertyAction constructor.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.SetBindalbePropertyAction.SetBindalbePropertyAction C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlSetBindalbePropertyActionConstructor()
        //{
        //    tlog.Debug(tag, $"EXamlSetBindalbePropertyActionConstructor START");

        //    var testingTarget = new Tizen.NUI.EXaml.SetBindalbePropertyAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object SetBindalbePropertyAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.SetBindalbePropertyAction>(testingTarget, "Should be an instance of SetBindalbePropertyAction type.");

        //    tlog.Debug(tag, $"EXamlSetBindalbePropertyActionConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("SetBindalbePropertyAction Init.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.SetBindalbePropertyAction.Init M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlSetBindalbePropertyActionInit()
        //{
        //    tlog.Debug(tag, $"EXamlSetBindalbePropertyActionInit START");

        //    var testingTarget = new Tizen.NUI.EXaml.SetBindalbePropertyAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object SetBindalbePropertyAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.SetBindalbePropertyAction>(testingTarget, "Should be an instance of SetBindalbePropertyAction type.");

        //    try
        //    {
        //        testingTarget.Init();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    tlog.Debug(tag, $"EXamlSetBindalbePropertyActionInit END (OK)");
        //}
    }
}
