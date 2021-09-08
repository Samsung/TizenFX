using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/FillResourceDictionariesVisitor")]
    public class InternalFillResourceDictionariesVisitorTest
    {
        private const string tag = "NUITEST";
        private FillResourceDictionariesVisitor visitor;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            visitor = new FillResourceDictionariesVisitor(new HydrationContext());
        }

        [TearDown]
        public void Destroy()
        {
            visitor = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("FillResourceDictionariesVisitor VisitingMode")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.VisitingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void FillResourceDictionariesVisitorVisitingMode()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorVisitingMode START");

            try
            {
                var result = visitor.VisitingMode;
                tlog.Debug(tag, "VisitingMode : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"FillResourceDictionariesVisitorVisitingMode END");
        }

        [Test]
        [Category("P1")]
        [Description("FillResourceDictionariesVisitor StopOnDataTemplate")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.StopOnDataTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void FillResourceDictionariesVisitorStopOnDataTemplate()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorStopOnDataTemplate START");

            try
            {
                var result = visitor.StopOnDataTemplate;
                tlog.Debug(tag, "StopOnDataTemplate : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"FillResourceDictionariesVisitorStopOnDataTemplate END");
        }

        [Test]
        [Category("P1")]
        [Description("FillResourceDictionariesVisitor StopOnResourceDictionary")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.StopOnResourceDictionary A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void FillResourceDictionariesVisitorStopOnResourceDictionary()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorStopOnResourceDictionary START");

            try
            {
                var result = visitor.StopOnResourceDictionary;
                tlog.Debug(tag, "StopOnResourceDictionary : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"FillResourceDictionariesVisitorStopOnResourceDictionary END");
        }

        [Test]
        [Category("P1")]
        [Description("FillResourceDictionariesVisitor VisitNodeOnDataTemplate")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.VisitNodeOnDataTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void FillResourceDictionariesVisitorVisitNodeOnDataTemplate()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorVisitNodeOnDataTemplate START");

            try
            {
                var result = visitor.VisitNodeOnDataTemplate;
                tlog.Debug(tag, "VisitNodeOnDataTemplate : " + result);

            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            tlog.Debug(tag, $"FillResourceDictionariesVisitorVisitNodeOnDataTemplate END");

        }
    }
}