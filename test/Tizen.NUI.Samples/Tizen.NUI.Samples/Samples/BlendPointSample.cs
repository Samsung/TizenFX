using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System;

namespace Tizen.NUI.Samples
{
    public class BlendPointSample : IExample
    {
        // Layout base
        private Window window;
        private View root;
        private View header;
        private View contents;
        private View footer;

        private View layoutOriginRoot;
        private View layoutBlendRoot;

        private bool contentsLayoutVertical = true;

        // Animate Views
        private int viewSize = 50;
        private View viewOrigin;
        private View viewBlend;
        private Animation animationOrigin;
        private Animation animationBlend;

        // Animaiton properties controller
        private Slider sliderBlendPoint;
        private Slider sliderDuration;
        private TextLabel labelBlendPoint;
        private TextLabel labelDuration;
        private float blendPoint = 0.25f;
        private float duration = 5.0f;
        private bool requiredNewAnimationCreate = true;

        private Button buttonPlayStop;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();

            window.AddAvailableOrientation(Window.WindowOrientation.Portrait);
            window.AddAvailableOrientation(Window.WindowOrientation.Landscape);
            window.AddAvailableOrientation(Window.WindowOrientation.PortraitInverse);
            window.AddAvailableOrientation(Window.WindowOrientation.LandscapeInverse);

            window.Resized += (o, e) =>
            {
                DetermineContentsDirection();
            };

            CreateLayoutViews();
            CreateSlider();
            CreateButton();
            CreateAnimatableViews();

            contents.Relayout += (o, e) =>
            {
                requiredNewAnimationCreate = true;

                animationOrigin?.Stop();
                animationBlend?.Stop();
            };

            DetermineContentsDirection();

            window.Add(root);
        }

        public void Deactivate()
        {
            if (root != null)
            {
                window.Remove(root);
                root.DisposeRecursively();
            }

            animationOrigin?.Stop();
            animationOrigin?.Clear();
            animationOrigin?.Dispose();

            animationBlend?.Stop();
            animationBlend?.Clear();
            animationBlend?.Dispose();
        }

        // Layout relative codes
        private void DetermineContentsDirection()
        {
            Size2D windowSize = window.WindowSize;
            if(windowSize.Width < windowSize.Height)
            {
                if(!contentsLayoutVertical)
                {
                    ushort viewRootPadding = (ushort)(10 + viewSize / 2);
                    contentsLayoutVertical = true;
                    contents.Layout = new LinearLayout()
                    {
                        LinearOrientation = LinearLayout.Orientation.Vertical,
                        Padding = new Extents((ushort)viewRootPadding),
                        CellPadding = new Size2D(viewRootPadding, viewRootPadding),
                    };
                }
            }
            else
            {
                if(contentsLayoutVertical)
                {
                    ushort viewRootPadding = (ushort)(10 + viewSize / 2);
                    contentsLayoutVertical = false;
                    contents.Layout = new LinearLayout()
                    {
                        LinearOrientation = LinearLayout.Orientation.Horizontal,
                        Padding = new Extents((ushort)viewRootPadding),
                        CellPadding = new Size2D(viewRootPadding, viewRootPadding),
                    };
                }
            }
        }

        private void CreateLayoutViews()
        {
            root = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    Padding = new Extents(10, 10, 10, 10),
                },
            };

            header = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    Padding = new Extents(10, 10, 10, 10),
                },
            };


            int viewRootPadding = 10 + viewSize / 2;
            contentsLayoutVertical = true;
            contents = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    Padding = new Extents((ushort)viewRootPadding),
                    CellPadding = new Size2D(viewRootPadding, viewRootPadding),
                },
            };

            footer = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    Padding = new Extents(10, 10, 10, 10),
                },
            };

            root.Add(header);
            root.Add(contents);
            root.Add(footer);

            layoutOriginRoot = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BorderlineWidth = 4.0f,
            };
            layoutBlendRoot = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BorderlineWidth = 4.0f,
            };

            contents.Add(layoutOriginRoot);
            contents.Add(layoutBlendRoot);
        }

        private void CreateSlider()
        {
            labelBlendPoint = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Text = "Blend Point : " + blendPoint.ToString(),
            };
            sliderBlendPoint = new Slider()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                MinValue = 0.0f,
                MaxValue = 1.0f,
                CurrentValue = blendPoint,
            };
            sliderBlendPoint.ValueChanged += (o, e) =>
            {
                requiredNewAnimationCreate = true;
                animationOrigin?.Stop();
                animationBlend?.Stop();

                blendPoint = e.CurrentValue;
                labelBlendPoint.Text = "Blend Point : " + blendPoint.ToString();
            };

            header.Add(labelBlendPoint);
            header.Add(sliderBlendPoint);

            labelDuration = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Text = "Duration : " + duration.ToString() + " seconds",
            };
            sliderDuration = new Slider()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                MinValue = 0.0f,
                MaxValue = 10.0f,
                CurrentValue = duration,
            };
            sliderDuration.ValueChanged += (o, e) =>
            {
                requiredNewAnimationCreate = true;
                animationOrigin?.Stop();
                animationBlend?.Stop();

                duration = e.CurrentValue;
                labelDuration.Text = "Duration : " + duration.ToString() + " seconds";
            };

            header.Add(labelDuration);
            header.Add(sliderDuration);
        }

        private void CreateButton()
        {
            buttonPlayStop = new Button()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(10, 10, 10, 10),

                Text = "Play",
            };
            buttonPlayStop.Clicked += (o, e)=>
            {
                if(requiredNewAnimationCreate)
                {
                    RegenerateAnimation();
                    animationOrigin.Play();
                    animationBlend.Play();
                    buttonPlayStop.Text = "Stop";
                }
                else if(animationOrigin != null && animationBlend != null)
                {
                    if(animationOrigin.State == Animation.States.Playing)
                    {
                        animationOrigin.Stop();
                        animationBlend.Stop();
                        buttonPlayStop.Text = "Play";
                    }
                    else
                    {
                        animationOrigin.Play();
                        animationBlend.Play();
                        buttonPlayStop.Text = "Stop";
                    }
                }
                else
                {
                    buttonPlayStop.Text = "??? Bug!";
                }
            };

            header.Add(buttonPlayStop);
        }

        private void CreateAnimatableViews()
        {
            viewOrigin = CreateNewAnimatableView("O");
            viewBlend = CreateNewAnimatableView("B");

            layoutOriginRoot.Add(viewOrigin);
            layoutBlendRoot.Add(viewBlend);
        }

        private void RegenerateAnimation()
        {
            requiredNewAnimationCreate = false;

            animationOrigin?.Dispose();
            animationOrigin = null;
            animationBlend?.Dispose();
            animationBlend = null;

            Size originSize = layoutOriginRoot.Size;
            Size blendSize = layoutBlendRoot.Size;

            animationOrigin = CreateNewAnimation(viewOrigin, originSize, duration, 0.0f);
            animationBlend = CreateNewAnimation(viewBlend, blendSize, duration, blendPoint);
        }


        // Creation functions. It will be used when we are doing duplicated jobs
        private View CreateNewAnimatableView(string name)
        {
            View view = new TextLabel()
            {
                Text = name,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,

                Size2D = new Size2D(viewSize, viewSize),

                PositionUsesPivotPoint = true,
                PivotPoint = Position.PivotPointCenter,
                ParentOrigin = Position.ParentOriginCenter,

                BackgroundColor = Color.BlancheDalmond,
                BorderlineColor = Color.Blue,
                BorderlineWidth = 10.0f,
                BorderlineOffset = -1.0f,

                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                CornerRadius = new Vector4(0.5f, 0.5f, 0.0f, 0.5f),
            };
            return view;
        }
        private Animation CreateNewAnimation(View target, Size parentSize, float durationSeconds, float blendPoint)
        {
            Animation animation = new Animation((int)(durationSeconds * 1000.0f))
            {
                BlendPoint = blendPoint,
            };
            animation.Finished += (o, e) =>
            {
                // Reset to zero
                target.Position = new Position(0.0f, 0.0f);
                target.Orientation = new Rotation(new Radian(0.0f), Vector3.ZAxis);
                if(buttonPlayStop)
                {
                    buttonPlayStop.Text = "Play";
                }
            };

            KeyFrames positionKeyFrames = new KeyFrames();
            positionKeyFrames.Add(0.0f, new Vector3(-parentSize.Width * 0.5f, parentSize.Height * 0.5f, 0.0f));
            positionKeyFrames.Add(0.2f, new Vector3(parentSize.Width * 0.5f, parentSize.Height * 0.5f, 0.0f));
            positionKeyFrames.Add(0.25f, new Vector3(parentSize.Width * 0.5f, parentSize.Height * 0.5f, 0.0f));
            positionKeyFrames.Add(0.45f, new Vector3(parentSize.Width * 0.5f, -parentSize.Height * 0.5f, 0.0f));
            positionKeyFrames.Add(0.5f, new Vector3(parentSize.Width * 0.5f, -parentSize.Height * 0.5f, 0.0f));
            positionKeyFrames.Add(0.7f, new Vector3(-parentSize.Width * 0.5f, -parentSize.Height * 0.5f, 0.0f));
            positionKeyFrames.Add(0.75f, new Vector3(-parentSize.Width * 0.5f, -parentSize.Height * 0.5f, 0.0f));
            positionKeyFrames.Add(0.95f, new Vector3(-parentSize.Width * 0.5f, parentSize.Height * 0.5f, 0.0f));
            positionKeyFrames.Add(1.0f, new Vector3(-parentSize.Width * 0.5f, parentSize.Height * 0.5f, 0.0f));

            KeyFrames orientationKeyFrames = new KeyFrames();
            orientationKeyFrames.Add(0.0f, new Rotation(new Radian(new Degree(-45.0f)), Vector3.ZAxis));
            orientationKeyFrames.Add(0.2f, new Rotation(new Radian(new Degree(-45.0f)), Vector3.ZAxis));
            orientationKeyFrames.Add(0.25f, new Rotation(new Radian(new Degree(-135.0f)), Vector3.ZAxis));
            orientationKeyFrames.Add(0.45f, new Rotation(new Radian(new Degree(-135.0f)), Vector3.ZAxis));
            orientationKeyFrames.Add(0.5f, new Rotation(new Radian(new Degree(135.0f)), Vector3.ZAxis));
            orientationKeyFrames.Add(0.7f, new Rotation(new Radian(new Degree(135.0f)), Vector3.ZAxis));
            orientationKeyFrames.Add(0.75f, new Rotation(new Radian(new Degree(45.0f)), Vector3.ZAxis));
            orientationKeyFrames.Add(0.95f, new Rotation(new Radian(new Degree(45.0f)), Vector3.ZAxis));
            orientationKeyFrames.Add(1.0f, new Rotation(new Radian(new Degree(-45.0f)), Vector3.ZAxis));

            animation.AnimateBetween(target, "Position", positionKeyFrames);
            animation.AnimateBetween(target, "Orientation", orientationKeyFrames);

            return animation;
        }
    }
}
