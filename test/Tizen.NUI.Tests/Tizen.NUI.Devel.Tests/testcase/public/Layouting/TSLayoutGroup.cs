using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Layouting/LayoutGroup")]
    public class PublicLayoutGroupTest
    {
        private const string tag = "NUITEST";
        private static bool flagOnMeasureOverride;
        private static bool flagOnLayoutOverride;
        private static bool flagOnChildAddOverride;
        private static bool flagOnChildRemoveOverride;
        private static bool flagOnMeasureChild;
        private static bool flagOnAttachedToOwner;

        internal class MyLayoutGroup : LayoutGroup
        {
            public MyLayoutGroup() : base()
            { }

            public int ChildCount()
            {
                return LayoutChildren.Count;
            }

            public IEnumerable<LayoutItem> ForeachLayoutChildren()
            {
                List<LayoutItem> LinearChildren = IterateLayoutChildren().ToList();
                return LinearChildren;
            }

            // This method needs to call protected method, OnMeasure for the test cases.
            public void OnMeasureTest(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                OnMeasure(widthMeasureSpec, heightMeasureSpec);
            }
            protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                flagOnMeasureOverride = true;
                base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            }

            public void OnLayoutTest(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
            {
                OnLayout(changed, left, top, right, bottom);
            }
            protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
            {
                flagOnLayoutOverride = true;
                base.OnLayout(changed, left, top, right, bottom);
            }

            public void OnChildAddTest(LayoutItem child)
            {
                OnChildAdd(child);
            }
            protected override void OnChildAdd(LayoutItem child)
            {
                flagOnChildAddOverride = true;
                base.OnChildAdd(child);
            }

            public void OnChildRemoveTest(LayoutItem child)
            {
                OnChildRemove(child);
            }
            protected override void OnChildRemove(LayoutItem child)
            {
                flagOnChildRemoveOverride = true;
                base.OnChildRemove(child);
            }

            public void MeasureChildTest(LayoutItem child, MeasureSpecification parentWidth, MeasureSpecification parentHeight)
            {
                MeasureChild(child, parentWidth, parentHeight);
            }
            protected override void MeasureChild(LayoutItem child, MeasureSpecification parentWidth, MeasureSpecification parentHeight)
            {
                flagOnMeasureChild = true;
                base.MeasureChild(child, parentWidth, parentHeight);
            }

            public void MeasureChildrenTest(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                MeasureChildren(widthMeasureSpec, heightMeasureSpec);
            }
            protected override void MeasureChildren(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                flagOnMeasureChild = true;
                base.MeasureChildren(widthMeasureSpec, heightMeasureSpec);
            }

            public void MeasureChildWithMarginsTest(LayoutItem child, MeasureSpecification parentWidthMeasureSpec, LayoutLength widthUsed, MeasureSpecification parentHeightMeasureSpec, LayoutLength heightUsed)
            {
                MeasureChildWithMargins(child, parentWidthMeasureSpec, widthUsed, parentHeightMeasureSpec, heightUsed);
            }
            protected override void MeasureChildWithMargins(LayoutItem child, MeasureSpecification parentWidthMeasureSpec, LayoutLength widthUsed, MeasureSpecification parentHeightMeasureSpec, LayoutLength heightUsed)
            {
                flagOnMeasureChild = true;
                base.MeasureChildWithMargins(child, parentWidthMeasureSpec, widthUsed, parentHeightMeasureSpec, heightUsed);
            }

            public void MeasureChildWithoutPaddingTest(LayoutItem child, MeasureSpecification parentWidthMeasureSpec, MeasureSpecification parentHeightMeasureSpec)
            {
                MeasureChildWithoutPadding(child, parentWidthMeasureSpec, parentHeightMeasureSpec);
            }

            public void OnAttachedToOwnerTest()
            {
                OnAttachedToOwner();
            }
            protected override void OnAttachedToOwner()
            {
                flagOnAttachedToOwner = true;
                base.OnAttachedToOwner();
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
        [Description("LayoutGroup constructor")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.LayoutGroup C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupConstructor()
        {
            tlog.Debug(tag, $"LayoutGroupConstructor START");

            var layoutGroup = new LayoutGroup();
            Assert.IsNotNull(layoutGroup, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(layoutGroup, "Should return LayoutGroup instance.");

            layoutGroup.Dispose();
            tlog.Debug(tag, $"LayoutGroupConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup IterateLayoutChildren")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.IterateLayoutChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupIterateLayoutChildren()
        {
            tlog.Debug(tag, $"LayoutGroupIterateLayoutChildren START");

            LayoutItem layoutItem = new LinearLayout();

            View view = new View()
            {
                ExcludeLayouting = false,
            };
            layoutItem.AttachToOwner(view);

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should return LayoutGroup instance.");

            testingTarget.Add(layoutItem);

            var result = testingTarget.ForeachLayoutChildren();
            Assert.AreEqual(1, result.Count(), "should be equal!");

            tlog.Debug(tag, $"LayoutGroupIterateLayoutChildren END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup Add")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupAdd()
        {
            tlog.Debug(tag, $"LayoutGroupAdd START");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should return LayoutGroup instance.");

            using (LayoutItem layoutItem = new LayoutItem())
            {
                testingTarget.Add(layoutItem);
                Assert.AreEqual(testingTarget.ChildCount(), 1, "Should 1 for the added child.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutGroupAdd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup Add. With null argument")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupAddWithNullArgument()
        {
            tlog.Debug(tag, $"LayoutGroupAddWithNullArgument START");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should return LayoutGroup instance.");

            try
            {
                testingTarget.Add(null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"LayoutGroupAddWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup RemoveAll")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.RemoveAll M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupRemoveAll()
        {
            tlog.Debug(tag, $"LayoutGroupRemoveAll START");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should return LayoutGroup instance.");

            using (LayoutItem layoutItem = new LayoutItem())
            {
                testingTarget.Add(layoutItem);
                Assert.AreEqual(testingTarget.ChildCount(), 1, "Should 1 for the added child.");

                testingTarget.RemoveAll();
                Assert.AreEqual(testingTarget.ChildCount(), 0, "Should 0 as child removed.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutGroupRemoveAll END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup Remove")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupRemove()
        {
            tlog.Debug(tag, $"LayoutGroupRemove START");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should return LayoutGroup instance.");

            using (LayoutItem layoutItem = new LayoutItem())
            {
                testingTarget.LayoutWithTransition = true;

                testingTarget.Add(layoutItem);
                Assert.AreEqual(testingTarget.ChildCount(), 1, "Should 1 for the added child.");

                using (LayoutItem siblingLayoutItem = new LayoutItem())
                {
                    testingTarget.Add(siblingLayoutItem);
                    Assert.AreEqual(testingTarget.ChildCount(), 2, "Should 1 for the added child.");

                    testingTarget.Remove(layoutItem);
                    Assert.AreEqual(testingTarget.ChildCount(), 1, "Should 0 as child removed");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutGroupRemove END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup ChangeLayoutSiblingOrder")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.ChangeLayoutSiblingOrder M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupChangeLayoutSiblingOrder()
        {
            tlog.Debug(tag, $"LayoutGroupChangeLayoutSiblingOrder START");

            View parent = new View()
            {
                Layout = new AbsoluteLayout()
            };

            View child = new View()
            {
                Layout = new AbsoluteLayout(),
            };
            
            parent.Add(child);

            LayoutItem layout = new LayoutItem();
            layout.AttachToOwner(child);

            var testingTarget = layout.Owner.Layout as LayoutGroup;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should return LayoutGroup instance.");

            testingTarget.ChangeLayoutSiblingOrder(0);

            child.Dispose();
            parent.Dispose();
            layout.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutGroupChangeLayoutSiblingOrder END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup LayoutChildren")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.LayoutChildren A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupLayoutChildren()
        {
            tlog.Debug(tag, $"LayoutGroupLayoutChildren START");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should return LayoutGroup instance.");

            using (LayoutItem layoutItem = new LayoutItem())
            {
                testingTarget.Add(layoutItem);
                Assert.AreEqual(1, testingTarget.ChildCount(), "Should number of children added");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutGroupLayoutChildren END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("LayoutGroup Get measure specification")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.GetChildMeasureSpecification M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupGetChildMeasureSpecification()
        {
            tlog.Debug(tag, $"LayoutGroupGetChildMeasureSpecification START");

            MeasureSpecification parentMeasureSpec = new MeasureSpecification(new LayoutLength(10), MeasureSpecification.ModeType.Exactly);
            LayoutLength padding = new LayoutLength(0);
            LayoutLength childDimension = new LayoutLength(10);

            MeasureSpecification measureSpec = LayoutGroup.GetChildMeasureSpecification(parentMeasureSpec, padding, childDimension);

            Assert.AreEqual((double)(measureSpec.GetSize().AsRoundedValue()), 10.0f, "Should be the value set.");
            Assert.AreEqual(measureSpec.GetMode(), MeasureSpecification.ModeType.Exactly, "ModeType should match.");

            tlog.Debug(tag, $"LayoutGroupGetChildMeasureSpecification END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup OnMeasure")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.OnMeasure M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupOnMeasure()
        {
            tlog.Debug(tag, $"LayoutGroupOnMeasure START");

            flagOnMeasureOverride = false;
            Assert.False(flagOnMeasureOverride, "flagOnMeasureOverride should be false initial");

            LayoutItem layoutItem = new LinearLayout();

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150)
            };
            layoutItem.AttachToOwner(view);

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should be an instance of LayoutGroup type.");

            testingTarget.AttachToOwner(view);
            testingTarget.Add(layoutItem);

            MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.AtMost);
            MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.AtMost);

            testingTarget.OnMeasureTest(measureWidth, measureHeight);
            Assert.True(flagOnMeasureOverride, "LayoutGroup overridden method not invoked.");

            // Test LayoutChildren.Count == 0
            flagOnMeasureOverride = false;
            Assert.False(flagOnMeasureOverride, "flagOnMeasureOverride should be false initial");

            testingTarget.Remove(layoutItem);

            testingTarget.OnMeasureTest(measureWidth, measureHeight);
            Assert.True(flagOnMeasureOverride, "LayoutGroup overridden method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutGroupOnMeasure END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup OnLayout")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.OnLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupOnLayout()
        {
            tlog.Debug(tag, $"LayoutGroupOnLayout START");

            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should be an instance of LayoutGroup type.");

            using (LayoutItem child = new LayoutItem())
            {
                testingTarget.Add(child);

                View view = new View()
                {
                    Position = new Position(100, 150)
                };
                child.AttachToOwner(view);

                testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
                Assert.True(flagOnLayoutOverride, "LayoutGroup overridden method not invoked.");

                // Test with false parameter.
                flagOnLayoutOverride = false;
                Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");
                testingTarget.OnLayoutTest(false, new LayoutLength(10), new LayoutLength(10), new LayoutLength(20), new LayoutLength(20));
                Assert.True(flagOnLayoutOverride, "LayoutGroup overridden method not invoked.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutGroupOnLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup OnChildAdd")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.OnChildAdd M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupOnChildAdd()
        {
            tlog.Debug(tag, $"LayoutGroupOnChildAdd START");

            flagOnChildAddOverride = false;
            Assert.False(flagOnChildAddOverride, "flagOnChildAddOverride should be false initial");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should be an instance of LayoutGroup type.");

            using (LayoutItem child = new LayoutItem())
            {
                testingTarget.OnChildAddTest(child);
                Assert.True(flagOnChildAddOverride, "LayoutGroup overridden method not invoked.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutGroupOnChildAdd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup OnChildRemove")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.OnChildRemove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupOnChildRemove()
        {
            tlog.Debug(tag, $"LayoutGroupOnChildRemove START");

            flagOnChildRemoveOverride = false;
            Assert.False(flagOnChildRemoveOverride, "flagOnChildRemoveOverride should be false initially");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should be an instance of LayoutGroup type.");

            using (LayoutItem child = new LayoutItem())
            {
                testingTarget.OnChildRemoveTest(child);
                Assert.True(flagOnChildRemoveOverride, "LayoutGroup overridden method not invoked.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutGroupOnChildRemove END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup MeasureChild")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.MeasureChild M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupMeasureChild()
        {
            tlog.Debug(tag, $"LayoutGroupMeasureChild START");

            flagOnMeasureChild = false;
            Assert.False(flagOnMeasureChild, "flagOnMeasureChild should be false initially");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should be an instance of LayoutGroup type.");

            View view = new View()
            {
                Size = new Size(100, 150),
            };

            // MeasureSpecification.ModeType.Exactly
            using (LayoutItem child = new LayoutItem())
            {
                child.AttachToOwner(view);
                MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);
                MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);

                testingTarget.MeasureChildTest(child, measureWidth, measureHeight);
                Assert.True(flagOnMeasureChild, "LayoutGroup overridden method not invoked.");
            }

            // MeasureSpecification.ModeType.AtMost
            using (LayoutItem child = new LayoutItem())
            {
                child.AttachToOwner(view);
                MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.AtMost);
                MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.AtMost);

                testingTarget.MeasureChildTest(child, measureWidth, measureHeight);
                Assert.True(flagOnMeasureChild, "LayoutGroup overridden method not invoked.");
            }

            // MeasureSpecification.ModeType.Unspecified
            using (LayoutItem child = new LayoutItem())
            {
                child.AttachToOwner(view);
                MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Unspecified);
                MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Unspecified);

                testingTarget.MeasureChildTest(child, measureWidth, measureHeight);
                Assert.True(flagOnMeasureChild, "LayoutGroup overridden method not invoked.");
            }

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutGroupMeasureChild END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("LayoutGroup MeasureChild. With null argument.")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.MeasureChild M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupMeasureChildWithNullArgument()
        {
            tlog.Debug(tag, $"LayoutGroupMeasureChildWithNullArgument START");

            flagOnMeasureChild = false;
            Assert.False(flagOnMeasureChild, "flagOnMeasureChild should be false initially");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should be an instance of LayoutGroup type.");

            MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);
            MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);

            try
            {
                testingTarget.MeasureChildTest(null, measureWidth, measureHeight);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"LayoutGroupMeasureChildWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup MeasureChildren")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.MeasureChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupMeasureChildren()
        {
            tlog.Debug(tag, $"LayoutGroupMeasureChildren START");

            flagOnMeasureChild = false;
            Assert.False(flagOnMeasureChild, "flagOnMeasureChild should be false initially");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should be an instance of LayoutGroup type.");

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150)
            };

            using (LayoutItem child = new LayoutItem())
            {
                child.AttachToOwner(view);
                testingTarget.Add(child);

                MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);
                MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);

                testingTarget.MeasureChildrenTest(measureWidth, measureHeight);
                Assert.True(flagOnMeasureChild, "LayoutGroup MeasureChild method not invoked when children measured.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutGroupMeasureChildren END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup MeasureChildWithMargins")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.MeasureChildWithMargins M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupMeasureChildWithMargins()
        {
            tlog.Debug(tag, $"LayoutGroupMeasureChildWithMargins START");

            flagOnMeasureChild = false;
            Assert.False(flagOnMeasureChild, "flagOnMeasureChild should be false initially");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should be an instance of LayoutGroup type.");

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150)
            };

            using (LayoutItem child = new LayoutItem())
            {
                child.AttachToOwner(view);
                testingTarget.Add(child);

                MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);
                MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);

                testingTarget.MeasureChildWithMarginsTest(child, measureWidth, new LayoutLength(10), measureHeight, new LayoutLength(10));
                Assert.True(flagOnMeasureChild, "LayoutGroup MeasureChild method not invoked when children measured.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutGroupMeasureChildWithMargins END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("LayoutGroup MeasureChildWithMargins. With null argument.")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.MeasureChildWithMargins M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupMeasureChildWithMarginsWithNullArgument()
        {
            tlog.Debug(tag, $"LayoutGroupMeasureChildWithMarginsWithNullArgument START");

            flagOnMeasureChild = false;
            Assert.False(flagOnMeasureChild, "flagOnMeasureChild should be false initially");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should be an instance of LayoutGroup type.");

            MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);
            MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);

            try
            {
                testingTarget.MeasureChildWithMarginsTest(null, measureWidth, new LayoutLength(10), measureHeight, new LayoutLength(10));
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"LayoutGroupMeasureChildWithMarginsWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            } 
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup MeasureChildWithoutPadding")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.MeasureChildWithoutPadding M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupMeasureChildWithoutPadding()
        {
            tlog.Debug(tag, $"LayoutGroupMeasureChildWithoutPadding START");

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should be an instance of LayoutGroup type.");

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150)
            };

            using (LayoutItem child = new LayoutItem())
            {
                child.AttachToOwner(view);
                testingTarget.Add(child);

                MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);
                MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);

                try
                {
                    testingTarget.MeasureChildWithoutPaddingTest(child, measureWidth, measureHeight);
                }
                catch (Exception e)
                {
                    tlog.Error(tag, "Caught Exception" + e.ToString());
                    LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                    Assert.Fail("Caught Exception" + e.ToString());
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutGroupMeasureChildWithoutPadding END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup OnAttachedToOwner")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.OnAttachedToOwner M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupOnAttachedToOwner()
        {
            tlog.Debug(tag, $"LayoutGroupOnAttachedToOwner START");

            using (View owner = new View())
            {
                TextLabel textLabel = new TextLabel()
                {
                    ExcludeLayouting = false,
                    Size = new Size(100, 150),
                    Layout = new AbsoluteLayout(),
                };

                owner.Add(textLabel);

                using (MyLayoutGroup testingTarget = new MyLayoutGroup())
                {
                    try
                    {
                        testingTarget.AttachToOwner(owner);
                    }
                    catch (Exception e)
                    {
                        tlog.Error(tag, "Caught Exception" + e.ToString());
                        LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                        Assert.Fail("Caught Exception" + e.ToString());
                    }
                }

                textLabel.Dispose();
            }

            tlog.Debug(tag, $"LayoutGroupOnAttachedToOwner END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup OnLayoutIndependentChildren")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.OnLayoutIndependentChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupOnLayoutIndependentChildren()
        {
            tlog.Debug(tag, $"LayoutGroupOnLayoutIndependentChildren START");

            using (View owner = new View())
            {
                TextLabel textLabel = new TextLabel()
                {
                    ExcludeLayouting = false,
                    Size = new Size(100, 150),
                    Layout = new AbsoluteLayout(),
                };

                owner.Add(textLabel);

                using (MyLayoutGroup testingTarget = new MyLayoutGroup())
                {
                    testingTarget.AttachToOwner(owner);
                    try
                    {
                        testingTarget.OnLayoutIndependentChildren(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(5), new LayoutLength(5));
                    }
                    catch (Exception e)
                    {
                        tlog.Error(tag, "Caught Exception" + e.ToString());
                        LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                        Assert.Fail("Caught Exception" + e.ToString());
                    }
                }

                textLabel.Dispose();
            }

            tlog.Debug(tag, $"LayoutGroupOnLayoutIndependentChildren END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutGroup RemoveChildFromLayoutGroup")]
        [Property("SPEC", "Tizen.NUI.LayoutGroup.RemoveChildFromLayoutGroup M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutGroupRemoveChildFromLayoutGroup()
        {
            tlog.Debug(tag, $"LayoutGroupRemoveChildFromLayoutGroup START");

            LayoutItem layoutItem = new AbsoluteLayout();

            View parent = new View();

            View child = new View()
            {
                ExcludeLayouting = false,
                Layout = new AbsoluteLayout()
            };

            parent.Add(child);

            layoutItem.AttachToOwner(child);

            var testingTarget = new MyLayoutGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should be an instance of LayoutGroup type.");

            testingTarget.Add(layoutItem);

            try
            {
                testingTarget.RemoveChildFromLayoutGroup(child);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"LayoutGroupRemoveChildFromLayoutGroup END (OK)");
        }
    }
}
