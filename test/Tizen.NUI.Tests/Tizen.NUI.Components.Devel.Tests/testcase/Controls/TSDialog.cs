using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Dialog")]
    public class DialogTest
    {
        private const string tag = "NUITEST";

        internal class MyDialog : Dialog
        {
            public MyDialog() : base()
            { }

            public void OnDispose(DisposeTypes types)
            {
                base.Dispose(types);
            }

            public void MyAccessibilityCalculateStates()
            {
                GetAccessibilityStates();
            }
        }

        internal class MyBindableObject : BindableObject
        { }

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
        [Description("Dialog Dispose.")]
        [Property("SPEC", "Tizen.NUI.Components.Dialog.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DialogDispose()
        {
            tlog.Debug(tag, $"DialogDispose START");

            var testingTarget = new MyDialog();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Dialog>(testingTarget, "Should return Dialog instance.");

            try
            {
                testingTarget.OnDispose(DisposeTypes.Explicit);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"DialogDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Dialog Content.")]
        [Property("SPEC", "Tizen.NUI.Components.Dialog.Content A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DialogContent()
        {
            tlog.Debug(tag, $"DialogContent START");

            var testingTarget = new MyDialog();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Dialog>(testingTarget, "Should return Dialog instance.");

            View view = new View() 
            { 
                Size = new Size(50, 80), 
                BackgroundColor = Color.Cyan 
            };

            testingTarget.Content = view;
            tlog.Debug(tag, "Content : " + testingTarget.Content);
            
            // content == value
            testingTarget.Content = view;
            tlog.Debug(tag, "Content : " + testingTarget.Content);

            // content != null
            View view2 = new View()
            {
                Size = new Size(30, 60),
                BackgroundColor = Color.Green
            };
            testingTarget.Content = view2;
            tlog.Debug(tag, "Content : " + testingTarget.Content);

            tlog.Debug(tag, $"DialogContent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Dialog AccessibilityCalculateStates.")]
        [Property("SPEC", "Tizen.NUI.Components.Dialog.AccessibilityCalculateStates M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DialogAccessibilityCalculateStates()
        {
            tlog.Debug(tag, $"DialogAccessibilityCalculateStates START");

            var testingTarget = new MyDialog();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Dialog>(testingTarget, "Should return Dialog instance.");

            try
            {
                testingTarget.MyAccessibilityCalculateStates();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"DialogAccessibilityCalculateStates END (OK)");
        }
    }
}
