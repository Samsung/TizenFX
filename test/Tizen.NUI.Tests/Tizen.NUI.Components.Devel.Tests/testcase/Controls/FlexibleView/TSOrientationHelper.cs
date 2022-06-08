using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/FlexibleView/OrientationHelper")]
    public class OrientationHelperTest
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
        [Description("OrientationHelper OnLayoutComplete.")]
        [Property("SPEC", "Tizen.NUI.Components.OrientationHelper.OnLayoutComplete M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void OrientationHelperOnLayoutComplete()
        {
            tlog.Debug(tag, $"OrientationHelperOnLayoutComplete START");

            var testingTarget = new LinearLayoutManager(LinearLayoutManager.VERTICAL);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LinearLayoutManager>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.orientationHelper.OnLayoutComplete();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"OrientationHelperOnLayoutComplete END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("OrientationHelper GetTotalSpaceChange.")]
        [Property("SPEC", "Tizen.NUI.Components.OrientationHelper.GetTotalSpaceChange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void OrientationHelperGetTotalSpaceChange()
        {
            tlog.Debug(tag, $"OrientationHelperGetTotalSpaceChange START");

            var testingTarget = new LinearLayoutManager(LinearLayoutManager.VERTICAL);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LinearLayoutManager>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.orientationHelper.GetTotalSpaceChange();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"OrientationHelperGetTotalSpaceChange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("OrientationHelper GetViewHolderMeasurementInOther.")]
        [Property("SPEC", "Tizen.NUI.Components.OrientationHelper.GetViewHolderMeasurementInOther M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void OrientationHelperGetViewHolderMeasurementInOther()
        {
            tlog.Debug(tag, $"OrientationHelperGetViewHolderMeasurementInOther START");

            using (LinearLayoutManager manager = new LinearLayoutManager(LinearLayoutManager.VERTICAL))
            {
                var testingTarget = new VerticalHelper(manager);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<VerticalHelper>(testingTarget, "should be an instance of testing target class!");

                using (View view = new View() { Size = new Size(100, 200) })
                {
                    FlexibleViewViewHolder holder = new FlexibleViewViewHolder(view);

                    var result = testingTarget.GetViewHolderMeasurementInOther(holder);
                    tlog.Debug(tag, "GetViewHolderMeasurementInOther : " + result);
                }
            }
           
            tlog.Debug(tag, $"OrientationHelperGetViewHolderMeasurementInOther END (OK)");
        }
    }
}
