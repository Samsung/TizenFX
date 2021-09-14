using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

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
        [Description("Trigger Trigger")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.Trigger C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TriggerConstructor()
        {
            tlog.Debug(tag, $"TriggerConstructor START");

            try
            {
                Trigger t2 = new Trigger(typeof(View));

                Assert.IsNotNull(t2, "null Trigger");
                Assert.IsInstanceOf<Trigger>(t2, "Should return Trigger instance.");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"TriggerConstructor END");
        }

        [Test]
        [Category("P2")]
        [Description("Trigger Trigger")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.Trigger C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TriggerConstructor2()
        {
            tlog.Debug(tag, $"TriggerConstructor2 START");

            Assert.Throws<ArgumentNullException>(() => new Trigger(null));

            tlog.Debug(tag, $"TriggerConstructor2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Trigger  BindableProperty")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.BindableProperty  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void BindablePropertyTest1()
        {
            tlog.Debug(tag, $"BindablePropertyTest1 START");
            try
            {
                Trigger t2 = new Trigger(typeof(ImageView));
                Assert.IsNotNull(t2, "null Trigger");
                t2.Property = ImageView.ResourceUrlProperty;
                Assert.AreEqual(ImageView.ResourceUrlProperty, t2.Property, "Should be equal");
                //<Setter Property="PositionX" Value="500" />
                t2.Value = "*Resource*/arrow.jpg";
                Assert.IsNotNull(t2.Value, "null Trigger value");

                Assert.AreEqual(0, t2.Setters.Count, "Should be equal");
                Assert.AreEqual(0, t2.EnterActions.Count, "Should be equal");
                Assert.AreEqual(0, t2.ExitActions.Count, "Should be equal");
                Type re = t2.TargetType;
                Assert.IsNotNull(re, "null Trigger value");
                Assert.AreEqual(false, t2.IsSealed, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"BindablePropertyTest1 END");
        }

    }
}