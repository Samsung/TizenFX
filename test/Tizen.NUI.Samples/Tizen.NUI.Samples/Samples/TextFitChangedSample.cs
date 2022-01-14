using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Text;

namespace Tizen.NUI.Samples
{
    public class TextFitChangedSample : IExample
    {
        private TextLabel label;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            var fit = new TextFit();
            fit.Enable = true;
            fit.MinSize = 5.0f;
            fit.MaxSize = 50.0f;

            label = new TextLabel()
            {
                Text = "ABCDE",
                Size = new Size(300, 100),
                PointSize = 10,
                Position = new Position(100, 100),
                BackgroundColor = Color.Yellow,
            };
            label.SetTextFit(fit);

            window.Add(label);

            label.TextFitChanged +=(s, e) =>
            {
                TextFit textfit = label.GetTextFit();
                Tizen.Log.Error("NUI", $"FontSize : {textfit.FontSize}\n");
            };
        }

        public void Deactivate()
        {
            label.Unparent();
        }
    }
}
