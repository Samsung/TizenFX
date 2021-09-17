using System;
using System.Collections.ObjectModel;
using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

[assembly: XamlResourceId("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.GenericCollections.xaml",
    "testcase.public.Xaml.TotalSample.GenericCollections.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.GenericCollections))]

namespace Tizen.NUI.Devel.Tests
{
	public class AttachedBP
	{
		public static readonly BindableProperty AttachedBPProperty = BindableProperty.CreateAttached (
			"AttachedBP",
			typeof(GenericCollection),
			typeof(AttachedBP),
			null);

		public static GenericCollection GetAttachedBP(BindableObject bindable)
		{
			throw new NotImplementedException();
		}
	}

	public class GenericCollection : ObservableCollection<object>
	{
	}

    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\GenericCollections.xaml")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenericCollections : View
	{
        public TextLabel label0;

        public GenericCollections ()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(GenericCollections));
            label0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label0");
        }

		[TestFixture]
		public class Tests
		{
			[Test]
			public void SupportsCrookedGenericScenarios ()
			{
				var p = new GenericCollections ();
				Assert.AreEqual ("Foo", (p.label0.GetValue (AttachedBP.AttachedBPProperty) as GenericCollection) [0]);
			}
		}
	}
}