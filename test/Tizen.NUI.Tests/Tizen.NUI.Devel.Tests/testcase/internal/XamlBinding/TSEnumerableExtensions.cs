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
    [Description("internal/XamlBinding/EnumerableExtensions")]
    public class InternalEnumerableExtensionsTest
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
        [Description("EnumerableExtensions GetGesturesFor")]
        [Property("SPEC", "Tizen.NUI.Binding.EnumerableExtensions.GetGesturesFor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GetGesturesFor()
        {
            tlog.Debug(tag, $"GetGesturesFor START");
            try
            {

                var list = new List<GestureRecognizer>() { new GestureRecognizer() };
                var ret = EnumerableExtensions.GetGesturesFor<GestureRecognizer>(list, (g) => false);
                Assert.IsNotNull(ret, "should not be null");
                var ret2 = EnumerableExtensions.GetGesturesFor<GestureRecognizer>(null, (g) => false);
                Assert.IsNotNull(ret2, "should not be null");
                var ret3 = EnumerableExtensions.GetGesturesFor<GestureRecognizer>(null, (g) => false);
                Assert.IsNotNull(ret3, "should not be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            tlog.Debug(tag, $"GetGesturesFor END");
        }

        [Test]
        [Category("P1")]
        [Description("EnumerableExtensions Append")]
        [Property("SPEC", "Tizen.NUI.Binding.EnumerableExtensions.Append M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Append()
        {
            tlog.Debug(tag, $"Append START");
            try
            {

                var list = new List<GestureRecognizer>() { new GestureRecognizer() };
                var ret = EnumerableExtensions.Append<GestureRecognizer>(list, new GestureRecognizer());
                Assert.IsNotNull(ret, "should not be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            tlog.Debug(tag, $"Append END");
        }

        [Test]
        [Category("P1")]
        [Description("EnumerableExtensions ForEach")]
        [Property("SPEC", "Tizen.NUI.Binding.EnumerableExtensions.ForEach M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ForEach()
        {
            tlog.Debug(tag, $"ForEach START");
            try
            {
                var list = new List<GestureRecognizer>() { new GestureRecognizer() };
                Action<GestureRecognizer> action = (g) => { };
                EnumerableExtensions.ForEach<GestureRecognizer>(list, action);
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            tlog.Debug(tag, $"ForEach END");
        }

        [Test]
        [Category("P2")]
        [Description("EnumerableExtensions IndexOf")]
        [Property("SPEC", "Tizen.NUI.Binding.EnumerableExtensions.IndexOf M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void IndexOf()
        {
            tlog.Debug(tag, $"IndexOf START");

            Assert.Throws<ArgumentNullException>(() => EnumerableExtensions.IndexOf<GestureRecognizer>(null, new GestureRecognizer()));
 
            tlog.Debug(tag, $"IndexOf END");
        }

        [Test]
        [Category("P1")]
        [Description("EnumerableExtensions IndexOf")]
        [Property("SPEC", "Tizen.NUI.Binding.EnumerableExtensions.IndexOf M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void IndexOf2()
        {
            tlog.Debug(tag, $"IndexOf2 START");
            try
            {
                var list = new List<GestureRecognizer>() { new GestureRecognizer() };
                EnumerableExtensions.IndexOf<GestureRecognizer>(list, new GestureRecognizer());

                EnumerableExtensions.IndexOf<GestureRecognizer>(list, (g) => true);
                EnumerableExtensions.IndexOf<GestureRecognizer>(list, (g) => false);
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            tlog.Debug(tag, $"IndexOf2 END");
        }

        [Test]
        [Category("P1")]
        [Description("EnumerableExtensions Prepend")]
        [Property("SPEC", "Tizen.NUI.Binding.EnumerableExtensions.Prepend M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Prepend()
        {
            tlog.Debug(tag, $"Prepend START");
            try
            {
                var list = new List<GestureRecognizer>() { new GestureRecognizer() };
                EnumerableExtensions.Prepend<GestureRecognizer>(list, new GestureRecognizer());
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            tlog.Debug(tag, $"Prepend END");
        }
    }
}
