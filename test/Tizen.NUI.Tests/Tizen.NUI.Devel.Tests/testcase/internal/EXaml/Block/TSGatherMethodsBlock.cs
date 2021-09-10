using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Block/GatherMethodsBlock")]
    internal class PublicGatherMethodsBlockTest
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
        //[Description("GatherMethodsBlock constructor.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.GatherMethodsBlock.GatherMethodsBlock C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlGatherMethodsBlockConstructor()
        //{
        //    tlog.Debug(tag, $"EXamlGatherMethodsBlockConstructor START");

        //    var testingTarget = new Tizen.NUI.EXaml.GatherMethodsBlock(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object GatherMethodsBlock");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.GatherMethodsBlock>(testingTarget, "Should be an instance of GatherMethodsBlock type.");

        //    tlog.Debug(tag, $"EXamlGatherMethodsBlockConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("GatherMethodsBlock Init.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.GatherMethodsBlock.Init M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlGatherMethodsBlockInit()
        //{
        //    tlog.Debug(tag, $"EXamlGatherMethodsBlockInit START");

        //    var testingTarget = new Tizen.NUI.EXaml.GatherMethodsBlock(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object GatherMethodsBlock");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.GatherMethodsBlock>(testingTarget, "Should be an instance of GatherMethodsBlock type.");

        //    try
        //    {
        //        testingTarget.Init();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    tlog.Debug(tag, $"EXamlGatherMethodsBlockInit END (OK)");
        //}
    }
}
