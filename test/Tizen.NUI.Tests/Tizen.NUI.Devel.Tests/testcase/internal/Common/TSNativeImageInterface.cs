using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/NativeImageInterface")]
    public class InternalNativeImageInterfaceTest
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
        [Description("NativeImageInterface constructor.")]
        [Property("SPEC", "Tizen.NUI.NativeImageInterface.NativeImageInterface C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NativeImageInterfaceConstructor()
        {
            tlog.Debug(tag, $"NativeImageInterfaceConstructor START");

            using (ImageView view = new ImageView())
            {
                var testingTarget = new NativeImageInterface(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<NativeImageInterface>(testingTarget, "Should be an Instance of NativeImageInterface!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"NativeImageInterfaceConstructor END (OK)");
        }
    }
}
