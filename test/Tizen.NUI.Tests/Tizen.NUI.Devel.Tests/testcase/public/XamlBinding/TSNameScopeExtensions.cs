using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/NameScopeExtensions")]
    internal class PublicNameScopeExtensionsTest
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
        [Description("NameScopeExtensions  PushElement")]
        [Property("SPEC", "Tizen.NUI.Binding.NameScopeExtensions.PushElement M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void PushElementTest1()
        {
            tlog.Debug(tag, $"PushElementTest1 START");
            try
            {
                NameScopeExtensions.PushElement(new View());
                NameScopeExtensions.FindByNameInCurrentNameScope<View>("View1");
                NameScopeExtensions.PopElement();
                Assert.True(true, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"PushElementTest1 END");
        }

    }
}