/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Globalization;
    using System.Diagnostics.CodeAnalysis;

    using Tizen.NUI.BaseComponents;

    /// <summary>
    /// Animation can be used to animate the properties of any number of objects, typically view.<br />
    /// If the "Finished" event is connected to a member function of an object, it must be disconnected before the object is destroyed.<br />
    /// This is typically done in the object destructor, and requires either the animation handle to be stored.<br />
    /// The overall animation time is superseded by the values given in the animation time used when calling the AnimateTo(), AnimateBy(), AnimateBetween() and AnimatePath() methods.<br />
    /// If any of the individual calls to those functions exceeds the overall animation time (Duration), then the overall animation time is automatically extended.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Animation : BaseHandle
    {
        private static bool? disableAnimation = null;

        private AnimationFinishedEventCallbackType animationFinishedEventCallback;
        private System.IntPtr finishedCallbackOfNative;

        private AnimationProgressReachedEventCallbackType animationProgressReachedEventCallback;

        private string[] properties = null;
        private string[] destValue = null;
        private int[] startTime = null;
        private int[] endTime = null;

        private List<string> propertyList = null;
        private List<string> destValueList = null;
        private List<int> startTimeList = null;
        private List<int> endTimeList = null;

        /// <summary>
        /// Creates an initialized animation.<br />
        /// The animation will not loop.<br />
        /// The default end action is "Cancel".<br />
        /// The default alpha function is linear.<br />
        /// </summary>
        /// <remarks>DurationmSeconds must be greater than zero.</remarks>
        /// <param name="durationMilliSeconds">The duration in milliseconds.</param>
        /// <since_tizen> 3 </since_tizen>
        public Animation(int durationMilliSeconds) : this(Interop.Animation.New((float)durationMilliSeconds / 1000.0f), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Animation(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            animationFinishedEventCallback = OnFinished;
            finishedCallbackOfNative = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(animationFinishedEventCallback);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AnimationFinishedEventCallbackType(IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AnimationProgressReachedEventCallbackType(IntPtr data);

        private event EventHandler animationFinishedEventHandler;

        /// <summary>
        /// Event for the finished signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// The finished signal is emitted when an animation's animations have finished.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler Finished
        {
            add
            {
                if (animationFinishedEventHandler == null && disposed == false)
                {
                    AnimationSignal finishedSignal = FinishedSignal();
                    finishedSignal.Connect(finishedCallbackOfNative);
                    finishedSignal.Dispose();
                }
                animationFinishedEventHandler += value;
            }
            remove
            {
                animationFinishedEventHandler -= value;

                AnimationSignal finishedSignal = FinishedSignal();
                if (animationFinishedEventHandler == null && finishedSignal.Empty() == false)
                {
                    finishedSignal.Disconnect(finishedCallbackOfNative);
                }
                finishedSignal.Dispose();
            }
        }

        private event EventHandler animationProgressReachedEventHandler;

        /// <summary>
        /// Event for the ProgressReached signal, which can be used to subscribe or unsubscribe the event handler.<br />
        /// The ProgressReached signal is emitted when the animation has reached a given progress percentage, this is set in the api SetProgressNotification.<br />
        /// </summary>
        /// <remark>
        /// This value only be applied if animation state is Stopped.
        /// </remark>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler ProgressReached
        {
            add
            {
                if (animationProgressReachedEventHandler == null)
                {
                    animationProgressReachedEventCallback = OnProgressReached;
                    AnimationSignal progressReachedSignal = ProgressReachedSignal();
                    progressReachedSignal?.Connect(animationProgressReachedEventCallback);
                    progressReachedSignal?.Dispose();
                }

                animationProgressReachedEventHandler += value;
            }
            remove
            {
                animationProgressReachedEventHandler -= value;

                AnimationSignal progressReachedSignal = ProgressReachedSignal();
                if (animationProgressReachedEventHandler == null && progressReachedSignal?.Empty() == false)
                {
                    progressReachedSignal?.Disconnect(animationProgressReachedEventCallback);
                }
                progressReachedSignal.Dispose();
            }
        }

        /// <summary>
        /// Enumeration for what to do when the animation ends, stopped, or destroyed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names")]
        public enum EndActions
        {
            /// <summary>
            /// When the animation ends, the animated property values are saved.
            /// </summary>
            Cancel,
            /// <summary>
            /// When the animation ends, the animated property values are forgotten.
            /// </summary>
            Discard,
            /// <summary>
            /// If the animation is stopped, the animated property values are saved as if the animation had run to completion, otherwise behaves like cancel.
            /// </summary>
            StopFinal
        }

        /// <summary>
        /// Enumeration for what interpolation method to use on key-frame animations.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum Interpolation
        {
            /// <summary>
            /// Values in between key frames are interpolated using a linear polynomial. (Default)
            /// </summary>
            Linear,
            /// <summary>
            /// Values in between key frames are interpolated using a cubic polynomial.
            /// </summary>
            Cubic
        }

        /// <summary>
        /// Enumeration for what state the animation is in.
        /// </summary>
        /// <remarks>Calling Reset() on this class will not reset the animation. It will call the BaseHandle.Reset() which drops the object handle.</remarks>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names")]
        public enum States
        {
            /// <summary>
            /// The animation has stopped.
            /// </summary>
            Stopped,
            /// <summary>
            /// The animation is playing.
            /// </summary>
            Playing,
            /// <summary>
            /// The animation is paused.
            /// </summary>
            Paused
        }

        /// <summary>
        /// Enumeration for what looping mode is in.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names")]
        public enum LoopingModes
        {
            /// <summary>
            /// When the animation arrives at the end in looping mode, the animation restarts from the beginning. (Default)
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Restart,
            /// <summary>
            /// When the animation arrives at the end in looping mode, the animation reverses direction and runs backwards again.
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            AutoReverse
        }

        /// <summary>
        /// Gets or sets the duration in milliseconds of the animation.
        /// This duration is applied to the animations are added after the Duration is set.
        /// </summary>
        /// <example>
        /// <code>
        /// animation.AnimateTo(actor, "position", destination);
        /// animation.Duration = 500; // This duration 500 is only applied to the size animation.
        /// animation.AnimateTo(actor, "size", size);
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public int Duration
        {
            set
            {
                SetDuration(MilliSecondsToSeconds(value));
            }
            get
            {
                return SecondsToMilliSeconds(GetDuration());
            }
        }

        /// <summary>
        /// Gets or sets the default alpha function for the animation.
        /// This DefaultAlphaFunction is only applied to the animations are added after the DefaultAlphaFunction is set.
        /// </summary>
        /// <example>
        /// <code>
        /// animation.AnimateTo(actor, "position", destination);
        /// animation.DefaultAlphaFunction = newAlphaFunction; // This newAlphaFunction is applied only for the size animation.
        /// animation.AnimateTo(actor, "size", size);
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction DefaultAlphaFunction
        {
            set
            {
                SetDefaultAlphaFunction(value);
            }
            get
            {
                AlphaFunction ret = GetDefaultAlphaFunction();
                return ret;
            }
        }

        /// <summary>
        /// Queries the state of the animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public States State
        {
            get
            {
                return GetState();
            }
        }

        /// <summary>
        /// Set: Enables looping for a specified number of repeats. A zero is the same as Looping = true; i.e., repeat forever.<br />
        /// This property resets the looping value and should not be used with the Looping property.<br />
        /// Setting this parameter does not cause the animation to Play().<br />
        /// Get: Gets the loop count. A zero is the same as Looping = true; i.e., repeat forever.<br />
        /// The loop count is initially 1 for play once.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int LoopCount
        {
            set
            {
                SetLoopCount(value);
            }
            get
            {
                int ret = GetLoopCount();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the status of whether the animation will loop.<br />
        /// This property resets the loop count and should not be used with the LoopCount property.<br />
        /// Setting this parameter does not cause the animation to Play().<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Looping
        {
            set
            {
                SetLooping(value);
            }
            get
            {
                bool ret = IsLooping();
                return ret;
            }
        }


        /// <summary>
        /// Gets or sets the end action of the animation.<br />
        /// This action is performed when the animation ends or if it is stopped.<br />
        /// The default end action is EndActions.Cancel.<br />
        /// </summary>
        /// <remark>
        /// Change the action value from EndActions.Discard, or to EndActions.Discard during animation is playing / paused will not works well.
        /// </remark>
        /// <since_tizen> 3 </since_tizen>
        public EndActions EndAction
        {
            set
            {
                SetEndAction(value);
            }
            get
            {
                return GetEndAction();
            }
        }

        /// <summary>
        /// Gets the current loop count.<br />
        /// A value 0 indicating the current loop count when looping.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int CurrentLoop
        {
            get
            {
                return GetCurrentLoop();
            }
        }

        /// <summary>
        /// Gets or sets the disconnect action.<br />
        /// If any of the animated property owners are disconnected from the stage while the animation is being played, then this action is performed.<br />
        /// The default action is EndActions.StopFinal.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public EndActions DisconnectAction
        {
            set
            {
                Interop.Animation.SetDisconnectAction(SwigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Animation.EndActions ret = (Animation.EndActions)Interop.Animation.GetDisconnectAction(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }


        /// <summary>
        /// Gets or sets the progress of the animation.<br />
        /// The animation will play (or continue playing) from this point.<br />
        /// The progress must be in the 0-1 interval or in the play range interval if defined<br />
        /// otherwise, it will be ignored.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float CurrentProgress
        {
            set
            {
                Interop.Animation.SetCurrentProgress(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Animation.GetCurrentProgress(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets specifications of a speed factor for the animation.<br />
        /// The speed factor is a multiplier of the normal velocity of the animation.<br />
        /// Values between [0, 1] will slow down the animation and values above one will speed up the animation.<br />
        /// It is also possible to specify a negative multiplier to play the animation in reverse.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float SpeedFactor
        {
            set
            {
                Interop.Animation.SetSpeedFactor(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Animation.GetSpeedFactor(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the playing range.<br />
        /// Animation will play between the values specified. Both values (range.x and range.y ) should be between 0-1,
        /// otherwise they will be ignored. If the range provided is not in proper order (minimum, maximum ), it will be reordered.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector2 PlayRange
        {
            set
            {
                Interop.Animation.SetPlayRange(SwigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Vector2 ret = new Vector2(Interop.Animation.GetPlayRange(SwigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }


        /// <summary>
        /// Gets or sets the progress notification marker which triggers the ProgressReachedSignal.<br />
        /// Percentage of animation progress should be greater than 0 and less than 1, for example, 0.3 for 30%<br />
        /// One notification can be set on each animation.
        /// </summary>
        /// <remark>
        /// This value only be applied if animation state is Stopped.
        /// </remark>
        /// <since_tizen> 3 </since_tizen>
        public float ProgressNotification
        {
            set
            {
                Interop.Animation.SetProgressNotification(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Animation.GetProgressNotification(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Enumeration for what looping mode is in.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LoopingModes LoopingMode
        {
            set
            {
                Interop.Animation.SetLoopingMode(SwigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Animation.LoopingModes ret = (Animation.LoopingModes)Interop.Animation.GetLoopingMode(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Sets and Gets the blend point to interpolate animate property
        ///
        /// BlendPoint is a value between [0,1], If the value of the keyframe whose progress is 0 is different from the current value,
        /// the property is animated as it smoothly blends until the progress reaches the blendPoint.
        /// </summary>
        /// <remarks>
        /// The blend point only affects animation registered with AnimateBetween. Other animations operate the same as when Play() is called.
        /// And the blend point needs to be set before this animation plays. If the blend point changes after playback, animation continuity cannot be guaranteed.
        /// </remarks>
        /// <remarks>
        /// In the case of a looping animation, the animation is blended only in the first loop.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BlendPoint
        {
            set
            {
                Interop.Animation.SetBlendPoint(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Animation.GetBlendPoint(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the properties of the animation.
        /// </summary>
        //ToDo : will raise deprecated-ACR, [Obsolete("Deprecated in API9, will be removed in API11, Use PropertyList instead")]
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "This API will be deprecated, so suppressing the warning for now")]
        public string[] Properties
        {
            get
            {
                return properties;
            }
            set
            {
                properties = value;
            }
        }

        /// <summary>
        /// Gets or sets the destination value for each property of the animation.
        /// </summary>
        //ToDo : will raise deprecated-ACR, [Obsolete("Deprecated in API9, will be removed in API11, Use DestValueList instead")]
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "This API will be deprecated, so suppressing the warning for now")]
        public string[] DestValue
        {
            get
            {
                return destValue;
            }
            set
            {
                destValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the start time for each property of the animation.
        /// </summary>
        //ToDo : will raise deprecated-ACR, [Obsolete("Deprecated in API9, will be removed in API11, Use StartTimeList instead")]
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "This API will be deprecated, so suppressing the warning for now")]
        public int[] StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the end time for each property of the animation.
        /// </summary>
        //ToDo : will raise deprecated-ACR, [Obsolete("Deprecated in API9, will be removed in API11, Use EndTimeList instead")]
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "This API will be deprecated, so suppressing the warning for now")]
        public int[] EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
            }
        }

        /// <summary>
        /// Get the list of the properties of the animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> PropertyList
        {
            get
            {
                if (null == propertyList)
                {
                    propertyList = new List<string>();
                }

                return propertyList;
            }
        }

        /// <summary>
        /// Get the list of the destination value for each property of the animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> DestValueList
        {
            get
            {
                if (null == destValueList)
                {
                    destValueList = new List<string>();
                }

                return destValueList;
            }
        }

        /// <summary>
        /// Get the list of the start time for each property of the animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<int> StartTimeList
        {
            get
            {
                if (null == startTimeList)
                {
                    startTimeList = new List<int>();
                }

                return startTimeList;
            }
        }

        /// <summary>
        /// Get the list of end time for each property of the animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<int> EndTimeList
        {
            get
            {
                if (null == endTimeList)
                {
                    endTimeList = new List<int>();
                }

                return endTimeList;
            }
        }

        private bool DisableAnimation
        {
            get
            {
                if (disableAnimation.HasValue == false)
                {
                    string type = Environment.GetEnvironmentVariable("PlatformSmartType");
                    if (type == "Entry")
                        disableAnimation = true;
                    else
                        disableAnimation = false;
                }
                return disableAnimation.Value;
            }
        }

        /// <summary>
        /// Downcasts a handle to animation handle.<br />
        /// If handle points to an animation object, the downcast produces a valid handle.<br />
        /// If not, the returned handle is left uninitialized.<br />
        /// </summary>
        /// <param name="handle">Handle to an object.</param>
        /// <returns>Handle to an animation object or an uninitialized handle.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when handle is null. </exception>
        internal static Animation DownCast(BaseHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }
            Animation ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as Animation;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Stops the animation. It will change this animation's EndAction property.
        /// </summary>
        /// <remarks>
        /// Change the value from EndActions.Discard, or to EndActions.Discard during animation is playing / paused will not works well.<br/>
        /// If you want to stop by EndActions.Discard, EndAction property also should be EndActions.Discard before Play API called. <br/>
        /// <br/>
        /// This method is deprecated since API11 because EndActions property concept is not matched with Stop(). <br/>
        /// Use <see cref="EndAction"/> property instead.
        /// </remarks>
        /// <param name="action">The end action can be set.</param>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API11, will be removed in API13. Use EndAction property instead.")]
        public void Stop(EndActions action)
        {
            SetEndAction(action);
            Interop.Animation.Stop(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Animates a property value by a relative amount.<br />
        /// </summary>
        /// <param name="target">The target animatable object to animate.</param>
        /// <param name="property">The target property to animate.</param>
        /// <param name="relativeValue">The property value will change by this amount.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <exception cref="ArgumentNullException"> Thrown when target or property or relativeValue is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when it failed to find a property from given string or the given relativeValue is invalid format. </exception>
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AnimateBy(Animatable target, string property, object relativeValue, AlphaFunction alphaFunction = null)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            if (relativeValue == null)
            {
                throw new ArgumentNullException(nameof(relativeValue));
            }

            using (var result = PropertyHelper.Search(target, property))
            {
                if (result == null)
                {
                    throw new ArgumentException("string property is invalid");
                }

                var current = result;
                while (current != null)
                {

                    var targetValueIntPtr = current.RefineValueIntPtr(relativeValue);
                    if (targetValueIntPtr == global::System.IntPtr.Zero)
                    {
                        throw new ArgumentException("Invalid " + nameof(relativeValue));
                    }
                    AnimateByIntPtr(current.Property, targetValueIntPtr, alphaFunction);
                    Interop.PropertyValue.DeletePropertyValueIntPtr(targetValueIntPtr);
                    current = current.NextResult;
                }
            }
        }

        /// <summary>
        /// Animates a property value by a relative amount.<br />
        /// </summary>
        /// <param name="target">The target animatable object to animate.</param>
        /// <param name="property">The target property to animate.</param>
        /// <param name="relativeValue">The property value will change by this amount.</param>
        /// <param name="startTime">The start time of the animation.</param>
        /// <param name="endTime">The end time of the animation.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <exception cref="ArgumentNullException"> Thrown when target or property or relativeValue is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when it failed to find a property from given string or the given relativeValue is invalid format. </exception>
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AnimateBy(Animatable target, string property, object relativeValue, int startTime, int endTime, AlphaFunction alphaFunction = null)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            if (relativeValue == null)
            {
                throw new ArgumentNullException(nameof(relativeValue));
            }

            using (var result = PropertyHelper.Search(target, property))
            {
                if (result == null)
                {
                    throw new ArgumentException("string property is invalid");
                }

                var current = result;
                using (var time = new TimePeriod(startTime, endTime - startTime))
                    while (current != null)
                    {

                        var targetValueIntPtr = current.RefineValueIntPtr(relativeValue);
                        if (targetValueIntPtr == global::System.IntPtr.Zero)
                        {
                            throw new ArgumentException("Invalid " + nameof(relativeValue));
                        }
                        AnimateByIntPtr(current.Property, targetValueIntPtr, alphaFunction, time);
                        Interop.PropertyValue.DeletePropertyValueIntPtr(targetValueIntPtr);
                        current = current.NextResult;
                    }
            }
        }

        /// <summary>
        /// Animates a property value by a relative amount.<br />
        /// </summary>
        /// <param name="target">The target object to animate.</param>
        /// <param name="property">The target property to animate.</param>
        /// <param name="relativeValue">The property value will change by this amount.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <exception cref="ArgumentNullException"> Thrown when target or property or relativeValue is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when it failed to find a property from given string or the given relativeValue is invalid format. </exception>
        /// <since_tizen> 3 </since_tizen>
        public void AnimateBy(View target, string property, object relativeValue, AlphaFunction alphaFunction = null)
        {
            AnimateBy(target as Animatable, property, relativeValue, alphaFunction);
        }

        /// <summary>
        /// Animates a property value by a relative amount.<br />
        /// </summary>
        /// <param name="target">The target object to animate.</param>
        /// <param name="property">The target property to animate.</param>
        /// <param name="relativeValue">The property value will change by this amount.</param>
        /// <param name="startTime">The start time of the animation.</param>
        /// <param name="endTime">The end time of the animation.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <exception cref="ArgumentNullException"> Thrown when target or property or relativeValue is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when it failed to find a property from given string or the given relativeValue is invalid format. </exception>
        /// <since_tizen> 3 </since_tizen>
        public void AnimateBy(View target, string property, object relativeValue, int startTime, int endTime, AlphaFunction alphaFunction = null)
        {
            AnimateBy(target as Animatable, property, relativeValue, startTime, endTime, alphaFunction);
        }

        /// <summary>
        /// Animates a property to a destination value.<br />
        /// </summary>
        /// <param name="target">The target animatable object to animate.</param>
        /// <param name="property">The target property to animate.</param>
        /// <param name="destinationValue">The destination value.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <exception cref="ArgumentNullException"> Thrown when target or property or destinationValue is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when it failed to find a property from given string or the given destinationValue is invalid format. </exception>
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AnimateTo(Animatable target, string property, object destinationValue, AlphaFunction alphaFunction = null)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            if (destinationValue == null)
            {
                throw new ArgumentNullException(nameof(destinationValue));
            }

            using (var result = PropertyHelper.Search(target, property))
            {
                if (result == null)
                {
                    throw new ArgumentException("string property is invalid");
                }

                var current = result;
                while (current != null)
                {

                    var targetValueIntPtr = current.RefineValueIntPtr(destinationValue);
                    if (targetValueIntPtr == global::System.IntPtr.Zero)
                    {
                        throw new ArgumentException("Invalid " + nameof(destinationValue));
                    }
                    AnimateToIntPtr(current.Property, targetValueIntPtr, alphaFunction);
                    Interop.PropertyValue.DeletePropertyValueIntPtr(targetValueIntPtr);
                    current = current.NextResult;
                }
            }
        }

        /// <summary>
        /// Animates a property to a destination value.<br />
        /// </summary>
        /// <param name="target">The target animatable object to animate.</param>
        /// <param name="property">The target property to animate.</param>
        /// <param name="destinationValue">The destination value.</param>
        /// <param name="startTime">The start time of the animation.</param>
        /// <param name="endTime">The end time of the animation.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <exception cref="ArgumentNullException"> Thrown when target or property or destinationValue is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when it failed to find a property from given string or the given destinationValue is invalid format. </exception>
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AnimateTo(Animatable target, string property, object destinationValue, int startTime, int endTime, AlphaFunction alphaFunction = null)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            if (destinationValue == null)
            {
                throw new ArgumentNullException(nameof(destinationValue));
            }

            using (var result = PropertyHelper.Search(target, property))
            {
                if (result == null)
                {
                    throw new ArgumentException("string property is invalid");
                }

                var current = result;
                using (var time = new TimePeriod(startTime, endTime - startTime))
                    while (current != null)
                    {
#if NUI_ANIMATION_PROPERTY_CHANGE_1
                        var targetValueIntPtr = current.RefineValueIntPtr(destinationValue);
                        if (targetValueIntPtr == global::System.IntPtr.Zero)
                        {
                            throw new ArgumentException("Invalid " + nameof(destinationValue));
                        }
                        AnimateToIntPtr(current.Property, targetValueIntPtr, alphaFunction, time);
                        Interop.PropertyValue.DeletePropertyValueIntPtr(targetValueIntPtr);
#else
                        var targetValue = current.RefineValue(destinationValue) ?? throw new ArgumentException("Invalid " + nameof(destinationValue));
                        AnimateTo(current.Property, targetValue, alphaFunction, time);
                        targetValue.Dispose();
#endif
                        current = current.NextResult;
                    }
            }
        }

        /// <summary>
        /// Animates a property to a destination value.<br />
        /// </summary>
        /// <param name="target">The target object to animate.</param>
        /// <param name="property">The target property to animate.</param>
        /// <param name="destinationValue">The destination value.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <exception cref="ArgumentNullException"> Thrown when target or property or destinationValue is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when it failed to find a property from given string or the given destinationValue is invalid format. </exception>
        /// <since_tizen> 3 </since_tizen>
        public void AnimateTo(View target, string property, object destinationValue, AlphaFunction alphaFunction = null)
        {
            AnimateTo(target as Animatable, property, destinationValue, alphaFunction);
        }

        /// <summary>
        /// Animates a property to a destination value.<br />
        /// </summary>
        /// <param name="target">The target object to animate.</param>
        /// <param name="property">The target property to animate.</param>
        /// <param name="destinationValue">The destination value.</param>
        /// <param name="startTime">The start time of the animation.</param>
        /// <param name="endTime">The end time of the animation.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <exception cref="ArgumentNullException"> Thrown when target or property or destinationValue is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when it failed to find a property from given string or the given destinationValue is invalid format. </exception>
        /// <since_tizen> 3 </since_tizen>
        public void AnimateTo(View target, string property, object destinationValue, int startTime, int endTime, AlphaFunction alphaFunction = null)
        {
            AnimateTo(target as Animatable, property, destinationValue, startTime, endTime, alphaFunction);
        }

        /// <summary>
        /// Animates one or more properties to a destination value.<br />
        /// </summary>
        /// <param name="target">The target object to animate.</param>
        /// <exception cref="ArgumentNullException"> Thrown when target is null. </exception>
        public void PlayAnimateTo(View target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            Clear();

            if (null != propertyList && null != destValueList && null != startTimeList && null != endTimeList)
            {
                if (propertyList.Count == destValueList.Count
                    &&
                    startTimeList.Count == endTimeList.Count
                    &&
                    propertyList.Count == startTimeList.Count)
                {
                    int count = propertyList.Count;
                    for (int index = 0; index < count; index++)
                    {
                        var elementType = target.GetType();
                        PropertyInfo propertyInfo = elementType.GetProperties().FirstOrDefault(fi => fi.Name == propertyList[index]);

                        if (propertyInfo != null)
                        {
                            object destinationValue = ConvertTo(destValueList[index], propertyInfo.PropertyType);

                            if (destinationValue != null)
                            {
                                AnimateTo(target, propertyList[index], destinationValue, startTimeList[index], endTimeList[index]);
                            }
                        }
                    }
                    Play();
                }
            }
            else
            {
                if (properties.Length == destValue.Length && startTime.Length == endTime.Length && properties.Length == startTime.Length)
                {
                    int length = properties.Length;
                    for (int index = 0; index < length; index++)
                    {
                        //object destinationValue = _destValue[index];
                        var elementType = target.GetType();
                        PropertyInfo propertyInfo = elementType.GetProperties().FirstOrDefault(fi => fi.Name == properties[index]);
                        //var propertyInfo = elementType.GetRuntimeProperties().FirstOrDefault(p => p.Name == localName);
                        if (propertyInfo != null)
                        {
                            object destinationValue = ConvertTo(destValue[index], propertyInfo.PropertyType);

                            if (destinationValue != null)
                            {
                                AnimateTo(target, properties[index], destinationValue, startTime[index], endTime[index]);
                            }
                        }
                    }
                    Play();
                }
            }
        }

        /// <summary>
        /// Animates a property between keyframes.
        /// </summary>
        /// <param name="target">The target animatable object to animate.</param>
        /// <param name="property">The target property to animate.</param>
        /// <param name="keyFrames">The set of time or value pairs between which to animate.</param>
        /// <param name="interpolation">The method used to interpolate between values.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <exception cref="ArgumentNullException"> Thrown when target or property or keyFrames is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when it failed to find a property from given string or the given keyFrames has invalid value. </exception>
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AnimateBetween(Animatable target, string property, KeyFrames keyFrames, Interpolation interpolation = Interpolation.Linear, AlphaFunction alphaFunction = null)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            if (keyFrames == null)
            {
                throw new ArgumentNullException(nameof(keyFrames));
            }

            using (var result = PropertyHelper.Search(target, property))
            {
                if (result == null)
                {
                    throw new ArgumentException("string property is invalid");
                }

                var current = result;
                while (current != null)
                {
                    // NOTE Do not dispose keyFrames object returned by GetRefinedKeyFrames() here.
                    AnimateBetween(current.Property, current.RefineKeyFrames(keyFrames) ?? throw new ArgumentException("Invalid " + nameof(keyFrames)), alphaFunction, interpolation);
                    current = current.NextResult;
                }
            }
        }

        /// <summary>
        /// Animates a property between keyframes.
        /// </summary>
        /// <param name="target">The target animatable object to animate</param>
        /// <param name="property">The target property to animate</param>
        /// <param name="keyFrames">The set of time/value pairs between which to animate</param>
        /// <param name="startTime">The start time of animation in milliseconds.</param>
        /// <param name="endTime">The end time of animation in milliseconds.</param>
        /// <param name="interpolation">The method used to interpolate between values.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <exception cref="ArgumentNullException"> Thrown when target or property or keyFrames is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when it failed to find a property from given string or the given keyFrames has invalid value. </exception>
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AnimateBetween(Animatable target, string property, KeyFrames keyFrames, int startTime, int endTime, Interpolation interpolation = Interpolation.Linear, AlphaFunction alphaFunction = null)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            if (keyFrames == null)
            {
                throw new ArgumentNullException(nameof(keyFrames));
            }

            using (var result = PropertyHelper.Search(target, property))
            {
                if (result == null)
                {
                    throw new ArgumentException("string property is invalid");
                }

                var current = result;
                using (var time = new TimePeriod(startTime, endTime - startTime))
                    while (current != null)
                    {
                        // NOTE Do not dispose keyFrames object returned by GetRefinedKeyFrames() here.
                        AnimateBetween(current.Property, current.RefineKeyFrames(keyFrames) ?? throw new ArgumentException("Invalid " + nameof(keyFrames)), alphaFunction, time, interpolation);
                        current = current.NextResult;
                    }
            }
        }

        /// <summary>
        /// Animates a property between keyframes.
        /// </summary>
        /// <param name="target">The target object to animate.</param>
        /// <param name="property">The target property to animate.</param>
        /// <param name="keyFrames">The set of time or value pairs between which to animate.</param>
        /// <param name="interpolation">The method used to interpolate between values.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <exception cref="ArgumentNullException"> Thrown when target or property or keyFrames is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when it failed to find a property from given string or the given keyFrames has invalid value. </exception>
        /// <since_tizen> 3 </since_tizen>
        public void AnimateBetween(View target, string property, KeyFrames keyFrames, Interpolation interpolation = Interpolation.Linear, AlphaFunction alphaFunction = null)
        {
            AnimateBetween(target as Animatable, property, keyFrames, interpolation, alphaFunction);
        }

        /// <summary>
        /// Animates a property between keyframes.
        /// </summary>
        /// <param name="target">The target object to animate</param>
        /// <param name="property">The target property to animate</param>
        /// <param name="keyFrames">The set of time/value pairs between which to animate</param>
        /// <param name="startTime">The start time of animation in milliseconds.</param>
        /// <param name="endTime">The end time of animation in milliseconds.</param>
        /// <param name="interpolation">The method used to interpolate between values.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <exception cref="ArgumentNullException"> Thrown when target or property or keyFrames is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when it failed to find a property from given string or the given keyFrames has invalid value. </exception>
        /// <since_tizen> 3 </since_tizen>
        public void AnimateBetween(View target, string property, KeyFrames keyFrames, int startTime, int endTime, Interpolation interpolation = Interpolation.Linear, AlphaFunction alphaFunction = null)
        {
            AnimateBetween(target as Animatable, property, keyFrames, startTime, endTime, interpolation, alphaFunction);
        }

        /// <summary>
        /// Animates the view's position and orientation through a predefined path.<br />
        /// The view will rotate to orient the supplied forward vector with the path's tangent.<br />
        /// If forward is the zero vector then no rotation will happen.<br />
        /// </summary>
        /// <param name="view">The view to animate.</param>
        /// <param name="path">It defines position and orientation.</param>
        /// <param name="forward">The vector (in local space coordinate system) will be oriented with the path's tangent direction.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <since_tizen> 3 </since_tizen>
        public void AnimatePath(View view, Path path, Vector3 forward, AlphaFunction alphaFunction = null)
        {
            if (alphaFunction == null)
            {
                Animate(view, path, forward);
            }
            else
            {
                Animate(view, path, forward, alphaFunction);
            }
        }

        /// <summary>
        /// Animates the view's position and orientation through a predefined path.<br />
        /// The view will rotate to orient the supplied forward vector with the path's tangent.<br />
        /// If forward is the zero vector then no rotation will happen.<br />
        /// </summary>
        /// <param name="view">The view to animate.</param>
        /// <param name="path">It defines position and orientation.</param>
        /// <param name="forward">The vector (in local space coordinate system) will be oriented with the path's tangent direction.</param>
        /// <param name="startTime">The start time of the animation.</param>
        /// <param name="endTime">The end time of the animation.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <since_tizen> 3 </since_tizen>
        public void AnimatePath(View view, Path path, Vector3 forward, int startTime, int endTime, AlphaFunction alphaFunction = null)
        {
            TimePeriod time = new TimePeriod(startTime, endTime - startTime);
            if (alphaFunction == null)
            {
                Animate(view, path, forward, time);
            }
            else
            {
                Animate(view, path, forward, alphaFunction, time);
            }
            time.Dispose();
        }

        /// <summary>
        /// Creates an initialized animation.<br />
        /// The animation will not loop.<br />
        /// The default end action is "Cancel".<br />
        /// The default alpha function is linear.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Animation() : this(Interop.Animation.New(0.0f), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Plays the animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Play()
        {
            Interop.Animation.Play(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (DisableAnimation == true)
                Stop(EndActions.StopFinal);
        }

        /// <summary>
        /// Plays the animation from a given point.<br />
        /// The progress must be in the 0-1 interval or in the play range interval if defined,
        /// otherwise, it will be ignored.<br />
        /// </summary>
        /// <param name="progress">A value between [0,1], or between the play range if specified, from where the animation should start playing.</param>
        /// <since_tizen> 3 </since_tizen>
        public void PlayFrom(float progress)
        {
            Interop.Animation.PlayFrom(SwigCPtr, progress);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Plays the animation after a given delay time.<br/>
        /// The delay time is not included in the looping time.<br/>
        /// When the delay time is a negative value, it would treat as play immediately.<br/>
        /// </summary>
        /// <param name="delayMilliseconds">The delay time.</param>
        /// <since_tizen> 4 </since_tizen>
        public void PlayAfter(int delayMilliseconds)
        {
            Interop.Animation.PlayAfter(SwigCPtr, MilliSecondsToSeconds(delayMilliseconds));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Pauses the animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Pause()
        {
            Interop.Animation.Pause(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stops the animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Stop()
        {
            Interop.Animation.Stop(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears the animation.<br />
        /// This disconnects any objects that were being animated, effectively stopping the animation.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Clear()
        {
            Interop.Animation.Clear(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal object ConvertTo(object value, Type toType)
        {
            Func<object> getConverter = () =>
            {
                string converterTypeName = GetTypeConverterTypeName(toType.GetTypeInfo().CustomAttributes);
                if (converterTypeName == null)
                    return null;

                Type convertertype = Type.GetType(converterTypeName);
                return Activator.CreateInstance(convertertype);
            };

            return ConvertTo(value, toType, getConverter);
        }

        internal object ConvertTo(object value, Type toType, Func<object> getConverter)
        {
            if (value == null)
                return null;

            var str = value as string;
            if (str != null)
            {
                //If there's a [TypeConverter], use it
                object converter = getConverter?.Invoke();
                var xfTypeConverter = converter as Tizen.NUI.Binding.TypeConverter;
                if (xfTypeConverter != null)
                    return value = xfTypeConverter.ConvertFromInvariantString(str);
                var converterType = converter?.GetType();
                if (converterType != null)
                {
                    var convertFromStringInvariant = converterType.GetRuntimeMethod("ConvertFromInvariantString",
                        new[] { typeof(string) });
                    if (convertFromStringInvariant != null)
                        return value = convertFromStringInvariant.Invoke(converter, new object[] { str });
                }

                //If the type is nullable, as the value is not null, it's safe to assume we want the built-in conversion
                if (toType.GetTypeInfo().IsGenericType && toType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    toType = Nullable.GetUnderlyingType(toType);

                //Obvious Built-in conversions
                if (toType.GetTypeInfo().IsEnum)
                    return Enum.Parse(toType, str, true);
                if (toType == typeof(SByte))
                    return SByte.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Int16))
                    return Int16.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Int32))
                    return Int32.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Int64))
                    return Int64.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Byte))
                    return Byte.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(UInt16))
                    return UInt16.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(UInt32))
                    return UInt32.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(UInt64))
                    return UInt64.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Single))
                    return Single.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Double))
                    return Double.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Boolean))
                    return Boolean.Parse(str);
                if (toType == typeof(TimeSpan))
                    return TimeSpan.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(DateTime))
                    return DateTime.Parse(str, CultureInfo.InvariantCulture);
                if (toType == typeof(Char))
                {
                    char c = '\0';
                    _ = Char.TryParse(str, out c);
                    return c;
                }
                if (toType == typeof(String) && str.StartsWith("{}", StringComparison.Ordinal))
                    return str.Substring(2);
                if (toType == typeof(String))
                    return value;
                if (toType == typeof(Decimal))
                    return Decimal.Parse(str, CultureInfo.InvariantCulture);
            }

            //if the value is not assignable and there's an implicit conversion, convert
            if (value != null && !toType.IsAssignableFrom(value.GetType()))
            {
                var opImplicit = GetImplicitConversionOperator(value.GetType(), value.GetType(), toType)
                                 ?? GetImplicitConversionOperator(toType, value.GetType(), toType);
                //var opImplicit = value.GetType().GetImplicitConversionOperator(fromType: value.GetType(), toType: toType)
                //                ?? toType.GetImplicitConversionOperator(fromType: value.GetType(), toType: toType);

                if (opImplicit != null)
                {
                    value = opImplicit.Invoke(null, new[] { value });
                    return value;
                }
            }

            return value;
        }

        internal string GetTypeConverterTypeName(IEnumerable<CustomAttributeData> attributes)
        {
            var converterAttribute =
                attributes.FirstOrDefault(cad => Tizen.NUI.Binding.TypeConverterAttribute.TypeConvertersType.Contains(cad.AttributeType.FullName));
            if (converterAttribute == null)
                return null;
            if (converterAttribute.ConstructorArguments[0].ArgumentType == typeof(string))
                return (string)converterAttribute.ConstructorArguments[0].Value;
            if (converterAttribute.ConstructorArguments[0].ArgumentType == typeof(Type))
                return ((Type)converterAttribute.ConstructorArguments[0].Value).AssemblyQualifiedName;
            return null;
        }

        internal MethodInfo GetImplicitConversionOperator(Type onType, Type fromType, Type toType)
        {
#if NETSTANDARD1_0
            var mi = onType.GetRuntimeMethod("op_Implicit", new[] { fromType });
#else
            var bindingFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;
            var mi = onType.GetMethod("op_Implicit", bindingFlags, null, new[] { fromType }, null);
#endif
            if (mi == null) return null;
            if (!mi.IsSpecialName) return null;
            if (!mi.IsPublic) return null;
            if (!mi.IsStatic) return null;
            if (!toType.IsAssignableFrom(mi.ReturnType)) return null;

            return mi;
        }

        internal Animation(float durationSeconds) : this(Interop.Animation.New(durationSeconds), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal Animation(Animation handle) : this(Interop.Animation.NewAnimation(Animation.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Animation Assign(Animation rhs)
        {
            Animation ret = new Animation(Interop.Animation.Assign(SwigCPtr, Animation.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetDuration(float seconds)
        {
            Interop.Animation.SetDuration(SwigCPtr, seconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetDuration()
        {
            float ret = Interop.Animation.GetDuration(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetLooping(bool looping)
        {
            Interop.Animation.SetLooping(SwigCPtr, looping);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetLoopCount(int count)
        {
            Interop.Animation.SetLoopCount(SwigCPtr, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal int GetLoopCount()
        {
            int ret = Interop.Animation.GetLoopCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal int GetCurrentLoop()
        {
            int ret = Interop.Animation.GetCurrentLoop(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool IsLooping()
        {
            bool ret = Interop.Animation.IsLooping(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetEndAction(Animation.EndActions action)
        {
            Interop.Animation.SetEndAction(SwigCPtr, (int)action);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Animation.EndActions GetEndAction()
        {
            Animation.EndActions ret = (Animation.EndActions)Interop.Animation.GetEndAction(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetDisconnectAction(Animation.EndActions disconnectAction)
        {
            Interop.Animation.SetDisconnectAction(SwigCPtr, (int)disconnectAction);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Animation.EndActions GetDisconnectAction()
        {
            Animation.EndActions ret = (Animation.EndActions)Interop.Animation.GetDisconnectAction(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetDefaultAlphaFunction(AlphaFunction alpha)
        {
            Interop.Animation.SetDefaultAlphaFunction(SwigCPtr, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal AlphaFunction GetDefaultAlphaFunction()
        {
            AlphaFunction ret = new AlphaFunction(Interop.Animation.GetDefaultAlphaFunction(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetCurrentProgress(float progress)
        {
            Interop.Animation.SetCurrentProgress(SwigCPtr, progress);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetCurrentProgress()
        {
            float ret = Interop.Animation.GetCurrentProgress(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetSpeedFactor(float factor)
        {
            Interop.Animation.SetSpeedFactor(SwigCPtr, factor);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetSpeedFactor()
        {
            float ret = Interop.Animation.GetSpeedFactor(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetPlayRange(Vector2 range)
        {
            Interop.Animation.SetPlayRange(SwigCPtr, Vector2.getCPtr(range));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2 GetPlayRange()
        {
            Vector2 ret = new Vector2(Interop.Animation.GetPlayRange(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Animation.States GetState()
        {
            Animation.States ret = (Animation.States)Interop.Animation.GetState(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AnimationSignal FinishedSignal()
        {
            AnimationSignal ret = new AnimationSignal(Interop.Animation.FinishedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AnimationSignal ProgressReachedSignal()
        {
            AnimationSignal ret = new AnimationSignal(Interop.Animation.ProgressReachedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void AnimateBy(Property target, PropertyValue relativeValue, AlphaFunction alpha)
        {
            if (alpha == null)
            {
                Interop.Animation.AnimateBy(SwigCPtr, Property.getCPtr(target), PropertyValue.getCPtr(relativeValue));
            }
            else
            {
                Interop.Animation.AnimateByAlphaFunction(SwigCPtr, Property.getCPtr(target), PropertyValue.getCPtr(relativeValue), AlphaFunction.getCPtr(alpha));
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AnimateBy(Property target, PropertyValue relativeValue, AlphaFunction alpha, TimePeriod period)
        {
            if (alpha == null)
            {
                Interop.Animation.AnimateByTimePeriod(SwigCPtr, Property.getCPtr(target), PropertyValue.getCPtr(relativeValue), TimePeriod.getCPtr(period));
            }
            else
            {
                Interop.Animation.AnimateBy(SwigCPtr, Property.getCPtr(target), PropertyValue.getCPtr(relativeValue), AlphaFunction.getCPtr(alpha), TimePeriod.getCPtr(period));
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AnimateTo(Property target, PropertyValue destinationValue, AlphaFunction alpha)
        {
            if (alpha == null)
            {
                Interop.Animation.AnimateTo(SwigCPtr, Property.getCPtr(target), PropertyValue.getCPtr(destinationValue));
            }
            else
            {
                Interop.Animation.AnimateToAlphaFunction(SwigCPtr, Property.getCPtr(target), PropertyValue.getCPtr(destinationValue), AlphaFunction.getCPtr(alpha));
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AnimateTo(Property target, PropertyValue destinationValue, AlphaFunction alpha, TimePeriod period)
        {
            if (alpha == null)
            {
                Interop.Animation.AnimateToTimePeriod(SwigCPtr, Property.getCPtr(target), PropertyValue.getCPtr(destinationValue), TimePeriod.getCPtr(period));
            }
            else
            {
                Interop.Animation.AnimateTo(SwigCPtr, Property.getCPtr(target), PropertyValue.getCPtr(destinationValue), AlphaFunction.getCPtr(alpha), TimePeriod.getCPtr(period));
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        internal void AnimateByIntPtr(Property target, global::System.IntPtr relativeValueIntPtr, AlphaFunction alpha)
        {
            if (alpha == null)
            {
                Interop.Animation.AnimateBy(SwigCPtr, Property.getCPtr(target), relativeValueIntPtr);
            }
            else
            {
                Interop.Animation.AnimateByAlphaFunction(SwigCPtr, Property.getCPtr(target), relativeValueIntPtr, AlphaFunction.getCPtr(alpha));
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AnimateByIntPtr(Property target, global::System.IntPtr relativeValueIntPtr, AlphaFunction alpha, TimePeriod period)
        {
            if (alpha == null)
            {
                Interop.Animation.AnimateByTimePeriod(SwigCPtr, Property.getCPtr(target), relativeValueIntPtr, TimePeriod.getCPtr(period));
            }
            else
            {
                Interop.Animation.AnimateBy(SwigCPtr, Property.getCPtr(target), relativeValueIntPtr, AlphaFunction.getCPtr(alpha), TimePeriod.getCPtr(period));
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AnimateToIntPtr(Property target, global::System.IntPtr destinationValueIntPtr, AlphaFunction alpha)
        {
            if (alpha == null)
            {
                Interop.Animation.AnimateTo(SwigCPtr, Property.getCPtr(target), destinationValueIntPtr);
            }
            else
            {
                Interop.Animation.AnimateToAlphaFunction(SwigCPtr, Property.getCPtr(target), destinationValueIntPtr, AlphaFunction.getCPtr(alpha));
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AnimateToIntPtr(Property target, global::System.IntPtr destinationValueIntPtr, AlphaFunction alpha, TimePeriod period)
        {
            if (alpha == null)
            {
                Interop.Animation.AnimateToTimePeriod(SwigCPtr, Property.getCPtr(target), destinationValueIntPtr, TimePeriod.getCPtr(period));
            }
            else
            {
                Interop.Animation.AnimateTo(SwigCPtr, Property.getCPtr(target), destinationValueIntPtr, AlphaFunction.getCPtr(alpha), TimePeriod.getCPtr(period));
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AnimateBetween(Property target, KeyFrames keyFrames)
        {
            Interop.Animation.AnimateBetween(SwigCPtr, Property.getCPtr(target), KeyFrames.getCPtr(keyFrames));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AnimateBetween(Property target, KeyFrames keyFrames, AlphaFunction alpha)
        {
            Interop.Animation.AnimateBetweenAlphaFunction(SwigCPtr, Property.getCPtr(target), KeyFrames.getCPtr(keyFrames), AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AnimateBetween(Property target, KeyFrames keyFrames, AlphaFunction alpha, Animation.Interpolation interpolation)
        {
            if (alpha == null)
            {
                Interop.Animation.AnimateBetween(SwigCPtr, Property.getCPtr(target), KeyFrames.getCPtr(keyFrames), (int)interpolation);
            }
            else
            {
                Interop.Animation.AnimateBetweenAlphaFunctionInterpolation(SwigCPtr, Property.getCPtr(target), KeyFrames.getCPtr(keyFrames), AlphaFunction.getCPtr(alpha), (int)interpolation);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AnimateBetween(Property target, KeyFrames keyFrames, TimePeriod period)
        {
            Interop.Animation.AnimateBetweenTimePeriod(SwigCPtr, Property.getCPtr(target), KeyFrames.getCPtr(keyFrames), TimePeriod.getCPtr(period));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AnimateBetween(Property target, KeyFrames keyFrames, AlphaFunction alpha, TimePeriod period)
        {
            Interop.Animation.AnimateBetween(SwigCPtr, Property.getCPtr(target), KeyFrames.getCPtr(keyFrames), AlphaFunction.getCPtr(alpha), TimePeriod.getCPtr(period));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AnimateBetween(Property target, KeyFrames keyFrames, AlphaFunction alpha, TimePeriod period, Animation.Interpolation interpolation)
        {
            if (alpha == null)
            {
                Interop.Animation.AnimateBetweenTimePeriodInterpolation(SwigCPtr, Property.getCPtr(target), KeyFrames.getCPtr(keyFrames), TimePeriod.getCPtr(period), (int)interpolation);
            }
            else
            {
                Interop.Animation.AnimateBetween(SwigCPtr, Property.getCPtr(target), KeyFrames.getCPtr(keyFrames), AlphaFunction.getCPtr(alpha), TimePeriod.getCPtr(period), (int)interpolation);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Animate(View view, Path path, Vector3 forward)
        {
            Interop.Animation.Animate(SwigCPtr, View.getCPtr(view), Path.getCPtr(path), Vector3.getCPtr(forward));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Animate(View view, Path path, Vector3 forward, AlphaFunction alpha)
        {
            Interop.Animation.AnimateAlphaFunction(SwigCPtr, View.getCPtr(view), Path.getCPtr(path), Vector3.getCPtr(forward), AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Animate(View view, Path path, Vector3 forward, TimePeriod period)
        {
            Interop.Animation.AnimateTimePeriod(SwigCPtr, View.getCPtr(view), Path.getCPtr(path), Vector3.getCPtr(forward), TimePeriod.getCPtr(period));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Animate(View view, Path path, Vector3 forward, AlphaFunction alpha, TimePeriod period)
        {
            Interop.Animation.Animate(SwigCPtr, View.getCPtr(view), Path.getCPtr(path), Vector3.getCPtr(forward), AlphaFunction.getCPtr(alpha), TimePeriod.getCPtr(period));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Show(View view, float delaySeconds)
        {
            Interop.Animation.Show(SwigCPtr, View.getCPtr(view), delaySeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Hide(View view, float delaySeconds)
        {
            Interop.Animation.Hide(SwigCPtr, View.getCPtr(view), delaySeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// To make animation instance be disposed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (animationFinishedEventHandler != null)
            {
                AnimationSignal finishedSignal = FinishedSignal();
                finishedSignal?.Disconnect(finishedCallbackOfNative);
                finishedSignal?.Dispose();
                animationFinishedEventHandler = null;
            }

            if (animationProgressReachedEventCallback != null)
            {
                AnimationSignal progressReachedSignal = ProgressReachedSignal();
                progressReachedSignal?.Disconnect(animationProgressReachedEventCallback);
                progressReachedSignal?.Dispose();
                animationProgressReachedEventCallback = null;
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            if (swigCPtr.Handle == IntPtr.Zero || Disposed)
            {
                Tizen.Log.Fatal("NUI", $"[ERROR] Animation ReleaseSwigCPtr()! IntPtr=0x{swigCPtr.Handle:X} Disposed={Disposed}");
                return;
            }
            Interop.Animation.DeleteAnimation(swigCPtr);
        }

        private void OnFinished(IntPtr data)
        {
            if (animationFinishedEventHandler != null)
            {
                //here we send all data to user event handlers
                animationFinishedEventHandler(this, null);
            }
        }

        private void OnProgressReached(IntPtr data)
        {
            if (animationProgressReachedEventHandler != null)
            {
                //here we send all data to user event handlers
                animationProgressReachedEventHandler(this, null);
            }
        }

        private float MilliSecondsToSeconds(int millisec)
        {
            return (float)millisec / 1000.0f;
        }

        private int SecondsToMilliSeconds(float sec)
        {
            return (int)(sec * 1000);
        }
    }
}
