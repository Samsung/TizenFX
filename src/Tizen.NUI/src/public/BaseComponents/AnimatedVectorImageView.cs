/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AnimatedVectorImageView : LottieAnimationView
    {
        #region Constructor, Distructor, Dispose
        /// <summary>
        /// Construct VectorAnimationView.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatedVectorImageView() : base()
        {
            tlog.Fatal(tag, $"[VAV START[ constuctor objId={GetId()} ]VAV END]");
        }

        /// <summary>
        /// Construct VectorAnimationView.
        /// </summary>
        /// <param name="scale">Set scaling factor for Vector Animation, while creating.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatedVectorImageView(float scale) : base(scale)
        {
            tlog.Fatal(tag, $"[VAV START[ constuctor scale={scale}) objId={GetId()} ]VAV END]");
        }

        /// <summary>
        /// You can override it to clean-up your own resources
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }
            tlog.Fatal(tag, $"[VAV START[ [{GetId()}] type={type})");

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            base.Dispose(type);

            tlog.Fatal(tag, $"]VAV END]");
        }
        #endregion Constructor, Distructor, Dispose


        #region Property
        /// <summary>
        /// Set Resource URL
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ResourceURL
        {
            set
            {
                tlog.Fatal(tag, $"[VAV START[ [{GetId()}] ResourceURL SET");

                if (value == mResourceURL)
                {
                    tlog.Fatal(tag, $"set same URL! ");
                    return;
                }
                mResourceURL = (value == null) ? "" : value;
                URL = mResourceURL;
                mIsMinMaxSet = minMaxSetTypes.NotSetByUser;
                mTotalFrameNum = base.TotalFrame;
                tlog.Fatal(tag, $" [{GetId()}] mResourceURL={mResourceURL}) ]VAV END]");
            }
            get => mResourceURL;
        }

        /// <summary>
        /// Set Resource URL
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string ResourceUrl
        {
            set
            {
                tlog.Fatal(tag, $"[VAV START[ [{GetId()}] ResourceUrl SET");
                this.ResourceURL = value;
                tlog.Fatal(tag, $" [{GetId()}] value={value}) ]VAV END]");
            }
            get
            {
                tlog.Fatal(tag, $"[VAV [ [{GetId()}] ResourceUrl GET");
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
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RepeatCount
        {
            set
            {
                tlog.Fatal(tag, $"[VAV START[ [{GetId()}] RepeatCount SET");

                mRepeatCount = (value < -1) ? -1 : value;
                LoopCount = (mRepeatCount < 0) ? mRepeatCount : mRepeatCount + 1;

                tlog.Fatal(tag, $"[{GetId()}] mRepeatCount={mRepeatCount} ]VAV END]");
            }
            get => mRepeatCount;
        }

        /// <summary>
        /// TotalFrame of animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int TotalFrame
        {
            get => mTotalFrameNum;
        }

        /// <summary>
        /// CurrentFrame of animation.
        /// </summary>
        /// <returns> Returns user set value for the current frame. Cannot provide actual playing current frame. </returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int CurrentFrame
        {
            set
            {
                tlog.Fatal(tag, $"[VAV START[ [{GetId()}] CurrentFrame SET");

                if (mResourceURL == null || mResourceURL == String.Empty)
                {
                    throw new InvalidOperationException("Resource Url not yet Set");
                }

                if (value < 0)
                {
                    value = 0;
                }
                else if (value >= mTotalFrameNum)
                {
                    value = mTotalFrameNum - 1;
                }

                mCurrentFrame = value;
                AnimationState = AnimationStates.Paused;

                base.SetMinMaxFrame(0, mTotalFrameNum - 1);
                base.CurrentFrame = mCurrentFrame;

                tlog.Fatal(tag, $" [{GetId()}] mCurrentFrame={mCurrentFrame}) ]VAV END]");
            }
            get => mCurrentFrame;
        }

        /// <summary>
        /// RepeatMode of animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RepeatModes RepeatMode
        {
            set
            {
                tlog.Fatal(tag, $"[VAV START[ [{GetId()}] RepeatMode SET");
                mRepeatMode = value;

                switch (mRepeatMode)
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

                tlog.Fatal(tag, $" [{GetId()}] mRepeatMode={mRepeatMode}) ]VAV END]");
            }
            get => mRepeatMode;
        }

        /// <summary>
        /// Get state of animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimationStates AnimationState
        {
            private set;
            get;
        }
        #endregion Property


        #region Method
        /// <summary>
        /// Set minimum frame and maximum frame
        /// </summary>
        /// <param name="minFrame">minimum frame.</param>
        /// <param name="maxFrame">maximum frame.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinAndMaxFrame(int minFrame, int maxFrame)
        {
            tlog.Fatal(tag, $"[VAV START[ [{GetId()}] SetMinAndMaxFrame({minFrame}, {maxFrame})");

            mMinFrame = (minFrame) > 0 ? minFrame : 0;
            mMaxFrame = (maxFrame) > 0 ? maxFrame : 0;
            mIsMinMaxSet = minMaxSetTypes.SetByMinAndMaxFrameMethod;

            if (mMinFrame >= mTotalFrameNum)
            {
                mMinFrame = mTotalFrameNum - 1;
            }

            if (mMaxFrame >= mTotalFrameNum)
            {
                mMaxFrame = mTotalFrameNum - 1;
            }

            if (mMinFrame > mMaxFrame)
            {
                return;
            }

            tlog.Fatal(tag, $" [{GetId()}] mMinFrame:{mMinFrame}, mMaxFrame:{mMaxFrame}) ]VAV END]");
        }

        /// <summary>
        /// SetMinMaxFrame(int startFrame, int endFrame)
        /// </summary>
        /// <param name="minFrame"></param>
        /// <param name="maxFrame"></param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void SetMinMaxFrame(int minFrame, int maxFrame)
        {
            tlog.Fatal(tag, $"SetMinMaxFrame({minFrame}, {maxFrame})!!!");

            mMinFrame = (minFrame) > 0 ? minFrame : 0;
            mMaxFrame = (maxFrame) > 0 ? maxFrame : 0;
            mIsMinMaxSet = minMaxSetTypes.SetByBaseSetMinMaxFrameMethod;

            if (mMinFrame >= mTotalFrameNum)
            {
                mMinFrame = mTotalFrameNum - 1;
            }

            if (mMaxFrame >= mTotalFrameNum)
            {
                mMaxFrame = mTotalFrameNum - 1;
            }

            base.SetMinMaxFrame(mMinFrame, mMaxFrame);
        }

        /// <summary>
        /// A marker has its start frame and end frame. 
        /// Animation will play between the start frame and the end frame of the marker if one marker is specified.
        /// Or animation will play between the start frame of the first marker and the end frame of the second marker if two markers are specified.   *
        /// </summary>
        /// <param name="marker1">First marker</param>
        /// <param name="marker2">Second marker</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void SetMinMaxFrameByMarker(string marker1, string marker2 = null)
        {
            tlog.Fatal(tag, $"SetMinMaxFrameByMarker({marker1}, {marker2})");
            mIsMinMaxSet = minMaxSetTypes.SetByMarker;
            base.SetMinMaxFrameByMarker(marker1, marker2);
        }

        /// <summary>
        /// Play Animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Play()
        {
            tlog.Fatal(tag, $"[VAV START[ [{GetId()}] AnimationState={AnimationState}, PlayState={PlayState}");

            if (mResourceURL == null || mResourceURL == String.Empty)
            {
                throw new InvalidOperationException("Resource Url not yet Set");
            }

            switch (mIsMinMaxSet)
            {
                case minMaxSetTypes.NotSetByUser:
                    base.SetMinMaxFrame(0, mTotalFrameNum - 1);
                    base.CurrentFrame = 0;
                    break;

                case minMaxSetTypes.SetByMinAndMaxFrameMethod:
                    base.SetMinMaxFrame(mMinFrame, mMaxFrame);
                    base.CurrentFrame = mMinFrame;
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

            tlog.Fatal(tag, $" [{GetId()}] mIsMinMaxSet={mIsMinMaxSet}) ]VAV END]");
        }

        /// <summary>
        /// Pause Animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Pause()
        {
            tlog.Fatal(tag, $"[VAV START[ [{GetId()}] AnimationState={AnimationState}, PlayState={PlayState}");

            if (mResourceURL == null || mResourceURL == String.Empty)
            {
                throw new InvalidOperationException("Resource Url not yet Set");
            }

            base.Pause();
            AnimationState = AnimationStates.Paused;

            tlog.Fatal(tag, $" [{GetId()}] ]VAV END]");
        }

        /// <summary>
        /// Stop Animation.
        /// </summary>
        /// <param name="endAction">Defines, what should be behaviour after cancel operation
        /// End action is Cancel, Animation Stops at the Current Frame.
        /// End action is Discard, Animation Stops at the Min Frame
        /// End action is StopFinal, Animation Stops at the Max Frame
        /// </param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Stop(EndActions endAction = EndActions.Cancel)
        {
            tlog.Fatal(tag, $"[VAV START[ [{GetId()}] endAction:({endAction}), PlayState={PlayState}");

            if (mResourceURL == null || mResourceURL == String.Empty)
            {
                throw new InvalidOperationException("Resource Url not yet Set");
            }

            if (AnimationState == AnimationStates.Stopped)
            {
                return;
            }

            if (mEndAction != endAction)
            {
                mEndAction = endAction;
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
                switch (mIsMinMaxSet)
                {
                    case minMaxSetTypes.NotSetByUser:
                        if (base.CurrentFrame != mTotalFrameNum - 1)
                        {
                            tlog.Fatal(tag, $"mIsMinMaxSet:{mIsMinMaxSet}, CurrentFrameNumber:{base.CurrentFrame}, mTotalFrameNum:{ mTotalFrameNum}");
                            base.CurrentFrame = mTotalFrameNum - 1;
                            tlog.Fatal(tag, $"set CurrentFrameNumber({base.CurrentFrame}) as mTotalFrameNum({mMaxFrame}) - 1 !");
                        }
                        break;

                    case minMaxSetTypes.SetByMinAndMaxFrameMethod:
                        if (base.CurrentFrame != mMaxFrame)
                        {
                            tlog.Fatal(tag, $"mIsMinMaxSet:{mIsMinMaxSet}, CurrentFrameNumber:{base.CurrentFrame}, mMaxFrame:{ mMaxFrame}");
                            base.CurrentFrame = mMaxFrame;
                            tlog.Fatal(tag, $"set CurrentFrameNumber({base.CurrentFrame}) as mMaxFrame({mMaxFrame})!!!");
                        }
                        break;
                    case minMaxSetTypes.SetByBaseSetMinMaxFrameMethod:
                    case minMaxSetTypes.SetByMarker:
                    default:
                        //do nothing!
                        break;
                }
            }
            tlog.Fatal(tag, $" [{GetId()}] ]VAV END]");
        }
        #endregion Method


        #region Event, Enum, Struct, ETC
        /// <summary>
        /// RepeatMode of animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum RepeatModes
        {
            /// <summary>
            /// When the animation reaches the end and RepeatCount is nonZero, the animation restarts from the beginning. 
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Restart = LoopingModeType.Restart,
            /// <summary>
            /// When the animation reaches the end and RepeatCount nonZero, the animation reverses direction on every animation cycle. 
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Reverse = LoopingModeType.AutoReverse
        }

        /// <summary>
        /// EndActions of animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum EndActions
        {
            /// <summary> End action is Cancel, Animation Stops at the Current Frame.</summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Cancel = 0,
            /// <summary>  End action is Discard, Animation Stops at the Min Frame</summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Discard = 1,
            /// <summary> End action is StopFinal, Animation Stops at the Max Frame</summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            StopFinal = 2
        }

        /// <summary>
        /// AnimationStates of animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum AnimationStates
        {
            /// <summary> The animation has stopped.</summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Stopped = PlayStateType.Stopped,
            /// <summary> The animation is playing.</summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Playing = PlayStateType.Playing,
            /// <summary> The animation is paused.</summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Paused = PlayStateType.Paused
        }
        #endregion Event, Enum, Struct, ETC


        #region Internal
        #endregion Internal


        #region Private
        private string mResourceURL = null;
        private int mRepeatCount = 0;
        private int mTotalFrameNum = 0;
        private RepeatModes mRepeatMode = RepeatModes.Restart;
        private int mMinFrame = -1, mMaxFrame = -1;
        private minMaxSetTypes mIsMinMaxSet = minMaxSetTypes.NotSetByUser;
        private int mCurrentFrame = -1;
        private EndActions mEndAction = EndActions.Cancel;
        private enum minMaxSetTypes
        {
            NotSetByUser,
            SetByMinAndMaxFrameMethod,
            SetByMarker,
            SetByBaseSetMinMaxFrameMethod,
        }

        private string tag = "NUITEST";
        #endregion Private
    }
}