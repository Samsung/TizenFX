﻿using NUnit.Framework;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    public partial class BindingsCompiler : View
    {
        public BindingsCompiler()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(BindingsCompiler));
#pragma warning restore Reflection // The code contains reflection

            //label0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label0");
            //label1 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label1");
            //label2 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label2");
            //label3 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label3");
            //label4 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label4");
            //label5 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label5");
            //label6 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label6");
            //label7 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label7");
            //label8 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label8");
            //label9 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label9");
            //label10 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label10");
            //entry0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextField>(this, "entry0");
            //entry1 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextField>(this, "entry1");
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
            //layout.label6.BindingContext = new MockStructViewModel
            //{
            //    Model = new MockViewModel
            //    {
            //        Text = "text6"
            //    }
            //};

            ////testing paths
            //Assert.AreEqual("Text0", layout.label0.Text);
            //Assert.AreEqual("Text0", layout.label1.Text);
            //Assert.AreEqual("Text1", layout.label2.Text);
            //Assert.AreEqual("TextIndex", layout.label3.Text);
            //Assert.AreEqual("Text0", layout.label8.Text);
        }
    }

    struct MockStructViewModel
    {
        public string Text
        {
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
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                    return;

                _text = value;
                OnPropertyChanged();
            }
        }

        int _i;
        public int I
        {
            get { return _i; }
            set
            {
                if (_i == value)
                    return;
                _i = value;
                OnPropertyChanged();
            }
        }

        MockViewModel _model;
        public MockViewModel Model
        {
            get { return _model; }
            set
            {
                if (_model == value)
                    return;
                _model = value;
                OnPropertyChanged();
            }
        }

        MockStructViewModel _structModel;
        public MockStructViewModel StructModel
        {
            get { return _structModel; }
            set
            {
                _structModel = value;
                OnPropertyChanged();
            }
        }

        string[] values = new string[5];
        [IndexerName("Indexer")]
        public string this[int v]
        {
            get { return values[v]; }
            set
            {
                if (values[v] == value)
                    return;

                values[v] = value;
                OnPropertyChanged("Indexer[" + v + "]");
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}