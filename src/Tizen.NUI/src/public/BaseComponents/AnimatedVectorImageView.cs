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
#if (NUI_DEBUG_ON)
using tlog = Tizen.Log;
#endif

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// AnimatedVectorImageView renders an animated vector image
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AnimatedVectorImageView : ImageView
    {
        #region Constructor, Distructor, Dispose
        /// <summary>
        /// AnimatedVectorImageView
        /// </summary>
        /// <param name="scale">The factor of scaling image, default : 1.0f</param>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown), default : true</param>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatedVectorImageView(float scale = 1.0f, bool shown = true) : base()
        {
            tlog.Fatal(tag, $"< constructor GetId={GetId()} >");
            currentStates.url = "";
            currentStates.frame = -1;
            currentStates.loopCount = 1;
            currentStates.loopMode = LoopingModeType.Restart;
            currentStates.stopEndAction = StopBehaviorType.CurrentFrame;
            currentStates.framePlayRangeMin = -1;
            currentStates.framePlayRangeMax = -1;
            currentStates.changed = false;
            currentStates.totalFrame = -1;
            currentStates.scale = scale;
            SetVisible(shown);
        }

        /// <summary>
        /// Dispose(DisposeTypes type)
        /// </summary>
        /// <param name="type"></param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            tlog.Fatal(tag, $"<[{GetId()}] type={type}");

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            //disconnect event signal
            if (finishedEventHandler != null && visualEventSignalCallback != null)
            {
                VisualEventSignal().Disconnect(visualEventSignalCallback);
                finishedEventHandler = null;
                tlog.Fatal(tag, $"disconnect event signal");
            }

            base.Dispose(type);
            tlog.Fatal(tag, $"[{GetId()}]>");
        }
        #endregion Constructor, Distructor, Dispose


        #region Property
        /// <summary>
        /// URL
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string URL
        {
            set
            {
                string ret = (value == null ? "" : value);
                currentStates.url = ret;
                currentStates.changed = true;

                tlog.Fatal(tag, $"<[{GetId()}]SET url={currentStates.url}");

                PropertyMap map = new PropertyMap();
                map.Add(Visual.Property.Type, new PropertyValue((int)DevelVisual.Type.AnimatedVectorImage))
                    .Add(ImageVisualProperty.URL, new PropertyValue(currentStates.url))
                    .Add(ImageVisualProperty.LoopCount, new PropertyValue(currentStates.loopCount))
                    .Add(ImageVisualProperty.StopBehavior, new PropertyValue((int)currentStates.stopEndAction))
                    .Add(ImageVisualProperty.LoopingMode, new PropertyValue((int)currentStates.loopMode));
                Image = map;
                tlog.Fatal(tag, $"<[{GetId()}]>");
            }
            get
            {
                string ret = currentStates.url;
                tlog.Fatal(tag, $"<[{GetId()}] GET");

                PropertyMap map = Image;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.URL);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            tlog.Fatal(tag, $"gotten url={ret} >");
                            return ret;
                        }
                    }
                }
                tlog.Error(tag, $"  [ERROR][{GetId()}](AnimatedVectorImageView) Fail to get URL from dali >");
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
                tlog.Fatal(tag, $"< Get!");
                PropertyMap map = base.Image;
                var ret = 0;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.PlayState);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            currentStates.playState = (PlayStateType)ret;
                            tlog.Fatal(tag, $"gotten play state={ret} >");
                            return currentStates.playState;
                        }
                    }
                }
                tlog.Error(tag, $"<[ERROR][{GetId()}]Fail to get PlayState from dali currentStates.playState={currentStates.playState}>");
                return currentStates.playState;
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
                            //tlog.Fatal(tag, $"TotalFrameNumber get! ret={ret}");
                            currentStates.totalFrame = ret;
                            return ret;
                        }
                    }
                }
                tlog.Error(tag, $"<[ERROR][{GetId()}](AnimatedVectorImageView) Fail to get TotalFrameNumber from dali>");
                return ret;
            }
        }

        /// <summary>
        /// CurrentFrameNumber
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CurrentFrameNumber
        {
            set
            {
                currentStates.frame = value;
                tlog.Fatal(tag, $"<[{GetId()}]SET frame={currentStates.frame}>");
                DoAction(vectorImageVisualIndex, (int)actionType.jumpTo, new PropertyValue(currentStates.frame));
            }
            get
            {
                int ret = 0;
                PropertyMap map = Image;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.CurrentFrameNumber);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            //tlog.Fatal(tag, $"CurrentFrameNumber get! val={ret}");
                            return ret;
                        }
                    }
                }
                tlog.Error(tag, $"<[ERROR][{GetId()}](AnimatedVectorImageView) Fail to get CurrentFrameNumber from dali!! ret={ret}>");
                return ret;
            }
        }

        /// <summary>
        /// Loop Mode of animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LoopingModeType LoopMode
        {
            set
            {
                currentStates.loopMode = (LoopingModeType)value;
                currentStates.changed = true;

                tlog.Fatal(tag, $"<[{GetId()}] SET loopMode={currentStates.loopMode}>");
                PropertyMap map = new PropertyMap();
                map.Add(ImageVisualProperty.LoopingMode, new PropertyValue((int)currentStates.loopMode));
                DoAction(vectorImageVisualIndex, (int)actionType.updateProperty, new PropertyValue(map));
            }
            get
            {
                //tlog.Fatal(tag, $"LoopMode get!");
                PropertyMap map = base.Image;
                var ret = 0;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.LoopingMode);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            //tlog.Fatal(tag, $"gotten LoopMode={ret}");
                            if (ret != (int)currentStates.loopMode && ret > 0)
                            {
                                tlog.Fatal(tag, $" [ERROR][{GetId()}](AnimatedVectorImageView) different LoopMode! gotten={ret}, loopMode={currentStates.loopMode}");
                            }
                            currentStates.loopMode = (LoopingModeType)ret;
                            return (LoopingModeType)ret;
                        }
                    }
                }
                tlog.Error(tag, $"<[ERROR][{GetId()}](AnimatedVectorImageView) Fail to get loopMode from dali>");
                return currentStates.loopMode;
            }
        }

        /// <summary>
        /// LoopCount
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LoopCount
        {
            set
            {
                currentStates.changed = true;
                currentStates.loopCount = value;
                tlog.Fatal(tag, $"<[{GetId()}]SET currentStates.loopCount={currentStates.loopCount}>");
                PropertyMap map = new PropertyMap();
                map.Add(ImageVisualProperty.LoopCount, new PropertyValue(currentStates.loopCount));
                DoAction(vectorImageVisualIndex, (int)actionType.updateProperty, new PropertyValue(map));
            }
            get
            {
                //tlog.Fatal(tag, $"LoopCount get!");
                PropertyMap map = base.Image;
                var ret = 0;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.LoopCount);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            //tlog.Fatal(tag, $"gotten loop count={ret}");
                            if (ret != currentStates.loopCount && ret > 0)
                            {
                                tlog.Fatal(tag, $"<[ERROR][{GetId()}](AnimatedVectorImageView) different loop count! gotten={ret}, loopCount={currentStates.loopCount}>");
                            }
                            currentStates.loopCount = ret;
                            return currentStates.loopCount;
                        }
                    }
                }
                tlog.Error(tag, $"<[ERROR][{GetId()}](AnimatedVectorImageView) Fail to get LoopCount from dali  currentStates.loopCount={currentStates.loopCount}>");
                return currentStates.loopCount;
            }
        }

        /// <summary>
        /// Stop Behavior (Stop End Action)
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StopBehaviorType StopBehavior
        {
            set
            {
                currentStates.stopEndAction = (StopBehaviorType)value;
                currentStates.changed = true;

                tlog.Fatal(tag, $"<[{GetId()}]SET val={currentStates.stopEndAction}>");
                PropertyMap map = new PropertyMap();
                map.Add(ImageVisualProperty.StopBehavior, new PropertyValue((int)currentStates.stopEndAction));
                DoAction(vectorImageVisualIndex, (int)actionType.updateProperty, new PropertyValue(map));
            }
            get
            {
                //tlog.Fatal(tag, $"StopBehavior get!");
                PropertyMap map = base.Image;
                var ret = 0;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.StopBehavior);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            //tlog.Fatal(tag, $"gotten StopBehavior={ret}");
                            if (ret != (int)currentStates.stopEndAction)
                            {
                                tlog.Fatal(tag, $"<[ERROR][{GetId()}](AnimatedVectorImageView) different StopBehavior! gotten={ret}, StopBehavior={currentStates.stopEndAction}>");
                            }
                            currentStates.stopEndAction = (StopBehaviorType)ret;
                            return (StopBehaviorType)ret;
                        }
                    }
                }
                tlog.Error(tag, $"<[ERROR][{GetId()}](AnimatedVectorImageView) Fail to get StopBehavior from dali>");
                return currentStates.stopEndAction;
            }
        }
        #endregion Property


        #region Method
        /// <summary>
        /// SetPlayRange(int startFrame, int endFrame)
        /// </summary>
        /// <param name="startFrame"></param>
        /// <param name="endFrame"></param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPlayRange(int startFrame, int endFrame)
        {
            tlog.Fatal(tag, $"< [{GetId()}] SetPlayRange({startFrame}, {endFrame})");

            currentStates.changed = true;
            currentStates.framePlayRangeMin = startFrame;
            currentStates.framePlayRangeMax = endFrame;

            PropertyArray array = new PropertyArray();
            array.PushBack(new PropertyValue(currentStates.framePlayRangeMin));
            array.PushBack(new PropertyValue(currentStates.framePlayRangeMax));

            PropertyMap map = new PropertyMap();
            map.Add(ImageVisualProperty.PlayRange, new PropertyValue(array));
            DoAction(vectorImageVisualIndex, (int)actionType.updateProperty, new PropertyValue(map));
            tlog.Fatal(tag, $"  [{GetId()}] currentStates.min:({currentStates.framePlayRangeMin}, max:{currentStates.framePlayRangeMax})>");
        }

        /// <summary>
        /// Play Animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Play()
        {
            tlog.Fatal(tag, $"<[{GetId()}] Play()");
            debugPrint();
            base.Play();
            tlog.Fatal(tag, $"[{GetId()}]>");
        }

        /// <summary>
        /// Pause Animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Pause()
        {
            tlog.Fatal(tag, $"<[{GetId()}] Pause()>");
            debugPrint();
            base.Pause();
            tlog.Fatal(tag, $"[{GetId()}]>");
        }

        /// <summary>
        /// Stop Animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Stop()
        {
            tlog.Fatal(tag, $"<[{GetId()}] Stop()");
            debugPrint();
            base.Stop();
            tlog.Fatal(tag, $"[{GetId()}]>");
        }
        #endregion Method


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
                    tlog.Fatal(tag, $"<[{GetId()}] Finished eventhandler added>");
                    visualEventSignalCallback = onVisualEventSignal;
                    VisualEventSignal().Connect(visualEventSignalCallback);
                }
                finishedEventHandler += value;
            }
            remove
            {
                tlog.Fatal(tag, $"<[{GetId()}] Finished eventhandler removed>");
                finishedEventHandler -= value;
                if (finishedEventHandler == null && visualEventSignalCallback != null)
                {
                    VisualEventSignal().Disconnect(visualEventSignalCallback);
                }
            }
        }

        /// <summary>
        /// Loop mode
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum LoopModes
        {
            /// <summary>
            /// Forward
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Forward = 1,
            /// <summary>
            /// Reverse
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Backward = 2
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
        /// @brief Enumeration for what to do when the animation is stopped.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum StopBehaviorType
        {
            /// <summary>
            /// When the animation is stopped, the current frame is shown.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            CurrentFrame,
            /// <summary>
            /// When the animation is stopped, the first frame is shown.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            FirstFrame,
            /// <summary>
            /// When the animation is stopped, the last frame is shown.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            LastFrame
        }

        /// <summary>
        /// @brief Enumeration for what looping mode is in.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        public enum LoopingModeType
        {
            /// <summary>
            /// When the animation arrives at the end in looping mode, the animation restarts from the beginning.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            Restart,
            /// <summary>
            /// When the animation arrives at the end in looping mode, the animation reverses direction and runs backwards again.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            AutoReverse
        }
        #endregion Event, Enum, Struct, ETC


        #region Internal
        internal class VisualEventSignalArgs : EventArgs
        {
            public int VisualIndex
            {
                set;
                get;
            }
            public int SignalId
            {
                set;
                get;
            }
        }

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
        #endregion Internal


        #region Private
        private struct states
        {
            internal string url;
            internal int frame;
            internal int loopCount;
            internal LoopingModeType loopMode;
            internal StopBehaviorType stopEndAction;
            internal int framePlayRangeMin;
            internal int framePlayRangeMax;
            internal bool changed;
            internal int totalFrame;
            internal float scale;
            internal PlayStateType playState;
        };
        private states currentStates;

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

        private const string tag = "NUITEST";
        private const int vectorImageVisualIndex = 10000000 + 1000 + 2;
        private event EventHandler finishedEventHandler;

        private void OnFinished()
        {
            tlog.Fatal(tag, $"<[{GetId()}] OnFinished()>");
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
                    tlog.Fatal(tag, $"targetView is not null! name={v.Name}");
                }
                else
                {
                    tlog.Fatal(tag, $"target is something created from dali");
                }
            }
            VisualEventSignalArgs e = new VisualEventSignalArgs();
            e.VisualIndex = visualIndex;
            e.SignalId = signalId;
            visualEventSignalHandler?.Invoke(this, e);

            tlog.Fatal(tag, $"<[{GetId()}] onVisualEventSignal()! visualIndex={visualIndex}, signalId={signalId}>");
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void VisualEventSignalCallbackType(IntPtr targetView, int visualIndex, int signalId);

        private VisualEventSignalCallbackType visualEventSignalCallback;
        private EventHandler<VisualEventSignalArgs> visualEventSignalHandler;

        private void debugPrint()
        {
            tlog.Fatal(tag, $"===================================");
            tlog.Fatal(tag, $"<[{GetId()}] get currentStates : url={currentStates.url}, loopCount={currentStates.loopCount}, framePlayRangeMin/Max({currentStates.framePlayRangeMin},{currentStates.framePlayRangeMax}) ");
            tlog.Fatal(tag, $"  get from Property : StopBehavior={StopBehavior}, LoopMode={LoopMode}, LoopCount={LoopCount}, PlayState={PlayState} >");
            tlog.Fatal(tag, $"===================================");
        }
        #endregion Private
    }
}