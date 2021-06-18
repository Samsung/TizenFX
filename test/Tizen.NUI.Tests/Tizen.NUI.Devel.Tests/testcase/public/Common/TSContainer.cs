using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/Container")]
    public class PublicContainerTest
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
        [Description("Container ChildCount.")]
        [Property("SPEC", "Tizen.NUI.Container.ChildCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ContainerChildCount()
        {
            tlog.Debug(tag, $"ContainerChildCount START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            Assert.AreEqual(0, testingTarget.ChildCount, "Should be equal!");

            using (View view = new View())
            {
                testingTarget.Add(view);
                Assert.AreEqual(1, testingTarget.ChildCount, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ContainerChildCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Container ChildCount. Container is Layer.")]
        [Property("SPEC", "Tizen.NUI.Container.ChildCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ContainerChildCountContainerIsLayer()
        {
            tlog.Debug(tag, $"ContainerChildCountContainerIsLayer START");

            var testingTarget = new Layer();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Layer>(testingTarget, "Should return Layer instance.");

            Assert.AreEqual(0, testingTarget.ChildCount, "Should be equal!");

            using (View view = new View())
            {
                testingTarget.Add(view);
                Assert.AreEqual(1, testingTarget.ChildCount, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ContainerChildCountContainerIsLayer END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Container Parent.")]
        [Property("SPEC", "Tizen.NUI.Container.Parent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ContainerParent()
        {
            tlog.Debug(tag, $"ContainerParent START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            using (View view = new View())
            {
                testingTarget.Add(view);

                var result = view.Parent;
                Assert.IsNotNull(result, "Should be not null!");
                Assert.AreEqual(result, testingTarget, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ContainerParent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Container GetParent.")]
        [Property("SPEC", "Tizen.NUI.Container.Parent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ContainerGetParent()
        {
            tlog.Debug(tag, $"ContainerGetParent START");

            var testingTarget = new Layer();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Layer>(testingTarget, "Should return Layer instance.");

            using (View view = new View())
            {
                testingTarget.Add(view);

                var result = view.GetParent();
                Assert.IsNotNull(result, "Should be not null!");
                Assert.AreEqual(result, testingTarget, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ContainerGetParent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Container GetChildCount.")]
        [Property("SPEC", "Tizen.NUI.Container.GetChildCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ContainerGetChildCount()
        {
            tlog.Debug(tag, $"ContainerGetChildCount START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            using (View view = new View())
            {
                testingTarget.Add(view);
                Assert.AreEqual(1, testingTarget.GetChildCount(), "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ContainerGetChildCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Container Remove.")]
        [Property("SPEC", "Tizen.NUI.Container.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ContainerRemove()
        {
            tlog.Debug(tag, $"ContainerRemove START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            using (View view = new View())
            {
                testingTarget.Add(view);
                Assert.AreEqual(1, testingTarget.ChildCount, "Should be equal!");

                testingTarget.Remove(view);
                Assert.AreEqual(0, testingTarget.ChildCount, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ContainerRemove END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Container Remove. Container is Layer.")]
        [Property("SPEC", "Tizen.NUI.Container.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ContainerRemoveContainerIsLayer()
        {
            tlog.Debug(tag, $"ContainerRemoveContainerIsLayer START");

            var testingTarget = new Layer();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Layer>(testingTarget, "Should return Layer instance.");

            using (View view = new View())
            {
                testingTarget.Add(view);
                Assert.AreEqual(1, testingTarget.ChildCount, "Should be equal!");

                testingTarget.Remove(view);
                Assert.AreEqual(0, testingTarget.ChildCount, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ContainerRemoveContainerIsLayer END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Container GetChildAt.")]
        [Property("SPEC", "Tizen.NUI.Container.GetChildAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ContainerGetChildAt()
        {
            tlog.Debug(tag, $"ContainerGetChildAt START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            using (View view = new View())
            {
                testingTarget.Add(view);

                var result = testingTarget.GetChildAt(0);
                Assert.IsTrue((result == view), "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ContainerGetChildAt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Container Children.")]
        [Property("SPEC", "Tizen.NUI.Container.Children A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ContainerChildren()
        {
            tlog.Debug(tag, $"ContainerChildren START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            using (View view = new View())
            {
                testingTarget.Add(view);
                List<View> children = testingTarget.Children;
                Assert.AreEqual(1, children.Count, "Should be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ContainerChildren END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Container Add.")]
        [Property("SPEC", "Tizen.NUI.Container.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ContainerAdd()
        {
            tlog.Debug(tag, $"ContainerAdd START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            using (View view = new View())
            {
                testingTarget.Add(view);
                Assert.AreEqual(1, testingTarget.ChildCount, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ContainerAdd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Container Add. Container is Layer.")]
        [Property("SPEC", "Tizen.NUI.Container.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ContainerAddContainerIsLayer()
        {
            tlog.Debug(tag, $"ContainerAddContainerIsLayer START");

            var testingTarget = new Layer();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Layer>(testingTarget, "Should return Layer instance.");

            using (View view = new View())
            {
                testingTarget.Add(view);
                Assert.AreEqual(1, testingTarget.ChildCount, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ContainerAddContainerIsLayer END (OK)");
        }
    }
}
