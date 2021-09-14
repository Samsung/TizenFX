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
        [Description("FillResourceDictionariesVisitor FillResourceDictionariesVisitor")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.FillResourceDictionariesVisitor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void FillResourceDictionariesVisitorConstructor()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorConstructor START");

            HydrationContext context = new HydrationContext();
            Assert.IsNotNull(context, "null HydrationContext");

            FillResourceDictionariesVisitor fillResourceDictionariesVisitor = new FillResourceDictionariesVisitor(context);
            Assert.IsNotNull(fillResourceDictionariesVisitor, "null FillResourceDictionariesVisitor");
            Assert.IsInstanceOf<FillResourceDictionariesVisitor>(fillResourceDictionariesVisitor, "Should return FillResourceDictionariesVisitor instance.");

            tlog.Debug(tag, $"FillResourceDictionariesVisitorConstructor END");
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

        public class IXmlNamespaceResolverImplement : IXmlNamespaceResolver
        {
            public IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope)
            {
                throw new NotImplementedException();
            }

            public string LookupNamespace(string prefix)
            {
                throw new NotImplementedException();
            }

            public string LookupPrefix(string namespaceName)
            {
                throw new NotImplementedException();
            }
        }

        //[Test]
        //[Category("P1")]
        //[Description("FillResourceDictionariesVisitor IsResourceDictionary")]
        //[Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.IsResourceDictionary M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void FillResourceDictionariesVisitorIsResourceDictionary()
        //{
        //    tlog.Debug(tag, $"FillResourceDictionariesVisitorVisitNodeOnDataTemplate START");

        //    try
        //    {
        //        IList<XmlType> list = null;
        //        XmlType xmlType = new XmlType("myNameSpace", "myName", list);
        //        Assert.IsNotNull(xmlType, "null XmlType");
        //        IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
        //        Assert.IsNotNull(i1, "null IXmlNamespaceResolverImplement");
        //        ElementNode n1 = new ElementNode(xmlType, "myNameSpace", i1);
        //        Assert.IsNotNull(n1, "null ElementNode");
        //        bool b1 = f1.IsResourceDictionary(n1);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }
        //    tlog.Debug(tag, $"FillResourceDictionariesVisitorVisitNodeOnDataTemplate END");
        //}

    }
}