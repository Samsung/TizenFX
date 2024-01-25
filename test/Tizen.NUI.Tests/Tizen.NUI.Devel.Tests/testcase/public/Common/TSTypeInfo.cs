using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/TypeInfo")]
    class PublicTypeInfoTest
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
        [Description("TypeInfo constructor")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.TypeInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeInfoConstructor()
        {
            tlog.Debug(tag, $"TypeInfoConstructor START");

            var testingTarget = new TypeInfo();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TypeInfo>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TypeInfoConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TypeInfo constructor. With TypeInfo instance")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.TypeInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeInfoConstructorWithTypeInfo()
        {
            tlog.Debug(tag, $"TypeInfoConstructorWithTypeInfo START");

            var testingTarget = TypeRegistry.Get().GetTypeInfo("PushButton");
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TypeInfo>(testingTarget, "should be an instance of testing target class!");

            var testingTarget2 = new TypeInfo(testingTarget);
            Assert.IsNotNull(testingTarget2, "should be not null");
            Assert.IsInstanceOf<TypeInfo>(testingTarget2, "Should be an instance of TypeInfo type.");

            testingTarget2.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TypeInfoConstructorWithTypeInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TypeInfo CreateInstance")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.CreateInstance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeInfoCreateInstance()
        {
            tlog.Debug(tag, $"TypeInfoCreateInstance START");

            var testingTarget = TypeRegistry.Get().GetTypeInfo("PushButton");
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TypeInfo>(testingTarget, "should be an instance of testing target class!");

            var baseHandle = testingTarget.CreateInstance();
            Assert.IsNotNull(baseHandle, "should be not null");
            Assert.IsInstanceOf<BaseHandle>(baseHandle, "Should be an instance of BaseHandle type.");

            baseHandle.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TypeInfoCreateInstance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TypeInfo GetBaseName")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.GetBaseName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeInfoGetBaseName()
        {
            tlog.Debug(tag, $"TypeInfoGetBaseName START");

            var testingTarget = TypeRegistry.Get().GetTypeInfo("PushButton");
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TypeInfo>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual("Button", testingTarget.GetBaseName(), "Should be equal");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TypeInfoGetBaseName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TypeInfo GetName")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.GetName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeInfoGetName()
        {
            tlog.Debug(tag, $"TypeInfoGetName START");

            var testingTarget = TypeRegistry.Get().GetTypeInfo("PushButton");
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TypeInfo>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual("PushButton", testingTarget.GetName(), "Should be equal");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TypeInfoGetName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TypeInfo GetPropertyCount")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.GetPropertyCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeInfoGetPropertyCount()
        {
            tlog.Debug(tag, $"TypeInfoGetPropertyCount START");

            var testingTarget = TypeRegistry.Get().GetTypeInfo("PushButton");
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TypeInfo>(testingTarget, "should be an instance of testing target class!");
            Assert.Greater(testingTarget.GetPropertyCount(), 0, "The property count should greater than 0");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TypeInfoGetPropertyCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TypeInfo GetPropertyName")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.GetPropertyName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeInfoGetPropertyName()
        {
            tlog.Debug(tag, $"TypeInfoGetPropertyName START");

            var testingTarget = TypeRegistry.Get().GetTypeInfo("ImageView");
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TypeInfo>(testingTarget, "should be an instance of testing target class!");

            var view = new ImageView();
            Assert.IsNotNull(view, "should be not null");
            Assert.IsInstanceOf<ImageView>(view, "should be an instance of ImageView class!");

            int pIndex = view.GetPropertyIndex("image");
            Assert.AreEqual("image", testingTarget.GetPropertyName(pIndex), "Should be equal");
            
            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TypeInfoGetPropertyName END (OK)");
        }
    }
}
