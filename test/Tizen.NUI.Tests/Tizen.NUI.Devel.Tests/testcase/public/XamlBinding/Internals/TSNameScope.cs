using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/Internals/NameScope")]
    internal class PublicNameScopeTest
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
        [Category("P2")]
        [Description("NameScope SetNameScope ")]
        [Property("SPEC", "Tizen.NUI.Binding.Internals.NameScope.SetNameScope  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SetNameScopeTest()
        {
            tlog.Debug(tag, $"SetNameScopeTest START");
            Assert.Throws<ArgumentNullException>(() => NameScope.SetNameScope(null, null));
            tlog.Debug(tag, $"SetNameScopeTest END");
        }
    }
}