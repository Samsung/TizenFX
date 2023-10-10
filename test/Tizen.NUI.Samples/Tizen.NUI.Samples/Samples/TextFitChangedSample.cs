using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Text;

namespace Tizen.NUI.Samples
{
    public class TextFitChangedSample : IExample
    {
        private TextLabel label;
        private TextLabel labelFitArray;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            // TextFit
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

            // TextFitArray
            labelFitArray = new TextLabel()
            {
                Text = "ABCDE",
                Size = new Size(300, 100),
                PointSize = 10,
                Position = new Position(100, 250),
                BackgroundColor = Color.Yellow,
            };
            window.Add(labelFitArray);

            var textFitArray = new Tizen.NUI.Text.TextFitArray();
            textFitArray.Enable = true;
            textFitArray.OptionList = new List<Tizen.NUI.Text.TextFitArrayOption>()
            {
                new Tizen.NUI.Text.TextFitArrayOption(5, 10),
                new Tizen.NUI.Text.TextFitArrayOption(10, 15),
                new Tizen.NUI.Text.TextFitArrayOption(15, 15),
                new Tizen.NUI.Text.TextFitArrayOption(20, 25),
                new Tizen.NUI.Text.TextFitArrayOption(50, 70),
                new Tizen.NUI.Text.TextFitArrayOption(60, 70),
                new Tizen.NUI.Text.TextFitArrayOption(70, 70),
            };
            labelFitArray.SetTextFitArray(textFitArray);

            var getFitArray = labelFitArray.GetTextFitArray();

            Tizen.Log.Error("NUI", $"GetTextFitArray:enable:[{getFitArray.Enable}] \n");
            for (int i = 0 ; i < getFitArray.OptionList.Count ; i ++)
            {
                Tizen.Log.Error("NUI", $"GetTextFitArray:option:[{getFitArray.OptionList[i].PointSize}, {getFitArray.OptionList[i].MinLineSize}] \n");
            }
        }

        public void Deactivate()
        {
        }
    }
}
