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
    [Description("Controls/RadioButtonGroup")]
    public class RadioButtonGroupTest
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
        [Description("RadioButtonGroup SetIsGroupHolder.")]
        [Property("SPEC", "Tizen.NUI.Components.Dialog.SetIsGroupHolder M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RadioButtonGroupSetIsGroupHolder()
        {
            tlog.Debug(tag, $"RadioButtonGroupSetIsGroupHolder START");

            View view = new View()
            {
                Size = new Size(100, 200),
                BackgroundColor = Color.Green,
            };

            RadioButtonGroup.SetIsGroupHolder(view, true);
            tlog.Debug(tag, "GetIsGroupHolder : " + RadioButtonGroup.GetIsGroupHolder(view));

            tlog.Debug(tag, "GetRadioButtonGroup : " + RadioButtonGroup.GetRadioButtonGroup(view));

            view.Dispose();
            tlog.Debug(tag, $"RadioButtonGroupSetIsGroupHolder END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RadioButtonGroup GetItem.")]
        [Property("SPEC", "Tizen.NUI.Components.Dialog.GetItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RadioButtonGroupGetItem()
        {
            tlog.Debug(tag, $"RadioButtonGroupGetItem START");

            var testingTarget = new RadioButtonGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<RadioButtonGroup>(testingTarget, "Should return RadioButtonGroup instance.");

            RadioButton button = new RadioButton();
            
            testingTarget.Add(button);
            var result = testingTarget.GetItem(0);
            tlog.Debug(tag, "GetItem : " + result);

            button.IsSelected = true;
            tlog.Debug(tag, "GetSelectedItem : " + testingTarget.GetSelectedItem());

            try
            {
                testingTarget.Remove(button);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            button.Dispose();
            tlog.Debug(tag, $"RadioButtonGroupGetItem END (OK)");
        }
    }
}
