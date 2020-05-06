using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class TitleSample : IExample
    {
        private TextLabel title;
        private View root;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            /**
            * Apply the fadeOut effect of title using textLabelStyle.
            * If Title is enabled, the fadeout effect is applied with balck color and width 32.
            * You can change the values of FadeOutColor and FadeOutWidth.
            */
            TextLabelStyle attr = new TextLabelStyle
            {
                Size = new Size(300, 39),
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                Title = true,
                // FadeOutColor = Color.Red,
                // FadeOutWidth = 40,
            };


            title = new TextLabel(attr);
            title.Text = "This title can has a fadeOut effect.";

            window.Add(title);
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
