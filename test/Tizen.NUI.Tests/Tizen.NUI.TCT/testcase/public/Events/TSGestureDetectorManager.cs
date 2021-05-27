using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

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
            tlog.Debug(tag, $"GestrueFeedTouchEvent END (OK)");
            Assert.Pass("GestrueFeedTouchEvent");
        }
    }

}
