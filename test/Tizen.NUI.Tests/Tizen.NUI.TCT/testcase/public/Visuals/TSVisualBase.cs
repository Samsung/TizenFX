using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/VisualBase")]
    public class PublicVisualBaseTest
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
        [Description("VisualBase constructor.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.VisualBase C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualBaseConstructor()
        {
            tlog.Debug(tag, $"VisualBaseConstructor START");

            var testingTarget = new VisualBase();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualBase");
            Assert.IsInstanceOf<VisualBase>(testingTarget, "Should return VisualBase instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualBaseConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualBase Name.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.Name A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualBaseName()
        {
            tlog.Debug(tag, $"VisualBaseName START");

            VisualFactory visualfactory = VisualFactory.Instance;

            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
            propertyMap.Insert(TextVisualProperty.Text, new PropertyValue("Hello Goodbye"));
            
            var testingTarget = visualfactory.CreateVisual(propertyMap);
            Assert.IsNotNull(testingTarget, "Can't create success object VisualBase");
            Assert.IsInstanceOf<VisualBase>(testingTarget, "Should return VisualBase instance.");

            testingTarget.Name = "VisualBase1";
            Assert.AreEqual("VisualBase1", testingTarget.Name, "Name function does not work, return incorrect name.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualBaseName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualBase SetTransformAndSize.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.SetTransformAndSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualBaseSetTransformAndSize()
        {
            tlog.Debug(tag, $"VisualBaseSetTransformAndSize START");

            try
            {
                VisualFactory visualfactory = VisualFactory.Instance;

                PropertyMap propertyMap = new PropertyMap();
                propertyMap.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
                propertyMap.Insert(Visual.Property.Type, new PropertyValue("Hello Goodbye"));
                
                var testingTarget = visualfactory.CreateVisual(propertyMap);
                Assert.IsNotNull(testingTarget, "Can't create success object VisualBase");
                Assert.IsInstanceOf<VisualBase>(testingTarget, "Should return VisualBase instance.");

                using (Vector2 vec2 = new Vector2(2.0f, 0.8f))
                {
                    testingTarget.SetTransformAndSize(propertyMap, vec2);
                }

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.IsTrue(e is ArgumentException, "Argument Exception Not Recieved");
            }

            tlog.Debug(tag, $"VisualBaseSetTransformAndSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualBase GetHeightForWidth.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.GetHeightForWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualBaseGetHeightForWidth()
        {
            tlog.Debug(tag, $"VisualBaseGetHeightForWidth START");

            VisualFactory visualfactory = VisualFactory.Instance;

            using (PropertyMap propertyMap = new PropertyMap())
            {
                propertyMap.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
                propertyMap.Insert(Visual.Property.Type, new PropertyValue(""));
                
                var testingTarget = visualfactory.CreateVisual(propertyMap);
                Assert.IsNotNull(testingTarget, "Can't create success object VisualBase");
                Assert.IsInstanceOf<VisualBase>(testingTarget, "Should return VisualBase instance.");

                Assert.AreEqual(0.0f, testingTarget.GetHeightForWidth(0.0f), "The height got from GetHeightForWidth is not correct.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VisualBaseGetHeightForWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualBase GetWidthForHeight.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.GetWidthForHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualBaseGetWidthForHeight()
        {
            tlog.Debug(tag, $"VisualBaseGetWidthForHeight START");

            VisualFactory visualfactory = VisualFactory.Instance;

            using (PropertyMap propertyMap = new PropertyMap())
            {
                propertyMap.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
                propertyMap.Insert(Visual.Property.Type, new PropertyValue(""));

                var testingTarget = visualfactory.CreateVisual(propertyMap);
                Assert.IsNotNull(testingTarget, "Can't create success object VisualBase");
                Assert.IsInstanceOf<VisualBase>(testingTarget, "Should return VisualBase instance.");

                Assert.AreEqual(0.0f, testingTarget.GetWidthForHeight(0.0f), "The Width got from GetWidthForHeight is not correct.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VisualBaseGetWidthForHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualBase GetNaturalSize.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.GetNaturalSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualBaseGetNaturalSize()
        {
            tlog.Debug(tag, $"VisualBaseGetNaturalSize START");

            try
            {
                VisualFactory visualfactory = VisualFactory.Instance;

                using (PropertyMap propertyMap = new PropertyMap())
                {
                    propertyMap.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));

                    var testingTarget = visualfactory.CreateVisual(propertyMap);
                    Assert.IsNotNull(testingTarget, "Can't create success object VisualBase");
                    Assert.IsInstanceOf<VisualBase>(testingTarget, "Should return VisualBase instance.");

                    using (Size2D size2d = new Size2D(1, 2))
                    {
                        testingTarget.GetNaturalSize(size2d);
                        Assert.AreEqual(0.0f, size2d.Height, "The Height got from GetNaturalSize is not right");
                        Assert.AreEqual(0.0f, size2d.Width, "The Width got from GetNaturalSize is not right");
                    }

                    testingTarget.Dispose();
                }

                visualfactory.Dispose();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"VisualBaseGetNaturalSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualBase DepthIndex.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.DepthIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualBaseDepthIndex()
        {
            tlog.Debug(tag, $"VisualBaseDepthIndex START");

            VisualFactory visualfactory = VisualFactory.Instance;

            using (PropertyMap propertyMap = new PropertyMap())
            {
                propertyMap.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
                propertyMap.Insert(Visual.Property.Type, new PropertyValue("Hello Goodbye"));
                
                var testingTarget = visualfactory.CreateVisual(propertyMap);
                Assert.IsNotNull(testingTarget, "Can't create success object VisualBase");
                Assert.IsInstanceOf<VisualBase>(testingTarget, "Should return VisualBase instance.");

                testingTarget.DepthIndex = 1;
                Assert.AreEqual(1, testingTarget.DepthIndex, "The DepthIndex got from DepthIndex is not right");

                testingTarget.Dispose();
            }
            
            visualfactory.Dispose();
            tlog.Debug(tag, $"VisualBaseDepthIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualBase Creation.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.Creation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualBaseCreation()
        {
            tlog.Debug(tag, $"VisualBaseCreation START");

            try
            {
                VisualFactory visualfactory = VisualFactory.Instance;

                using (PropertyMap propertyMap = new PropertyMap())
                {
                    propertyMap.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
                    propertyMap.Insert(TextVisualProperty.Text, new PropertyValue("Hello"));
                    propertyMap.Insert(TextVisualProperty.PointSize, new PropertyValue(10.0f));

                    var testingTarget = visualfactory.CreateVisual(propertyMap);
                    Assert.IsNotNull(testingTarget, "Can't create success object VisualBase");
                    Assert.IsInstanceOf<VisualBase>(testingTarget, "Should return VisualBase instance.");

                    var result = testingTarget.Creation;
                    Assert.IsNotNull(result, "Can't create success object VisualBase");
                    Assert.IsInstanceOf<PropertyMap>(result, "Should return PropertyMap instance.");

                    testingTarget.Dispose();
                    result.Dispose();
                }

                visualfactory.Dispose();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.IsTrue(e is ArgumentException, "Argument Exception Not Recieved");
            }

            tlog.Debug(tag, $"VisualBaseCreation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualBase Dispose.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualBaseDispose()
        {
            tlog.Debug(tag, $"VisualBaseDispose START");

            var testingTarget = new VisualBase();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualBase");
            Assert.IsInstanceOf<VisualBase>(testingTarget, "Should return VisualBase instance.");
            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualBaseDispose END (OK)");
        }
    }
}
