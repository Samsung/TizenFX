/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class PlaceHolderImageSample : IExample
    {
        private const string tag = "NUITEST";
        private Window mainWin;
        private ImageView[] imageViews = null;
        const int imageWidth = 500;
        const int imageHeight = 500;
        const int imageMax = 6;
        Timer mTimer;
        int image_count = 0;

        private static string[] url = new string[]
        {
            "https://images.pexels.com/photos/16027424/pexels-photo-16027424.jpeg",
            "https://images.pexels.com/photos/214574/pexels-photo-214574.jpeg",
            "https://images.pexels.com/photos/39853/woman-girl-freedom-happy-39853.jpeg",
            "https://images.pexels.com/photos/842711/pexels-photo-842711.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2",
            "https://images.pexels.com/photos/15828302/pexels-photo-15828302.jpeg",
            "",
        };

        public void Activate()
        {
            Initialize();
        }

        public void Deactivate()
        {
        }

        private void Initialize()
        {
            mainWin = NUIApplication.GetDefaultWindow();
            mainWin.BackgroundColor = Color.White;
            mainWin.WindowSize = new Size2D(1920,1080);
            Size2D windowSize = new Size2D(mainWin.Size.Width,mainWin.Size.Height);

            imageViews = new ImageView[imageMax];
            for(int i=0; i<imageMax; i++)
            {
                int width = (i%(imageMax/2))*imageWidth;
                int height = (i/(imageMax/2))*imageHeight;
                imageViews[i] = new ImageView();
                imageViews[i].Size2D = new Size2D(imageWidth, imageHeight);
                imageViews[i].Position2D = new Position2D(width,height);
                imageViews[i].ResourceUrl = url[i];
                imageViews[i].PlaceHolderUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/placeholder_image.png";
                imageViews[i].TransitionEffect = true;
                imageViews[i].SetTransitionEffectOption(0.0f, 1.0f, 0.0f, 3.0f, AlphaFunction.BuiltinFunctions.EaseInOut);
                mainWin.Add(imageViews[i]);
            }

            mTimer = new Timer(5000);
            mTimer.Tick += ((object target, Timer.TickEventArgs args) =>
            {
                image_count++;
                for(int i=0;i<imageMax;i++)
                {
                    imageViews[i].ResourceUrl = url[(image_count+i)%imageMax];
                }
                return true;
            });

            mTimer.Start();
        }
    }
}
