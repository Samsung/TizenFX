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
    [Description("Controls/FlexibleView/FlexibleViewRecycler")]
    public class FlexibleViewRecyclerTest
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
        [Description("FlexibleViewRecycler SetViewCacheSize.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewRecycler.SetViewCacheSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexibleViewRecyclerSetViewCacheSize()
        {
            tlog.Debug(tag, $"FlexibleViewRecyclerSetViewCacheSize START");

            using (FlexibleView recyclerView = new FlexibleView() { Padding = new Extents(10, 10, 10, 10) })
            {
                var testingTarget = new FlexibleViewRecycler(recyclerView);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<FlexibleViewRecycler>(testingTarget, "should be an instance of testing target class!");

                try
                {
                    testingTarget.SetViewCacheSize(5);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"FlexibleViewRecyclerSetViewCacheSize END (OK)");
        }
    }
}
