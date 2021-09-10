using NUnit.Framework;
using System;
using System.Collections.Generic;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/HydrationContext")]
    public class InternalHydrationContextTest
    {
        private const string tag = "NUITEST";
        private HydrationContext context;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            context = new HydrationContext();
        }

        [TearDown]
        public void Destroy()
        {
            context = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("HydrationContext Values")]
        [Property("SPEC", "Tizen.NUI.HydrationContext.Values A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void HydrationContextValues()
        {
            tlog.Debug(tag, $"HydrationContextValues START");

            try
            {
                var dic = context.Values;
                Assert.AreEqual(0, dic.Count, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"HydrationContextValues END");
        }

        [Test]
        [Category("P1")]
        [Description("HydrationContext Types")]
        [Property("SPEC", "Tizen.NUI.HydrationContext.Types A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void HydrationContextTypes()
        {
            tlog.Debug(tag, $"HydrationContextTypes START");

            try
            {
                var dic = context.Types;
                Assert.AreEqual(0, dic.Count, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"HydrationContextTypes END");
        }

        [Test]
        [Category("P1")]
        [Description("HydrationContext ParentContext")]
        [Property("SPEC", "Tizen.NUI.HydrationContext.ParentContext A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void HydrationContextParentContext()
        {
            tlog.Debug(tag, $"HydrationContextParentContext START");

            try
            {
                var testingTarget = context.ParentContext;
                context.ParentContext = testingTarget;
                Assert.AreEqual(testingTarget, context.ParentContext, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"HydrationContextParentContext END");
        }

        [Test]
        [Category("P1")]
        [Description("HydrationContext ExceptionHandler")]
        [Property("SPEC", "Tizen.NUI.HydrationContext.ExceptionHandler A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void HydrationContextExceptionHandler()
        {
            tlog.Debug(tag, $"HydrationContextExceptionHandler START");

            try
            {
                var action = context.ExceptionHandler;
                context.ExceptionHandler = action;
                Assert.AreEqual(action, context.ExceptionHandler, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"HydrationContextExceptionHandler END");
        }
    }
}