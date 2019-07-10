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
    public class AnimatedVectorImageView : ImageView
    {
        #region Constructor, Distructor, Dispose
        /// <summary>
        /// AnimatedVectorImageView
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatedVectorImageView() : base()
        {
            NUILog.Debug($"AnimatedVectorImageView() constructor!");
            currentStates.url = "";
            currentStates.frame = -1;
            currentStates.loopCount = 0;
            currentStates.loopMode = LoopModes.Forward;
            //currentStates.stopEndAction = EndActions.Cancel;
            currentStates.framePlayRangeMin = -1;
            currentStates.framePlayRangeMax = -1;
            currentStates.changed = false;
            currentStates.totalFrame = -1;
            currentStates.scale = 1.0f;
        }

        /// <summary>
        /// AnimatedVectorImageView(float scale)
        /// </summary>
        /// <param name="scale"></param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatedVectorImageView(float scale) : this()
        {
            currentStates.scale = scale;
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

            //disconnect event signal
            if (finishedEventHandler != null && visualEventSignalCallback != null)
            {
                VisualEventSignal().Disconnect(visualEventSignalCallback);
                finishedEventHandler = null;
                NUILog.Debug($"disconnect event signal");
            }

            base.Dispose(type);
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
                NUILog.Debug($"URL set! value={value}");
                string ret = (value == null ? "" : value);
                currentStates.url = ret;
                currentStates.changed = true;

                PropertyMap map = new PropertyMap();
                map.Add(Visual.Property.Type, new PropertyValue((int)DevelVisual.Type.AnimatedVectorImage))
                    .Add(ImageVisualProperty.URL, new PropertyValue(currentStates.url))
                    .Add(ImageVisualProperty.LoopCount, new PropertyValue(currentStates.loopCount));
                //.Add(ImageVisualProperty.StopEndAction, new PropertyValue((int)currentStates.stopEndAction))
                //.Add(ImageVisualProperty.LoopMode, new PropertyValue((int)currentStates.loopMode));
                Image = map;
            }
            get
            {
                string ret = ResourceUrl;
                NUILog.Debug($"URL get! base ret={ret}, Name={Name}");
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
                tizenlog.Error(tag, "[ERROR] fail to get URL from dali");
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
        /// CurrentFrameNumber
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CurrentFrameNumber
        {
            set
            {
                currentStates.frame = value;
                NUILog.Debug($"set CurrentFrameNumber={currentStates.frame}");
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
                            NUILog.Debug($"CurrentFrameNumber get! val={ret}");
                            return ret;
                        }
                    }
                }
                tizenlog.Error(tag, $"[ERROR] fail to get CurrentFrameNumber from dali!! ret={ret}");
                return ret;
            }
        }

        /// <summary>
        /// Loop Mode of animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LoopModes LoopMode
        {
            set
            {
                currentStates.loopMode = (LoopModes)value;
                currentStates.changed = true;


                NUILog.Debug($"LoopMode set val={currentStates.loopMode}");
                //PropertyMap map = new PropertyMap();
                //map.Add(ImageVisualProperty.LoopMode, new PropertyValue((int)currentStates.loopMode));
                //DoAction(vectorImageVisualIndex, (int)actionType.updateProperty, new PropertyValue(map));
            }
            get
            {
                NUILog.Debug($"LoopMode get!");
                PropertyMap map = base.Image;
                var ret = 0;
                //if (map != null)
                //{
                //    PropertyValue val = map.Find(ImageVisualProperty.LoopMode);
                //    if (val != null)
                //    {
                //        if (val.Get(out ret))
                //        {
                //            NUILog.Debug($"gotten LoopMode={ret}");
                //            if (ret != (int)currentStates.loopMode && ret > 0)
                //            {
                //                NUILog.Debug($"different LoopMode! gotten={ret}, loopMode={currentStates.loopMode}");
                //                return (int)currentStates.loopMode;
                //            }
                //            return ret;
                //        }
                //    }
                //}
                tizenlog.Error(tag, "[ERROR] fail to get loopMode from dali");
                return (LoopModes)ret;
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
                NUILog.Debug($"LoopCount set! currentStates.loopCount={currentStates.loopCount}");
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
                                NUILog.Debug($"[ERR] different loop count! gotten={ret}, loopCount={currentStates.loopCount}");
                            }
                            return currentStates.loopCount;
                        }
                    }
                }
                tizenlog.Error(tag, $"[ERROR] fail to get LoopCount from dali  currentStates.loopCount={currentStates.loopCount}");
                return currentStates.loopCount;
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
            NUILog.Debug($"SetPlayRange(startFrame={startFrame}, endFrame={endFrame})");

            currentStates.changed = true;
            currentStates.framePlayRangeMin = startFrame;
            currentStates.framePlayRangeMax = endFrame;

            PropertyArray array = new PropertyArray();
            array.PushBack(new PropertyValue(currentStates.framePlayRangeMin));
            array.PushBack(new PropertyValue(currentStates.framePlayRangeMax));

            PropertyMap map = new PropertyMap();
            map.Add(ImageVisualProperty.PlayRange, new PropertyValue(array));
            DoAction(vectorImageVisualIndex, (int)actionType.updateProperty, new PropertyValue(map));
            NUILog.Debug($"currentStates.framePlayRangeMin={currentStates.framePlayRangeMin}, currentStates.framePlayRangeMax={currentStates.framePlayRangeMax})");
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
        }

        /// <summary>
        /// Stop Animation.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Stop()
        {
            NUILog.Debug($"Stop()!");
            debugPrint();
            base.Stop();
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
            internal LoopModes loopMode;
            //internal EndActions stopEndAction;
            internal int framePlayRangeMin;
            internal int framePlayRangeMax;
            internal bool changed;
            internal int totalFrame;
            internal float scale;
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
        #endregion Private
    }
}
