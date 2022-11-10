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
    [Description("public/BaseComponents/ViewAccessibility")]
    public class PublicViewAccessibilityTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/picture.png";
        private string lottiePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/lottie.json";

        internal class MyView : View
        {
            public MyView() : base()
            { }

            public string GetAccessibilityAttributes(string key)
            {
                return AccessibilityAttributes[key];
            }

            public void SetAccessibilityAttributes(string key, string value)
            {
                AccessibilityAttributes[key] = value;
            }

            public void ClearAccessibilityAttributes()
            {
                AccessibilityAttributes.Clear();
            }

            public void RemoveAccessibilityAttributes(string key)
            {
                AccessibilityAttributes.Remove(key);
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
        [Description("ViewAccessibility.AccessibilityRange StartOffset.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.AccessibilityRange.StartOffset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityAccessibilityRangeStartOffset()
        {
            tlog.Debug(tag, $"ViewAccessibilityAccessibilityRangeStartOffset START");

            var testingTarget = new AccessibilityRange();
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityRange");
            Assert.IsInstanceOf<AccessibilityRange>(testingTarget, "Should be an instance of AccessibilityRange type.");

            testingTarget.StartOffset = 10;
            Assert.AreEqual(10, testingTarget.StartOffset, "Should be equal!");

            tlog.Debug(tag, $"ViewAccessibilityAccessibilityRangeStartOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.AccessibilityRange EndOffset.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.AccessibilityRange.EndOffset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityAccessibilityRangeEndOffset()
        {
            tlog.Debug(tag, $"ViewAccessibilityAccessibilityRangeEndOffset START");

            var testingTarget = new AccessibilityRange();
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityRange");
            Assert.IsInstanceOf<AccessibilityRange>(testingTarget, "Should be an instance of AccessibilityRange type.");

            testingTarget.EndOffset = 30;
            Assert.AreEqual(30, testingTarget.EndOffset, "Should be equal!");

            tlog.Debug(tag, $"ViewAccessibilityAccessibilityRangeEndOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.AccessibilityRange Content.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.AccessibilityRange.Content A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityAccessibilityRangeContent()
        {
            tlog.Debug(tag, $"ViewAccessibilityAccessibilityRangeContent START");

            var testingTarget = new AccessibilityRange();
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityRange");
            Assert.IsInstanceOf<AccessibilityRange>(testingTarget, "Should be an instance of AccessibilityRange type.");

            testingTarget.Content = "TextLabel";
            Assert.AreEqual("TextLabel", testingTarget.Content, "Should be equal!");

            tlog.Debug(tag, $"ViewAccessibilityAccessibilityRangeContent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.View.AccessibilityAttributes.Remove.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.View.AccessibilityAttributes.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityViewRemoveAccessibilityAttribute()
        {
            tlog.Debug(tag, $"ViewAccessibilityViewRemoveAccessibilityAttribute START");

            var testingTarget = new MyView();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.SetAccessibilityAttributes("view", "test");
            var result = testingTarget.GetAccessibilityAttributes("view");
            Assert.AreEqual("test", result, "Should be equal.");

            try
            {
                testingTarget.RemoveAccessibilityAttributes("view");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewAccessibilityViewRemoveAccessibilityAttribute END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.View.AccessibilityAttributes.Clear.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.View.AccessibilityAttributes.Clear MR")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityViewClearAccessibilityAttributes()
        {
            tlog.Debug(tag, $"ViewAccessibilityViewClearAccessibilityAttributes START");

            var testingTarget = new MyView();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.SetAccessibilityAttributes("view", "test");

            try
            {
                testingTarget.ClearAccessibilityAttributes();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewAccessibilityViewClearAccessibilityAttributes END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.View.ClearAccessibilityHighlight.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.View.ClearAccessibilityHighlight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityViewClearAccessibilityHighlight()
        {
            tlog.Debug(tag, $"ViewAccessibilityViewClearAccessibilityHighlight START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.AccessibilityHighlightable = true;

            try
            {
                var result = testingTarget.ClearAccessibilityHighlight();
                tlog.Debug(tag, "ClearAccessibilityHighlight : " + result);

                result = testingTarget.GrabAccessibilityHighlight();
                tlog.Debug(tag, "GrabAccessibilityHighlight : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewAccessibilityViewClearAccessibilityHighlight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.View.AppendAccessibilityRelation.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.View.AppendAccessibilityRelation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityViewAppendAccessibilityRelation()
        {
            tlog.Debug(tag, $"ViewAccessibilityViewAppendAccessibilityRelation START");

            var testingTarget = new View()
            {
                Size = new Size2D(100, 100),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.TopCenter,
                BackgroundColor = Color.AquaMarine,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            using (View child = new View())
            {
                try
                {
                    testingTarget.AppendAccessibilityRelation(child, AccessibilityRelationType.MemberOf);
                    var result = testingTarget.GetAccessibilityRelations();
                    tlog.Debug(tag, "AccessibilityRelations : " + result);

                    testingTarget.RemoveAccessibilityRelation(child, AccessibilityRelationType.MemberOf);
                    testingTarget.ClearAccessibilityRelations();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewAccessibilityViewAppendAccessibilityRelation END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ViewAccessibility.View.AppendAccessibilityRelation.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.View.AppendAccessibilityRelation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityViewAppendAccessibilityRelationNullValue()
        {
            tlog.Debug(tag, $"ViewAccessibilityViewAppendAccessibilityRelationNullValue START");

            var testingTarget = new View()
            {
                Size = new Size2D(100, 100),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.TopCenter,
                BackgroundColor = Color.AquaMarine,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            View child = null;
            try
            {
                testingTarget.AppendAccessibilityRelation(child, AccessibilityRelationType.MemberOf);
            }
            catch (ArgumentNullException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"ViewAccessibilityViewAppendAccessibilityRelationNullValue END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.View.SetAccessibilityReadingInfoTypes.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.View.SetAccessibilityReadingInfoTypes M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityViewSetAccessibilityReadingInfoTypes()
        {
            tlog.Debug(tag, $"ViewAccessibilityViewSetAccessibilityReadingInfoTypes START");

            var testingTarget = new View()
            {
                Size = new Size2D(100, 100),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.TopCenter,
                BackgroundColor = Color.AquaMarine,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");


            testingTarget.SetAccessibilityReadingInfoTypes(AccessibilityReadingInfoTypes.Description);
            var result = testingTarget.GetAccessibilityReadingInfoTypes();
            tlog.Debug(tag, "AccessibilityReadingInfoTypes : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewAccessibilityViewSetAccessibilityReadingInfoTypes END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.View.NotifyAccessibilityStatesChange.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.View.NotifyAccessibilityStatesChange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityViewNotifyAccessibilityStatesChange()
        {
            tlog.Debug(tag, $"ViewAccessibilityViewNotifyAccessibilityStatesChange START");

            var testingTarget = new View()
            {
                Size = new Size2D(100, 100),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.TopCenter,
                BackgroundColor = Color.AquaMarine,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.NotifyAccessibilityStatesChange(new AccessibilityStates(AccessibilityState.Busy), AccessibilityStatesNotifyMode.Recursive);
            var result = testingTarget.GetAccessibilityStates();
            tlog.Debug(tag, "AccessibilityStates : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewAccessibilityViewNotifyAccessibilityStatesChange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.View.RegisterDefaultLabel.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.View.RegisterDefaultLabel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityRegisterDefaultLabel()
        {
            tlog.Debug(tag, $"ViewAccessibilityRegisterDefaultLabel START");

            var testingTarget = new View()
            {
                Size = new Size2D(100, 100),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.TopCenter,
                BackgroundColor = Color.AquaMarine,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            try
            {
                testingTarget.RegisterDefaultLabel();
                testingTarget.UnregisterDefaultLabel();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewAccessibilityRegisterDefaultLabel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.EmitAccessibilityEvent.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.EmitAccessibilityEvent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityEmitAccessibilityEvent()
        {
            tlog.Debug(tag, $"ViewAccessibilityEmitAccessibilityEvent START");

            var testingTarget = new View()
            {
                Size = new Size2D(100, 100),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.TopCenter,
                BackgroundColor = Color.AquaMarine,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            try
            {
                testingTarget.EmitAccessibilityEvent(AccessibilityPropertyChangeEvent.Name);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewAccessibilityEmitAccessibilityEvent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.EmitAccessibilityStateChangedEvent.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.EmitAccessibilityStateChangedEvent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityEmitAccessibilityStateChangedEvent()
        {
            tlog.Debug(tag, $"ViewAccessibilityEmitAccessibilityStateChangedEvent START");

            var testingTarget = new CheckBox()
            {
                Size = new Size2D(100, 100),
                IsSelectable = true,
                IsSelected = true,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object CheckBox.");
            Assert.IsInstanceOf<CheckBox>(testingTarget, "Should be an instance of CheckBox type.");

            try
            {
                testingTarget.EmitAccessibilityStateChangedEvent(AccessibilityState.Checked, true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewAccessibilityEmitAccessibilityStateChangedEvent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.EmitTextInsertedEvent.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.EmitTextInsertedEvent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityEmitTextInsertedEvent()
        {
            tlog.Debug(tag, $"ViewAccessibilityEmitTextInsertedEvent START");

            var testingTarget = new TextLabel()
            {
                Text = "InsertedEvent"
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            try
            {
                testingTarget.EmitTextInsertedEvent(0, 4, "test");
                testingTarget.EmitTextCursorMovedEvent(4);
                testingTarget.EmitTextDeletedEvent(0, 4, "test");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewAccessibilityEmitTextInsertedEvent END (OK)");
        }
    }
}
