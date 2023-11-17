using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/Trigger")]
    internal class PublicTriggerTest
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
        [Description("Trigger constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.Trigger C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TriggerConstructor()
        {
            tlog.Debug(tag, $"TriggerConstructor START");

            try
            {
#pragma warning disable Reflection // The code contains reflection
                var testingTarget = new Trigger(typeof(View));
#pragma warning restore Reflection // The code contains reflection
                Assert.IsNotNull(testingTarget, "null Trigger");
                Assert.IsInstanceOf<Trigger>(testingTarget, "Should return Trigger instance.");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"TriggerConstructor END");
        }

        [Test]
        [Category("P2")]
        [Description("Trigger constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.Trigger C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TriggerConstructorWithNull()
        {
            tlog.Debug(tag, $"TriggerConstructorWithNull START");

            Assert.Throws<ArgumentNullException>(() => new Trigger(null));

            tlog.Debug(tag, $"TriggerConstructorWithNull END");
        }

        [Test]
        [Category("P1")]
        [Description("Trigger BindableProperty")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.BindableProperty  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Obsolete]
        public void TriggerBindableProperty()
        {
            tlog.Debug(tag, $"TriggerBindableProperty START");

            try
            {
#pragma warning disable Reflection // The code contains reflection
                var testingTarget = new Trigger(typeof(ImageView));
#pragma warning restore Reflection // The code contains reflection
                Assert.IsNotNull(testingTarget, "null Trigger");

                testingTarget.Property = ImageView.ResourceUrlProperty;
                Assert.AreEqual(ImageView.ResourceUrlProperty, testingTarget.Property, "Should be equal");
                
                testingTarget.Value = "*Resource*/arrow.jpg";
                Assert.IsNotNull(testingTarget.Value, "null Trigger value");

                Assert.AreEqual(0, testingTarget.Setters.Count, "Should be equal");
                Assert.AreEqual(0, testingTarget.EnterActions.Count, "Should be equal");
                Assert.AreEqual(0, testingTarget.ExitActions.Count, "Should be equal");

                var result = testingTarget.TargetType;
                Assert.IsNotNull(result, "null Trigger value");

                Assert.AreEqual(false, testingTarget.IsSealed, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TriggerBindableProperty END");
        }

    }
}