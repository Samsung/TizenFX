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

            using (View view = new View())
            {
                var testingTarget = new GestureDetectorManager(view, new GestureDetectorManager.GestureListener());
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<GestureDetectorManager>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"GestureDetectorManagerConstructor END (OK)");
            Assert.Pass("GestureDetectorManagerConstructor");
        }

        [Test]
        [Category("P2")]
        [Description("GestureDetectorManager constructor")]
        [Property("SPEC", "Tizen.NUI.GestureDetectorManager.GestureDetectorManager C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureDetectorManagerConstructorWithNullView()
        {
            tlog.Debug(tag, $"GestureDetectorManagerConstructorWithNullView START");

            try
            {
                var testingTarget = new GestureDetectorManager(null, new GestureDetectorManager.GestureListener());
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"GestureDetectorManagerConstructorWithNullView END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("GestureDetectorManager constructor")]
        [Property("SPEC", "Tizen.NUI.GestureDetectorManager.GestureDetectorManager C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureDetectorManagerConstructorWithNullListener()
        {
            tlog.Debug(tag, $"GestureDetectorManagerConstructorWithNullListener START");

            try
            {
                using (View view = new View())
                {
                    var testingTarget = new GestureDetectorManager(view, null);

                }
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"GestureDetectorManagerConstructorWithNullListener END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }
    }
}
