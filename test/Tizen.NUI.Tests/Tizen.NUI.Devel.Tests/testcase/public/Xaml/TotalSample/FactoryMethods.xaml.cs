using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

[assembly: XamlResourceId("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.FactoryMethods.xaml",
    "testcase.public.Xaml.TotalSample.FactoryMethods.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.FactoryMethods))]

namespace Tizen.NUI.Devel.Tests
{
	public class MockView : View
	{
		public MockFactory Content { get; set; }
	}

	public class MockFactory
	{
		public string Content { get; set; }
		public MockFactory ()
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

		public MockFactory (int arg)
		{
			Content = "int ctor " + arg.ToString ();
		}

		public MockFactory(object [] args)
		{
			Content = string.Join(" ", args);
		}

		public static  MockFactory ParameterlessFactory ()
		{
			return new MockFactory {
				Content = "parameterless factory",
			};
		}

		public static MockFactory Factory (string arg0, int arg1)
		{
			return new MockFactory {
				Content = "factory " + arg0 + arg1,
			};
		}

		public static MockFactory Factory (int arg0, string arg1)
		{
			return new MockFactory {
				Content = "factory " + arg0 + arg1,
			};
		}
	}

    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\FactoryMethods.xaml")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FactoryMethods : View
	{
        public MockView v0;
        public MockView v1;
        public MockView v2;
        public MockView v3;
        public MockView v4;
        public MockView v5;
        public MockView v6;
        public MockView v7;
        public MockView v8;

        public FactoryMethods ()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(FactoryMethods));

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

		[TestFixture]
		public class Tests
		{
			[SetUp]
			public void SetUp()
			{
			}

			[Test]
			public void TestDefaultCtor ()
			{
				var layout = new FactoryMethods ();
				Assert.AreEqual ("default ctor", layout.v0.Content.Content);
			}

			[Test]
			public void TestStringCtor ()
			{
				var layout = new FactoryMethods ();
				Assert.AreEqual ("alternate ctor foobar", layout.v1.Content.Content);
			}

			[Test]
			public void TestIntCtor ()
			{
				var layout = new FactoryMethods ();
				Assert.AreEqual ("int ctor 42", layout.v2.Content.Content);
			}

			[Test]
			public void TestArgumentlessFactoryMethod ()
			{
				var layout = new FactoryMethods ();
				Assert.AreEqual ("parameterless factory", layout.v3.Content.Content);
			}

			[Test]
			public void TestFactoryMethod ()
			{
				var layout = new FactoryMethods ();
				Assert.AreEqual ("factory foo42", layout.v4.Content.Content);
			}

			[Test]
			public void TestFactoryMethodParametersOrder ()
			{
				var layout = new FactoryMethods ();
				Assert.AreEqual ("factory 42foo", layout.v5.Content.Content);
			}

			[Test]
			public void TestCtorWithxStatic()
			{
				var layout = new FactoryMethods();
				Assert.AreEqual("alternate ctor Property", layout.v6.Content.Content);
			}

			[Test]
			public void TestCtorWithxStaticAttribute()
			{
				var layout = new FactoryMethods();
				Assert.AreEqual("alternate ctor Property", layout.v7.Content.Content);
			}

			[Test]
			public void TestCtorWithArrayParameter()
			{
				var layout = new FactoryMethods();
				Assert.AreEqual("Foo Bar", layout.v8.Content.Content);
			}
		}
	}
}