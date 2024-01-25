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
    [Description("Style/RecyclerViewItemStyle")]
    public class RecyclerViewItemStyleTest
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
        [Description("RecyclerViewItemStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItemStyle.RecyclerViewItemStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RecyclerViewItemStyleConstructor()
        {
            tlog.Debug(tag, $"RecyclerViewItemStyleConstructor START");

            var style = new RecyclerViewItemStyle()
            { 
                BackgroundColor = Color.Cyan,
            };

            var testingTarget = new RecyclerViewItemStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<RecyclerViewItemStyle>(testingTarget, "Should return RecyclerViewItemStyle instance.");

            testingTarget.IsEnabled = true;
            tlog.Debug(tag, "IsEnabled : " + testingTarget.IsEnabled);

            testingTarget.IsSelectable = true;
            tlog.Debug(tag, "IsSelectable : " + testingTarget.IsSelectable);

            testingTarget.IsSelected = false;
            tlog.Debug(tag, "IsSelected : " + testingTarget.IsSelected);

            testingTarget.IsSelected = true;
            tlog.Debug(tag, "IsSelected : " + testingTarget.IsSelected);

            tlog.Debug(tag, $"RecyclerViewItemStyleConstructor END (OK)");
        }
    }
}
