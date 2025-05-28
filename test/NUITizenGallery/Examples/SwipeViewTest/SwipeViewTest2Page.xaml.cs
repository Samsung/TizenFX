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
    public partial class SwipeViewTest2Page : ContentPage
    {
        private PanGestureDetector panGestureDetector;
        private Position init1Position;
        private Position init2Position;

        public SwipeViewTest2Page()
        {
            InitializeComponent();

            panGestureDetector = new PanGestureDetector();
            panGestureDetector.Attach(text1View);
            panGestureDetector.Attach(text2View);
            panGestureDetector.Detected += (obj, e) =>
            {
                Vector2 velocity = e.PanGesture.Velocity;
                View view = e.View;
                if (view != null)
                {
                    if (e.PanGesture.State == Gesture.StateType.Started)
                    {
                        init1Position = text1View.Position;
                        init2Position = text2View.Position;
                    }
                    else if (e.PanGesture.State == Gesture.StateType.Finished || e.PanGesture.State == Gesture.StateType.Cancelled)
                    {
                        if(view.Position.X < - 110)
                        {
                            var button = new Button()
                            {
                                Text = "Cancel",
                            };

                            button.Clicked += (object s, ClickedEventArgs a) =>
                            {
                                Navigator?.Pop();
                            };

                            if (view == text1View)
                            {
                                DialogPage.ShowAlertDialog("SwipeView", "SwipeItemView Invoked", button);
                            }
                            else if (view == text2View)
                            {
                                DialogPage.ShowAlertDialog("SwipeView", "SwipeItemView Command Executed", button);
                            }
                        }

                        text1View.Position = init1Position;
                        text2View.Position = init2Position;
                    }
                    else
                    {
                        if (velocity.X < 0 && view.Position.X > -140)
                        {
                            view.Position += new Position(e.PanGesture.ScreenDisplacement.X, 0, 0);
                        }
                    }
                }
            };

        }

    }
}
