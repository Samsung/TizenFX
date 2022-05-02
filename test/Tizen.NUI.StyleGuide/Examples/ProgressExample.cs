/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.StyleGuide
{
    // IExample inehrited class will be automatically added in the main examples list.
    internal class ProgressExample : ContentPage, IExample
    {
        private View rootContent;
        private Progress bufferingProgress, disabledProgress, determinatedProgress, indeterminatedProgress;

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public ProgressExample() : base()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "Progress Default Style",
            };

            // Example root content view.
            // you can decorate, add children on this view.
            rootContent = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 20),
                },
            };

            // Progress examples.
            bufferingProgress = new Progress()
            {
                MinValue = 0,
                MaxValue = 100,
                BufferValue = 10,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                ProgressState = Progress.ProgressStatusType.Buffering,
            };
            rootContent.Add(bufferingProgress);

            determinatedProgress = new Progress()
            {
                MinValue = 0,
                MaxValue = 100,
                CurrentValue = 80,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                ProgressState = Progress.ProgressStatusType.Determinate,
            };
            rootContent.Add(determinatedProgress);

            indeterminatedProgress = new Progress()
            {
                MinValue = 0,
                MaxValue = 100,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                ProgressState = Progress.ProgressStatusType.Indeterminate,
            };
            rootContent.Add(indeterminatedProgress);


            disabledProgress = new Progress()
            {
                MinValue = 0,
                MaxValue = 100,
                IsEnabled = false,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                ProgressState = Progress.ProgressStatusType.Determinate,
            };
            rootContent.Add(disabledProgress);
            Content = rootContent;
        }
    }
}
