using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ViewWrapperImpl")]
    public class InternalViewWrapperImplTest
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

        [Test]
        [Category("P1")]
        [Description("ViewWrapperImpl constructor.")]
        [Property("SPEC", "Tizen.NUI.ViewWrapperImpl.ViewWrapperImpl M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewWrapperImplConstructor()
        {
            tlog.Debug(tag, $"ViewWrapperImplConstructor START");

            var testingTarget = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ViewWrapperImpl>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            // disposed
            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewWrapperImplConstructor END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("ViewWrapperImpl New.")]
        //[Property("SPEC", "Tizen.NUI.ViewWrapperImpl.New M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void ViewWrapperImplNew()
        //{
        //    tlog.Debug(tag, $"ViewWrapperImplNew START");

        //    using (ViewWrapperImpl impl = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault))
        //    {
        //        var testingTarget = ViewWrapperImpl.New("CustomView", impl);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<ViewWrapper>(testingTarget, "should be an instance of testing target class!");

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"ViewWrapperImplNew END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("ViewWrapperImpl ApplyThemeStyle.")]
        //[Property("SPEC", "Tizen.NUI.ViewWrapperImpl.ApplyThemeStyle M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void ViewWrapperImplApplyThemeStyle()
        //{
        //    tlog.Debug(tag, $"ViewWrapperImplApplyThemeStyle START");

        //    var testingTarget = new ViewWrapperImpl(CustomViewBehaviour.ViewBehaviourDefault);
        //    Assert.IsNotNull(testingTarget, "should be not null");
        //    Assert.IsInstanceOf<ViewWrapperImpl>(testingTarget, "should be an instance of testing target class!");

        //    try
        //    {
        //        testingTarget.ApplyThemeStyle();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"ViewWrapperImplApplyThemeStyle END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("ViewWrapperImpl ViewBehaviourFlagCount.")]
        [Property("SPEC", "Tizen.NUI.ViewWrapperImpl.ViewBehaviourFlagCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewWrapperImplViewBehaviourFlagCount()
        {
            tlog.Debug(tag, $"ViewWrapperImplViewBehaviourFlagCount START");

            var result = ViewWrapperImpl.ViewBehaviourFlagCount;
            tlog.Debug(tag, "ViewBehaviourFlagCount : " + result);

            tlog.Debug(tag, $"ViewWrapperImplViewBehaviourFlagCount END (OK)");
        }
    }
}
