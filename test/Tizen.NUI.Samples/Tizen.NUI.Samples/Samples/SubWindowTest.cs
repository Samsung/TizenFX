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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class SubWindowTest : IExample
    {
        private static string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        private Window mainWin;

        private ImageView imageView1;
        private ImageView imageView2;

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
            mainWin.BackgroundColor = Color.Cyan;
            imageView1 = new ImageView
            {
                 Position2D = new Position2D(100, 100),
                Size2D = new Size2D(146, 146),
                SynchronosLoading = true,
                ResourceUrl = resourcePath + "images/animated.gif"
                //AlphaMaskURL = resourcePath + "images/mask_f.png"
            };
            //imageView1.CropToMask = true;
            mainWin.Add(imageView1);

            imageView2 = new ImageView
            {
                Position2D = new Position2D(300, 100),
                Size2D = new Size2D(146, 146),
                ResourceUrl = resourcePath + "images/animated.gif",
                //AlphaMaskURL = resourcePath + "images/mask_f.png"
            };
            //imageView2.CropToMask = false;
            mainWin.Add(imageView2);
        }
    }
}
