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
    [Description("internal/XamlBinding/TrackableCollection")]
    public class InternalTrackableCollectionTest
    {
        private const string tag = "NUITEST";

        internal class MyTrackableCollection<T> : TrackableCollection<T>
        {
            public void Clear()
            {
                ClearItems();
            }
        }

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
        [Description("TrackableCollection ClearItems")]
        [Property("SPEC", "Tizen.NUI.Binding.TrackableCollection.ClearItems M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ClearItems()
        {
            tlog.Debug(tag, $"ClearItems START");
            try
            {
                var testingTarget = new MyTrackableCollection<int>();
                Assert.IsNotNull(testingTarget, "Can't create success object TrackableCollection.");
                testingTarget.Clear();
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"ClearItems END");
        }
    }
}
