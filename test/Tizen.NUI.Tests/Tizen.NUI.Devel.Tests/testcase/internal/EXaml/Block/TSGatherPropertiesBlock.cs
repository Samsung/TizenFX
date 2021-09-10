using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Block/GatherPropertiesBlock")]
    internal class PublicGatherPropertiesBlockTest
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
        //[Description("GatherPropertiesBlock constructor.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.GatherPropertiesBlock.GatherPropertiesBlock C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlGatherPropertiesBlockConstructor()
        //{
        //    tlog.Debug(tag, $"EXamlGatherPropertiesBlockConstructor START");

        //    var testingTarget = new Tizen.NUI.EXaml.GatherPropertiesBlock(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object GatherPropertiesBlock");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.GatherPropertiesBlock>(testingTarget, "Should be an instance of GatherPropertiesBlock type.");

        //    tlog.Debug(tag, $"EXamlGatherPropertiesBlockConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("GatherPropertiesBlock Init.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.GatherPropertiesBlock.Init M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlGatherPropertiesBlockInit()
        //{
        //    tlog.Debug(tag, $"EXamlGatherPropertiesBlockInit START");

        //    var testingTarget = new Tizen.NUI.EXaml.GatherPropertiesBlock(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object GatherPropertiesBlock");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.GatherPropertiesBlock>(testingTarget, "Should be an instance of GatherPropertiesBlock type.");

        //    try
        //    {
        //        testingTarget.Init();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    tlog.Debug(tag, $"EXamlGatherPropertiesBlockInit END (OK)");
        //}
    }
}
