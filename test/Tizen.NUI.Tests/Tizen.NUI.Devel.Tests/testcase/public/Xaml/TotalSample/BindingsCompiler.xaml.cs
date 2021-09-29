using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

[assembly: global::Tizen.NUI.Xaml.XamlResourceIdAttribute("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.BindingsCompiler.xaml",
    "testcase.public.Xaml.TotalSample.BindingsCompiler.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.BindingsCompiler))]

namespace Tizen.NUI.Devel.Tests
{
    [Tizen.NUI.Xaml.XamlFilePathAttribute("testcase\\public\\Xaml\\TotalSample\\BindingsCompiler.xaml")]
    [Tizen.NUI.Xaml.XamlCompilationAttribute(global::Tizen.NUI.Xaml.XamlCompilationOptions.Compile)]
    public partial class BindingsCompiler : View
	{
        public TextLabel label0;
        public TextLabel label1;
        public TextLabel label2;
        public TextLabel label3;
        public TextLabel label4;
        public TextLabel label5;
        public TextLabel label6;
        public TextLabel label7;
        public TextLabel label8;
        public TextLabel label9;
        public TextLabel label10;
        public TextField entry0;
        public TextField entry1;
        public TextLabel labelWithUncompiledBinding;

        public BindingsCompiler()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(BindingsCompiler));

            label0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label0");
            label1 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label1");
            label2 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label2");
            label3 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label3");
            label4 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label4");
            label5 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label5");
            label6 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label6");
            label7 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label7");
            label8 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label8");
            label9 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label9");
            label10 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label10");
            labelWithUncompiledBinding = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "labelWithUncompiledBinding");
            entry0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextField>(this, "entry0");
            entry1 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextField>(this, "entry1");
        }

		
	}

	[TestFixture]
	public class BindingsCompilerTests
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
		[NUnit.Framework.Category("P1")]
		[NUnit.Framework.Description("Extensions LoadFromXaml.")]
		[Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
		[Property("SPEC_URL", "-")]
		[Property("CRITERIA", "MR")]
		public void BindingsCompilerTest()
		{
			var vm = new MockViewModel
			{
				Text = "Text0",
				I = 42,
				Model = new MockViewModel
				{
					Text = "Text1"
				},
				StructModel = new MockStructViewModel
				{
					Model = new MockViewModel
					{
						Text = "Text9"
					}
				}
			};
			vm.Model[3] = "TextIndex";

			var layout = new BindingsCompiler();
			layout.BindingContext = vm;
			layout.label6.BindingContext = new MockStructViewModel
			{
				Model = new MockViewModel
				{
					Text = "text6"
				}
			};

			//testing paths
			Assert.AreEqual("Text0", layout.label0.Text);
			Assert.AreEqual("Text0", layout.label1.Text);
			Assert.AreEqual("Text1", layout.label2.Text);
			Assert.AreEqual("TextIndex", layout.label3.Text);
			Assert.AreEqual("Text0", layout.label8.Text);

			//value types
			Assert.That(layout.label5.Text, Is.EqualTo("42"));
			Assert.That(layout.label6.Text, Is.EqualTo("text6"));
			Assert.AreEqual("Text9", layout.label9.Text);
			Assert.AreEqual("Text9", layout.label10.Text);
			layout.label9.Text = "Text from label9";
			Assert.AreEqual("Text from label9", vm.StructModel.Text);
			layout.label10.Text = "Text from label10";
			Assert.AreEqual("Text from label10", vm.StructModel.Model.Text);

			//testing selfPath
			layout.label4.BindingContext = "Self";
			Assert.AreEqual("Self", layout.label4.Text);
			layout.label7.BindingContext = 42;
			Assert.That(layout.label7.Text, Is.EqualTo("42"));

			//testing INPC
			GC.Collect();
			vm.Text = "Text2";
			Assert.AreEqual("Text2", layout.label0.Text);

			//testing 2way
			Assert.AreEqual("Text2", layout.entry0.Text);
			layout.entry0.SetValue(TextField.TextProperty, "Text3");
			Assert.AreEqual("Text3", layout.entry0.Text);
			Assert.AreEqual("Text3", vm.Text);
			layout.entry1.SetValue(TextField.TextProperty, "Text4");
			Assert.AreEqual("Text4", layout.entry1.Text);
			Assert.AreEqual("Text4", vm.Model.Text);
			vm.Model = null;
			layout.entry1.BindingContext = null;

			//testing invalid bindingcontext type
			layout.BindingContext = new object();
			Assert.AreEqual(string.Empty, layout.label0.Text);
		}
	}

	struct MockStructViewModel
	{
		public string Text {
			get { return Model.Text; }
			set { Model.Text = value; }
		}
		public int I { get; set; }
		public MockViewModel Model { get; set; }
	}

	class MockViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public MockViewModel(string text = null, int i = -1)
		{
			_text = text;
			_i = i;
		}

		string _text;
		public string Text {
			get { return _text; }
			set {
				if (_text == value)
					return;

				_text = value;
				OnPropertyChanged();
			}
		}

		int _i;
		public int I {
			get { return _i; }
			set {
				if (_i == value)
					return;
				_i = value;
				OnPropertyChanged();
			}
		}

		MockViewModel _model;
		public MockViewModel Model {
			get { return _model; }
			set {
				if (_model == value)
					return;
				_model = value;
				OnPropertyChanged();
			}
		}

		MockStructViewModel _structModel;
		public MockStructViewModel StructModel {
			get { return _structModel; }
			set {
				_structModel = value;
				OnPropertyChanged();
			}
		}

		string [] values = new string [5];
		[IndexerName("Indexer")]
		public string this [int v] {
			get { return values [v]; }
			set {
				if (values [v] == value)
					return;

				values [v] = value;
				OnPropertyChanged("Indexer[" + v + "]");
			}
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}