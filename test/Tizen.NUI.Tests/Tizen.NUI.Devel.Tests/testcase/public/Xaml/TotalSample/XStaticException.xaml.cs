using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

[assembly: XamlResourceId("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.XStaticException.xaml",
    "testcase.public.Xaml.TotalSample.XStaticException.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.XStaticException))]

namespace Tizen.NUI.Devel.Tests
{
    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\XStaticException.xaml")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class XStaticException : View
	{
		public XStaticException()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(XStaticException));
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

				//there's a test not resetting the values correctly, but can't find which one...
#pragma warning disable 0618
				ResourceLoader.ExceptionHandler = null;
                Xaml.Internals.XamlLoader.DoNotThrowOnExceptions = false;
#pragma warning restore 0618
			}

			[TearDown]
			public void TearDown()
			{
			}

			[Test]
			public void ThrowOnInstanceProperty()
			{
				Assert.Throws<XamlParseException>(() => new XStaticException());
			}
		}
	}
}