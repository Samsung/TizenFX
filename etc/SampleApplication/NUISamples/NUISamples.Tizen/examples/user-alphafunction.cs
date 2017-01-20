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
using NUI;
using NUI.Constants;

namespace MyCSharpExample
{
  class Example
  {
    private Application _application;
    private Animation _animation;
    private TextLabel _text;
    private View _view1, _view2, _view3;
    private PushButton _pButton, _pButton2;
    private UserAlphaFunctionDelegate _user_alpha_func;
    private int myCount;
    private int myCount2;
    private bool _isAnimationFinished = true;

    public static void Log(string str)
    {
      Console.WriteLine("[DALI C# SAMPLE] " + str);
    }

    public Example(Application application)
    {
      _application = application;
      _application.Initialized += Initialize;
    }

    // Declare user alpha function delegate
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    delegate float UserAlphaFunctionDelegate(float progress);

    public void Initialize(object source, EventArgs e)
    {
      Log("Initialize() is called!");
      Stage stage = Stage.GetCurrent();
      stage.BackgroundColor = Color.White;
      stage.TouchEvent += OnStageTouched;
      stage.TouchEvent += OnStageTouched2;
      stage.WheelEvent += OnStageWheelEvent;
      stage.EventProcessingFinished += OnEventProcessingFinished;
      stage.KeyEvent += OnKeyEvent;
      stage.ContextLost += OnContextLost;
      stage.ContextRegained += OnContextRegained;
      stage.SceneCreated += OnSceneCreated;

      //Add push button
      _pButton = new PushButton();
      _pButton.ParentOrigin = ParentOrigin.TopLeft;
      _pButton.AnchorPoint = AnchorPoint.TopLeft;
      _pButton.LabelText = "Start Animation";
      _pButton.Position = new Size3D(0.0f, stage.Size.Height * 0.1f, 0.0f);
      _pButton.Clicked += OnPushButtonClicked1;
      stage.Add(_pButton);

      //Add push button
      _pButton2 = new PushButton();
      _pButton2.ParentOrigin = ParentOrigin.TopLeft;
      _pButton2.AnchorPoint = AnchorPoint.TopLeft;
      _pButton2.LabelText = "Stop Animation";
      _pButton2.Position = new Size3D(0.0f, stage.Size.Height * 0.2f, 0.0f);
      _pButton2.Clicked += OnPushButtonClicked2;
      stage.Add(_pButton2);

      // Add a _text label to the stage
      _text = new TextLabel("Hello Mono World");
      _text.ParentOrigin = ParentOrigin.BottomCenter;
      _text.AnchorPoint = AnchorPoint.BottomCenter;
      _text.HorizontalAlignment = "CENTER";
      _text.PointSize = 32.0f;
      stage.Add(_text);

      _view1 = new View();
      _view1.Size = new Vector3(200.0f, 200.0f, 0.0f);
      _view1.BackgroundColor = Color.Green;
      _view1.ParentOrigin = ParentOrigin.Center;
      _view1.AnchorPoint = AnchorPoint.Center;
      _view1.SetResizePolicy(ResizePolicyType.FIXED, DimensionType.ALL_DIMENSIONS);
      _view1.OnStageEvent += OnStage;
      _view1.KeyPressed += OnViewKeyPressed;
      Console.WriteLine("StateFocusEnable =" + _view1.StateFocusEnable);
      _view1.StateFocusEnable = true;
      stage.Add(_view1);

      _view2 = new View();
      _view2.BackgroundColor = Color.Red;
      _view2.Size = new Vector3(50.0f, 50.0f, 0.0f);
      _view2.ParentOrigin = ParentOrigin.TopLeft;
      _view2.AnchorPoint = AnchorPoint.TopLeft;
      _view2.SetResizePolicy(ResizePolicyType.FIXED, DimensionType.ALL_DIMENSIONS);
      _view2.Hovered +=OnViewHovered;
      _view1.Add(_view2);

      _view3 = new View();
      _view3.BackgroundColor = Color.Blue;
      _view3.Size = new Vector3(50.0f, 50.0f, 0.0f);
      _view3.ParentOrigin = ParentOrigin.TopLeft;
      _view3.AnchorPoint = AnchorPoint.TopLeft;
      _view3.SetResizePolicy(ResizePolicyType.FIXED, DimensionType.ALL_DIMENSIONS);
      _view1.Add(_view3);

      _user_alpha_func = new UserAlphaFunctionDelegate(body);

      MyAnimating();
    }

    // User defines alpha function as custom alpha function
    // Important Notification : when this custom alpha-function is implemented,
    // the other function call nor other data excess is prevented.
    // this method must be implemented to calculate the values of input and output purely.
    // unless, this will cause application crash.
    float body(float progress)
    {
      if (progress > 0.2f && progress< 0.7f)
      {
        return progress + 0.8f;
      }
      return progress;
    }

    // Callback for _animation finished signal handling
    public void AnimationFinished(object sender, EventArgs e)
    {
        Log("AnimationFinished() is called!");
        _isAnimationFinished = true;
        myCount = 0;
    }

    public void MyAnimating()
    {
      // Create a new _animation
      if (_isAnimationFinished == true)
      {
        if(_animation)
        {
          _animation.Clear();
          _animation.Reset();
        }
      }
      else
      {
        return;
      }

      _animation = new Animation(10000); // 10000 milli-second of duration
      _animation.StartTime = 0;
      _animation.EndTime = 10000;
      _animation.TargetProperty = "Position";
      _animation.AlphaFunction = new AlphaFunction(_user_alpha_func);
      _animation.Destination = new Vector3(150.0f, 150.0f, 0.0f);
      _animation.AnimateTo(_view2);
      // Connect the signal callback for animaiton finished signal
      _animation.Finished += AnimationFinished;
      _animation.EndAction = Animation.EndActions.StopFinal;
      // Play the _animation
      _animation.Play();
      _isAnimationFinished = false;
    }

    // Callback for stage touched signal handling
    public void OnStageTouched(object source, Stage.TouchEventArgs e)
    {
      TouchData _tdata = e.TouchData;

      Log("OnStageTouched() is called!GetTime=" + _tdata.GetTime() + " GetPointCount=" + _tdata.GetPointCount() + " GetState=" + _tdata.GetState(0) );
    }

    // Callback for stage touched signal handling
    public void OnStageTouched2(object source, Stage.TouchEventArgs e)
    {
      TouchData _tdata = e.TouchData;

      Log("OnStageTouched2() is called!GetTime="+ _tdata.GetTime() + " GetScreenPosition.X=" + _tdata.GetScreenPosition(0).X + " GetScreenPosition.Y=" + _tdata.GetScreenPosition(0).Y);
    }

    public void OnEventProcessingFinished(object sender, EventArgs e)
	{
      if (myCount % 20 == 0)
      {
        Log("OnEventProcessingFinished() is called!" + myCount + "times!");
      }
      myCount++;
    }

    public void OnStageWheelEvent(object source, Stage.WheelEventArgs e)
    {
      Log("OnStageWheelEvent() is called!");
      Log("OnStageWheelEvent() is called!direction="+ e.WheelEvent.direction + " timeStamp=" + e.WheelEvent.timeStamp );
    }

    public void OnKeyEvent(object source, Stage.KeyEventArgs e)
    {
      KeyEvent _kevent = e.KeyEvent;

      Log("OnKeyEvent() is called!keyPressedName="+ _kevent.keyPressedName + " time=" + _kevent.time + " state=" + _kevent.state);
    }

    public void OnContextLost(object sender, EventArgs e)
    {
      Log("OnContextLost() is called!");
    }

    public void OnContextRegained(object sender, EventArgs e)
    {
      Log("OnContextRegained() is called!");
    }

    public void OnSceneCreated(object sender, EventArgs e)
    {
      Log("OnSceneCreated() is called!");
    }

    public void OnStage(object source , EventArgs e)
	{
      Log("OnStage() is called!");
	}

    public bool OnViewKeyPressed(object sender, View.KeyEventArgs e)
    {
      KeyEvent _kevent = e.KeyEvent;

      Log("OnViewKeyPressed() is called!keyPressedName="+ _kevent.keyPressedName + " time=" + _kevent.time + " state=" + _kevent.state);
      return true;
    }

    public bool OnViewHovered(object sender, View.HoverEventArgs e)
    {
      HoverEvent _hevent = e.HoverEvent;

      Log("OnViewHovered() is called!GetPointCount()="+ _hevent.GetPointCount() + " time=" + _hevent.time + " state=" + _hevent.GetPoint(0).state);
      return true;
    }

    public bool OnPushButtonClicked1(object sender, EventArgs e)
    {
      Log("OnPushButtonClicked1() is called!");
      MyAnimating();
      return true;
    }

    public bool OnPushButtonClicked2(object sender, EventArgs e)
    {
      Log("OnPushButtonClicked2() is called!");
      _animation.Stop(Animation.EndActions.Discard);
      return true;
    }	

    public void MainLoop()
    {
      _application.MainLoop ();
    }

    [STAThread]
    static void Main(string[] args)
    {
      Log("Main() is called!");

      Example example = new Example(Application.NewApplication());
      example.MainLoop ();

      Log("After MainLoop()");
    }
  }
}

