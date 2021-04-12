/*
* Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.Diagnostics;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    class PaletteSample : IExample
    {
        private static int bottomHeight = 60;
        private static int buttonWeight = 100;
        private static int buttonHeight = 40;
        private static int maxView = 2;
        private static string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        private static string[] imagePath = {
            resourcePath + "/images/PaletteTest/rock.jpg",
            resourcePath + "/images/PaletteTest/red2.jpg",
            resourcePath + "/images/PaletteTest/10by10tree.png",
            resourcePath + "/images/PaletteTest/3color.jpeg"
        };

        private int viewIndex = 0;
        private int windowWidth, windowHeight;
        private Window currentWindow;
        private View view;
        private View bottomView;
        private ImageView imageView;
        private Palette palette;
        private Palette.Swatch dominantSwatch;
        private Palette.Swatch vibrantSwatch;
        private Palette.Swatch mutedSwatch;
        private Palette.Swatch darkVibrantSwatch;
        private Palette.Swatch darkMutedSwatch;
        private Palette.Swatch lightVibrantSwatch;
        private Palette.Swatch lightMutedSwatch;
        private Stopwatch timer = new Stopwatch();

        public void Activate()
        {
            Initialize();
        }

        public void Initialize()
        {
            currentWindow = NUIApplication.GetDefaultWindow();
            currentWindow.BackgroundColor = Color.White;

            windowWidth = Window.Instance.Size.Width;
            windowHeight = Window.Instance.Size.Height;

            CreatePage(viewIndex);
            CreateBottomLayout();

        }

        public void CreateBottomLayout()
        {
            bottomView = new View()
            {
                Size = new Size(windowWidth, bottomHeight),
                Position2D = new Position2D(0, windowHeight - bottomHeight),
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Center,
                }

            };
            currentWindow.Add(bottomView);

            Button prevBtn = new Button()
            {
                Text = "Prev",
                Size = new Size(buttonWeight, buttonHeight),
                Margin = 10,
            };
            Button nextBtn = new Button()
            {
                Text = "next",
                Size = new Size(buttonWeight, buttonHeight),
                Margin = 10,
            };
            bottomView.Add(prevBtn);
            bottomView.Add(nextBtn);

            prevBtn.Clicked += PrevClicked;
            nextBtn.Clicked += NextClicked;
        }

        private void PrevClicked(object sender, ClickedEventArgs e)
        {
            if (viewIndex == 0) return;

            viewIndex--;
            view.Unparent();
            CreatePage(viewIndex);

        }

        private void NextClicked(object sender, ClickedEventArgs e)
        {
            if (viewIndex == maxView) return;

            viewIndex++;
            view.Unparent();
            CreatePage(viewIndex);
        }

        public void CreatePage(int idx)
        {
            view = new View()
            {
                Size = new Size(windowWidth, windowHeight - bottomHeight),
                Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical },
            };
            currentWindow.Add(view);

            imageView = CreateImageView(viewIndex);
            view.Add(imageView);

            timer.Start();
            palette = ImageGenerate(viewIndex);
            timer.Stop();

            TextLabel label = new TextLabel("Time = " + timer.ElapsedMilliseconds.ToString() + "ms")
            {
                Size2D  = new Size2D((int)(windowWidth), (int)((windowHeight - windowWidth) / 9)),
                HorizontalAlignment = HorizontalAlignment.End,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(label);

            dominantSwatch = palette.GetDominantSwatch();
             if (dominantSwatch != null) {
                CreateLabel(dominantSwatch);
            }

            lightVibrantSwatch = palette.GetLightVibrantSwatch();
            if (lightVibrantSwatch != null) {
                CreateLabel(lightVibrantSwatch);
            }

            vibrantSwatch = palette.GetVibrantSwatch();
            if (vibrantSwatch != null) {
                CreateLabel(vibrantSwatch);
            }

            darkVibrantSwatch = palette.GetDarkVibrantSwatch();
            if (darkVibrantSwatch != null) {
                CreateLabel(darkVibrantSwatch);
            }

            lightMutedSwatch = palette.GetLightMutedSwatch();
            if (lightMutedSwatch != null) {
                CreateLabel(lightMutedSwatch);
            }

            mutedSwatch = palette.GetMutedSwatch();
            if (mutedSwatch != null) {
                CreateLabel(mutedSwatch);
            }

            darkMutedSwatch = palette.GetDarkMutedSwatch();
            if (darkMutedSwatch != null) {
                CreateLabel(darkMutedSwatch);
            }

            timer.Reset();
        }

        public void CreateLabel(Palette.Swatch swatch)
        {
            Color color = swatch.GetRgb();

            string txt = " RGB(" + (int)(color.R * 255) + " " + (int)(color.G * 255) + " " + (int)(color.B * 255) + ")";
            TextLabel label = new TextLabel(txt)
            {
                TextColor = swatch.GetBodyTextColor(),
                BackgroundColor = color,
                Size2D  = new Size2D((int)(windowWidth), (int)((windowHeight - windowWidth) / 9)),
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };

            view.Add(label);
        }

        public Palette ImageGenerate(int idx)
        {
            PixelBuffer imgBitmap = ImageLoading.LoadImageFromFile(imagePath[idx]);
            Palette palette = Palette.Generate(imgBitmap);
            
            return palette;
        }

        public ImageView CreateImageView(int idx)
        {
            ImageView tempImage = new ImageView()
            {
                ResourceUrl = imagePath[idx],
                Size = new Tizen.NUI.Size(Window.Instance.Size.Width, Window.Instance.Size.Width),
                HeightResizePolicy = ResizePolicyType.Fixed,
                WidthResizePolicy = ResizePolicyType.Fixed,
            };

            return tempImage;
        }

        public void Deactivate()
        {
            //Will Do FullGC in DailDemo Class
            view.Unparent();
            bottomView.Unparent();

            view.Dispose();
            bottomView.Dispose();

            view = null;
            bottomView = null;
        }
    }
}
