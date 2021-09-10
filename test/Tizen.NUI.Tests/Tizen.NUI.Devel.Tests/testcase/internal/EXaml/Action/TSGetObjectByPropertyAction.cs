using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/GetObjectByPropertyAction")]
    public class InternalGetObjectByPropertyActionTest
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
        //[Description("GetObjectByPropertyAction constructor.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.GetObjectByPropertyAction.GetObjectByPropertyAction C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlGetObjectByPropertyActionConstructor()
        //{
        //    tlog.Debug(tag, $"EXamlGetObjectByPropertyActionConstructor START");

        //    var testingTarget = new Tizen.NUI.EXaml.GetObjectByPropertyAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object GetObjectByPropertyAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.GetObjectByPropertyAction>(testingTarget, "Should be an instance of GetObjectByPropertyAction type.");

        //    tlog.Debug(tag, $"EXamlGetObjectByPropertyActionConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("GetObjectByPropertyAction Init.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.GetObjectByPropertyAction.Init M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlGetObjectByPropertyActionInit()
        //{
        //    tlog.Debug(tag, $"EXamlGetObjectByPropertyActionInit START");

        //    var testingTarget = new Tizen.NUI.EXaml.GetObjectByPropertyAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object GetObjectByPropertyAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.GetObjectByPropertyAction>(testingTarget, "Should be an instance of GetObjectByPropertyAction type.");

        //    try
        //    {
        //        testingTarget.Init();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    tlog.Debug(tag, $"EXamlGetObjectByPropertyActionInit END (OK)");
        //}
    }
}
