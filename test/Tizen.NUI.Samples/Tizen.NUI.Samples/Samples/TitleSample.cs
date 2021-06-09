using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Wearable;

namespace Tizen.NUI.Samples
{
    public class TitleSample : IExample
    {
        private Title title;
        private View root;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            TextLabelStyle attr = new TextLabelStyle
            {
                Size = new Size(300, 39),
                BackgroundColor = Color.Black,
                TextColor = Color.White,
            };

            /**
             * The title inherits textlabel.
             * Refer to textlabel.
             */
            title = new Title(attr);
            title.Text = "The title can has a fadeOut effect.";


            /**
             * The title has a fadeout effect.
             * The default width is 32. You can change the value through FadeOutWidth.
             * ex) title.FadeOutWidth = 10;
             * The default color is BackgroundColor. You can change the color value through FadeOutColor.
             * ex) title.FadeOutColor = Color.Red;
             */
            window.Add(title);
        }

        public void Deactivate()
        {
            if (title != null){
                title.Unparent();
                title.Dispose();
            }
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}