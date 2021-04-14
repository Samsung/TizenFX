using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class PageTransitionSample : IExample
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
        private readonly Vector4 ColorBackground = new Vector4(0.99f, 0.94f, 0.83f, 1.0f);

        private readonly Vector4[] TileColor = { new Color("#F5625D"), new Color("#7DFF83"), new Color("#7E72DF") };

        private readonly Vector2 baseSize = new Vector2(480.0f, 800.0f);
        private Vector2 contentSize;

        private float magnification;

        private float convertSize(float size)
        {
            return size * magnification;
        }


        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            Vector2 windowSize = new Vector2((float)(window.Size.Width), (float)(window.Size.Height));
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

            View mainRoot = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent
            };

            View layoutView = new View()
            {
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.BottomCenter,
                ParentOrigin = ParentOrigin.BottomCenter,
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

            mainPage = new ContentPage()
            {
                Content = mainRoot,
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
                }
            };

            totalGreyView.TouchEvent += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    navigator.PushWithTransition(totalPage);
                }
                return true;
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
                PivotPoint = PivotPoint.Center,
                ParentOrigin = ParentOrigin.Center,
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
                smallView.PivotPoint = PivotPoint.Center;
                smallView.ParentOrigin = ParentOrigin.Center;
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
                PivotPoint = PivotPoint.Center,
                ParentOrigin = ParentOrigin.Center,
                Size = new Size(convertSize(70), convertSize(70)),
                CornerRadius = convertSize(20),
                BackgroundColor = ColorGrey,
                TransitionOptions = new TransitionOptions()
                {
                    TransitionTag = totalGreyTag,
                }
            };
            sizeGreyView.Add(totalGreyReturnView);
            totalLayoutView.Add(sizeGreyView);

            totalGreyReturnView.TouchEvent += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    navigator.PopWithTransition();
                }
                return true;
            };

            totalPage = new ContentPage()
            {
                Content = totalPageRoot,
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
                },
            };

            View greyView = new View()
            {
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.Center,
                ParentOrigin = ParentOrigin.Center,
                Size = new Size(convertSize(40), convertSize(40)),
                CornerRadius = 0.45f,
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                BackgroundColor = ColorGrey,
                Orientation = new Rotation(new Radian(-(float)Math.PI / 2.0f), Vector3.ZAxis),
                TransitionOptions = new TransitionOptions()
                {
                    TransitionTag = greyTag,
                }
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
                PivotPoint = PivotPoint.TopCenter,
                ParentOrigin = ParentOrigin.TopCenter,
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
                PivotPoint = PivotPoint.BottomCenter,
                ParentOrigin = ParentOrigin.BottomCenter,
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
                    navigator.PopWithTransition();
                }
                return true;
            };
            pageRoot.Add(pageBackground);

            Page page = new ContentPage()
            {
                Content = pageRoot,
            };
            return page;
        }

        public void Deactivate()
        {
        }
    }
}
