using System;
using System.IO;
using System.Collections.Generic;

using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class LottieAnimationScaleTest : IExample
    {
        // Lottie images
        private string[] imagePaths = Directory.GetFiles(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "*.json");
        private uint imageIndex = 0;

        private LottieAnimationView[] mLottieView = new LottieAnimationView[4];
        private LottieAnimationView mEditableLottie;

        // UI components
        private Menu mPivotPointMenu;
        private Dictionary<Slider, float> mSliders;
        private Dictionary<string, Button> mButtons;


        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            window.Add(GetInitializedCanvas(window.Size));
            window.Add(GetInitializedSidePanel(window.Size));
        }

        public void Deactivate()
        {
        }

        private View GetInitializedCanvas(Size size)
        {
            const float scaleUp = 2.0f;

            View canvas = new View() {
                Size = size,
                BackgroundColor = Color.Black,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
            };

            canvas.Add(new TextLabel($"(Reference#left)   Scale {scaleUp} | RedrawInScalingUp(true) | RenderScale 1") {
                    TextColor = Color.White,
                    FontSizeScale = 0.5f,
                    ParentOrigin = ParentOrigin.TopCenter,
            });
            canvas.Add(new TextLabel($"(Reference#center) Scale {scaleUp} | RedrawInScalingUp(false) | RenderScale 1") {
                    TextColor = Color.White,
                    FontSizeScale = 0.5f,
                    ParentOrigin = ParentOrigin.TopCenter,
            });
            canvas.Add(new TextLabel($"(Reference#right)  Scale {scaleUp} | RedrawInScalingUp(false) | RenderScale {scaleUp}") {
                    TextColor = Color.White,
                    FontSizeScale = 0.5f,
                    ParentOrigin = ParentOrigin.TopCenter,
            });
            View referencePanel = new View() {
                ParentOrigin = ParentOrigin.TopCenter,
                SizeHeight = 200,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    CellPadding = new Size2D(100,100),
                },
            };
            canvas.Add(referencePanel);

            mLottieView[1] = new LottieAnimationView() {
                ResourceUrl = imagePaths[imageIndex],
                PivotPoint = PivotPoint.TopLeft,
                SizeWidth = 100,
                SizeHeight = 100,
                ScaleX = scaleUp,
                ScaleY = scaleUp,
                LoopCount = -1,
            };
            referencePanel.Add(mLottieView[1]);

            mLottieView[2] = new LottieAnimationView() {
                RedrawInScalingUp = false,
                ResourceUrl = imagePaths[imageIndex],
                PivotPoint = PivotPoint.TopLeft,
                SizeWidth = 100,
                SizeHeight = 100,
                ScaleX = scaleUp,
                ScaleY = scaleUp,
                LoopCount = -1,
            };
            referencePanel.Add(mLottieView[2]);

            mLottieView[3] = new LottieAnimationView() {
                RedrawInScalingUp = false,
                ResourceUrl = imagePaths[imageIndex],
                PivotPoint = PivotPoint.TopLeft,
                SizeWidth = 100,
                SizeHeight = 100,
                ScaleX = scaleUp,
                ScaleY = scaleUp,
                RenderScale = scaleUp,
                LoopCount = -1,
            };
            referencePanel.Add(mLottieView[3]);

            canvas.Add(new TextLabel("Edit this lottie:") {
                    TextColor = Color.White,
                    ParentOrigin = ParentOrigin.TopCenter,
            });
            mLottieView[0] = new LottieAnimationView() {
                ResourceUrl = imagePaths[imageIndex],
                PivotPoint = PivotPoint.TopLeft,
                ParentOrigin = ParentOrigin.TopCenter,
                SizeWidth = 100,
                SizeHeight = 100,
                RedrawInScalingUp = false,
                LoopCount = -1,
            };
            canvas.Add(mLottieView[0]);

            mEditableLottie = mLottieView[0];

            return canvas;
        }

        private View GetInitializedSidePanel(Size size)
        {
            View sidePanel = new View() {
                BackgroundColor = Color.Gray,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                SizeWidth = size.Width * 0.4f,
                ParentOrigin = ParentOrigin.TopLeft,
                Padding = new Extents(20,20,20,20),
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
            };

            mSliders = new Dictionary<Slider, float>();
            mButtons = new Dictionary<string, Button>();

            {
                sidePanel.Add(new TextLabel("Change Image") {});
                Button button = new Button() {
                    Text = imagePaths[imageIndex].Split('/')[^1],
                    Margin = new Extents(0,0,20,20),
                };
                mButtons["image"] = button;
                sidePanel.Add(button);

                button.Clicked += (o,e) => {

                    imageIndex = (imageIndex + 1) % (uint)(imagePaths.Length);

                    foreach(LottieAnimationView lottieView in mLottieView)
                    {
                        lottieView.ResourceUrl = imagePaths[imageIndex];
                    }

                    Button button = o as Button;
                    button.Text = imagePaths[imageIndex].Split('/')[^1];

                    // Reset UI
                    foreach(KeyValuePair<Slider, float> entry in mSliders)
                    {
                        entry.Key.CurrentValue = entry.Value;
                    }

                    if (mButtons.TryGetValue("animation", out Button animationButton))
                    {
                        animationButton.Text = "Play";
                    }
                };
            }
            {
                sidePanel.Add(new TextLabel("Play or Stop Animation") {});
                Button button = new Button() {
                    Text = "Play",
                    Margin = new Extents(0,0,20,20),
                };
                mButtons["animation"] = button;
                sidePanel.Add(button);
                button.Clicked += (o,e) => {

                    foreach(LottieAnimationView lottieView in mLottieView)
                    {
                        if (lottieView.PlayState == LottieAnimationView.PlayStateType.Stopped)
                        {
                            lottieView.Play();
                            button.Text = "Stop";
                        }
                        else
                        {
                            lottieView.Stop();
                            button.Text = "Play";
                        }
                    }
                };
            }
            {
                sidePanel.Add(new TextLabel("Change PivotPoint") {});

                string[] pivotPointNames = new string[] {
                    "TopLeft", "TopCenter", "TopRight",
                    "CenterLeft", "Center", "CenterRight",
                    "BottomLeft", "BottomCenter", "BottomRight"
                };
                Position[] pivotPoints = new Position[] {
                    PivotPoint.TopLeft, PivotPoint.TopCenter, PivotPoint.TopRight,
                    PivotPoint.CenterLeft, PivotPoint.Center, PivotPoint.CenterRight,
                    PivotPoint.BottomLeft, PivotPoint.BottomCenter, PivotPoint.BottomRight
                };
                MenuItem[] items = new MenuItem[9];
                for(int i = 0; i < items.Length; i++)
                {
                    items[i] = new MenuItem() { Text = pivotPointNames[i] };
                    items[i].SelectedChanged += (o,e) => {
                        if (e.IsSelected)
                        {
                            MenuItem item = o as MenuItem;
                            int j = Array.IndexOf(pivotPointNames, item.Text);
                            mEditableLottie.PivotPoint = pivotPoints[j];
                            mButtons["pivotPoint"].Text = pivotPointNames[j];
                        }
                        if (mPivotPointMenu) mPivotPointMenu.Dismiss();
                    };
                }

                Button button = new Button();
                button.Text = "TopLeft";
                button.Margin = new Extents(0,0,20,20);
                mButtons["pivotPoint"] = button;
                sidePanel.Add(button);
                button.Clicked += (o,e) => {
                    mPivotPointMenu = new Menu() {Items = items};
                    mPivotPointMenu.Post();
                };
            }
            {
                sidePanel.Add(new TextLabel("Size") {});
                Slider slider = new Slider()
                {
                    MinValue = 0.0f,
                    MaxValue = 500.0f,
                    CurrentValue = 100.0f,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    IsValueShown = true,
                };
                slider.ValueChanged += (o, e) =>
                {
                    mEditableLottie.SizeWidth = e.CurrentValue;
                    mEditableLottie.SizeHeight = e.CurrentValue;

                    Slider slider = o as Slider;
                    slider.ValueIndicatorText = e.CurrentValue.ToString("0.00");
                };
                sidePanel.Add(slider);
                mSliders[slider] = 100.0f;
            }
            {
                sidePanel.Add(new TextLabel("Scale") {});
                Slider slider = new Slider()
                {
                    MinValue = 0.0f,
                    MaxValue = 5.0f,
                    CurrentValue = 1.0f,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    IsValueShown = true,
                };
                slider.ValueChanged += (o, e) =>
                {
                    mEditableLottie.ScaleX = e.CurrentValue;
                    mEditableLottie.ScaleY = e.CurrentValue;

                    Slider slider = o as Slider;
                    slider.ValueIndicatorText = e.CurrentValue.ToString("0.00");
                };
                sidePanel.Add(slider);
                mSliders[slider] = 1.0f;
            }
            {
                sidePanel.Add(new TextLabel("RenderScale") {});
                Slider slider = new Slider()
                {
                    MinValue = 0.0f,
                    MaxValue = 5.0f,
                    CurrentValue = 1.0f,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    IsValueShown = true,
                };
                slider.ValueChanged += (o, e) =>
                {
                    mEditableLottie.RenderScale = e.CurrentValue;

                    Slider slider = o as Slider;
                    slider.ValueIndicatorText = e.CurrentValue.ToString("0.00");
                };
                sidePanel.Add(slider);
                mSliders[slider] = 1.0f;
            }
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = "RedrawInScalingUp";
                checkBox.SelectedChanged += (o, e) =>
                {
                    mEditableLottie.RedrawInScalingUp = e.IsSelected;
                };
                sidePanel.Add(checkBox);
            }
            return sidePanel;
        }
    }
}

