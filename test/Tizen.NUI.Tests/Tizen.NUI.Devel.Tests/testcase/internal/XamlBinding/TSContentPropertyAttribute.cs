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
    [Description("internal/XamlBinding/ContentPropertyAttribute")]
    public class InternalContentPropertyAttributeTest
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
        [Description("ContentPropertyAttribute constructor")]
        [Property("SPEC", "ContentPropertyAttribute constructor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ContentPropertyAttributeConstructor()
        {
            tlog.Debug(tag, $"ContentPropertyAttributeConstructor START");

            var testingTarget = new ContentPropertyAttribute("content");
            tlog.Debug(tag, "Name : " + testingTarget.Name);

            tlog.Debug(tag, $"ContentPropertyAttributeConstructor END");
        }
    }
}
