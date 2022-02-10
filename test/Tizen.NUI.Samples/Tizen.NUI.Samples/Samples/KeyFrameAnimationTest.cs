/*
* Copyright (c) 2022 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class KeyFrameAnimationTest : IExample
    {
        private static string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        private Animation animation;
        private ImageView imageView;
        private bool isAniFinised = true;
        private Button button;
        private Window window;
        private const int testPosition = 100;
        private const int testSize = 100;

        public void Activate()
        {
            Initialize();
        }
        public void Deactivate()
        {
            FocusManager.Instance.ClearFocus();
            imageView.Unparent();
            imageView.Dispose();

            button.Unparent();
            button.Dispose();
        }

        public void Initialize()
        {
            window = NUIApplication.GetDefaultWindow();
            imageView = new ImageView();
            imageView.ResourceUrl = resourcePath + "/images/Dali/DaliDemo/application-icon-1.png";
            imageView.Position = new Position2D(testPosition, testPosition);
            imageView.Size = new Size2D(testSize, testSize);
            window.Add(imageView);

            button = new Button()
            {
                Position = new Position2D(0, 0),
                Text = "click or Return key",
                BackgroundColor = Color.DarkGreen,
                Focusable = true,
            };
            button.Clicked += OnButtonClicked;
            window.Add(button);
            FocusManager.Instance.SetCurrentFocusView(button);

        }

        private void OnButtonClicked(object sender, ClickedEventArgs e)
        {
            if (!isAniFinised) return;
            isAniFinised = false;

            // Create a new animation
            if (animation)
            {
                //animation.Stop(Tizen.NUI.Constants.Animation.EndAction.Stop);
                animation.Reset();
            }

            animation = new Animation();

            KeyFrames pixelkeyFrames = new KeyFrames();
            pixelkeyFrames.Add(0.25f, new Vector4(0.5f, 0.0f, 0.5f, 0.5f));
            pixelkeyFrames.Add(0.5f, new Vector4(0.5f, 0.5f, 0.5f, 0.5f));
            pixelkeyFrames.Add(0.75f, new Vector4(0.0f, 0.0f, 1.0f, 1.0f));
            pixelkeyFrames.Add(1.0f, new Vector4(0.5f, 0.5f, 0.5f, 0.5f));
            animation.AnimateBetween(imageView, "PixelArea", pixelkeyFrames, 0, 8000, Animation.Interpolation.Cubic);

            KeyFrames keyFrames = new KeyFrames();
            keyFrames.Add(0.0f, new Size(0.0f, 0.0f, 0.0f));
            keyFrames.Add(0.3f, new Size(window.Size.Width * 0.3f, window.Size.Height * 0.3f, 0));
            keyFrames.Add(1.0f, new Size(window.Size.Width * 0.5f, window.Size.Height * 0.5f, 0));
            animation.AnimateBetween(imageView, "Size", keyFrames, 2000, 6000, Animation.Interpolation.Linear);

            KeyFrames positionkeyFrames = new KeyFrames();
            positionkeyFrames.Add(0.0f, new Position(testPosition * 1.5f, testPosition * 1.5f, 0));
            positionkeyFrames.Add(0.2f, new Position(window.Size.Width * 0.5f, window.Size.Height * 0.1f, 0));
            positionkeyFrames.Add(0.4f, new Position(window.Size.Width * 0.6f, window.Size.Height * 0.5f, 0));
            positionkeyFrames.Add(0.8f, new Position(window.Size.Width * 0.1f, window.Size.Height * 0.6f, 0));
            positionkeyFrames.Add(1.0f, new Position(window.Size.Width * 0.6f, window.Size.Height * 0.7f, 0));
            animation.AnimateBetween(imageView, "Position", positionkeyFrames, 0, 9000, Animation.Interpolation.Cubic);

            animation.EndAction = Animation.EndActions.Discard;

            // Connect the signal callback for animaiton finished signal
            animation.Finished += AnimationFinished;
            animation.Finished += AnimationFinishedSecond;

            // Play the animation
            animation.Play();
        }

        // Callback for animation finished signal handling
        public void AnimationFinished(object sender, EventArgs e)
        {
            Tizen.Log.Debug("NUITEST", $"animation finished");
        }

        // Callback for second animation finished signal handling
        public void AnimationFinishedSecond(object sender, EventArgs e)
        {
            if (animation)
            {
                isAniFinised = true;
            }
        }
    }
}
