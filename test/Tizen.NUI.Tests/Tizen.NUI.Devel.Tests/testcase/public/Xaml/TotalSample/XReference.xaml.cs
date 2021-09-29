using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

[assembly: XamlResourceId("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.XReference.xaml",
    "testcase.public.Xaml.TotalSample.XReference.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.XReference))]

namespace Tizen.NUI.Devel.Tests
{
    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\XReference.xaml")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class XReference : View
	{
        public TextLabel label0;
        public TextLabel label1;
        public TextField entry;

        public XReference ()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(XReference));

            label0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label0");
            label1 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label1");
            entry = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextField>(this, "entry");
        }

		[TestFixture]
		public class Tests
		{
			[Test]
			public void XReferenceAsBindingSource ()
			{
				var layout = new XReference ();

				Assert.AreEqual ("foo", layout.entry.Text);
				Assert.AreEqual ("bar", layout.entry.PlaceholderText);
			}

			[Test]
			public void CrossXReference ()
			{
				var layout = new XReference ();

				Assert.AreSame (layout.label0, layout.label1.BindingContext);
				Assert.AreSame (layout.label1, layout.label0.BindingContext);
			}
		}
	}
}