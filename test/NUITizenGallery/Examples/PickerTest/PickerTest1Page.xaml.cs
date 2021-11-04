using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NUITizenGallery
{
    public partial class PickerTest1Page : ContentPage
    {
        String[] textValue = new string[] { "Black", "Blue", "Green", "Maroon", "Pink", "Teal", "Yellow"};
        Color[] colorValue = new Color[] {Color.Black, Color.Blue, Color.Green, Color.Maroon, Color.Pink, Color.Teal, Color.Yellow};

        private void onValueChanged(object sender, ValueChangedEventArgs e)
        {
            text1.Text = textValue[e.Value];
            text1.TextColor = colorValue[e.Value];
            rect1.BackgroundColor = colorValue[e.Value];
            Console.WriteLine("Value is " + e.Value);
        }

        public PickerTest1Page()
        {
            InitializeComponent();
            picker1.DisplayedValues = new ReadOnlyCollection<string>(textValue);
            picker1.ValueChanged += onValueChanged;
        }
    }
}
