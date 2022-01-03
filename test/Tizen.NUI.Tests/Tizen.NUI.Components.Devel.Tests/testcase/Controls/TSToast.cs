using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Control/Toast")]
    public class ControlToastTest
    {
        private const string tag = "NUITEST";

        [Obsolete]
        internal class MyToast : Toast
        {
            public MyToast() : base()
            { }

            public override void OnInitialize()
            {
                base.OnInitialize();
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
        [Description("Toast constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.Toast.Toast C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ToastConstructor()
        {
            tlog.Debug(tag, $"ToastConstructor START");

            ToastStyle style = new ToastStyle()
            { 
                BackgroundColor = Color.Cyan,
            };

            var testingTarget = new Toast(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Toast>(testingTarget, "Should return Toast instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ToastConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Toast FromText.")]
        [Property("SPEC", "Tizen.NUI.Components.Toast.FromText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ToastFromText()
        {
            tlog.Debug(tag, $"ToastFromText START");

            var testingTarget = Toast.FromText("Null parameter construction", 1000);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Toast>(testingTarget, "Should return Toast instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ToastFromText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Toast Duration.")]
        [Property("SPEC", "Tizen.NUI.Components.Toast.Duration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ToastDuration()
        {
            tlog.Debug(tag, $"ToastDuration START");

            var testingTarget = new MyToast();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Toast>(testingTarget, "Should return Toast instance.");

            testingTarget.OnInitialize();

            testingTarget.Duration = 10;
            tlog.Debug(tag, "Duration : " + testingTarget.Duration);

            testingTarget.TextLineSpace = 8;
            tlog.Debug(tag, "testingTarget : " + testingTarget.TextLineSpace);

            testingTarget.TextLineHeight = 15;
            tlog.Debug(tag, "TextLineHeight : " + testingTarget.TextLineHeight);

            testingTarget.TextPadding = new Extents(2, 2, 2, 2);
            tlog.Debug(tag, "TextPadding : " + testingTarget.TextPadding);

            testingTarget.Message = "Toast";
            tlog.Debug(tag, "Message : " + testingTarget.Message);

            testingTarget.TextAlignment = HorizontalAlignment.Center;
            tlog.Debug(tag, "TextAlignment :" + testingTarget.TextAlignment);

            testingTarget.TextArray = new string[2] { "microsoft", "perfomance" };
            tlog.Debug(tag, "TextArray : " + testingTarget.TextArray);

            testingTarget.PointSize = 15.0f;
            tlog.Debug(tag, "PointSize : " + testingTarget.PointSize);

            testingTarget.FontFamily = "BreezeSans";
            tlog.Debug(tag, "FontFamily : " + testingTarget.FontFamily);

            testingTarget.TextColor = Color.Yellow;
            tlog.Debug(tag, "TextColor : " + testingTarget.TextColor);

            try
            {
                testingTarget.Post(Window.Instance);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ToastDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Toast CreateViewStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.Toast.CreateViewStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ToastCreateViewStyle()
        {
            tlog.Debug(tag, $"ToastCreateViewStyle START");

            var testingTarget = new MyToast();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Toast>(testingTarget, "Should return Toast instance.");

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
            tlog.Debug(tag, $"ToastCreateViewStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Toast ApplyStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.Toast.ApplyStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ToastApplyStyle()
        {
            tlog.Debug(tag, $"ToastApplyStyle START");

            var testingTarget = new Toast();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Toast>(testingTarget, "Should return Toast instance.");

            ToastStyle style = new ToastStyle()
            {
                Text = new TextLabelStyle()
                { 
                    Size = new Size(80, 30)
                }
            };

            try
            {
                testingTarget.ApplyStyle(style);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ToastApplyStyle END (OK)");
        }
    }
}
