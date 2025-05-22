/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

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
            TargetWebView.LoadUrl(TargetWebView.Url);
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

