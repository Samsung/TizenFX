using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/TextLabelEvent")]
    public class PublicTextLabelEventTest
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
        [Description("TextLabelEvent.AnchorClicked.")]
        [Property("SPEC", "Tizen.NUI.TextLabelEvent.AnchorClicked A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextLabelEventAnchorClicked()
        {
            tlog.Debug(tag, $"TextLabelEventAnchorClicked START");

            TextLabel label = new TextLabel()
            {
                Text = "hypertext",
            };

            label.AnchorClicked += MyOnAnchorClicked;
            label.AnchorClicked -= MyOnAnchorClicked;

            label.Dispose();
            tlog.Debug(tag, $"TextLabelEventAnchorClicked END (OK)");
        }

        private void MyOnAnchorClicked(object sender, AnchorClickedEventArgs e)
        {
            var label = sender as TextLabel;
            e.Href = Marshal.PtrToStringAnsi(label.SwigCPtr.Handle);
        }
    }
}
