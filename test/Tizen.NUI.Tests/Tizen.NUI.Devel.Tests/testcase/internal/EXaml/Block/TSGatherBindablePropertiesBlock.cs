using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Block/GatherBindablePropertiesBlock")]
    internal class PublicGatherBindablePropertiesBlockTest
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
        //[Description("GatherBindablePropertiesBlock constructor.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.GatherBindablePropertiesBlock.GatherBindablePropertiesBlock C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlGatherBindablePropertiesBlockConstructor()
        //{
        //    tlog.Debug(tag, $"EXamlGatherBindablePropertiesBlockConstructor START");

        //    var testingTarget = new Tizen.NUI.EXaml.GatherBindablePropertiesBlock(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object GatherBindablePropertiesBlock");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.GatherBindablePropertiesBlock>(testingTarget, "Should be an instance of GatherBindablePropertiesBlock type.");

        //    tlog.Debug(tag, $"EXamlGatherBindablePropertiesBlockConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("GatherBindablePropertiesBlock Init.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.GatherBindablePropertiesBlock.Init M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlGatherBindablePropertiesBlockInit()
        //{
        //    tlog.Debug(tag, $"EXamlGatherBindablePropertiesBlockInit START");

        //    var testingTarget = new Tizen.NUI.EXaml.GatherBindablePropertiesBlock(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object GatherBindablePropertiesBlock");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.GatherBindablePropertiesBlock>(testingTarget, "Should be an instance of GatherBindablePropertiesBlock type.");

        //    try
        //    {
        //        testingTarget.Init();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    tlog.Debug(tag, $"EXamlGatherBindablePropertiesBlockInit END (OK)");
        //}
    }
}
