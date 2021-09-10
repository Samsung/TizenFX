using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/CreateInstanceAction")]
    public class InternalCreateInstanceActionTest
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
        //[Description("CreateInstanceAction constructor.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.CreateInstanceAction.CreateInstanceAction C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlCreateInstanceActionConstructor()
        //{
        //    tlog.Debug(tag, $"EXamlCreateInstanceActionConstructor START");

        //    var testingTarget = new Tizen.NUI.EXaml.CreateInstanceAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object CreateInstanceAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.CreateInstanceAction>(testingTarget, "Should be an instance of CreateInstanceAction type.");

        //    tlog.Debug(tag, $"EXamlCreateInstanceActionConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("CreateInstanceAction Init.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.CreateInstanceAction.Init M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlCreateInstanceActionInit()
        //{
        //    tlog.Debug(tag, $"EXamlCreateInstanceActionInit START");

        //    var testingTarget = new Tizen.NUI.EXaml.CreateInstanceAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object CreateInstanceAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.CreateInstanceAction>(testingTarget, "Should be an instance of CreateInstanceAction type.");

        //    try
        //    {
        //        testingTarget.Init();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    tlog.Debug(tag, $"EXamlCreateInstanceActionnit END (OK)");
        //}
    }
}
