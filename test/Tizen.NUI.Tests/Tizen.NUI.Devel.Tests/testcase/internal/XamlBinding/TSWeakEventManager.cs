using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using static Tizen.NUI.BaseComponents.View;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/WeakEventManager")]
    public class InternalWeakEventManagerTest
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

        internal EventHandler<VisibilityChangedEventArgs> visibilityChangedEventHandler;
        internal EventHandler eventHandler;

        [Test]
        [Category("P1")]
        [Description("WeakEventManager AddEventHandler")]
        [Property("SPEC", "Tizen.NUI.Binding.WeakEventManager.AddEventHandler M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void AddEventHandler()
        {
            tlog.Debug(tag, $"AddEventHandler START");
            try
            {
                var testingTarget = new WeakEventManager();
                visibilityChangedEventHandler = (o, e) => { };
                Assert.IsNotNull(testingTarget, "Can't create success object WeakEventManager.");
                testingTarget.AddEventHandler<VisibilityChangedEventArgs>("visibilityChangedEventHandler", visibilityChangedEventHandler);

                eventHandler = (o, e) => { };
                testingTarget.AddEventHandler("eventHandler", eventHandler);
                testingTarget.RemoveEventHandler<VisibilityChangedEventArgs>("visibilityChangedEventHandler", visibilityChangedEventHandler);
                testingTarget.RemoveEventHandler("eventHandler", eventHandler);
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"AddEventHandler END");
        }

        [Test]
        [Category("P2")]
        [Description("WeakEventManager AddEventHandler")]
        [Property("SPEC", "Tizen.NUI.Binding.WeakEventManager.AddEventHandler M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void AddEventHandler2()
        {
            tlog.Debug(tag, $"AddEventHandler START");

            var testingTarget = new WeakEventManager();
            Assert.IsNotNull(testingTarget, "Can't create success object WeakEventManager.");
            visibilityChangedEventHandler = (o, e) => { };
            Assert.Throws<ArgumentNullException> (() => testingTarget.AddEventHandler<VisibilityChangedEventArgs>(null, visibilityChangedEventHandler));
            Assert.Throws<ArgumentNullException>(() => testingTarget.AddEventHandler<VisibilityChangedEventArgs>("visibilityChangedEventHandler", null));
            eventHandler = (o, e) => { };
            Assert.Throws<ArgumentNullException>(() => testingTarget.AddEventHandler(null, eventHandler));
            Assert.Throws<ArgumentNullException>(() => testingTarget.AddEventHandler("eventHandler", null));

            tlog.Debug(tag, $"AddEventHandler END");
        }

        [Test]
        [Category("P1")]
        [Description("WeakEventManager HandleEvent")]
        [Property("SPEC", "Tizen.NUI.Binding.WeakEventManager.HandleEvent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void HandleEvent()
        {
            tlog.Debug(tag, $"HandleEvent START");
            try
            {
                var testingTarget = new WeakEventManager();
                Assert.IsNotNull(testingTarget, "Can't create success object WeakEventManager.");
                visibilityChangedEventHandler = (o, e) => { };
                testingTarget.AddEventHandler<VisibilityChangedEventArgs>("visibilityChangedEventHandler", visibilityChangedEventHandler);
                eventHandler = (o, e) => { };
                testingTarget.AddEventHandler("eventHandler", eventHandler);
                testingTarget.HandleEvent(null, new EventArgs(), "eventHandler");
                testingTarget.HandleEvent(null, new VisibilityChangedEventArgs(), "visibilityChangedEventHandler");
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"HandleEvent END");
        }
    }
}
