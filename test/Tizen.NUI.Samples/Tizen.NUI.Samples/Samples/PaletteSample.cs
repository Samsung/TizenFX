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
        private static int maxView = 4;
        private static string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        private static string[] imagePath = {
            resourcePath + "/images/PaletteTest/rock.jpg",
            resourcePath + "/images/PaletteTest/red2.jpg",
            resourcePath + "/images/PaletteTest/10by10tree.png",
            resourcePath + "/images/PaletteTest/3color.jpeg"
        };

        private int viewIndex = 0;
        private int windowWidth, windowHeight;
        private int imageViewSize;
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
        private Stopwatch timerImage = new Stopwatch();
        private Stopwatch timerPalette = new Stopwatch();
        private int useRegionType = 0;

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
            imageViewSize = Math.Min(windowWidth, windowHeight - bottomHeight);

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
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
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
                Text = "Next",
                Size = new Size(buttonWeight, buttonHeight),
                Margin = 10,
            };
            Button regionBtn = new Button()
            {
                Text = "Change Region",
                Size = new Size(buttonWeight * 2, buttonHeight),
                Margin = 10,
            };
            bottomView.Add(prevBtn);
            bottomView.Add(nextBtn);
            bottomView.Add(regionBtn);

            prevBtn.Clicked += PrevClicked;
            nextBtn.Clicked += NextClicked;
            regionBtn.Clicked += RegionClicked;
        }

        private void PrevClicked(object sender, ClickedEventArgs e)
        {
            if (viewIndex == 0)
            {
                viewIndex = maxView;
            }
            viewIndex--;

            view.Unparent();
            CreatePage(viewIndex);

        }

        private void NextClicked(object sender, ClickedEventArgs e)
        {
            viewIndex++;
            if (viewIndex == maxView)
            {
                viewIndex = 0;
            }

            view.Unparent();
            CreatePage(viewIndex);
        }

        private void RegionClicked(object sender, ClickedEventArgs e)
        {
            useRegionType += 1;
            if (useRegionType == 3)
            {
                useRegionType = 0;
            }

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

            palette = ImageGenerate(viewIndex);

            TextLabel label = new TextLabel("Time = (load) " + timerImage.ElapsedMilliseconds.ToString() + "ms (palette) " + timerPalette.ElapsedMilliseconds.ToString() + "ms")
            {
                Size2D  = new Size2D((int)(windowWidth), (int)((windowHeight - windowWidth) / 9)),
                HorizontalAlignment = HorizontalAlignment.End,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(label);

            CreateSwatchLabel("Dominant", palette.GetDominantSwatch());
            CreateSwatchLabel("LightVibrant", palette.GetLightVibrantSwatch());
            CreateSwatchLabel("Vibrant", palette.GetVibrantSwatch());
            CreateSwatchLabel("DarkVibrant", palette.GetDarkVibrantSwatch());
            CreateSwatchLabel("LightMuted", palette.GetLightMutedSwatch());
            CreateSwatchLabel("Muted", palette.GetMutedSwatch());
            CreateSwatchLabel("DarkMuted", palette.GetDarkMutedSwatch());

            timerImage.Reset();
            timerPalette.Reset();
        }

        private void CreateSwatchLabel(string title, Palette.Swatch swatch)
        {
            var swatchInfo = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Row,
                    Justification = FlexLayout.FlexJustification.SpaceBetween,
                    WrapType = FlexLayout.FlexWrapType.NoWrap,
                },
            };

            var titleLabel = new TextLabel()
            {
                Text = title,
            };
            swatchInfo.Add(titleLabel);

            var bodyLabel = new TextLabel()
            {
                Text = " Invalid",
            };
            swatchInfo.Add(bodyLabel);

            if (swatch != null)
            {
                Color color = swatch.GetRgb();
                Color titleColor = swatch.GetTitleTextColor();
                Color bodyColor = swatch.GetBodyTextColor();
                bodyLabel.Text = " RGB(" + (int)(color.R * 255) + " " + (int)(color.G * 255) + " " + (int)(color.B * 255) + ")";

                swatchInfo.BackgroundColor = color;
                titleLabel.TextColor = titleColor;
                bodyLabel.TextColor = bodyColor;
            }

            view.Add(swatchInfo);
        }

        public Palette ImageGenerate(int idx)
        {
            timerImage.Start();
            PixelBuffer imgBitmap = ImageLoader.LoadImageFromFile(imagePath[idx]);
            timerImage.Stop();

            Rectangle rect = null;
            if(useRegionType == 1)
            {
                rect = new Rectangle();
                rect.Width = (int)imgBitmap.GetWidth() / 5;
                rect.Height = (int)imgBitmap.GetHeight() / 5;
                rect.Y = 0;
                rect.X = (int)imgBitmap.GetWidth() - rect.Width;
            }
            else if(useRegionType == 2)
            {
                rect = new Rectangle();
                rect.Width = (int)imgBitmap.GetWidth() / 5;
                rect.Height = (int)imgBitmap.GetHeight() / 5;
                rect.Y = ((int)imgBitmap.GetHeight() - rect.Height) / 2;
                rect.X = ((int)imgBitmap.GetWidth() - rect.Width) / 2;
            }

            timerPalette.Start();
            Palette palette = Palette.Generate(imgBitmap, rect);
            timerPalette.Stop();

            return palette;
        }

        public ImageView CreateImageView(int idx)
        {
            ImageView tempImage = new ImageView()
            {
                ResourceUrl = imagePath[idx],
                Size = new Tizen.NUI.Size(imageViewSize, imageViewSize),
                HeightResizePolicy = ResizePolicyType.Fixed,
                WidthResizePolicy = ResizePolicyType.Fixed,
            };

            if(useRegionType == 1)
            {
                var borderVisual = new Tizen.NUI.Visuals.BorderVisual()
                {
                    PivotPoint = Visual.AlignType.TopEnd,
                    Origin = Visual.AlignType.TopEnd,
                    Width = 0.2f, // Default size policy is relative
                    Height = 0.2f, // Default size policy is relative
                    BorderWidth = 4.0f,
                    BorderColor = Color.Black,
                };
                tempImage.AddVisual(borderVisual, ViewVisualContainerRange.Decoration);
            }
            if(useRegionType == 2)
            {
                var borderVisual = new Tizen.NUI.Visuals.BorderVisual()
                {
                    PivotPoint = Visual.AlignType.Center,
                    Origin = Visual.AlignType.Center,
                    Width = 0.2f, // Default size policy is relative
                    Height = 0.2f, // Default size policy is relative
                    BorderWidth = 4.0f,
                    BorderColor = Color.Black,
                };
                tempImage.AddVisual(borderVisual, ViewVisualContainerRange.Decoration);
            }

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
