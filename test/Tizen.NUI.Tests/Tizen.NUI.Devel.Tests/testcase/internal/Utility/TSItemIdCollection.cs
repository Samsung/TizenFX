using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests 
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/ItemIdCollection")]
    public class InternalItemIdCollectionTest
    {
        private const string tag = "NUITEST";

        internal class MyItemIdCollection : ItemIdCollection
        {
            public MyItemIdCollection() : base()
            { }
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
        [Description("ItemIdCollection constructor.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.ItemIdCollection C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionConstructor()
        {
            tlog.Debug(tag, $"ItemIdCollectionConstructor START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            Assert.IsFalse(testingTarget.IsFixedSize);
            Assert.IsFalse(testingTarget.IsReadOnly);
            Assert.IsFalse(testingTarget.IsSynchronized);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemIdCollectionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection constructor. With ItemIdCollection.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.ItemIdCollection C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionConstructorWithItemIdCollection()
        {
            tlog.Debug(tag, $"ItemIdCollectionConstructorWithItemIdCollection START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var itemIdCollection = new ItemIdCollection(c);
            Assert.IsNotNull(itemIdCollection, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(itemIdCollection, "Should be an Instance of ItemIdCollection!");

            var testingTarget = new ItemIdCollection(itemIdCollection);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            itemIdCollection.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemIdCollectionConstructorWithItemIdCollection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection constructor. With capacity.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.ItemIdCollection C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionConstructorWithCapacity()
        {
            tlog.Debug(tag, $"ItemIdCollectionConstructorWithCapacity START");

            var testingTarget = new ItemIdCollection(5);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemIdCollectionConstructorWithCapacity END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ItemIdCollection constructor. Null ICollection.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.ItemIdCollection C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionConstructorWithNullICollection()
        {
            tlog.Debug(tag, $"ItemIdCollectionConstructorWithNullICollection START");

            global::System.Collections.ICollection c = null;

            try
            {
                new ItemIdCollection(c);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ItemIdCollectionConstructorWithNullICollection END (OK)");
                Assert.Pass("Caught ArgumentNullException : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection getCPtr.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectiongetCPtr()
        {
            tlog.Debug(tag, $"ItemIdCollectiongetCPtr START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            try
            {
                ItemIdCollection.getCPtr(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemIdCollectiongetCPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection this.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.this A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionThis()
        {
            tlog.Debug(tag, $"ItemIdCollectionThis START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            tlog.Debug(tag, testingTarget[1].ToString());

            testingTarget[2] = 5;
            tlog.Debug(tag, testingTarget[2].ToString());

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemIdCollectionThis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection Capacity.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.Capacity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionCapacity()
        {
            tlog.Debug(tag, $"ItemIdCollectionCapacity START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            tlog.Debug(tag, "Capacity : " + testingTarget.Capacity.ToString());

            testingTarget.Capacity = 5;
            tlog.Debug(tag, "Capacity : " + testingTarget.Capacity.ToString());

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemIdCollectionCapacity END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ItemIdCollection Capacity. Set value < size.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.Capacity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionCapacitySetValueLessThanSize()
        {
            tlog.Debug(tag, $"ItemIdCollectionCapacitySetValueLessThanSize START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            tlog.Debug(tag, "Count : " + testingTarget.Count);
            tlog.Debug(tag, "Capacity : " + testingTarget.Capacity.ToString());

            try
            {
                testingTarget.Capacity = 3;
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"ItemIdCollectionCapacitySetValueLessThanSize END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection CopyTo.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionCopyTo()
        {
            tlog.Debug(tag, $"ItemIdCollectionCopyTo START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            uint[] array = new uint[4];

            try
            {
                testingTarget.CopyTo(array);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ItemIdCollectionCopyTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection CopyTo. With arrayIndex.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionCopyToWithArrayIndex()
        {
            tlog.Debug(tag, $"ItemIdCollectionCopyToWithArrayIndex START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            uint[] array = new uint[4];

            try
            {
                testingTarget.CopyTo(array, 0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ItemIdCollectionCopyToWithArrayIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection CopyTo. With null array.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionCopyToWithNullArray()
        {
            tlog.Debug(tag, $"ItemIdCollectionCopyToWithNullArray START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            try
            {
                testingTarget.CopyTo(null);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"ItemIdCollectionCopyToWithNullArray END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection CopyTo. index < 0.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionCopyToWithIndexLessThan0()
        {
            tlog.Debug(tag, $"ItemIdCollectionCopyToWithIndexLessThan0 START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            try
            {
                uint[] array = new uint[4];
                testingTarget.CopyTo(-1, array, 0, testingTarget.Count);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"ItemIdCollectionCopyToWithIndexLessThan0 END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection CopyTo. arrayIndex < 0.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionCopyToWithArrayIndexLessThan0()
        {
            tlog.Debug(tag, $"ItemIdCollectionCopyToWithArrayIndexLessThan0 START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            try
            {
                uint[] array = new uint[4];
                testingTarget.CopyTo(0, array, -1, testingTarget.Count);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"ItemIdCollectionCopyToWithArrayIndexLessThan0 END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection CopyTo. count < 0.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionCopyToWithCountLessThan0()
        {
            tlog.Debug(tag, $"ItemIdCollectionCopyToWithCountLessThan0 START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            try
            {
                uint[] array = new uint[4];
                testingTarget.CopyTo(0, array, 0, -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"ItemIdCollectionCopyToWithCountLessThan0 END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection GetEnumerator.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.GetEnumerator M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionGetEnumerator()
        {
            tlog.Debug(tag, $"ItemIdCollectionGetEnumerator START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            var result = testingTarget.GetEnumerator();
            Assert.IsNotNull(result, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection.ItemIdCollectionEnumerator>(result, "Should be an Instance of ItemIdCollectionEnumerator!");

            tlog.Debug(tag, $"ItemIdCollectionGetEnumerator END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection.ItemIdCollectionEnumerator constructor.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.ItemIdCollectionEnumerator.ItemIdCollectionEnumerator C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONTSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionEnumeratorConstructor()
        {
            tlog.Debug(tag, $"ItemIdCollectionEnumeratorConstructor START");

            using (ItemIdCollection itemIdCollection = new ItemIdCollection())
            {
                var testingTarget = new ItemIdCollection.ItemIdCollectionEnumerator(itemIdCollection);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemIdCollection.ItemIdCollectionEnumerator>(testingTarget, "Should be an Instance of ItemIdCollectionEnumerator!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemIdCollectionEnumeratorConstructor END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ItemIdCollection.ItemIdCollectionEnumerator Current. currentIndex == -1.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.ItemIdCollectionEnumerator.Current A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionEnumeratorCurrent()
        {
            tlog.Debug(tag, $"ItemIdCollectionEnumeratorCurrent START");

            using (ItemIdCollection itemCollection = new ItemIdCollection())
            {
                var testingTarget = new ItemIdCollection.ItemIdCollectionEnumerator(itemCollection);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemIdCollection.ItemIdCollectionEnumerator>(testingTarget, "Should be an Instance of ItemIdCollectionEnumerator!");

                try
                {
                    tlog.Debug(tag, "Current : " + testingTarget.Current);
                }
                catch (InvalidOperationException e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    testingTarget.Dispose();
                    tlog.Debug(tag, $"ItemIdCollectionEnumeratorCurrent END (OK)");
                    Assert.Pass("Caught InvalidOperationException : passed!");
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection.ItemIdCollectionEnumerator MoveNext.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.ItemIdCollectionEnumerator.MoveNext M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionEnumeratorMoveNext()
        {
            tlog.Debug(tag, $"ItemIdCollectionEnumeratorMoveNext START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var itemIdCollection = new ItemIdCollection(c);
            Assert.IsNotNull(itemIdCollection, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(itemIdCollection, "Should be an Instance of ItemIdCollection!");

            var testingTarget = new ItemIdCollection.ItemIdCollectionEnumerator(itemIdCollection);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection.ItemIdCollectionEnumerator>(testingTarget, "Should be an Instance of ItemIdCollectionEnumerator!");

            try
            {
                testingTarget.MoveNext();
                var result = testingTarget.Current;
                Assert.IsNotNull(result, "Should be not null!");
                Assert.IsInstanceOf<uint>(result, "Should be an Instance of uint!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ItemIdCollectionEnumeratorMoveNext END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ItemIdCollection.ItemIdCollectionEnumerator MoveNext. Object is null.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.ItemIdCollectionEnumerator.MoveNext M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionEnumeratorMoveNextNullObject()
        {
            tlog.Debug(tag, $"ItemIdCollectionEnumeratorMoveNextNullObject START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var itemIdCollection = new ItemIdCollection(c);
            Assert.IsNotNull(itemIdCollection, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(itemIdCollection, "Should be an Instance of ItemIdCollection!");

            var testingTarget = new ItemIdCollection.ItemIdCollectionEnumerator(itemIdCollection);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection.ItemIdCollectionEnumerator>(testingTarget, "Should be an Instance of ItemIdCollectionEnumerator!");

            try
            {
                testingTarget.MoveNext();
                testingTarget.MoveNext();
                testingTarget.MoveNext();
                testingTarget.MoveNext();
                testingTarget.MoveNext();
                var result = testingTarget.Current;
            }
            catch (InvalidOperationException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"ItemIdCollectionEnumeratorMoveNextNullObject END (OK)");
                Assert.Pass("Caught InvalidOperationException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection.ItemIdCollectionEnumerator Reset.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.ItemIdCollectionEnumerator.Reset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionEnumeratorReset()
        {
            tlog.Debug(tag, $"ItemIdCollectionEnumeratorReset START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var itemIdCollection = new ItemIdCollection(c);
            Assert.IsNotNull(itemIdCollection, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(itemIdCollection, "Should be an Instance of ItemIdCollection!");

            var testingTarget = new ItemIdCollection.ItemIdCollectionEnumerator(itemIdCollection);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection.ItemIdCollectionEnumerator>(testingTarget, "Should be an Instance of ItemIdCollectionEnumerator!");

            testingTarget.MoveNext();

            try
            {
                testingTarget.Reset();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ItemIdCollectionEnumeratorReset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection Clear.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionClear()
        {
            tlog.Debug(tag, $"ItemIdCollectionClear START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");
            tlog.Debug(tag, "Count : " + testingTarget.Count.ToString());

            try
            {
                testingTarget.Clear();
                tlog.Debug(tag, "Count : " + testingTarget.Count.ToString());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemIdCollectionClear END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection AddRange.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.AddRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionAddRange()
        {
            tlog.Debug(tag, $"ItemIdCollectionAddRange START");

            using (ItemIdCollection itemIdCollection = new ItemIdCollection(5))
            {
                var testingTarget = new ItemIdCollection();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

                try
                {
                    testingTarget.AddRange(itemIdCollection);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemIdCollectionAddRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection GetRange.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.GetRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionGetRange()
        {
            tlog.Debug(tag, $"ItemIdCollectionGetRange START");

            using (ItemIdCollection itemIdCollection = new ItemIdCollection(5))
            {
                var testingTarget = new ItemIdCollection();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

                testingTarget.AddRange(itemIdCollection);

                try
                {
                    var result = testingTarget.GetRange(0, 0);
                    Assert.IsInstanceOf<ItemIdCollection>(result, "Should be an Instance of ItemIdCollection!");
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemIdCollectionGetRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection Insert.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.Insert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionInsert()
        {
            tlog.Debug(tag, $"ItemIdCollectionInsert START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            testingTarget.Capacity = 5;

            try
            {
                testingTarget.Insert(4, 5);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"ItemIdCollectionInsert END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection InsertRange.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.InsertRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionInsertRange()
        {
            tlog.Debug(tag, $"ItemIdCollectionInsertRange START");

            using (ItemIdCollection value = new ItemIdCollection(3))
            {

                uint[] itemId = new uint[] { 1, 2, 3, 4 };
                global::System.Collections.ICollection c = itemId;

                var testingTarget = new ItemIdCollection(c);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

                testingTarget.Capacity = 10;

                try
                {
                    testingTarget.InsertRange(3, value);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemIdCollectionInsertRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection RemoveAt.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.RemoveAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionRemoveAt()
        {
            tlog.Debug(tag, $"ItemIdCollectionRemoveAt START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            testingTarget.Capacity = 5;

            try
            {
                testingTarget.RemoveAt(3);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"ItemIdCollectionRemoveAt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection RemoveRange.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.RemoveRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionRemoveRange()
        {
            tlog.Debug(tag, $"ItemIdCollectionRemoveRange START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            testingTarget.Capacity = 5;

            try
            {
                testingTarget.RemoveRange(1, 2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"ItemIdCollectionRemoveRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection Repeat.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.Repeat M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionRepeat()
        {
            tlog.Debug(tag, $"ItemIdCollectionRepeat START");

            var testingTarget = ItemIdCollection.Repeat(6, 4);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            Assert.AreEqual(4, testingTarget.Capacity, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemIdCollectionRepeat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection SetRange.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.SetRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionSetRange()
        {
            tlog.Debug(tag, $"ItemIdCollectionSetRange START");

            using (ItemIdCollection itemIdCollection = new ItemIdCollection(5))
            {
                uint[] itemId = new uint[] { 1, 2, 3, 4 };
                global::System.Collections.ICollection c = itemId;

                var testingTarget = new ItemIdCollection(c);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

                try
                {
                    testingTarget.SetRange(1, itemIdCollection);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemIdCollectionSetRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection Reverse.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.Reverse M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionReverse()
        {
            tlog.Debug(tag, $"ItemIdCollectionReverse START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            testingTarget.Capacity = 5;

            try
            {
                testingTarget.Reverse();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"ItemIdCollectionReverse END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection Reverse. With parameters.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.Reverse M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionReverseWithParameters()
        {
            tlog.Debug(tag, $"ItemIdCollectionReverseWithParameters START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            testingTarget.Capacity = 5;

            try
            {
                testingTarget.Reverse(1, 2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"ItemIdCollectionReverseWithParameters END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection Contains.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.Contains M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionContains()
        {
            tlog.Debug(tag, $"ItemIdCollectionContains START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            testingTarget.Capacity = 5;

            Assert.IsTrue(testingTarget.Contains(2));

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemIdCollectionContains END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection IndexOf.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.IndexOf M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionIndexOf()
        {
            tlog.Debug(tag, $"ItemIdCollectionIndexOf START");

            uint[] itemId = new uint[] { 1, 2, 3, 4 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            testingTarget.Capacity = 5;

            Assert.AreEqual(2, testingTarget.IndexOf(3), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemIdCollectionIndexOf END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection LastIndexOf.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.LastIndexOf M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionLastIndexOf()
        {
            tlog.Debug(tag, $"ItemIdCollectionLastIndexOf START");

            uint[] itemId = new uint[] { 1, 2, 3, 4, 3 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            testingTarget.Capacity = 5;

            Assert.AreEqual(4, testingTarget.LastIndexOf(3), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemIdCollectionLastIndexOf END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemIdCollection Remove.")]
        [Property("SPEC", "Tizen.NUI.ItemIdCollection.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemIdCollectionRemove()
        {
            tlog.Debug(tag, $"ItemIdCollectionRemove START");

            uint[] itemId = new uint[] { 1, 2, 3, 4, 3 };
            global::System.Collections.ICollection c = itemId;

            var testingTarget = new ItemIdCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemIdCollection>(testingTarget, "Should be an Instance of ItemIdCollection!");

            testingTarget.Capacity = 5;

            Assert.AreEqual(true, testingTarget.Remove(3), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemIdCollectionRemove END (OK)");
        }
    }
}
