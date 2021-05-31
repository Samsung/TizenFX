using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Layouting/RelativeLayout")]

    public class PublicRelativeLayoutTest
    {
        private const string tag = "NUITEST";
        private static bool flagOnMeasureOverride;
        private static bool flagOnLayoutOverride;
        internal class MyRelativeLayout : RelativeLayout
        {
            public MyRelativeLayout() : base()
            { }

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
        [Description("RelativeLayout constructor")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.RelativeLayout C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutConstructor()
        {
            tlog.Debug(tag, $"RelativeLayoutConstructor START");

            var testingTarget = new RelativeLayout();
            Assert.IsNotNull(testingTarget, "Can't create success object PaddingType");
            Assert.IsInstanceOf<RelativeLayout>(testingTarget, "Should be an instance of RelativeLayout type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeLayoutConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout SetLeftTarget.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetLeftTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetLeftTarget()
        {
            tlog.Debug(tag, $"RelativeLayoutSetLeftTarget START");

            using (View child = new View())
            {
                using (View target = new View())
                {
                    RelativeLayout.SetLeftTarget(child, target);
                    Assert.AreEqual(RelativeLayout.GetLeftTarget(child), target, $"Should be {target}.");

                    RelativeLayout.SetLeftTarget(child, null);
                    Assert.AreEqual(RelativeLayout.GetLeftTarget(child), null, "Should be null.");
                }
            }

            tlog.Debug(tag, $"RelativeLayoutSetLeftTarget END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetLeftTarget. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetLeftTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetLeftTargetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutSetLeftTargetWithNullArgument START");

            View target = new View();
            try
            {
                RelativeLayout.SetLeftTarget(null, target);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                target.Dispose();
                tlog.Debug(tag, $"RelativeLayoutSetLeftTargetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetLeftTarget. With null argument and null reference.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetLeftTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetLeftTargetWithNullArgumentReference()
        {
            tlog.Debug(tag, $"RelativeLayoutSetLeftTargetWithNullArgumentReference START");

            try
            {
                RelativeLayout.SetLeftTarget(null, null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutSetLeftTargetWithNullArgumentReference END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout GetLeftTarget.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetLeftTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetLeftTarget()
        {
            tlog.Debug(tag, $"RelativeLayoutGetLeftTarget START");

            using (View child = new View())
            {
                using (View target = new View())
                {
                    RelativeLayout.SetLeftTarget(child, target);
                    Assert.AreEqual(RelativeLayout.GetLeftTarget(child), target, $"Should be {target}.");
                }
            }

            tlog.Debug(tag, $"RelativeLayoutGetLeftTarget END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout GetLeftTarget. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetLeftTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetLeftTargetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutGetLeftTargetWithNullArgument START");

            try
            {
                RelativeLayout.GetLeftTarget(null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutGetLeftTargetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout SetRightTarget.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetRightTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetRightTarget()
        {
            tlog.Debug(tag, $"RelativeLayoutSetRightTarget START");

            using (View child = new View())
            {
                using (View target = new View())
                {
                    RelativeLayout.SetRightTarget(child, target);
                    Assert.AreEqual(RelativeLayout.GetRightTarget(child), target, $"Should be {target}.");

                    RelativeLayout.SetRightTarget(child, null);
                    Assert.AreEqual(RelativeLayout.GetRightTarget(child), null, "Should be null.");
                }
            }

            tlog.Debug(tag, $"RelativeLayoutSetRightTarget END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetRightTarget. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetRightTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetRightTargetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutSetRightTargetWithNullArgument START");

            View target = new View();
            try
            {
                RelativeLayout.SetRightTarget(null, target);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                target.Dispose();
                tlog.Debug(tag, $"RelativeLayoutSetRightTargetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetRightTarget. With null argument and null reference.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetRightTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetRightTargetWithNullArgumentReference()
        {
            tlog.Debug(tag, $"RelativeLayoutSetRightTargetWithNullArgumentReference START");

            try
            {
                RelativeLayout.SetRightTarget(null, null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutSetRightTargetWithNullArgumentReference END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout GetRightTarget.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetRightTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetRightTarget()
        {
            tlog.Debug(tag, $"RelativeLayoutGetRightTarget START");

            using (View child = new View())
            {
                using (View target = new View())
                {
                    RelativeLayout.SetRightTarget(child, target);
                    Assert.AreEqual(RelativeLayout.GetRightTarget(child), target, $"Should be {target}.");
                }
            }

            tlog.Debug(tag, $"RelativeLayoutGetRightTarget END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout GetRightTarget. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetRightTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetRightTargetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutGetRightTargetWithNullArgument START");

            try
            {
                RelativeLayout.GetRightTarget(null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutGetRightTargetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout SetTopTarget.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetTopTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetTopTarget()
        {
            tlog.Debug(tag, $"RelativeLayoutSetTopTarget START");

            using (View child = new View())
            {
                using (View target = new View())
                {
                    RelativeLayout.SetTopTarget(child, target);
                    Assert.AreEqual(RelativeLayout.GetTopTarget(child), target, $"Should be {target}.");

                    RelativeLayout.SetTopTarget(child, null);
                    Assert.AreEqual(RelativeLayout.GetTopTarget(child), null, "Should be null.");
                }
            }

            tlog.Debug(tag, $"RelativeLayoutSetTopTarget END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetTopTarget. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetTopTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetTopTargetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutSetTopTarget START");

            View target = new View();
            try
            {
                RelativeLayout.SetTopTarget(null, target);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                target.Dispose();
                tlog.Debug(tag, $"RelativeLayoutSetTopTarget END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetTopTarget. With null argument and null reference.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetTopTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetTopTargetWithNullArgumentReference()
        {
            tlog.Debug(tag, $"RelativeLayoutSetTopTargetWithNullArgumentReference START");

            try
            {
                RelativeLayout.SetTopTarget(null, null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutSetTopTargetWithNullArgumentReference END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout GetTopTarget.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetTopTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetTopTarget()
        {
            tlog.Debug(tag, $"RelativeLayoutGetTopTarget START");

            using (View child = new View())
            {
                using (View target = new View())
                {
                    RelativeLayout.SetTopTarget(child, target);
                    Assert.AreEqual(RelativeLayout.GetTopTarget(child), target, $"Should be {target}.");

                }
            }

            tlog.Debug(tag, $"RelativeLayoutGetTopTarget END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout GetTopTarget. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetTopTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetTopTargetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutGetTopTargetWithNullArgument START");

            try
            {
                RelativeLayout.GetTopTarget(null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutGetTopTargetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout SetBottomTarget.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetBottomTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetBottomTarget()
        {
            tlog.Debug(tag, $"RelativeLayoutSetBottomTarget START");

            using (View child = new View())
            {
                using (View target = new View())
                {
                    RelativeLayout.SetBottomTarget(child, target);
                    Assert.AreEqual(RelativeLayout.GetBottomTarget(child), target, $"Should be {target}.");

                    RelativeLayout.SetBottomTarget(child, null);
                    Assert.AreEqual(RelativeLayout.GetBottomTarget(child), null, "Should be null.");
                }
            }

            tlog.Debug(tag, $"RelativeLayoutSetBottomTarget END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetBottomTarget. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetBottomTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetBottomTargetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutSetBottomTargetWithNullArgument START");

            View target = new View();
            try
            {
                RelativeLayout.SetBottomTarget(null, target);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                target.Dispose();
                tlog.Debug(tag, $"RelativeLayoutSetBottomTargetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetBottomTarget. With null argument and null reference.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetBottomTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetBottomTargetWithNullArgumentReference()
        {
            tlog.Debug(tag, $"RelativeLayoutSetBottomTargetWithNullArgumentReference START");

            try
            {
                RelativeLayout.SetBottomTarget(null, null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutSetBottomTargetWithNullArgumentReference END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout GetBottomTarget.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetBottomTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetBottomTarget()
        {
            tlog.Debug(tag, $"RelativeLayoutGetBottomTarget START");

            using (View child = new View())
            {
                using (View target = new View())
                {
                    RelativeLayout.SetBottomTarget(child, target);
                    Assert.AreEqual(RelativeLayout.GetBottomTarget(child), target, $"Should be {target}.");
                }
            }

            tlog.Debug(tag, $"RelativeLayoutGetBottomTarget END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout GetBottomTarget. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetBottomTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetBottomTargetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutGetBottomTargetWithNullArgument START");

            try
            {
                RelativeLayout.GetBottomTarget(null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutGetBottomTargetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout SetLeftRelativeOffset.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetLeftRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetLeftRelativeOffset()
        {
            tlog.Debug(tag, $"RelativeLayoutGetBottomTargetWithNullArgument START");

            using (View child = new View())
            {
                RelativeLayout.SetLeftRelativeOffset(child, 0.0f);
                Assert.AreEqual(RelativeLayout.GetLeftRelativeOffset(child), 0.0f, "Should be 0.0.");

                RelativeLayout.SetLeftRelativeOffset(child, -1.0f);
                Assert.AreEqual(RelativeLayout.GetLeftRelativeOffset(child), -1.0f, "Should be -1.0f.");
            }

            tlog.Debug(tag, $"RelativeLayoutGetBottomTargetWithNullArgument END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetLeftRelativeOffset. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetLeftRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetLeftRelativeOffsetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutSetLeftRelativeOffsetWithNullArgument START");

            try
            {
                RelativeLayout.SetLeftRelativeOffset(null, 0.0f);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutSetLeftRelativeOffsetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout GetLeftRelativeOffset.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetLeftRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetLeftRelativeOffset()
        {
            tlog.Debug(tag, $"RelativeLayoutGetLeftRelativeOffset START");

            using (View child = new View())
            {
                RelativeLayout.SetLeftRelativeOffset(child, 0.0f);
                Assert.AreEqual(RelativeLayout.GetLeftRelativeOffset(child), 0.0f, "Should be 0.0.");
            }

            tlog.Debug(tag, $"RelativeLayoutGetLeftRelativeOffset END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout GetLeftRelativeOffset. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetLeftRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetLeftRelativeOffsetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutGetLeftRelativeOffsetWithNullArgument START");

            try
            {
                RelativeLayout.GetLeftRelativeOffset(null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutGetLeftRelativeOffsetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout SetRightRelativeOffset.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetRightRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetRightRelativeOffset()
        {
            tlog.Debug(tag, $"RelativeLayoutSetRightRelativeOffset START");

            using (View child = new View())
            {
                RelativeLayout.SetRightRelativeOffset(child, 0.0f);
                Assert.AreEqual(RelativeLayout.GetRightRelativeOffset(child), 0.0f, "Should be 0.0.");

                RelativeLayout.SetRightRelativeOffset(child, -1.0f);
                Assert.AreEqual(RelativeLayout.GetRightRelativeOffset(child), -1.0f, "Should be -1.0f.");
            }

            tlog.Debug(tag, $"RelativeLayoutSetRightRelativeOffset END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetRightRelativeOffset. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetRightRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetRightRelativeOffsetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutSetRightRelativeOffsetWithNullArgument START");

            try
            {
                RelativeLayout.SetRightRelativeOffset(null, 0.0f);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutSetRightRelativeOffsetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout GetRightRelativeOffset.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetRightRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetRightRelativeOffset()
        {
            tlog.Debug(tag, $"RelativeLayoutGetRightRelativeOffset START");

            using (View child = new View())
            {
                RelativeLayout.SetRightRelativeOffset(child, 0.0f);
                Assert.AreEqual(RelativeLayout.GetRightRelativeOffset(child), 0.0f, "Should be 0.0.");
            }

            tlog.Debug(tag, $"RelativeLayoutGetRightRelativeOffset END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout GetRightRelativeOffset. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetRightRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetRightRelativeOffsetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutGetRightRelativeOffsetWithNullArgument START");

            try
            {
                RelativeLayout.GetRightRelativeOffset(null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutGetRightRelativeOffsetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout SetTopRelativeOffset.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetTopRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetTopRelativeOffset()
        {
            tlog.Debug(tag, $"RelativeLayoutSetTopRelativeOffset START");

            using (View child = new View())
            {
                RelativeLayout.SetTopRelativeOffset(child, 0.0f);
                Assert.AreEqual(RelativeLayout.GetTopRelativeOffset(child), 0.0f, "Should be 0.0.");

                RelativeLayout.SetTopRelativeOffset(child, -1.0f);
                Assert.AreEqual(RelativeLayout.GetTopRelativeOffset(child), -1.0f, "Should be -1.0f.");
            }

            tlog.Debug(tag, $"RelativeLayoutSetTopRelativeOffset END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetTopRelativeOffset. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetTopRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetTopRelativeOffsetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutSetTopRelativeOffsetWithNullArgument START");

            try
            {
                RelativeLayout.SetTopRelativeOffset(null, 0.0f);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutSetTopRelativeOffsetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout GetTopRelativeOffset.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetTopRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetTopRelativeOffset()
        {
            tlog.Debug(tag, $"RelativeLayoutGetTopRelativeOffset START");

            using (View child = new View())
            {
                RelativeLayout.SetTopRelativeOffset(child, 0.0f);
                Assert.AreEqual(RelativeLayout.GetTopRelativeOffset(child), 0.0f, "Should be 0.0.");
            }

            tlog.Debug(tag, $"RelativeLayoutGetTopRelativeOffset END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout GetTopRelativeOffset. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetTopRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetTopRelativeOffsetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutGetTopRelativeOffsetWithNullArgument START");

            try
            {
                RelativeLayout.GetTopRelativeOffset(null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutGetTopRelativeOffsetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout SetBottomRelativeOffset.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetBottomRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetBottomRelativeOffset()
        {
            tlog.Debug(tag, $"RelativeLayoutSetBottomRelativeOffset START");

            using (View child = new View())
            {
                RelativeLayout.SetBottomRelativeOffset(child, 0.0f);
                Assert.AreEqual(RelativeLayout.GetBottomRelativeOffset(child), 0.0f, "Should be 0.0.");

                RelativeLayout.SetBottomRelativeOffset(child, -1.0f);
                Assert.AreEqual(RelativeLayout.GetBottomRelativeOffset(child), -1.0f, "Should be -1.0f.");
            }

            tlog.Debug(tag, $"RelativeLayoutSetBottomRelativeOffset END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetBottomRelativeOffset. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetBottomRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetBottomRelativeOffsetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutSetBottomRelativeOffsetWithNullArgument START");

            try
            {
                RelativeLayout.SetBottomRelativeOffset(null, 0.0f);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutSetBottomRelativeOffsetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout GetBottomRelativeOffset.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetBottomRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetBottomRelativeOffset()
        {
            tlog.Debug(tag, $"RelativeLayoutGetBottomRelativeOffset START");

            using (View child = new View())
            {
                RelativeLayout.SetBottomRelativeOffset(child, 0.0f);
                Assert.AreEqual(RelativeLayout.GetBottomRelativeOffset(child), 0.0f, "Should be 0.0.");
            }

            tlog.Debug(tag, $"RelativeLayoutGetBottomRelativeOffset END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout GetBottomRelativeOffset. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetBottomRelativeOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetBottomRelativeOffsetWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutGetBottomRelativeOffsetWithNullArgument START");

            try
            {
                RelativeLayout.GetBottomRelativeOffset(null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutGetBottomRelativeOffsetWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout SetHorizontalAlignment.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetHorizontalAlignment M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetHorizontalAlignment()
        {
            tlog.Debug(tag, $"RelativeLayoutSetHorizontalAlignment START");

            using (View child = new View())
            {
                RelativeLayout.SetHorizontalAlignment(child, RelativeLayout.Alignment.Start);
                Assert.AreEqual(RelativeLayout.GetHorizontalAlignment(child), RelativeLayout.Alignment.Start, "Should be RelativeLayout.Alignment.Start.");

                RelativeLayout.SetHorizontalAlignment(child, RelativeLayout.Alignment.Center);
                Assert.AreEqual(RelativeLayout.GetHorizontalAlignment(child), RelativeLayout.Alignment.Center, "Should be RelativeLayout.Alignment.Center.");

                RelativeLayout.SetHorizontalAlignment(child, RelativeLayout.Alignment.End);
                Assert.AreEqual(RelativeLayout.GetHorizontalAlignment(child), RelativeLayout.Alignment.End, "Should be RelativeLayout.Alignment.End.");
            }

            tlog.Debug(tag, $"RelativeLayoutSetHorizontalAlignment END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetHorizontalAlignment. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetHorizontalAlignment M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetHorizontalAlignmentWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutSetHorizontalAlignmentWithNullArgument START");

            try
            {
                RelativeLayout.SetHorizontalAlignment(null, RelativeLayout.Alignment.End);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutSetHorizontalAlignmentWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout GetHorizontalAlignment.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetHorizontalAlignment M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetHorizontalAlignment()
        {
            tlog.Debug(tag, $"RelativeLayoutGetHorizontalAlignment START");

            using (View child = new View())
            {
                RelativeLayout.SetHorizontalAlignment(child, RelativeLayout.Alignment.Start);
                Assert.AreEqual(RelativeLayout.GetHorizontalAlignment(child), RelativeLayout.Alignment.Start, "Should be RelativeLayout.Alignment.Start.");
            }

            tlog.Debug(tag, $"RelativeLayoutGetHorizontalAlignment END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout GetHorizontalAlignment. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetHorizontalAlignment M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetHorizontalAlignmentWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutGetHorizontalAlignmentWithNullArgument START");

            try
            {
                RelativeLayout.GetHorizontalAlignment(null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutGetHorizontalAlignmentWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout SetVerticalAlignment.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetVerticalAlignment M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetVerticalAlignment()
        {
            tlog.Debug(tag, $"RelativeLayoutSetVerticalAlignment START");

            using (View child = new View())
            {
                RelativeLayout.SetVerticalAlignment(child, RelativeLayout.Alignment.Start);
                Assert.AreEqual(RelativeLayout.GetVerticalAlignment(child), RelativeLayout.Alignment.Start, "Should be RelativeLayout.Alignment.Start.");

                RelativeLayout.SetVerticalAlignment(child, RelativeLayout.Alignment.Center);
                Assert.AreEqual(RelativeLayout.GetVerticalAlignment(child), RelativeLayout.Alignment.Center, "Should be RelativeLayout.Alignment.Center.");

                RelativeLayout.SetVerticalAlignment(child, RelativeLayout.Alignment.End);
                Assert.AreEqual(RelativeLayout.GetVerticalAlignment(child), RelativeLayout.Alignment.End, "Should be RelativeLayout.Alignment.End.");
            }

            tlog.Debug(tag, $"RelativeLayoutSetVerticalAlignment END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetVerticalAlignment. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetVerticalAlignment M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetVerticalAlignmentWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutSetVerticalAlignmentWithNullArgument START");

            try
            {
                RelativeLayout.SetVerticalAlignment(null, RelativeLayout.Alignment.End);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutSetVerticalAlignmentWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout GetVerticalAlignment.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetVerticalAlignment M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetVerticalAlignment()
        {
            tlog.Debug(tag, $"RelativeLayoutGetVerticalAlignment START");

            using (View child = new View())
            {
                RelativeLayout.SetVerticalAlignment(child, RelativeLayout.Alignment.Start);
                Assert.AreEqual(RelativeLayout.GetVerticalAlignment(child), RelativeLayout.Alignment.Start, "Should be RelativeLayout.Alignment.Start.");
            }

            tlog.Debug(tag, $"RelativeLayoutGetVerticalAlignment END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout GetVerticalAlignment. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetVerticalAlignment M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetVerticalAlignmentWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutGetVerticalAlignmentWithNullArgument START");

            try
            {
                RelativeLayout.GetVerticalAlignment(null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutGetVerticalAlignmentWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout SetFillHorizontal.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetFillHorizontal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetFillHorizontal()
        {
            tlog.Debug(tag, $"RelativeLayoutGetVerticalAlignmentWithNullArgument START");

            using (View child = new View())
            {
                RelativeLayout.SetFillHorizontal(child, true);
                Assert.AreEqual(RelativeLayout.GetFillHorizontal(child), true, "Should be true");

                RelativeLayout.SetFillHorizontal(child, false);
                Assert.AreEqual(RelativeLayout.GetFillHorizontal(child), false, "Should be false");
            }

            tlog.Debug(tag, $"RelativeLayoutGetVerticalAlignmentWithNullArgument END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetFillHorizontal. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetFillHorizontal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetFillHorizontalWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutSetFillHorizontalWithNullArgument START");

            try
            {
                RelativeLayout.SetFillHorizontal(null, true);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutSetFillHorizontalWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout GetFillHorizontal.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetFillHorizontal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetFillHorizontal()
        {
            tlog.Debug(tag, $"RelativeLayoutGetFillHorizontal START");

            using (View child = new View())
            {
                RelativeLayout.SetFillHorizontal(child, true);
                Assert.AreEqual(RelativeLayout.GetFillHorizontal(child), true, "Should be true.");
            }

            tlog.Debug(tag, $"RelativeLayoutGetFillHorizontal END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout GetFillHorizontal. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetFillHorizontal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetFillHorizontalWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutGetFillHorizontalWithNullArgument START");

            try
            {
                RelativeLayout.GetFillHorizontal(null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutGetFillHorizontalWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout SetFillVertical.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetFillVertical M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetFillVertical()
        {
            tlog.Debug(tag, $"RelativeLayoutGetFillHorizontalWithNullArgument START");

            using (View child = new View())
            {
                RelativeLayout.SetFillVertical(child, true);
                Assert.AreEqual(RelativeLayout.GetFillVertical(child), true, "Should be true");

                RelativeLayout.SetFillVertical(child, false);
                Assert.AreEqual(RelativeLayout.GetFillVertical(child), false, "Should be false");
            }

            tlog.Debug(tag, $"RelativeLayoutGetFillHorizontalWithNullArgument END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout SetFillVertical. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.SetFillVertical M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutSetFillVerticalWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutSetFillVerticalWithNullArgument START");

            try
            {
                RelativeLayout.SetFillVertical(null, true);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutSetFillVerticalWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout GetFillVertical.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetFillVertical M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetFillVertical()
        {
            tlog.Debug(tag, $"RelativeLayoutGetFillVertical START");

            using (View child = new View())
            {
                RelativeLayout.SetFillVertical(child, true);
                Assert.AreEqual(RelativeLayout.GetFillVertical(child), true, "Should be true.");
            }

            tlog.Debug(tag, $"RelativeLayoutGetFillVertical END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RelativeLayout GetFillVertical. With null argument.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.GetFillVertical M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MEX")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutGetFillVerticalWithNullArgument()
        {
            tlog.Debug(tag, $"RelativeLayoutGetFillVerticalWithNullArgument START");

            try
            {
                RelativeLayout.GetFillVertical(null);
                Assert.Fail("Should return null argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"RelativeLayoutGetFillVerticalWithNullArgument END (OK)");
                Assert.Pass("ArgumentNullException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout OnMeasure.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.OnMeasure M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutOnMeasure()
        {
            tlog.Debug(tag, $"RelativeLayoutOnMeasure START");

            flagOnMeasureOverride = false;
            Assert.False(flagOnMeasureOverride, "flagOnMeasureOverride should be false initial");

            LayoutItem layoutItem = new LinearLayout();

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150),
                Layout = new RelativeLayout()
            };

            layoutItem.AttachToOwner(view);

            var testingTarget = new MyRelativeLayout();
            Assert.IsNotNull(testingTarget, "Should not be null.");
            Assert.IsInstanceOf<RelativeLayout>(testingTarget, "Should be an instance of RelativeLayout type.");

            testingTarget.AttachToOwner(view);
            testingTarget.Add(layoutItem);

            MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);
            MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);

            testingTarget.OnMeasureTest(measureWidth, measureHeight);
            Assert.True(flagOnMeasureOverride, "RelativeLayout overridden method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeLayoutOnMeasure END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeLayout OnLayout.")]
        [Property("SPEC", "Tizen.NUI.RelativeLayout.OnLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeLayoutOnLayout()
        {
            tlog.Debug(tag, $"RelativeLayoutOnLayout START");

            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            LayoutItem layoutItem = new LinearLayout();

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150),
                Layout = new RelativeLayout()
            };

            layoutItem.AttachToOwner(view);

            var testingTarget = new MyRelativeLayout();
            Assert.IsNotNull(testingTarget, "Should not be null.");
            Assert.IsInstanceOf<RelativeLayout>(testingTarget, "Should be an instance of RelativeLayout type.");

            testingTarget.AttachToOwner(view);
            testingTarget.Add(layoutItem);

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "RelativeLayout overridden method not invoked.");

            // Test with false parameter
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");
            testingTarget.OnLayoutTest(false, new LayoutLength(10), new LayoutLength(10), new LayoutLength(20), new LayoutLength(20));
            Assert.True(flagOnLayoutOverride, "RelativeLayout overridden method not invoked.");

            tlog.Debug(tag, $"RelativeLayoutOnLayout END (OK)");
        }
    }
}
