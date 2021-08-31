using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ObjectRegistry")]
    public class InternalObjectRegistryTest
    {
        private const string tag = "NUITEST";
        private ObjectRegistry registry = null;

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
        [Description("ObjectRegistry constructor.")]
        [Property("SPEC", "Tizen.NUI.ObjectRegistry.ObjectRegistry C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectRegistryConstructor()
        {
            tlog.Debug(tag, $"ObjectRegistryConstructor START");

            var testingTarget = new ObjectRegistry();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ObjectRegistry>(testingTarget, "Should return ObjectRegistry instance.");

            tlog.Debug(tag, "getCPtr : " + ObjectRegistry.getCPtr(testingTarget));

            testingTarget.Dispose();
            tlog.Debug(tag, $"ObjectRegistryConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObjectRegistry ObjectCreatedEventArgs .")]
        [Property("SPEC", "Tizen.NUI.ObjectRegistry.ObjectCreatedEventArgs  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectRegistryObjectCreatedEventArgs()
        {
            tlog.Debug(tag, $"ObjectRegistryObjectCreatedEventArgs START");

            var testingTarget = new Tizen.NUI.ObjectRegistry.ObjectCreatedEventArgs();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.ObjectRegistry.ObjectCreatedEventArgs>(testingTarget, "Should return ObjectCreatedEventArgs instance.");

            using (View view = new View())
            {
                testingTarget.BaseHandle = view;
                tlog.Debug(tag, "BaseHandle : " + testingTarget.BaseHandle);
            }

            tlog.Debug(tag, $"ObjectRegistryObjectCreatedEventArgs END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObjectRegistry ObjectDestroyedEventArgs .")]
        [Property("SPEC", "Tizen.NUI.ObjectRegistry.ObjectDestroyedEventArgs  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectRegistryObjectDestroyedEventArgs()
        {
            tlog.Debug(tag, $"ObjectRegistryObjectDestroyedEventArgs START");

            var testingTarget = new Tizen.NUI.ObjectRegistry.ObjectDestroyedEventArgs();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.ObjectRegistry.ObjectDestroyedEventArgs>(testingTarget, "Should return ObjectDestroyedEventArgs instance.");

            using (View view = new View())
            {
                RefObject obj = RefObject.GetRefObjectFromPtr(view.SwigCPtr.Handle);
                testingTarget.RefObject = obj;
                tlog.Debug(tag, "RefObject : " + testingTarget.RefObject);
            }

            tlog.Debug(tag, $"ObjectRegistryObjectDestroyedEventArgs END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObjectRegistry ObjectRegistry .")]
        [Property("SPEC", "Tizen.NUI.ObjectRegistry.ObjectRegistry C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectRegistryObjectRegistry()
        {
            tlog.Debug(tag, $"ObjectRegistryObjectRegistry START");

            using (ObjectRegistry obj = new ObjectRegistry(new View().SwigCPtr.Handle, false))
            {
                var testingTarget = new ObjectRegistry(obj);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ObjectRegistry>(testingTarget, "Should return ObjectRegistry instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ObjectRegistryObjectRegistry END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObjectRegistry Assign .")]
        [Property("SPEC", "Tizen.NUI.ObjectRegistry.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectRegistryAssign()
        {
            tlog.Debug(tag, $"ObjectRegistryAssign START");

            using (ObjectRegistry obj = new ObjectRegistry(new View().SwigCPtr.Handle, false))
            {
                var testingTarget = obj.Assign(obj);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ObjectRegistry>(testingTarget, "Should return ObjectRegistry instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ObjectRegistryAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObjectRegistry ObjectCreatedSignal .")]
        [Property("SPEC", "Tizen.NUI.ObjectRegistry.ObjectCreatedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectRegistryObjectCreatedSignal()
        {
            tlog.Debug(tag, $"ObjectRegistryObjectCreatedSignal START");

            using (View view = new View())
            {
                var testingTarget = new ObjectRegistry(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ObjectRegistry>(testingTarget, "Should return ObjectRegistry instance.");

                var createdSignal = testingTarget.ObjectCreatedSignal();
                Assert.IsInstanceOf<ObjectCreatedSignal>(createdSignal, "Should return ObjectCreatedSignal instance.");

                var destroyedSignal = testingTarget.ObjectDestroyedSignal();
                Assert.IsInstanceOf<ObjectDestroyedSignal>(destroyedSignal, "Should return ObjectDestroyedSignal instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ObjectRegistryObjectCreatedSignal END (OK)");
        }
    }
}
