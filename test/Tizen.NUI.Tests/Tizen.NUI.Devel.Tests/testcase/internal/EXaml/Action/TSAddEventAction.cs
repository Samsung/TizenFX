using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/AddEventAction")]
    public class InternalAddEventActionTest
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
        //[Description("AddEventAction AddEventAction.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.AddEventAction.AddEventAction C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlAddEventActionConstructor()
        //{
        //    tlog.Debug(tag, $"EXamlAddEventActionConstructor START");

        //    var testingTarget = new Tizen.NUI.EXaml.AddEventAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object AddEventAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.AddEventAction>(testingTarget, "Should be an instance of AddEventAction type.");

        //    tlog.Debug(tag, $"EXamlAddEventActionConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AddEventAction Init.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.AddEventAction.Init M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlAddEventActionInit()
        //{
        //    tlog.Debug(tag, $"EXamlAddEventActionInit START");

        //    var testingTarget = new Tizen.NUI.EXaml.AddEventAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object AddEventAction");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.AddEventAction>(testingTarget, "Should be an instance of AddEventAction type.");

        //    try
        //    {
        //        testingTarget.Init();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    tlog.Debug(tag, $"EXamlAddEventActionInit END (OK)");
        //}
    }
}
