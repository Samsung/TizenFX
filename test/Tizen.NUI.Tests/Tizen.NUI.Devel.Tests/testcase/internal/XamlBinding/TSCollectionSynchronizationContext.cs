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
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/CollectionSynchronizationContext")]
    public class InternalCollectionSynchronizationContextTest
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
        [Description("CollectionSynchronizationContext constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.CollectionSynchronizationContext.CollectionSynchronizationContext C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void CollectionSynchronizationContextConstructor()
        {
            tlog.Debug(tag, $"CollectionSynchronizationContextConstructor START");

            var testingTarget = new CollectionSynchronizationContext(new View(), null);
            Assert.IsNotNull(testingTarget, "Can't create success object CollectionSynchronizationContext.");
            Assert.IsInstanceOf<CollectionSynchronizationContext>(testingTarget, "Should return CollectionSynchronizationContext instance.");

            Assert.IsNull(testingTarget.Callback, "Should be null");
            Assert.IsNotNull(testingTarget.ContextReference, "Should not be null");

            tlog.Debug(tag, $"CollectionSynchronizationContextConstructor END");
        }
    }
}
