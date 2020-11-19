using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class ThemeResourceSample : IExample
    {
        public void Activate()
        {
            string resourceDefault = global::System.IO.Path.Combine("res", "resSampleThemeResourceDefault.xaml");
            string resourceDark = global::System.IO.Path.Combine("res", "SampleThemeResourceDark.xaml");
            Theme sampleTheme = new Theme(global::System.IO.Path.Combine("res", "SampleTheme.xaml"), resourceDefault);
            ThemeManager.ApplyTheme(sampleTheme);

            View root = new View();
            root.WidthSpecification = LayoutParamPolicies.MatchParent;
            root.HeightSpecification = LayoutParamPolicies.MatchParent;
            Window.Instance.GetDefaultLayer().Add(root);

            Button button = new Button();
            button.ThemeChangeSensitive = true;
            button.Size = new Size2D(200, 200);
            button.Clicked += (object sender, ClickedEventArgs e) =>
            {
                if (sampleTheme.Resource == resourceDefault)
                {
                    sampleTheme.Resource = resourceDark;
                    ThemeManager.ApplyTheme(sampleTheme);

                }
                else
                {
                    sampleTheme.Resource = resourceDefault;
                    ThemeManager.ApplyTheme(sampleTheme);
                }
            };
            root.Add(button);
        }

        public void Deactivate() {}
    }
}
