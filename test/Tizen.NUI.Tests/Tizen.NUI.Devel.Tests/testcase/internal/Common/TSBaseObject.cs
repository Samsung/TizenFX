using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/BaseObject")]
    public class InternalBaseObjectTest
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
        [Description("BaseObject constructor.")]
        [Property("SPEC", "Tizen.NUI.BaseObject.BaseObject C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseObjectConstructor()
        {
            tlog.Debug(tag, $"BaseObjectConstructor START");

            using (ImageView view = new ImageView())
            {
                var testingTarget = new BaseObject(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "should not be null.");
                Assert.IsInstanceOf<BaseObject>(testingTarget, "should be an instance of BaseObject class!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"BaseObjectConstructor END (OK)");
        }
    }
}
