using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using ElmSharp.Wearable;

namespace ElmSharp.Test.TC
{
    class MoreOptionTest : TestCaseBase
    {
        public override string TestName => "MoreOptionTest";

        public override string TestDescription => "Wearable More Option Widget Test";

        class ColorMoreOptionItem : MoreOptionItem
        {
            public Color Color;
            public ColorMoreOptionItem(Window window, string iconName, Color color)
            {
                MainText = (iconName.First().ToString().ToUpper() + iconName.Substring(1)).Replace('_', ' ');
                SubText = color.ToString();
                Icon = new Image(window);
                Icon.Show();
                Icon.Load(Path.Combine(TestRunner.ResourceDir, "icons", iconName+".png"));
                Color = color;
            }
        }

        static Color Deep(Color color)
        {
            return new Color(color.R / 2, color.G / 2, color.B / 2);
        }

        public override void Run(Window window)
        {
            Conformant conf = new Conformant(window);
            conf.Show();

            MoreOption option = new MoreOption(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Direction = MoreOptionDirection.Right
            };
            option.Show();
            //option.Move(window.ScreenSize.Width/2, window.ScreenSize.Height/2);
            conf.SetContent(option);

            option.Items.Add(new ColorMoreOptionItem(window, "icon_aquamarine_260_me", Color.FromHex("#800000")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_auamarine_260_me", Color.FromHex("#800012")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_azure_215_me", Color.FromHex("#800034")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_beige_330_me", Color.FromHex("#800056")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_blue_45_me", Color.FromHex("#800067")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_brown_90_me", Color.FromHex("#800087")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_cyan_230_me", Color.FromHex("#800023")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_firebrick_95_me", Color.FromHex("#804300")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_gold_75_me", Color.FromHex("#854000")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_green_60_me", Color.FromHex("#800340")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_honeydew_285_me", Color.FromHex("#823000")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_ivory_315_me", Color.FromHex("#806700")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_khaki_360_me", Color.FromHex("#80ab00")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_lime_300_me", Color.FromHex("#800c30")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_maroon_120_me", Color.FromHex("#8fd000")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_me", Color.FromHex("#800000")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_orchid_160_me", Color.FromHex("#8d3000")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_pink_145_me", Color.FromHex("#8002d0")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_purple_200_me", Color.FromHex("#8ff000")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_red_30_me", Color.FromHex("#800fa0")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_snow_75_me", Color.FromHex("#80f200")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_snow_80_me", Color.FromHex("#80d200")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_teal_245_me", Color.FromHex("#80f300")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_violet_180_me", Color.FromHex("#80fb00")));
            option.Items.Add(new ColorMoreOptionItem(window, "icon_yellow_345_me", Color.FromHex("#800b30")));

            option.Opened += (s, e) => Log.Debug(TestName, "Opened!");
            option.Closed += (s, e) => Log.Debug(TestName, "Closed!");
            option.Selected += (s, e) => Log.Debug(TestName, "Selected! : " + e?.Item?.MainText);
            option.Clicked += (s, e) => Log.Debug(TestName, "Clicked! : " + e?.Item?.MainText);

            option.Opened += (s, e) => option.BackgroundColor = Color.Aqua;
            option.Closed += (s, e) => option.BackgroundColor = Color.Black;

            option.Selected += (s, e) => option.BackgroundColor = (e?.Item as ColorMoreOptionItem).Color;
            option.Clicked += (s, e) => option.BackgroundColor = Deep((e?.Item as ColorMoreOptionItem).Color);
        }
    }
}
