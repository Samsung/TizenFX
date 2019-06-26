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
using global::System.Runtime.InteropServices;
using System.ComponentModel;
using tizenlog = Tizen.Log;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// AnimatedVectorImageView renders an animated vector image
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class VectorAnimationViewTBD : ImageView
    {
        #region Constructor, Distructor, Dispose
        /// <summary>
        /// Construct VectorAnimationView.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VectorAnimationViewTBD() : base()
        {
            NUILog.Debug($"AnimatedVectorImageView() constructor!");
            //default value in NUI level
            currentStates.url = "";
            currentStates.frame = 0;
            currentStates.loopCount = 0;
            currentStates.repeatMode = RepeatModes.Restart;
            currentStates.stopEndAction = EndActions.Cancel;
            currentStates.framePlayRangeMin = -1;
            currentStates.framePlayRangeMax = -1;
            currentStates.changed = false;
            currentStates.totalFrame = -1;
            currentStates.scale = 1.0f;
        }

        /// <summary>
        /// Construct VectorAnimationView.
        /// </summary>
        /// <param name="scale">Set scaling factor for Vector Animation, while creating.</param>
        /// <exception cref='NotImplementedException'>
        /// Throw API implementation is pending
        /// </exception>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VectorAnimationViewTBD(float scale) : base()
        {
            currentStates.scale = scale;
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

            NUILog.Debug($"Dispose(type={type})!");

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            //disconnect event signal!
            if (finishedEventHandler != null && visualEventSignalCallback != null)
            {
                VisualEventSignal().Disconnect(visualEventSignalCallback);
                finishedEventHandler = null;
                NUILog.Debug($"disconnect event signal!!!!");
            }

            base.Dispose(type);
        }
        #endregion


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
                NUILog.Debug($"URL set! value={value}");
                string ret = (value == null ? "" : value);
                currentStates.url = ret;
                currentStates.changed = true;

                PropertyMap map = new PropertyMap();
                map.Add(Visual.Property.Type, new PropertyValue((int)DevelVisual.Type.AnimatedVectorImage))
                    .Add(ImageVisualProperty.URL, new PropertyValue(currentStates.url))
                    .Add(ImageVisualProperty.LoopCount, new PropertyValue(currentStates.loopCount));
                //.Add(ImageVisualProperty.StopEndAction, new PropertyValue((int)currentStates.stopEndAction))
                //.Add(ImageVisualProperty.RepeatMode, new PropertyValue((int)currentStates.repeatMode));
                Image = map;
            }
            get
            {
                string ret = ResourceUrl;
                NUILog.Debug($"URL get! base resource mUrl={ret}, name={Name}");
                PropertyMap map = Image;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.URL);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            NUILog.Debug($"gotten url={ret}");
                            return ret;
                        }
                    }
                }
                tizenlog.Error(tag, "[ERROR] fail to get ResourceUrl from dali");
                return ret;
            }
        }

        /// <summary>
        /// The playing state
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PlayStateType PlayState
        {
            get
            {
                var ret = -1;
                PropertyMap map = Image;
                if (map != null)
                {
                    PropertyValue val = map.Find((int)DevelVisual.Type.AnimatedVectorImage);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            return (PlayStateType)ret;
                        }
                    }
                }
                tizenlog.Error(tag, $"[ERROR] fail to get PlayState from dali");
                return (PlayStateType)ret;
            }
        }

        /// <summary>
        /// The number of total frame
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TotalFrameNumber
        {
            get
            {
                int ret = -1;
                PropertyMap map = Image;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.TotalFrameNumber);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            NUILog.Debug($"TotalFrameNumber get! ret={ret}");
                            currentStates.totalFrame = ret;
                            return ret;
                        }
                    }
                }
                tizenlog.Error(tag, $"[ERROR] fail to get TotalFrameNumber from dali");
                return ret;
            }
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
                currentStates.frame = value;
                NUILog.Debug($"set CurrentFrame={currentStates.frame}");
                DoAction(vectorImageVisualIndex, (int)actionType.jumpTo, new PropertyValue(currentStates.frame));
            }
            get
            {
                int ret = -1;
                PropertyMap map = Image;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.CurrentFrameNumber);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            NUILog.Debug($"CurrentFrame get! val={ret}");
                            return ret;
                        }
                    }
                }
                tizenlog.Error(tag, $"[ERROR] fail to get CurrentFrame from dali");
                return ret;
            }
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
                currentStates.repeatMode = (RepeatModes)value;
                currentStates.changed = true;


                NUILog.Debug($"RepeatMode set val={currentStates.repeatMode}");
                //PropertyMap map = new PropertyMap();
                //map.Add(ImageVisualProperty.RepeatMode, new PropertyValue((int)currentStates.repeatMode));
                //DoAction(vectorImageVisualIndex, (int)actionType.updateProperty, new PropertyValue(map));
            }
            get
            {
                NUILog.Debug($"RepeatMode get!");
                PropertyMap map = base.Image;
                var ret = 0;
                //if (map != null)
                //{
                //    PropertyValue val = map.Find(ImageVisualProperty.RepeatMode);
                //    if (val != null)
                //    {
                //        if (val.Get(out ret))
                //        {
                //            NUILog.Debug($"gotten RepeatMode={ret}");
                //            if (ret != (int)currentStates.repeatMode && ret > 0)
                //            {
                //                NUILog.Debug($"different RepeatMode! gotten={ret}, repeatMode={currentStates.repeatMode}");
                //                return (int)currentStates.repeatMode;
                //            }
                //            return ret;
                //        }
                //    }
                //}
                tizenlog.Error(tag, "[ERROR] fail to get repeatMode from dali");
                return (RepeatModes)ret;
            }
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
                if (value < 0)
                {
                    currentStates.loopCount = -1;
                }
                else
                {
                    currentStates.loopCount = value;
                }
                currentStates.changed = true;

                NUILog.Debug($"LoopCount set val={currentStates.loopCount}");
                PropertyMap map = new PropertyMap();
                map.Add(ImageVisualProperty.LoopCount, new PropertyValue(currentStates.loopCount));
                DoAction(vectorImageVisualIndex, (int)actionType.updateProperty, new PropertyValue(map));
            }
            get
            {
                NUILog.Debug($"LoopCount get!");
                PropertyMap map = base.Image;
                var ret = 0;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.LoopCount);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            NUILog.Debug($"gotten loop count={ret}");
                            if (ret != currentStates.loopCount && ret > 0)
                            {
                                NUILog.Debug($"different loop count! gotten={ret}, loopCount={currentStates.loopCount}");
                                return currentStates.loopCount;
                            }
                            return (ret < 0 ? ret : ret - 1);
                        }
                    }
                }
                tizenlog.Error(tag, "[ERROR] fail to get LoopCount from dali");
                return ret;
            }
        }
        #endregion


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
            var mMinFrame = (minFrame) > 0 ? minFrame : 0;
            var mMaxFrame = (maxFrame) > 0 ? maxFrame : 0;

            if (mMinFrame > mMaxFrame)
            {
                return;
            }
            NUILog.Debug($"SetMinAndMaxFrame()! minFrame={mMinFrame}, maxFrame={mMaxFrame}");

            Vector2 range = new Vector2((float)mMinFrame, (float)mMaxFrame);
            SetFramePlayRange(range);
        }

        /// <summary>
        /// Play Animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Play()
        {
            NUILog.Debug($"Play() called!");
            debugPrint();
            base.Play();
            AnimationState = AnimationStates.Playing;
        }

        /// <summary>
        /// Pause Animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Pause()
        {
            NUILog.Debug($"Pause() called!");
            debugPrint();
            base.Pause();
            AnimationState = AnimationStates.Paused;
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
            NUILog.Debug($"Stop()!");
            if (AnimationState == AnimationStates.Stopped)
            {
                return;
            }

            AnimationState = AnimationStates.Stopped;
            StopEndAction = (int)endAction;

            NUILog.Debug($"Stop() called!");
            debugPrint();
            base.Stop();
        }
        #endregion


        #region Event, Enum, Struct, ETC
        /// <summary>
        /// Animation finished event
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Finished
        {
            add
            {
                if (finishedEventHandler == null)
                {
                    NUILog.Debug($"Finished()! add!");
                    visualEventSignalCallback = onVisualEventSignal;
                    VisualEventSignal().Connect(visualEventSignalCallback);
                }
                finishedEventHandler += value;
            }
            remove
            {
                NUILog.Debug($"Finished()! remove!");
                finishedEventHandler -= value;
                if (finishedEventHandler == null && visualEventSignalCallback != null)
                {
                    VisualEventSignal().Disconnect(visualEventSignalCallback);
                }
            }
        }

        /// <summary>
        /// Enumeration for what state the vector animation is in
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum PlayStateType
        {
            /// <summary>
            /// Invalid
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Invalid = -1,
            /// <summary>
            /// Vector Animation has stopped
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Stopped = 0,
            /// <summary>
            /// The vector animation is playing
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Playing = 1,
            /// <summary>
            /// The vector animation is paused
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Paused = 2
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
            Stopped = 0,
            /// <summary> The animation is playing.</summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Playing = 1,
            /// <summary> The animation is paused.</summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Paused = 2
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
            Restart = 1,
            /// <summary>
            /// When the animation reaches the end and RepeatCount nonZero, the animation reverses direction on every animation cycle. 
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Reverse = 2
        }
        #endregion


        #region Internal
        internal void SetPlayRange(Vector2 range)
        {
            PropertyMap map = new PropertyMap();
            map.Add(ImageVisualProperty.PlayRange, new PropertyValue(range));
            DoAction(vectorImageVisualIndex, (int)actionType.updateProperty, new PropertyValue(map));
            NUILog.Debug($"SetPlayRange(range min={range.X}, max={range.Y})");
        }

        internal void SetFramePlayRange(Vector2 range)
        {
            currentStates.framePlayRangeMin = (int)range.X;
            currentStates.framePlayRangeMax = (int)range.Y;
            currentStates.changed = true;

            PropertyArray array = new PropertyArray();
            array.PushBack(new PropertyValue(currentStates.framePlayRangeMin));
            array.PushBack(new PropertyValue(currentStates.framePlayRangeMax));

            PropertyMap map = new PropertyMap();
            map.Add(ImageVisualProperty.PlayRange, new PropertyValue(array));
            DoAction(vectorImageVisualIndex, (int)actionType.updateProperty, new PropertyValue(map));
            NUILog.Debug($"SetFramePlayRange(range min={currentStates.framePlayRangeMin}, max={currentStates.framePlayRangeMax})");
        }

        internal Vector2 GetPlayRange()
        {
            Vector2 ret = new Vector2(-1.0f, -1.0f);
            PropertyMap map = Image;
            if (map != null)
            {
                PropertyValue val = map.Find(ImageVisualProperty.PlayRange);
                if (val != null)
                {
                    if (val.Get(ret))
                    {
                        return ret;
                    }
                }
            }
            tizenlog.Error(tag, $"[ERROR] fail to get PlayRange from dali");
            return ret;
        }

        internal float CurrentProgress
        {
            get
            {
                float ret = -1.0f;
                int currentFrame = -1;
                PropertyMap map = Image;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.CurrentFrameNumber);
                    if (val != null)
                    {
                        if (val.Get(out currentFrame))
                        {
                            int total = TotalFrameNumber;
                            if (total != -1)
                            {
                                ret = (float)currentFrame / (float)total;
                                NUILog.Debug($"CurrentProgress get! currentFrame={currentFrame}, total={total}, ret={ret}");
                                return ret;
                            }
                            else
                            {
                                tizenlog.Error(tag, $"[ERROR] fail to get total frame number from dali");
                                return -1.0f;
                            }
                        }
                    }
                }
                tizenlog.Error(tag, $"[ERROR] fail to get CurrentProgress from dali");
                return -1.0f;
            }
        }

        internal int StopEndAction
        {
            set
            {
                currentStates.stopEndAction = (EndActions)value;
                currentStates.changed = true;

                NUILog.Debug($"StopEndAction set val={currentStates.stopEndAction}");
                //PropertyMap map = new PropertyMap();
                //map.Add(ImageVisualProperty.StopEndAction, new PropertyValue((int)currentStates.stopEndAction));
                //DoAction(vectorImageVisualIndex, (int)actionType.updateProperty, new PropertyValue(map));
            }
            get
            {
                NUILog.Debug($"StopEndAction get!");
                PropertyMap map = base.Image;
                var ret = 0;
                //if (map != null)
                //{
                //    PropertyValue val = map.Find(ImageVisualProperty.StopEndAction);
                //    if (val != null)
                //    {
                //        if (val.Get(out ret))
                //        {
                //            NUILog.Debug($"gotten stopEndAction={ret}");
                //            if (ret != (int)currentStates.stopEndAction && ret > 0)
                //            {
                //                NUILog.Debug($"different stopEndAction! gotten={ret}, stopEndAction={currentStates.stopEndAction}");
                //                return (int)currentStates.stopEndAction;
                //            }
                //            return (ret);
                //        }
                //    }
                //}
                tizenlog.Error(tag, "[ERROR] fail to get stopEndAction from dali");
                return ret;
            }
        }

        internal class VisualEventSignalArgs : EventArgs
        {
            public int VisualIndex
            {
                get
                {
                    return visualIndex;
                }
                set
                {
                    visualIndex = value;
                }
            }

            public int SignalId
            {
                get
                {
                    return signalId;
                }
                set
                {
                    signalId = value;
                }
            }

            int visualIndex;
            int signalId;
        }

        internal struct states
        {
            internal string url;
            internal int frame;
            internal int loopCount;
            internal RepeatModes repeatMode;
            internal EndActions stopEndAction;
            internal int framePlayRangeMin;
            internal int framePlayRangeMax;
            internal bool changed;
            internal int totalFrame;
            internal float scale;
        };
        internal states currentStates;

        internal event EventHandler<VisualEventSignalArgs> VisualEvent
        {
            add
            {
                if (visualEventSignalHandler == null)
                {
                    visualEventSignalCallback = onVisualEventSignal;
                    VisualEventSignal().Connect(visualEventSignalCallback);
                }
                visualEventSignalHandler += value;
            }
            remove
            {
                visualEventSignalHandler -= value;
                if (visualEventSignalHandler == null && VisualEventSignal().Empty() == false)
                {
                    VisualEventSignal().Disconnect(visualEventSignalCallback);
                }
            }
        }

        internal void EmitVisualEventSignal(int visualIndex, int signalId)
        {
            VisualEventSignal().Emit(this, visualIndex, signalId);
        }

        internal VisualEventSignal VisualEventSignal()
        {
            VisualEventSignal ret = new VisualEventSignal(Interop.VisualEventSignal.NewWithView(View.getCPtr(this)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
        #endregion


        #region Private
        private enum actionType
        {
            play,
            pause,
            stop,
            jumpTo,
            updateProperty,
        };

        private struct DevelVisual
        {
            internal enum Type
            {
                AnimatedGradient = Visual.Type.AnimatedImage + 1,
                AnimatedVectorImage = Visual.Type.AnimatedImage + 2,
            }
        }

        private const string tag = "NUI";
        private const int vectorImageVisualIndex = 10000000 + 1000 + 2;
        private event EventHandler finishedEventHandler;

        private void OnFinished()
        {
            finishedEventHandler?.Invoke(this, null);
        }

        private void onVisualEventSignal(IntPtr targetView, int visualIndex, int signalId)
        {
            OnFinished();

            if (targetView != IntPtr.Zero)
            {
                View v = Registry.GetManagedBaseHandleFromNativePtr(targetView) as View;
                if (v != null)
                {
                    NUILog.Debug($"targetView is not null! name={v.Name}");
                }
                else
                {
                    NUILog.Debug($"target is something created from dali");
                }
            }
            VisualEventSignalArgs e = new VisualEventSignalArgs();
            e.VisualIndex = visualIndex;
            e.SignalId = signalId;
            visualEventSignalHandler?.Invoke(this, e);

            NUILog.Debug($"@@ onVisualEventSignal()! visualIndex={visualIndex}, signalId={signalId}");
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void VisualEventSignalCallbackType(IntPtr targetView, int visualIndex, int signalId);

        private VisualEventSignalCallbackType visualEventSignalCallback;
        private EventHandler<VisualEventSignalArgs> visualEventSignalHandler;

        private void debugPrint()
        {
            NUILog.Debug($"======= currentStates");
            NUILog.Debug($"url={currentStates.url}, loopCount={currentStates.loopCount}, framePlayRangeMin={currentStates.framePlayRangeMin}, framePlayRangeMax={currentStates.framePlayRangeMax} \n");
        }
        #endregion
    }
}
