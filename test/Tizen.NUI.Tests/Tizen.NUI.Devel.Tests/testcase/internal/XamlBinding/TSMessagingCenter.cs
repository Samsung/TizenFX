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
    [Description("internal/XamlBinding/MessagingCenter")]
    public class InternalMessagingCenterTest
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
        [Description("MessagingCenter Instance")]
        [Property("SPEC", "MessagingCenter Instance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void MessagingCenterInstance()
        {
            tlog.Debug(tag, $"MessagingCenterInstance START");

            var testingTarget = MessagingCenter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object IMessagingCenter.");
            Assert.IsInstanceOf<IMessagingCenter>(testingTarget, "Should return IMessagingCenter instance.");

            tlog.Debug(tag, $"MessagingCenterInstance END");
        }

        [Test]
        [Category("P1")]
        [Description("MessagingCenter ClearSubscribers")]
        [Property("SPEC", "MessagingCenter ClearSubscribers M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void MessagingCenterClearSubscribers()
        {
            tlog.Debug(tag, $"ClearSubscribers START");

            try
            {
                MessagingCenter.ClearSubscribers();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ClearSubscribers END");
        }
    }
}
