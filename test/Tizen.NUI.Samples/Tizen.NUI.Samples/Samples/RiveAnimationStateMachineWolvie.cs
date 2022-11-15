using Tizen.NUI.BaseComponents;
using Tizen.NUI.Extension;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class RiveAnimationStateMachineWolvie : IExample
    {
        private Window window;
        private Layer defaultLayer;

        private Tizen.NUI.Extension.RiveAnimationView rav;

        private TextLabel errorLabel;

        private CheckBox walkCheckBox;
        private CheckBox rageCheckBox;
        private CheckBox turnCheckBox;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            defaultLayer = window.GetDefaultLayer();

            rav = new Tizen.NUI.Extension.RiveAnimationView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/wolvie-v2.riv")
            {
                Size = new Size(500.0f, 500.0f),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true
            };

            rav.EnableAnimation("idle", true);
            rav.Play();

            errorLabel = new TextLabel()
            {
                Size = new Size(400.0f, 100.0f),
                Position = new Position(5.0f, 220.0f),
                Text = ""
            };

            walkCheckBox = new CheckBox()
            {
                Size = new Size(250.0f, 100.0f),
                Position = new Position(5.0f, 5.0f),
                Text = "Enable walk state.",
                IsSelected = false
            };
            walkCheckBox.Clicked += (object source, ClickedEventArgs args) =>
            {
                if (!rav.SetBooleanState("State Machine 1", "walk", walkCheckBox.IsSelected))
                {
                    walkCheckBox.IsSelected = false;
                    errorLabel.Text = "walkCheckBox returned false";
                }
            };

            rageCheckBox = new CheckBox()
            {
                Size = new Size(250.0f, 100.0f),
                Position = new Position(5.0f, 110.0f),
                Text = "Enable rage state.",
                IsSelected = false
            };
            rageCheckBox.Clicked += (object source, ClickedEventArgs args) =>
            {
                if(!rav.SetBooleanState("State Machine 1", "berserkerRage", rageCheckBox.IsSelected))
                {
                    rageCheckBox.IsSelected = false;
                    errorLabel.Text = "rageCheckBox returned false";
                }
            };

            turnCheckBox = new CheckBox()
            {
                Size = new Size(250.0f, 100.0f),
                Position = new Position(5.0f, 215.0f),
                Text = "Enable turn state.",
                IsSelected = false
            };
            turnCheckBox.Clicked += (object source, ClickedEventArgs args) =>
            {
                if(!rav.SetBooleanState("State Machine 1", "direction(defaultRight)", turnCheckBox.IsSelected))
                {
                    turnCheckBox.IsSelected = false;
                    errorLabel.Text = "turnCheckBox returned false";
                }
            };

            defaultLayer.Add(rav);
            defaultLayer.Add(walkCheckBox);
            defaultLayer.Add(rageCheckBox);
            defaultLayer.Add(turnCheckBox);
            defaultLayer.Add(errorLabel);
        }

        public void Deactivate()
        {
            if (rav)
                defaultLayer.Remove(rav);

            if (walkCheckBox)
                defaultLayer.Remove(walkCheckBox);

            if (rageCheckBox)
                defaultLayer.Remove(rageCheckBox);

            if (turnCheckBox)
                defaultLayer.Remove(turnCheckBox);

            if (errorLabel)
                defaultLayer.Remove(errorLabel);
        }
    }
}
