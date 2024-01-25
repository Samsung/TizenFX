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
    [Description("internal/XamlBinding/AlertArguments")]
    public class InternalAlertArgumentsTest
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
        [Description("AlertArguments constructor")]
        [Property("SPEC", "Tizen.NUI.AlertArguments.AlertArguments C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void AlertArgumentsConstructor()
        {
            tlog.Debug(tag, $"AlertArgumentsConstructor START");

            var testingTarget = new AlertArguments("AlertArguments", "AlertArguments", "ACCEPT", "CANCEL");
            Assert.IsNotNull(testingTarget, "Can't create success object AlertArguments.");
            Assert.IsInstanceOf<AlertArguments>(testingTarget, "Should return AlertArguments instance.");

            tlog.Debug(tag, "Accept  : " + testingTarget.Accept);
            tlog.Debug(tag, "Cancel  : " + testingTarget.Cancel);
            tlog.Debug(tag, "Message   : " + testingTarget.Message);
            tlog.Debug(tag, "Result  : " + testingTarget.Result);
            tlog.Debug(tag, "Title   : " + testingTarget.Title);

            try
            {
                testingTarget.SetResult(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"AlertArgumentsConstructor END");
        }
    }
}
