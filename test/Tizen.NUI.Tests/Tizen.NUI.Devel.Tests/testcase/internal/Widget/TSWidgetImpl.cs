using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Widget/WidgetImpl")]
    public class PublicWidgetImplTest
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
        [Description("WidgetImpl.WIdgetInstanceOnCreateArgs.ContentInfo.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.WIdgetInstanceOnCreateArgs.ContentInfo A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplWIdgetInstanceOnCreateArgsContentInfo()
        {
            tlog.Debug(tag, $"WidgetImplWIdgetInstanceOnCreateArgsContentInfo START");

            var testingTarget = new WidgetImpl.WIdgetInstanceOnCreateArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object WIdgetInstanceOnCreateArgs");
            Assert.IsInstanceOf<WidgetImpl.WIdgetInstanceOnCreateArgs>(testingTarget, "Should be an instance of WIdgetInstanceOnCreateArgs type.");

            tlog.Debug(tag, "Default testingTarget.ContentInfo is : " + testingTarget.ContentInfo);

            testingTarget.ContentInfo = "WidgetImpl";
            tlog.Debug(tag, "testingTarget.ContentInfo : " + testingTarget.ContentInfo);

            tlog.Debug(tag, $"WidgetImplWIdgetInstanceOnCreateArgsContentInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.WIdgetInstanceOnCreateArgs.Window.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.WIdgetInstanceOnCreateArgs.Window A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplWIdgetInstanceOnCreateArgsWindow()
        {
            tlog.Debug(tag, $"WidgetImplWIdgetInstanceOnCreateArgsWindow START");

            var testingTarget = new WidgetImpl.WIdgetInstanceOnCreateArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object WIdgetInstanceOnCreateArgs");
            Assert.IsInstanceOf<WidgetImpl.WIdgetInstanceOnCreateArgs>(testingTarget, "Should be an instance of WIdgetInstanceOnCreateArgs type.");

            tlog.Debug(tag, "Default testingTarget.Window is : " + testingTarget.Window);

            testingTarget.Window = Window.Instance;
            tlog.Debug(tag, "testingTarget.Window : " + testingTarget.Window);

            tlog.Debug(tag, $"WidgetImplWIdgetInstanceOnCreateArgsWindow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.WIdgetInstanceOnDestroyArgs.ContentInfo.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.WIdgetInstanceOnDestroyArgs.ContentInfo A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplWIdgetInstanceOnDestroyArgsContentInfo()
        {
            tlog.Debug(tag, $"WidgetImplWIdgetInstanceOnDestroyArgsContentInfo START");

            var testingTarget = new WidgetImpl.WIdgetInstanceOnDestroyArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object WIdgetInstanceOnDestroyArgs");
            Assert.IsInstanceOf<WidgetImpl.WIdgetInstanceOnDestroyArgs>(testingTarget, "Should be an instance of WIdgetInstanceOnDestroyArgs type.");

            tlog.Debug(tag, "Default testingTarget.ContentInfo is : " + testingTarget.ContentInfo);

            testingTarget.ContentInfo = "WIdgetInstanceOnDestroyArgs";
            tlog.Debug(tag, "testingTarget.ContentInfo : " + testingTarget.ContentInfo);

            tlog.Debug(tag, $"WidgetImplWIdgetInstanceOnDestroyArgsContentInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.WIdgetInstanceOnDestroyArgs.TerminateType.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.WIdgetInstanceOnDestroyArgs.TerminateType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplWIdgetInstanceOnDestroyArgsTerminateType()
        {
            tlog.Debug(tag, $"WidgetImplWIdgetInstanceOnDestroyArgsTerminateType START");

            var testingTarget = new WidgetImpl.WIdgetInstanceOnDestroyArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object WIdgetInstanceOnDestroyArgs");
            Assert.IsInstanceOf<WidgetImpl.WIdgetInstanceOnDestroyArgs>(testingTarget, "Should be an instance of WIdgetInstanceOnDestroyArgs type.");

            tlog.Debug(tag, "Default testingTarget.TerminateType is : " + testingTarget.TerminateType);

            testingTarget.TerminateType = Widget.TerminationType.Permanent;
            tlog.Debug(tag, "testingTarget.TerminateType : " + testingTarget.TerminateType);

            testingTarget.TerminateType = Widget.TerminationType.Temporary;
            tlog.Debug(tag, "testingTarget.TerminateType : " + testingTarget.TerminateType);

            tlog.Debug(tag, $"WidgetImplWIdgetInstanceOnDestroyArgsTerminateType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.WidgetInstanceOnResizeArgs.Window.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.WidgetInstanceOnResizeArgs.Window A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplWidgetInstanceOnResizeArgsWindow()
        {
            tlog.Debug(tag, $"WidgetImplWidgetInstanceOnResizeArgsWindow START");

            var testingTarget = new WidgetImpl.WidgetInstanceOnResizeArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetInstanceOnResizeArgs");
            Assert.IsInstanceOf<WidgetImpl.WidgetInstanceOnResizeArgs>(testingTarget, "Should be an instance of WidgetInstanceOnResizeArgs type.");

            tlog.Debug(tag, "Default testingTarget.Window is : " + testingTarget.Window);

            testingTarget.Window = Window.Instance;
            tlog.Debug(tag, "testingTarget.Window : " + testingTarget.Window);

            tlog.Debug(tag, $"WidgetImplWidgetInstanceOnResizeArgsWindow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.WidgetInstanceOnUpdateArgs.ContentInfo.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.WidgetInstanceOnUpdateArgs.ContentInfo A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplWidgetInstanceOnUpdateArgsContentInfo()
        {
            tlog.Debug(tag, $"WidgetImplWidgetInstanceOnUpdateArgsContentInfo START");

            var testingTarget = new WidgetImpl.WidgetInstanceOnUpdateArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetInstanceOnUpdateArgs");
            Assert.IsInstanceOf<WidgetImpl.WidgetInstanceOnUpdateArgs>(testingTarget, "Should be an instance of WidgetInstanceOnUpdateArgs type.");

            tlog.Debug(tag, "Default testingTarget.ContentInfo is : " + testingTarget.ContentInfo);

            testingTarget.ContentInfo = "WidgetInstanceOnUpdateArgs";
            tlog.Debug(tag, "testingTarget.ContentInfo : " + testingTarget.ContentInfo);

            tlog.Debug(tag, $"WidgetImplWidgetInstanceOnUpdateArgsContentInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.WidgetInstanceOnUpdateArgs.Force.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.WidgetInstanceOnUpdateArgs.Force A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplWidgetInstanceOnUpdateArgsForce()
        {
            tlog.Debug(tag, $"WidgetImplWidgetInstanceOnUpdateArgsForce START");

            var testingTarget = new WidgetImpl.WidgetInstanceOnUpdateArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetInstanceOnUpdateArgs");
            Assert.IsInstanceOf<WidgetImpl.WidgetInstanceOnUpdateArgs>(testingTarget, "Should be an instance of WidgetInstanceOnUpdateArgs type.");

            tlog.Debug(tag, "Default testingTarget.Force is : " + testingTarget.Force);

            testingTarget.Force = 0;
            tlog.Debug(tag, "testingTarget.Force : " + testingTarget.Force);

            tlog.Debug(tag, $"WidgetImplWidgetInstanceOnUpdateArgsForce END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.SetImpl.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.SetImpl M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplSetImpl()
        {
            tlog.Debug(tag, $"WidgetImplSetImpl START");

            var testingTarget = new WidgetImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetImpl");
            Assert.IsInstanceOf<WidgetImpl>(testingTarget, "Should be an instance of WidgetImpl type.");

            Widget widget = new Widget();

            try
            {
                testingTarget.SetImpl(new SWIGTYPE_p_Dali__Widget__Impl(widget.GetIntPtr()));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            widget.Dispose();
            widget = null;

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"WidgetImplSetImpl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.OnCreate.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.OnCreate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplOnCreate()
        {
            tlog.Debug(tag, $"WidgetImplOnCreate START");

            var testingTarget = new WidgetImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetImpl");
            Assert.IsInstanceOf<WidgetImpl>(testingTarget, "Should be an instance of WidgetImpl type.");

            try
            {
                testingTarget.OnCreate("WidgetImplOnCreate", Window.Instance);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }
            
            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"WidgetImplOnCreate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.OnTerminate. Type is Permanent.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.OnTerminate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplOnTerminatePermanent()
        {
            tlog.Debug(tag, $"WidgetImplOnTerminatePermanent START");

            var testingTarget = new WidgetImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetImpl");
            Assert.IsInstanceOf<WidgetImpl>(testingTarget, "Should be an instance of WidgetImpl type.");

            try
            {
                testingTarget.OnTerminate("WidgetImplOnTerminate", Widget.TerminationType.Permanent);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"WidgetImplOnTerminatePermanent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.OnTerminate. Type is Temporary.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.OnTerminate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplOnTerminateTemporary()
        {
            tlog.Debug(tag, $"WidgetImplOnTerminateTemporary START");

            var testingTarget = new WidgetImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetImpl");
            Assert.IsInstanceOf<WidgetImpl>(testingTarget, "Should be an instance of WidgetImpl type.");

            try
            {
                testingTarget.OnTerminate("WidgetImplOnTerminate", Widget.TerminationType.Temporary);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"WidgetImplOnTerminateTemporary END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.OnPause.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.OnPause M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplOnPause()
        {
            tlog.Debug(tag, $"WidgetImplOnPause START");

            var testingTarget = new WidgetImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetImpl");
            Assert.IsInstanceOf<WidgetImpl>(testingTarget, "Should be an instance of WidgetImpl type.");

            try
            {
                testingTarget.OnPause();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"WidgetImplOnPause END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.OnResume.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.OnResume M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplOnResume()
        {
            tlog.Debug(tag, $"WidgetImplOnResume START");

            var testingTarget = new WidgetImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetImpl");
            Assert.IsInstanceOf<WidgetImpl>(testingTarget, "Should be an instance of WidgetImpl type.");

            try
            {
                testingTarget.OnResume();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"WidgetImplOnResume END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.OnResize.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.OnResize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplOnResize()
        {
            tlog.Debug(tag, $"WidgetImplOnResize START");

            var testingTarget = new WidgetImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetImpl");
            Assert.IsInstanceOf<WidgetImpl>(testingTarget, "Should be an instance of WidgetImpl type.");

            try
            {
                testingTarget.OnResize(Window.Instance);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"WidgetImplOnResize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImpl.OnUpdate.")]
        [Property("SPEC", "Tizen.NUI.WidgetImpl.OnUpdate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplOnUpdate()
        {
            tlog.Debug(tag, $"WidgetImplOnUpdate START");

            var testingTarget = new WidgetImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetImpl");
            Assert.IsInstanceOf<WidgetImpl>(testingTarget, "Should be an instance of WidgetImpl type.");

            try
            {
                testingTarget.OnUpdate("WidgetImplOnUpdate", 0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"WidgetImplOnUpdate END (OK)");
        }
    }
}
