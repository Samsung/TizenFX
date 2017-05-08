/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;

namespace ScrollViewTest
{
  class Example : NUIApplication
  {
    private const string resources = "/home/owner/apps_rw/NUISamples.TizenTV/res";

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    delegate void CallbackDelegate(IntPtr data);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    delegate void ActorCallbackDelegate(IntPtr data);

    private ScrollView _scrollView;
    private ScrollBar _scrollBar;
    private Animation _animation;
    private TextLabel _text;

    public Example() : base()
    {
    }

    public Example(string stylesheet) : base(stylesheet)
    {
    }

    public Example(string stylesheet, WindowMode windowMode) : base(stylesheet, windowMode)
    {
    }

    protected override void OnCreate()
    {
        base.OnCreate();
        Initialize();
    }

    public void Initialize()
    {
      CreateScrollView();
    }

    private void CreateScrollView()
    {
      Window window = Window.Instance;
      window.BackgroundColor = Color.White;

      // Create a scroll view
      _scrollView = new ScrollView();
      Size windowSize = new Size(window.Size.Width, window.Size.Height, 0.0f);
      _scrollView.Size = new Size(windowSize.Width, windowSize.Height, 0.0f);
      _scrollView.ParentOrigin = ParentOrigin.Center;
      _scrollView.AnchorPoint = AnchorPoint.Center;
      window.GetDefaultLayer().Add(_scrollView);

      // Add actors to a scroll view with 3 pages
      int pageRows = 1;
      int pageColumns = 3;
      for(int pageRow = 0; pageRow < pageRows; pageRow++)
      {
        for(int pageColumn = 0; pageColumn < pageColumns; pageColumn++)
        {
          View pageActor = new View();
          pageActor.WidthResizePolicy = ResizePolicyType.FillToParent;
          pageActor.HeightResizePolicy = ResizePolicyType.FillToParent;
          pageActor.ParentOrigin = ParentOrigin.Center;
          pageActor.AnchorPoint = AnchorPoint.Center;
          pageActor.Position = new Position(pageColumn * windowSize.Width, pageRow * windowSize.Height, 0.0f);

          // Add images in a 3x4 grid layout for each page
          int imageRows = 4;
          int imageColumns = 3;
          float margin = 10.0f;
          Position imageSize = new Position((windowSize.Width / imageColumns) - margin, (windowSize.Height / imageRows) - margin, 0.0f);

          for(int row = 0; row < imageRows; row++)
          {
            for(int column = 0; column < imageColumns;column++)
            {
              int imageId = (row * imageColumns + column) % 2 + 1;
              ImageView imageView = new ImageView(resources+"/images/image-" + imageId + ".jpg");
              imageView.ParentOrigin = ParentOrigin.Center;
              imageView.AnchorPoint = AnchorPoint.Center;
              imageView.Size = new Size(imageSize.X, imageSize.Y, imageSize.Z);
              imageView.Position = new Position( margin * 0.5f + (imageSize.X + margin) * column - windowSize.Width * 0.5f + imageSize.X * 0.5f,
                  margin * 0.5f + (imageSize.Y + margin) * row - windowSize.Height * 0.5f + imageSize.Y * 0.5f, 0.0f );
              pageActor.Add(imageView);
            }
          }

          _scrollView.Add(pageActor);
        }
      }

      _scrollView.SetAxisAutoLock(true);

      // Set scroll view to have 3 pages in X axis and allow page snapping,
      // and also disable scrolling in Y axis.
      RulerPtr scrollRulerX = new RulerPtr(new FixedRuler(windowSize.Width));
      RulerPtr scrollRulerY = new RulerPtr(new DefaultRuler());
      scrollRulerX.SetDomain(new RulerDomain(0.0f, windowSize.Width * pageColumns, true));
      scrollRulerY.Disable();
      _scrollView.SetRulerX(scrollRulerX);
      _scrollView.SetRulerY(scrollRulerY);

      // Create a horizontal scroll bar in the bottom of scroll view (which is optional)
      _scrollBar = new ScrollBar(ScrollBar.Direction.Horizontal);
      _scrollBar.ParentOrigin = ParentOrigin.BottomLeft;
      _scrollBar.AnchorPoint = AnchorPoint.TopLeft;
      _scrollBar.WidthResizePolicy = ResizePolicyType.FitToChildren;
      _scrollBar.HeightResizePolicy = ResizePolicyType.FillToParent;
      _scrollBar.Orientation = new Rotation( new Radian( new Degree( 270.0f ) ), Vector3.ZAxis );
      _scrollView.Add(_scrollBar);

      // Connect to the OnRelayout signal
      _scrollView.OnRelayoutEvent += OnScrollViewRelayout;
      //_scrollView.Touched += OnTouch;
      _scrollView.WheelMoved += Onwheel;
      _scrollView.FocusGained += OnKey;
      _text = new TextLabel("View Touch Event Handler Test");
      _text.ParentOrigin = ParentOrigin.Center;
      _text.AnchorPoint = AnchorPoint.Center;
      _text.HorizontalAlignment = HorizontalAlignment.Center;
            _text.PointSize = 20.0f;

      _scrollView.Add(_text);
    }

    // Callback for _animation finished signal handling
    public void AnimationFinished(object sender, EventArgs e)
    {
      Tizen.Log.Debug("NUI", "Customized Animation Finished Event handler");
    }
    private void OnKey(object source, EventArgs e)
    {
      Tizen.Log.Debug("NUI", "View Keyevent EVENT callback....");
    }

    private bool Onwheel(object source, View.WheelEventArgs e)
    {
      Tizen.Log.Debug("NUI", "View Wheel EVENT callback....");
      return true;
    }

    private bool OnTouch(object source, View.TouchEventArgs e)
    {
      Tizen.Log.Debug("NUI", "View TOUCH EVENT callback....");

      // Only animate the _text label when touch down happens
      if( e.Touch.GetState(0) == PointStateType.Down )
      {
        Tizen.Log.Debug("NUI", "Customized Window Touch event handler");
        // Create a new _animation
        if( _animation )
        {
          _animation.Reset();
        }

        _animation = new Animation(1); // 1 second of duration

        _animation.AnimateTo(_text, "Orientation", new Rotation( new Radian( new Degree( 180.0f ) ), Vector3.XAxis ), 0, 500);
        _animation.AnimateTo(_text, "Orientation", new Rotation( new Radian( new Degree( 0.0f ) ), Vector3.XAxis ), 500, 1000);

        // Connect the signal callback for animaiton finished signal
        _animation.Finished += AnimationFinished;

        // Play the _animation
        _animation.Play();
      }
      return true;
    }

    private void OnScrollViewRelayout(object source, EventArgs e)
    {
      Tizen.Log.Debug("NUI", "View OnRelayoutEventArgs EVENT callback....");

      // Set the correct scroll bar size after size negotiation of scroll view is done
      _scrollBar.Size = new Size(0.0f, _scrollView.GetRelayoutSize(DimensionType.Width), 0.0f);
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
      static void _Main(string[] args)
      {
        Example example = new Example();
        example.Run(args);
      }
  }
}
