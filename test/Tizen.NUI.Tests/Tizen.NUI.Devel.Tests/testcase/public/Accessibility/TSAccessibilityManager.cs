using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Accessibility/AccessibilityManager")]
    public class PublicAccessibilityManagerTest
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
        [Description("AccessibilityManager construcotr.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.AccessibilityManager M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerConstructor()
        {
            tlog.Debug(tag, $"AccessibilityManagerConstructor START");

            var testingTarget = new Accessibility.AccessibilityManager();
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AccessibilityManagerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager SetAccessibilityAttribute.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.SetAccessibilityAttribute M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerSetAccessibilityAttribute()
        {
            tlog.Debug(tag, $"AccessibilityManagerSetAccessibilityAttribute START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            try
            {
                using (View view = new View() { Size = new Size(100, 50) })
                {
                    testingTarget.SetAccessibilityAttribute(view, Accessibility.AccessibilityManager.AccessibilityAttribute.Label, "label");
                    var result = testingTarget.GetAccessibilityAttribute(view, Accessibility.AccessibilityManager.AccessibilityAttribute.Label);
                    tlog.Debug(tag, "Attribute : " + result);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"AccessibilityManagerSetAccessibilityAttribute END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager SetFocusOrder.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.SetFocusOrder M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerSetFocusOrder()
        {
            tlog.Debug(tag, $"AccessibilityManagerSetFocusOrder START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            try
            {
                using (View view = new View() { Size = new Size(100, 50) })
                {
                    testingTarget.SetFocusOrder(view, 1);
                    var result = testingTarget.GetFocusOrder(view);
                    tlog.Debug(tag, "FocusOrder : " + result);

                    testingTarget.ClearFocus();
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"AccessibilityManagerSetFocusOrder END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager GenerateNewFocusOrder.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.GenerateNewFocusOrder M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerGenerateNewFocusOrder()
        {
            tlog.Debug(tag, $"AccessibilityManagerGenerateNewFocusOrder START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.GenerateNewFocusOrder();
            tlog.Debug(tag, "New focus order : " + result);

            tlog.Debug(tag, $"AccessibilityManagerGenerateNewFocusOrder END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager GetViewByFocusOrder.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.GetViewByFocusOrder M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerGetViewByFocusOrder()
        {
            tlog.Debug(tag, $"AccessibilityManagerGetViewByFocusOrder START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.GetViewByFocusOrder(1);
            tlog.Debug(tag, "New focus order : " + result);

            tlog.Debug(tag, $"AccessibilityManagerGetViewByFocusOrder END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager SetCurrentFocusView.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.SetCurrentFocusView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerSetCurrentFocusView()
        {
            tlog.Debug(tag, $"AccessibilityManagerSetCurrentFocusView START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                var result = testingTarget.SetCurrentFocusView(view);
                tlog.Debug(tag, "Set current focus order : " + result);
                tlog.Debug(tag, "Current focus : " + testingTarget.GetCurrentFocusView());
                tlog.Debug(tag, "Current focus order : " + testingTarget.GetCurrentFocusOrder());
                tlog.Debug(tag, "Current focus group : " + testingTarget.GetCurrentFocusGroup());

                testingTarget.Reset();
            }

            tlog.Debug(tag, $"AccessibilityManagerSetCurrentFocusView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager MoveFocusForward.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.MoveFocusForward M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerMoveFocusForward()
        {
            tlog.Debug(tag, $"AccessibilityManagerMoveFocusForward START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            tlog.Debug(tag, "Move focus forwrad : " + testingTarget.MoveFocusForward());
            tlog.Debug(tag, "Move focus backwrad : " + testingTarget.MoveFocusBackward());

            tlog.Debug(tag, $"AccessibilityManagerMoveFocusForward END (OK)");
        }



        [Test]
        [Category("P1")]
        [Description("AccessibilityManager SetFocusGroup.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.SetFocusGroup M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerSetFocusGroup()
        {
            tlog.Debug(tag, $"AccessibilityManagerSetFocusGroup START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                try
                {
                    testingTarget.SetFocusGroup(view, true);
                    tlog.Debug(tag, "Is focus group : " + testingTarget.IsFocusGroup(view));
                    tlog.Debug(tag, "Focus group : " + testingTarget.GetFocusGroup(view));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"AccessibilityManagerSetFocusGroup END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager SetGroupMode.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.SetGroupMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerSetGroupMode()
        {
            tlog.Debug(tag, $"AccessibilityManagerSetGroupMode START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                try
                {
                    testingTarget.SetGroupMode(true);
                    tlog.Debug(tag, "Group mode : " + testingTarget.GetGroupMode());
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"AccessibilityManagerSetGroupMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager SetWrapMode.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.SetWrapMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerSetWrapMode()
        {
            tlog.Debug(tag, $"AccessibilityManagerSetWrapMode START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            testingTarget.SetWrapMode(true);
            tlog.Debug(tag, "Wrap mode : " + testingTarget.GetWrapMode());

            tlog.Debug(tag, $"AccessibilityManagerSetWrapMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager SetFocusIndicatorView.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.SetFocusIndicatorView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerSetFocusIndicatorView()
        {
            tlog.Debug(tag, $"AccessibilityManagerSetFocusIndicatorView START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            using (View indicator = new View() { Size = new Size(8, 8), Color = Color.Black })
            {
                testingTarget.SetFocusIndicatorView(indicator);
                tlog.Debug(tag, "Group mode : " + testingTarget.GetFocusIndicatorView());
            }

            tlog.Debug(tag, $"AccessibilityManagerSetFocusIndicatorView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager GetReadPosition.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.GetReadPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerGetReadPosition()
        {
            tlog.Debug(tag, $"AccessibilityManagerGetReadPosition START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            using (View view = new View() { Size = new Size(8, 8), Position = new Position(100, 200) })
            {
                testingTarget.SetFocusIndicatorView(view);
                tlog.Debug(tag, "Group mode : " + testingTarget.GetReadPosition());
            }

            tlog.Debug(tag, $"AccessibilityManagerGetReadPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager FocusChangedSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.FocusChangedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerFocusChangedSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerFocusChangedSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.FocusChangedSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerFocusChangedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager FocusOvershotSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.FocusOvershotSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerFocusOvershotSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerFocusOvershotSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.FocusOvershotSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerFocusOvershotSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager FocusedViewActivatedSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.FocusedViewActivatedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerFocusedViewActivatedSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerFocusedViewActivatedSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.FocusedViewActivatedSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerFocusedViewActivatedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager StatusChangedSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.StatusChangedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerStatusChangedSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerStatusChangedSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.StatusChangedSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerStatusChangedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionNextSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionNextSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionNextSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerStatusChangedSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionNextSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionNextSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionPreviousSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionPreviousSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionPreviousSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionPreviousSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionPreviousSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionPreviousSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionActivateSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionActivateSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionActivateSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionActivateSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionActivateSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionActivateSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionReadSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionReadSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionReadSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionReadSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionReadSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionReadSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionOverSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionOverSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionOverSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionOverSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionOverSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionOverSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionReadNextSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionReadNextSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionReadNextSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionReadNextSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionReadNextSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionReadNextSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionReadPreviousSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionReadPreviousSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionReadPreviousSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionReadPreviousSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionReadPreviousSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionReadPreviousSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionUpSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionUpSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionUpSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionUpSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionUpSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionUpSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionDownSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionDownSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionDownSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionDownSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionDownSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionDownSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionClearFocusSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionClearFocusSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionClearFocusSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionClearFocusSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionClearFocusSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionClearFocusSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionBackSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionBackSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionBackSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionBackSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionBackSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionBackSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionScrollUpSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionScrollUpSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionScrollUpSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionScrollUpSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionScrollUpSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionScrollUpSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionScrollDownSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionScrollDownSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionScrollDownSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionScrollDownSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionScrollDownSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionScrollDownSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionPageLeftSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionPageLeftSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionPageLeftSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionPageLeftSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionPageLeftSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionPageLeftSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionPageRightSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionPageRightSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionPageRightSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionPageRightSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionPageRightSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionPageRightSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionPageUpSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionPageUpSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionPageUpSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionPageUpSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionPageUpSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionPageUpSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionPageDownSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionPageDownSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionPageDownSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionPageDownSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionPageDownSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionPageDownSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionMoveToFirstSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionMoveToFirstSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionMoveToFirstSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionMoveToFirstSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionMoveToFirstSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionMoveToFirstSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionMoveToLastSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionMoveToLastSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionMoveToLastSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionMoveToLastSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionMoveToLastSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionMoveToLastSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionReadFromTopSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionReadFromTopSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionReadFromTopSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionReadFromTopSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionReadFromTopSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionReadFromTopSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionReadFromNextSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionReadFromNextSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionReadFromNextSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionReadFromNextSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionReadFromNextSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionReadFromNextSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionZoomSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionZoomSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionZoomSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionZoomSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionZoomSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionZoomSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionReadPauseResumeSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionReadPauseResumeSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionReadPauseResumeSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionReadPauseResumeSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionReadPauseResumeSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionReadPauseResumeSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionStartStopSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionStartStopSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionStartStopSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionStartStopSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionStartStopSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionStartStopSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager ActionScrollSignal.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.ActionScrollSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerActionScrollSignal()
        {
            tlog.Debug(tag, $"AccessibilityManagerActionScrollSignal START");

            var testingTarget = Accessibility.AccessibilityManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityManager ");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager>(testingTarget, "Should be an instance of AccessibilityManager  type.");

            var result = testingTarget.ActionScrollSignal();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"AccessibilityManagerActionScrollSignal END (OK)");
        }
    }
}
