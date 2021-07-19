using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUITizenGallery
{
    public partial class SliderTest1Page : View
    {
        public SliderTest1Page()
        {
            InitializeComponent();
            slider1.ValueChanged += (o, e) =>
            {
                text1.Text = "slider value: " + slider1.CurrentValue;
            };

            button1.Clicked += (o, e) =>
            {
                if (slider1.CurrentValue + 10 > slider1.MaxValue) return;
                slider1.CurrentValue += 10;
                text1.Text = "slider value: " + slider1.CurrentValue;
            };

            button2.Clicked += (o, e) =>
            {
                if (slider1.CurrentValue - 10 < slider1.MinValue) return;
                slider1.CurrentValue -= 10;
                text1.Text = "slider value: " + slider1.CurrentValue;
            };
        }
    }
}