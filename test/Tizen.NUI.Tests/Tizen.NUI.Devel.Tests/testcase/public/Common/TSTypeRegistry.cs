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
    [Description("public/Common/TypeRegistry")]
    public class PublicTypeRegistryTest
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
        [Description("TypeRegistry constructor.")]
        [Property("SPEC", "Tizen.NUI.TypeRegistry.TypeRegistry C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeRegistryConstructor()
        {
            tlog.Debug(tag, $"TypeRegistryConstructor START");

            var testingTarget = new TypeRegistry();
            Assert.IsNotNull(testingTarget, "Can't create success object TypeRegistry");
            Assert.IsInstanceOf<TypeRegistry>(testingTarget, "Should return TypeRegistry instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TypeRegistryConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TypeRegistry Get.")]
        [Property("SPEC", "Tizen.NUI.TypeRegistry.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeRegistryGet()
        {
            tlog.Debug(tag, $"TypeRegistryGet START");

            var testingTarget = TypeRegistry.Get();
            Assert.IsNotNull(testingTarget, "Can't create success object TypeRegistry");
            Assert.IsInstanceOf<TypeRegistry>(testingTarget, "Should return TypeRegistry instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TypeRegistryGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TypeRegistry Assign.")]
        [Property("SPEC", "Tizen.NUI.TypeRegistry.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeRegistryAssign()
        {
            tlog.Debug(tag, $"TypeRegistryAssign START");

            var testingTarget = new TypeRegistry();
            Assert.IsNotNull(testingTarget, "Can't create success object TypeRegistry");
            Assert.IsInstanceOf<TypeRegistry>(testingTarget, "Should return TypeRegistry instance.");

            using (TypeRegistry typeRegistry = TypeRegistry.Get())
            {
                var result = testingTarget.Assign(typeRegistry);
                Assert.IsNotNull(result, "Can't create success object TypeRegistry");
                Assert.IsInstanceOf<TypeRegistry>(result, "Should return TypeRegistry instance.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TypeRegistryAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TypeRegistry GetTypeInfo.")]
        [Property("SPEC", "Tizen.NUI.TypeRegistry.GetTypeInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeRegistryGetTypeInfo()
        {
            tlog.Debug(tag, $"TypeRegistryGetTypeInfo START");

            var testingTarget = TypeRegistry.Get();
            Assert.IsNotNull(testingTarget, "Can't create success object TypeRegistry");
            Assert.IsInstanceOf<TypeRegistry>(testingTarget, "Should return TypeRegistry instance.");

            var result = testingTarget.GetTypeInfo("ImageView");
            Assert.IsNotNull(result, "should be not null");
            Assert.IsInstanceOf<TypeInfo>(result, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TypeRegistryGetTypeInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TypeRegistry GetTypeNameCount.")]
        [Property("SPEC", "Tizen.NUI.TypeRegistry.GetTypeNameCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeRegistryGetTypeNameCount()
        {
            tlog.Debug(tag, $"TypeRegistryGetTypeNameCount START");

            var testingTarget = TypeRegistry.Get();
            Assert.IsNotNull(testingTarget, "Can't create success object TypeRegistry");
            Assert.IsInstanceOf<TypeRegistry>(testingTarget, "Should return TypeRegistry instance.");

            var result = testingTarget.GetTypeNameCount();
            Assert.IsNotNull(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TypeRegistryGetTypeNameCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TypeRegistry GetTypeName.")]
        [Property("SPEC", "Tizen.NUI.TypeRegistry.GetTypeName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeRegistryGetTypeName()
        {
            tlog.Debug(tag, $"TypeRegistryGetTypeName START");

            var testingTarget = TypeRegistry.Get();
            Assert.IsNotNull(testingTarget, "Can't create success object TypeRegistry");
            Assert.IsInstanceOf<TypeRegistry>(testingTarget, "Should return TypeRegistry instance.");

            var result = testingTarget.GetTypeName(0);
            Assert.IsNotNull(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TypeRegistryGetTypeName END (OK)");
        }
    }
}
