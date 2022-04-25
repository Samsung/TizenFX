using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ButtonTest1Page : ContentPage
    {
        string ImageURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";
        Color[] button4Colors = { Color.White, Color.Black, Color.Red, Color.Magenta, Color.Green, Color.Yellow };
        uint button4ColorsIndex = 0;
        bool button5Clicked = false;
        public ButtonTest1Page()
        {
            InitializeComponent();
            button2.Icon.Size2D = new Size2D(60, 60);
            button2.Icon.ResourceUrl = ImageURL + "NUITizenGallery.png";
            button3.Icon.Size2D = new Size2D(60, 60);
            button3.Icon.ResourceUrl = ImageURL + "NUITizenGallery.png";
            button4.Icon.Size2D = new Size2D(60, 60);
            button4.Icon.ResourceUrl = ImageURL + "NUITizenGallery.png";
            button5.Icon.Size2D = new Size2D(60, 60);
            button5.Icon.ResourceUrl = ImageURL + "NUITizenGallery.png";
            button6.Icon.Size2D = new Size2D(60, 60);
            button6.Icon.ResourceUrl = ImageURL + "NUITizenGallery.png";

            button4.Clicked += (s, e) =>
            {
                button4.TextColor = button4Colors[++button4ColorsIndex % button4Colors.Length];
            };

            button5.Clicked += (s, e) =>
            {
                button5Clicked = !button5Clicked;
                if (button5Clicked) button5.Text = "";
                else button5.Text = "Text Toggle";
            };

            button8.Clicked += (s, e) =>
            {
                button7.IsEnabled = !button7.IsEnabled;
            };
        }
    }
}