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

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class TapGestureTest1Page : ContentPage
    {
        private string ImageURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";
        private TapGestureDetector imageTapDetector;
        private TapGestureDetector frameTapDetector;
        private int imageTapCount;
        private int frameTapCount;

        public TapGestureTest1Page()
        {
            InitializeComponent();
            tabView.Padding = new Extents(20, 20, 20, 20);

            CreateImageTab();
            CreateFrameTab();
        }

        private void CreateImageTab()
        {
          imageTapCount = 0;
          TabButton button = new TabButton() { Text = "Image", };
          View view = new View
          {
            Layout = new LinearLayout()
              {
                  LinearOrientation = LinearLayout.Orientation.Vertical,
                  LinearAlignment = LinearLayout.Alignment.Center,
                  CellPadding = new Size2D(30, 30),
              },
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = LayoutParamPolicies.MatchParent,
          };

          ImageView image = new ImageView
          {
              ResourceUrl = ImageURL + "picture.png",
              BorderlineWidth = 5f,
              BorderlineColor = Color.Red,
          };

          TextLabel label = new TextLabel
          {
            Text = "tap the photo!",
            PointSize = 8,
          };

          view.Add(image);
          view.Add(label);

          tabView.AddTab(button, view);

          imageTapDetector = new TapGestureDetector();
          imageTapDetector.Attach(image);
          imageTapDetector.Detected += (obj, e) =>
          {
              ++imageTapCount;
              label.Text = imageTapCount + " taps so far!";
          };

        }

        private void CreateFrameTab()
        {
          frameTapCount = 0;
          TabButton button = new TabButton() { Text = "Frame", };

          View view = new View
          {
            Layout = new LinearLayout()
              {
                  LinearOrientation = LinearLayout.Orientation.Vertical,
                  LinearAlignment = LinearLayout.Alignment.Center,
                  CellPadding = new Size2D(30, 30),
              },
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = LayoutParamPolicies.MatchParent,
          };

          View image = new View
          {
              BackgroundColor = Color.White,
              Size = new Size(200, 200),

              BorderlineWidth = 5f,
              BorderlineColor = Color.Red,
          };

          TextLabel label = new TextLabel
          {
            Text = "tap the frame!",
            PointSize = 8,
          };

          view.Add(image);
          view.Add(label);

          tabView.AddTab(button, view);

          frameTapDetector = new TapGestureDetector();
          frameTapDetector.Attach(image);
          frameTapDetector.Detected += (obj, e) =>
          {
              ++frameTapCount;
              label.Text = frameTapCount + " taps so far!";
          };

        }
    }
}
