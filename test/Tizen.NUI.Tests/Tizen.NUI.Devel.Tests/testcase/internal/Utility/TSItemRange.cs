using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/ItemRange")]
    public class InternalItemRangeTest
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
        [Description("ItemRange constructor.")]
        [Property("SPEC", "Tizen.NUI.ItemRange.ItemRange C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemRangeConstructor()
        {
            tlog.Debug(tag, $"ItemRangeConstructor START");
            
            var testingTarget = new ItemRange(0, 300);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemRange>(testingTarget, "Should be an Instance of ItemRange!");

            testingTarget.Dispose();

            tlog.Debug(tag, $"ItemRangeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemRange constructor. With ItemRange.")]
        [Property("SPEC", "Tizen.NUI.ItemRange.ItemRange C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemRangeConstructorWithItemRange()
        {
            tlog.Debug(tag, $"ItemRangeConstructorWithItemRange START");

            using (ItemRange copy = new ItemRange(0, 300))
            {
                var testingTarget = new ItemRange(copy);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemRange>(testingTarget, "Should be an Instance of ItemRange!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemRangeConstructorWithItemRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemRange Assign.")]
        [Property("SPEC", "Tizen.NUI.ItemRange.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemRangeAssign()
        {
            tlog.Debug(tag, $"ItemRangeAssign START");

            using (ItemRange range = new ItemRange(0, 300))
            {
                using (ItemRange copy = new ItemRange(range))
                {
                    var testingTarget = range.Assign(copy);
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<ItemRange>(testingTarget, "Should be an Instance of ItemRange!");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"ItemRangeAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemRange Within.")]
        [Property("SPEC", "Tizen.NUI.ItemRange.Within M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemRangeWithin()
        {
            tlog.Debug(tag, $"ItemRangeWithin START");

            var testingTarget = new ItemRange(0, 300);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemRange>(testingTarget, "Should be an Instance of ItemRange!");

            var result = testingTarget.Within(50);
            Assert.IsTrue(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemRangeWithin END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemRange Intersection.")]
        [Property("SPEC", "Tizen.NUI.ItemRange.Intersection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemRangeIntersection()
        {
            tlog.Debug(tag, $"ItemRangeIntersection START");

            var testingTarget = new ItemRange(0, 300);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemRange>(testingTarget, "Should be an Instance of ItemRange!");

            using (ItemRange second = new ItemRange(300, 500))
            {
                var result = testingTarget.Intersection(second);
                Assert.IsNotNull(result, "Should be not null!");
                Assert.IsInstanceOf<ItemRange>(result, "Should be an Instance of ItemRange!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemRangeIntersection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemRange begin.")]
        [Property("SPEC", "Tizen.NUI.ItemRange.begin A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemRangeBegin()
        {
            tlog.Debug(tag, $"ItemRangeBegin START");

            var testingTarget = new ItemRange(0, 300);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemRange>(testingTarget, "Should be an Instance of ItemRange!");

            Assert.AreEqual(0, testingTarget.begin, "Should be equal!");
            testingTarget.begin = 100;
            Assert.AreEqual(100, testingTarget.begin, "Should be equal!");

            testingTarget.Dispose();

            tlog.Debug(tag, $"ItemRangeBegin END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemRange end.")]
        [Property("SPEC", "Tizen.NUI.ItemRange.end C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemRangeEnd()
        {
            tlog.Debug(tag, $"ItemRangeEnd START");

            var testingTarget = new ItemRange(0, 300);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemRange>(testingTarget, "Should be an Instance of ItemRange!");

            Assert.AreEqual(300, testingTarget.end, "Should be equal!");
            testingTarget.end = 500;
            Assert.AreEqual(500, testingTarget.end, "Should be equal!");

            testingTarget.Dispose();

            tlog.Debug(tag, $"ItemRangeEnd END (OK)");
        }
    }
}
