using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/Layer")]
    public class PublicLayerTest
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
        [Description("Layer constructor.")]
        [Property("SPEC", "Tizen.NUI.Layer.Layer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayerConstructor()
        {
            tlog.Debug(tag, $"LayerConstructor START");

            var testingTarget = new Layer();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Layer>(testingTarget, "Should return Layer instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Layer add.")]
        [Property("SPEC", "Tizen.NUI.Layer.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayerAdd()
        {
            tlog.Debug(tag, $"LayerAdd START");

            var testingTarget = new Layer();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Layer>(testingTarget, "Should return Layer instance.");

            using (View view = new View())
            {
                testingTarget.Add(view);
                Assert.AreEqual(1, testingTarget.ChildCount, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayerAdd END (OK)");
        }
        [Test]
        [Category("P1")]
        [Description("Layer ChildCount.")]
        [Property("SPEC", "Tizen.NUI.Layer.ChildCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayerChildCount()
        {
            tlog.Debug(tag, $"LayerChildCount START");

            var testingTarget = new Layer();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Layer>(testingTarget, "Should return Layer instance.");

            using (View view = new View())
            {
                testingTarget.Add(view);
                Assert.AreEqual(1, testingTarget.ChildCount, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayerChildCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Layer Name.")]
        [Property("SPEC", "Tizen.NUI.Layer.Name A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayerName()
        {
            tlog.Debug(tag, $"LayerName START");

            var testingTarget = new Layer() 
            {
                Name = "Layer"
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Layer>(testingTarget, "Should return Layer instance.");

            Assert.AreEqual("Layer", testingTarget.Name, "The layer's Name is not correct");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayerName END (OK)");
        }
        [Test]
        [Category("P1")]
        [Description("Layer Viewport.")]
        [Property("SPEC", "Tizen.NUI.Layer.Viewport A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayerViewport()
        {
            tlog.Debug(tag, $"LayerViewport START");

            var testingTarget = new Layer();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Layer>(testingTarget, "Should return Layer instance.");

            using (Rectangle rec = new Rectangle(0, 0, 1, 1))
            {
                testingTarget.Viewport = rec;
                Assert.AreEqual(0, testingTarget.Viewport.X, "Should be equal!");
                Assert.AreEqual(0, testingTarget.Viewport.Y, "Should be equal!");
                Assert.AreEqual(1, testingTarget.Viewport.Width, "Should be equal!");
                Assert.AreEqual(1, testingTarget.Viewport.Height, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayerViewport END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Layer GetChildCount.")]
        [Property("SPEC", "Tizen.NUI.Layer.GetChildCount C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void LayerGetChildCount()
        {
            tlog.Debug(tag, $"LayerGetChildCount START");

            var testingTarget = new Layer();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Layer>(testingTarget, "Should return Layer instance.");

            using (View view = new View())
            {
                testingTarget.Add(view);
                Assert.AreEqual(1, testingTarget.GetChildCount(), "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayerGetChildCount END (OK)");
        }
        [Test]
        [Category("P1")]
        [Description("Layer remove")]
        [Property("SPEC", "Tizen.NUI.Layer.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayerRemove()
        {
            tlog.Debug(tag, $"LayerRemove START");

            var testingTarget = new Layer();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Layer>(testingTarget, "Should return Layer instance.");

            try
            {
                using (View view = new View())
                {
                    testingTarget.Add(view);
                    testingTarget.Remove(view);
                }
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayerRemove END (OK)");
        }
        [Test]
        [Category("P1")]
        [Description("Layer GetChildAt.")]
        [Property("SPEC", "Tizen.NUI.Layer.GetChildAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayerGetChildAt()
        {
            tlog.Debug(tag, $"LayerGetChildAt START");

            View view = new View() 
            {
                Name = "Child",
                Size = new Size(100.0f, 100.0f, 100.0f)
            };

            var testingTarget = new Layer();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Layer>(testingTarget, "Should return Layer instance.");

            testingTarget.Add(view);
            Assert.IsNotNull(testingTarget.GetChildAt(0), "Should be not null");

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"LayerGetChildAt END (OK)");
        }
        [Test]
        [Category("P1")]
        [Description("Layer Behavior.")]
        [Property("SPEC", "Tizen.NUI.Layer.Behavior A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayerBehavior()
        {
            tlog.Debug(tag, $"LayerBehavior START");

            var testingTarget = new Layer() 
            {
                Behavior = Layer.LayerBehavior.Layer3D
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Layer>(testingTarget, "Should return Layer instance.");

            Assert.AreEqual(testingTarget.Behavior, Layer.LayerBehavior.Layer3D, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayerBehavior END (OK)");
        }
    }
}
