using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Input/TSInputMethodContext")]
    internal class PublicInputMethodContextTest
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
        [Description("Create a InputMethodContext object.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.InputMethodContext C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextConstructor()
        {
            tlog.Debug(tag, $"InputMethodContextConstructor START");
            InputMethodContext a1 = new InputMethodContext();
            InputMethodContext b1 = new InputMethodContext(a1);

            b1.Dispose();
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextConstructor END (OK)");
            Assert.Pass("InputMethodContextConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext Activated")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.Activated A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextActivated()
        {
            tlog.Debug(tag, $"InputMethodContextActivated START");
            InputMethodContext a1 = new InputMethodContext();

            a1.Activated += A1_Activated;
            a1.Activated -= A1_Activated;

            object o1 = new object();
            InputMethodContext.ActivatedEventArgs e = new InputMethodContext.ActivatedEventArgs();

            A1_Activated(o1, e);
            a1.Dispose();
            tlog.Debug(tag, $"InputMethodContextActivated END (OK)");
            Assert.Pass("InputMethodContextActivated");
        }

        private void A1_Activated(object sender, InputMethodContext.ActivatedEventArgs e)
        {
            InputMethodContext a1 = e.InputMethodContext;
            e.InputMethodContext = a1;
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext EventReceived")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.EventReceived A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextEventReceived()
        {
            tlog.Debug(tag, $"InputMethodContextEventReceived START");
            InputMethodContext a1 = new InputMethodContext();

            a1.EventReceived += A1_EventReceived;
            a1.EventReceived -= A1_EventReceived;

            object o1 = new object();
            InputMethodContext.EventReceivedEventArgs e = new InputMethodContext.EventReceivedEventArgs();

            A1_EventReceived(o1, e);
            a1.Dispose();
            tlog.Debug(tag, $"InputMethodContextActivated END (OK)");
            Assert.Pass("InputMethodContextActivated");
        }

        private InputMethodContext.CallbackData A1_EventReceived(object source, InputMethodContext.EventReceivedEventArgs e)
        {
            InputMethodContext a1 = e.InputMethodContext;
            e.InputMethodContext = a1;

            InputMethodContext.EventData b1 = e.EventData;
            e.EventData = b1;

            return null;
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext StatusChanged")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.StatusChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextStatusChanged()
        {
            tlog.Debug(tag, $"InputMethodContextStatusChanged START");
            InputMethodContext a1 = new InputMethodContext();

            a1.StatusChanged += A1_StatusChanged;
            a1.StatusChanged -= A1_StatusChanged;

            object o1 = new object();
            InputMethodContext.StatusChangedEventArgs e = new InputMethodContext.StatusChangedEventArgs();

            A1_StatusChanged(o1, e);
            a1.Dispose();
            tlog.Debug(tag, $"InputMethodContextStatusChanged END (OK)");
            Assert.Pass("InputMethodContextStatusChanged");
        }

        private void A1_StatusChanged(object sender, InputMethodContext.StatusChangedEventArgs e)
        {
            bool a1 = e.StatusChanged;
            e.StatusChanged = a1;
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext Resized")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.Resized A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextResized()
        {
            tlog.Debug(tag, $"InputMethodContextResized START");
            InputMethodContext a1 = new InputMethodContext();

            a1.Resized += A1_Resized;
            a1.Resized -= A1_Resized;

            object o1 = new object();
            InputMethodContext.ResizedEventArgs e = new InputMethodContext.ResizedEventArgs();

            A1_Resized(o1, e);
            a1.Dispose();
            tlog.Debug(tag, $"InputMethodContextResized END (OK)");
            Assert.Pass("InputMethodContextResized");
        }

        private void A1_Resized(object sender, InputMethodContext.ResizedEventArgs e)
        {
            e.Resized = 5;
            int i = e.Resized;
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext LanguageChanged")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.LanguageChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextLanguageChanged()
        {
            tlog.Debug(tag, $"InputMethodContextLanguageChanged START");
            InputMethodContext a1 = new InputMethodContext();

            a1.LanguageChanged += A1_LanguageChanged;
            a1.LanguageChanged -= A1_LanguageChanged;

            object o1 = new object();
            InputMethodContext.LanguageChangedEventArgs e = new InputMethodContext.LanguageChangedEventArgs();

            A1_LanguageChanged(o1, e);
            a1.Dispose();
            tlog.Debug(tag, $"InputMethodContextLanguageChanged END (OK)");
            Assert.Pass("InputMethodContextLanguageChanged");
        }

        private void A1_LanguageChanged(object sender, InputMethodContext.LanguageChangedEventArgs e)
        {
            int i = e.LanguageChanged;
            e.LanguageChanged = i;
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext KeyboardTypeChanged")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.KeyboardTypeChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextKeyboardTypeChanged()
        {
            tlog.Debug(tag, $"InputMethodContextKeyboardTypeChanged START");
            InputMethodContext a1 = new InputMethodContext();

            a1.KeyboardTypeChanged += A1_KeyboardTypeChanged;
            a1.KeyboardTypeChanged -= A1_KeyboardTypeChanged;

            object o1 = new object();
            InputMethodContext.KeyboardTypeChangedEventArgs e = new InputMethodContext.KeyboardTypeChangedEventArgs();

            A1_KeyboardTypeChanged(o1, e);
            a1.Dispose();
            tlog.Debug(tag, $"InputMethodContextKeyboardTypeChanged END (OK)");
            Assert.Pass("InputMethodContextKeyboardTypeChanged");
        }

        private void A1_KeyboardTypeChanged(object sender, InputMethodContext.KeyboardTypeChangedEventArgs e)
        {
            InputMethodContext.KeyboardType b1 = e.KeyboardType;
            e.KeyboardType = b1;
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext ContentReceived")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.ContentReceived A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextContentReceived()
        {
            tlog.Debug(tag, $"InputMethodContextContentReceived START");
            InputMethodContext a1 = new InputMethodContext();

            a1.ContentReceived += A1_ContentReceived;
            a1.ContentReceived -= A1_ContentReceived;

            object o1 = new object();
            InputMethodContext.ContentReceivedEventArgs e = new InputMethodContext.ContentReceivedEventArgs();

            A1_ContentReceived(o1, e);
            a1.Dispose();
            tlog.Debug(tag, $"InputMethodContextContentReceived END (OK)");
            Assert.Pass("InputMethodContextContentReceived");
        }

        private void A1_ContentReceived(object sender, InputMethodContext.ContentReceivedEventArgs e)
        {
            string s1 = e.Content;
            e.Content = s1;

            string s2 = e.Description;
            e.Description = s2;

            string s3 = e.MimeType;
            e.MimeType = s3;
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext DestroyContext")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.DestroyContext M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextDestroyContext()
        {
            tlog.Debug(tag, $"InputMethodContextDestroyContext START");
            InputMethodContext a1 = new InputMethodContext();

            a1.DestroyContext();
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextDestroyContext END (OK)");
            Assert.Pass("InputMethodContextDestroyContext");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext Activate")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.Activate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextActivate()
        {
            tlog.Debug(tag, $"InputMethodContextActivate START");
            InputMethodContext a1 = new InputMethodContext();

            a1.Activate();
            a1.Deactivate();
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextActivate END (OK)");
            Assert.Pass("InputMethodContextActivate");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext Deactivate")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.Deactivate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextDeactivate()
        {
            tlog.Debug(tag, $"InputMethodContextDeactivate START");
            InputMethodContext a1 = new InputMethodContext();

            a1.Activate();
            a1.Deactivate();
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextDeactivate END (OK)");
            Assert.Pass("InputMethodContextDeactivate");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext RestoreAfterFocusLost")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.RestoreAfterFocusLost M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextRestoreAfterFocusLost()
        {
            tlog.Debug(tag, $"InputMethodContextRestoreAfterFocusLost START");
            InputMethodContext a1 = new InputMethodContext();

            a1.RestoreAfterFocusLost();
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextRestoreAfterFocusLost END (OK)");
            Assert.Pass("InputMethodContextRestoreAfterFocusLost");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext SetRestoreAfterFocusLost")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.SetRestoreAfterFocusLost M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextSetRestoreAfterFocusLost()
        {
            tlog.Debug(tag, $"InputMethodContextSetRestoreAfterFocusLost START");
            InputMethodContext a1 = new InputMethodContext();

            a1.SetRestoreAfterFocusLost(true);
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextSetRestoreAfterFocusLost END (OK)");
            Assert.Pass("InputMethodContextSetRestoreAfterFocusLost");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext Reset")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.Reset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextReset()
        {
            tlog.Debug(tag, $"InputMethodContextReset START");
            InputMethodContext a1 = new InputMethodContext();

            a1.Reset();
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextReset END (OK)");
            Assert.Pass("InputMethodContextReset");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext NotifyCursorPosition")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.NotifyCursorPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextNotifyCursorPosition()
        {
            tlog.Debug(tag, $"InputMethodContextNotifyCursorPosition START");
            InputMethodContext a1 = new InputMethodContext();

            a1.NotifyCursorPosition();
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextNotifyCursorPosition END (OK)");
            Assert.Pass("InputMethodContextNotifyCursorPosition");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext SetCursorPosition")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.SetCursorPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextSetCursorPosition()
        {
            tlog.Debug(tag, $"InputMethodContextSetCursorPosition START");
            InputMethodContext a1 = new InputMethodContext();

            a1.SetCursorPosition(5);
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextSetCursorPosition END (OK)");
            Assert.Pass("InputMethodContextSetCursorPosition");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext GetCursorPosition")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetCursorPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextGetCursorPosition()
        {
            tlog.Debug(tag, $"InputMethodContextGetCursorPosition START");
            InputMethodContext a1 = new InputMethodContext();

            a1.GetCursorPosition();
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextGetCursorPosition END (OK)");
            Assert.Pass("InputMethodContextGetCursorPosition");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext SetSurroundingText")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.SetSurroundingText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextSetSurroundingText()
        {
            tlog.Debug(tag, $"InputMethodContextSetSurroundingText START");
            InputMethodContext a1 = new InputMethodContext();

            a1.SetSurroundingText("surrounding text");
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextSetSurroundingText END (OK)");
            Assert.Pass("InputMethodContextSetSurroundingText");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext GetSurroundingText")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetSurroundingText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextGetSurroundingText()
        {
            tlog.Debug(tag, $"InputMethodContextGetSurroundingText START");
            InputMethodContext a1 = new InputMethodContext();

            a1.GetSurroundingText();
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextGetSurroundingText END (OK)");
            Assert.Pass("InputMethodContextGetSurroundingText");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext NotifyTextInputMultiLine")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.NotifyTextInputMultiLine M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextNotifyTextInputMultiLine()
        {
            tlog.Debug(tag, $"InputMethodContextNotifyTextInputMultiLine START");
            InputMethodContext a1 = new InputMethodContext();

            a1.NotifyTextInputMultiLine(true);
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextNotifyTextInputMultiLine END (OK)");
            Assert.Pass("InputMethodContextNotifyTextInputMultiLine");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext GetTextDirection")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetTextDirection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextGetTextDirection()
        {
            tlog.Debug(tag, $"InputMethodContextGetTextDirection START");
            InputMethodContext a1 = new InputMethodContext();

            a1.GetTextDirection();
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextGetTextDirection END (OK)");
            Assert.Pass("InputMethodContextGetTextDirection");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext GetInputMethodArea")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetInputMethodArea M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextGetInputMethodArea()
        {
            tlog.Debug(tag, $"InputMethodContextGetInputMethodArea START");
            InputMethodContext a1 = new InputMethodContext();

            a1.GetInputMethodArea();
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextGetInputMethodArea END (OK)");
            Assert.Pass("InputMethodContextGetInputMethodArea");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext SetInputPanelUserData")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.SetInputPanelUserData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextSetInputPanelUserData()
        {
            tlog.Debug(tag, $"InputMethodContextSetInputPanelUserData START");
            InputMethodContext a1 = new InputMethodContext();

            a1.SetInputPanelUserData("userdata");
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextSetInputPanelUserData END (OK)");
            Assert.Pass("InputMethodContextSetInputPanelUserData");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext GetInputPanelUserData")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetInputPanelUserData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextGetInputPanelUserData()
        {
            tlog.Debug(tag, $"InputMethodContextGetInputPanelUserData START");
            InputMethodContext a1 = new InputMethodContext();

            a1.GetInputPanelUserData(out string b1);
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextGetInputPanelUserData END (OK)");
            Assert.Pass("InputMethodContextGetInputPanelUserData");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext GetInputPanelState")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetInputPanelState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextGetInputPanelState()
        {
            tlog.Debug(tag, $"InputMethodContextGetInputPanelState START");
            InputMethodContext a1 = new InputMethodContext();

            a1.GetInputPanelState();
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextGetInputPanelState END (OK)");
            Assert.Pass("InputMethodContextGetInputPanelState");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext SetReturnKeyState")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.SetReturnKeyState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextSetReturnKeyState()
        {
            tlog.Debug(tag, $"InputMethodContextSetReturnKeyState START");
            InputMethodContext a1 = new InputMethodContext();

            a1.SetReturnKeyState(true);
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextSetReturnKeyState END (OK)");
            Assert.Pass("InputMethodContextSetReturnKeyState");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext AutoEnableInputPanel")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.AutoEnableInputPanel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextAutoEnableInputPanel()
        {
            tlog.Debug(tag, $"InputMethodContextAutoEnableInputPanel START");
            InputMethodContext a1 = new InputMethodContext();

            a1.AutoEnableInputPanel(true);
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextAutoEnableInputPanel END (OK)");
            Assert.Pass("InputMethodContextAutoEnableInputPanel");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext ShowInputPanel")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.ShowInputPanel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextShowInputPanel()
        {
            tlog.Debug(tag, $"InputMethodContextShowInputPanel START");
            InputMethodContext a1 = new InputMethodContext();

            a1.ShowInputPanel();
            a1.Dispose();

            tlog.Debug(tag, $"InputMethodContextShowInputPanel END (OK)");
            Assert.Pass("InputMethodContextShowInputPanel");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext getCPtr")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextgetCPtr()
        {
            tlog.Debug(tag, $"InputMethodContextgetCPtr START");
            InputMethodContext a1 = new InputMethodContext();

            global::System.Runtime.InteropServices.HandleRef p1 = InputMethodContext.getCPtr(a1);
            tlog.Debug(tag, $"InputMethodContextgetCPtr END (OK)");
            Assert.Pass("InputMethodContextgetCPtr");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext Assign")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextAssign()
        {
            tlog.Debug(tag, $"InputMethodContextAssign START");
            InputMethodContext a1 = new InputMethodContext();
            InputMethodContext b1 = a1;

            tlog.Debug(tag, $"InputMethodContextAssign END (OK)");
            Assert.Pass("InputMethodContextAssign");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext DownCast")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextDownCast()
        {
            tlog.Debug(tag, $"InputMethodContextDownCast START");

            using (InputMethodContext context = new InputMethodContext())
            {
                var testingTarget = InputMethodContext.DownCast(context);
                Assert.IsNotNull(testingTarget, "Can't create success object InputMethodContext");
                Assert.IsInstanceOf<InputMethodContext>(testingTarget, "Should be an instance of InputMethodContext type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"InputMethodContextDownCast END (OK)");
            Assert.Pass("InputMethodContextDownCast");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext ApplyOptions")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.ApplyOptions M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextApplyOptions()
        {
            tlog.Debug(tag, $"InputMethodContextApplyOptions START");

            InputMethodContext a1 = new InputMethodContext();
            InputMethodOptions option = new InputMethodOptions();

            a1.ApplyOptions(option);
            a1.Dispose();
            tlog.Debug(tag, $"InputMethodContextApplyOptions END (OK)");
            Assert.Pass("InputMethodContextApplyOptions");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext LanguageChangedSignal")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.LanguageChangedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextLanguageChangedSignal()
        {
            tlog.Debug(tag, $"InputMethodContextLanguageChangedSignal START");

            InputMethodContext a1 = new InputMethodContext();

            a1.LanguageChangedSignal();
            a1.Dispose();
            tlog.Debug(tag, $"InputMethodContextLanguageChangedSignal END (OK)");
            Assert.Pass("InputMethodContextLanguageChangedSignal");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext KeyboardTypeChangedSignal")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.KeyboardTypeChangedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextKeyboardTypeChangedSignal()
        {
            tlog.Debug(tag, $"InputMethodContextKeyboardTypeChangedSignal START");

            InputMethodContext a1 = new InputMethodContext();

            a1.KeyboardTypeChangedSignal();
            a1.Dispose();
            tlog.Debug(tag, $"InputMethodContextKeyboardTypeChangedSignal END (OK)");
            Assert.Pass("InputMethodContextKeyboardTypeChangedSignal");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodContext ContentReceivedSignal")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.ContentReceivedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodContextContentReceivedSignal()
        {
            tlog.Debug(tag, $"InputMethodContextContentReceivedSignal START");

            InputMethodContext a1 = new InputMethodContext();

            a1.ContentReceivedSignal();
            a1.Dispose();
            tlog.Debug(tag, $"InputMethodContextContentReceivedSignal END (OK)");
            Assert.Pass("InputMethodContextContentReceivedSignal");
        }
    }

}