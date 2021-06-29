using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Animation/AnimatablePropertyRegistration")]
    public class InternalAnimatablePropertyRegistrationTest
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
        [Description("AnimatablePropertyRegistration constructor with PropertyType")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatablePropertyRegistrationConstructorWithPropertyType()
        {
            tlog.Debug(tag, $"AnimatablePropertyRegistrationConstructorWithPropertyType START");

            var ani = new Animatable();
            Assert.IsNotNull(ani, "should be not null");
            Assert.IsInstanceOf<Animatable>(ani, "should be an instance of TypeRegistration!");

            var registered = new TypeRegistration((global::System.IntPtr)ani.SwigCPtr, false);
            Assert.IsNotNull(registered, "should be not null");
            Assert.IsInstanceOf<TypeRegistration>(registered, "should be an instance of TypeRegistration!");

            var testingTarget = new AnimatablePropertyRegistration(registered, "Animatable", 28000000, PropertyType.Boolean);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AnimatablePropertyRegistration>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            registered.Dispose();
            ani.Dispose();
            tlog.Debug(tag, $"AnimatablePropertyRegistrationConstructorWithPropertyType END (OK)");
        }

        [Test]
        [Description("AnimatablePropertyRegistration constructor with PropertyValue")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatablePropertyRegistrationConstructorWithPropertyValue()
        {
            tlog.Debug(tag, $"AnimatablePropertyRegistrationConstructorWithPropertyValue START");

            var ani = new Animatable();
            Assert.IsNotNull(ani, "should be not null");
            Assert.IsInstanceOf<Animatable>(ani, "should be an instance of TypeRegistration!");

            var registered = new TypeRegistration((global::System.IntPtr)ani.SwigCPtr, false);
            Assert.IsNotNull(registered, "should be not null");
            Assert.IsInstanceOf<TypeRegistration>(registered, "should be an instance of TypeRegistration!");

            var testingTarget = new AnimatablePropertyRegistration(registered, "Animatable", 28000000, new PropertyValue(1));
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AnimatablePropertyRegistration>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            registered.Dispose();
            ani.Dispose();
            tlog.Debug(tag, $"AnimatablePropertyRegistrationConstructorWithPropertyValue END (OK)");
        }
    }
}
