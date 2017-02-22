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
using Dali;

namespace MyCSharpExample
{
  class Example
  {
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    delegate void CallbackDelegate(IntPtr data);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    delegate void ActorCallbackDelegate(IntPtr data);

    private Dali.Application _application;
    private ScrollView _scrollView;
    private ScrollBar _scrollBar;
    private Animation _animation;
    private TextLabel _text;

    public Example(Dali.Application application)
    {
      _application = application;
      _application.Initialized += Initialize;
    }


    public void Initialize(object source, NUIApplicationInitEventArgs e)
    {
      CreateScrollView();
    }

    private void CreateScrollView()
    {
      Stage stage = Stage.GetCurrent();
      stage.BackgroundColor = Color.White;

      // Create a scroll view
      _scrollView = new ScrollView();
      Size stageSize = stage.Size;
      _scrollView.Size = new Position(stageSize.W, stageSize.H, 0.0f);
      _scrollView.ParentOrigin = NDalic.ParentOriginCenter;
      _scrollView.AnchorPoint = NDalic.AnchorPointCenter;
      stage.Add(_scrollView);

      // Add actors to a scroll view with 3 pages
      int pageRows = 1;
      int pageColumns = 3;
      for(int pageRow = 0; pageRow < pageRows; pageRow++)
      {
        for(int pageColumn = 0; pageColumn < pageColumns; pageColumn++)
        {
          View pageActor = new View();
          pageActor.SetResizePolicy(ResizePolicyType.FILL_TO_PARENT, DimensionType.ALL_DIMENSIONS);
          pageActor.ParentOrigin = NDalic.ParentOriginCenter;
          pageActor.AnchorPoint = NDalic.AnchorPointCenter;
          pageActor.Position = new Position(pageColumn * stageSize.W, pageRow * stageSize.H, 0.0f);

          // Add images in a 3x4 grid layout for each page
          int imageRows = 4;
          int imageColumns = 3;
          float margin = 10.0f;
          Position imageSize = new Position((stageSize.W / imageColumns) - margin, (stageSize.H / imageRows) - margin, 0.0f);

          for(int row = 0; row < imageRows; row++)
          {
            for(int column = 0; column < imageColumns;column++)
            {
              int imageId = (row * imageColumns + column) % 2 + 1;
              ImageView imageView = new ImageView("images/image-" + imageId + ".jpg");
              imageView.ParentOrigin = NDalic.ParentOriginCenter;
              imageView.AnchorPoint = NDalic.AnchorPointCenter;
              imageView.Size = imageSize;
              imageView.Position = new Position( margin * 0.5f + (imageSize.X + margin) * column - stageSize.W * 0.5f + imageSize.X * 0.5f,
                  margin * 0.5f + (imageSize.Y + margin) * row - stageSize.H * 0.5f + imageSize.Y * 0.5f, 0.0f );
              pageActor.Add(imageView);
            }
          }

          _scrollView.Add(pageActor);
        }
      }

      _scrollView.SetAxisAutoLock(true);

      // Set scroll view to have 3 pages in X axis and allow page snapping,
      // and also disable scrolling in Y axis.
      RulerPtr scrollRulerX = new RulerPtr(new FixedRuler(stageSize.W));
      RulerPtr scrollRulerY = new RulerPtr(new DefaultRuler());
      scrollRulerX.SetDomain(new RulerDomain(0.0f, stageSize.W * pageColumns, true));
      scrollRulerY.Disable();
      _scrollView.SetRulerX(scrollRulerX);
      _scrollView.SetRulerY(scrollRulerY);

      // Create a horizontal scroll bar in the bottom of scroll view (which is optional)
      _scrollBar = new ScrollBar();
      _scrollBar.ParentOrigin = NDalic.ParentOriginBottomLeft;
      _scrollBar.AnchorPoint = NDalic.AnchorPointTopLeft;
      _scrollBar.SetResizePolicy(ResizePolicyType.FIT_TO_CHILDREN, DimensionType.WIDTH);
      _scrollBar.SetResizePolicy(ResizePolicyType.FILL_TO_PARENT, DimensionType.HEIGHT);
      _scrollBar.Orientation = new Quaternion( new Radian( new Degree( 270.0f ) ), Vector3.ZAXIS );
      _scrollBar.SetScrollDirection(ScrollBar.Direction.Horizontal);
      _scrollView.Add(_scrollBar);

      // Connect to the OnRelayout signal
      _scrollView.OnRelayoutEvent += OnScrollViewRelayout;
      _scrollView.Touched += OnTouch;
      _scrollView.WheelMoved += Onwheel;
      _scrollView.KeyInputFocusGained += OnKey;
      _text = new TextLabel("View Touch Event Handler Test");
      _text.ParentOrigin = NDalic.ParentOriginCenter;
      _text.AnchorPoint = NDalic.AnchorPointCenter;
      _text.HorizontalAlignment = "CENTER";
      _text.PointSize = 48.0f;

      _scrollView.Add(_text);
    }

    // Callback for _animation finished signal handling
    public void AnimationFinished(object sender, EventArgs e)
    {
      Console.WriteLine("Customized Animation Finished Event handler");
    }
    private void OnKey(object source, View.KeyInputFocusGainedEventArgs e)
    {
      Console.WriteLine("View Keyevent EVENT callback....");
    }

    private bool Onwheel(object source, View.WheelEventArgs e)
    {
      Console.WriteLine("View Wheel EVENT callback....");
      return true;
    }

    private bool OnTouch(object source, View.TouchEventArgs e)
    {
      Console.WriteLine("View TOUCH EVENT callback....");

      // Only animate the _text label when touch down happens
      if( e.Touch.GetState(0) == PointStateType.DOWN )
      {
        Console.WriteLine("Customized Stage Touch event handler");
        // Create a new _animation
        if( _animation )
        {
          _animation.Reset();
        }

        _animation = new Animation(1.0f); // 1 second of duration

        _animation.AnimateTo(new Property(_text, Actor.Property.ORIENTATION), new Property.Value(new Quaternion( new Radian( new Degree( 180.0f ) ), Vector3.XAXIS )), new AlphaFunction(AlphaFunction.BuiltinFunction.Linear), new TimePeriod(0.0f, 0.5f));
        _animation.AnimateTo(new Property(_text, Actor.Property.ORIENTATION), new Property.Value(new Quaternion( new Radian( new Degree( 0.0f ) ), Vector3.XAXIS )), new AlphaFunction(AlphaFunction.BuiltinFunction.Linear), new TimePeriod(0.5f, 0.5f));

        // Connect the signal callback for animaiton finished signal
        _animation.Finished += AnimationFinished;

        // Play the _animation
        _animation.Play();
      }
      return true;
    }

    private void OnScrollViewRelayout(object source, View.OnRelayoutEventArgs e)
    {
      Console.WriteLine("View OnRelayoutEventArgs EVENT callback....");

      // Set the correct scroll bar size after size negotiation of scroll view is done
      _scrollBar.Size = new Position(0.0f, _scrollView.GetRelayoutSize(DimensionType.WIDTH), 0.0f);
    }

    public void MainLoop()
    {
      _application.MainLoop ();
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
      static void Main(string[] args)
      {
        Example example = new Example(Application.NewApplication());
        example.MainLoop ();
      }
  }
}
