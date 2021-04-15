using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/PropertyArray")]
    class TSPropertyArray
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
        [Description("PropertyArray constructor")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.PropertyArray C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyArrayConstructor()
        {
            tlog.Debug(tag, $"PropertyArrayConstructor START");

            var testingTarget = new PropertyArray();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyArrayConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyArray Size")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Size M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyArraySize()
        {
            tlog.Debug(tag, $"PropertyArraySize START");

            var testingTarget = new PropertyArray();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Reserve(3);
            Assert.IsTrue(testingTarget.Size() == 0, "testingTarget's size should be 1");
            var pValue = new PropertyValue(1);
            testingTarget.PushBack(pValue);
            Assert.IsTrue(testingTarget.Size() == 1, "testingTarget's size should be 1");

            pValue.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyArraySize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyArray Count")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Count M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyArrayCount()
        {
            tlog.Debug(tag, $"PropertyArrayCount START");

            var testingTarget = new PropertyArray();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(0, testingTarget.Count(), "Retrieved testingTarget.Count() should be equal to 0.");

            testingTarget.Reserve(3);
            var pValue = new PropertyValue(1);
            testingTarget.PushBack(pValue);
            Assert.IsTrue(testingTarget.Count() == 1, "testingTarget's count should be 1");

            pValue.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyArrayCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyArray Empty")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", " MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyArrayEmpty()
        {
            tlog.Debug(tag, $"PropertyArrayEmpty START");

            var testingTarget = new PropertyArray();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Reserve(3);
            Assert.IsTrue(testingTarget.Empty());

            var pVal = new PropertyValue(1);
            testingTarget.PushBack(pVal);
            Assert.IsFalse(testingTarget.Empty());

            pVal.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyArrayEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyArray Clear")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyArrayClear()
        {
            tlog.Debug(tag, $"PropertyArrayClear START");

            var testingTarget = new PropertyArray();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Reserve(3);
            var pValue = new PropertyValue(1);
            testingTarget.PushBack(pValue);
            Assert.IsFalse(testingTarget.Empty());

            testingTarget.Clear();
            Assert.IsTrue(testingTarget.Empty());

            pValue.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyArrayClear END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyArray Reserve")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Reserve M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyArrayReserve()
        {
            tlog.Debug(tag, $"PropertyArrayReserve START");

            var testingTarget = new PropertyArray();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "should be an instance of testing target class!");
            Assert.IsTrue(testingTarget.Capacity() == 0, "testingTarget's capacity should be 0");

            testingTarget.Reserve(3);
            Assert.IsTrue(testingTarget.Capacity() == 3, "testingTarget's capacity should be 3");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyArrayClear END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyArray Resize")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Resize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyArrayResize()
        {
            tlog.Debug(tag, $"PropertyArrayResize START");

            var testingTarget = new PropertyArray();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Resize(5);
            var result = testingTarget.Count();
            Assert.IsTrue(result == 5, "result should be 5");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyArrayResize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyArray Capacity")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Capacity M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyArrayCapacity()
        {
            tlog.Debug(tag, $"PropertyArrayCapacity START");

            var testingTarget = new PropertyArray();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Reserve(6);
            var result = testingTarget.Capacity();
            Assert.IsTrue(result == 6, "result should be 6");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyArrayCapacity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyArray PushBack")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.PushBack M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyArrayPushBack()
        {
            tlog.Debug(tag, $"PropertyArrayPushBack START");

            var testingTarget = new PropertyArray();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "should be an instance of testing target class!");

            var pValue = new PropertyValue(4);
            testingTarget.PushBack(pValue);
            var result = testingTarget.Size();
            Assert.IsTrue(result == 1, "result should be 1");

            pValue.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyArrayPushBack END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyArray Add. Add with property value")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyArrayAddWithProperty()
        {
            tlog.Debug(tag, $"PropertyArrayAddWithProperty START");

            var testingTarget = new PropertyArray();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "should be an instance of testing target class!");

            var pValue = new PropertyValue(14.0f);
            testingTarget.Add(pValue);
            Assert.AreEqual(1, testingTarget.Size(), "Retrieved testingTarget.Size() should be equal to 1.");

            var result = 0.0f;
            testingTarget[0].Get(out result);
            Assert.IsTrue(result == 14.0f, "result should be 14.0f");

            pValue.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyArrayAddWithProperty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyArray Add. Add with key value")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyArrayAddWithKey()
        {
            tlog.Debug(tag, $"PropertyArrayAddWithKey START");

            var testingTarget = new PropertyArray();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "should be an instance of testing target class!");

            var kValue = new KeyValue();
            kValue.SingleValue = 14.0f;
            testingTarget.Add(kValue);
            Assert.AreEqual(1, testingTarget.Size(), "Retrieved testingTarget.Size() should be equal to 1.");
            
            var result = 0.0f;
            testingTarget[0].Get(out result);
            Assert.IsTrue(result == 14.0f, "result should be 14.0f");

            kValue.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyArrayAddWithKey END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyArray GetElementAt")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.GetElementAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyArrayGetElementAt()
        {
            tlog.Debug(tag, $"PropertyArrayGetElementAt START");

            var testingTarget = new PropertyArray();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "should be an instance of testing target class!");

            var pValue = new PropertyValue(3.0f);
            testingTarget.Add(pValue);

            var result = 0.0f;
            testingTarget.GetElementAt(0).Get(out result);
            Assert.IsTrue(result == 3.0f, "result should be 3.0f");

            pValue.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyArrayGetElementAt END (OK)");
        }
    }
}
