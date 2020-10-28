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

namespace Tizen.NUI.BaseComponents
{
    using global::System;
    using global::System.Runtime.InteropServices;
    using System.ComponentModel;
    using Tizen.NUI;
    using tizenlog = Tizen.Log;

    /// <summary>
    /// VectorAnimationView renders an animated vector image
    /// </summary>
    /// <since_tizen> none </since_tizen>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class VectorAnimationView : ImageView
    {
        /// <summary>
        /// VectorAnimationView constructor
        /// </summary>
        /// <since_tizen> none </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VectorAnimationView()
        {
        }

        /// <summary>
        /// Animation finished event
        /// </summary>
        /// <since_tizen> none </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Finished
        {
            add
            {
                if (finishedEventHandler == null)
                {
                    tizenlog.Debug(debugTag, $"Finished()! add!");
                    visualEventSignalCallback = onVisualEventSignal;
                    VisualEventSignal().Connect(visualEventSignalCallback);
                }
                finishedEventHandler += value;
            }
            remove
            {
                tizenlog.Debug(debugTag, $"Finished()! remove!");
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
        /// <since_tizen> none </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum PlayStateType
        {
            /// <summary>
            /// Invalid
            /// </summary>
            Invalid = -1,
            /// <summary>
            /// Vector Animation has stopped
            /// </summary>
            /// <since_tizen> none </since_tizen>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Stopped,
            /// <summary>
            /// The vector animation is playing
            /// </summary>
            /// <since_tizen> none </since_tizen>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Playing,
            /// <summary>
            /// The vector animation is paused
            /// </summary>
            /// <since_tizen> none </since_tizen>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Paused
        }

        /// <summary>
        /// Resource URL
        /// </summary>
        /// <since_tizen> none </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string URL
        {
            get
            {
                string ret = ResourceUrl;
                tizenlog.Debug(debugTag, $"URL get! base resource mUrl={ret}, name={Name}");
                PropertyMap map = Image;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.URL);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            tizenlog.Debug(debugTag, $"gotten url={ret}");
                            return ret;
                        }
                    }
                }
                tizenlog.Error(tag, "[ERROR] fail to get ResourceUrl from dali");
                return ret;
            }
            set
            {
                tizenlog.Debug(debugTag, $"URL set! value={value}");
                string ret = (value == null ? "" : value);
                url = ret;
                PropertyMap map = new PropertyMap();
                map.Add(Visual.Property.Type, new PropertyValue((int)DevelVisual.Type.AnimatedVectorImage))
                    .Add(ImageVisualProperty.URL, new PropertyValue(ret));
                Image = map;
            }
        }

        /// <summary>
        /// The number of times the VectorAnimationView will be looped
        /// </summary>
        /// <since_tizen> none </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LoopCount
        {
            set
            {
                tizenlog.Debug(debugTag, $"LoopCount set val={value}");
                PropertyMap map = new PropertyMap();
                map.Add(ImageVisualProperty.LoopCount, new PropertyValue(value));
                DoAction(vectorImageVisualIndex, (int)actionType.updateProperty, new PropertyValue(map));
            }
            get
            {
                tizenlog.Debug(debugTag, $"LoopCount get!");
                PropertyMap map = base.Image;
                var ret = 0;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.LoopCount);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            tizenlog.Debug(debugTag, $"gotten loop count={ret}");
                            return ret;
                        }
                    }
                }
                tizenlog.Error(tag, "[ERROR] fail to get LoopCount from dali");
                return ret;
            }
        }

        /// <summary>
        /// The playing state
        /// </summary>
        /// <since_tizen> none </since_tizen>
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
        /// The animation progress
        /// </summary>
        /// <since_tizen> none </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CurrentProgress
        {
            set
            {
                float val = value;
                tizenlog.Debug(debugTag, $"set progress={val}");
                DoAction(vectorImageVisualIndex, (int)actionType.jumpTo, new PropertyValue(val));
            }
            get
            {
                float ret = -1.0f;
                PropertyMap map = Image;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.CurrentProgress);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            return ret;
                        }
                    }
                }
                tizenlog.Error(tag, $"[ERROR] fail to get CurrentProgress from dali");
                return ret;
            }
        }

        /// <summary>
        /// The animation frame
        /// </summary>
        /// <since_tizen> none </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CurrentFrame
        {
            set
            {
                currentFrame = value;
                //to do
            }
            get
            {
                //to do
                return currentFrame;
            }
        }

        /// <summary>
        /// Animation will play between the values specified. Both values should be between 0-1, otherwise they will be ignored. 
        /// If the range provided is not in proper order(minimum, maximum ), it will be reordered.
        /// Default 0 and 1
        /// </summary>
        /// <param name="range">Vector2 type, between 0 and 1</param>
        /// <since_tizen> none </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPlayRange(Vector2 range)
        {
            PropertyMap map = new PropertyMap();
            map.Add(ImageVisualProperty.PlayRange, new PropertyValue(range));
            DoAction(vectorImageVisualIndex, (int)actionType.updateProperty, new PropertyValue(map));
        }

        /// <summary>
        /// Get Animation play range
        /// </summary>
        /// <returns>Vector2 type, between 0 and 1</returns>
        /// <since_tizen> none </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetPlayRange()
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

        /// <summary>
        /// Play VectorAnimationView
        /// </summary>
        /// <since_tizen> none </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        new public void Play()
        {
            tizenlog.Debug(debugTag, $"play() called! my mUrl={url}");
            base.Play();
        }

        /// <summary>
        /// Pause VectorAnimationView
        /// </summary>
        /// <since_tizen> none </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        new public void Pause()
        {
            tizenlog.Debug(debugTag, $"pause() called! my mUrl={url}");
            base.Pause();
        }

        /// <summary>
        /// Stop VectorAnimationView
        /// </summary>
        /// <since_tizen> none </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        new public void Stop()
        {
            tizenlog.Debug(debugTag, $"stop() called! my mUrl={url}");
            base.Stop();
        }

        /// <summary>
        /// You can override it to clean-up your own resources
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// <since_tizen> none </since_tizen>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            base.Dispose(type);
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

        private enum actionType
        {
            /// <summary>
            /// Play the animated vector image
            /// </summary>
            play,
            /// <summary>
            /// Pause the animated vector image
            /// </summary>
            pause,
            /// <summary>
            /// Stop the animated vector image. This is also Default playback mode
            /// </summary>
            stop,
            /// <summary>
            /// Jump to the specified frame. Property::FLOAT value should be passed
            /// </summary>
            jumpTo,
            /// <summary>
            /// Update the properties of the animated vector image
            /// </summary>
            updateProperty
        };

        private struct DevelVisual
        {
            internal enum Type
            {
                /// <summary>
                /// Renders an animated gradient
                /// </summary>
                AnimatedGradient = Tizen.NUI.Visual.Type.AnimatedImage + 1,
                /// <summary>
                /// Renders an animated vector image
                /// </summary>
                AnimatedVectorImage = Tizen.NUI.Visual.Type.AnimatedImage + 2,
            }
        }

        private const string debugTag = "NUITEST";
        private const string tag = "NUI";
        //DummyControl.Property.TEST_VISUAL
        private const int vectorImageVisualIndex = 10000000 + 1000 + 2;
        private string url;
        private int currentFrame;
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
                    tizenlog.Debug(debugTag, $"targetView is not null! name={v.Name}");
                }
                else
                {
                    tizenlog.Debug(debugTag, $"target is something created from dali");
                }
            }
            VisualEventSignalArgs e = new VisualEventSignalArgs();
            e.VisualIndex = visualIndex;
            e.SignalId = signalId;
            visualEventSignalHandler?.Invoke(this, e);

            tizenlog.Debug(debugTag, $"@@ onVisualEventSignal()! visualIndex={visualIndex}, signalId={signalId}");
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void VisualEventSignalCallbackType(IntPtr targetView, int visualIndex, int signalId);

        private VisualEventSignalCallbackType visualEventSignalCallback;

        private EventHandler<VisualEventSignalArgs> visualEventSignalHandler;

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
            VisualEventSignal ret = new VisualEventSignal(InterOp.View_VisaulEventSignal(View.getCPtr(this)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    } // VectorAnimationView : ImageView
} // namespace Tizen.NUI.BaseComponents

namespace Tizen.NUI
{
    using Tizen.NUI.BaseComponents;
    using global::System;
    using global::System.Runtime.InteropServices;
    using System.ComponentModel;
    using tizenlog = Tizen.Log;

    internal class VisualEventSignal : IDisposable
    {
        public VisualEventSignal() : this(InterOp.new_VisualEventSignal(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        ~VisualEventSignal()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    InterOp.delete_VisualEventSignal(swigCPtr);
                }
                swigCPtr = new HandleRef(null, IntPtr.Zero);
            }
            disposed = true;
        }

        public bool Empty()
        {
            bool ret = InterOp.VisualEventSignal_Empty(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetConnectionCount()
        {
            uint ret = InterOp.VisualEventSignal_GetConnectionCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Connect(Delegate func)
        {
            tizenlog.Debug(tag, $"Connect()!");

            IntPtr ip = Marshal.GetFunctionPointerForDelegate<Delegate>(func);
            {
                InterOp.VisualEventSignal_Connect(swigCPtr, new HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void Disconnect(Delegate func)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate<Delegate>(func);
            {
                InterOp.VisualEventSignal_Disconnect(swigCPtr, new HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void Emit(View target, int visualIndex, int signalId)
        {
            InterOp.VisualEventSignal_Emit(swigCPtr, View.getCPtr(target), visualIndex, signalId);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal VisualEventSignal(IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new HandleRef(this, cPtr);
        }

        internal static HandleRef getCPtr(VisualEventSignal obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
        }

        private const string tag = "NUI";
        private HandleRef swigCPtr;
        protected bool swigCMemOwn;

        private bool isDisposeQueued = false;
        protected bool disposed = false;

    } // internal class VisualEventSignal : IDisposable
} // namespace Tizen.NUI

namespace Tizen.NUI
{
    using global::System.Runtime.InteropServices;
    using global::System;

    internal partial class InterOp
    {
        const string Lib = "libdali-csharp-binder.so";

        [DllImport(Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_Empty")]
        public static extern bool VisualEventSignal_Empty(HandleRef jarg1);

        [DllImport(Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_GetConnectionCount")]
        public static extern uint VisualEventSignal_GetConnectionCount(HandleRef jarg1);

        [DllImport(Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_Connect")]
        public static extern void VisualEventSignal_Connect(HandleRef jarg1, HandleRef jarg2);

        [DllImport(Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_Disconnect")]
        public static extern void VisualEventSignal_Disconnect(HandleRef jarg1, HandleRef jarg2);

        [DllImport(Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_Emit")]
        public static extern void VisualEventSignal_Emit(HandleRef jarg1, HandleRef jarg2, int jarg3, int jarg4);

        [DllImport(Lib, EntryPoint = "CSharp_Dali_new_VisualEventSignal")]
        public static extern IntPtr new_VisualEventSignal();

        [DllImport(Lib, EntryPoint = "CSharp_Dali_delete_VisualEventSignal")]
        public static extern void delete_VisualEventSignal(HandleRef jarg1);

        [DllImport(Lib, EntryPoint = "CSharp_Dali_View_VisualEventSignal")]
        public static extern IntPtr View_VisaulEventSignal(HandleRef jarg1);
    }
}
