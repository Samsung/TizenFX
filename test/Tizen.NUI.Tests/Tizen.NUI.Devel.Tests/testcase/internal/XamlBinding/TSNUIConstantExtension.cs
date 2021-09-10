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
    [Description("internal/XamlBinding/NUIConstantExtension")]
    public class InternalNUIConstantExtensionTest
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
        [Description("NUIConstantExtension.VisualExtension KeyDictionary")]
        [Property("SPEC", "Tizen.NUI.NUIConstantExtension.VisualExtension.KeyDictionary M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void NUIConstantExtensionKeyDictionary()
        {
            tlog.Debug(tag, $"NUIConstantExtensionKeyDictionary START");

            var result = VisualExtension.KeyDictionary;
            tlog.Debug(tag, "KeyDictionary : " + result);

            tlog.Debug(tag, $"NUIConstantExtensionKeyDictionary END");
        }
    }
}
