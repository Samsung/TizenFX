using NUnit.Framework;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;


namespace Tizen.NUI.Devel.Tests
{
    [ContentProperty("Content")]
    public class MockBindableForArray : View
    {
        public object Content { get; set; }
    }

    public partial class XArray : MockBindableForArray
    {
        public XArray()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(XArray));
#pragma warning restore Reflection // The code contains reflection
        }

    }


    [TestFixture]
    public class XArrayTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        //[Test]
        //[Category("P1")]
        //[Description("Extensions LoadFromXaml.")]
        //[Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void SupportsXArray()
        //{
        //    var layout = new XArray();
        //    var array = layout.Content;
        //    Assert.IsNotNull(array);
        //    Assert.IsInstanceOf<string[]>(array, "Should be an instance of string[] type.");

        //    Assert.AreEqual(2, ((string[])layout.Content).Length);
        //    Assert.AreEqual("Hello", ((string[])layout.Content)[0]);
        //    Assert.AreEqual("World", ((string[])layout.Content)[1]);
        //}
    }
}