using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

[assembly: XamlResourceId("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.FieldModifier.xaml",
    "testcase.public.Xaml.TotalSample.FieldModifier.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.FieldModifier))]

namespace Tizen.NUI.Devel.Tests
{
    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\FieldModifier.xaml")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FieldModifier : View
	{
        public TextLabel privateLabel;
        public TextLabel internalLabel;
        public TextLabel publicLabel;

        public FieldModifier()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(FieldModifier));

            privateLabel = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "privateLabel");
            internalLabel = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "internalLabel");
            publicLabel = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "publicLabel");
        }

		[TestFixture]
		public class FindByNameTests
		{
			[Test]
			public void TestFieldModifier ()
			{
				var layout = new FieldModifier();
				Assert.That(layout.privateLabel, Is.Not.Null);
				Assert.That(layout.internalLabel, Is.Not.Null);
				Assert.That(layout.publicLabel, Is.Not.Null);

				var fields = typeof(FieldModifier).GetTypeInfo().DeclaredFields;

				Assert.That(fields.First(fi => fi.Name == "privateLabel").IsPrivate, Is.False);
			}
		}
	}
}
