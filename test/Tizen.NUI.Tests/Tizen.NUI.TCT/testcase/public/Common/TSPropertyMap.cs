using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/PropertyMap")]
    class PublicPropertyMapTest
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
        [Description("PropertyMap constructor")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.PropertyMap C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyMapConstructor()
        {
            tlog.Debug(tag, $"PropertyMapConstructor START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap constructor. With PropertyMap parameter")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.PropertyMap C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Property("COVPARAM", "PropertyMap")]
        public void PropertyMapConstructorWithPropertyMap()
        {
            tlog.Debug(tag, $"PropertyMapConstructorWithPropertyMap START");

            var dummy = new PropertyMap();
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(dummy, "should be an instance of PropertyMap class!");

            var testingTarget = new PropertyMap(dummy);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");

            testingTarget.Dispose();
            dummy.Dispose();
            tlog.Debug(tag, $"PropertyMapConstructorWithPropertyMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap Insert. Insert key with string")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.this[string] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Property("COVPARAM", "string")]
        public void PropertyMapInsertKeyWithString()
        {
            tlog.Debug(tag, $"PropertyMapInsertKeyWithString START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");

            var dummy = new PropertyValue(14.0f);
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummy, "should be an instance of PropertyValue class!");

            testingTarget.Insert("A", dummy);
            PropertyValue value = testingTarget["A"];
            float result = 0;
            value.Get(out result);
            Assert.IsTrue(result == 14);

            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapInsertKeyWithString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap Insert. Insert key with int")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.this[int] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Property("COVPARAM", "int")]
        public void PropertyMapInsertKeyWithInt()
        {
            tlog.Debug(tag, $"PropertyMapInsertKeyWithInt START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");

            var dummy = new PropertyValue(14.0f);
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummy, "should be an instance of PropertyValue class!");

            testingTarget.Insert(8, dummy);
            PropertyValue value = testingTarget[8];
            float result = 0;
            value.Get(out result);
            Assert.IsTrue(result == 14);

            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapInsertKeyWithInt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap Count")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Count M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyMapCount()
        {
            tlog.Debug(tag, $"PropertyMapCount START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");

            var dummy1 = new PropertyValue(4.0f);
            Assert.IsNotNull(dummy1, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummy1, "should be an instance of PropertyValue class!");

            testingTarget.Insert(8, dummy1);
            
            var dummy2 = new PropertyValue(5.0f);
            Assert.IsNotNull(dummy2, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummy2, "should be an instance of PropertyValue class!");

            testingTarget.Insert(18, dummy2);
            Assert.AreEqual(2, testingTarget.Count(), "Retrive testingTarget.Count() should equal to 2.");

            dummy1.Dispose();
            dummy2.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap Empty")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyMapEmpty()
        {
            tlog.Debug(tag, $"PropertyMapEmpty START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");
            
            Assert.True(testingTarget.Empty(), "the testingTarget is empty");

            var dummy1 = new PropertyValue(4.0f);
            Assert.IsNotNull(dummy1, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummy1, "should be an instance of PropertyValue class!");

            testingTarget.Insert(8, dummy1);

            var dummy2 = new PropertyValue(5.0f);
            Assert.IsNotNull(dummy2, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummy2, "should be an instance of PropertyValue class!");

            testingTarget.Insert(18, dummy2);
            
            Assert.False(testingTarget.Empty(), "the PropertyMap is not empty");

            dummy1.Dispose();
            dummy2.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap Add. Add key with string")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Property("COVPARAM", "string, PropertyValue")]
        public void PropertyMapAddKeyWithString()
        {
            tlog.Debug(tag, $"PropertyMapAddKeyWithString START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");

            PropertyValue dummy = new PropertyValue(4.0f);
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummy, "should be an instance of PropertyValue class!");

            testingTarget.Add("hello", dummy);
            Assert.AreEqual(1, testingTarget.Count(), "Retrive testingTarget.Count() should equal to 1.");

            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapAddKeyWithString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap Add. Add key with int")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Property("COVPARAM", "int, PropertyValue")]
        public void PropertyMapAddKeyWithInt()
        {
            tlog.Debug(tag, $"PropertyMapAddKeyWithInt START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");

            PropertyValue dummy = new PropertyValue(4.0f);
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummy, "should be an instance of PropertyValue class!");

            testingTarget.Add(300, dummy);
            Assert.AreEqual(1, testingTarget.Count(), "Retrive testingTarget.Count() should equal to 1.");

            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapAddKeyWithInt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap Add. Add with KeyValue")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Property("COVPARAM", "KeyValue")]
        [Obsolete]
        public void PropertyMapAddWithKeyValue()
        {
            tlog.Debug(tag, $"PropertyMapAddWithKeyValue START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");

            var dummy = new KeyValue();
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<KeyValue>(dummy, "should be an instance of KeyValue class!");

            dummy.KeyInt = 300;
            dummy.SingleValue = 4.0f;
            testingTarget.Add(dummy);

            Assert.AreEqual(1, testingTarget.Count(), "Add with string and PropertyValue parameter function does not work");
            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapAddWithKeyValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap GetValue")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.GetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyMapGetValue()
        {
            tlog.Debug(tag, $"PropertyMapGetValue START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");

            var dummy = new PropertyValue(4.0f);
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummy, "should be an instance of PropertyValue class!");

            testingTarget.Insert("hello", dummy);
            var result = testingTarget.GetValue(0);
            Assert.IsInstanceOf<PropertyValue>(result, "Should return PropertyValue instance.");

            result.Dispose();
            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapGetValue END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("PropertyMap GetKeyAt")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.GetKeyAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyMapGetKeyAt()
        {
            tlog.Debug(tag, $"PropertyMapGetKeyAt START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");
            
            var dummy = new PropertyValue(4.0f);
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummy, "should be an instance of PropertyValue class!");

            testingTarget.Add("hello", dummy);
            var key = testingTarget.GetKeyAt(0);
            Assert.AreEqual(PropertyKey.KeyType.String, key.Type, "Retrive key.Type should equal to PropertyKey.KeyType.String");

            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapGetKeyAt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap Find. Find with int key")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Find M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Property("COVPARAM", "int")]
        public void PropertyMapFindWithIntKey()
        {
            tlog.Debug(tag, $"PropertyMapFindWithIntKey START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");

            var dummy = new PropertyValue(400.0f);
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummy, "should be an instance of PropertyValue class!");

            testingTarget.Add(2, dummy);
            PropertyValue value = testingTarget.Find(2);
            float result = 0;
            value.Get(out result);
            Assert.AreEqual(400.0f, result, "Retrive result should equal to the set value.");

            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapFindWithIntKey END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap Find. Find with int key and string Key")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Find M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Property("COVPARAM", "int, string")]
        public void PropertyMapFindWithIntAndStringKey()
        {
            tlog.Debug(tag, $"PropertyMapFindWithIntAndStringKey START");
            
            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");
            
            var dummy = new PropertyValue("DALI");
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummy, "should be an instance of PropertyValue class!");

            testingTarget.Add("A", dummy);
            PropertyValue value = testingTarget.Find(10, "A");
            string result = "";
            value.Get(out result);
            Assert.AreEqual("DALI", result, "Retrive result should equal to the set value.");

            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapFindWithIntAndStringKey END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap Clear")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyMapClear()
        {
            tlog.Debug(tag, $"PropertyMapClear START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");

            var dummy = new PropertyValue(5);
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummy, "should be an instance of PropertyValue class!");

            testingTarget.Add(100, dummy);
            testingTarget.Clear();
            Assert.AreEqual(0, testingTarget.Count(), "Retrive testingTarget.Count() should equal to 0.");

            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapClear END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap Merge")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Merge M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyMapMerge()
        {
            tlog.Debug(tag, $"PropertyMapMerge START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");

            var dummyValue1 = new PropertyValue(5);
            Assert.IsNotNull(dummyValue1, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummyValue1, "should be an instance of PropertyValue class!");
            testingTarget.Add(100, dummyValue1);

            var dummy = new PropertyMap();
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(dummy, "should be an instance of PropertyMap class!");

            var dummyValue2 = new PropertyValue(6);
            Assert.IsNotNull(dummyValue2, "should not be null.");
            Assert.IsInstanceOf<PropertyValue>(dummyValue2, "should be an instance of PropertyValue class!");
            dummy.Add("A", dummyValue2);

            testingTarget.Merge(dummy);
            Assert.AreEqual(2, testingTarget.Count(), "Retrive dummy1.Count() should equal to 2.");

            dummyValue2.Dispose();
            dummy.Dispose();
            dummyValue1.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyMapMerge END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyMap Dispose")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyMapDispose()
        {
            tlog.Debug(tag, $"PropertyMapDispose START");

            var testingTarget = new PropertyMap();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyMap>(testingTarget, "should be an instance of PropertyMap class!");
            
            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"PropertyMapDispose END (OK)");
        }
    }
}
