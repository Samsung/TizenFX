using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Windows.Input;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Control")]
    public class ControlTest
    {
        private const string tag = "NUITEST";

        internal class ICommandImpl : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter) { return true; }

            public void Execute(object parameter) { }
        }

        internal class MyControl : Control
        {
            public MyControl() : base()
            { }

            public override void OnFocusGained()
            {
                base.OnFocusGained();
            }

            public override void OnFocusLost()
            {
                base.OnFocusLost();
            }

            public void OnCreateViewStyle()
            {
                base.CreateViewStyle();
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
        [Description("Control Preload.")]
        [Property("SPEC", "Tizen.NUI.Components.Control.Preload M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlPreload()
        {
            tlog.Debug(tag, $"ControlPreload START");

            try
            {
                Control.Preload();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ControlPreload END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Control Feedback.")]
        [Property("SPEC", "Tizen.NUI.Components.Control.Feedback A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlFeedback()
        {
            tlog.Debug(tag, $"ControlFeedback START");

            var testingTarget = new Control();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Control>(testingTarget, "Should return Control instance.");

            testingTarget.Feedback = true;
            tlog.Debug(tag, "Feedback : " + testingTarget.Feedback);

            // value == (feedback != null)
            testingTarget.Feedback = true;
            tlog.Debug(tag, "Feedback : " + testingTarget.Feedback);

            testingTarget.Feedback = false;
            tlog.Debug(tag, "Feedback : " + testingTarget.Feedback);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ControlFeedback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Control Command.")]
        [Property("SPEC", "Tizen.NUI.Components.Control.Command A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlCommand()
        {
            tlog.Debug(tag, $"ControlCommand START");

            var testingTarget = new Control();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Control>(testingTarget, "Should return Control instance.");

            ICommandImpl command = new ICommandImpl();

            testingTarget.Command = command;
            tlog.Debug(tag, "Command : " + testingTarget.Command);

            //Button parameter = new Button()
            //{ 
            //    Size = new Size(10, 30),
            //    BackgroundColor = Color.Green,
            //};
            //testingTarget.CommandParameter = parameter;
            //tlog.Debug(tag, "CommandParameter : " + testingTarget.CommandParameter);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ControlCommand END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Control OnFocusGained.")]
        [Property("SPEC", "Tizen.NUI.Components.Control.OnFocusGained M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlOnFocusGained()
        {
            tlog.Debug(tag, $"ControlOnFocusGained START");

            var testingTarget = new MyControl();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Control>(testingTarget, "Should return Control instance.");

            try
            {
                testingTarget.OnFocusGained();
                testingTarget.OnFocusLost();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ControlOnFocusGained END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Control CreateViewStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.Control.CreateViewStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlCreateViewStyle()
        {
            tlog.Debug(tag, $"ControlCreateViewStyle START");

            var testingTarget = new MyControl();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Control>(testingTarget, "Should return Control instance.");

            try
            {
                testingTarget.OnCreateViewStyle();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ControlCreateViewStyle END (OK)");
        }
    }
}
