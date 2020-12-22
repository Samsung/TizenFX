using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class ThemeResourceSample : IExample
    {
        Dictionary<string, string> DefaultThemeResources { get; } = new Dictionary<string, string>()
        {
            {"ButtonBackgroundColorNormal", "0.054, 0.631, 0.921, 1" },
            {"ButtonBackgroundColorPressed", "0.454, 0.752, 0.905, 1" },
            {"ButtonBackgroundColorDisabled", "0.88, 0.88, 0.88, 1" },
        };
        Dictionary<string, string> DarkThemeResources { get; } = new Dictionary<string, string>()
        {
            {"ButtonBackgroundColorNormal", "0.309, 0.309, 0.309, 1" },
            {"ButtonBackgroundColorPressed", "0.631, 0.631, 0.631, 1" },
            {"ButtonBackgroundColorDisabled", "0.8, 0.8, 0.8, 1" },
        };
        public void Activate()
        {
            bool isCurrentThemeDefault = true;

            View root = new View();
            root.WidthSpecification = LayoutParamPolicies.MatchParent;
            root.HeightSpecification = LayoutParamPolicies.MatchParent;
            Window.Instance.GetDefaultLayer().Add(root);

            Button button = new Button();
            button.ThemeChangeSensitive = true;
            button.Size = new Size2D(200, 200);
            button.Clicked += (object sender, ClickedEventArgs e) =>
            {
                if (isCurrentThemeDefault)
                {
                    isCurrentThemeDefault = false;
                    ThemeManager.UpdateCurrentThemeResources(DarkThemeResources);
                }
                else
                {
                    isCurrentThemeDefault = true;
                    ThemeManager.UpdateCurrentThemeResources(DefaultThemeResources);
                }
            };
            root.Add(button);
        }

        public void Deactivate() {}
    }
}
