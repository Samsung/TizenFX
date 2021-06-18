using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/PropertyKey")]
    class PublicPropertyKeyTest
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
        [Description("PropertyKey constructor. With string")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.PropertyKey C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyKeyConstructorWithString()
        {
            tlog.Debug(tag, $"PropertyKeyConstructorWithString START");

            var testingTarget = new PropertyKey("dali");
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyKey>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyKeyConstructorWithString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyKey constructor. With int")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.PropertyKey C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyKeyConstructorWithInt()
        {
            tlog.Debug(tag, $"PropertyKeyConstructorWithInt START");

            var testingTarget = new PropertyKey(7);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyKey>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyKeyConstructorWithInt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyKey Type. String key")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW PRE")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyKeyType()
        {
            tlog.Debug(tag, $"PropertyKeyType START");

            var testingTarget = new PropertyKey("hello world");
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyKey>(testingTarget, "should be an instance of testing target class!");
            Assert.IsTrue(PropertyKey.KeyType.String == testingTarget.Type);

            testingTarget.Type = PropertyKey.KeyType.Index;
            Assert.IsTrue(PropertyKey.KeyType.Index == testingTarget.Type);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyKeyType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyKey Type. Int key")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyKeyTypeWithInt()
        {
            tlog.Debug(tag, $"PropertyKeyTypeWithInt START");

            var testingTarget = new PropertyKey(1);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyKey>(testingTarget, "should be an instance of testing target class!");
            Assert.IsTrue(PropertyKey.KeyType.Index == testingTarget.Type);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyKeyTypeWithInt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyKey IndexKey")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.IndexKey A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyKeyIndexKey()
        {
            tlog.Debug(tag, $"PropertyKeyIndexKey START");

            var testingTarget = new PropertyKey(30);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyKey>(testingTarget, "should be an instance of testing target class!");
            Assert.IsTrue(30 == testingTarget.IndexKey);

            testingTarget.IndexKey = 20;
            Assert.IsTrue(20 == testingTarget.IndexKey);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyKeyIndexKey END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyKey StringKey")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.StringKey A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyKeyStringKey()
        {
            tlog.Debug(tag, $"PropertyKeyStringKey START");

            var testingTarget = new PropertyKey("aKey");
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyKey>(testingTarget, "should be an instance of testing target class!");
            Assert.IsTrue("aKey" == testingTarget.StringKey);
            
            testingTarget.StringKey = "bKey";
            Assert.IsTrue("bKey" == testingTarget.StringKey);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyKeyStringKey END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyKey EqualTo. With String")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyKeyEqualToWithString()
        {
            tlog.Debug(tag, $"PropertyKeyEqualToWithString START");

            var testingTarget = new PropertyKey("hello world");
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyKey>(testingTarget, "should be an instance of testing target class!");

            Assert.IsTrue(testingTarget.EqualTo("hello world"));
            testingTarget.Dispose();

            tlog.Debug(tag, $"PropertyKeyEqualToWithString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyKey EqualTo. With Int")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyKeyEqualToWithInt()
        {
            tlog.Debug(tag, $"PropertyKeyEqualToWithInt START");

            var testingTarget = new PropertyKey(20);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyKey>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.EqualTo(20);
            Assert.IsNotNull(result, "The result should not be null");
            Assert.IsTrue(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyKeyEqualToWithInt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyKey EqualTo. With PropertyKey")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyKeyEqualToWithPropertyKey()
        {
            tlog.Debug(tag, $"PropertyKeyEqualToWithPropertyKey START");

            var pkey1 = new PropertyKey(20);
            Assert.IsNotNull(pkey1, "should be not null");
            Assert.IsInstanceOf<PropertyKey>(pkey1, "should be an instance of PropertyKey class!");

            var pkey2 = pkey1;
            var result = pkey1.EqualTo(pkey2);
            Assert.IsNotNull(result, "The result should not be null");
            Assert.IsTrue(result);

            pkey2.Dispose();
            pkey1.Dispose();
            tlog.Debug(tag, $"PropertyKeyEqualToWithPropertyKey END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyKey NotEqualTo. With String")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyKeyNotEqualToWithString()
        {
            tlog.Debug(tag, $"PropertyKeyNotEqualToWithString START");

            var testingTarget = new PropertyKey("DALI");
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyKey>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.NotEqualTo("HELLO");
            Assert.IsNotNull(result, "The result should not be null");
            Assert.IsTrue(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyKeyNotEqualToWithString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyKey NotEqualTo. With Int")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyKeyNotEqualToWithInt()
        {
            tlog.Debug(tag, $"PropertyKeyNotEqualToWithInt START");

            var testingTarget = new PropertyKey(20);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyKey>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.NotEqualTo(30);
            Assert.IsNotNull(result, "The result should not be null");
            Assert.IsTrue(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyKeyNotEqualToWithInt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyKey NotEqualTo. With PropertyKey")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyKeyNotEqualToWithPropertyKey()
        {
            tlog.Debug(tag, $"PropertyKeyNotEqualToWithPropertyKey START");

            var pKey1 = new PropertyKey(20);
            Assert.IsNotNull(pKey1, "should be not null");
            Assert.IsInstanceOf<PropertyKey>(pKey1, "should be an instance of PropertyKey class!");

            var pKey2 = new PropertyKey(30);
            Assert.IsNotNull(pKey2, "should be not null");
            Assert.IsInstanceOf<PropertyKey>(pKey2, "should be an instance of PropertyKey class!");

            var result = pKey1.NotEqualTo(pKey2);
            Assert.IsNotNull(result, "The result should not be null");
            Assert.IsTrue(result);

            pKey2.Dispose();
            pKey1.Dispose();
            tlog.Debug(tag, $"PropertyKeyNotEqualToWithPropertyKey END (OK)");
        }
    }
}
