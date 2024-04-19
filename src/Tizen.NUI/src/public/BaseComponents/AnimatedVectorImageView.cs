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

using global::System;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// AnimatedVectorImageView is a class for displaying a vector resource.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AnimatedVectorImageView : LottieAnimationView
    {
        #region Constructor, Destructor, Dispose

        static AnimatedVectorImageView()
        {
            //to get "IsUsingXaml" feature working at preload, we need to remove readonly for BindableProperty.
            //this AnimatedVectorImageView is not preloaded.
            if (NUIApplication.IsUsingXaml)
            {
                ResourceURLProperty = BindableProperty.Create(nameof(ResourceURL), typeof(string), typeof(AnimatedVectorImageView), string.Empty,
                    propertyChanged: SetInternalResourceURLProperty, defaultValueCreator: GetInternalResourceURLProperty);

                ResourceUrlProperty = BindableProperty.Create(nameof(ResourceUrl), typeof(string), typeof(AnimatedVectorImageView), string.Empty,
                    propertyChanged: SetInternalResourceUrlProperty, defaultValueCreator: GetInternalResourceUrlProperty);

                RepeatCountProperty = BindableProperty.Create(nameof(RepeatCount), typeof(int), typeof(AnimatedVectorImageView), 0,
                    propertyChanged: SetInternalRepeatCountProperty, defaultValueCreator: GetInternalRepeatCountProperty);

                CurrentFrameProperty = BindableProperty.Create(nameof(CurrentFrame), typeof(int), typeof(AnimatedVectorImageView), 0,
                    propertyChanged: SetInternalCurrentFrameProperty, defaultValueCreator: GetInternalCurrentFrameProperty);

                RepeatModeProperty = BindableProperty.Create(nameof(RepeatMode), typeof(RepeatModes), typeof(AnimatedVectorImageView), default(RepeatModes),
                    propertyChanged: SetInternalRepeatModeProperty, defaultValueCreator: GetInternalRepeatModeProperty);
            }
        }

        /// <summary>
        /// Construct VectorAnimationView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatedVectorImageView() : base()
        {
            NUILog.Debug($"[AnimatedVectorImageView START[ constructor objId={GetId()} ] END]");
        }

        /// <summary>
        /// Construct VectorAnimationView.
        /// </summary>
        /// <param name="scale">Set scaling factor for Vector Animation, while creating.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatedVectorImageView(float scale) : base(scale)
        {
            NUILog.Debug($"[AnimatedVectorImageView START[ constructor scale={scale}) objId={GetId()} ] END]");
        }

        /// <summary>
        /// You can override it to clean-up your own resources
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }
            NUILog.Debug($"AnimatedVectorImageView START");

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            base.Dispose(type);

            NUILog.Debug($"AnimatedVectorImageView END");
        }
        #endregion Constructor, Destructor, Dispose


        #region Property
        /// <summary>
        /// Set Resource URL
        /// </summary>
        // Suppress warning : This has been being used by users, so that the interface can not be changed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ResourceURL
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ResourceURLProperty) as string;
                }
                else
                {
                    return GetInternalResourceURLProperty(this) as string;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ResourceURLProperty, value);
                }
                else
                {
                    SetInternalResourceURLProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private string InternalResourceURL
        {
            set
            {
                NUILog.Debug($"[AnimatedVectorImageView START[ [{GetId()}] ResourceURL SET");

                if (value == resourceUrl)
                {
                    NUILog.Debug($"set same URL! ");
                    return;
                }
                resourceUrl = (value == null) ? "" : value;
                URL = resourceUrl;
                isMinMaxFrameSet = minMaxSetTypes.NotSetByUser;
                NUILog.Debug($" [{GetId()}] resourceUrl={resourceUrl}) ]AnimatedVectorImageView END]");
            }
            get => resourceUrl;
        }

        /// <summary>
        /// Set Resource URL
        /// </summary>
        // Suppress warning : This has been being used by users, so that the interface can not be changed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string ResourceUrl
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ResourceUrlProperty) as string;
                }
                else
                {
                    return GetInternalResourceUrlProperty(this) as string;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ResourceUrlProperty, value);
                }
                else
                {
                    SetInternalResourceUrlProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private string InternalResourceUrl
        {
            set
            {
                NUILog.Debug($"[AnimatedVectorImageView START[ [{GetId()}] ResourceUrl SET");
                this.ResourceURL = value;
                NUILog.Debug($" [{GetId()}] value={value}) ]AnimatedVectorImageView END]");
            }
            get
            {
                NUILog.Debug($"[AnimatedVectorImageView [ [{GetId()}] ResourceUrl GET");
                return this.ResourceURL;
            }
        }


        /// <summary>
        /// RepeatCount of animation.
        /// The repeat count is 0 by default.
        /// If the RepeatCount is 0, the animation is never repeated.
        /// If the RepeatCount is greater than 0, the repeat mode will be taken into account.
        /// If RepeatCount is -1, animation is infinite loops.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RepeatCount
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(RepeatCountProperty);
                }
                else
                {
                    return (int)GetInternalRepeatCountProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RepeatCountProperty, value);
                }
                else
                {
                    SetInternalRepeatCountProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private int InternalRepeatCount
        {
            set
            {
                NUILog.Debug($"[AnimatedVectorImageView START[ [{GetId()}] RepeatCount SET");

                repeatCnt = (value < -1) ? -1 : value;
                LoopCount = (repeatCnt < 0) ? repeatCnt : repeatCnt + 1;

                NUILog.Debug($"[{GetId()}] repeatCnt={repeatCnt} ]AnimatedVectorImageView END]");
            }
            get => repeatCnt;
        }

        /// <summary>
        /// TotalFrame of animation.
        /// If resouce is still not be loaded, or invalid resource, the value is 0.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int TotalFrame
        {
            get => totalFrameNum;
        }

        private int totalFrameNum
        {
            get => base.TotalFrame;
        }

        /// <summary>
        /// CurrentFrame of animation.
        /// </summary>
        /// <returns> Returns user set value for the current frame. Cannot provide actual playing current frame. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int CurrentFrame
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(CurrentFrameProperty);
                }
                else
                {
                    return (int)GetInternalCurrentFrameProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CurrentFrameProperty, value);
                }
                else
                {
                    SetInternalCurrentFrameProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private int InternalCurrentFrame
        {
            set
            {
                NUILog.Debug($"[AnimatedVectorImageView START[ [{GetId()}] CurrentFrame SET");

                if (string.IsNullOrEmpty(resourceUrl))
                {
                    throw new InvalidOperationException("Resource Url not yet Set");
                }

                if (value < 0)
                {
                    value = 0;
                }

                innerCurrentFrame = value;
                AnimationState = AnimationStates.Paused;

                base.SetMinMaxFrame(0, IntegerMaxValue);
                base.CurrentFrame = innerCurrentFrame;

                NUILog.Debug($" [{GetId()}] innerCurrentFrame={innerCurrentFrame}) ]AnimatedVectorImageView END]");
            }
            get => innerCurrentFrame;
        }

        /// <summary>
        /// RepeatMode of animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RepeatModes RepeatMode
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (RepeatModes)GetValue(RepeatModeProperty);
                }
                else
                {
                    return (RepeatModes)GetInternalRepeatModeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RepeatModeProperty, value);
                }
                else
                {
                    SetInternalRepeatModeProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private RepeatModes InternalRepeatMode
        {
            set
            {
                NUILog.Debug($"[AnimatedVectorImageView START[ [{GetId()}] RepeatMode SET");
                repeatMode = value;

                switch (repeatMode)
                {
                    case RepeatModes.Restart:
                        LoopingMode = LoopingModeType.Restart;
                        break;
                    case RepeatModes.Reverse:
                        LoopingMode = LoopingModeType.AutoReverse;
                        break;
                    default:
                        LoopingMode = LoopingModeType.Restart;
                        break;
                }

                NUILog.Debug($" [{GetId()}] repeatMode={repeatMode}) ]AnimatedVectorImageView END]");
            }
            get => repeatMode;
        }

        /// <summary>
        /// Get state of animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimationStates AnimationState
        {
            private set
            {
                CurrentAnimationState = value;
            }
            get
            {
                if (CurrentAnimationState == AnimationStates.Playing)
                {
                    if (PlayState == PlayStateType.Stopped)
                    {
                        CurrentAnimationState = AnimationStates.Stopped;
                    }
                }
                return CurrentAnimationState;
            }
        }
        #endregion Property


        #region Method
        /// <summary>
        /// Set minimum frame and maximum frame
        /// </summary>
        /// <param name="minFrame">minimum frame.</param>
        /// <param name="maxFrame">maximum frame.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinAndMaxFrame(int minFrame, int maxFrame)
        {
            NUILog.Debug($"[AnimatedVectorImageView START[ [{GetId()}] SetMinAndMaxFrame({minFrame}, {maxFrame})");

            minimumFrame = (minFrame) > 0 ? minFrame : 0;
            maximumFrame = (maxFrame) > 0 ? maxFrame : 0;
            isMinMaxFrameSet = minMaxSetTypes.SetByMinAndMaxFrameMethod;

            // Remove marker information.
            minimumFrameMarker = null;
            maximumFrameMarker = null;

            if (minimumFrame > maximumFrame)
            {
                NUILog.Debug($" [{GetId()}] minimumFrame:{minimumFrame} > maximumFrame:{maximumFrame}) ]AnimatedVectorImageView END]");
                return;
            }

            NUILog.Debug($" [{GetId()}] minimumFrame:{minimumFrame}, maximumFrame:{maximumFrame}) ]AnimatedVectorImageView END]");
        }

        /// <summary>
        /// Set minimum frame and maximum frame by marker.
        /// Animation will play between the start frame and the end frame of the marker if one marker is specified.
        /// Or animation will play between the start frame of the first marker and the end frame of the second marker if two markers are specified.
        /// </summary>
        /// <remarks>
        /// If we use invaliad markers, or we load image asynchronous and load is not finished yet,
        /// CurrentFrame might not be matched with real value.
        /// </remarks>
        /// <param name="marker1">First marker</param>
        /// <param name="marker2">Second marker</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinAndMaxFrameByMarker(string marker1, string marker2 = null)
        {
            NUILog.Debug($"[AnimatedVectorImageView START[ [{GetId()}] SetMinAndMaxFrameByMarker({marker1}, {marker2})");

            minimumFrameMarker = marker1;
            maximumFrameMarker = marker2;
            isMinMaxFrameSet = minMaxSetTypes.SetByMinAndMaxFrameByMarkerMethod;

            // Remove frame information.
            minimumFrame = -1;
            maximumFrame = -1;

            NUILog.Debug($" [{GetId()}] minimumFrameMarker:{minimumFrameMarker}, maximumFrameMarker:{maximumFrameMarker}) ]AnimatedVectorImageView END]");
        }

        /// <summary>
        /// SetMinMaxFrame(int startFrame, int endFrame)
        /// </summary>
        /// <param name="minFrame"></param>
        /// <param name="maxFrame"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void SetMinMaxFrame(int minFrame, int maxFrame)
        {
            NUILog.Debug($"SetMinMaxFrame({minFrame}, {maxFrame})!!!");

            minimumFrame = (minFrame) > 0 ? minFrame : 0;
            maximumFrame = (maxFrame) > 0 ? maxFrame : 0;
            isMinMaxFrameSet = minMaxSetTypes.SetByBaseSetMinMaxFrameMethod;

            // Remove marker information.
            minimumFrameMarker = null;
            maximumFrameMarker = null;

            if (minimumFrame >= totalFrameNum)
            {
                minimumFrame = totalFrameNum - 1;
            }

            if (maximumFrame >= totalFrameNum)
            {
                maximumFrame = totalFrameNum - 1;
            }

            base.SetMinMaxFrame(minimumFrame, maximumFrame);
        }

        /// <summary>
        /// A marker has its start frame and end frame.
        /// Animation will play between the start frame and the end frame of the marker if one marker is specified.
        /// Or animation will play between the start frame of the first marker and the end frame of the second marker if two markers are specified.
        /// </summary>
        /// <param name="marker1">First marker</param>
        /// <param name="marker2">Second marker</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void SetMinMaxFrameByMarker(string marker1, string marker2 = null)
        {
            NUILog.Debug($"SetMinMaxFrameByMarker({marker1}, {marker2})");

            minimumFrameMarker = marker1;
            maximumFrameMarker = marker2;
            isMinMaxFrameSet = minMaxSetTypes.SetByMarker;

            // Remove frame information.
            minimumFrame = -1;
            maximumFrame = -1;

            base.SetMinMaxFrameByMarker(marker1, marker2);
        }

        /// <summary>
        /// Play Animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Play()
        {
            NUILog.Debug($"[AnimatedVectorImageView START[ [{GetId()}] AnimationState={AnimationState}, PlayState={PlayState}");

            if (string.IsNullOrEmpty(resourceUrl))
            {
                throw new InvalidOperationException("Resource Url not yet Set");
            }

            switch (isMinMaxFrameSet)
            {
                case minMaxSetTypes.NotSetByUser:
                    base.SetMinMaxFrame(0, totalFrameNum - 1);
                    base.CurrentFrame = 0;
                    innerCurrentFrame = 0;
                    break;

                case minMaxSetTypes.SetByMinAndMaxFrameByMarkerMethod:
                    base.SetMinMaxFrameByMarker(minimumFrameMarker, maximumFrameMarker);
                    if (GetFrameValueFromMarkerInfo())
                    {
                        base.CurrentFrame = minimumFrame;
                        innerCurrentFrame = minimumFrame;
                    }
                    else
                    {
                        Tizen.Log.Error("NUI", $"[Warning] Play with invalid marker! Current frame become 0\n");
                        base.CurrentFrame = 0;
                        innerCurrentFrame = 0;
                    }
                    break;

                case minMaxSetTypes.SetByMinAndMaxFrameMethod:
                    base.SetMinMaxFrame(minimumFrame, maximumFrame);
                    base.CurrentFrame = minimumFrame;
                    innerCurrentFrame = minimumFrame;
                    break;

                case minMaxSetTypes.SetByMarker:
                case minMaxSetTypes.SetByBaseSetMinMaxFrameMethod:
                default:
                    //do nothing!
                    break;
            }

            base.Play();
            AnimationState = AnimationStates.Playing;

            NUILog.Debug($" [{GetId()}] isMinMaxFrameSet={isMinMaxFrameSet}) ]AnimatedVectorImageView END]");
        }

        /// <summary>
        /// Pause Animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Pause()
        {
            NUILog.Debug($"[AnimatedVectorImageView START[ [{GetId()}] AnimationState={AnimationState}, PlayState={PlayState}");

            if (string.IsNullOrEmpty(resourceUrl))
            {
                throw new InvalidOperationException("Resource Url not yet Set");
            }

            base.Pause();
            AnimationState = AnimationStates.Paused;

            NUILog.Debug($" [{GetId()}] ]AnimatedVectorImageView END]");
        }

        /// <summary>
        /// Stop Animation.
        /// </summary>
        /// <param name="endAction">Defines, what should be behaviour after cancel operation
        /// End action is Cancel, Animation Stops at the Current Frame.
        /// End action is Discard, Animation Stops at the Min Frame
        /// End action is StopFinal, Animation Stops at the Max Frame
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Stop(EndActions endAction = EndActions.Cancel)
        {
            NUILog.Debug($"[AnimatedVectorImageView START[ [{GetId()}] endAction:({endAction}), PlayState={PlayState}");

            if (string.IsNullOrEmpty(resourceUrl))
            {
                throw new InvalidOperationException("Resource Url not yet Set");
            }

            if (AnimationState == AnimationStates.Stopped)
            {
                return;
            }

            if (innerEndAction != endAction)
            {
                innerEndAction = endAction;
                switch (endAction)
                {
                    case EndActions.Cancel:
                        StopBehavior = StopBehaviorType.CurrentFrame;
                        break;
                    case EndActions.Discard:
                        StopBehavior = StopBehaviorType.MinimumFrame;
                        break;
                    case EndActions.StopFinal:
                        StopBehavior = StopBehaviorType.MaximumFrame;
                        break;
                    default:
                        NUILog.Debug($" [{GetId()}] no endAction : default set");
                        break;
                }
            }
            AnimationState = AnimationStates.Stopped;

            base.Stop();

            NUILog.Debug($"isMinMaxFrameSet:{isMinMaxFrameSet}, base.CurrentFrame:{base.CurrentFrame}, totalFrameNum:{totalFrameNum}, minimumFrame:{minimumFrame}, maximumFrame:{maximumFrame}, StopBehavior:{StopBehavior}, endAction:{endAction}");

            switch (isMinMaxFrameSet)
            {
                case minMaxSetTypes.NotSetByUser:
                    switch (endAction)
                    {
                        case EndActions.Cancel:
                            innerCurrentFrame = base.CurrentFrame;
                            break;
                        case EndActions.Discard:
                            base.CurrentFrame = innerCurrentFrame = 0;
                            break;
                        case EndActions.StopFinal:
                            base.CurrentFrame = innerCurrentFrame = totalFrameNum - 1;
                            break;
                    }
                    break;

                case minMaxSetTypes.SetByMinAndMaxFrameByMarkerMethod:
                    if (GetFrameValueFromMarkerInfo())
                    {
                        goto case minMaxSetTypes.SetByMinAndMaxFrameMethod;
                    }
                    else
                    {
                        switch (endAction)
                        {
                            case EndActions.Cancel:
                                innerCurrentFrame = base.CurrentFrame;
                                break;
                            case EndActions.Discard:
                                Tizen.Log.Error("NUI", $"[Warning] Stop(Discard) with invalid marker! Current frame become 0\n");
                                base.CurrentFrame = innerCurrentFrame = 0;
                                break;
                            case EndActions.StopFinal:
                                Tizen.Log.Error("NUI", $"[Warning] Stop(StopFinal) with invalid marker! Current frame become {totalFrameNum - 1}\n");
                                base.CurrentFrame = innerCurrentFrame = totalFrameNum - 1;
                                break;
                        }
                        break;
                    }

                case minMaxSetTypes.SetByMinAndMaxFrameMethod:
                    switch (endAction)
                    {
                        case EndActions.Cancel:
                            innerCurrentFrame = base.CurrentFrame;
                            break;
                        case EndActions.Discard:
                            base.CurrentFrame = innerCurrentFrame = minimumFrame;
                            break;
                        case EndActions.StopFinal:
                            base.CurrentFrame = innerCurrentFrame = maximumFrame;
                            break;
                    }
                    break;

                case minMaxSetTypes.SetByMarker:
                case minMaxSetTypes.SetByBaseSetMinMaxFrameMethod:
                default:
                    //do nothing!
                    break;
            }
            NUILog.Debug($" [{GetId()}] innerCurrentFrame={innerCurrentFrame}, base.CurrentFrame={base.CurrentFrame}");
            NUILog.Debug($" [{GetId()}] ]AnimatedVectorImageView END]");
        }
        #endregion Method


        #region Event, Enum, Struct, ETC
        /// <summary>
        /// RepeatMode of animation.
        /// </summary>
        // Suppress warning : This has been being used by users, so that the interface can not be changed.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names", Justification = "<Pending>")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum RepeatModes
        {
            /// <summary>
            /// When the animation reaches the end and RepeatCount is nonZero, the animation restarts from the beginning. 
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Restart = LoopingModeType.Restart,
            /// <summary>
            /// When the animation reaches the end and RepeatCount nonZero, the animation reverses direction on every animation cycle. 
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Reverse = LoopingModeType.AutoReverse
        }

        /// <summary>
        /// EndActions of animation.
        /// </summary>
        // Suppress warning : This has been being used by users, so that the interface can not be changed.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names", Justification = "<Pending>")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum EndActions
        {
            /// <summary> End action is Cancel, Animation Stops at the Current Frame.</summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Cancel = 0,
            /// <summary>  End action is Discard, Animation Stops at the Min Frame</summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Discard = 1,
            /// <summary> End action is StopFinal, Animation Stops at the Max Frame</summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            StopFinal = 2
        }

        /// <summary>
        /// AnimationStates of animation.
        /// </summary>
        // Suppress warning : This has been being used by users, so that the interface can not be changed.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names", Justification = "<Pending>")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum AnimationStates
        {
            /// <summary> The animation has stopped.</summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Stopped = PlayStateType.Stopped,
            /// <summary> The animation is playing.</summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Playing = PlayStateType.Playing,
            /// <summary> The animation is paused.</summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Paused = PlayStateType.Paused
        }
        #endregion Event, Enum, Struct, ETC


        #region Internal
        internal bool GetFrameValueFromMarkerInfo()
        {
            bool minimumMarkerFoundSuccess = false;
            bool maximumMarkerFoundSuccess = false;
            int foundedMinimumFrame = 0;
            int foundedMaximumFrame = 0;

            NUILog.Debug($" [{GetId()}] GetFrameValueFromMarkerInfo : marker = (minimumFrameMarker:{minimumFrameMarker}, maximumFrameMarker:{maximumFrameMarker})");

            var markerInfoList = GetMarkerInfo();
            if (markerInfoList != null)
            {
                foreach (var markerInfo in markerInfoList)
                {
                    if (markerInfo.Item1 == minimumFrameMarker)
                    {
                        if (string.IsNullOrEmpty(maximumFrameMarker))
                        {
                            minimumMarkerFoundSuccess = true;
                            maximumMarkerFoundSuccess = true;
                            foundedMinimumFrame = markerInfo.Item2;
                            foundedMaximumFrame = markerInfo.Item3;
                        }
                        else
                        {
                            minimumMarkerFoundSuccess = true;
                            foundedMinimumFrame = markerInfo.Item2;
                        }
                    }
                    else if (markerInfo.Item1 == maximumFrameMarker)
                    {
                        maximumMarkerFoundSuccess = true;
                        foundedMaximumFrame = markerInfo.Item2;
                    }
                }
            }

            if (minimumMarkerFoundSuccess && maximumMarkerFoundSuccess)
            {
                minimumFrame = (foundedMinimumFrame) > 0 ? foundedMinimumFrame : 0;
                maximumFrame = (foundedMaximumFrame) > 0 ? foundedMaximumFrame : 0;
                NUILog.Debug($" [{GetId()}] GetFrameValueFromMarkerInfo Sucess! frame set as {minimumFrame} ~ {maximumFrame} : marker = (minimumFrameMarker:{minimumFrameMarker}, maximumFrameMarker:{maximumFrameMarker})");
                if (minimumFrame > maximumFrame)
                {
                    NUILog.Debug($" [{GetId()}] minimumFrame:{minimumFrame} > maximumFrame:{maximumFrame})");
                }

                // Note : let we insure to get marker frame value only one time per each frame marker setter
                minimumFrameMarker = null;
                maximumFrameMarker = null;
                isMinMaxFrameSet = minMaxSetTypes.SetByMinAndMaxFrameMethod;
                return true;
            }
            else
            {
                Tizen.Log.Error("NUI", $"Fail to get frame from marker = (minimumFrameMarker:{minimumFrameMarker}, maximumFrameMarker:{maximumFrameMarker}). Maybe file is not loaded yet, or invalid marker used. url : {resourceUrl}\n");
                NUILog.Debug($" [{GetId()}] GetFrameValueFromMarkerInfo Failed! frame set as {minimumFrame} ~ {maximumFrame} : marker = (minimumFrameMarker:{minimumFrameMarker}, maximumFrameMarker:{maximumFrameMarker})");
                return false;
            }
        }
        #endregion Internal


        #region Private
        private string resourceUrl = null;
        private int repeatCnt = 0;
        private RepeatModes repeatMode = RepeatModes.Restart;
        private int minimumFrame = -1, maximumFrame = -1;
        private string minimumFrameMarker = null;
        private string maximumFrameMarker = null;
        private minMaxSetTypes isMinMaxFrameSet = minMaxSetTypes.NotSetByUser;
        private int innerCurrentFrame = -1;
        private EndActions innerEndAction = EndActions.Cancel;
        private enum minMaxSetTypes
        {
            NotSetByUser,
            SetByMinAndMaxFrameMethod,
            SetByMinAndMaxFrameByMarkerMethod,
            SetByMarker,
            SetByBaseSetMinMaxFrameMethod,
        }

        private AnimationStates CurrentAnimationState = AnimationStates.Stopped;
        private const int IntegerMaxValue = 0x7FFFFFFF;
        #endregion Private
    }
}
