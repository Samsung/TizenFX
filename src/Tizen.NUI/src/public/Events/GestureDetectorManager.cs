/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Events
{
  /// <summary>
  /// This is a class for detects various gestures.
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public class GestureDetectorManager : Disposable
  {
    /// <summary>
    ///  This class is used to create a subset of the gestures you only want.
    ///  You can inherit this class and implement the callback for gestures what you want to use.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GestureListener
    {
      /// <summary>
      ///  TapGestureDetector event callback.
      /// </summary>
      [EditorBrowsable(EditorBrowsableState.Never)]
      public virtual void OnTap(object sender, TapGestureDetector.DetectedEventArgs e)
      {
      }

      /// <summary>
      ///  LongPressGestureDetector event callback.
      /// </summary>
      [EditorBrowsable(EditorBrowsableState.Never)]
      public virtual void OnLongPress(object sender, LongPressGestureDetector.DetectedEventArgs e)
      {
      }

      /// <summary>
      ///  PanGestureDetector event callback.
      /// </summary>
      [EditorBrowsable(EditorBrowsableState.Never)]
      public virtual void OnPan(object sender, PanGestureDetector.DetectedEventArgs e)
      {
      }

      /// <summary>
      ///  PinchGestureDetector event callback.
      /// </summary>
      [EditorBrowsable(EditorBrowsableState.Never)]
      public virtual void OnPinch(object sender, PinchGestureDetector.DetectedEventArgs e)
      {
      }
    }

    private GestureListener mListener;
    private TapGestureDetector mTapGestureDetector;
    private LongPressGestureDetector mLongGestureDetector;
    private PinchGestureDetector mPinchGestureDetector;
    private PanGestureDetector mPanGestureDetector;

    /// <summary>
    ///  Creates a GestureDetectorManager with the user listener.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public GestureDetectorManager(View view, GestureListener listener)
    {
      if(view == null)
      {
        throw new global::System.ArgumentNullException(nameof(view));
      }
      if(listener == null)
      {
        throw new global::System.ArgumentNullException(nameof(listener));
      }

      mListener = listener;
      view.GrabTouchAfterLeave = true;
      init(view);
    }

    private void init(View view)
    {
      mTapGestureDetector = new TapGestureDetector();
      mLongGestureDetector = new LongPressGestureDetector();
      mPanGestureDetector = new PanGestureDetector();
      mPinchGestureDetector = new PinchGestureDetector();

      mTapGestureDetector.Attach(view);
      mLongGestureDetector.Attach(view);
      mPanGestureDetector.Attach(view);
      mPinchGestureDetector.Attach(view);
    }

    private void InternalOnTap(object sender, TapGestureDetector.DetectedEventArgs e)
    {
      mListener.OnTap(sender, e);
      mTapGestureDetector.Detected -= InternalOnTap;
    }

    private void InternalOnLongPress(object sender, LongPressGestureDetector.DetectedEventArgs e)
    {
      mListener.OnLongPress(sender, e);
      mLongGestureDetector.Detected -= InternalOnLongPress;
    }

    private void InternalOnPan(object sender, PanGestureDetector.DetectedEventArgs e)
    {
      mListener.OnPan(sender, e);
      mPanGestureDetector.Detected -= InternalOnPan;
    }

    private void InternalOnPinch(object sender, PinchGestureDetector.DetectedEventArgs e)
    {
      mListener.OnPinch(sender, e);
      mPinchGestureDetector.Detected -= InternalOnPinch;
    }

    /// <summary>
    /// Gestures also work only when there is a touch event.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void FeedTouchEvent(object sender, View.TouchEventArgs e)
    {
      mTapGestureDetector.Detected -= InternalOnTap;
      mLongGestureDetector.Detected -= InternalOnLongPress;
      mPanGestureDetector.Detected -= InternalOnPan;
      mPinchGestureDetector.Detected -= InternalOnPinch;

      if(e != null &&
          (e.Touch.GetState(0) != PointStateType.Finished ||
           e.Touch.GetState(0) != PointStateType.Up       ||
           e.Touch.GetState(0) != PointStateType.Interrupted))
      {
        mTapGestureDetector.Detected += InternalOnTap;
        mLongGestureDetector.Detected += InternalOnLongPress;
        mPanGestureDetector.Detected += InternalOnPan;
        mPinchGestureDetector.Detected += InternalOnPinch;
      }
    }
  }
}
