using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

using ElmSharp.Wearable;

namespace ElmSharp.Test.TC
{
    class RotarySelectorTest : TestCaseBase
    {
        public override string TestName => "RotarySelectorTest";

        public override string TestDescription => "Rotary Selector Widget Test";

        Window _window;

        class MyRotarySelectorItem : RotarySelectorItem
        {
            public Color Color { get; set; }
            public string Message { get; set; }
        }

        MyRotarySelectorItem NewItem(string iconName, Color color)
        {
            Image img = new Image(_window);
            img.Load(Path.Combine(TestRunner.ResourceDir, "icons", iconName + ".png"));

            string title = (iconName.First().ToString().ToUpper() + iconName.Substring(1)).Replace('_', ' ');

            return new MyRotarySelectorItem
            {
                Color = color,
                Message = title,
                MainText = title,
                SubText = color.ToString(),
                NormalIconImage = img,

                //PressedIconColor = Color.Green,
                //IconColor = Color.Red,

                //BackgroundImage = img,
                //BackgroundColor = Color.Blue,
                //PressedBackgroundColor = Color.Red

            };
        }

        public override void Run(Window window)
        {
            this._window = window;
            Conformant conf = new Conformant(window);
            conf.Show();

            RotarySelector selector = new RotarySelector(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            selector.Show();

            selector.Items.Add(NewItem("icon_aquamarine_260_me", Color.FromHex("#800000")));
            selector.Items.Add(NewItem("icon_auamarine_260_me", Color.FromHex("#800012")));
            selector.Items.Add(NewItem("icon_azure_215_me", Color.FromHex("#800034")));
            selector.Items.Add(NewItem("icon_beige_330_me", Color.FromHex("#800056")));
            selector.Items.Add(NewItem("icon_blue_45_me", Color.FromHex("#800067")));
            selector.Items.Add(NewItem("icon_brown_90_me", Color.FromHex("#800087")));
            selector.Items.Add(NewItem("icon_cyan_230_me", Color.FromHex("#800023")));
            selector.Items.Add(NewItem("icon_firebrick_95_me", Color.FromHex("#804300")));
            selector.Items.Add(NewItem("icon_gold_75_me", Color.FromHex("#854000")));
            selector.Items.Add(NewItem("icon_green_60_me", Color.FromHex("#800340")));
            selector.Items.Add(NewItem("icon_honeydew_285_me", Color.FromHex("#823000")));
            selector.Items.Add(NewItem("icon_ivory_315_me", Color.FromHex("#806700")));
            selector.Items.Add(NewItem("icon_khaki_360_me", Color.FromHex("#80ab00")));
            selector.Items.Add(NewItem("icon_lime_300_me", Color.FromHex("#800c30")));
            selector.Items.Add(NewItem("icon_maroon_120_me", Color.FromHex("#8fd000")));
            selector.Items.Add(NewItem("icon_me", Color.FromHex("#800000")));
            selector.Items.Add(NewItem("icon_orchid_160_me", Color.FromHex("#8d3000")));
            selector.Items.Add(NewItem("icon_pink_145_me", Color.FromHex("#8002d0")));
            selector.Items.Add(NewItem("icon_purple_200_me", Color.FromHex("#8ff000")));
            selector.Items.Add(NewItem("icon_red_30_me", Color.FromHex("#800fa0")));
            selector.Items.Add(NewItem("icon_snow_75_me", Color.FromHex("#80f200")));
            selector.Items.Add(NewItem("icon_snow_80_me", Color.FromHex("#80d200")));
            selector.Items.Add(NewItem("icon_teal_245_me", Color.FromHex("#80f300")));
            selector.Items.Add(NewItem("icon_violet_180_me", Color.FromHex("#80fb00")));
            selector.Items.Add(NewItem("icon_yellow_345_me", Color.FromHex("#800b30")));
            //selector.BackgroundImage = new Image(window);
            //selector.BackgroundImage.Load(Path.Combine(TestRunner.ResourceDir, "icons", "round_bg_green.png"));
            //selector.BackgroundColor = Color.Pink;
            //selector.PressedBackgroundColor = Color.Gray;
            conf.SetContent(selector);

        }
    }
}
