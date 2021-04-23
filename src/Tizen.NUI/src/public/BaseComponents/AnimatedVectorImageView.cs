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

namespace Tizen.NUI.BaseComponents
{
#if (NUI_DEBUG_ON)
    using tlog = Tizen.Log;
#endif

    /// <summary>
    /// AnimatedVectorImageView is a class for displaying a vector resource.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AnimatedVectorImageView : LottieAnimationView
    {
        #region Constructor, Destructor, Dispose
        /// <summary>
        /// Construct VectorAnimationView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatedVectorImageView() : base()
        {
            tlog.Fatal(tag, $"[AnimatedVectorImageView START[ constructor objId={GetId()} ] END]");
        }

        /// <summary>
        /// Construct VectorAnimationView.
        /// </summary>
        /// <param name="scale">Set scaling factor for Vector Animation, while creating.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatedVectorImageView(float scale) : base(scale)
        {
            tlog.Fatal(tag, $"[AnimatedVectorImageView START[ constructor scale={scale}) objId={GetId()} ] END]");
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
            tlog.Fatal(tag, $"[AnimatedVectorImageView START[ [{GetId()}] type={type})");

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            base.Dispose(type);

            tlog.Fatal(tag, $"]AnimatedVectorImageView END]");
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
            set
            {
                tlog.Fatal(tag, $"[AnimatedVectorImageView START[ [{GetId()}] ResourceURL SET");

                if (value == resourceUrl)
                {
                    tlog.Fatal(tag, $"set same URL! ");
                    return;
                }
                resourceUrl = (value == null) ? "" : value;
                URL = resourceUrl;
                isMinMaxFrameSet = minMaxSetTypes.NotSetByUser;
                totalFrameNum = base.TotalFrame;
                tlog.Fatal(tag, $" [{GetId()}] resourceUrl={resourceUrl}) ]AnimatedVectorImageView END]");
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
            set
            {
                tlog.Fatal(tag, $"[AnimatedVectorImageView START[ [{GetId()}] ResourceUrl SET");
                this.ResourceURL = value;
                tlog.Fatal(tag, $" [{GetId()}] value={value}) ]AnimatedVectorImageView END]");
            }
            get
            {
                tlog.Fatal(tag, $"[AnimatedVectorImageView [ [{GetId()}] ResourceUrl GET");
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
            set
            {
                tlog.Fatal(tag, $"[AnimatedVectorImageView START[ [{GetId()}] RepeatCount SET");

                repeatCnt = (value < -1) ? -1 : value;
                LoopCount = (repeatCnt < 0) ? repeatCnt : repeatCnt + 1;

                tlog.Fatal(tag, $"[{GetId()}] repeatCnt={repeatCnt} ]AnimatedVectorImageView END]");
            }
            get => repeatCnt;
        }

        /// <summary>
        /// TotalFrame of animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int TotalFrame
        {
            get => totalFrameNum;
        }

        /// <summary>
        /// CurrentFrame of animation.
        /// </summary>
        /// <returns> Returns user set value for the current frame. Cannot provide actual playing current frame. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int CurrentFrame
        {
            set
            {
                tlog.Fatal(tag, $"[AnimatedVectorImageView START[ [{GetId()}] CurrentFrame SET");

                if (string.IsNullOrEmpty(resourceUrl))
                {
                    throw new InvalidOperationException("Resource Url not yet Set");
                }

                if (value < 0)
                {
                    value = 0;
                }
                else if (value >= totalFrameNum)
                {
                    value = totalFrameNum - 1;
                }

                innerCurrentFrame = value;
                AnimationState = AnimationStates.Paused;

                base.SetMinMaxFrame(0, totalFrameNum - 1);
                base.CurrentFrame = innerCurrentFrame;

                tlog.Fatal(tag, $" [{GetId()}] innerCurrentFrame={innerCurrentFrame}) ]AnimatedVectorImageView END]");
            }
            get => innerCurrentFrame;
        }

        /// <summary>
        /// RepeatMode of animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RepeatModes RepeatMode
        {
            set
            {
                tlog.Fatal(tag, $"[AnimatedVectorImageView START[ [{GetId()}] RepeatMode SET");
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

                tlog.Fatal(tag, $" [{GetId()}] repeatMode={repeatMode}) ]AnimatedVectorImageView END]");
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
            tlog.Fatal(tag, $"[AnimatedVectorImageView START[ [{GetId()}] SetMinAndMaxFrame({minFrame}, {maxFrame})");

            minimumFrame = (minFrame) > 0 ? minFrame : 0;
            maximumFrame = (maxFrame) > 0 ? maxFrame : 0;
            isMinMaxFrameSet = minMaxSetTypes.SetByMinAndMaxFrameMethod;

            if (minimumFrame >= totalFrameNum)
            {
                minimumFrame = totalFrameNum - 1;
            }

            if (maximumFrame >= totalFrameNum)
            {
                maximumFrame = totalFrameNum - 1;
            }

            if (minimumFrame > maximumFrame)
            {
                return;
            }

            tlog.Fatal(tag, $" [{GetId()}] minimumFrame:{minimumFrame}, maximumFrame:{maximumFrame}) ]AnimatedVectorImageView END]");
        }

        /// <summary>
        /// SetMinMaxFrame(int startFrame, int endFrame)
        /// </summary>
        /// <param name="minFrame"></param>
        /// <param name="maxFrame"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void SetMinMaxFrame(int minFrame, int maxFrame)
        {
            tlog.Fatal(tag, $"SetMinMaxFrame({minFrame}, {maxFrame})!!!");

            minimumFrame = (minFrame) > 0 ? minFrame : 0;
            maximumFrame = (maxFrame) > 0 ? maxFrame : 0;
            isMinMaxFrameSet = minMaxSetTypes.SetByBaseSetMinMaxFrameMethod;

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
        /// Or animation will play between the start frame of the first marker and the end frame of the second marker if two markers are specified.   *
        /// </summary>
        /// <param name="marker1">First marker</param>
        /// <param name="marker2">Second marker</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void SetMinMaxFrameByMarker(string marker1, string marker2 = null)
        {
            tlog.Fatal(tag, $"SetMinMaxFrameByMarker({marker1}, {marker2})");
            isMinMaxFrameSet = minMaxSetTypes.SetByMarker;
            base.SetMinMaxFrameByMarker(marker1, marker2);
        }

        /// <summary>
        /// Play Animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Play()
        {
            tlog.Fatal(tag, $"[AnimatedVectorImageView START[ [{GetId()}] AnimationState={AnimationState}, PlayState={PlayState}");

            if (string.IsNullOrEmpty(resourceUrl))
            {
                throw new InvalidOperationException("Resource Url not yet Set");
            }

            switch (isMinMaxFrameSet)
            {
                case minMaxSetTypes.NotSetByUser:
                    base.SetMinMaxFrame(0, totalFrameNum - 1);
                    base.CurrentFrame = 0;
                    break;

                case minMaxSetTypes.SetByMinAndMaxFrameMethod:
                    base.SetMinMaxFrame(minimumFrame, maximumFrame);
                    base.CurrentFrame = minimumFrame;
                    break;

                case minMaxSetTypes.SetByMarker:
                case minMaxSetTypes.SetByBaseSetMinMaxFrameMethod:
                default:
                    //do nothing!
                    break;
            }

            //temporal fix
            Extents tmp = base.Margin;
            base.Margin = tmp;

            base.Play();
            AnimationState = AnimationStates.Playing;

            tlog.Fatal(tag, $" [{GetId()}] isMinMaxFrameSet={isMinMaxFrameSet}) ]AnimatedVectorImageView END]");
        }

        /// <summary>
        /// Pause Animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Pause()
        {
            tlog.Fatal(tag, $"[AnimatedVectorImageView START[ [{GetId()}] AnimationState={AnimationState}, PlayState={PlayState}");

            if (string.IsNullOrEmpty(resourceUrl))
            {
                throw new InvalidOperationException("Resource Url not yet Set");
            }

            base.Pause();
            AnimationState = AnimationStates.Paused;

            tlog.Fatal(tag, $" [{GetId()}] ]AnimatedVectorImageView END]");
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
            tlog.Fatal(tag, $"[AnimatedVectorImageView START[ [{GetId()}] endAction:({endAction}), PlayState={PlayState}");

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
                        tlog.Fatal(tag, $" [{GetId()}] no endAction : default set");
                        break;
                }
            }
            AnimationState = AnimationStates.Stopped;

            base.Stop();

            if (endAction == EndActions.StopFinal)
            {
                switch (isMinMaxFrameSet)
                {
                    case minMaxSetTypes.NotSetByUser:
                        if (base.CurrentFrame != totalFrameNum - 1)
                        {
                            tlog.Fatal(tag, $"isMinMaxFrameSet:{isMinMaxFrameSet}, CurrentFrameNumber:{base.CurrentFrame}, totalFrameNum:{ totalFrameNum}");
                            base.CurrentFrame = totalFrameNum - 1;
                            tlog.Fatal(tag, $"set CurrentFrameNumber({base.CurrentFrame}) as totalFrameNum({maximumFrame}) - 1 !");
                        }
                        break;

                    case minMaxSetTypes.SetByMinAndMaxFrameMethod:
                        if (base.CurrentFrame != maximumFrame)
                        {
                            tlog.Fatal(tag, $"isMinMaxFrameSet:{isMinMaxFrameSet}, CurrentFrameNumber:{base.CurrentFrame}, maximumFrame:{ maximumFrame}");
                            base.CurrentFrame = maximumFrame;
                            tlog.Fatal(tag, $"set CurrentFrameNumber({base.CurrentFrame}) as maximumFrame({maximumFrame})!!!");
                        }
                        break;
                    case minMaxSetTypes.SetByBaseSetMinMaxFrameMethod:
                    case minMaxSetTypes.SetByMarker:
                    default:
                        //do nothing!
                        break;
                }
            }
            tlog.Fatal(tag, $" [{GetId()}] ]AnimatedVectorImageView END]");
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
        #endregion Internal


        #region Private
        private string resourceUrl = null;
        private int repeatCnt = 0;
        private int totalFrameNum = 0;
        private RepeatModes repeatMode = RepeatModes.Restart;
        private int minimumFrame = -1, maximumFrame = -1;
        private minMaxSetTypes isMinMaxFrameSet = minMaxSetTypes.NotSetByUser;
        private int innerCurrentFrame = -1;
        private EndActions innerEndAction = EndActions.Cancel;
        private enum minMaxSetTypes
        {
            NotSetByUser,
            SetByMinAndMaxFrameMethod,
            SetByMarker,
            SetByBaseSetMinMaxFrameMethod,
        }

        private string tag = "NUITEST";
        private AnimationStates CurrentAnimationState = AnimationStates.Stopped;
        #endregion Private
    }
}
