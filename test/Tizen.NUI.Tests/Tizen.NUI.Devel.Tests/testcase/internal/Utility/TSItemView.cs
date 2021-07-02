using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/ItemView")]
    public class InternalItemViewTest
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
        [Description("ItemView constructor.")]
        [Property("SPEC", "Tizen.NUI.ItemView.ItemView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewConstructor()
        {
            tlog.Debug(tag, $"ItemViewConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ItemView(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                tlog.Debug(tag, " LayoutCount : " + testingTarget.GetLayoutCount());

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView constructor. With ItemFactory.")]
        [Property("SPEC", "Tizen.NUI.ItemView.Layout C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewConstructorWithItemFactory()
        {
            tlog.Debug(tag, $"ItemViewConstructorWithItemFactory START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewConstructorWithItemFactory END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView Layout.")]
        [Property("SPEC", "Tizen.NUI.ItemView.Layout A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewLayout()
        {
            tlog.Debug(tag, $"ItemViewLayout START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                using (PropertyArray propertyArray = new PropertyArray())
                {
                    propertyArray.Add(new PropertyValue(new Size2D(100, 80)));
                    testingTarget.Layout = propertyArray;

                    try
                    {
                        testingTarget.Layout = propertyArray;
                        tlog.Debug(tag, "Layout : " + testingTarget.Layout);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception: Failed!");
                    }
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView AddLayout.")]
        [Property("SPEC", "Tizen.NUI.ItemView.AddLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewAddLayout()
        {
            tlog.Debug(tag, $"ItemViewAddLayout START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.AddLayout(new ItemLayout(testingTarget.SwigCPtr.Handle, true));

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewAddLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView RemoveLayout.")]
        [Property("SPEC", "Tizen.NUI.ItemView.RemoveLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewRemoveLayout()
        {
            tlog.Debug(tag, $"ItemViewRemoveLayout START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.AddLayout(new ItemLayout(testingTarget.SwigCPtr.Handle, true));
                tlog.Debug(tag, " LayoutCount : " + testingTarget.GetLayoutCount());

                try
                {
                    testingTarget.RemoveLayout((uint)testingTarget.LayoutPosition);
                    tlog.Debug(tag, " LayoutCount : " + testingTarget.GetLayoutCount());
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewRemoveLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView DownCast.")]
        [Property("SPEC", "Tizen.NUI.ItemView.Layout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewDownCast()
        {
            tlog.Debug(tag, $"ItemViewDownCast START");

            using (ItemFactory factory = new ItemFactory())
            {
                using (ItemView view = new ItemView(factory))
                {
                    var testingTarget = ItemView.DownCast(view);
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"ItemViewDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView GetLayout.")]
        [Property("SPEC", "Tizen.NUI.ItemView.GetLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewGetLayout()
        {
            tlog.Debug(tag, $"ItemViewGetLayout START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.AddLayout(new ItemLayout(testingTarget.SwigCPtr.Handle, true));

                try
                {
                    testingTarget.GetLayout((uint)testingTarget.LayoutPosition);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewGetLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView GetActiveLayout.")]
        [Property("SPEC", "Tizen.NUI.ItemView.GetActiveLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewGetActiveLayout()
        {
            tlog.Debug(tag, $"ItemViewGetActiveLayout START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.AddLayout(new ItemLayout(testingTarget.SwigCPtr.Handle, true));

                try
                {
                    testingTarget.GetActiveLayout();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewGetActiveLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView InsertItem.")]
        [Property("SPEC", "Tizen.NUI.ItemView.InsertItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewInsertItem()
        {
            tlog.Debug(tag, $"ItemViewInsertItem START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                try
                {
                    using (Item item = new Item())
                    {
                        testingTarget.InsertItem(new Item(), 30.0f);
                    }
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewInsertItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView RemoveItem.")]
        [Property("SPEC", "Tizen.NUI.ItemView.RemoveItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewRemoveItem()
        {
            tlog.Debug(tag, $"ItemViewRemoveItem START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                using (Item item = new Item())
                {
                    testingTarget.InsertItem(item, 30.0f);

                    var id = testingTarget.GetLayoutCount() - 1;
                    testingTarget.RemoveItem(id, 0.5f);
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewRemoveItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView SetItemsAnchorPoint.")]
        [Property("SPEC", "Tizen.NUI.ItemView.SetItemsAnchorPoint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewSetItemsAnchorPoint()
        {
            tlog.Debug(tag, $"ItemViewSetItemsAnchorPoint START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                using (Vector3 vector = new Vector3(100.0f, 30.0f, 200.0f))
                {
                    testingTarget.SetItemsAnchorPoint(vector);
                    Assert.AreEqual(100.0f, testingTarget.GetItemsAnchorPoint().X, "Should be equal!");
                    Assert.AreEqual(30.0f, testingTarget.GetItemsAnchorPoint().Y, "Should be equal!");
                    Assert.AreEqual(200.0f, testingTarget.GetItemsAnchorPoint().Z, "Should be equal!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewSetItemsAnchorPoint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView GetItemsRange.")]
        [Property("SPEC", "Tizen.NUI.ItemView.GetItemsRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewGetItemsRange()
        {
            tlog.Debug(tag, $"ItemViewGetItemsRange START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                try
                {
                    using (ItemRange range = new ItemRange(0, 300))
                    {
                        testingTarget.GetItemsRange(range);
                    }
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewGetItemsRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView SetAnchoring.")]
        [Property("SPEC", "Tizen.NUI.ItemView.SetAnchoring M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewSetAnchoring()
        {
            tlog.Debug(tag, $"ItemViewSetAnchoring START");

            using (ItemFactory factory = new ItemFactory())
            {
                using (ItemView itemView = new ItemView(factory))
                {
                    itemView.SetAnchoring(true);
                    Assert.AreEqual(true, itemView.GetAnchoring(), "Should be equal!");

                    itemView.SetAnchoring(false);
                    Assert.AreEqual(false, itemView.GetAnchoring(), "Should be equal!");
                }
            }

            tlog.Debug(tag, $"ItemViewSetAnchoring END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView SetAnchoringDuration.")]
        [Property("SPEC", "Tizen.NUI.ItemView.SetAnchoringDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewSetAnchoringDuration()
        {
            tlog.Debug(tag, $"ItemViewSetAnchoringDuration START");

            using (ItemFactory factory = new ItemFactory())
            {
                using (ItemView itemView = new ItemView(factory))
                {
                    itemView.SetAnchoringDuration(30.0f);
                    Assert.AreEqual(30.0f, itemView.GetAnchoringDuration(), "Should be equal!");
                }
            }

            tlog.Debug(tag, $"ItemViewSetAnchoringDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView Refresh.")]
        [Property("SPEC", "Tizen.NUI.ItemView.Refresh M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewRefresh()
        {
            tlog.Debug(tag, $"ItemViewRefresh START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.AddLayout(new ItemLayout(factory.SwigCPtr.Handle, true));

                try
                {
                    testingTarget.Refresh();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"ItemViewRefresh END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView GetItemId.")]
        [Property("SPEC", "Tizen.NUI.ItemView.GetItemId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewGetItemId()
        {
            tlog.Debug(tag, $"ItemViewGetItemId START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                View view = new View()
                {
                    Size = new Size(100, 80)
                };

                testingTarget.AddLayout(new ItemLayout(view.SwigCPtr.Handle, true));

                try
                {
                    var result = testingTarget.GetItemId(view);
                    tlog.Debug(tag, "ItemId : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"ItemViewGetItemId END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView SetItemsParentOrigin.")]
        [Property("SPEC", "Tizen.NUI.ItemView.SetItemsParentOrigin M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewSetItemsParentOrigin()
        {
            tlog.Debug(tag, $"ItemViewSetItemsParentOrigin START");

            using (ItemFactory factory = new ItemFactory())
            {
                using (ItemView itemView = new ItemView(factory))
                {
                    using (Vector3 vector = new Vector3(0.0f, 1.0f, 3.0f))
                    {
                        itemView.SetItemsParentOrigin(vector);
                        Assert.AreEqual(0.0f, itemView.GetItemsParentOrigin().X, "Should be equal!");
                        Assert.AreEqual(1.0f, itemView.GetItemsParentOrigin().Y, "Should be equal!");
                        Assert.AreEqual(3.0f, itemView.GetItemsParentOrigin().Z, "Should be equal!");
                    }
                }
            }

            tlog.Debug(tag, $"ItemViewSetItemsParentOrigin END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView LayoutActivatedSignal.")]
        [Property("SPEC", "Tizen.NUI.ItemView.LayoutActivatedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewLayoutActivatedSignal()
        {
            tlog.Debug(tag, $"ItemViewLayoutActivatedSignal START");

            using (ItemFactory factory = new ItemFactory())
            {
                using (ItemView itemView = new ItemView(factory))
                {
                    var testingTarget = itemView.LayoutActivatedSignal();
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<VoidSignal>(testingTarget, "Should be an Instance of VoidSignal!");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"ItemViewLayoutActivatedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView MinimumSwipeDistance.")]
        [Property("SPEC", "Tizen.NUI.ItemView.MinimumSwipeDistance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewMinimumSwipeDistance()
        {
            tlog.Debug(tag, $"ItemViewMinimumSwipeDistance START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.MinimumSwipeDistance = 10.0f;
                Assert.AreEqual(10.0f, testingTarget.MinimumSwipeDistance, "Should be equal");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewMinimumSwipeDistance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView MinimumSwipeSpeed.")]
        [Property("SPEC", "Tizen.NUI.ItemView.MinimumSwipeSpeed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewMinimumSwipeSpeed()
        {
            tlog.Debug(tag, $"ItemViewMinimumSwipeSpeed START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.MinimumSwipeSpeed = 1.0f;
                Assert.AreEqual(1.0f, testingTarget.MinimumSwipeSpeed, "Should be equal");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewMinimumSwipeSpeed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView WheelScrollDistanceStep.")]
        [Property("SPEC", "Tizen.NUI.ItemView.WheelScrollDistanceStep A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewWheelScrollDistanceStep()
        {
            tlog.Debug(tag, $"ItemViewWheelScrollDistanceStep START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.WheelScrollDistanceStep = 1.0f;
                Assert.AreEqual(1.0f, testingTarget.WheelScrollDistanceStep, "Should be equal");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewWheelScrollDistanceStep END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView SnapToItemEnabled.")]
        [Property("SPEC", "Tizen.NUI.ItemView.SnapToItemEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewSnapToItemEnabled()
        {
            tlog.Debug(tag, $"ItemViewSnapToItemEnabled START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.SnapToItemEnabled = true;
                Assert.AreEqual(true, testingTarget.SnapToItemEnabled, "Should be equal");

                testingTarget.SnapToItemEnabled = false;
                Assert.AreEqual(false, testingTarget.SnapToItemEnabled, "Should be equal");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewSnapToItemEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView RefreshInterval.")]
        [Property("SPEC", "Tizen.NUI.ItemView.RefreshInterval A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewRefreshInterval()
        {
            tlog.Debug(tag, $"ItemViewRefreshInterval START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.RefreshInterval = 0.3f;
                Assert.AreEqual(0.3f, testingTarget.RefreshInterval, "Should be equal");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewRefreshInterval END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView LayoutPosition.")]
        [Property("SPEC", "Tizen.NUI.ItemView.LayoutPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewLayoutPosition()
        {
            tlog.Debug(tag, $"ItemViewLayoutPosition START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.LayoutPosition = 15.0f;
                Assert.AreEqual(15.0f, testingTarget.LayoutPosition, "Should be equal");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewLayoutPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView ScrollSpeed.")]
        [Property("SPEC", "Tizen.NUI.ItemView.ScrollSpeed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewScrollSpeed()
        {
            tlog.Debug(tag, $"ItemViewScrollSpeed START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.ScrollSpeed = 15.0f;
                Assert.AreEqual(15.0f, testingTarget.ScrollSpeed, "Should be equal");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewScrollSpeed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView Overshoot.")]
        [Property("SPEC", "Tizen.NUI.ItemView.Overshoot A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewOvershoot()
        {
            tlog.Debug(tag, $"ItemViewOvershoot START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.Overshoot = 15.0f;
                Assert.AreEqual(15.0f, testingTarget.Overshoot, "Should be equal");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewOvershoot END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView ScrollDirection.")]
        [Property("SPEC", "Tizen.NUI.ItemView.ScrollDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewScrollDirection()
        {
            tlog.Debug(tag, $"ItemViewScrollDirection START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.ScrollDirection = new Vector2(0.0f, 90.0f);
                Assert.AreEqual(0.0f, testingTarget.ScrollDirection.X, "Should be equal");
                Assert.AreEqual(90.0f, testingTarget.ScrollDirection.Y, "Should be equal");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewScrollDirection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView LayoutOrientation.")]
        [Property("SPEC", "Tizen.NUI.ItemView.LayoutOrientation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewLayoutOrientation()
        {
            tlog.Debug(tag, $"ItemViewLayoutOrientation START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.LayoutOrientation = 1;
                Assert.AreEqual(1, testingTarget.LayoutOrientation, "Should be equal");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewLayoutOrientation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemView ScrollContentSize.")]
        [Property("SPEC", "Tizen.NUI.ItemView.ScrollContentSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemViewScrollContentSize()
        {
            tlog.Debug(tag, $"ItemViewScrollContentSize START");

            using (ItemFactory factory = new ItemFactory())
            {
                var testingTarget = new ItemView(factory);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemView>(testingTarget, "Should be an Instance of ItemView!");

                testingTarget.ScrollContentSize = 15.0f;
                Assert.AreEqual(15.0f, testingTarget.ScrollContentSize, "Should be equal");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemViewScrollContentSize END (OK)");
        }
    }
}
