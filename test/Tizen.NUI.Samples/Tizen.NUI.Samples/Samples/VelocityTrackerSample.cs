using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;
using Tizen.NUI.Utility;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
  public class VelocityTrackerSample : IExample
  {
    private View myView;
    private PanGestureDetector panGestureDetector, panGestureDetector1;

    Tizen.NUI.Utility.VelocityTracker tracker;
    Tizen.NUI.Utility.VelocityTracker customTracker;

    private ImageView panView, panView1;
    private readonly int ImageSize = 24;
    private static readonly string imagePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/Dali/CubeTransitionEffect/";

    private readonly string[] ResourceUrl = {
           imagePath + "gallery-large-9.jpg",
           imagePath + "gallery-large-5.jpg",
        };

    private Animation flickAnimation = new Animation();
    private Animation flickAnimation1 = new Animation();

    public void Activate()
    {
      Init();
    }

    private void Init()
    {

      // You can use custom trackers created by yourself
      Tizen.NUI.Utility.VelocityTrackerStrategy[] strategy = new CustomVelocityTracker[2];
      for(int i=0 ; i<2; i++)
      {
        strategy[i] = new CustomVelocityTracker();
      }
      customTracker = new Tizen.NUI.Utility.VelocityTracker(strategy);

      // you can use default tracker
      tracker = new Tizen.NUI.Utility.VelocityTracker();


      Window.Instance.BackgroundColor = Color.White;

      panGestureDetector = new PanGestureDetector();
      panGestureDetector1 = new PanGestureDetector();

      myView = new View()
      {
        WidthResizePolicy = ResizePolicyType.FillToParent,
        HeightResizePolicy = ResizePolicyType.FillToParent,
        BackgroundColor = Color.White
      };
      Window.Instance.Add(myView);

      panView = new ImageView()
      {
        Size2D = new Size2D(200, 200),
        Position2D = new Position2D(100, 100),
        ResourceUrl = ResourceUrl[0],
      };
      myView.Add(panView);
      panGestureDetector.Attach(panView);

      panView1 = new ImageView()
      {
        Size2D = new Size2D(200, 200),
        Position2D = new Position2D(400, 100),
        ResourceUrl = ResourceUrl[1],
      };
      myView.Add(panView1);
      panGestureDetector1.Attach(panView1);


      panGestureDetector.Attach(panView);
      panGestureDetector.Detected += OnPanGestureDetector;

      panGestureDetector1.Attach(panView1);
      panGestureDetector1.Detected += OnPanGestureDetector1;

    }

    public void Deactivate()
    {
    }

    private void OnPanGestureDetector(object source, PanGestureDetector.DetectedEventArgs e)
    {
      if (e.View is ImageView view)
      {
        flickAnimation.Stop();
        flickAnimation.Clear();

        if (e.PanGesture.State == Gesture.StateType.Started)
        {
          tracker.Clear();
          tracker.AddMovement(e.PanGesture.ScreenPosition, e.PanGesture.Time);
          Vector2 move = e.PanGesture.ScreenDisplacement;
          view.Position += new Position(move.X, move.Y);
        }
        else if (e.PanGesture.State == Gesture.StateType.Continuing)
        {
          tracker.AddMovement(e.PanGesture.ScreenPosition, e.PanGesture.Time);
          Vector2 move = e.PanGesture.ScreenDisplacement;
          view.Position += new Position(move.X, move.Y);
        }
        else if (e.PanGesture.State == Gesture.StateType.Finished)
        {
          Vector2 move = e.PanGesture.ScreenDisplacement;
          view.Position += new Position(move.X, move.Y);

          int distanceX = (int)(tracker.GetVelocity().X * 100);
          int distanceY = (int)(tracker.GetVelocity().Y * 100);

          Tizen.Log.Error("NUI", $"tracker : {tracker.GetVelocity().X}, {tracker.GetVelocity().Y}, {e.PanGesture.ScreenVelocity.X}, {e.PanGesture.ScreenVelocity.Y}\n");

          flickAnimation.AnimateBy(view, "PositionX", distanceX, 0, 300);
          flickAnimation.AnimateBy(view, "PositionY", distanceY, 0, 300);
          flickAnimation.Play();
        }
      }
    }

    private void OnPanGestureDetector1(object source, PanGestureDetector.DetectedEventArgs e)
    {
      if (e.View is ImageView view)
      {
        flickAnimation1.Stop();
        flickAnimation1.Clear();

        if (e.PanGesture.State == Gesture.StateType.Started)
        {
          customTracker.Clear();
          customTracker.AddMovement(e.PanGesture.ScreenPosition, e.PanGesture.Time);

          Vector2 move = e.PanGesture.ScreenDisplacement;
          view.Position += new Position(move.X, move.Y);
        }
        else if (e.PanGesture.State == Gesture.StateType.Continuing)
        {
          customTracker.AddMovement(new Vector2(e.PanGesture.ScreenPosition), e.PanGesture.Time);

          Vector2 move = e.PanGesture.ScreenDisplacement;
          view.Position += new Position(move.X, move.Y);
        }
        else if (e.PanGesture.State == Gesture.StateType.Finished)
        {
          Vector2 move = e.PanGesture.ScreenDisplacement;
          view.Position += new Position(move.X, move.Y);

          Tizen.Log.Error("NUI", $"customTracker : {customTracker.GetVelocity().X}, {customTracker.GetVelocity().Y}, {e.PanGesture.ScreenVelocity.X}, {e.PanGesture.ScreenVelocity.Y}\n");

          int distanceX = (int)(customTracker.GetVelocity().X * 100);
          int distanceY = (int)(customTracker.GetVelocity().Y * 100);

          flickAnimation1.AnimateBy(view, "PositionX", distanceX, 0, 300);
          flickAnimation1.AnimateBy(view, "PositionY", distanceY, 0, 300);
          flickAnimation1.Play();
        }
      }
    }
  }

  public class CustomVelocityTracker : Tizen.NUI.Utility.VelocityTrackerStrategy
  {
      private uint mHistorySize = 20;
      private uint mMaximumTime = 100;
      private uint mLastEventTime = 0;
      private uint mAssumePointerStoppedTime = 40; // 40ms
      private Strategy mStrategy;
      private uint mMinDuration = 10; //10ms
      private List<Data> mMovements = new List<Data>();

      public enum Strategy
      {
          Legacy,
          LSQ2,
          Default = Legacy
      }

      public struct Data
      {
          public float Position {get; set;}
          public uint EventTime {get; set;}

          public Data(float position, uint time)
          {
              Position = position;
              EventTime = time;
          }
      }

      public CustomVelocityTracker(Strategy strategy = Strategy.Default)
      {
          mStrategy = strategy;
      }

      public override void AddMovement(uint time, int pointerId, float position)
      {
          int size = mMovements.Count;
          if(size > 0)
          {
              if(time - mLastEventTime > mAssumePointerStoppedTime)
              {
                  mMovements.Clear();
                  return;
              }

              if(mLastEventTime == time)
              {
                  mMovements.RemoveAt(size-1);
              }

              if(size > mHistorySize)
              {
                  mMovements.RemoveAt(0);
              }
          }

          mLastEventTime = time;
          Data data = new Data(position, time);
          mMovements.Add(data);

          while(mMovements.Count > 0 && time - mMovements[0].EventTime > mMaximumTime)
          {
              mMovements.RemoveAt(0);
          }
      }

      public override void Clear()
      {
          mMovements.Clear();
      }

      private float GetVelocityLSQ2()
      {
          int count = mMovements.Count;
          if(count > 1)
          {
              // Solving y = a*x^2 + b*x + c, where
              //      - "x" is age (i.e. duration since latest movement) of the movemnets
              //      - "y" is positions of the movements.
              float sxi = 0, sxiyi = 0, syi = 0, sxi2 = 0, sxi3 = 0, sxi2yi = 0, sxi4 = 0;

              Data newestMovement = mMovements[count - 1];
              for (int i = 0; i < count; i++) {
                  Data movement = mMovements[i];
                  float age = newestMovement.EventTime - movement.EventTime;
                  float xi = -age;
                  float yi = movement.Position;
                  float xi2 = xi*xi;
                  float xi3 = xi2*xi;
                  float xi4 = xi3*xi;
                  float xiyi = xi*yi;
                  float xi2yi = xi2*yi;
                  sxi += xi;
                  sxi2 += xi2;
                  sxiyi += xiyi;
                  sxi2yi += xi2yi;
                  syi += yi;
                  sxi3 += xi3;
                  sxi4 += xi4;
              }
              float Sxx = sxi2 - sxi*sxi / count;
              float Sxy = sxiyi - sxi*syi / count;
              float Sxx2 = sxi3 - sxi*sxi2 / count;
              float Sx2y = sxi2yi - sxi2*syi / count;
              float Sx2x2 = sxi4 - sxi2*sxi2 / count;
              float denominator = Sxx*Sx2x2 - Sxx2*Sxx2;
              if (denominator == 0) {
                  return 0.0f;
              }
              return (Sxy * Sx2x2 - Sx2y * Sxx2) / (denominator );
          }
          return 0.0f;
      }

      private float GetVelocityLegacy()
      {
          int size = mMovements.Count;
          if(size > 0)
          {
              int oldestIndex = 0;
              float accumV = 0;
              bool samplesUsed = false;
              Data oldestMovement = mMovements[oldestIndex];
              float oldestPosition = oldestMovement.Position;
              float lastDuration = 0;
              for (int i = oldestIndex; i < size; i++) {
                  Data movement = mMovements[i];
                  float duration = movement.EventTime - oldestMovement.EventTime;
                  if (duration >= mMinDuration) {
                      float position = movement.Position;
                      float scale = 1.0f / duration; // one over time delta in seconds
                      float v = (position - oldestPosition) * scale;
                      accumV = (accumV * lastDuration + v * duration) / (duration + lastDuration);
                      lastDuration = duration;
                      samplesUsed = true;
                  }
              }
              if (samplesUsed) {
                  return accumV;
              }
          }
          return 0.0f;
      }



      public override float? GetVelocity(int pointerId)
      {
          switch(mStrategy)
          {
              case Strategy.LSQ2:
                  return GetVelocityLSQ2();
              case Strategy.Legacy:
              default:
                  return GetVelocityLegacy();
          }
      }
  }
}
