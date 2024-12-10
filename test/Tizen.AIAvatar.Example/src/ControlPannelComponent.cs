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

using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Scene3D;
using Tizen.NUI.Components;

namespace AIAvatar
{
    public class UIControlPanel
    {
        private readonly Vector2 SceneViewPadding = new Vector2(0.0f, 0.0f);
        private ButtonStyle buttonStyle;
        private SliderStyle sliderStyle;

        private Window uiWindow;
        private AvatarScene mainScene;
        private View controlPannel;

        private TextField editor;

        private readonly float ControlPannelWidthScale = 0.25f;// Relative size of window width. windowSize.Width * 0.5f

        public event EventHandler OnExitButtonClicked;

        public void MakeControlPannel(Window uiWindow, AvatarScene mainScene)
        {
            this.uiWindow = uiWindow;
            this.mainScene = mainScene;

            if (controlPannel != null)
            {
                return;
            }

            InitializeButtonStyle();
            InitializeSliderStyle();

            controlPannel = new ScrollableBase()
            {
                BackgroundColor = new Color(0.85f, 0.85f, 0.85f, 0.25f),

                PivotPoint = PivotPoint.TopLeft,
                ParentOrigin = ParentOrigin.TopLeft,
                PositionUsesPivotPoint = true,
                //CornerRadius = 30.0f,
                Padding = new Extents(30, 30, 30, 30),

                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(10, 20),
                },
                HideScrollbar = false,
            };
            uiWindow.Add(controlPannel);

            // Make control buttons
            MakeControlPannelComponents();
        }

        public void ReizeUIPanel(View avatarScene)
        {
            var windowSize = uiWindow.Size;
            var layoutLTR = (windowSize.Width >= windowSize.Height);

            var sceneViewSize = new Vector2(0, 0);
            var sceneViewPosition = new Vector2(0, 0);
            var controlPannelSize = new Vector2(0, 0);
            var controlPannelPosition = new Vector2(0, 0);
            if (layoutLTR) // layout Left to Right
            {
                sceneViewSize = new Vector2(windowSize.Width - SceneViewPadding.X * 3.0f - ControlPannelWidthScale * windowSize.Width,
                                            windowSize.Height - SceneViewPadding.Y * 2.0f);
                sceneViewPosition = new Vector2(SceneViewPadding.X * 2.0f + ControlPannelWidthScale * windowSize.Width, SceneViewPadding.Y);
                controlPannelSize = new Vector2(ControlPannelWidthScale * windowSize.Width, windowSize.Height - SceneViewPadding.Y * 2.0f);
                controlPannelPosition = new Vector2(SceneViewPadding.X, SceneViewPadding.Y);
            }
            else // layout Top to Bottom
            {
                sceneViewSize = new Vector2(windowSize.Width - SceneViewPadding.X * 2.0f,
                                        windowSize.Height - SceneViewPadding.Y * 3.0f - ControlPannelWidthScale * windowSize.Height);
                sceneViewPosition = new Vector2(SceneViewPadding.X, SceneViewPadding.Y * 2.0f + ControlPannelWidthScale * windowSize.Height);
                controlPannelSize = new Vector2(windowSize.Width - SceneViewPadding.X * 2.0f, ControlPannelWidthScale * windowSize.Height);
                controlPannelPosition = new Vector2(SceneViewPadding.X, SceneViewPadding.Y);
            }

            // Update SceneView and ControlPannel size/position if we has.
            if (avatarScene != null)
            {
                avatarScene.SizeWidth = sceneViewSize.Width;
                avatarScene.SizeHeight = sceneViewSize.Height;
                avatarScene.PositionX = sceneViewPosition.X;
                avatarScene.PositionY = sceneViewPosition.Y;
            }

            if (controlPannel != null)
            {
                controlPannel.SizeWidth = controlPannelSize.Width;
                controlPannel.SizeHeight = controlPannelSize.Height;
                controlPannel.PositionX = controlPannelPosition.X;
                controlPannel.PositionY = controlPannelPosition.Y;
            }
        }

        private void InitializeButtonStyle()
        {
            buttonStyle = new ButtonStyle()
            {
                Size = new Size(252, 48),
                ItemSpacing = new Size2D(8, 8),
                CornerRadius = 12.0f,
                ItemHorizontalAlignment = HorizontalAlignment.Center,
                ItemVerticalAlignment = VerticalAlignment.Center,
                BorderlineWidth = 5.0f,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = Styles.BIG_TAG_FOCUS_BACKGROUND_COLOR1,
                    Pressed = Styles.BIG_TAG_NORMAL_BACKGROUND_COLOR1,
                    Focused = Styles.BIG_TAG_FOCUS_BACKGROUND_COLOR2,
                    Selected = Styles.BIG_TAG_NORMAL_BACKGROUND_COLOR1,
                    Disabled = new Color(0.792f, 0.792f, 0.792f, 1),
                },
                BorderlineColorSelector = new Selector<Color>()
                {
                    Normal = Styles.BIG_TAG_FOCUS_BACKGROUND_COLOR2,
                    Pressed = Styles.BIG_TAG_NORMAL_BACKGROUND_COLOR2,
                    Focused = Styles.BIG_TAG_FOCUS_BACKGROUND_COLOR1,
                    Selected = Styles.BIG_TAG_NORMAL_BACKGROUND_COLOR2,
                    Disabled = new Color(0.94f, 0.95f, 0.93f, 1.0f),
                },
                Text = new TextLabelStyle()
                {
                    TextColor = new Color("#0D0D0D"),
                    PixelSize = 24,
                },
            };
        }

        private void InitializeSliderStyle()
        {
            sliderStyle = new SliderStyle()
            {
                Size = new Size(850, 50),
                TrackThickness = 8,
                Track = new ImageViewStyle()
                {
                    Size = new Size(800, 8),
                    CornerRadius = 4.0f,
                    BackgroundColor = new Selector<Color>()
                    {
                        Normal = new Color(1.0f, 0.37f, 0.0f, 0.1f),
                        Disabled = new Color(1.0f, 0.37f, 0.0f, 0.1f),
                    },
                },
                Progress = new ImageViewStyle()
                {
                    Size = new Size(800, 8),
                    CornerRadius = 4.0f,
                    BackgroundColor = new Selector<Color>()
                    {
                        //Normal = new Color("#FF6200"),
                        Normal = Styles.BIG_TAG_FOCUS_BACKGROUND_COLOR2,
                        Disabled = new Color("#CACACA"),
                    },
                },
                Thumb = new ImageViewStyle()
                {
                    Size = new Size(24, 24),
                    BackgroundColor = new Selector<Color>()
                    {
                        Normal = Styles.BIG_TAG_FOCUS_BACKGROUND_COLOR1,
                        Pressed = Styles.BIG_TAG_NORMAL_BACKGROUND_COLOR1,
                        Focused = Styles.BIG_TAG_FOCUS_BACKGROUND_COLOR2,
                        Disabled = new Color(0.94f, 0.95f, 0.93f, 1.0f),
                    },
                    BorderlineWidth = 5.0f,
                    BorderlineColorSelector = new Selector<Color>()
                    {
                        Normal = Styles.BIG_TAG_FOCUS_BACKGROUND_COLOR2,
                        Pressed = Styles.BIG_TAG_NORMAL_BACKGROUND_COLOR2,
                        Focused = Styles.BIG_TAG_FOCUS_BACKGROUND_COLOR1,
                        Disabled = new Color(0.94f, 0.95f, 0.93f, 1.0f),
                    },
                    CornerRadius = new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
                    CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                },
                ValueIndicatorImage = new ImageViewStyle()
                {
                    Size = new Size(43, 40),
                    BorderlineWidth = 1.0f,
                    BorderlineColor = new Color("#FF6200"),
                    BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.0f),
                    CornerRadius = 12.0f,
                },
                ValueIndicatorText = new TextLabelStyle()
                {
                    SizeHeight = 24,
                    PixelSize = 16,
                    TextColor = new Color("#FF6200"),
                }
            };
        }

        private void MakeControlPannelComponents()
        {
            AddControlEditor();
            AddControlButton("ChangeAvatar", "button_avatar", mainScene.ChangeAvatar);
            AddControlButton("Random Animation", "button_bvh", mainScene.TriggerRandomBodyAnimation);
            AddControlButton("Multiple Face Animations", "button_bvh", mainScene.TriggerMultipleFacialAnimations);
            AddControlButton("Random Face Expression", "button_bvh", mainScene.TriggerExpressionAniatmion);
            AddControlButton("Lip Animation", "button_bvh", mainScene.TriggerLipSync);
            AddControlButton("Audio & LipSync", "button_bvh", mainScene.TriggerAudioLipSync);
            AddControlButton("Samsung AI (chat)", "button_avatar", mainScene.TriggerSamsungAIService);
            AddControlButton("Pause", "button_bvh", mainScene.TriggerPauseAnimations);
            AddControlButton("Stop", "button_bvh", mainScene.TriggerStopAnimations);
            AddControlButton("EyeBlink", "button_bvh", mainScene.TriggerEyeBlink);
            AddControlButton("Show/Hide", "button_bvh", mainScene.ShowHide);
            AddControlSlider("Camera FOV", "slider_camera_fov", 0.1f, 1.3f, mainScene.GetSelectedCamera().FieldOfView.ConvertToFloat(), mainScene.SetupSceneViewCameraFov);
            AddControlSlider("IBL intensity", "slider_ibl_factor", 0.1f, 0.8f, mainScene.IBLFactor, mainScene.SetupSceneViewIBLFactor);
            AddControlButton("Quit", "button_quit", Exit);
        }

        private void AddControlEditor()
        {
            editor = new TextField()
            {
                Text = Utils.TTSText,
                PlaceholderText = "Input Your Message",
                Name = "InputText",
                BackgroundColor = Color.White,
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            editor.TextChanged += (obj, e) => {
                Utils.TTSText = e.TextField.Text;
            };

            controlPannel.Add(editor);
        }

        private void AddControlButton(string buttonText, string buttonName, Action func)
        {
            var button = new Button(buttonStyle)
            {
                Text = buttonText,
                Name = buttonName,
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            button.Clicked += (o, e) =>
            {
                Button me = o as Button;
                if (me == null) return;

                func();
            };

            controlPannel.Add(button);
        }

        private Slider AddControlSlider(string sliderText, string sliderName, float minValue, float maxValue, float currentValue, Action<float> func)
        {
            var dummy = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(5, 0),
                },
            };
            var label = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Text = sliderText,
                FontSizeScale = 0.5f,
                Focusable = false,
                Weight = 0.2f,
                MultiLine = true,
            };
            dummy.Add(label);
            var slider = new Slider(sliderStyle)
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                MinValue = minValue,
                MaxValue = maxValue,
                CurrentValue = currentValue,
                Name = sliderName,
                Weight = 0.8f,
            };
            slider.ValueChanged += (o, e) =>
            {
                func(e.CurrentValue);
            };
            dummy.Add(slider);
            controlPannel.Add(dummy);

            return slider;
        }

        private void Exit()
        {
            OnExitButtonClicked?.Invoke(null, null);
        }
    }
}
