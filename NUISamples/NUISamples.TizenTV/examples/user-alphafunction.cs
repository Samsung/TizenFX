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
using Dali.Constants;

namespace MyCSharpExample
{
  class Example
  {
    private Dali.Application _application;
    private Animation _animation;
    private TextLabel _text;
    private View _view1, _view2, _view3;
    private UserAlphaFunctionDelegate _user_alpha_func;
    private int myCount;

    public static void Log(string str)
    {
      Console.WriteLine("[DALI C# SAMPLE] " + str);
    }

    public Example(Dali.Application application)
    {
      _application = application;
      _application.Initialized += Initialize;
    }

    // Declare user alpha function delegate
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    delegate float UserAlphaFunctionDelegate(float progress);

    public void Initialize(object source, NUIApplicationInitEventArgs e)
    {
      Log("Initialize() is called!");
      Stage stage = Stage.GetCurrent();
      stage.BackgroundColor = Color.White;
      stage.Touch += OnStageTouched;
      stage.Touch += OnStageTouched2;
      //stage.EventProcessingFinished += OnEventProcessingFinished;
      stage.Wheel += OnStageWheelEvent;

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
      stage.Add(_view1);

      _view2 = new View();
      _view2.BackgroundColor = Color.Red;
      _view2.Size = new Vector3(50.0f, 50.0f, 0.0f);
      _view2.ParentOrigin = ParentOrigin.TopLeft;
      _view2.AnchorPoint = AnchorPoint.TopLeft;
      _view2.SetResizePolicy(ResizePolicyType.FIXED, DimensionType.ALL_DIMENSIONS);
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
        myCount = 0;
    }

    public void MyAnimating()
    {
      // Create a new _animation
      if( _animation )
      {
        _animation.Clear();
        _animation.Reset();
      }

      _animation = new Animation(10000); // 10000 milli-second of duration
      _animation.StartTime = 5000;
      _animation.EndTime = 10000;
      _animation.TargetProperty = "Position";
      _animation.AlphaFunction = new AlphaFunction(_user_alpha_func);
      _animation.Destination = new Vector3(150.0f, 150.0f, 0.0f);
      _animation.AnimateTo(_view2);
      // Connect the signal callback for animaiton finished signal
      _animation.Finished += AnimationFinished;
      _animation.EndAction = Animation.EndActions.Discard;
      // Play the _animation
      _animation.Play();
    }

    // Callback for stage touched signal handling
    public void OnStageTouched(object source, Stage.TouchEventArgs e)
    {
      // Only animate the _text label when touch down happens
      if( e.Touch.GetState(0) == PointStateType.DOWN )
      {
        Log("OnStageTouched() is called! PointStateType.DOWN came!");
        myCount++;
        if( myCount > 1 )
        {
          _animation.Stop();
          Log("_animation.Stop() is called!");
        }
      }
    }

    // Callback for stage touched signal handling
    public void OnStageTouched2(object source, Stage.TouchEventArgs e)
    {
      Log("OnStageTouched2() is called!state="+ e.Touch.GetState(0) );
    }

    public void OnEventProcessingFinished(object source)
	{
      Log("OnEventProcessingFinished() is called!");
    }

    public void OnStageWheelEvent(object source, Stage.WheelEventArgs e)
    {
      Log("OnStageWheelEvent() is called!");
      //Log("OnStageWheelEvent() is called!direction="+ e.WheelEvent.direction + " timeStamp=" + e.WheelEvent.timeStamp );
    }


    public void OnStage(object source , View.OnStageEventArgs e)
	{
      Log("OnStage() is called!");
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

