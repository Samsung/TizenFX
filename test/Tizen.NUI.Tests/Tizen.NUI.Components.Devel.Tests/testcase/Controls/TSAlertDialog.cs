using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/AlertDialog")]
    public class AlertDialogTest
    {
        private const string tag = "NUITEST";

        internal class MyAlertDialog : AlertDialog
        {
            public MyAlertDialog() : base()
            { }

            public void OnDispose(DisposeTypes types)
            {
                base.Dispose(types);
            }

            public AccessibilityStates OnAccessibilityCalculateStates()
            {
                return GetAccessibilityStates();
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
        [Description("AlertDialog Dispose.")]
        [Property("SPEC", "Tizen.NUI.Components.AlertDialog.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlertDialogDispose()
        {
            tlog.Debug(tag, $"AlertDialogDispose START");

            var testingTarget = new MyAlertDialog()
            { 
                Size = new Size(100, 100),
                TitleContent = new View() { Size = new Size(100, 20) },
                Content = new View() { Size = new Size(100, 80) },
                ActionContent = new View() { Size = new Size(50, 50) }, 
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<AlertDialog>(testingTarget, "Should return AlertDialog instance.");

            try
            {
                testingTarget.OnDispose(DisposeTypes.Explicit);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlertDialogDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AlertDialog AccessibilityCalculateStates.")]
        [Property("SPEC", "Tizen.NUI.Components.AlertDialog.AccessibilityCalculateStates M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlertDialogAccessibilityCalculateStates()
        {
            tlog.Debug(tag, $"AlertDialogAccessibilityCalculateStates START");

            var testingTarget = new MyAlertDialog()
            {
                Size = new Size(100, 100),
                TitleContent = new View() { Size = new Size(100, 20) },
                Content = new View() { Size = new Size(100, 80) },
                ActionContent = new View() { Size = new Size(50, 50) },
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<AlertDialog>(testingTarget, "Should return AlertDialog instance.");

            try
            {
                var result = testingTarget.OnAccessibilityCalculateStates();
                tlog.Debug(tag, "AccessibilityCalculateStates : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlertDialogAccessibilityCalculateStates END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AlertDialog Actions.")]
        [Property("SPEC", "Tizen.NUI.Components.AlertDialog.Actions A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlertDialogActions()
        {
            tlog.Debug(tag, $"AlertDialogActions START");

            var testingTarget = new AlertDialog();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<AlertDialog>(testingTarget, "Should return AlertDialog instance.");

            View tc = new View()
            {
                Size = new Size(100, 20),
                Position = new Position(0, 0),
                BackgroundColor = Color.Green
            };
            testingTarget.TitleContent = tc;
            testingTarget.TitleContent = tc;

            List<View> actions = new List<View>();

            ViewStyle style1 = new ViewStyle()
            {
                BackgroundColor = Color.Red,
            };
            View action1 = new View(style1);

            ButtonStyle style2 = new ButtonStyle()
            {
                BackgroundColor = Color.Yellow,
            };
            View action2 = new Button(style2);

            actions.Add(action1);
            actions.Add(action2);

            testingTarget.Actions = actions;

            View ac = new View()
            {
                Size = new Size(100, 80),
                Position = new Position(0, 20)
            };
            testingTarget.ActionContent = ac;

            testingTarget.Actions = actions;

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlertDialogActions END (OK)");
        }
    }
}
