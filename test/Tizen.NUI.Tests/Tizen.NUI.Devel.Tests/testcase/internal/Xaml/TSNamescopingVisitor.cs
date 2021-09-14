using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/NamescopingVisitor")]
    public class InternalNamescopingVisitorTest
    {
        private const string tag = "NUITEST";
        private NamescopingVisitor visitor;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            visitor = new NamescopingVisitor(new HydrationContext());
        }

        [TearDown]
        public void Destroy()
        {
            visitor = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("NamescopingVisitor NamescopingVisitor")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.NamescopingVisitor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void NamescopingVisitorConstructor()
        {
            tlog.Debug(tag, $"NamescopingVisitorConstructor START");

            HydrationContext context = new HydrationContext();
            Assert.IsNotNull(context, "null HydrationContext");

            NamescopingVisitor namescoping = new NamescopingVisitor(context);
            Assert.IsNotNull(namescoping, "null NamescopingVisitor");

            tlog.Debug(tag, $"NamescopingVisitorConstructor END");
        }
        //[Test]
        //[Category("P1")]
        //[Description("NamescopingVisitor VisitingMode")]
        //[Property("SPEC", "Tizen.NUI.NamescopingVisitor.VisitingMode A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //public void NamescopingVisitorVisitingMode()
        //{
        //    tlog.Debug(tag, $"NamescopingVisitorVisitingMode START");

        //    try
        //    {
        //        Assert.IsNotNull(n1, "null NamescopingVisitor");
        //        TreeVisitingMode t1 = n1.VisitingMode;
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }
        //    tlog.Debug(tag, $"NamescopingVisitorVisitingMode END");

        //}

        //[Test]
        //[Category("P1")]
        //[Description("NamescopingVisitor StopOnDataTemplate")]
        //[Property("SPEC", "Tizen.NUI.NamescopingVisitor.StopOnDataTemplate A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //public void NamescopingVisitorStopOnDataTemplate()
        //{
        //    tlog.Debug(tag, $"NamescopingVisitorStopOnDataTemplate START");

        //    try
        //    {
        //        Assert.IsNotNull(n1, "null NamescopingVisitor");
        //        bool b1 = n1.StopOnDataTemplate;
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }
        //    tlog.Debug(tag, $"NamescopingVisitorStopOnDataTemplate END");

        //}

        //[Test]
        //[Category("P1")]
        //[Description("NamescopingVisitor StopOnResourceDictionary")]
        //[Property("SPEC", "Tizen.NUI.NamescopingVisitor.StopOnResourceDictionary A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //public void NamescopingVisitorStopOnResourceDictionary()
        //{
        //    tlog.Debug(tag, $"NamescopingVisitorStopOnResourceDictionary START");

        //    try
        //    {
        //        Assert.IsNotNull(n1, "null NamescopingVisitor");
        //        bool b1 = n1.StopOnResourceDictionary;
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }
        //    tlog.Debug(tag, $"NamescopingVisitorStopOnResourceDictionary END");

        //}

        //[Test]
        //[Category("P1")]
        //[Description("NamescopingVisitor VisitNodeOnDataTemplate")]
        //[Property("SPEC", "Tizen.NUI.NamescopingVisitor.VisitNodeOnDataTemplate A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //public void NamescopingVisitorVisitNodeOnDataTemplate()
        //{
        //    tlog.Debug(tag, $"NamescopingVisitorVisitNodeOnDataTemplate START");

        //    try
        //    {
        //        Assert.IsNotNull(n1, "null NamescopingVisitor");
        //        bool b1 = n1.VisitNodeOnDataTemplate;
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }
        //    tlog.Debug(tag, $"NamescopingVisitorVisitNodeOnDataTemplate END");

        //}
    }
}