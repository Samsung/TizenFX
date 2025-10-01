using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Scene3D;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class Scene3DPanelTest : IExample
    {
        private Window window;
        private SceneView sceneView;
        private static readonly string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        private Color[] backFaceColors;
        private int colorIndex;
        private Animation animation;
        private Panel panel;
        private TextLabel guideText;
        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.White;
            Size2D windowSize = window.Size;

            backFaceColors = new Color[3];
            backFaceColors[0] = Color.Red;
            backFaceColors[1] = Color.Green;
            backFaceColors[2] = Color.Blue;

            colorIndex = 0;

            sceneView = new SceneView()
            {
                Size = new Size(windowSize.Width, windowSize.Height),
                PivotPoint = PivotPoint.Center,
                ParentOrigin = ParentOrigin.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.Beige,
                UseFramebuffer = true,
            };
            window.Add(sceneView);

            View parent = new View()
            {
                BackgroundColor = Color.Blue,
                PivotPoint = PivotPoint.Center,
                ParentOrigin = ParentOrigin.Center,
                PositionUsesPivotPoint = true,
                Size = new Size(100, 100),
            };

            View child = new View()
            {
                BackgroundColor = Color.Red,
                PivotPoint = PivotPoint.Center,
                ParentOrigin = ParentOrigin.Center,
                PositionUsesPivotPoint = true,
                Size = new Size(100, 100),
                Position = new Position(25, 100),
            };
            parent.Add(child);

            panel = new Panel()
            {
                Position = new Position(0.0f, 0.0f, 0.5f),
                Size = new Size(2.0f, 1.0f),
                PanelResolution = new Vector2(400, 500),
                Content = parent,
                BackFacePlaneColor = backFaceColors[colorIndex],
            };
            sceneView.Add(panel);

            SetGuide();

            animation = new Animation(15000);
            animation.AnimateTo(panel, "orientation", new Rotation(new Radian(new Degree(180.0f)), Vector3.YAxis));
            animation.AnimateTo(panel, "size", new Vector3(1.0f, 2.0f, 0.0f));
            animation.Looping = true;
            animation.LoopingMode = Animation.LoopingModes.AutoReverse;
            animation.Play();

            window.KeyEvent += WindowKeyEvent;
        }

        void SetGuide()
        {
            if(guideText == null)
            {
                guideText = new TextLabel()
                {
                    PositionUsesPivotPoint = true,
                    PivotPoint = PivotPoint.BottomLeft,
                    ParentOrigin = ParentOrigin.BottomLeft,
                    PointSize = 30.0f,
                    MultiLine = true,
                };
            }
            window.Add(guideText);

            string backFaceColor = string.Format($"({panel.BackFacePlaneColor.R}, {panel.BackFacePlaneColor.G}, {panel.BackFacePlaneColor.B})");
            string guide = string.Format($"Press 1 to convert transparency - Current value : {panel.Transparent}\nPress 2 to convert double sided - Current value : {panel.DoubleSided}\nPress 3 to convert back face - Current value : {panel.UsingBackFacePlane}\nPress 4 to convert back face color - Current value : {backFaceColor}\n");
            guideText.Text = guide;
        }

        private void WindowKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "1")
                {
                    panel.Transparent = !panel.Transparent;
                }
                else if (e.Key.KeyPressedName == "2")
                {
                    panel.DoubleSided = !panel.DoubleSided;
                }
                else if (e.Key.KeyPressedName == "3")
                {
                    panel.UsingBackFacePlane = !panel.UsingBackFacePlane;
                }
                else if (e.Key.KeyPressedName == "4")
                {
                    colorIndex = ((colorIndex + 1) % 3);
                    panel.BackFacePlaneColor = backFaceColors[colorIndex];
                }
                SetGuide();
            }
        }

        public void Deactivate()
        {
            window.KeyEvent -= WindowKeyEvent;
            sceneView?.DisposeRecursively();
        }
    }
}
