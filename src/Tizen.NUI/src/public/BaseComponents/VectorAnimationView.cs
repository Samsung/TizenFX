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
#if (NUI_DEBUG_ON)
using tlog = Tizen.Log;
#endif

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// VectorAnimationView is a class for displaying a vector resource.
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class VectorAnimationViewTBD : AnimatedVectorImageView
    {
        #region Constructor, Distructor, Dispose
        /// <summary>
        /// Construct VectorAnimationView.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VectorAnimationViewTBD() : base()
        {
            tlog.Fatal(tag,  $"[VAV START[ constuctor objId={GetId()} ]VAV END]");
        }

        /// <summary>
        /// Construct VectorAnimationView.
        /// </summary>
        /// <param name="scale">Set scaling factor for Vector Animation, while creating.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VectorAnimationViewTBD(float scale) : base(scale)
        {
            tlog.Fatal(tag,  $"[VAV START[ constuctor scale={scale}) objId={GetId()} ]VAV END]");
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
            tlog.Fatal(tag,  $"[VAV START[ [{GetId()}] type={type})");

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            base.Dispose(type);

            tlog.Fatal(tag,  $"]VAV END]");
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
                tlog.Fatal(tag,  $"[VAV START[ [{GetId()}] ResourceURL SET");

                if (value == mResourceURL)
                {
                    tlog.Fatal(tag,  $"set same URL! ");
                    return;
                }
                mResourceURL = (value == null) ? "" : value;
                URL = mResourceURL;
                mIsMinMaxSet = false;
                mTotalFrameNum = TotalFrameNumber;
                tlog.Fatal(tag,  $" [{GetId()}] mResourceURL={mResourceURL}) ]VAV END]");
            }
            get => mResourceURL;
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
                tlog.Fatal(tag,  $"[VAV START[ [{GetId()}] RepeatCount SET");

                mRepeatCount = (value < -1) ? -1 : value;
                LoopCount = (mRepeatCount < 0) ? mRepeatCount : mRepeatCount + 1;

                tlog.Fatal(tag,  $"[{GetId()}] mRepeatCount={mRepeatCount} ]VAV END]");
            }
            get => mRepeatCount;
        }

        /// <summary>
        /// TotalFrame of animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TotalFrame
        {
            get => mTotalFrameNum;
        }

        /// <summary>
        /// CurrentFrame of animation.
        /// </summary>
        /// <returns> Returns user set value for the current frame. Cannot provide actual playing current frame. </returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CurrentFrame
        {
            set
            {
                tlog.Fatal(tag,  $"[VAV START[ [{GetId()}] CurrentFrame SET");

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

                SetPlayRange(0, mTotalFrameNum - 1);
                CurrentFrameNumber = mCurrentFrame;

                tlog.Fatal(tag,  $" [{GetId()}] mCurrentFrame={mCurrentFrame}) ]VAV END]");
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
                tlog.Fatal(tag,  $"[VAV START[ [{GetId()}] RepeatMode SET");
                mRepeatMode = value;

                switch (mRepeatMode)
                {
                    case RepeatModes.Restart:
                        LoopMode = LoopingModeType.Restart;
                        break;
                    case RepeatModes.Reverse:
                        LoopMode = LoopingModeType.AutoReverse;
                        break;
                    default:
                        LoopMode = LoopingModeType.Restart;
                        break;
                }

                tlog.Fatal(tag,  $" [{GetId()}] mRepeatMode={mRepeatMode}) ]VAV END]");
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
            tlog.Fatal(tag,  $"[VAV START[ [{GetId()}] SetMinAndMaxFrame({minFrame}, {maxFrame})");

            mMinFrame = (minFrame) > 0 ? minFrame : 0;
            mMaxFrame = (maxFrame) > 0 ? maxFrame : 0;
            mIsMinMaxSet = true;

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

            tlog.Fatal(tag,  $" [{GetId()}] mMinFrame:{mMinFrame}, mMaxFrame:{mMaxFrame}) ]VAV END]");
        }

        /// <summary>
        /// Play Animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Play()
        {
            tlog.Fatal(tag,  $"[VAV START[ [{GetId()}] AnimationState={AnimationState}, PlayState={PlayState}");

            if (mResourceURL == null || mResourceURL == String.Empty)
            {
                throw new InvalidOperationException("Resource Url not yet Set");
            }

            if (mIsMinMaxSet)
            {
                SetPlayRange(mMinFrame, mMaxFrame);
                CurrentFrameNumber = mMinFrame;
            }
            else
            {
                SetPlayRange(0, mTotalFrameNum - 1);
                CurrentFrameNumber = 0;
            }

            base.Play();
            AnimationState = AnimationStates.Playing;

            tlog.Fatal(tag,  $" [{GetId()}] mIsMinMaxSet={mIsMinMaxSet}) ]VAV END]");
        }

        /// <summary>
        /// Pause Animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Pause()
        {
            tlog.Fatal(tag,  $"[VAV START[ [{GetId()}] AnimationState={AnimationState}, PlayState={PlayState}");

            if (mResourceURL == null || mResourceURL == String.Empty)
            {
                throw new InvalidOperationException("Resource Url not yet Set");
            }

            base.Pause();
            AnimationState = AnimationStates.Paused;

            tlog.Fatal(tag,  $" [{GetId()}] ]VAV END]");
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
            tlog.Fatal(tag,  $"[VAV START[ [{GetId()}] endAction:({endAction}), PlayState={PlayState}");

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
                        StopBehavior = StopBehaviorType.FirstFrame;
                        break;
                    case EndActions.StopFinal:
                        StopBehavior = StopBehaviorType.LastFrame;
                        break;
                    default:
                        tlog.Fatal(tag,  $" [{GetId()}] no endAction : default set");
                        break;
                }
            }
            AnimationState = AnimationStates.Stopped;

            base.Stop();

            if (endAction == EndActions.StopFinal)
            {
                if (mIsMinMaxSet)
                {
                    if (CurrentFrameNumber != mMaxFrame)
                    {
                        tlog.Fatal(tag,  $"mIsMinMaxSet:{mIsMinMaxSet}, CurrentFrameNumber:{CurrentFrameNumber}, mMaxFrame:{ mMaxFrame}");
                        CurrentFrameNumber = mMaxFrame;
                        tlog.Fatal(tag,  $"set CurrentFrameNumber({CurrentFrameNumber}) as mMaxFrame({mMaxFrame})!!!");
                    }
                }
                else
                {
                    if (CurrentFrameNumber != mTotalFrameNum - 1)
                    {
                        tlog.Fatal(tag,  $"mIsMinMaxSet:{mIsMinMaxSet}, CurrentFrameNumber:{CurrentFrameNumber}, mTotalFrameNum:{ mTotalFrameNum}");
                        CurrentFrameNumber = mTotalFrameNum - 1;
                        tlog.Fatal(tag,  $"set CurrentFrameNumber({CurrentFrameNumber}) as mTotalFrameNum({mMaxFrame}) - 1 !");
                    }
                }
            }

            tlog.Fatal(tag,  $" [{GetId()}] ]VAV END]");
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
            Restart = LoopModes.Forward,
            /// <summary>
            /// When the animation reaches the end and RepeatCount nonZero, the animation reverses direction on every animation cycle. 
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Reverse = LoopModes.Backward
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
        private bool mIsMinMaxSet = false;
        private int mCurrentFrame = -1;
        private EndActions mEndAction = EndActions.Cancel;

        private string tag = "NUITEST";
        #endregion Private
    }
}