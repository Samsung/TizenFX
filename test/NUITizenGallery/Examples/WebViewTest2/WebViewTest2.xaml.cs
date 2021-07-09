using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class WebViewTest2Page : ContentPage
    {
        public WebViewTest2Page()
        {
            InitializeComponent();

            string text = @"<div style='background-color:yellow'>
  <h1>Hello World!</h1>
</div>";
            InputField.Text = text;
            TargetWebView.LoadHTMLString(text);
        }

        public void OnTextChanged(object sender, EventArgs e)
        {
            if (sender is TextField textField)
            {
                RunButton.IsEnabled = !string.IsNullOrWhiteSpace(textField.Text);
            }
        }

        public void OnUrlChanged(object sender, WebViewUrlChangedEventArgs e)
        {
            if (sender is WebView webView)
            {
                InputField.Text = e.NewPageUrl;
            }
        }

        public void OnRunClicked(object sender, EventArgs e)
        {
            InputField.GetInputMethodContext()?.HideInputPanel();
            TargetWebView.LoadHTMLString(InputField.Text);
        }
    }
}

