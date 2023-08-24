using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/ItemCollection")]
    public class InternalItemCollectionTest
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
        [Description("ItemCollection constructor.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.ItemCollection C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionConstructor()
        {
            tlog.Debug(tag, $"ItemCollectionConstructor START");

            var testingTarget = new ItemCollection();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            Assert.IsFalse(testingTarget.IsFixedSize);
            Assert.IsFalse(testingTarget.IsReadOnly);
            Assert.IsFalse(testingTarget.IsSynchronized);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemCollectionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection constructor. With ItemCollection.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.ItemCollection C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionConstructorWithItemCollection()
        {
            tlog.Debug(tag, $"ItemCollectionConstructorWithItemCollection START");

            using (ItemCollection itemCollection = new ItemCollection())
            {
                var testingTarget = new ItemCollection(itemCollection);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemCollectionConstructorWithItemCollection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection constructor. With capacity.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.ItemCollection C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionConstructorWithCapacity()
        {
            tlog.Debug(tag, $"ItemCollectionConstructorWithCapacity START");

            var testingTarget = new ItemCollection(5);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemCollectionConstructorWithCapacity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection constructor. With ICollection.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.ItemCollection C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionConstructorWithICollection()
        {
            tlog.Debug(tag, $"ItemCollectionConstructorWithICollection START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var testingTarget = new ItemCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            Assert.AreEqual(4, testingTarget.Count, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemCollectionConstructorWithICollection END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ItemCollection constructor. With null ICollection.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.ItemCollection C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionConstructorWithNullICollection()
        {
            tlog.Debug(tag, $"ItemCollectionConstructorWithNullICollection START");

            global::System.Collections.ICollection c = null;

            try
            {
                new ItemCollection(c);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ItemCollectionConstructorWithNullICollection END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection Clear.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionClear()
        {
            tlog.Debug(tag, $"ItemCollectionClear START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
           
            var testingTarget = new ItemCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");
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
            tlog.Debug(tag, $"ItemCollectionClear END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection this.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.this A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionGetVauleByIndex()
        {
            tlog.Debug(tag, $"ItemCollectionGetVauleByIndex START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var testingTarget = new ItemCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            testingTarget[2].first = 3;
            Assert.AreEqual(3, testingTarget[2].first, "Should be equal!");

            try
            {
                testingTarget[1] = new Item(testingTarget[2]);
                Assert.AreEqual(3, testingTarget[1].first, "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemCollectionGetVauleByIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection Capacity.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.Capacity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionCapacity()
        {
            tlog.Debug(tag, $"ItemCollectionCapacity START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var testingTarget = new ItemCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            Assert.AreEqual(4, testingTarget.Capacity, "Should be equal!");

            testingTarget.Capacity = 8;
            Assert.AreEqual(8, testingTarget.Capacity, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemCollectionCapacity END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ItemCollection Capacity. Set exception.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.Capacity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionCapacitySetException()
        {
            tlog.Debug(tag, $"ItemCollectionCapacitySetException START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var testingTarget = new ItemCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            Assert.AreEqual(4, testingTarget.Capacity, "Should be equal!");

            try
            {
                testingTarget.Capacity = 2;
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"ItemCollectionCapacitySetException END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection CopyTo.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionCopyTo()
        {
            tlog.Debug(tag, $"ItemCollectionCopyTo START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var testingTarget = new ItemCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            Item[] array = new Item[4];

            try
            {
                testingTarget.CopyTo(array);
                Assert.IsNotNull(array[1], "Should be not null!");
                Assert.IsInstanceOf<Item>(array[1], "Should be an Instance of Item!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemCollectionCopyTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection CopyTo. With arrayIndex.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionCopyToWithArrayIndex()
        {
            tlog.Debug(tag, $"ItemCollectionCopyToWithArrayIndex START");

            var testingTarget = new ItemCollection();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            testingTarget.Add(new Item());
            Assert.AreEqual(1, testingTarget.Count, "Should be equal!");

            try
            {
                testingTarget.CopyTo(new Item[2], 0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemCollectionCopyToWithArrayIndex END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ItemCollection CopyTo. With null array.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionCopyToWithNullArray()
        {
            tlog.Debug(tag, $"ItemCollectionCopyToWithNullArray START");

            var testingTarget = new ItemCollection();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            testingTarget.Add(new Item());
            Assert.AreEqual(1, testingTarget.Count, "Should be equal!");

            try
            {
                testingTarget.CopyTo(null, 0);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"ItemCollectionCopyToWithNullArray END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection CopyTo. ArrayIndex < 0.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionCopyToWithArrayIndexLessThan0()
        {
            tlog.Debug(tag, $"ItemCollectionCopyToWithArrayIndexLessThan0 START");

            var testingTarget = new ItemCollection();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            testingTarget.Add(new Item());
            Assert.AreEqual(1, testingTarget.Count, "Should be equal!");

            try
            {
                testingTarget.CopyTo(new Item[2], -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"ItemCollectionCopyToWithArrayIndexLessThan0 END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("ItemCollection CopyTo. Elements too large.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionCopyToWithLargerElements()
        {
            tlog.Debug(tag, $"ItemCollectionCopyToWithLargerElements START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var testingTarget = new ItemCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            Item[] array = new Item[4];

            try
            {
                testingTarget.CopyTo(array, 2);
            }
            catch (ArgumentException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"ItemCollectionCopyToWithLargerElements END (OK)");
                Assert.Pass("Caught ArgumentException: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("ItemCollection CopyTo. Index < 0.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionCopyToWithIndexLessThan0()
        {
            tlog.Debug(tag, $"ItemCollectionCopyToWithIndexLessThan0 START");

            var testingTarget = new ItemCollection();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            testingTarget.Add(new Item());
            Assert.AreEqual(1, testingTarget.Count, "Should be equal!");

            try
            {
                testingTarget.CopyTo(-1, new Item[2], 0,  1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"ItemCollectionCopyToWithIndexLessThan0 END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("ItemCollection CopyTo. Count < zero.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionCopyToWithCountLessThan0()
        {
            tlog.Debug(tag, $"ItemCollectionCopyToWithCountLessThan0 START");

            var testingTarget = new ItemCollection();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            testingTarget.Add(new Item());
            Assert.AreEqual(1, testingTarget.Count, "Should be equal!");

            try
            {
                testingTarget.CopyTo(0, new Item[2], 0, -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"ItemCollectionCopyToWithCountLessThan0 END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection GetEnumerator.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.GetEnumerator M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionGetEnumerator()
        {
            tlog.Debug(tag, $"ItemCollectionGetEnumerator START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var testingTarget = new ItemCollection(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            var result = testingTarget.GetEnumerator();
            Assert.IsNotNull(result, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection.ItemCollectionEnumerator>(result, "Should be an Instance of ItemCollectionEnumerator!");

            tlog.Debug(tag, $"ItemCollectionGetEnumerator END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection.ItemCollectionEnumerator constructor.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.ItemCollectionEnumerator.ItemCollectionEnumerator C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONTSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionItemCollectionEnumeratorConstructor()
        {
            tlog.Debug(tag, $"ItemCollectionItemCollectionEnumeratorConstructor START");

            using (ItemCollection itemCollection = new ItemCollection())
            {
                var testingTarget = new ItemCollection.ItemCollectionEnumerator(itemCollection);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemCollection.ItemCollectionEnumerator>(testingTarget, "Should be an Instance of ItemCollectionEnumerator!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemCollectionItemCollectionEnumeratorConstructor END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ItemCollection.ItemCollectionEnumerator Current. currentIndex == -1.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.ItemCollectionEnumerator.Current A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionItemCollectionEnumeratorCurrent()
        {
            tlog.Debug(tag, $"ItemCollectionItemCollectionEnumeratorCurrent START");

            using (ItemCollection itemCollection = new ItemCollection())
            {
                var testingTarget = new ItemCollection.ItemCollectionEnumerator(itemCollection);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemCollection.ItemCollectionEnumerator>(testingTarget, "Should be an Instance of ItemCollectionEnumerator!");

                try
                {
                    tlog.Debug(tag, "Current : " + testingTarget.Current);
                }
                catch (InvalidOperationException e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    testingTarget.Dispose();
                    tlog.Debug(tag, $"ItemCollectionItemCollectionEnumeratorCurrent END (OK)");
                    Assert.Pass("Caught InvalidOperationException : passed!");
                }
            }

            tlog.Debug(tag, $"ItemCollectionItemCollectionEnumeratorCurrent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection.ItemCollectionEnumerator MoveNext.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.ItemCollectionEnumerator.MoveNext M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionItemCollectionEnumeratorMoveNext()
        {
            tlog.Debug(tag, $"ItemCollectionItemCollectionEnumeratorMoveNext START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var itemCollection = new ItemCollection(c);
            Assert.IsNotNull(itemCollection, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(itemCollection, "Should be an Instance of ItemCollection!");

            var testingTarget = new ItemCollection.ItemCollectionEnumerator(itemCollection);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection.ItemCollectionEnumerator>(testingTarget, "Should be an Instance of ItemCollectionEnumerator!");

            try
            {
                testingTarget.MoveNext();
                var result = testingTarget.Current;
                Assert.IsNotNull(result, "Should be not null!");
                Assert.IsInstanceOf<Item>(result, "Should be an Instance of Item!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ItemCollectionItemCollectionEnumeratorMoveNext END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ItemCollection.ItemCollectionEnumerator MoveNext. Object is null.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.ItemCollectionEnumerator.MoveNext M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionItemCollectionEnumeratorMoveNextNullObject()
        {
            tlog.Debug(tag, $"ItemCollectionItemCollectionEnumeratorMoveNextNullObject START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var itemCollection = new ItemCollection(c);
            Assert.IsNotNull(itemCollection, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(itemCollection, "Should be an Instance of ItemCollection!");

            var testingTarget = new ItemCollection.ItemCollectionEnumerator(itemCollection);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection.ItemCollectionEnumerator>(testingTarget, "Should be an Instance of ItemCollectionEnumerator!");

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
                tlog.Debug(tag, $"ItemCollectionItemCollectionEnumeratorMoveNextNullObject END (OK)");
                Assert.Pass("Caught InvalidOperationException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection.ItemCollectionEnumerator Reset.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.ItemCollectionEnumerator.Reset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionItemCollectionEnumeratorReset()
        {
            tlog.Debug(tag, $"ItemCollectionItemCollectionEnumeratorReset START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var itemCollection = new ItemCollection(c);
            Assert.IsNotNull(itemCollection, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(itemCollection, "Should be an Instance of ItemCollection!");

            var testingTarget = new ItemCollection.ItemCollectionEnumerator(itemCollection);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection.ItemCollectionEnumerator>(testingTarget, "Should be an Instance of ItemCollectionEnumerator!");

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

            tlog.Debug(tag, $"ItemCollectionItemCollectionEnumeratorReset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection AddRange.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.AddRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionAddRange()
        {
            tlog.Debug(tag, $"ItemCollectionAddRange START");

            using (ItemCollection itemCollection = new ItemCollection(5))
            {
                var testingTarget = new ItemCollection();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

                try
                {
                    testingTarget.AddRange(itemCollection);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemCollectionAddRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection GetRange.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.GetRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionGetRange()
        {
            tlog.Debug(tag, $"ItemCollectionGetRange START");

            using (ItemCollection itemCollection = new ItemCollection(5))
            {
                var testingTarget = new ItemCollection();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

                testingTarget.AddRange(itemCollection);

                try
                {
                    var result = testingTarget.GetRange(0, 0);
                    Assert.IsInstanceOf<ItemCollection>(result, "Should be an Instance of ItemCollection!");
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemCollectionGetRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection Insert.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.Insert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionInsert()
        {
            tlog.Debug(tag, $"ItemCollectionInsert START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var testingTarget = new ItemCollection(c);

            testingTarget.Capacity = 5;

            try
            {
                testingTarget.Insert(4, new Item());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemCollectionInsert END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection InsertRange.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.InsertRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionInsertRange()
        {
            tlog.Debug(tag, $"ItemCollectionInsertRange START");

            using (ItemCollection value = new ItemCollection(3))
            {

                Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
                global::System.Collections.ICollection c = b;
                var testingTarget = new ItemCollection(c);

                testingTarget.Capacity = 10;

                try
                {
                    testingTarget.InsertRange(4, value);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemCollectionInsertRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection RemoveAt.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.RemoveAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionRemoveAt()
        {
            tlog.Debug(tag, $"ItemCollectionRemoveAt START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var testingTarget = new ItemCollection(c);

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

            tlog.Debug(tag, $"ItemCollectionRemoveAt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection RemoveRange.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.RemoveRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionRemoveRange()
        {
            tlog.Debug(tag, $"ItemCollectionRemoveRange START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var testingTarget = new ItemCollection(c);

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

            tlog.Debug(tag, $"ItemCollectionRemoveRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection Repeat.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.Repeat M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionRepeat()
        {
            tlog.Debug(tag, $"ItemCollectionRepeat START");

            var testingTarget = ItemCollection.Repeat(new Item(), 6);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemCollection>(testingTarget, "Should be an Instance of ItemCollection!");

            Assert.AreEqual(6, testingTarget.Capacity, "Should be equal!");

            testingTarget.Dispose();

            tlog.Debug(tag, $"ItemCollectionRepeat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection SetRange.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.SetRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionSetRange()
        {
            tlog.Debug(tag, $"ItemCollectionSetRange START");

            using (ItemCollection itemCollection = new ItemCollection(5))
            {
                Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
                global::System.Collections.ICollection c = b;
                var testingTarget = new ItemCollection(c);

                try
                {
                    testingTarget.SetRange(1, itemCollection);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemCollectionSetRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection Reverse.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.Reverse M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionReverse()
        {
            tlog.Debug(tag, $"ItemCollectionReverse START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var testingTarget = new ItemCollection(c);

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

            tlog.Debug(tag, $"ItemCollectionReverse END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemCollection Reverse. With parameters.")]
        [Property("SPEC", "Tizen.NUI.ItemCollection.Reverse M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemCollectionReverseWithParameters()
        {
            tlog.Debug(tag, $"ItemCollectionReverseWithParameters START");

            Item[] b = new Item[] { new Item(), new Item(), new Item(), new Item() };
            global::System.Collections.ICollection c = b;
            var testingTarget = new ItemCollection(c);

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

            tlog.Debug(tag, $"ItemCollectionReverseWithParameters END (OK)");
        }
    }
}
