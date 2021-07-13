/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
namespace NUITizenGallery
{
    public partial class TextAnchorTestPage : ContentPage
    {
        public TextAnchorTestPage()
        {
            InitializeComponent();

            anchorLabel.Text = "<a href='www.tizen.org/TextLabel'>Click TextLabel Anchor</a>";
            anchorLabel.EnableMarkup = true;
            anchorLabel.AnchorClicked += OnAnchorClicked;

            anchorField.Text = "<a href='www.tizen.org/TextField'>Click TextField Anchor</a>";
            anchorField.EnableMarkup = true;
            anchorField.AnchorClicked += OnAnchorClicked;

            anchorEditor.Text = "<a href='www.tizen.org/TextEditor'>Click TextEditor Anchor</a>";
            anchorEditor.EnableMarkup = true;
            anchorEditor.AnchorClicked += OnAnchorClicked;
        }

        public void OnAnchorClicked(object sender, AnchorClickedEventArgs e)
        {
            field.Text = e.Href;
        }
    }
}
