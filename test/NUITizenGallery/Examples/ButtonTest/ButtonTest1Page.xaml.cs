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
            imageview1.ResourceUrl = ImageURL + "NUITizenGallery.png";
            imageview2.ResourceUrl = ImageURL + "NUITizenGallery.png";
            imageview3.ResourceUrl = ImageURL + "NUITizenGallery.png";
            imageview4.ResourceUrl = ImageURL + "NUITizenGallery.png";
            imageview5.ResourceUrl = ImageURL + "NUITizenGallery.png";

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