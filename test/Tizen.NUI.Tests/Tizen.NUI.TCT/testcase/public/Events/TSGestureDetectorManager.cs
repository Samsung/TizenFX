using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Events;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/GestureDetectorManager")]
    class PublicGestureDetectorManagerTest
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
        [Description("GestureDetectorManager constructor")]
        [Property("SPEC", "Tizen.NUI.GestureDetectorManager.GestureDetectorManager C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureDetectorManagerConstructor()
        {
            tlog.Debug(tag, $"GestureDetectorManagerConstructor START");
            View view = new View();

            GestureDetectorManager a1 = new GestureDetectorManager(view, new GestureDetectorManager.GestureListener());
            a1.Dispose();

            GestureDetectorManager b1 = new GestureDetectorManager(null, new GestureDetectorManager.GestureListener());
            GestureDetectorManager c1 = new GestureDetectorManager(view, null);
            view.Dispose();

            tlog.Debug(tag, $"GestureDetectorManagerConstructor END (OK)");
            Assert.Pass("GestureDetectorManagerConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("GestureDetectorManager FeedTouchEvent")]
        [Property("SPEC", "Tizen.NUI.GestureDetectorManager.FeedTouchEvent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestrueFeedTouchEvent()
        {
            tlog.Debug(tag, $"GestrueFeedTouchEvent START");
            object sender = new object();
            View view = new View();
            View.TouchEventArgs e = new View.TouchEventArgs();
            GestureDetectorManager a1 = new GestureDetectorManager(view, new GestureDetectorManager.GestureListener());

            a1.FeedTouchEvent(sender, e);

            a1.Dispose();
            tlog.Debug(tag, $"GestrueFeedTouchEvent END (OK)");
            Assert.Pass("GestrueFeedTouchEvent");
        }
    }

}
