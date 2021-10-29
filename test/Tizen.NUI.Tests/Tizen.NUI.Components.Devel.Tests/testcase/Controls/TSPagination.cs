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
    [Description("Controls/Pagination")]
    public class PaginationTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MyPagination : Pagination
        {
            public MyPagination() : base()
            { }

            public void MyAccessibilitySetCurrent(double value)
            {
                base.AccessibilitySetCurrent(value);
            }

            public void MyAccessibilityGetMinimumIncrement()
            {
                base.AccessibilityGetMinimumIncrement();
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
        [Description("Pagination LastIndicatorImageUrl.")]
        [Property("SPEC", "Tizen.NUI.Components.Pagination.LastIndicatorImageUrl M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaginationLastIndicatorImageUrl()
        {
            tlog.Debug(tag, $"PaginationLastIndicatorImageUrl START");

            PaginationStyle style = new PaginationStyle()
            {
                Size = new Size(80, 20),
            };

            var testingTarget = new Pagination(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Pagination>(testingTarget, "Should return Pagination instance.");

            Selector<String> url = new Selector<string>();
            url.Add(ControlState.All, image_path);

            testingTarget.LastIndicatorImageUrl = url;
            tlog.Debug(tag, "LastIndicatorImageUrl : " + testingTarget.LastIndicatorImageUrl);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PaginationLastIndicatorImageUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Pagination AccessibilitySetCurrent.")]
        [Property("SPEC", "Tizen.NUI.Components.Pagination.AccessibilitySetCurrent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaginationAccessibilitySetCurrent()
        {
            tlog.Debug(tag, $"PaginationAccessibilitySetCurrent START");

            var testingTarget = new MyPagination();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Pagination>(testingTarget, "Should return Pagination instance.");

            testingTarget.IndicatorCount = 8;

            try
            {
                testingTarget.MyAccessibilitySetCurrent(5.0f);
                testingTarget.MyAccessibilityGetMinimumIncrement();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PaginationAccessibilitySetCurrent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Pagination SelectedIndex.")]
        [Property("SPEC", "Tizen.NUI.Components.Pagination.SelectedIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaginationSelectedIndex()
        {
            tlog.Debug(tag, $"PaginationSelectedIndex START");

            var testingTarget = new MyPagination();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Pagination>(testingTarget, "Should return Pagination instance.");

            testingTarget.IndicatorCount = 8;

            testingTarget.SelectedIndex = 9;
            tlog.Debug(tag, "SelectedIndex : " + testingTarget.SelectedIndex);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PaginationSelectedIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Pagination SelectedIndicatorColor.")]
        [Property("SPEC", "Tizen.NUI.Components.Pagination.SelectedIndicatorColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaginationSelectedIndicatorColor()
        {
            tlog.Debug(tag, $"PaginationSelectedIndicatorColor START");

            var testingTarget = new MyPagination();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Pagination>(testingTarget, "Should return Pagination instance.");

            testingTarget.IndicatorCount = 8;
            testingTarget.SelectedIndex = 5;
            testingTarget.SelectedIndicatorColor = Color.Black;
            tlog.Debug(tag, "SelectedIndicatorColor : " + testingTarget.SelectedIndicatorColor);

            // indicatorCount > value
            testingTarget.IndicatorCount = 7;
            // selectedIndex >= value
            testingTarget.SelectedIndex = 7;

            testingTarget.Dispose();
            tlog.Debug(tag, $"PaginationSelectedIndicatorColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Pagination IndicatorColor.")]
        [Property("SPEC", "Tizen.NUI.Components.Pagination.IndicatorColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaginationIndicatorColor()
        {
            tlog.Debug(tag, $"PaginationIndicatorColor START");

            var testingTarget = new MyPagination();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Pagination>(testingTarget, "Should return Pagination instance.");

            testingTarget.IndicatorCount = 8;
            testingTarget.SelectedIndex = 5;
            testingTarget.IndicatorColor = Color.Black;
            tlog.Debug(tag, "IndicatorColor : " + testingTarget.IndicatorColor);
            testingTarget.IndicatorColor = Color.Yellow;
            tlog.Debug(tag, "IndicatorColor : " + testingTarget.IndicatorColor);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PaginationIndicatorColor END (OK)");
        }
    }
}
