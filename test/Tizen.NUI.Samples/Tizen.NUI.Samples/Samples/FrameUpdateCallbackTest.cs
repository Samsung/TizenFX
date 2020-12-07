using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.NUI.Samples
{
  enum TOUCH_ANIMATION_STATE
  {
    NO_ANIMATION = 0,
    ON_ANIMATION,
    ON_FINISH_ANIMATION,
    END_ANIMATION = NO_ANIMATION
  };

  public class FrameUpdateCallbackTest : IExample
  {

    private static string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
    private static string[] BACKGROUND_IMAGE_PATH = {
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_bg_02_nor.png",
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_bg_03_nor.png",
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_bg_04_nor.png",
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_bg_05_nor.png",
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_bg_06_nor.png",
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_bg_apps_nor.png"
    };

    private static string[] APPS_IMAGE_PATH = {
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_ic_culinary_nor.png",
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_ic_family_nor.png",
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_ic_ent_nor.png",
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_ic_homecare_nor.png"
    };

    private static string[] APPS_ICON_NAME = {
      "Culinary",
      "Family",
      "Entertainment",
      "Homecare"
    };

    private static string[] CONTROL_IMAGE_PATH = {
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_ic_apps_nor.png",
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_ic_settings_nor.png",
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_ic_viewinside_nor.png",
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_ic_timer_nor.png",
      resourcePath + "/images/FrameUpdateCallbackTest/launcher_ic_internet_nor.png"
    };

    private static string[] CONTROL_ICON_NAME = {
      "Apps",
      "Settings",
      "ViewInside",
      "Timer",
      "Internet"
    };

    private const int FRAME_RATE = 60;
    private const int OBJECT_DELAY = 30;
    private const int OBJECT_SIZE = 150;
    private const int INITIAL_POSITION = 46;
    private const int DEFAULT_SPACE = 9;
    private const int DEVIDE_BAR_SIZE = 4;

    private TextLabel text;
    public class FrameUpdateCallback : FrameUpdateCallbackInterface
    {
      private int timeInterval;

      private uint containerId;
      private List<uint> viewId; ///< View ID in the container.
      private List<float> viewPosition;

      // Movement is position difference of Container from start position of this animation to current position.
      // Time interval between each containerMovement entry is 16 milliseconds(about 60 fps)
      // For example.
      // containerMovement[i] + containerStartPosition is the position of container after i*16 milliseconds from this animation started.
      private List<float> containerMovement;

      // latestMovement is actually current movement of container.
      private float latestMovement;

      // An icon of touchedViewIndex moves with container at the same time.
      // Each icon of (touchedViewIndex -/+ i) moves as following container after i*OBJECT_DELAY milliseconds.
      private int touchedViewIndex;

      // If every icon between mLeftIndext and rightIndex is stopped, this frame callback can be reset.
      // Then isResetTouchedViewPossible becomes true.
      private bool isResetTouchedViewPossible;
      private int leftIndex;
      private int rightIndex;

      // Total animation time from start to current.
      private float totalAnimationTime;
      // Total animation time from start to the time that last movement is added.
      private float previousTotalAnimationTime;

      // Start position of container in this animation.
      private float containerStartPosition;
      // Position of container at the time that last movement is added.
      private float previousContainerPosition;

      // This animation only need to save movement about (the number of view * OBJECT_DELAY) milliseconds.
      // and this size is updated when new view is added.
      // and, If the list of containerMovement size become larger than this size, remove unnecessary entries.
      private int requiredMovementSize;
      private bool needUpdateMovementSize;

      // current velocity.
      private float velocity;
      // dirty flag.
      private bool dirty;

      public FrameUpdateCallback()
      {
        viewId = new List<uint>();
        containerMovement = new List<float>();
        requiredMovementSize = 0;
        needUpdateMovementSize = false;
        isResetTouchedViewPossible = false;
      }

      public void ResetAnimationData()
      {
        SetLatestMovement(0.0f);
        containerMovement.Clear();
        totalAnimationTime = 0.0f;
        previousTotalAnimationTime = 0.0f;
        dirty = true;
      }

      public void SetTimeInterval(int interval)
      {
        needUpdateMovementSize = true;
        timeInterval = interval;
      }

      public void AddId(uint id)
      {
        viewId.Add(id);
        needUpdateMovementSize = true;
      }

      public void SetContainerId(uint id)
      {
        containerId = id;
      }

      public void SetContainerStartPosition(float position)
      {
        containerStartPosition = position;
      }

      public void SetLatestMovement(float movement)
      {
        latestMovement = movement;
      }

      public void ResetViewPosition()
      {
        viewPosition = Enumerable.Repeat(0.0f, viewId.Count).ToList();
      }

      public void SetViewPosition(int index, float position)
      {
        viewPosition[index] = position;
      }

      public void SetTouchedViewIndex(int controlIndex)
      {
        touchedViewIndex = controlIndex;
      }

      public void AddMovement(float movement)
      {
        containerMovement.Add(movement);
      }

      public void SetLeftIndex(int Index)
      {
        leftIndex = Index;
      }

      public void SetRightIndex(int Index)
      {
        rightIndex = Index;
      }

      public bool IsResetTouchedViewPossible()
      {
        return isResetTouchedViewPossible;
      }
      public void Dirty()
      {
        dirty = true;
      }

      public bool IsDirty()
      {
        return dirty;
      }

      public float GetVelocity()
      {
        return velocity;
      }

      private void ComputeNewPositions(int totalTime)
      {
        // save latestMovement to avoid interference between thread.
        float lastMovement = latestMovement;
        bool isStillMoving = true;
        for (int i = 0; i < viewId.Count; ++i)
        {
          if (i == touchedViewIndex)
          {
            continue;
          }

          // compute delay of view of i.
          int totalDelay = Math.Abs(i - touchedViewIndex) * OBJECT_DELAY;
          if (totalDelay > totalTime)
          {
            continue;
          }

          int actorTime = totalTime - totalDelay;
          int movementIndex = actorTime / timeInterval;
          float factor = (float)(actorTime - (movementIndex * timeInterval)) / (float)timeInterval;
          float movement;
          if (movementIndex >= containerMovement.Count - 1)
          {
            // 1. delay is zero(every view moves with container at the same time)
            // 2. after every icons are stopped and the finger is stopped to move, the movement is still not added more.
            // than the view has lastMovement.
            movement = lastMovement;
          }
          else if (movementIndex < 0)
          {
            // If this animation is just staarted and the view need to wait more.
            // movement is 0.
            movement = 0.0f;
          }
          else
          {
            // Get the movement of ith view by interpolating containerMovement
            movement = factor * containerMovement[movementIndex + 1] + (1.0f - factor) * containerMovement[movementIndex];
          }

          // Prevent to overlap of each views.
          float currentSpace = Math.Abs((viewPosition[i] + movement) - (viewPosition[touchedViewIndex] + lastMovement));
          float minimumSpace = (float)Math.Abs(viewPosition[i] - viewPosition[touchedViewIndex]);
          if (currentSpace < minimumSpace)
          {
            movement = lastMovement;
          }

          // check views in screen are still moving or stopped.
          float newPosition = viewPosition[i] + movement - lastMovement;
          if (i >= leftIndex && i <= rightIndex)
          {
            Vector3 previousPosition = new Vector3();
            GetPosition(viewId[i], previousPosition);
            if (Math.Abs(previousPosition.X - newPosition) >= 1.0f)
            {
              isStillMoving = false;
            }
          }
          // update new position.
          SetPosition(viewId[i], new Vector3(newPosition, 0.0f, 0.0f));
        }
        isResetTouchedViewPossible = isStillMoving;
      }

      public override void OnUpdate(float elapsedSeconds)
      {
        // second -> millisecond
        totalAnimationTime += elapsedSeconds * 1000.0f;

        Vector3 currentPosition = new Vector3();
        GetPosition(containerId, currentPosition);

        // Add new Movement, if there is change in position.
        // 1. if dirty(there is reserved event)
        // 2. if container position is changed.
        // 3. if every icons in screen is stopped
        if (dirty || currentPosition.X != previousContainerPosition || isResetTouchedViewPossible)
        {
          dirty = false;
          if (totalAnimationTime >= containerMovement.Count * timeInterval)
          {
            // If the passed time is larger than timeInterval, add new movements.
            // If we need to add more than one, compute each movement by using interpolation.
            while (containerMovement.Count <= totalAnimationTime / timeInterval)
            {
              float factor = ((float)(containerMovement.Count * timeInterval) - previousTotalAnimationTime) / (totalAnimationTime - previousTotalAnimationTime);
              float movement = (float)(factor * currentPosition.X + (1.0f - factor) * previousContainerPosition) - containerStartPosition;
              AddMovement(movement);
            }
            // Compute velocity.
            // We need to compute velocity here to get reasonable value.
            velocity = (currentPosition.X - previousContainerPosition) / (totalAnimationTime - previousTotalAnimationTime);
            previousTotalAnimationTime = totalAnimationTime;
            previousContainerPosition = currentPosition.X;
          }
        }
        float currentMovement = currentPosition.X - containerStartPosition;
        SetLatestMovement(currentMovement);

        // Compute positions of each icon
        ComputeNewPositions((int)totalAnimationTime);

        // compute requiredMovementSize
        if (requiredMovementSize == 0 || needUpdateMovementSize)
        {
          needUpdateMovementSize = false;
          requiredMovementSize = viewId.Count * OBJECT_DELAY / timeInterval;
        }

        // Remove unnecessary movement for memory optimization.
        if (containerMovement.Count > requiredMovementSize * 2)
        {
          int movementNumberToRemove = containerMovement.Count - requiredMovementSize;
          containerMovement.RemoveRange(0, movementNumberToRemove);
          totalAnimationTime -= (float)(timeInterval * movementNumberToRemove);
        }
      }
    }

    private Window window;

    private FrameUpdateCallback frameUpdateCallback;        ///< An instance of our implementation of the FrameUpdateCallbackInterface.

    // Views for launcher
    private View baseView;
    private View controlView;
    private View layoutView;

    // Variables for animation
    private float previousTouchedPosition;
    private int touchedViewIndex;
    private TOUCH_ANIMATION_STATE animationState;

    private float leftDirectionLimit;
    private float rightDirectionLimit;


    // Variables for Finish animation
    // These variables are for deceleration curve.
    // If we want to use another curve like bezier, uses different variables
    private delegate float UserAlphaFunctionDelegate(float progress);
    private UserAlphaFunctionDelegate customScrollAlphaFunction;
    private float absoluteVelocity = 0.0f;
    private float finishAnimationDuration = 0.0f;
    private float finishAnimationDelta = 0.0f;
    private float logDeceleration = 0.0f;
    private float decelerationRate = 0.99f;
    private float easingThreshold = 0.1f;

    private Animation finishAnimation;
    private Timer animationOffTimer;  // timer to end animation after the easing animation is finished

    // Vies of contents
    private View contentsView;

    public void Activate()
    {
      frameUpdateCallback = new FrameUpdateCallback();
      Initialize();
    }

    public void Deactivate()
    {
    }

    void Initialize()
    {
      // Set the stage background color and connect to the stage's key signal to allow Back and Escape to exit.
      window = Window.Instance;
      window.BackgroundColor = Color.White;

      rightDirectionLimit = INITIAL_POSITION;

      // Contents

      contentsView = new View();
      contentsView.BackgroundColor = new Color(0.921568f, 0.9098039f, 0.890196f, 0.5f);
      contentsView.ParentOrigin = ParentOrigin.TopLeft;
      contentsView.PivotPoint = PivotPoint.TopLeft;
      contentsView.PositionUsesPivotPoint = true;
      contentsView.WidthResizePolicy = ResizePolicyType.FillToParent;
      contentsView.HeightResizePolicy = ResizePolicyType.FillToParent;
      window.GetDefaultLayer().Add(contentsView);

      // Launcher
      baseView = new View();
      baseView.ParentOrigin = ParentOrigin.BottomLeft;
      baseView.PivotPoint = PivotPoint.BottomLeft;
      baseView.PositionUsesPivotPoint = true;
      baseView.Size = new Size(window.Size.Width, 278);
      baseView.Position = new Position(0, 0);
      window.GetDefaultLayer().Add(baseView);

      View iconBackgroundView = new View();
      iconBackgroundView.BackgroundColor = new Color(0.921568f, 0.9098039f, 0.890196f, 0.5f);
      iconBackgroundView.ParentOrigin = ParentOrigin.BottomLeft;
      iconBackgroundView.PivotPoint = PivotPoint.BottomLeft;
      iconBackgroundView.PositionUsesPivotPoint = true;
      iconBackgroundView.Size = new Size(window.Size.Width, 278);
      iconBackgroundView.Position = new Position(0, 0);
      baseView.Add(iconBackgroundView);

      controlView = new View();
      controlView.ParentOrigin = ParentOrigin.CenterLeft;
      controlView.PivotPoint = PivotPoint.CenterLeft;
      controlView.PositionUsesPivotPoint = true;
      controlView.Position = new Position(rightDirectionLimit, 0);
      baseView.Add(controlView);
      frameUpdateCallback.SetContainerId(controlView.ID);

      layoutView = new View();
      layoutView.ParentOrigin = ParentOrigin.CenterLeft;
      layoutView.PivotPoint = PivotPoint.CenterLeft;
      layoutView.PositionUsesPivotPoint = true;
      layoutView.Layout = new LinearLayout()
      {
        LinearOrientation = LinearLayout.Orientation.Horizontal,
        CellPadding = new Size2D(DEFAULT_SPACE, 0),
      };
      layoutView.Position = new Position(0, 0);
      controlView.Add(layoutView);

      for (int i = 0; i < 4; ++i)
      {
        AddIcon(BACKGROUND_IMAGE_PATH[i], APPS_IMAGE_PATH[i], APPS_ICON_NAME[i], Color.White);
      }

      View divideBar = new View();
      divideBar.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.1f);
      divideBar.ParentOrigin = ParentOrigin.CenterLeft;
      divideBar.PivotPoint = PivotPoint.CenterLeft;
      divideBar.PositionUsesPivotPoint = true;
      divideBar.Size = new Size(DEVIDE_BAR_SIZE, OBJECT_SIZE);
      layoutView.Add(divideBar);
      frameUpdateCallback.AddId(divideBar.ID);

      int iconNumber = 8;
      for (int i = 0; i < iconNumber; ++i)
      {
        AddIcon(BACKGROUND_IMAGE_PATH[5], CONTROL_IMAGE_PATH[i % 5], CONTROL_ICON_NAME[i % 5], new Color(0.0f, 0.0f, 0.0f, 0.5f));
      }

      frameUpdateCallback.ResetViewPosition();
      frameUpdateCallback.SetTimeInterval(1000 / FRAME_RATE);

      animationState = TOUCH_ANIMATION_STATE.NO_ANIMATION;

      animationOffTimer = new Timer(16);
      animationOffTimer.Tick += OffAnimatable;

      baseView.TouchEvent += OnTouch;

      finishAnimation = new Animation();
      finishAnimation.Finished += EasingAnimationFinishedCallback;
      logDeceleration = (float)Math.Log(decelerationRate);
    }

    // Add icons

    void AddIcon(string background, string icon, string text, Color textColor)
    {
      ImageView backgroundView = new ImageView();
      backgroundView.ResourceUrl = background;
      backgroundView.Size = new Size(OBJECT_SIZE, OBJECT_SIZE);
      backgroundView.ParentOrigin = ParentOrigin.CenterLeft;
      backgroundView.PivotPoint = PivotPoint.CenterLeft;
      backgroundView.PositionUsesPivotPoint = true;
      layoutView.Add(backgroundView);
      frameUpdateCallback.AddId(backgroundView.ID);

      ImageView iconView = new ImageView();
      iconView.ResourceUrl = icon;
      iconView.Position = new Position(0, -15);
      iconView.ParentOrigin = ParentOrigin.Center;
      iconView.PivotPoint = PivotPoint.Center;
      iconView.PositionUsesPivotPoint = true;
      backgroundView.Add(iconView);

      TextLabel label = new TextLabel(text);
      label.Position = new Position(0, 30);
      label.HorizontalAlignment = HorizontalAlignment.Center;
      label.TextColor = textColor;
      label.FontFamily = "SamsungOneUI";
      label.PointSize = 12;
      label.ParentOrigin = ParentOrigin.Center;
      label.PivotPoint = PivotPoint.Center;
      label.PositionUsesPivotPoint = true;
      backgroundView.Add(label);
    }

    // Set frame callback to start drag animation.
    private void SetFrameUpdateCallback(float position)
    {
      // remove frame callback if it is already added.
      window.RemoveFrameUpdateCallback(frameUpdateCallback);

      frameUpdateCallback.ResetAnimationData();
      frameUpdateCallback.AddMovement(0.0f); // Add first movement.

      // Set container start position and start positions of each icon(and vertical bar)
      // And compute total container size.
      float totalSize = 0.0f;
      frameUpdateCallback.SetContainerStartPosition(controlView.Position.X);
      for (int i = 0; i < layoutView.ChildCount; ++i)
      {
        frameUpdateCallback.SetViewPosition(i, layoutView.Children[i].Position.X);
        totalSize += (float)(layoutView.Children[i].Size.Width + DEFAULT_SPACE);
      }
      totalSize -= (float)DEFAULT_SPACE;

      // Find touched icon
      for (int i = (int)layoutView.ChildCount - 1; i >= 0; --i)
      {
        if (position >= layoutView.Children[i].Position.X + controlView.Position.X)
        {
          frameUpdateCallback.SetTouchedViewIndex(i);
          touchedViewIndex = i;
          break;
        }
      }
      if (position < layoutView.Children[0].Position.X + controlView.Position.X)
      {
        frameUpdateCallback.SetTouchedViewIndex(0);
        touchedViewIndex = 0;
      }

      previousTouchedPosition = position;

      // Add frame callback on window.
      // OnUpdate callback of frameUpdateCallback will be called before every render frame.
      window.AddFrameUpdateCallback(frameUpdateCallback);

      // compute limit position the container could go.
      leftDirectionLimit = (float)window.Size.Width - (totalSize + (float)(INITIAL_POSITION));

      window.RenderingBehavior = RenderingBehaviorType.Continuously; // make rendering be done for upto 60 fps even though there is no update in main thread.
      animationState = TOUCH_ANIMATION_STATE.ON_ANIMATION; // make rendering state on.
    }

    private bool OnTouch(object source, View.TouchEventArgs e)
    {
      Vector2 position = e.Touch.GetScreenPosition(0);

      PointStateType state = e.Touch.GetState(0);
      if (PointStateType.Down == state)
      {
        if (animationState == TOUCH_ANIMATION_STATE.ON_FINISH_ANIMATION)
        {
          // re-birth current animation
          // in case of touch during finish animation,
          // quit easingAnimation and AnimationOffTimer because animation ownership is returned to the touch event again.
          // AND, DO NOT RESET ALL PROPERTIES OF FRAMECALLBACK.
          // because, for example, if touched icon index is changed, the movement is wrong and the animation can be not continous.
          // This re-birthed animation is just for smooth moving during complex user interaction.
          // during complex and fast interaction, this is not so noticeable.
          // and reset of such properties will be done in the below Motion state
          finishAnimation.Stop();
          animationOffTimer.Stop();

          // Set Animation State to ON_ANIMATION again
          animationState = TOUCH_ANIMATION_STATE.ON_ANIMATION;
          // Set previousTouchPosition
          previousTouchedPosition = position.X;
        }
        else
        {
          // in case of stable state
          // just set new framecallback for this touched position.
          SetFrameUpdateCallback(position.X);
        }
      }
      else if (PointStateType.Motion == state)
      {
        // if framecallback can be reset, quit current frame callback and re-launch new frame callback.
        // because, if current frame callback is re-birthed one, the animation is not totally re-created one.
        // So, some properties like touched icon index can be wrong for the continuous animation.
        // But, some case like that finger is stopped and restart to move, this could make weired feeling.
        // We reset frameUpdateCallback as soon as possible we can. And the conditions are ...
        // 1. icons in screen is stopped.
        // 2. velocity of frame callback is 0.0 (this frame callback will not move again instantly)
        // 3. frame callback is not dirty (there is no reserved action)
        if (frameUpdateCallback.IsResetTouchedViewPossible() && frameUpdateCallback.GetVelocity() == 0.0f && !frameUpdateCallback.IsDirty())
        {
          SetFrameUpdateCallback(position.X);
        }

        // Set new controlView(container) position
        // in here, we need to consider the container is not go outside of limits.
        float containerPosition = controlView.Position.X + (position.X - previousTouchedPosition);
        containerPosition = Math.Min(containerPosition, rightDirectionLimit);
        containerPosition = Math.Max(containerPosition, leftDirectionLimit);
        float adjustedPosition = containerPosition - controlView.Position.X + previousTouchedPosition;
        previousTouchedPosition = adjustedPosition;
        controlView.Position.X = containerPosition;
      }
      else if ((PointStateType.Up == state || PointStateType.Leave == state || PointStateType.Interrupted == state) &&
               animationState == TOUCH_ANIMATION_STATE.ON_ANIMATION)
      {
        animationState = TOUCH_ANIMATION_STATE.ON_FINISH_ANIMATION;

        // To launch finish animation, we get latest velocty from frame callback
        float lastVelocity = frameUpdateCallback.GetVelocity();

        /* TUNING */
        // This is just for turning of finish animation.
        // change the values if you want.
        lastVelocity = Math.Max(lastVelocity, -3.5f);
        lastVelocity = Math.Min(lastVelocity, 3.5f);
        if (Math.Abs(lastVelocity) < 0.0001f)
        {
          // If velocity is zero. just start animationOfftimer.
          animationOffTimer.Start();
        }
        else
        {
          // If velocity is not zero, make decelerating animation.
          Decelerating(lastVelocity);
        }
      }
      // set currently visible icons for optimization
      SetVisibleLimit();
      // make frame callback dirty.
      frameUpdateCallback.Dirty();
      return true;
    }

    private void SetVisibleLimit()
    {
      int leftViewIndex = touchedViewIndex;
      for (; leftViewIndex >= 0; --leftViewIndex)
      {
        float newPosition = layoutView.Children[leftViewIndex].Position.X + controlView.Position.X;
        if (newPosition + (float)layoutView.Children[leftViewIndex].Size.Width < 0.0f)
        {
          break;
        }
      }
      leftViewIndex = Math.Max(leftViewIndex, 0);
      int rightViewIndex = touchedViewIndex;
      for (; rightViewIndex < layoutView.ChildCount; ++rightViewIndex)
      {
        float newPosition = layoutView.Children[rightViewIndex].Position.X + controlView.Position.X;
        if (newPosition > window.Size.Width)
        {
          break;
        }
      }
      rightViewIndex = Math.Min(rightViewIndex, (int)layoutView.ChildCount - 1);

      frameUpdateCallback.SetLeftIndex(leftViewIndex);
      frameUpdateCallback.SetRightIndex(rightViewIndex);
    }

    // set decelerating properties
    // in this example, we used decelerate animation in "https://medium.com/@esskeetit/scrolling-mechanics-of-uiscrollview-142adee1142c"
    // But, if this method is problematic or violate some patent of other company, change this other way.
    // We didn't checked anything.
    // Only thing we need to remember when we change this animation is to add "EasingAnimationFinishedCallback" for the new animation.
    private void Decelerating(float lastVelocity)
    {
      absoluteVelocity = Math.Abs(lastVelocity);
      finishAnimationDelta = (absoluteVelocity * decelerationRate) / (1 - decelerationRate);
      float destination = (lastVelocity > 0) ? controlView.Position.X + finishAnimationDelta : controlView.Position.X - finishAnimationDelta;

      if (destination < leftDirectionLimit || destination > rightDirectionLimit)
      {
        finishAnimationDelta = lastVelocity > 0 ? (rightDirectionLimit - controlView.Position.X) : (controlView.Position.X - leftDirectionLimit);
        destination = lastVelocity > 0 ? rightDirectionLimit : leftDirectionLimit;
        if (finishAnimationDelta == 0)
        {
          finishAnimationDuration = 0.0f;
        }
        else
        {
          finishAnimationDuration = (float)Math.Log((finishAnimationDelta * logDeceleration / absoluteVelocity + 1), decelerationRate);
        }
      }
      else
      {
        if (finishAnimationDelta == 0)
        {
          finishAnimationDuration = 0.0f;
        }
        else
        {
          finishAnimationDuration = (float)Math.Log(-easingThreshold * logDeceleration / absoluteVelocity) / logDeceleration;
        }
      }

      finishAnimation.Clear();
      customScrollAlphaFunction = new UserAlphaFunctionDelegate(CustomScrollAlphaFunction);
      finishAnimation.DefaultAlphaFunction = new AlphaFunction(customScrollAlphaFunction);
      GC.KeepAlive(customScrollAlphaFunction);
      finishAnimation.Duration = (int)finishAnimationDuration;
      finishAnimation.AnimateTo(controlView, "PositionX", destination);
      finishAnimation.Play();
    }

    private float CustomScrollAlphaFunction(float progress)
    {
      if (finishAnimationDelta == 0)
      {
        return 1.0f;
      }
      else
      {
        float realDuration = progress * finishAnimationDuration;
        float realDistance = absoluteVelocity * ((float)Math.Pow(decelerationRate, realDuration) - 1) / logDeceleration;
        float result = Math.Min(realDistance / Math.Abs(finishAnimationDelta), 1.0f);

        return result;
      }
    }

    private void EasingAnimationFinishedCallback(object sender, EventArgs e)
    {
      if (animationState != TOUCH_ANIMATION_STATE.ON_FINISH_ANIMATION)
      {
        return;
      }

      // start Animation Off Timer
      finishAnimation.Clear();
      SetVisibleLimit();
      animationOffTimer.Start();
    }

    // Check each icons in screen is not moving.
    // If it is, finish all animation and make animationstate End_animation(NO_ANIMATION)
    private bool OffAnimatable(object target, Timer.TickEventArgs args)
    {
      if (frameUpdateCallback.IsResetTouchedViewPossible())
      {
        window.RenderingBehavior = RenderingBehaviorType.IfRequired;
        window.RemoveFrameUpdateCallback(frameUpdateCallback);
        animationOffTimer.Stop();
        animationState = TOUCH_ANIMATION_STATE.END_ANIMATION;
        return false;
      }
      SetVisibleLimit();
      return true;
    }
  }
}