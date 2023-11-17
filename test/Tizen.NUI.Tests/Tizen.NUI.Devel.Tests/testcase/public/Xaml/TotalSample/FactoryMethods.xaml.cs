using NUnit.Framework;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    public class MockView : View
    {
        public MockFactory Content { get; set; }
    }

    public class MockFactory
    {
        public string Content { get; set; }
        public MockFactory()
        {
            Content = "default ctor";
        }

        public MockFactory(string arg0, string arg1)
        {
            Content = "alternate ctor " + arg0 + arg1;
        }

        public MockFactory(string arg0)
        {
            Content = "alternate ctor " + arg0;
        }

        public MockFactory(int arg)
        {
            Content = "int ctor " + arg.ToString();
        }

        public MockFactory(object[] args)
        {
            Content = string.Join(" ", args);
        }

        public static MockFactory ParameterlessFactory()
        {
            return new MockFactory
            {
                Content = "parameterless factory",
            };
        }

        public static MockFactory Factory(string arg0, int arg1)
        {
            return new MockFactory
            {
                Content = "factory " + arg0 + arg1,
            };
        }

        public static MockFactory Factory(int arg0, string arg1)
        {
            return new MockFactory
            {
                Content = "factory " + arg0 + arg1,
            };
        }
    }

    public partial class FactoryMethods : View
    {
        public FactoryMethods()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(FactoryMethods));
#pragma warning restore Reflection // The code contains reflection

            v0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<MockView>(this, "v0");
            v1 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<MockView>(this, "v1");
            v2 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<MockView>(this, "v2");
            v3 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<MockView>(this, "v3");
            v4 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<MockView>(this, "v4");
            v5 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<MockView>(this, "v5");
            v6 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<MockView>(this, "v6");
            v7 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<MockView>(this, "v7");
            v8 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<MockView>(this, "v8");
        }
    }

    [TestFixture]
    public class FactoryMethodsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXaml.")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void FactoryMethodsTestDefaultCtor()
        {
            FactoryMethods layout = new FactoryMethods();
            Assert.AreEqual("default ctor", layout.v0.Content.Content);
            Assert.AreEqual("alternate ctor foobar", layout.v1.Content.Content);
            Assert.AreEqual("int ctor 42", layout.v2.Content.Content);
            Assert.AreEqual("parameterless factory", layout.v3.Content.Content);
            Assert.AreEqual("factory foo42", layout.v4.Content.Content);
            Assert.AreEqual("factory 42foo", layout.v5.Content.Content);
            Assert.AreEqual("alternate ctor Property", layout.v6.Content.Content);
            Assert.AreEqual("alternate ctor Property", layout.v7.Content.Content);
            Assert.AreEqual("Foo Bar", layout.v8.Content.Content);
        }
    }
}