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
    [Description("Controls/TabContent")]
    public class TabContentTest
    {
        private const string tag = "NUITEST";

        internal class MyTabContent : TabContent
        {
            public MyTabContent() : base()
            { }

            public void OnDispose(DisposeTypes types)
            {
                base.Dispose(types);
            }

            public void OnAddView(View view)
            {
                base.AddView(view);
            }

            public void OnRemoveView(View view)
            {
                base.RemoveView(view);
            }

            public void OnSelect(int index)
            {
                base.Select(index);
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
        [Description("TabContent Dispose.")]
        [Property("SPEC", "Tizen.NUI.Components.TabContent.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabContentDispose()
        {
            tlog.Debug(tag, $"TabContentDispose START");

            var testingTarget = new MyTabContent();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabContent>(testingTarget, "Should return TabContent instance.");

            try
            {
                testingTarget.OnDispose(DisposeTypes.Explicit);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabContentDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TabContent RemoveView.")]
        [Property("SPEC", "Tizen.NUI.Components.TabContent.RemoveView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabContentRemoveView()
        {
            tlog.Debug(tag, $"TabContentRemoveView START");

            var testingTarget = new MyTabContent()
            { 
                Size = new Size(100, 100),
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabContent>(testingTarget, "Should return TabContent instance.");

            View dummy1 = new View()
            {
                Size = new Size(50, 100),
                Position = new Position(0, 0),
            };

            View dummy2 = new View()
            {
                Size = new Size(50, 100),
                Position = new Position(50, 0),
            };

            testingTarget.OnAddView(dummy1);
            testingTarget.OnAddView(dummy2);

            testingTarget.OnSelect(0);

            try
            {
                testingTarget.OnRemoveView(dummy1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            dummy1.Dispose();
            dummy2.Dispose();
            testingTarget.OnDispose(DisposeTypes.Explicit);
            tlog.Debug(tag, $"TabContentRemoveView END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("TabContent AddView.")]
        [Property("SPEC", "Tizen.NUI.Components.TabContent.AddView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabContentAddView()
        {
            tlog.Debug(tag, $"TabContentAddView START");

            var testingTarget = new MyTabContent();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabContent>(testingTarget, "Should return TabContent instance.");

            View view = null;

            try
            {
                testingTarget.OnAddView(view);
            }
            catch (ArgumentNullException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"TabContentAddView END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }


        [Test]
        [Category("P2")]
        [Description("TabContent RemoveView.")]
        [Property("SPEC", "Tizen.NUI.Components.TabContent.RemoveView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabContentRemoveViewWithNull()
        {
            tlog.Debug(tag, $"TabContentRemoveViewWithNull START");

            var testingTarget = new MyTabContent();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabContent>(testingTarget, "Should return TabContent instance.");

            View view = null;

            try
            {
                testingTarget.OnRemoveView(view);
            }
            catch (ArgumentNullException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"TabContentRemoveViewWithNull END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

    }
}
