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
    public partial class PinchGestureTest1Page : ContentPage
    {
        private PinchGestureDetector pinchDetector;
        private Vector3 startingScale;
        public PinchGestureTest1Page()
        {
            InitializeComponent();

            pinchDetector = new PinchGestureDetector();
            pinchDetector.Attach(imageView);

            pinchDetector.Detected += (obj, e) =>
            {
                View view = e.View;
                if (view != null)
                {
                    if(e.PinchGesture.State == Gesture.StateType.Started)
                    {
                        startingScale = view.Scale;
                    }
                    view.Scale = startingScale * e.PinchGesture.Scale;
                }
            };
        }
    }
}