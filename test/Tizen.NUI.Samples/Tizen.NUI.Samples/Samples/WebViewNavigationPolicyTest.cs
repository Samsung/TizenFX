
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.IO;
using System.Text;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;

    public class WebViewInterceptTest : IExample
    {
        const string tag = "NUITEST";
        private View root;
        private Window win;
        private WebView webView;

        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = new Size(win.Size.Width, win.Size.Height, 0),
                BackgroundColor = Color.Green,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    Padding = new Extents(3, 3, 3, 3),
                },
            };
            win.Add(root);

            webView = new WebView();
            webView.Url = "https://www.google.com/";
            webView.WidthSpecification = LayoutParamPolicies.MatchParent;
            webView.HeightSpecification = LayoutParamPolicies.MatchParent;
            root.Add(webView);

            webView.NavigationPolicyDecided += OnCallback;
        }

        private void OnCallback(object sender, WebViewPolicyDecidedEventArgs e)
        {
            tlog.Debug(tag, $"callback: navigation policy decided, Url: {e.ResponsePolicyDecisionMaker.Url}");
            e.ResponsePolicyDecisionMaker.Ignore();
        }

        public void Deactivate()
        {
            webView.Unparent();
            root.Unparent();

            webView.Dispose();
            root.Dispose();
        }
    }
}
