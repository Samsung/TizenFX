using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NuiCommonUiSamples
{
    using Controls = Tizen.FH.NUI.Controls;
    public class Header : IExample
    {
        private SampleLayout root;
        private View root1;
        private View root2;
        private View root3;
        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            root = new SampleLayout(false);
            root.HeaderText = "Header";

            root1 = new View()
            {
                SizeWidth = 1080,
                Position2D = new Position2D(0, 0),
                BackgroundColor = new Color(1.0f, 1.0f, 0, 0.7f),
                SizeHeight = 200,

            };

            Controls.Header header1 = new Tizen.FH.NUI.Controls.Header();
            header1.Position2D = new Position2D(0, 0);
            header1.BackgroundColor = new Color(255, 255, 255, 1);
            header1.Size2D = new Size2D(1080, 128);
            header1.HeaderText = "Title Area Default";
            header1.HeaderTextColor = new Color(0, 0, 0, 1); //black
            header1.LinebackgroundColor = new Color(0, 0, 0, 0.2f);//white

            root1.Add(header1);
            root.Add(root1);

            root2 = new View()
            {
                SizeWidth = 1080,
                Position2D = new Position2D(0, 210),
                BackgroundColor = new Color(1.0f, 1.0f, 0, 0.7f),
                SizeHeight = 200,
            };

            Controls.Header header2 = new Tizen.FH.NUI.Controls.Header();
            header2.Position2D = new Position2D(0, 0);
            header2.Size2D = new Size2D(1080, 128);
            header1.BackgroundColor = new Color(255, 255, 255, 0.7f);
            header2.HeaderText = "Title Area Opqaue";
            header2.HeaderTextColor = new Color(0, 0, 0, 1); //black
            header2.LinebackgroundColor = new Color(0, 0, 0, 0.2f); //black


            root2.Add(header2);
            root.Add(root2);

            root3 = new View()
            {
                SizeWidth = 1080,
                Position2D = new Position2D(0, 420),
                BackgroundColor = new Color(0, 0, 0, 1),
                SizeHeight = 200,
            };

            Controls.Header header3 = new Controls.Header();
            header3.Position2D = new Position2D(0, 0);
            header3.Size2D = new Size2D(1080, 128);
            header3.HeaderText = "Title Area Transparency";
            header3.HeaderTextColor = new Color(255, 255, 255, 1); //white
            header3.LinebackgroundColor = new Color(255, 255, 255, 0.2f);//white


            root3.Add(header3);
            root.Add(root3);
        }

        public void Deactivate()
        {
            if (root1 != null)
            {
                root.Remove(root1);
                root1.Dispose();
            }
            if (root2 != null)
            {
                root.Remove(root2);
                root2.Dispose();
            }
            if (root3 != null)
            {
                root.Remove(root3);
                root3.Dispose();
            }

            root.Dispose();
        }
    }
}
