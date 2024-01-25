using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/RecyclerView/ItemSource/EmptySource")]
    class TSEmptySource
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
        [Description("EmptySource Count.")]
        [Property("SPEC", "Tizen.NUI.Components.EmptySource.Count A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void EmptySourceCount()
        {
            tlog.Debug(tag, $"EmptySourceCount START");

            var testingTarget = new EmptySource();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<EmptySource>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.Count, 0, "Count of EmptySource should be equal to 0.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"EmptySourceCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("EmptySource HasHeader.")]
        [Property("SPEC", "Tizen.NUI.Components.EmptySource.HasHeader A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void EmptySourceHasHeader()
        {
            tlog.Debug(tag, $"EmptySourceHasHeader START");

            var testingTarget = new EmptySource();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<EmptySource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasHeader = true;
            Assert.IsTrue(testingTarget.HasHeader, "EmptySource should have a header.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"EmptySourceHasHeader END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("EmptySource HasFooter.")]
        [Property("SPEC", "Tizen.NUI.Components.EmptySource.HasFooter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void EmptySourceHasFooter()
        {
            tlog.Debug(tag, $"EmptySourceHasFooter START");

            var testingTarget = new EmptySource();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<EmptySource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasFooter = true;
            Assert.IsTrue(testingTarget.HasFooter, "EmptySource should have a footer.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"EmptySourceHasFooter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("EmptySource IsHeader.")]
        [Property("SPEC", "Tizen.NUI.Components.EmptySource.IsHeader M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void EmptySourceIsHeader()
        {
            tlog.Debug(tag, $"EmptySourceIsHeader START");

            var testingTarget = new EmptySource();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<EmptySource>(testingTarget, "should be an instance of testing target class!");
            testingTarget.HasHeader = true;
            Assert.IsTrue(testingTarget.IsHeader(0), "The first item of EmptySource should is header.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"EmptySourceIsHeader END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("EmptySource IsFooter.")]
        [Property("SPEC", "Tizen.NUI.Components.EmptySource.IsFooter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void EmptySourceIsFooter()
        {
            tlog.Debug(tag, $"EmptySourceIsFooter START");

            var testingTarget = new EmptySource();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<EmptySource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasFooter = true;
            Assert.IsTrue(testingTarget.IsFooter(0), "The last item of EmptySource should is footer.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"EmptySourceIsFooter END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("EmptySource IsFooter.")]
        [Property("SPEC", "Tizen.NUI.Components.EmptySource.IsFooter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void EmptySourceIsFooterWithHeader()
        {
            tlog.Debug(tag, $"EmptySourceIsFooterWithHeader START");

            var testingTarget = new EmptySource();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<EmptySource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasHeader = true;
            tlog.Debug(tag, "IsFooter : " + testingTarget.IsFooter(1));
       
            testingTarget.Dispose();
            tlog.Debug(tag, $"EmptySourceIsFooterWithHeader END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("EmptySource IsFooter.")]
        [Property("SPEC", "Tizen.NUI.Components.EmptySource.IsFooter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void EmptySourceIsFooterWithoutFooter()
        {
            tlog.Debug(tag, $"EmptySourceIsFooterWithoutFooter START");

            var testingTarget = new EmptySource();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<EmptySource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasFooter = false;
            Assert.IsFalse(testingTarget.IsFooter(0), "EmptySource should not have footer.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"EmptySourceIsFooterWithoutFooter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("EmptySource GetPosition.")]
        [Property("SPEC", "Tizen.NUI.Components.EmptySource.GetPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void EmptySourceGetPosition()
        {
            tlog.Debug(tag, $"EmptySourceGetPosition START");

            var testingTarget = new EmptySource();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<EmptySource>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.GetPosition(0), -1, "The index of the first item of EmptySource should be -1.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"EmptySourceGetPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("EmptySource GetItem.")]
        [Property("SPEC", "Tizen.NUI.Components.EmptySource.GetItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void EmptySourceGetItem()
        {
            tlog.Debug(tag, $"EmptySourceGetItem START");

            var testingTarget = new EmptySource();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<EmptySource>(testingTarget, "should be an instance of testing target class!");

            try
            {
                var ret = testingTarget.GetItem(0);
            }
            catch (IndexOutOfRangeException e)
            {
                Assert.AreEqual(e.Message, "IItemSource is empty", "GetItem of EmptySource should not be implemented.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"EmptySourceGetItem END (OK)");
        }
    }
}
