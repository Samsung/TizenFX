using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/Property")]
    class PublicPropertyTest
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
        [Description("Property constructor")]
        [Property("SPEC", "Tizen.NUI.Property.Property C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyConstructor()
        {
            tlog.Debug(tag, $"PropertyConstructor START");

            var animatable  = new Animatable();
            Assert.IsNotNull(animatable, "Should be not null!");
            Assert.IsInstanceOf<Animatable>(animatable, "Should return PropertyValue instance.");

            var dummyIndex = 28000000;
            var testingTarget =  new Property(animatable, dummyIndex);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Property>(testingTarget, "Should return PropertyValue instance.");

            tlog.Debug(tag, "InvalidKey : " + Property.InvalidKey);
            tlog.Debug(tag, "InvalidComponentIndex : " + Property.InvalidComponentIndex);

            using (Animatable ani = new Animatable())
            {
                testingTarget.Object = ani;
                tlog.Debug(tag, "Object : " + testingTarget.Object);
            }

            testingTarget.Dispose();
            animatable.Dispose();
            tlog.Debug(tag, $"PropertyConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Property constructor. With property name")]
        [Property("SPEC", "Tizen.NUI.Property.Property C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyConstructorWithPropertyName()
        {
            tlog.Debug(tag, $"PropertyConstructorWithPropertyName START");

            var animatable = new Animatable();
            Assert.IsNotNull(animatable, "Should be not null!");
            Assert.IsInstanceOf<Animatable>(animatable, "Should return PropertyValue instance.");

            var testingTarget = new Property(animatable, "image");
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Property>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            animatable.Dispose();
            tlog.Debug(tag, $"PropertyConstructorWithPropertyName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Property propertyIndex. Get")]
        [Property("SPEC", "Tizen.NUI.Property.propertyIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyPropertyIndexGet()
        {
            tlog.Debug(tag, $"PropertyPropertyIndexGet START");

            var animatable = new Animatable();
            Assert.IsNotNull(animatable, "Should be not null!");
            Assert.IsInstanceOf<Animatable>(animatable, "Should return PropertyValue instance.");

            var testingTarget = new Property(animatable, 28000000);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Property>(testingTarget, "Should return PropertyValue instance.");

            var result = testingTarget.propertyIndex;
            Assert.IsTrue(28000000 == result);

            testingTarget.Dispose();
            animatable.Dispose();
            tlog.Debug(tag, $"PropertyPropertyIndexGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Property propertyIndex. Set")]
        [Property("SPEC", "Tizen.NUI.Property.propertyIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyPropertyIndexSet()
        {
            tlog.Debug(tag, $"PropertyPropertyIndexSet START");

            var animatable = new Animatable();
            Assert.IsNotNull(animatable, "Should be not null!");
            Assert.IsInstanceOf<Animatable>(animatable, "Should return PropertyValue instance.");

            var testingTarget = new Property(animatable, 28000000);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Property>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.propertyIndex = 29000000;
            var result = testingTarget.propertyIndex;
            Assert.IsTrue(29000000 == result);

            testingTarget.Dispose();
            animatable.Dispose();
            tlog.Debug(tag, $"PropertyPropertyIndexSet END (OK)");
        }
    }
}
