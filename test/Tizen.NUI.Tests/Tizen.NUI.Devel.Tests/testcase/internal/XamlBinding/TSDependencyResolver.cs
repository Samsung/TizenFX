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
    [Description("internal/XamlBinding/DependencyResolver")]
    public class InternalDependencyResolverTest
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
        [Description("DependencyResolver ResolveUsing")]
        [Property("SPEC", "Tizen.NUI.Binding.DependencyResolver.ResolveUsing M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ResolveUsing()
        {
            tlog.Debug(tag, $"ResolveUsing START");
            try
            {
                DependencyResolver.ResolveUsing((t, b) => null);
                DependencyResolver.ResolveUsing((t) => null);
            }
            catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            tlog.Debug(tag, $"ResolveUsing END");
        }
    }
}
