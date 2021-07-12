using NUnit.Framework;
using System;
using System.Collections.Generic;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/HydrationContext")]
    internal class PublicHydrationContextTest
    {
        private const string tag = "NUITEST";
        private static HydrationContext h1;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            h1 = new HydrationContext();
        }

        [TearDown]
        public void Destroy()
        {
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
                Dictionary<INode, object> d1 = h1.Values;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"HydrationContextValues END (OK)");
            Assert.Pass("HydrationContextValues");
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
                Dictionary<IElementNode, Type> d1 = h1.Types;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"HydrationContextTypes END (OK)");
            Assert.Pass("HydrationContextTypes");
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
                HydrationContext hy1 = h1.ParentContext;
                h1.ParentContext = hy1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"HydrationContextParentContext END (OK)");
            Assert.Pass("HydrationContextParentContext");
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
                Action<Exception> a1 = h1.ExceptionHandler;
                h1.ExceptionHandler = a1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"HydrationContextExceptionHandler END (OK)");
            Assert.Pass("HydrationContextExceptionHandler");
        }
    }
}