using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/Item")]
    public class InternalItemTest
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
        [Description("Item constructor.")]
        [Property("SPEC", "Tizen.NUI.Item.Item C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemConstructor()
        {
            tlog.Debug(tag, $"ItemConstructor START");

            var testingTarget = new Item();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Item>(testingTarget, "Should be an Instance of Item!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ItemConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Item constructor. With View.")]
        [Property("SPEC", "Tizen.NUI.Item.Item C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemConstructorWithView()
        {
            tlog.Debug(tag, $"ItemConstructorWithView START");

            using (View view = new View())
            {
                var testingTarget = new Item(2, view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<Item>(testingTarget, "Should be an Instance of Item!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemConstructorWithView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Item constructor. With Item.")]
        [Property("SPEC", "Tizen.NUI.Item.Item C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemConstructorWithItem()
        {
            tlog.Debug(tag, $"ItemConstructorWithItem START");

            using (View view = new View())
            {
                using (Item item = new Item(2, view))
                {
                    var testingTarget = new Item(item);
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<Item>(testingTarget, "Should be an Instance of Item!");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"ItemConstructorWithItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Item first.")]
        [Property("SPEC", "Tizen.NUI.Item.first A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemConstructorFirst()
        {
            tlog.Debug(tag, $"ItemConstructorFirst START");

            using (View view = new View())
            {
                using (Item item = new Item(2, view))
                {
                    var testingTarget = new Item(item);
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<Item>(testingTarget, "Should be an Instance of Item!");

                    Assert.AreEqual(2, testingTarget.first, "should be equal!");

                    testingTarget.first = 1;
                    Assert.AreEqual(1, testingTarget.first, "should be equal!");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"ItemConstructorFirst END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Item second.")]
        [Property("SPEC", "Tizen.NUI.Item.second A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemConstructorSecond()
        {
            tlog.Debug(tag, $"ItemConstructorSecond START");

            using (View view = new View())
            {
                using (Item item = new Item(2, view))
                {
                    var testingTarget = new Item(item);
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<Item>(testingTarget, "Should be an Instance of Item!");

                    var result = testingTarget.second;
                    Assert.IsInstanceOf<View>(testingTarget.second, "Should be an Instance of View!");

                    using (View view2 = new View())
                    {
                        testingTarget.second = view2;
                        Assert.IsNotNull(testingTarget.second, "Should be not null!");
                        Assert.IsInstanceOf<View>(testingTarget.second, "Should be an Instance of View!");
                    }

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"ItemConstructorSecond END (OK)");
        }
    }   
}
