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
    }
}