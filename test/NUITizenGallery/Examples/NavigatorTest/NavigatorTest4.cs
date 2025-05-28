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

using System;
using Tizen;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public class NavigatorContentPage4 : ContentPage
    {
        private readonly string[,] Keywords = new string[3, 2]
        {
            {"red", "redGrey"},
            {"green", "greenGrey"},
            {"blue", "blueGrey"}
        };
        private readonly string totalGreyTag = "totalGrey";

        private Navigator navigator;
        private ContentPage mainPage;
        private ContentPage redPage, greenPage, bluePage, totalPage;

        private readonly Vector4 ColorGrey = new Vector4(0.82f, 0.80f, 0.78f, 1.0f);

        private readonly Vector4[] TileColor = { new Color("#F5625D"), new Color("#7DFF83"), new Color("#7E72DF") };

        private readonly Vector2 baseSize = new Vector2(480.0f, 800.0f);
        private Vector2 contentSize;

        private float magnification;

        private Window window;

        private float convertSize(float size)
        {
            return size * magnification;
        }

        public NavigatorContentPage4(Window win)
        {
            window = win;

            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            AppBar = new AppBar()
            {
                Title = "Navigator Sample",
            };

            var button = new Button()
            {
                Text = "Click to show Navigator",
                WidthSpecification = 400,
                HeightSpecification = 100,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
                Focusable = true,
            };
            Content = button;

            button.Clicked += (object sender, ClickedEventArgs e) =>
            {
                PushPopNavigator(window);
            };

            //navigator = window.GetDefaultNavigator();
        }

        public void PushPopNavigator(Window window)
        {
            Vector2 windowSize = new Vector2(window.Size.Width, window.Size.Height);
            magnification = Math.Min(windowSize.X / baseSize.X, windowSize.Y / baseSize.Y);
            contentSize = baseSize * magnification;

            navigator = new Navigator()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                Transition = new Transition()
                {
                    TimePeriod = new TimePeriod(400),
                    AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOutSine),
                },
            };
            window.Add(navigator);

            //navigator = window.GetDefaultNavigator();

            View mainRoot = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent
            };

            View layoutView = new View()
            {
                PositionUsesPivotPoint = true,
                PivotPoint = Tizen.NUI.PivotPoint.BottomCenter,
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomCenter,
                Layout = new LinearLayout()
                {
                    LinearAlignment = LinearLayout.Alignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    CellPadding = new Size(convertSize(60), convertSize(60)),
                },
                Position = new Position(0, -convertSize(30))
            };
            mainRoot.Add(layoutView);

            View redButton = CreateButton(TileColor[0], Keywords[0, 0], Keywords[0, 1], redPage);
            View greenButton = CreateButton(TileColor[1], Keywords[1, 0], Keywords[1, 1], greenPage);
            View blueButton = CreateButton(TileColor[2], Keywords[2, 0], Keywords[2, 1], bluePage);

            layoutView.Add(redButton);
            layoutView.Add(greenButton);
            layoutView.Add(blueButton);

            TransitionGroup transitionGroup = new TransitionGroup()
            {
                UseGroupAlphaFunction = true,
                AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOut),
            };
            SlideTransition slide = new SlideTransition()
            {
                TimePeriod = new TimePeriod(400),
                AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default),
                Direction = SlideTransitionDirection.Top
            };
            transitionGroup.AddTransition(slide);
            FadeTransition fade = new FadeTransition()
            {
                Opacity = 0.3f,
                TimePeriod = new TimePeriod(400),
                AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default)
            };
            transitionGroup.AddTransition(fade);
            ScaleTransition scale = new ScaleTransition()
            {
                ScaleFactor = new Vector2(0.3f, 0.3f),
                TimePeriod = new TimePeriod(400),
                AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default)
            };
            transitionGroup.AddTransition(scale);

            var popButton = new Button()
            {
                Text = "Pop",
            };
            popButton.Clicked += (object sender, ClickedEventArgs e) =>
            {
                navigator.Pop();
                window.Remove(navigator);
                navigator = null;
            };

            mainPage = new ContentPage()
            {
                AppBar = new AppBar()
                {
                    AutoNavigationContent = true,
                    Title = "Main Page",
                    NavigationContent = popButton,
                },
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
                Content = mainRoot,
                DisappearingTransition = new ScaleTransition()
                {
                    TimePeriod = new TimePeriod(500),
                    AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default),
                    ScaleFactor = new Vector2(0.5f, 1.5f)
                },
                AppearingTransition = transitionGroup,
            };
            navigator.Push(mainPage);

            View totalGreyView = new View()
            {
                Size = new Size(convertSize(50), convertSize(50)),
                CornerRadius = convertSize(25),
                BackgroundColor = ColorGrey,
                TransitionOptions = new TransitionOptions()
                {
                    TransitionTag = totalGreyTag,
                },
                Focusable = true,
            };

            totalGreyView.TouchEvent += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    navigator.PushWithTransition(totalPage);
                }
                return true;
            };
            totalGreyView.KeyEvent += (object sender, View.KeyEventArgs e) =>
            {
                if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Return")
                {
                    navigator.PushWithTransition(totalPage);
                }
                return false;
            };
            layoutView.Add(totalGreyView);


            // ------------------------------------------------------
            View totalPageRoot = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                SizeHeight = contentSize.Height,
            };

            View totalLayoutView = new View()
            {
                Layout = new GridLayout()
                {
                    Rows = 2,
                    GridOrientation = GridLayout.Orientation.Vertical,
                },
                PositionUsesPivotPoint = true,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
            };
            totalPageRoot.Add(totalLayoutView);

            for (int i = 0; i < 3; ++i)
            {
                View sizeView = new View()
                {
                    Size = new Size(contentSize.Width / 2.0f, contentSize.Height / 2.0f),
                };
                View smallView = CreatePageScene(TileColor[i], Keywords[i, 0], Keywords[i, 1]);
                smallView.Scale = new Vector3(0.45f, 0.45f, 1.0f);
                smallView.PositionUsesPivotPoint = true;
                smallView.PivotPoint = Tizen.NUI.PivotPoint.Center;
                smallView.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
                sizeView.Add(smallView);
                totalLayoutView.Add(sizeView);
            }

            View sizeGreyView = new View()
            {
                Size = new Size(contentSize.Width / 2.0f, contentSize.Height / 2.0f),
            };

            View totalGreyReturnView = new View()
            {
                PositionUsesPivotPoint = true,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                Size = new Size(convertSize(70), convertSize(70)),
                CornerRadius = convertSize(20),
                BackgroundColor = ColorGrey,
                TransitionOptions = new TransitionOptions()
                {
                    TransitionTag = totalGreyTag,
                },
                Focusable = true,
            };
            sizeGreyView.Add(totalGreyReturnView);
            totalLayoutView.Add(sizeGreyView);

            totalGreyReturnView.TouchEvent += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    navigator?.PopWithTransition();
                }
                return true;
            };
            totalGreyReturnView.KeyEvent += (object sender, View.KeyEventArgs e) =>
            {
                if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Return")
                {
                    navigator?.PopWithTransition();
                }
                return false;
            };

            totalPage = new ContentPage()
            {
                AppBar = new AppBar()
                {
                    Title = "Total Page",
                },
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
                Content = totalPageRoot,
                AppearingTransition = new FadeTransition()
                {
                    TimePeriod = new TimePeriod(500),
                    AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default),
                },
                DisappearingTransition = new FadeTransition()
                {
                    TimePeriod = new TimePeriod(500),
                    AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default),
                },
            };
        }

        private View CreateButton(Color color, string colorTag, string greyTag, Page secondPage)
        {
            View colorView = new View()
            {
                Size = new Size(convertSize(50), convertSize(50)),
                CornerRadius = 0.45f,
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                BackgroundColor = color,
                Orientation = new Rotation(new Radian((float)Math.PI / 2.0f), Vector3.ZAxis),
                TransitionOptions = new TransitionOptions()
                {
                    TransitionTag = colorTag,
                }
            };

            View greyView = new View()
            {
                PositionUsesPivotPoint = true,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                Size = new Size(convertSize(40), convertSize(40)),
                CornerRadius = 0.45f,
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                BackgroundColor = ColorGrey,
                Orientation = new Rotation(new Radian(-(float)Math.PI / 2.0f), Vector3.ZAxis),
                TransitionOptions = new TransitionOptions()
                {
                    TransitionTag = greyTag,
                },
                Focusable = true,
            };

            secondPage = CreatePage(color, colorTag, greyTag);

            greyView.TouchEvent += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    navigator.PushWithTransition(secondPage);
                }
                return true;
            };
            greyView.KeyEvent += (object sender, View.KeyEventArgs e) =>
            {
                if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Return")
                {
                    navigator.PushWithTransition(secondPage);
                }
                return false;
            };
            colorView.Add(greyView);
            return colorView;
        }

        private View CreatePageScene(Color color, string colorTag, string greyTag)
        {
            View pageBackground = new View()
            {
                SizeWidth = contentSize.Width,
                SizeHeight = contentSize.Height,
            };

            View colorView = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                CornerRadius = 0.05f,
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                BackgroundColor = color,
                TransitionOptions = new TransitionOptions()
                {
                    TransitionTag = colorTag
                }
            };

            View greyView = new View()
            {
                PositionUsesPivotPoint = true,
                PivotPoint = Tizen.NUI.PivotPoint.TopCenter,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopCenter,
                Position = new Position(0, convertSize(80)),
                SizeWidth = contentSize.Width * 0.7f,
                SizeHeight = contentSize.Height * 0.06f,
                CornerRadius = 0.1f,
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                BackgroundColor = ColorGrey,
                TransitionOptions = new TransitionOptions()
                {
                    TransitionTag = greyTag
                }
            };

            View whiteView = new View()
            {
                PositionUsesPivotPoint = true,
                PivotPoint = Tizen.NUI.PivotPoint.BottomCenter,
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomCenter,
                Position = new Position(0, -convertSize(60)),
                SizeWidth = contentSize.Width * 0.75f,
                SizeHeight = contentSize.Height * 0.7f,
                CornerRadius = 0.1f,
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                BackgroundColor = Color.AntiqueWhite,
            };
            pageBackground.Add(colorView);
            pageBackground.Add(whiteView);
            pageBackground.Add(greyView);
            pageBackground.Focusable = true;
            
            return pageBackground;
        }

        private Page CreatePage(Color color, string colorTag, string greyTag)
        {
            View pageRoot = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent
            };

            View pageBackground = CreatePageScene(color, colorTag, greyTag);
            pageBackground.TouchEvent += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    navigator?.PopWithTransition();
                }
                return true;
            };
            pageRoot.Add(pageBackground);

            TransitionGroup transitionGroup = new TransitionGroup();
            FadeTransition slide = new FadeTransition()
            {
                TimePeriod = new TimePeriod(500),
                AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default),
            };
            transitionGroup.AddTransition(slide);

            Page page = new ContentPage()
            {
                AppBar = new AppBar()
                {
                    Title = "Second Page",
                },
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
                Content = pageRoot,

                AppearingTransition = transitionGroup,
                DisappearingTransition = new SlideTransition()
                {
                    TimePeriod = new TimePeriod(500),
                    AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default),
                    Direction = SlideTransitionDirection.Left
                },
            };
            return page;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                Deactivate();
            }

            base.Dispose(type);
        }

        private void Deactivate()
        {
        }
    }

    class NavigatorTest4 : IExample
    {
        private Window window;

        public void Activate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            window.GetDefaultNavigator().Push(new NavigatorContentPage4(window));
        }

        public void Deactivate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            window.GetDefaultNavigator().Pop();
        }
    }
}
