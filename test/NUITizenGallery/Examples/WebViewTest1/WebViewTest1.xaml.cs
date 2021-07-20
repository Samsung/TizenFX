using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class WebViewTest1Page : ContentPage
    {
        public WebViewTest1Page()
        {
            InitializeComponent();
        }

        public void OnTextChanged(object sender, EventArgs e)
        {
            if (sender is TextField textField)
            {
                GoButton.IsEnabled = !string.IsNullOrWhiteSpace(textField.Text);
            }
        }

        public void OnUrlChanged(object sender, WebViewUrlChangedEventArgs e)
        {
            if (sender is WebView webView)
            {
                InputField.Text = e.NewPageUrl;
                BackButton.IsEnabled = webView.CanGoBack();
                NextButton.IsEnabled = webView.CanGoForward();
            }
        }

        public void OnGoClicked(object sender, EventArgs e)
        {
            InputField.GetInputMethodContext()?.HideInputPanel();
            TargetWebView.Url = InputField.Text;
        }

        public void OnBackClicked(object sender, EventArgs e)
        {
            TargetWebView.GoBack();
        }

        public void OnNextClicked(object sender, EventArgs e)
        {
            TargetWebView.GoForward();
        }
    }
}

