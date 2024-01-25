using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Application/NUIComponentApplication")]
    class PublicNUIComponentApplicationTest
    {
        private const string tag = "NUITEST";

        internal class MyNUIComponentApplication : NUIComponentApplication
        {
            public MyNUIComponentApplication(IDictionary<Type, string> typeInfo) : base(typeInfo)
            { }

            public void MyOnCreate() {   base.OnCreate();    }

            public void MyOnTerminate() {   base.OnTerminate();    }

            public void MyExit() { base.Exit(); }
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
        [Description("NUIComponentApplication constructor.")]
        [Property("SPEC", "Tizen.NUI.NUIComponentApplication.NUIComponentApplication M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentApplicationConstructor()
        {
            tlog.Debug(tag, $"NUIComponentApplicationConstructor START");

            IDictionary<Type, string> typeInfo = new Dictionary<Type, string>();
            typeInfo.Add(typeof(Applications.ComponentBased.Common.FrameComponent), "FrameComponent");
            typeInfo.Add(typeof(Applications.ComponentBased.Common.ServiceComponent), "ServiceComponent");
            var testingTarget = new NUIComponentApplication(typeInfo);
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIComponentApplication>(testingTarget, "Should be an instance of NUIComponentApplication type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIComponentApplicationConstructor END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("NUIComponentApplication constructor. With illegal type.")]
        [Property("SPEC", "Tizen.NUI.NUIComponentApplication.NUIComponentApplication M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentApplicationConstructorWithIllegalType()
        {
            tlog.Debug(tag, $"NUIComponentApplicationConstructorWithIllegalType START");

            IDictionary<Type, string> typeInfo = new Dictionary<Type, string>();
            typeInfo.Add(typeof(Widget), "Widget");

            try
            {
                new NUIComponentApplication(typeInfo);
            }
            catch (ArgumentException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"NUIComponentApplicationConstructorWithIllegalType END (OK)");
                Assert.Pass("Caught ArgumentException: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("NUIComponentApplication constructor. With null parameter.")]
        [Property("SPEC", "Tizen.NUI.NUIComponentApplication.NUIComponentApplication M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentApplicationConstructorWithNull()
        {
            tlog.Debug(tag, $"NUIComponentApplicationConstructorWithNull START");

            var testingTarget = new NUIComponentApplication(null);
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIComponentApplication>(testingTarget, "Should be an instance of NUIComponentApplication type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIComponentApplicationConstructorWithNull END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIComponentApplication OnCreate.")]
        [Property("SPEC", "Tizen.NUI.NUIComponentApplication.OnCreate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentApplicationOnCreate()
        {
            tlog.Debug(tag, $"NUIComponentApplicationOnCreate START");

            IDictionary<Type, string> typeInfo = new Dictionary<Type, string>();
            typeInfo.Add(typeof(Applications.ComponentBased.Common.FrameComponent), "FrameComponent");
            var testingTarget = new MyNUIComponentApplication(typeInfo);
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIComponentApplication>(testingTarget, "Should be an instance of NUIComponentApplication type.");

            try
            {
                testingTarget.MyOnCreate();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIComponentApplicationOnCreate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIComponentApplication OnTerminate.")]
        [Property("SPEC", "Tizen.NUI.NUIComponentApplication.OnTerminate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentApplicationOnTerminate()
        {
            tlog.Debug(tag, $"NUIComponentApplicationOnCreate START");

            IDictionary<Type, string> typeInfo = new Dictionary<Type, string>();
            typeInfo.Add(typeof(Applications.ComponentBased.Common.FrameComponent), "FrameComponent");
            var testingTarget = new MyNUIComponentApplication(typeInfo);
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIComponentApplication>(testingTarget, "Should be an instance of NUIComponentApplication type.");

            try
            {
                testingTarget.MyOnTerminate();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIComponentApplicationOnCreate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIComponentApplication Exit.")]
        [Property("SPEC", "Tizen.NUI.NUIComponentApplication.Exit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentApplicationExit()
        {
            tlog.Debug(tag, $"NUIComponentApplicationExit START");

            IDictionary<Type, string> typeInfo = new Dictionary<Type, string>();
            typeInfo.Add(typeof(Applications.ComponentBased.Common.FrameComponent), "FrameComponent");
            var testingTarget = new MyNUIComponentApplication(typeInfo);
            Assert.IsNotNull(testingTarget, "Should be not null.");
            Assert.IsInstanceOf<NUIComponentApplication>(testingTarget, "Should be an instance of NUIComponentApplication type.");

            try
            {
                testingTarget.MyExit();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIComponentApplicationExit END (OK)");
        }

    }
}
