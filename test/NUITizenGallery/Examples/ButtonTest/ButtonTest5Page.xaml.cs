using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ButtonTest5Page : ContentPage
    {
        bool opacityToggle = false;
        public ButtonTest5Page()
        {
            InitializeComponent();

            slider1.ValueChanged += (o, e) =>
            {
                text1.Text = "Button Size: " + slider1.CurrentValue;
                button1.SizeHeight = slider1.CurrentValue;
                button2.SizeHeight = slider1.CurrentValue;
            };

            slider2.ValueChanged += (o, e) =>
            {
                text2.Text = "Button Font Size: " + slider2.CurrentValue;
                button1.PointSize = slider2.CurrentValue;
                button2.PointSize = slider2.CurrentValue;
            };

            slider3.ValueChanged += (o, e) =>
            {
                text3.Text = "Button Opacity: " + slider3.CurrentValue;
                button1.Opacity = slider3.CurrentValue;
                button2.Opacity = slider3.CurrentValue;
            };

            button1.Clicked += (o, e) =>
            {
                opacityToggle = !opacityToggle;
                if (opacityToggle)
                {
                    slider3.CurrentValue = 0.5f;
                }
                else
                {
                    slider3.CurrentValue = 1.0f;
                }
                text3.Text = "Button Opacity: " + slider3.CurrentValue;
                button1.Opacity = slider3.CurrentValue;
                button2.Opacity = slider3.CurrentValue;
            };

        }
    }
}