using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Block/GatherEventsBlock")]
    internal class PublicGatherEventsBlockTest
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
        //[Description("GatherEventsBlock constructor.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.GatherEventsBlock.GatherEventsBlock C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlGatherEventsBlockConstructor()
        //{
        //    tlog.Debug(tag, $"EXamlGatherEventsBlockConstructor START");

        //    var testingTarget = new Tizen.NUI.EXaml.GatherEventsBlock(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object GatherEventsBlock");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.GatherEventsBlock>(testingTarget, "Should be an instance of GatherEventsBlock type.");

        //    tlog.Debug(tag, $"EXamlGatherEventsBlockConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("GatherEventsBlock Init.")]
        //[Property("SPEC", "Tizen.NUI.EXaml.GatherEventsBlock.Init M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void EXamlGatherEventsBlockInit()
        //{
        //    tlog.Debug(tag, $"EXamlGatherEventsBlockInit START");

        //    var testingTarget = new Tizen.NUI.EXaml.GatherEventsBlock(new Tizen.NUI.EXaml.GlobalDataList(), null);
        //    Assert.IsNotNull(testingTarget, "Can't create success object GatherEventsBlock");
        //    Assert.IsInstanceOf<Tizen.NUI.EXaml.GatherEventsBlock>(testingTarget, "Should be an instance of GatherEventsBlock type.");

        //    try
        //    {
        //        testingTarget.Init();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    tlog.Debug(tag, $"EXamlGatherEventsBlockInit END (OK)");
        //}
    }
}
