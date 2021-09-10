using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/SetDynamicResourceAction")]
    public class InternalEXamlSetDynamicResourceActionTest
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
        //[Description("SetDynamicResourceAction constructor.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.SetDynamicResourceAction.SetDynamicResourceAction C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlSetDynamicResourceActionConstructor()
        //{
        //    tlog.Debug(tag, $"EXamlSetDynamicResourceActionConstructor START");

        //    var testingTarget = new Tizen.NUI.EXaml.SetDynamicResourceAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object SetDynamicResourceAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.SetDynamicResourceAction>(testingTarget, "Should be an instance of SetDynamicResourceAction type.");

        //    tlog.Debug(tag, $"EXamlSetDynamicResourceActionConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("SetDynamicResourceAction Init.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.SetDynamicResourceAction.Init M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlSetDynamicResourceActionInit()
        //{
        //    tlog.Debug(tag, $"EXamlSetDynamicResourceActionInit START");

        //    var testingTarget = new Tizen.NUI.EXaml.SetDynamicResourceAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object SetDynamicResourceAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.SetDynamicResourceAction>(testingTarget, "Should be an instance of SetDynamicResourceAction type.");

        //    try
        //    {
        //        testingTarget.Init();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    tlog.Debug(tag, $"EXamlSetDynamicResourceActionInit END (OK)");
        //}
    }
}
