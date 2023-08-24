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
    [Description("Style/TimePickerStyle")]
    public class TimePickerStyleTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("TimePickerStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.TimePickerStyle.TimePickerStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePickerStyleConstructor()
        {
            tlog.Debug(tag, $"TimePickerStyleConstructor START");

            TimePickerStyle style = new TimePickerStyle()
            {
                BackgroundColor = Color.Cyan,
            };
            var testingTarget = new TimePickerStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TimePickerStyle>(testingTarget, "Should return TimePickerStyle instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TimePickerStyleConstructor END (OK)");
        }
    }
}
