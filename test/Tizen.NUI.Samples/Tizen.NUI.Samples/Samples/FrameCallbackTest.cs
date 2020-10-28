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

  public class FrameCallbackTest : IExample
  {

    private static string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
    private static string[] BACKGROUND_IMAGE_PATH = {
      resourcePath + "/images/FrameCallbackTest/launcher_bg_02_nor.png",
      resourcePath + "/images/FrameCallbackTest/launcher_bg_03_nor.png",
      resourcePath + "/images/FrameCallbackTest/launcher_bg_04_nor.png",
      resourcePath + "/images/FrameCallbackTest/launcher_bg_05_nor.png",
      resourcePath + "/images/FrameCallbackTest/launcher_bg_06_nor.png",
      resourcePath + "/images/FrameCallbackTest/launcher_bg_apps_nor.png"
    };

    private static string[] APPS_IMAGE_PATH = {
      resourcePath + "/images/FrameCallbackTest/launcher_ic_culinary_nor.png",
      resourcePath + "/images/FrameCallbackTest/launcher_ic_family_nor.png",
      resourcePath + "/images/FrameCallbackTest/launcher_ic_ent_nor.png",
      resourcePath + "/images/FrameCallbackTest/launcher_ic_homecare_nor.png"
    };

    private static string[] APPS_ICON_NAME = {
      "Culinary",
      "Family",
      "Entertainment",
      "Homecare"
    };

    private static string[] CONTROL_IMAGE_PATH = {
      resourcePath + "/images/FrameCallbackTest/launcher_ic_apps_nor.png",
      resourcePath + "/images/FrameCallbackTest/launcher_ic_settings_nor.png",
      resourcePath + "/images/FrameCallbackTest/launcher_ic_viewinside_nor.png",
      resourcePath + "/images/FrameCallbackTest/launcher_ic_timer_nor.png",
      resourcePath + "/images/FrameCallbackTest/launcher_ic_internet_nor.png"
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
    public class FrameCallback : FrameCallbackInterface
    {
      private int mTimeInterval;

      private uint mContainerId;
      private List<uint> mViewId; ///< Container of Actor IDs.
      private List<float> mViewPosition;

      // Movement is position difference of Container from start position of this animation to current position.
      // Time interval between each mMovement entry is 16 milliseconds(about 60 fps)
      // For example.
      // mMovement[i] + mContainerStartPosition is the position of container after i*16 milliseconds from this animation started.
      private List<float> mMovement;

      // mLatestMovement is actually current movement of container.
      private float mLatestMovement;

      // An icon of mTouchedViewIndex moves with container at the same time.
      // Each icon of (mTouchedViewIndex -/+ i) moves as following container after i*OBJECT_DELAY milliseconds.
      private int mTouchedViewIndex;

      // If every icon between mLeftIndext and mRightIndex is stopped, this frame callback can be reset.
      // Then mIsResetTouchedViewPossible becomes true.
      private bool mIsResetTouchedViewPossible;
      private int mLeftIndex;
      private int mRightIndex;

      // Total animation time from start to current.
      private float mTotalAnimationTime;
      // Total animation time from start to the time that last movement is added.
      private float mPreviousTotalAnimationTime;

      // Start position of container in this animation.
      private float mContainerStartPosition;
      // Position of container at the time that last movement is added.
      private float mPreviousContainerPosition;

      // This animation only need to save movement about (the number of view * OBJECT_DELAY) milliseconds.
      // and this size is updated when new view is added.
      // and, If the list of mMovement size become larger than this size, remove unnecessary entries.
      private int mRequiredMovementSize;
      private bool mNeedUpdateMovementSize;

      // current velocity.
      private float mVelocity;
      // dirty flag.
      private bool mDirty;

      public FrameCallback()
      {
        mViewId = new List<uint>();
        mMovement = new List<float>();
        mRequiredMovementSize = 0;
        mNeedUpdateMovementSize = false;
        mIsResetTouchedViewPossible = false;
      }

      public void ResetAnimationData()
      {
        SetLatestMovement(0.0f);
        mMovement.Clear();
        mTotalAnimationTime = 0.0f;
        mPreviousTotalAnimationTime = 0.0f;
        mDirty = true;
      }

      public void SetTimeInterval(int timeInterval)
      {
        mNeedUpdateMovementSize = true;
        mTimeInterval = timeInterval;
      }

      public void AddId(uint id)
      {
        mViewId.Add(id);
        mNeedUpdateMovementSize = true;
      }

      public void SetContainerId(uint id)
      {
        mContainerId = id;
      }

      public void SetContainerStartPosition(float position)
      {
        mContainerStartPosition = position;
      }

      public void SetLatestMovement(float movement)
      {
        mLatestMovement = movement;
      }

      public void ResetViewPosition()
      {
        mViewPosition = Enumerable.Repeat(0.0f, mViewId.Count).ToList();
      }

      public void SetViewPosition(int index, float position)
      {
        mViewPosition[index] = position;
      }

      public void SetTouchedViewIndex(int controlIndex)
      {
        mTouchedViewIndex = controlIndex;
      }

      public void AddMovement(float movement)
      {
        mMovement.Add(movement);
      }

      public void SetLeftIndex(int leftIndex)
      {
        mLeftIndex = leftIndex;
      }

      public void SetRightIndex(int rightIndex)
      {
        mRightIndex = rightIndex;
      }

      public bool IsResetTouchedViewPossible()
      {
        return mIsResetTouchedViewPossible;
      }
      public void Dirty()
      {
        mDirty = true;
      }

      public bool IsDirty()
      {
        return mDirty;
      }

      public float GetVelocity()
      {
        return mVelocity;
      }

      private void ComputeNewPositions(int totalTime)
      {
        // save latestMovement to avoid interference between thread.
        float latestMovement = mLatestMovement;
        bool isResetTouchedViewPossible = true;
        for (int i = 0; i < mViewId.Count; ++i)
        {
          if (i == mTouchedViewIndex)
          {
            continue;
          }

          // compute delay of view of i.
          int totalDelay = Math.Abs(i - mTouchedViewIndex) * OBJECT_DELAY;
          if (totalDelay > totalTime)
          {
            continue;
          }

          int actorTime = totalTime - totalDelay;
          int movementIndex = actorTime / mTimeInterval;
          float factor = (float)(actorTime - (movementIndex * mTimeInterval)) / (float)mTimeInterval;
          float movement;
          if (movementIndex >= mMovement.Count - 1)
          {
            // 1. delay is zero(every view moves with container at the same time)
            // 2. after every icons are stopped and the finger is stopped to move, the movement is still not added more.
            // than the view has latestMovement.
            movement = latestMovement;
          }
          else if (movementIndex < 0)
          {
            // If this animation is just staarted and the view need to wait more.
            // movement is 0.
            movement = 0.0f;
          }
          else
          {
            // Get the movement of ith view by interpolating mMovement
            movement = factor * mMovement[movementIndex + 1] + (1.0f - factor) * mMovement[movementIndex];
          }

          // Prevent to overlap of each views.
          float currentSpace = Math.Abs((mViewPosition[i] + movement) - (mViewPosition[mTouchedViewIndex] + latestMovement));
          float minimumSpace = (float)Math.Abs(mViewPosition[i] - mViewPosition[mTouchedViewIndex]);
          if (currentSpace < minimumSpace)
          {
            movement = latestMovement;
          }

          // check views in screen are still moving or stopped.
          float newPosition = mViewPosition[i] + movement - latestMovement;
          if (i >= mLeftIndex && i <= mRightIndex)
          {
            Vector3 previousPosition = new Vector3();
            GetPosition(mViewId[i], previousPosition);
            if (Math.Abs(previousPosition.X - newPosition) >= 1.0f)
            {
              isResetTouchedViewPossible = false;
            }
          }
          // update new position.
          SetPosition(mViewId[i], new Vector3(newPosition, 0.0f, 0.0f));
        }
        mIsResetTouchedViewPossible = isResetTouchedViewPossible;
      }

      public override void OnUpdate(float elapsedSeconds)
      {
        // second -> millisecond
        mTotalAnimationTime += elapsedSeconds * 1000.0f;

        Vector3 currentPosition = new Vector3();
        GetPosition(mContainerId, currentPosition);

        // Add new Movement, if there is change in position.
        // 1. if dirty(there is reserved event)
        // 2. if container position is changed.
        // 3. if every icons in screen is stopped
        if (mDirty || currentPosition.X != mPreviousContainerPosition || mIsResetTouchedViewPossible)
        {
          mDirty = false;
          if (mTotalAnimationTime >= mMovement.Count * mTimeInterval)
          {
            // If the passed time is larger than mTimeInterval, add new movements.
            // If we need to add more than one, compute each movement by using interpolation.
            while (mMovement.Count <= mTotalAnimationTime / mTimeInterval)
            {
              float factor = ((float)(mMovement.Count * mTimeInterval) - mPreviousTotalAnimationTime) / (mTotalAnimationTime - mPreviousTotalAnimationTime);
              float movement = (float)(factor * currentPosition.X + (1.0f - factor) * mPreviousContainerPosition) - mContainerStartPosition;
              AddMovement(movement);
            }
            // Compute velocity.
            // We need to compute velocity here to get reasonable value.
            mVelocity = (currentPosition.X - mPreviousContainerPosition) / (mTotalAnimationTime - mPreviousTotalAnimationTime);
            mPreviousTotalAnimationTime = mTotalAnimationTime;
            mPreviousContainerPosition = currentPosition.X;
          }
        }
        float currentMovement = currentPosition.X - mContainerStartPosition;
        SetLatestMovement(currentMovement);

        // Compute positions of each icon
        ComputeNewPositions((int)mTotalAnimationTime);

        // compute mRequiredMovementSize
        if (mRequiredMovementSize == 0 || mNeedUpdateMovementSize)
        {
          mNeedUpdateMovementSize = false;
          mRequiredMovementSize = mViewId.Count * OBJECT_DELAY / mTimeInterval;
        }

        // Remove unnecessary movement for memory optimization.
        if (mMovement.Count > mRequiredMovementSize * 2)
        {
          int movementNumberToRemove = mMovement.Count - mRequiredMovementSize;
          mMovement.RemoveRange(0, movementNumberToRemove);
          mTotalAnimationTime -= (float)(mTimeInterval * movementNumberToRemove);
        }
      }
    }

    private Window mWindow;

    private FrameCallback mFrameCallback;        ///< An instance of our implementation of the FrameCallbackInterface.

    // Views for launcher
    private View mBaseView;
    private View mControlView;
    private View mLayoutView;

    // Variables for animation
    private float mPreviousTouchedPosition;
    private int mTouchedViewIndex;
    private TOUCH_ANIMATION_STATE mAnimationState;

    private float mLeftDirectionLimit;
    private float mRightDirectionLimit;


    // Variables for Finish animation
    // These variables are for deceleration curve.
    // If we want to use another curve like bezier, uses different variables
    private delegate float UserAlphaFunctionDelegate(float progress);
    private UserAlphaFunctionDelegate customScrollAlphaFunction;
    private float mAbsoluteVelocity = 0.0f;
    private float mFinishAnimationDuration = 0.0f;
    private float mFinishAnimationDelta = 0.0f;
    private float mLogDeceleration = 0.0f;
    private float mDecelerationRate = 0.99f;
    private float mEasingThreshold = 0.1f;

    private Animation mFinishAnimation;
    private Timer mAnimationOffTimer;  // timer to end animation after the easing animation is finished

    // Vies of contents
    private View mContentsView;

    public void Activate()
    {
      mFrameCallback = new FrameCallback();
      Initialize();
    }

    public void Deactivate()
    {
    }

    void Initialize()
    {
      // Set the stage background color and connect to the stage's key signal to allow Back and Escape to exit.
      mWindow = Window.Instance;
      mWindow.BackgroundColor = Color.White;

      mRightDirectionLimit = INITIAL_POSITION;

      // Contents

      mContentsView = new View();
      mContentsView.BackgroundColor = new Color(0.921568f, 0.9098039f, 0.890196f, 0.5f);
      mContentsView.ParentOrigin = ParentOrigin.TopLeft;
      mContentsView.PivotPoint = PivotPoint.TopLeft;
      mContentsView.PositionUsesPivotPoint = true;
      mContentsView.WidthResizePolicy = ResizePolicyType.FillToParent;
      mContentsView.HeightResizePolicy = ResizePolicyType.FillToParent;
      mWindow.GetDefaultLayer().Add(mContentsView);

      // Launcher
      mBaseView = new View();
      mBaseView.ParentOrigin = ParentOrigin.BottomLeft;
      mBaseView.PivotPoint = PivotPoint.BottomLeft;
      mBaseView.PositionUsesPivotPoint = true;
      mBaseView.Size = new Size(mWindow.Size.Width, 278);
      mBaseView.Position = new Position(0, 0);
      mWindow.GetDefaultLayer().Add(mBaseView);

      View iconBackgroundView = new View();
      iconBackgroundView.BackgroundColor = new Color(0.921568f, 0.9098039f, 0.890196f, 0.5f);
      iconBackgroundView.ParentOrigin = ParentOrigin.BottomLeft;
      iconBackgroundView.PivotPoint = PivotPoint.BottomLeft;
      iconBackgroundView.PositionUsesPivotPoint = true;
      iconBackgroundView.Size = new Size(mWindow.Size.Width, 278);
      iconBackgroundView.Position = new Position(0, 0);
      mBaseView.Add(iconBackgroundView);

      mControlView = new View();
      mControlView.ParentOrigin = ParentOrigin.CenterLeft;
      mControlView.PivotPoint = PivotPoint.CenterLeft;
      mControlView.PositionUsesPivotPoint = true;
      mControlView.Position = new Position(mRightDirectionLimit, 0);
      mBaseView.Add(mControlView);
      mFrameCallback.SetContainerId(mControlView.ID);

      mLayoutView = new View();
      mLayoutView.ParentOrigin = ParentOrigin.CenterLeft;
      mLayoutView.PivotPoint = PivotPoint.CenterLeft;
      mLayoutView.PositionUsesPivotPoint = true;
      mLayoutView.Layout = new LinearLayout()
      {
        LinearOrientation = LinearLayout.Orientation.Horizontal,
        CellPadding = new Size2D(DEFAULT_SPACE, 0),
      };
      mLayoutView.Position = new Position(0, 0);
      mControlView.Add(mLayoutView);

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
      mLayoutView.Add(divideBar);
      mFrameCallback.AddId(divideBar.ID);

      int iconNumber = 8;
      for (int i = 0; i < iconNumber; ++i)
      {
        AddIcon(BACKGROUND_IMAGE_PATH[5], CONTROL_IMAGE_PATH[i % 5], CONTROL_ICON_NAME[i % 5], new Color(0.0f, 0.0f, 0.0f, 0.5f));
      }

      mFrameCallback.ResetViewPosition();
      mFrameCallback.SetTimeInterval(1000 / FRAME_RATE);

      mAnimationState = TOUCH_ANIMATION_STATE.NO_ANIMATION;

      mAnimationOffTimer = new Timer(16);
      mAnimationOffTimer.Tick += OffAnimatable;

      mBaseView.TouchEvent += OnTouch;

      mFinishAnimation = new Animation();
      mFinishAnimation.Finished += EasingAnimationFinishedCallback;
      mLogDeceleration = (float)Math.Log(mDecelerationRate);
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
      mLayoutView.Add(backgroundView);
      mFrameCallback.AddId(backgroundView.ID);

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
    private void SetFrameCallback(float position)
    {
      // remove frame callback if it is already added.
      mWindow.RemoveFrameCallback(mFrameCallback);

      mFrameCallback.ResetAnimationData();
      mFrameCallback.AddMovement(0.0f); // Add first movement.

      // Set container start position and start positions of each icon(and vertical bar)
      // And compute total container size.
      float totalSize = 0.0f;
      mFrameCallback.SetContainerStartPosition(mControlView.Position.X);
      for (int i = 0; i < mLayoutView.ChildCount; ++i)
      {
        mFrameCallback.SetViewPosition(i, mLayoutView.Children[i].Position.X);
        totalSize += (float)(mLayoutView.Children[i].Size.Width + DEFAULT_SPACE);
      }
      totalSize -= (float)DEFAULT_SPACE;

      // Find touched icon
      for (int i = (int)mLayoutView.ChildCount - 1; i >= 0; --i)
      {
        if (position >= mLayoutView.Children[i].Position.X + mControlView.Position.X)
        {
          mFrameCallback.SetTouchedViewIndex(i);
          mTouchedViewIndex = i;
          break;
        }
      }
      if (position < mLayoutView.Children[0].Position.X + mControlView.Position.X)
      {
        mFrameCallback.SetTouchedViewIndex(0);
        mTouchedViewIndex = 0;
      }

      mPreviousTouchedPosition = position;

      // Add frame callback on window.
      // OnUpdate callback of mFrameCallback will be called before every render frame.
      mWindow.AddFrameCallback(mFrameCallback);

      // compute limit position the container could go.
      mLeftDirectionLimit = (float)mWindow.Size.Width - (totalSize + (float)(INITIAL_POSITION));

      mWindow.RenderingBehavior = RenderingBehaviorType.Continuously; // make rendering be done for upto 60 fps even though there is no update in main thread.
      mAnimationState = TOUCH_ANIMATION_STATE.ON_ANIMATION; // make rendering state on.
    }

    private bool OnTouch(object source, View.TouchEventArgs e)
    {
      Vector2 position = e.Touch.GetScreenPosition(0);

      PointStateType state = e.Touch.GetState(0);
      if (PointStateType.Down == state)
      {
        if (mAnimationState == TOUCH_ANIMATION_STATE.ON_FINISH_ANIMATION)
        {
          // re-birth current animation
          // in case of touch during finish animation,
          // quit easingAnimation and AnimationOffTimer because animation ownership is returned to the touch event again.
          // AND, DO NOT RESET ALL PROPERTIES OF FRAMECALLBACK.
          // because, for example, if touched icon index is changed, the movement is wrong and the animation can be not continous.
          // This re-birthed animation is just for smooth moving during complex user interaction.
          // during complex and fast interaction, this is not so noticeable.
          // and reset of such properties will be done in the below Motion state
          mFinishAnimation.Stop();
          mAnimationOffTimer.Stop();

          // Set Animation State to ON_ANIMATION again
          mAnimationState = TOUCH_ANIMATION_STATE.ON_ANIMATION;
          // Set previousTouchPosition
          mPreviousTouchedPosition = position.X;
        }
        else
        {
          // in case of stable state
          // just set new framecallback for this touched position.
          SetFrameCallback(position.X);
        }
      }
      else if (PointStateType.Motion == state)
      {
        // if framecallback can be reset, quit current frame callback and re-launch new frame callback.
        // because, if current frame callback is re-birthed one, the animation is not totally re-created one.
        // So, some properties like touched icon index can be wrong for the continuous animation.
        // But, some case like that finger is stopped and restart to move, this could make weired feeling.
        // We reset mFrameCallback as soon as possible we can. And the conditions are ...
        // 1. icons in screen is stopped.
        // 2. velocity of frame callback is 0.0 (this frame callback will not move again instantly)
        // 3. frame callback is not dirty (there is no reserved action)
        if (mFrameCallback.IsResetTouchedViewPossible() && mFrameCallback.GetVelocity() == 0.0f && !mFrameCallback.IsDirty())
        {
          SetFrameCallback(position.X);
        }

        // Set new controlView(container) position
        // in here, we need to consider the container is not go outside of limits.
        float containerPosition = mControlView.Position.X + (position.X - mPreviousTouchedPosition);
        containerPosition = Math.Min(containerPosition, mRightDirectionLimit);
        containerPosition = Math.Max(containerPosition, mLeftDirectionLimit);
        float adjustedPosition = containerPosition - mControlView.Position.X + mPreviousTouchedPosition;
        mPreviousTouchedPosition = adjustedPosition;
        mControlView.Position.X = containerPosition;
      }
      else if ((PointStateType.Up == state || PointStateType.Leave == state || PointStateType.Interrupted == state) &&
               mAnimationState == TOUCH_ANIMATION_STATE.ON_ANIMATION)
      {
        mAnimationState = TOUCH_ANIMATION_STATE.ON_FINISH_ANIMATION;

        // To launch finish animation, we get latest velocty from frame callback
        float velocity = mFrameCallback.GetVelocity();

        /* TUNING */
        // This is just for turning of finish animation.
        // change the values if you want.
        velocity = Math.Max(velocity, -3.5f);
        velocity = Math.Min(velocity, 3.5f);
        if (Math.Abs(velocity) < 0.0001f)
        {
          // If velocity is zero. just start animationOfftimer.
          mAnimationOffTimer.Start();
        }
        else
        {
          // If velocity is not zero, make decelerating animation.
          Decelerating(velocity);
        }
      }
      // set currently visible icons for optimization
      SetVisibleLimit();
      // make frame callback dirty.
      mFrameCallback.Dirty();
      return true;
    }

    private void SetVisibleLimit()
    {
      int leftViewIndex = mTouchedViewIndex;
      for (; leftViewIndex >= 0; --leftViewIndex)
      {
        float newPosition = mLayoutView.Children[leftViewIndex].Position.X + mControlView.Position.X;
        if (newPosition + (float)mLayoutView.Children[leftViewIndex].Size.Width < 0.0f)
        {
          break;
        }
      }
      leftViewIndex = Math.Max(leftViewIndex, 0);
      int rightViewIndex = mTouchedViewIndex;
      for (; rightViewIndex < mLayoutView.ChildCount; ++rightViewIndex)
      {
        float newPosition = mLayoutView.Children[rightViewIndex].Position.X + mControlView.Position.X;
        if (newPosition > mWindow.Size.Width)
        {
          break;
        }
      }
      rightViewIndex = Math.Min(rightViewIndex, (int)mLayoutView.ChildCount - 1);

      mFrameCallback.SetLeftIndex(leftViewIndex);
      mFrameCallback.SetRightIndex(rightViewIndex);
    }

    // set decelerating properties
    // in this example, we used decelerate animation in "https://medium.com/@esskeetit/scrolling-mechanics-of-uiscrollview-142adee1142c"
    // But, if this method is problematic or violate some patent of other company, change this other way.
    // We didn't checked anything.
    // Only thing we need to remember when we change this animation is to add "EasingAnimationFinishedCallback" for the new animation.
    private void Decelerating(float velocity)
    {
      mAbsoluteVelocity = Math.Abs(velocity);
      mFinishAnimationDelta = (mAbsoluteVelocity * mDecelerationRate) / (1 - mDecelerationRate);
      float destination = (velocity > 0) ? mControlView.Position.X + mFinishAnimationDelta : mControlView.Position.X - mFinishAnimationDelta;

      if (destination < mLeftDirectionLimit || destination > mRightDirectionLimit)
      {
        mFinishAnimationDelta = velocity > 0 ? (mRightDirectionLimit - mControlView.Position.X) : (mControlView.Position.X - mLeftDirectionLimit);
        destination = velocity > 0 ? mRightDirectionLimit : mLeftDirectionLimit;
        if (mFinishAnimationDelta == 0)
        {
          mFinishAnimationDuration = 0.0f;
        }
        else
        {
          mFinishAnimationDuration = (float)Math.Log((mFinishAnimationDelta * mLogDeceleration / mAbsoluteVelocity + 1), mDecelerationRate);
        }
      }
      else
      {
        if (mFinishAnimationDelta == 0)
        {
          mFinishAnimationDuration = 0.0f;
        }
        else
        {
          mFinishAnimationDuration = (float)Math.Log(-mEasingThreshold * mLogDeceleration / mAbsoluteVelocity) / mLogDeceleration;
        }
      }

      mFinishAnimation.Clear();
      customScrollAlphaFunction = new UserAlphaFunctionDelegate(CustomScrollAlphaFunction);
      mFinishAnimation.DefaultAlphaFunction = new AlphaFunction(customScrollAlphaFunction);
      GC.KeepAlive(customScrollAlphaFunction);
      mFinishAnimation.Duration = (int)mFinishAnimationDuration;
      mFinishAnimation.AnimateTo(mControlView, "PositionX", destination);
      mFinishAnimation.Play();
    }

    private float CustomScrollAlphaFunction(float progress)
    {
      if (mFinishAnimationDelta == 0)
      {
        return 1.0f;
      }
      else
      {
        float realDuration = progress * mFinishAnimationDuration;
        float realDistance = mAbsoluteVelocity * ((float)Math.Pow(mDecelerationRate, realDuration) - 1) / mLogDeceleration;
        float result = Math.Min(realDistance / Math.Abs(mFinishAnimationDelta), 1.0f);

        return result;
      }
    }

    private void EasingAnimationFinishedCallback(object sender, EventArgs e)
    {
      if (mAnimationState != TOUCH_ANIMATION_STATE.ON_FINISH_ANIMATION)
      {
        return;
      }

      // start Animation Off Timer
      mFinishAnimation.Clear();
      SetVisibleLimit();
      mAnimationOffTimer.Start();
    }

    // Check each icons in screen is not moving.
    // If it is, finish all animation and make animationstate End_animation(NO_ANIMATION)
    private bool OffAnimatable(object target, Timer.TickEventArgs args)
    {
      if (mFrameCallback.IsResetTouchedViewPossible())
      {
        mWindow.RenderingBehavior = RenderingBehaviorType.IfRequired;
        mWindow.RemoveFrameCallback(mFrameCallback);
        mAnimationOffTimer.Stop();
        mAnimationState = TOUCH_ANIMATION_STATE.END_ANIMATION;
        return false;
      }
      SetVisibleLimit();
      return true;
    }
  }
}