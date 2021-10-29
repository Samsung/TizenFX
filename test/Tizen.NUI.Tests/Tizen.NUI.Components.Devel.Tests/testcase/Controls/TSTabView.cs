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
    [Description("Controls/TabView")]
    public class TabViewTest
    {
        private const string tag = "NUITEST";

        internal class MyTabView : TabView
        {
            public MyTabView() : base()
            { }

            public void OnDispose(DisposeTypes types)
            {
                base.Dispose(types);
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
        [Description("TabView Dispose.")]
        [Property("SPEC", "Tizen.NUI.Components.TabView.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabViewDispose()
        {
            tlog.Debug(tag, $"TabViewDispose START");

            var testingTarget = new MyTabView();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabView>(testingTarget, "Should return TabView instance.");

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
            tlog.Debug(tag, $"TabViewDispose END (OK)");
        }
    }
}
