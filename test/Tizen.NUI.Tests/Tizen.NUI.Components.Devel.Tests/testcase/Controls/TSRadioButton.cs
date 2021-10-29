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
    [Description("Controls/RadioButton")]
    public class RadioButtonTest
    {
        private const string tag = "NUITEST";

        internal class MyRadioButton : RadioButton 
        {
            public MyRadioButton() : base()
            { }

            public override bool OnKey(Key key)
            {
                return base.OnKey(key);
            }

            public void MyHandleControlStateOnTouch(Touch touch)
            {
                base.HandleControlStateOnTouch(touch);
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
        [Description("RadioButton ItemGroup.")]
        [Property("SPEC", "Tizen.NUI.Components.RadioButton.ItemGroup M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RadioButtonItemGroup()
        {
            tlog.Debug(tag, $"RadioButtonItemGroup START");

            var testingTarget = new RadioButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<RadioButton>(testingTarget, "Should return RadioButton instance.");

            var group = new RadioButtonGroup();
            group.Add(testingTarget);

            tlog.Debug(tag, "ItemGroup : " + testingTarget.ItemGroup);

            testingTarget.Dispose();
            tlog.Debug(tag, $"RadioButtonItemGroup END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RadioButton OnKey.")]
        [Property("SPEC", "Tizen.NUI.Components.RadioButton.OnKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RadioButtonOnKey()
        {
            tlog.Debug(tag, $"RadioButtonOnKey START");

            var testingTarget = new MyRadioButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<RadioButton>(testingTarget, "Should return RadioButton instance.");

            testingTarget.IsEnabled = true;
            testingTarget.IsSelected = true;

            Key key = null;
            var result = testingTarget.OnKey(key);
            Assert.AreEqual(false, result, "should be equal here!");

            key = new Key()
            {
                State = Key.StateType.Up,
                KeyPressedName = "Return"
            };
            result = testingTarget.OnKey(key);
            tlog.Debug(tag, "OnKey : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"RadioButtonOnKey END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RadioButton HandleControlStateOnTouch.")]
        [Property("SPEC", "Tizen.NUI.Components.RadioButton.HandleControlStateOnTouch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RadioHandleControlStateOnTouch()
        {
            tlog.Debug(tag, $"RadioButtonOnKey START");

            var testingTarget = new MyRadioButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<RadioButton>(testingTarget, "Should return RadioButton instance.");

            testingTarget.IsEnabled = true;
            Touch touch = new Touch();

            try
            {
                testingTarget.MyHandleControlStateOnTouch(touch);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RadioButtonOnKey END (OK)");
        }
    }
}
