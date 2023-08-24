using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace NUITizenGallery
{
    public partial class SliderTest2Page : ContentPage
    {
        float saveHeight = 0;
        public SliderTest2Page()
        {
            InitializeComponent();
            button1.Clicked += (o, e) =>
            {
                if (slider1.Direction == Slider.DirectionType.Vertical)
                {
                    slider1.Direction = Slider.DirectionType.Horizontal;
                    slider1.SizeHeight = saveHeight;
                } 
                else
                {
                    slider1.Direction = Slider.DirectionType.Vertical;
                    saveHeight = slider1.SizeHeight;
                    slider1.SizeHeight = 300;
                }

            };

            slider1.ValueChanged += (o, e) =>
            {
                text1.Text = "slider value: " + slider1.CurrentValue;
            };
        }
    }
}