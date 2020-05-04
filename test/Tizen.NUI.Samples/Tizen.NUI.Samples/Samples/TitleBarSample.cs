using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class TitleBarSample : IExample
    {
        private TitleBar titleBar;
        private View root;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            TextLabelStyle attr = new TextLabelStyle
            {
                Size = new Size(300, 39),
            };

            /**
             * The title bar inherits textlabel.
             * Refer to textlabel.
             */
            titleBar = new TitleBar(attr);
            titleBar.Text = "The title bar can has a fadeOut effect.";

            /**
             * The title bar has a fadeout effect.
             * The default width is 32. You can change the value through FadeOutWidth.
             * ex) titleBar.FadeOutWidth = 10;
             * The default color is Vector4(0, 0, 0, 0.6F). You can change the color value through FadeOutColor.
             * ex) titleBar.FadeOutColor(new Vector4(1, 0, 0, 0.6F), new Vector4(1, 0, 0, 0));
             */
            window.Add(titleBar);
        }

        public void Deactivate()
        {
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
