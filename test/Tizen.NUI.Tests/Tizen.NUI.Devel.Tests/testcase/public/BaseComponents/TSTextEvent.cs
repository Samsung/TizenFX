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
    [Description("public/BaseComponents/TextEvent")]
    public class PublicTextEventTest
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
        [Description("TextEvent.AnchorClickedEventArgs Href.")]
        [Property("SPEC", "Tizen.NUI.TextEvent.AnchorClickedEventArgs.Href A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextEventAnchorClickedEventArgsHref()
        {
            tlog.Debug(tag, $"TextEventAnchorClickedEventArgsHref START");

            TextLabel label = new TextLabel()
            {
                Text = "hypertext",
            };

            var testingTarget = new AnchorClickedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object AnchorClickedEventArgs");
            Assert.IsInstanceOf<AnchorClickedEventArgs>(testingTarget, "Should be an instance of AnchorClickedEventArgs type.");

            testingTarget.Href = Marshal.PtrToStringAnsi(label.SwigCPtr.Handle);
            Assert.IsNotNull(testingTarget.Href, "Should be not null.");

            label.Dispose();
            tlog.Debug(tag, $"TextEventAnchorClickedEventArgsHref END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEvent.InputFilteredEventArgs Type.")]
        [Property("SPEC", "Tizen.NUI.TextEvent.InputFilteredEventArgs.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextEventInputFilteredEventArgsType()
        {
            tlog.Debug(tag, $"TextEventInputFilteredEventArgsType START");

            TextLabel label = new TextLabel()
            {
                Text = "hypertext",
            };

            var testingTarget = new InputFilteredEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object InputFilteredEventArgs");
            Assert.IsInstanceOf<InputFilteredEventArgs>(testingTarget, "Should be an instance of InputFilteredEventArgs type.");

            testingTarget.Type = InputFilterType.Accept;
            Assert.IsNotNull(testingTarget.Type, "Should be not null.");

            label.Dispose();
            tlog.Debug(tag, $"TextEventInputFilteredEventArgsType END (OK)");
        }
    }
}
