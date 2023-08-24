using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/ApplyPropertiesVisitor")]
    public class InternalApplyPropertiesVisitorTest
    {
        private const string tag = "NUITEST";
        private ApplyPropertiesVisitor visitor;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            visitor = new ApplyPropertiesVisitor(new HydrationContext(), false);
        }

        [TearDown]
        public void Destroy()
        {
            visitor = null;
            tlog.Info(tag, "Destroy() is called!");
        }
    }
}