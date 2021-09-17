using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

[assembly: XamlResourceId("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.XStatic.xaml",
    "testcase.public.Xaml.TotalSample.XStatic.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.XStatic))]

namespace Tizen.NUI.Devel.Tests
{

	public class Icons
	{
		public const string CLOSE = "ic_close.png";
	}

	public class MockxStatic
	{
		public static string MockStaticProperty { get { return "Property"; } }
		public const string MockConstant = "Constant";
		public static string MockField = "Field";
		public static string MockFieldRef = Icons.CLOSE;
		public string InstanceProperty { get { return "InstanceProperty"; } }
		public static readonly Color BackgroundColor = Color.Fuchsia;

		public class Nested {
			public static string Foo = "FOO";
		}
	}

	public enum MockEnum : long
	{
		First,
		Second,
		Third,
	}

    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\XStatic.xaml")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class XStatic : View
	{
        public TextLabel staticproperty;
        public TextLabel memberisoptional;
        public TextLabel color;
        public TextLabel constant;
        public TextLabel field;
        public TextLabel field2;
        public TextLabel nestedField;


        public XStatic ()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(XStatic));
            staticproperty = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "staticproperty");
            memberisoptional = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "memberisoptional");
            color = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "color");
            constant = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "constant");
            field = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "field");
            field2 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "field2");
            nestedField = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "nestedField");
        }

		[TestFixture]
		public class Tests
		{
			//{x:Static Member=prefix:typeName.staticMemberName}
			//{x:Static prefix:typeName.staticMemberName}

			//The code entity that is referenced must be one of the following:
			// - A constant
			// - A static property
			// - A field
			// - An enumeration value
			// All other cases should throw

			[SetUp]
			public void Setup()
			{
			}

			[TearDown]
			public void TearDown()
			{
			}

			[Test]
			public void StaticProperty ()
			{
				var layout = new XStatic ();
				Assert.AreEqual ("Property", layout.staticproperty.Text);
			}

			[Test]
			public void MemberOptional ()
			{
				var layout = new XStatic ();
				Assert.AreEqual ("Property", layout.memberisoptional.Text);
			}

			[Test]
			public void FieldColor ()
			{
				var layout = new XStatic ();
				Assert.AreEqual (Color.Fuchsia, layout.color.TextColor);
			}

			[Test]
			public void Constant()
			{
				var layout = new XStatic();
				Assert.AreEqual("Constant", layout.constant.Text);
			}

			[Test]
			public void Field()
			{
				var layout = new XStatic();
				Assert.AreEqual("Field", layout.field.Text);
			}

			[Test]
			public void FieldRef()
			{
				var layout = new XStatic();
				Assert.AreEqual("ic_close.png", layout.field2.Text);
			}


			[Test]
			// https://bugzilla.xamarin.com/show_bug.cgi?id=55096
			public void xStaticAndNestedClasses()
			{
				var layout = new XStatic();
				Assert.AreEqual(MockxStatic.Nested.Foo, layout.nestedField.Text);
			}
		}
	}
}