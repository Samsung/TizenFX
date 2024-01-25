using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/SynchronizedList")]
    internal class InternalSynchronizedListTest
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
        [Description("SynchronizedList SynchronizedList")]
        [Property("SPEC", "Tizen.NUI.Binding.SynchronizedList<T>.SynchronizedList<T> C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TriggerConstructor()
        {
            tlog.Debug(tag, $"TriggerConstructor START");

            try
            {
                var sl = new SynchronizedList<int>();

                Assert.IsNotNull(sl, "null SynchronizedList");
                Assert.IsInstanceOf<SynchronizedList<int>>(sl, "Should return SynchronizedList instance.");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"TriggerConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("SynchronizedList Add")]
        [Property("SPEC", "Tizen.NUI.Binding.SynchronizedList.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SynchronizedListAddTest()
        {
            tlog.Debug(tag, $"SynchronizedListAddTest START");
            try
            {
                var sl = new SynchronizedList<int>();
                Assert.IsNotNull(sl, "null SynchronizedList");
                sl.Add(1);
            }
            catch(Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"SynchronizedListAddTest END");
        }

        [Test]
        [Category("P1")]
        [Description("SynchronizedList Add")]
        [Property("SPEC", "Tizen.NUI.Binding.SynchronizedList.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SynchronizedListClearTest()
        {
            tlog.Debug(tag, $"SynchronizedListAddTest START");
            try
            {
                var sl = new SynchronizedList<int>();
                Assert.IsNotNull(sl, "null SynchronizedList");
                sl.Add(1);
                sl.Clear();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"SynchronizedListAddTest END");
        }

        [Test]
        [Category("P1")]
        [Description("SynchronizedList Contains")]
        [Property("SPEC", "Tizen.NUI.Binding.SynchronizedList.Contains M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void SynchronizedListContainsTest()
        {
            tlog.Debug(tag, $"SynchronizedListContainsTest START");
            try
            {
                var sl = new SynchronizedList<int>();
                Assert.IsNotNull(sl, "null SynchronizedList");
                sl.Add(1);
                var ret = sl.Contains(1);
                Assert.AreEqual(true, ret, "Should be equal");
                Assert.AreEqual(1, sl.Count, "Should be equal");

                int[] ia= new int[] { 1, 2, 3 };
                sl.CopyTo(ia, 0);

                var ret2 = sl.GetEnumerator();
                Assert.IsNotNull(ret2, "null SynchronizedList");
                var ret3 = sl.IndexOf(1);
                sl.Insert(0, 2);
                var ret4 = sl[1];
                sl[1] = 7;
                sl.Remove(1);

                sl.Insert(0, 3);
                sl.RemoveAt(0);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"SynchronizedListContainsTest END");
        }
    }
}