﻿using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using Tizen.NUI;
namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/FrameBroker/DefaultFrameBroker")]
    class InternalDefaultFrameBrokerTest
    {
        private const string tag = "NUITEST";
        private const string MyAppId = "org.tizen.SampleServiceApp.Tizen";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MyDefaultFrameBroker : DefaultFrameBroker
        {
            public MyDefaultFrameBroker(Window win) : base(win)
            { }

            public void MyOnFrameCreated()
            {
                base.OnFrameCreated();
            }

            public void MyOnFrameResumed(FrameData frame)
            {
                base.OnFrameResumed(frame);
            }

            public void MyOnFrameUpdated(FrameData frame)
            {
                base.OnFrameUpdated(frame);
            }

            public void MyOnFramePaused()
            {
                base.OnFramePaused();
            }

            public void MyOnFrameDestroyed()
            {
                base.OnFrameDestroyed();
            }

            public void MyOnFrameErred(FrameError error)
            {
                base.OnFrameErred(error);
            }
        }

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
        [Description("DefaultFrameBroker constructor.")]
        [Property("SPEC", "Tizen.NUI.DefaultFrameBroker.DefaultFrameBroker C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultFrameBrokerConstructor()
        {
            tlog.Debug(tag, $"DefaultFrameBrokerConstructor START");

            var testingTarget = new DefaultFrameBroker(Window.Instance);
            Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
            Assert.IsInstanceOf<DefaultFrameBroker>(testingTarget, "Should be an instance of DefaultFrameBroker type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultFrameBrokerConstructor END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("DefaultFrameBroker constructor. With null window.")]
        [Property("SPEC", "Tizen.NUI.DefaultFrameBroker.DefaultFrameBroker M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultFrameBrokerConstructorWindowIsNull()
        {
            tlog.Debug(tag, $"DefaultFrameBrokerConstructorWindowIsNull START");

            using (Window window = null)
            {
                try
                {
                    var testingTarget = new DefaultFrameBroker(window);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    tlog.Debug(tag, $"DefaultFrameBrokerConstructorWindowIsNull END (OK)");
                    Assert.Pass("Caught Exception : Passed!");
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("DefaultFrameBroker OnFrameCreated.")]
        [Property("SPEC", "Tizen.NUI.DefaultFrameBroker.OnFrameCreated M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultFrameBrokerOnFrameCreated()
        {
            tlog.Debug(tag, $"DefaultFrameBrokerOnFrameCreated START");

            var testingTarget = new MyDefaultFrameBroker(Window.Instance);
            Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
            Assert.IsInstanceOf<DefaultFrameBroker>(testingTarget, "Should be an instance of DefaultFrameBroker type.");

            try
            {
                testingTarget.MyOnFrameCreated();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"DefaultFrameBrokerOnFrameCreated END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultFrameBroker OnFramePaused.")]
        [Property("SPEC", "Tizen.NUI.DefaultFrameBroker.OnFramePaused M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultFrameBrokerOnFramePaused()
        {
            tlog.Debug(tag, $"DefaultFrameBrokerOnFramePaused START");

            var testingTarget = new MyDefaultFrameBroker(Window.Instance);
            Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
            Assert.IsInstanceOf<DefaultFrameBroker>(testingTarget, "Should be an instance of DefaultFrameBroker type.");

            try
            {
                testingTarget.MyOnFramePaused();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"DefaultFrameBrokerOnFramePaused END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultFrameBroker OnFrameDestroyed.")]
        [Property("SPEC", "Tizen.NUI.DefaultFrameBroker.OnFrameDestroyed M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultFrameBrokerOnFrameDestroyed()
        {
            tlog.Debug(tag, $"DefaultFrameBrokerOnFrameDestroyed START");

            var testingTarget = new MyDefaultFrameBroker(Window.Instance);
            Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
            Assert.IsInstanceOf<DefaultFrameBroker>(testingTarget, "Should be an instance of DefaultFrameBroker type.");

            try
            {
                testingTarget.MyOnFrameDestroyed();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"DefaultFrameBrokerOnFrameDestroyed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultFrameBroker OnFrameErred.")]
        [Property("SPEC", "Tizen.NUI.DefaultFrameBroker.OnFrameErred M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultFrameBrokerOnFrameErred()
        {
            tlog.Debug(tag, $"DefaultFrameBrokerOnFrameErred START");

            var testingTarget = new MyDefaultFrameBroker(Window.Instance);
            Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
            Assert.IsInstanceOf<DefaultFrameBroker>(testingTarget, "Should be an instance of DefaultFrameBroker type.");

            try
            {
                testingTarget.MyOnFrameErred(FrameError.Disqualified);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"DefaultFrameBrokerOnFrameErred END (OK)");
        }
    }
}
