using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/RecyclerView/ItemSource/ListSource")]
    class ListSourceTest
    {
        private const string tag = "NUITEST";

        private class TestEnumerable : IEnumerable
        {
            private ArrayList mylist = new ArrayList();

            public TestEnumerable()
            {
                mylist.Add(1);
                mylist.Add(2);
                mylist.Add(3);
            }

            public IEnumerator GetEnumerator()
            {
                return mylist.GetEnumerator();
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
        [Description("ListSource constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceConstructor()
        {
            tlog.Debug(tag, $"ListSourceConstructor START");

            var testingTarget = new ListSource();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceConstructorWithEnumerableObject()
        {
            tlog.Debug(tag, $"ListSourceConstructorWithEnumerableObject START");

            IEnumerable<string> para = new List<string>();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceConstructorWithEnumerableObject END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceConstructorWithEnumerable()
        {
            tlog.Debug(tag, $"ListSourceConstructorWithEnumerable START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceConstructorWithEnumerable END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ListSource constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceConstructorWithEnumerableNull()
        {
            tlog.Debug(tag, $"ListSourceConstructorWithEnumerableNull START");

            var testingTarget = new ListSource((IEnumerable)null);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceConstructorWithEnumerableNull END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource Count.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.Count A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceCount()
        {
            tlog.Debug(tag, $"ListSourceCount START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.Count, 3, "Count of ListSouce should be equal to 3.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource HasHeader.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.HasHeader A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceHasHeader()
        {
            tlog.Debug(tag, $"ListSourceHasHeader START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasHeader = true;
            Assert.IsTrue(testingTarget.HasHeader, "ListSouce should have a header.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceHasHeader END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource HasFooter.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.HasFooter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceHasFooter()
        {
            tlog.Debug(tag, $"ListSourceHasFooter START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasFooter = true;
            Assert.IsTrue(testingTarget.HasFooter, "ListSouce should have a footer.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceHasFooter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource IsReadOnly.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.IsReadOnly A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceIsReadOnly()
        {
            tlog.Debug(tag, $"ListSourceIsReadOnly START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            tlog.Debug(tag, "IsReadOnly : " + testingTarget.IsReadOnly);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceIsReadOnly END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource IsFixedSize.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.IsFixedSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceIsFixedSize()
        {
            tlog.Debug(tag, $"ListSourceIsFixedSize START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            tlog.Debug(tag, "IsFixedSize : " + testingTarget.IsFixedSize);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceIsFixedSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource SyncRoot.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.SyncRoot A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceSyncRoot()
        {
            tlog.Debug(tag, $"ListSourceSyncRoot START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");
            Assert.IsNotNull(testingTarget.SyncRoot, "SyncRoot of ListSouce should not be null.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceSyncRoot END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource IsSynchronized.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.IsSynchronized A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceIsSynchronized()
        {
            tlog.Debug(tag, $"ListSourceIsSynchronized START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");
            
            tlog.Debug(tag, "IsSynchronized : " + testingTarget.IsSynchronized);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceIsSynchronized END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource IsFooter.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.IsFooter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceIsFooter()
        {
            tlog.Debug(tag, $"ListSourceIsFooter START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasFooter = true;
            tlog.Debug(tag, "IsFooter : " + testingTarget.IsFooter(2));

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceIsFooter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource IsHeader.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.IsHeader M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceIsHeader()
        {
            tlog.Debug(tag, $"ListSourceIsHeader START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasHeader = true;
            Assert.IsTrue(testingTarget.IsHeader(0), "The first item of ListSouce should be header.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceIsHeader END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource GetPosition.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.GetPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceGetPosition()
        {
            tlog.Debug(tag, $"ListSourceGetPosition START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.GetPosition(1), 0, "The index of the first item of ListSouce should be 0.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceGetPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource GetItem.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.GetItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceGetItem()
        {
            tlog.Debug(tag, $"ListSourceGetItem START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.GetItem(0), 1, "The value of the first item of ListSouce should be 1.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceGetItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource Add.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceAdd()
        {
            tlog.Debug(tag, $"ListSourceAdd START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            var ret = testingTarget.Add(4);
            Assert.AreEqual(ret, 3, "The index of ListSouce should is 3.");
            Assert.AreEqual(testingTarget.Count, 4, "The count of ListSouce should be 4.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceAdd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource Contains.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.Contains M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceContains()
        {
            tlog.Debug(tag, $"ListSourceContains START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            var ret = testingTarget.Contains(3);
            Assert.IsTrue(ret, "The ListSouce should contain 3.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceContains END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource Clear.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceClear()
        {
            tlog.Debug(tag, $"ListSourceClear START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Clear();
            Assert.AreEqual(testingTarget.Count, 0, "The ListSouce should be empty after cleared.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceClear END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource IndexOf.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.IndexOf M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceIndexOf()
        {
            tlog.Debug(tag, $"ListSourceIndexOf START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            var ret = testingTarget.IndexOf(1);
            Assert.AreEqual(ret, 0, "The index of ListSouce should be 0.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceIndexOf END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource Insert.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.Insert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceInsert()
        {
            tlog.Debug(tag, $"ListSourceInsert START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Insert(2, 4);
            Assert.AreEqual(testingTarget.Count, 4, "The count of ListSouce should be 4.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceInsert END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource Remove.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceRemove()
        {
            tlog.Debug(tag, $"ListSourceRemove START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Remove(3);
            Assert.AreEqual(testingTarget.Count, 2, "The count of ListSouce should be 2.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceRemove END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource RemoveAt.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.RemoveAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceRemoveAt()
        {
            tlog.Debug(tag, $"ListSourceRemoveAt START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.RemoveAt(2);
            Assert.AreEqual(testingTarget.Count, 2, "The count of ListSouce should be 2.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceRemoveAt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource CopyTo.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceCopyTo()
        {
            tlog.Debug(tag, $"ListSourceCopyTo START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            Array intArray = Array.CreateInstance(typeof(int), 10);
            intArray.SetValue(4, 0);
            testingTarget.CopyTo(intArray, 2);
            tlog.Debug(tag, "Count : " + testingTarget.Count);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceCopyTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ListSource GetEnumerator.")]
        [Property("SPEC", "Tizen.NUI.Components.ListSource.GetEnumerator M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ListSourceGetEnumerator()
        {
            tlog.Debug(tag, $"ListSourceGetEnumerator START");

            var para = new TestEnumerable();
            var testingTarget = new ListSource(para);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ListSource>(testingTarget, "should be an instance of testing target class!");

            var ret = testingTarget.GetEnumerator();
            Assert.IsNotNull(ret, "The Enumerator of ListSouce should not be null.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ListSourceGetEnumerator END (OK)");
        }
    }
}
