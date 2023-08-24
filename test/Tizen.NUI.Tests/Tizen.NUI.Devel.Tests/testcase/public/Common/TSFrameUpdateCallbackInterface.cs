using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/FrameUpdateCallbackInterface")]
    class PublicFrameUpdateCallbackInterfaceTest
    {
        private const string tag = "NUITEST";

        internal class MyFrameUpdateCallbackInterface : FrameUpdateCallbackInterface
        {
            public MyFrameUpdateCallbackInterface() : base()
            { }

            public View view = new View()
            {
                Size = new Size(100, 150, 40),
                Position = new Position(20, 40),
                Color = new Tizen.NUI.Color("#C3CAD5FF")
            };

            public override void OnUpdate(float elapsedSeconds)
            {
                base.GetPosition(view.ID, new Position(100.0f, 150.0f, 0.0f));
                base.SetPosition(view.ID, new Position(100.0f, 150.0f, 0.0f));
                base.BakePosition(view.ID, new Position(100.0f, 150.0f, 0.0f));
                base.GetSize(view.ID, new Size(100.0f, 150.0f, 0.0f));
                base.SetSize(view.ID, new Size(100.0f, 150.0f, 0.0f));
                base.BakeSize(view.ID, new Size(100.0f, 150.0f, 0.0f));
                base.GetScale(view.ID, new Vector3(100.0f, 150.0f, 0.0f));
                base.SetScale(view.ID, new Vector3(100.0f, 150.0f, 0.0f));
                base.BakeScale(view.ID, new Vector3(100.0f, 150.0f, 0.0f));
                base.GetColor(view.ID, new Tizen.NUI.Color("#C3CAD2FF"));
                base.SetColor(view.ID, new Tizen.NUI.Color("#C3CAD3FF"));
                base.BakeColor(view.ID, new Tizen.NUI.Color("#C3CAD4FF"));
                base.GetPositionAndSize(view.ID, new Position(100.0f, 150.0f, 0.0f), new Size(100.0f, 200.0f, 300.0f));
                base.OnUpdate(300);
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
        [Description("FrameUpdateCallbackInterface constructor.")]
        [Property("SPEC", "Tizen.NUI.FrameUpdateCallbackInterface.FrameUpdateCallbackInterface C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameUpdateCallbackInterfaceConstructor()
        {
            tlog.Debug(tag, $"FrameUpdateCallbackInterfaceConstructor START");

            var testingTarget = new FrameUpdateCallbackInterface();
            Assert.IsNotNull(testingTarget, "Can't create success object FrameUpdateCallbackInterface");
            Assert.IsInstanceOf<FrameUpdateCallbackInterface>(testingTarget, "Should return FrameUpdateCallbackInterface instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FrameUpdateCallbackInterfaceConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameUpdateCallbackInterface OnUpdate.")]
        [Property("SPEC", "Tizen.NUI.FrameUpdateCallbackInterface.OnUpdate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameUpdateCallbackInterfaceOnUpdate()
        {
            tlog.Debug(tag, $"FrameUpdateCallbackInterfaceOnUpdate START");

            var testingTarget = new MyFrameUpdateCallbackInterface();
            Assert.IsNotNull(testingTarget, "Can't create success object FrameUpdateCallbackInterface");
            Assert.IsInstanceOf<FrameUpdateCallbackInterface>(testingTarget, "Should return FrameUpdateCallbackInterface instance.");

            try
            {
                testingTarget.OnUpdate(300);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FrameUpdateCallbackInterfaceOnUpdate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameUpdateCallbackInterface AddFrameUpdateCallback.")]
        [Property("SPEC", "Tizen.NUI.FrameUpdateCallbackInterface.AddFrameUpdateCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameUpdateCallbackInterfaceAddFrameUpdateCallback()
        {
            tlog.Debug(tag, $"FrameUpdateCallbackInterfaceAddFrameUpdateCallback START");

            var testingTarget = new MyFrameUpdateCallbackInterface();
            Assert.IsNotNull(testingTarget, "Can't create success object FrameUpdateCallbackInterface");
            Assert.IsInstanceOf<FrameUpdateCallbackInterface>(testingTarget, "Should return FrameUpdateCallbackInterface instance.");

            try
            {
                NUIApplication.GetDefaultWindow().AddFrameUpdateCallback(testingTarget);
                NUIApplication.GetDefaultWindow().RemoveFrameUpdateCallback(testingTarget);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FrameUpdateCallbackInterfaceAddFrameUpdateCallback END (OK)");
        }
    }
}
