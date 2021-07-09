using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ChildPropertyRegistration")]
    public class InternalChildPropertyRegistrationTest
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
        [Description("ChildPropertyRegistration constructor.")]
        [Property("SPEC", "Tizen.NUI.ChildPropertyRegistration.ChildPropertyRegistration C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ChildPropertyRegistrationcConstructor()
        {
            tlog.Debug(tag, $"ChildPropertyRegistrationcConstructor START");

            using (Animatable ani = new Animatable())
            {
                var registered = new TypeRegistration((global::System.IntPtr)ani.SwigCPtr, false);
                var testingTarget = new ChildPropertyRegistration(registered, "Animatable", 45000000, PropertyType.Boolean);
                Assert.IsNotNull(testingTarget, "should not be null.");
                Assert.IsInstanceOf<ChildPropertyRegistration>(testingTarget, "should be an instance of ChildPropertyRegistration class!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ChildPropertyRegistrationcConstructor END (OK)");
        }
    }
}
