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

        internal class OrientationHelperImpl : OrientationHelper
        {
            public OrientationHelperImpl(FlexibleViewLayoutManager layoutManager) : base(layoutManager)
            { 
                
            }

            public override float GetEnd()
            {
                throw new NotImplementedException();
            }

            public override float GetEndAfterPadding()
            {
                throw new NotImplementedException();
            }

            public override float GetEndPadding()
            {
                throw new NotImplementedException();
            }

            public override float GetStartAfterPadding()
            {
                throw new NotImplementedException();
            }

            public override float GetTotalSpace()
            {
                throw new NotImplementedException();
            }

            public override float GetViewHolderEnd(FlexibleViewViewHolder holder)
            {
                throw new NotImplementedException();
            }

            public override float GetViewHolderMeasurement(FlexibleViewViewHolder holder)
            {
                throw new NotImplementedException();
            }

            public override float GetViewHolderMeasurementInOther(FlexibleViewViewHolder holder)
            {
                return holder.Bottom - holder.Top;
            }

            public override float GetViewHolderStart(FlexibleViewViewHolder holder)
            {
                throw new NotImplementedException();
            }

            public override void OffsetChildren(float amount, bool immediate)
            {
                throw new NotImplementedException();
            }

            internal override void OffsetChild(FlexibleViewViewHolder holder, int offset)
            {
                throw new NotImplementedException();
            }
        }

        internal class FlexibleViewLayoutManagerImpl : FlexibleViewLayoutManager
        {
            public FlexibleViewLayoutManagerImpl() : base()
            { }

            public override void OnLayoutChildren(FlexibleViewRecycler recycler)
            {
                throw new NotImplementedException();
            }

            protected override int GetNextPosition(int position, Direction direction)
            {
                throw new NotImplementedException();
            }
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

            FlexibleViewLayoutManager manager = new FlexibleViewLayoutManagerImpl();
            Assert.IsNotNull(manager, "should be not null");
            Assert.IsInstanceOf<FlexibleViewLayoutManager>(manager, "should be an instance of testing target class!");

            var testingTarget = new OrientationHelperImpl(manager);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<OrientationHelper>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.OnLayoutComplete();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            manager.Dispose();
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

            FlexibleViewLayoutManager manager = new FlexibleViewLayoutManagerImpl();
            Assert.IsNotNull(manager, "should be not null");
            Assert.IsInstanceOf<FlexibleViewLayoutManager>(manager, "should be an instance of testing target class!");

            var testingTarget = new OrientationHelperImpl(manager);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<OrientationHelper>(testingTarget, "should be an instance of testing target class!");

            try
            {
                var result = testingTarget.GetTotalSpaceChange();
                tlog.Debug(tag, "GetTotalSpaceChange : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            manager.Dispose();
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

            FlexibleViewLayoutManager manager = new FlexibleViewLayoutManagerImpl();
            Assert.IsNotNull(manager, "should be not null");
            Assert.IsInstanceOf<FlexibleViewLayoutManager>(manager, "should be an instance of testing target class!");

            var testingTarget = new OrientationHelperImpl(manager);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<OrientationHelper>(testingTarget, "should be an instance of testing target class!");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                FlexibleViewViewHolder holder = new FlexibleViewViewHolder(view);

                var result = testingTarget.GetViewHolderMeasurementInOther(holder);
                tlog.Debug(tag, "GetViewHolderMeasurementInOther : " + result);
            }

            manager.Dispose();
            tlog.Debug(tag, $"OrientationHelperGetViewHolderMeasurementInOther END (OK)");
        }
    }
}
