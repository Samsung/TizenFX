/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd.
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

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;

class VisualTestExample : NUIApplication
{
    const uint VIEW_COUNT = 1000;

    static string IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image/";
    readonly static string[] IMAGE_PATH =
    {
        IMAGE_DIR + "gallery-small-1.jpg",
    };

    Window mWindow;
    Vector2 mWindowSize;
    float mViewSize;

    TextLabel infoLabel;

    View rootView;

    ImageView dummyView;
    Animation dummyAnimation;

    int state = 0;

    private global::System.Random mRandom = new global::System.Random();

    private global::System.Collections.Generic.List<Tizen.NUI.Visuals.VisualBase> visuals = new();

    protected void CreateScene()
    {
        mWindow = Window.Instance;
        mWindow.BackgroundColor = Color.White;
        mWindowSize = mWindow.WindowSize;

        mViewSize = global::System.Math.Min(mWindowSize.X, mWindowSize.Y) / 10.0f;

        infoLabel = new TextLabel(
            $"VisualObject Test with {VIEW_COUNT} and 2 children. (ImageView + TextLabel)\n" +
            $"Press 1 key to start test with View. (ImageView + TextLabel)\n" +
            $"Press 2 key to start test with Visual. (ImageVisual + TextLabel)\n" +
            $"Press 3 key to start test with various Visuals. (ColorVisual + ImageVisual + TextVisual + BorderVisual)\n" +
            $"Press 4 key to animate the size of View.\n" +
            $"(View size : {mViewSize})\n")
        {
            MultiLine = true,
            PointSize = 20.0f,
        };

        // For image cache.
        dummyView = new ImageView()
        {
            ResourceUrl = IMAGE_PATH[0],
            SizeWidth = 1.0f,
            SizeHeight = 1.0f,
        };

        // For keep rendering forever
        dummyAnimation = new Animation(1000);
        dummyAnimation.AnimateTo(dummyView, "PositionX", 1.0f);
        dummyAnimation.Looping = true;
        dummyAnimation.Play();

        rootView = new View()
        {
            SizeWidth = mWindowSize.X,
            SizeHeight = mWindowSize.Y,
            BackgroundColor = Color.White,
        };
        mWindow.Add(dummyView);
        mWindow.Add(rootView);

        mWindow.GetOverlayLayer().Add(infoLabel);

        mWindow.KeyEvent += OnKeyEvent;
    }

    void NormalViewTest()
    {
        global::System.DateTime startTime;
        global::System.DateTime endTime;

        startTime = global::System.DateTime.Now;

        for(int i = 0; i < VIEW_COUNT; i++)
        {
            View view = new View()
            {
                SizeWidth = mViewSize,
                SizeHeight = mViewSize,
                PositionX = (mRandom.Next()%1000 / 999.0f) * (mWindowSize.X - mViewSize),
                PositionY = (mRandom.Next()%1000 / 999.0f) * (mWindowSize.Y - mViewSize),
            };
            CreateNormalView(ref view);
            rootView.Add(view);
        }

        endTime = global::System.DateTime.Now;

        Tizen.Log.Error("NUI.Visuals", $"NormalViewTest : {(endTime - startTime).TotalMilliseconds} ms\n");
    }

    void VisualViewTest()
    {
        global::System.DateTime startTime;
        global::System.DateTime endTime;

        startTime = global::System.DateTime.Now;

        for(int i = 0; i < VIEW_COUNT; i++)
        {
            View view = new View()
            {
                SizeWidth = mViewSize,
                SizeHeight = mViewSize,
                PositionX = (mRandom.Next()%1000 / 999.0f) * (mWindowSize.X - mViewSize),
                PositionY = (mRandom.Next()%1000 / 999.0f) * (mWindowSize.Y - mViewSize),
            };
            CreateVisualView(ref view);
            rootView.Add(view);
        }

        endTime = global::System.DateTime.Now;

        Tizen.Log.Error("NUI.Visuals", $"VisualViewTest : {(endTime - startTime).TotalMilliseconds} ms\n");
    }

    void GeneralVisualTest()
    {
        global::System.DateTime startTime;
        global::System.DateTime endTime;

        startTime = global::System.DateTime.Now;

        for(int i = 0; i < VIEW_COUNT; i++)
        {
            View view = new View()
            {
                SizeWidth = mViewSize,
                SizeHeight = mViewSize,
                PositionX = (mRandom.Next()%1000 / 999.0f) * (mWindowSize.X - mViewSize),
                PositionY = (mRandom.Next()%1000 / 999.0f) * (mWindowSize.Y - mViewSize),
            };
            CreateGeneralVisualView(ref view);
            rootView.Add(view);
        }

        endTime = global::System.DateTime.Now;

        Tizen.Log.Error("NUI.Visuals", $"GeneralVisualTest : {(endTime - startTime).TotalMilliseconds} ms\n");
    }


    void OnKeyEvent(object source, Window.KeyEventArgs e)
    {
        if (e.Key.State == Key.StateType.Down)
        {
            switch(e.Key.KeyPressedName)
            {
                case "Escape":
                case "Back":
                case "XF86Back":
                {
                    if(state == 0)
                    {
                        Deactivate();
                        Exit();
                    }
                    else
                    {
                        state = 0;
                        viewWidthChangeAnimation?.Stop();
                        viewWidthChangeAnimation?.Clear();
                        viewWidthChangeAnimation?.Dispose();
                        viewWidthChangeAnimation = null;

                        rootView?.Unparent();
                        rootView?.DisposeRecursively();
                        foreach (var visual in visuals)
                        {
                            visual?.Dispose();
                        }
                        visuals.Clear();
                        rootView = new View()
                        {
                            SizeWidth = mWindowSize.X,
                            SizeHeight = mWindowSize.Y,
                            BackgroundColor = Color.White,
                        };
                        mWindow.Add(rootView);
                        FullGC();
                        FullGC();
                    }
                    break;
                }
                case "1":
                {
                    if(state == 0)
                    {
                        state = 1;
                        NormalViewTest();
                    }
                    break;
                }
                case "2":
                {
                    if(state == 0)
                    {
                        state = 2;
                        VisualViewTest();
                    }
                    break;
                }
                case "3":
                {
                    if(state == 0)
                    {
                        state = 3;
                        GeneralVisualTest();
                    }
                    break;
                }
                case "4":
                {
                    if(state != 0)
                    {
                        ViewSizeChangeTest();
                    }
                    break;
                }
                default:
                {
                    FullGC();
                    FullGC();
                    break;
                }
            }
        }
    }

    public void Activate()
    {
        CreateScene();
    }
    public void FullGC()
    {
        global::System.GC.Collect();
        global::System.GC.WaitForPendingFinalizers();
        global::System.GC.Collect();
    }

    public void Deactivate()
    {
        DestroyScene();
    }

    private void DestroyScene()
    {
        rootView?.Unparent();
        rootView?.Dispose();
    }

    private Animation viewWidthChangeAnimation = null;
    private void ViewSizeChangeTest()
    {
        viewWidthChangeAnimation?.Stop();
        viewWidthChangeAnimation?.Clear();
        viewWidthChangeAnimation?.Dispose();
        viewWidthChangeAnimation = new Animation(3000);
        for(int i = 0; i < VIEW_COUNT; i++)
        {
            View view = rootView.GetChildAt((uint)i);

            if(view == null)break;

            viewWidthChangeAnimation.AnimateTo(view, "SizeWidth", mViewSize * 2.0f, 0, 1000);
            viewWidthChangeAnimation.AnimateTo(view, "SizeWidth", mViewSize * 0.0f, 1000, 2000);
            viewWidthChangeAnimation.AnimateTo(view, "SizeWidth", mViewSize * 1.0f, 2000, 3000);
        }

        viewWidthChangeAnimation.Play();
    }

    private void CreateNormalView(ref View view)
    {
        // ImageView with corner radius top.
        ImageView imageView = new ImageView()
        {
            ResourceUrl = IMAGE_PATH[0],
            CornerRadius = new Vector4(0.15f, 0.15f, 0.15f, 0.15f),
            CornerRadiusPolicy = VisualTransformPolicyType.Relative,

            SizeWidth = mViewSize,
            SizeHeight = mViewSize,
        };

        TextLabel textLabel = new TextLabel()
        {
            Text = "1",
            PointSize = 20.0f,

            SizeWidth = mViewSize,
            SizeHeight = mViewSize,

            PositionY = mViewSize * 0.25f,
            PositionX = mViewSize * 0.5f,

            ParentOrigin = Position.ParentOriginCenter,
            PivotPoint = Position.PivotPointCenter,
            PositionUsesPivotPoint = true,
        };

        view.Add(imageView);
        view.Add(textLabel);
    }

    private void CreateVisualView(ref View view)
    {
        // ImageView with corner radius top.
        Tizen.NUI.Visuals.ImageVisual imageVisual = new Tizen.NUI.Visuals.ImageVisual()
        {
            ResourceUrl = IMAGE_PATH[0],
            CornerRadius = new Vector4(0.15f, 0.15f, 0.15f, 0.15f),
            CornerRadiusPolicy = VisualTransformPolicyType.Relative,

            Width = mViewSize,
            Height = mViewSize,

            WidthPolicy = VisualTransformPolicyType.Absolute,
            HeightPolicy = VisualTransformPolicyType.Absolute,
        };
        visuals.Add(imageVisual);

        /*
        Tizen.NUI.Visuals.TextVisual textVisual = new Tizen.NUI.Visuals.TextVisual()
        {
            Text = "1",
            PointSize = 20.0f,

            Width = mViewSize,
            Height = mViewSize,

            OffsetY = mViewSize * 0.25f,

            Origin = Visual.AlignType.Center,
            PivotPoint = Visual.AlignType.Center,

            WidthPolicy = VisualTransformPolicyType.Absolute,
            HeightPolicy = VisualTransformPolicyType.Absolute,
            OffsetYPolicy = VisualTransformPolicyType.Absolute,
        };
        */

        view.AddVisual(imageVisual, ViewVisualContainerRange.Content);
        //view.AddVisual(textVisual, ViewVisualContainerRange.Content);

        TextLabel textLabel = new TextLabel()
        {
            Text = "1",
            PointSize = 20.0f,

            SizeWidth = mViewSize,
            SizeHeight = mViewSize,

            PositionY = mViewSize * 0.25f,
            PositionX = mViewSize * 0.5f,

            ParentOrigin = Position.ParentOriginCenter,
            PivotPoint = Position.PivotPointCenter,
            PositionUsesPivotPoint = true,
        };
        view.Add(textLabel);
    }

    private void CreateGeneralVisualView(ref View view)
    {
        #region ColorVisual
        Tizen.NUI.Visuals.ColorVisual colorVisual = new Tizen.NUI.Visuals.ColorVisual()
        {
            Color = new Color(1.0f, 0.0f, 0.0f, 0.9f),
            CornerRadius = new Vector4(0.15f, 0.15f, 0.15f, 0.15f),
            CornerRadiusPolicy = VisualTransformPolicyType.Relative,

            Width = 1.1f,
            Height = 1.1f,

            BlurRadius = mViewSize * 0.05f,
            OffsetX = 0.1f,
            OffsetY = 0.05f,

            ExtraWidth = mViewSize * 0.15f,
            ExtraHeight = -mViewSize * 0.05f,
        };
        visuals.Add(colorVisual);
        view.AddVisual(colorVisual, ViewVisualContainerRange.Content);
        #endregion

        #region ImageVisual
        Tizen.NUI.Visuals.ImageVisual imageVisual = new Tizen.NUI.Visuals.ImageVisual()
        {
            ResourceUrl = IMAGE_PATH[0],
            CornerRadius = new Vector4(0.15f, 0.15f, 0.15f, 0.15f),
            CornerRadiusPolicy = VisualTransformPolicyType.Relative,
            BorderlineWidth = mViewSize * 0.05f,
            BorderlineColor = Color.Green,
            BorderlineOffset = 1.0f,

            Width = mViewSize,
            Height = mViewSize,

            WidthPolicy = VisualTransformPolicyType.Absolute,
            HeightPolicy = VisualTransformPolicyType.Absolute,
        };
        visuals.Add(imageVisual);
        view.AddVisual(imageVisual, ViewVisualContainerRange.Content);
        #endregion

        #region TextVisual
        Tizen.NUI.Visuals.TextVisual textVisual = new Tizen.NUI.Visuals.TextVisual()
        {
            Text = "1",
            PointSize = 20.0f,

            Width = mViewSize,
            Height = mViewSize,

            OffsetY = mViewSize * 0.25f,

            Origin = Visual.AlignType.Center,
            PivotPoint = Visual.AlignType.Center,

            WidthPolicy = VisualTransformPolicyType.Absolute,
            HeightPolicy = VisualTransformPolicyType.Absolute,
            OffsetYPolicy = VisualTransformPolicyType.Absolute,
        };
        visuals.Add(textVisual);
        view.AddVisual(textVisual, ViewVisualContainerRange.Content);
        #endregion

        #region BorderVisual
        Tizen.NUI.Visuals.BorderVisual borderVisual = new Tizen.NUI.Visuals.BorderVisual()
        {
            BorderColor = Color.Blue,
            BorderWidth = mViewSize * 0.05f,
            AntiAliasing = false, // For speed up
        };
        visuals.Add(borderVisual);
        view.AddVisual(borderVisual, ViewVisualContainerRange.Content);
        #endregion
    }

    protected override void OnCreate()
    {
        // Up call to the Base class first
        base.OnCreate();
        Activate();
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [global::System.STAThread] // Forces app to use one thread to access NUI
    static void Main(string[] args)
    {
        VisualTestExample example = new VisualTestExample();
        example.Run(args);
    }
}
