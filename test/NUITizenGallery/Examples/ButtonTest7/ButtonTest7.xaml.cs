
using Tizen.NUI.BaseComponents;

namespace NUITizenGallery
{
    public partial class ButtonTest7Page : View
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