using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmSharp.Test
{
    class SliderTest1 : TestCaseBase
    {
        public override string TestName => "SliderTest1";
        public override string TestDescription => "To test basic operation of Slider";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Table table = new Table(window);
            conformant.SetContent(table);
            table.Show();

            Slider sld1 = new Slider(window)
            {
                Text = "Slider Test",
                UnitFormat = "%1.2f meters",
                IndicatorFormat = "%1.2f meters",
                Minimum = 0.0,
                Maximum = 100.0,
                Value = 0.1,
                AlignmentX = -1,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1
            };

            Label lb1 = new Label(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            table.Pack(sld1, 1, 1, 2, 1);
            table.Pack(lb1, 1, 2, 2, 1);

            sld1.Show();
            lb1.Show();

            sld1.ValueChanged += (s, e) =>
            {
                lb1.Text = string.Format("Value Changed: {0}", sld1.Value);
                lb1.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
            };
        }
    }
}
