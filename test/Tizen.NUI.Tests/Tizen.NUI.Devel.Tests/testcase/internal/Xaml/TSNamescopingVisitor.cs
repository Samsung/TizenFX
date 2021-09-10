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
    }
}