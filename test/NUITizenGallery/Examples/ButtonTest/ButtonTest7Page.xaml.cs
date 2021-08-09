
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ButtonTest7Page : ContentPage
    {
        public ButtonTest7Page()
        {
            InitializeComponent();
            button1.ControlStateChangedEvent += (o, e) =>
            {
                if (e.CurrentState == ControlState.Normal) {
                    text2.Text = "Normal";
                }
                if (e.CurrentState == ControlState.Pressed) {
                    text2.Text = "Pressed";
                }
            };

        }
    }
}