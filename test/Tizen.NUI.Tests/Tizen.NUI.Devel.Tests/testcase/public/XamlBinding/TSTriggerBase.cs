using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using static Tizen.NUI.Binding.TriggerBase;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/TriggerBase")]
    internal class PublicSealedListTest
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
        [Description("SealedList SealedList")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.SealedList<T>.SealedList C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TriggerConstructor()
        {
            tlog.Debug(tag, $"TriggerConstructor START");

            try
            {
                var sl = new SealedList<int>();

                Assert.IsNotNull(sl, "null SealedList");
                Assert.IsInstanceOf<SealedList<int>>(sl, "Should return SealedList instance.");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"TriggerConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("SealedList Add")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.SealedList.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SealedListAddTest()
        {
            tlog.Debug(tag, $"SealedListAddTest START");
            try
            {
                var sl = new SealedList<int>();
                Assert.IsNotNull(sl, "null SealedList");
                sl.Add(1);
            }
            catch(Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"SealedListAddTest END");
        }

        [Test]
        [Category("P2")]
        [Description("SealedList Add")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.SealedList.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SealedListAddTest2()
        {
            tlog.Debug(tag, $"SealedListAddTest2 START");
            var sl = new SealedList<int>();

            Assert.IsNotNull(sl, "null SealedList");
            sl.IsReadOnly = true;
            Assert.Throws<InvalidOperationException>(() => sl.Add(1));

            tlog.Debug(tag, $"SealedListAddTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("SealedList Add")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.SealedList.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SealedListClearTest()
        {
            tlog.Debug(tag, $"SealedListAddTest START");
            try
            {
                var sl = new SealedList<int>();
                Assert.IsNotNull(sl, "null SealedList");
                sl.Clear();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"SealedListAddTest END");
        }

        [Test]
        [Category("P2")]
        [Description("SealedList Clear")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.SealedList.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SealedListClearTest2()
        {
            tlog.Debug(tag, $"SealedListClearTest2 START");
            var sl = new SealedList<int>();
            Assert.IsNotNull(sl, "null SealedList");
            sl.IsReadOnly = true;
            Assert.Throws<InvalidOperationException>(() => sl.Clear());
            tlog.Debug(tag, $"SealedListClearTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("SealedList Contains")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.SealedList.Contains M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void SealedListContainsTest()
        {
            tlog.Debug(tag, $"SealedListContainsTest START");
            try
            {
                var sl = new SealedList<int>();
                Assert.IsNotNull(sl, "null SealedList");
                sl.Add(1);
                var ret = sl.Contains(1);
                Assert.AreEqual(true, ret, "Should be equal");

                int[] ia= new int[] { 1, 2, 3 };
                sl.CopyTo(ia, 0);

                var ret2 = sl.GetEnumerator();
                var ret3 = sl.IndexOf(1);
                sl.Insert(0, 2);
                var ret4 = sl[1];
                sl.Remove(1);

                sl.Insert(0, 3);
                sl.RemoveAt(0);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"SealedListContainsTest END");
        }

        [Test]
        [Category("P2")]
        [Description("SealedList IsFixedSize")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.SealedList.IsFixedSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void SealedListIsFixedSizeTest()
        {
            tlog.Debug(tag, $"SealedListIsFixedSizeTest START");
            var sl = new SealedList<int>();
            Assert.IsNotNull(sl, "null SealedList");
            bool bl;
            Assert.Throws<NotImplementedException>(() => bl = sl.IsFixedSize);
            tlog.Debug(tag, $"SealedListIsFixedSizeTest END");
        }

        [Test]
        [Category("P2")]
        [Description("SealedList IsSynchronized")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.SealedList.IsSynchronized A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void SealedListIsSynchronizedTest()
        {
            tlog.Debug(tag, $"SealedListIsSynchronizedTest START");
            var sl = new SealedList<int>();
            Assert.IsNotNull(sl, "null SealedList");
            bool bl;
            Assert.Throws<NotImplementedException>(() => bl = sl.IsSynchronized);
            tlog.Debug(tag, $"SealedListIsSynchronizedTest END");
        }

        [Test]
        [Category("P2")]
        [Description("SealedList SyncRoot")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.SealedList.SyncRoot  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void SealedListSyncRootTest()
        {
            tlog.Debug(tag, $"SealedListSyncRootTest START");
            var sl = new SealedList<int>();
            Assert.IsNotNull(sl, "null SealedList");
            object bl;
            Assert.Throws<NotImplementedException>(() => bl = sl.SyncRoot);
            tlog.Debug(tag, $"SealedListSyncRootTest END");
        }

        [Test]
        [Category("P2")]
        [Description("SealedList RemoveAt")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.SealedList.RemoveAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void SealedListRemoveAtTest()
        {
            tlog.Debug(tag, $"SealedListRemoveAtTest START");

            var sl = new SealedList<int>();
            Assert.IsNotNull(sl, "null SealedList");
            sl.Add(1);
            sl.IsReadOnly = true;
            Assert.Throws<InvalidOperationException>(() => sl.RemoveAt(0));

            tlog.Debug(tag, $"SealedListRemoveAtTest END");
        }

        [Test]
        [Category("P2")]
        [Description("SealedList this[]")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.SealedList.this[] M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void SealedListThisTest()
        {
            tlog.Debug(tag, $"SealedListThisTest START");

            var sl = new SealedList<int>();
            Assert.IsNotNull(sl, "null SealedList");
            sl.Add(1);
            sl.IsReadOnly = true;
            var i = sl[0];
            Assert.Throws<InvalidOperationException>(() => sl[0] = 2);

            tlog.Debug(tag, $"SealedListThisTest END");
        }

        [Test]
        [Category("P2")]
        [Description("SealedList Insert")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.SealedList.Insert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SealedListInsertTest()
        {
            tlog.Debug(tag, $"SealedListInsertTest START");

            var sl = new SealedList<int>();
            Assert.IsNotNull(sl, "null SealedList");
            sl.Add(1);
            sl.IsReadOnly = true;
            int i;
            Assert.Throws<InvalidOperationException>(() => sl.Insert(0, 2));
            tlog.Debug(tag, $"SealedListInsertTest END");
        }

        [Test]
        [Category("P2")]
        [Description("SealedList Remove")]
        [Property("SPEC", "Tizen.NUI.Binding.Trigger.SealedList.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SealedListRemoveTest()
        {
            tlog.Debug(tag, $"SealedListRemoveTest START");

            var sl = new SealedList<int>();
            Assert.IsNotNull(sl, "null SealedList");
            sl.Add(1);
            sl.IsReadOnly = true;
            int i;
            Assert.Throws<InvalidOperationException>(() => sl.Remove(1));
            tlog.Debug(tag, $"SealedListRemoveTest END");
        }
    }
}