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

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.Components;
using Tizen.NUI;

namespace Tizen.NUI.BaseComponents
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [StructLayout(LayoutKind.Sequential)]
    public struct GestureInfoType : IEquatable<GestureInfoType>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityGesture type { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int xBeg { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int xEnd { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int yBeg { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int yEnd { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityGestureState state { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint eventTime { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(System.Object obj)
        {
            if(obj is GestureInfoType)
            {
                return this.Equals((GestureInfoType)obj);
            }
            return false;
        }

        public bool Equals(GestureInfoType other)
        {
            if ((other == null) || !this.GetType().Equals(other.GetType()))
                return false;

            GestureInfoType sec = (GestureInfoType)other;
            return
              type == sec.type &&
              xBeg == sec.xBeg &&
              xEnd == sec.xEnd &&
              yBeg == sec.yBeg &&
              yEnd == sec.yEnd &&
              state == sec.state &&
              eventTime == sec.eventTime;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(GestureInfoType arg1, GestureInfoType arg2)
        {
            return arg1.Equals(arg2);
        }

        /// <summary>
        /// The != operator.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(GestureInfoType arg1, GestureInfoType arg2)
        {
            return !arg1.Equals(arg2);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return Tuple.Create((int)type, xBeg, xEnd, yBeg, yEnd, (int)state, eventTime).GetHashCode();
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GestureInfoEventArgs : EventArgs
    {
        public GestureInfoType GestureInfo { get; internal set; }
        public int Consumed { get; set; }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GetDescriptionEventArgs : EventArgs
    {
        public string Description { get; internal set; }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GetNameEventArgs : EventArgs
    {
        public string Description { get; internal set; }
    }

    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        internal class ControlHandle : SafeHandle {
            public ControlHandle() : base (IntPtr.Zero, true) {}

            public ControlHandle(IntPtr ptr) : base(ptr, true) {}

            public override bool IsInvalid {
                get {
                    return this.handle == IntPtr.Zero;
                }
            }

            protected override bool ReleaseHandle() {
                Interop.View.DeleteControlHandleView(handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        ControlHandle GetControl() {
            var ret = new ControlHandle(Interop.View.DownCast(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        ///////////////////////////////////////////////////////////////////
        // ***************** AccessiblityDoGestureSignal ****************//
        ///////////////////////////////////////////////////////////////////

        private delegate void GestureInfoHandlerType(IntPtr data);
        private GestureInfoHandlerType gestureInfoCallback;
        private EventHandler<GestureInfoEventArgs> gestureInfoHandler;

        private void OnGestureInfoEvent(IntPtr data) {
            if (data == IntPtr.Zero)
                return;

            if (Marshal.SizeOf<GestureInfoType>() != AccessibilityDoGestureSignal.GetSizeOfGestureInfo()) {
                throw new global::System.ApplicationException("ABI mismatch SizeOf(C# GestureInfo) != SizeOf(c++ GestureInfo)");
            }

            var arg = new GestureInfoEventArgs();

            arg.Consumed = AccessibilityDoGestureSignal.GetResult(data);
            arg.GestureInfo = (GestureInfoType)Marshal.PtrToStructure(data, typeof(GestureInfoType));

            gestureInfoHandler?.Invoke(this, arg);

            AccessibilityDoGestureSignal.SetResult(data, Convert.ToInt32(arg.Consumed));
        }

        // This uses DoGestureInfo signal from C++ API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<GestureInfoEventArgs> GestureInfoReceived {
            add {
                if (gestureInfoHandler == null) {
                    gestureInfoCallback = OnGestureInfoEvent;
                    GestureInfoSignal().Connect(gestureInfoCallback);
                }
                gestureInfoHandler += value;
            }
            remove {
                gestureInfoHandler -= value;
                if (gestureInfoHandler == null && GestureInfoSignal().Empty() == false)
                    GestureInfoSignal().Disconnect(gestureInfoCallback);
            }
        }

        internal AccessibilityDoGestureSignal GestureInfoSignal() {
            var handle = GetControl();
            AccessibilityDoGestureSignal ret = new AccessibilityDoGestureSignal(Interop.ControlDevel.DaliToolkitDevelControlAccessibilityDoGestureSignal(handle), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        ///////////////////////////////////////////////////////////////////
        // ************** AccessiblityGetDescriptionSignal ************* //
        ///////////////////////////////////////////////////////////////////

        private delegate void GetDescriptionHandlerType(IntPtr data);
        private GetDescriptionHandlerType getDescriptionCallback;
        private EventHandler<GetDescriptionEventArgs> getDescriptionHandler;

        private void OnGetDescriptionEvent(IntPtr data) {
            if (data == IntPtr.Zero)
                return;

            var arg = new GetDescriptionEventArgs();
            arg.Description = StringToVoidSignal.ConvertParam1(data);

            getDescriptionHandler?.Invoke(this, arg);
        }

        // This uses GetDescription signal from C++ API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<GetDescriptionEventArgs> DescriptionRequested {
            add {
                if (getDescriptionHandler == null) {
                    getDescriptionCallback = OnGetDescriptionEvent;
                    GetDescriptionSignal().Connect(getDescriptionCallback);
                }
                getDescriptionHandler += value;
            }
            remove {
                getDescriptionHandler -= value;
                if (getDescriptionHandler == null && GetDescriptionSignal().Empty() == false)
                    GetDescriptionSignal().Disconnect(getDescriptionCallback);
            }
        }

        internal StringToVoidSignal GetDescriptionSignal() {
            var handle = GetControl();
            StringToVoidSignal ret = new StringToVoidSignal(Interop.ControlDevel.DaliToolkitDevelControlAccessibilityGetDescriptionSignal(handle), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        ///////////////////////////////////////////////////////////////////
        // ***************** AccessiblityGetNameSignal ***************** //
        ///////////////////////////////////////////////////////////////////

        private delegate void GetNameHandlerType(IntPtr data);
        private GetNameHandlerType getNameCallback;
        private EventHandler<GetNameEventArgs> getNameHandler;

        private void OnGetNameEvent(IntPtr data) {
            if (data == IntPtr.Zero)
                return;

            var arg = new GetNameEventArgs();
            arg.Description = StringToVoidSignal.ConvertParam1(data);

            getNameHandler?.Invoke(this, arg);
        }

        // This uses GetName signal from C++ API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<GetNameEventArgs> NameRequested {
            add {
                if (getNameHandler == null) {
                    getNameCallback = OnGetNameEvent;
                    GetNameSignal().Connect(getNameCallback);
                }
                getNameHandler += value;
            }
            remove {
                getNameHandler -= value;
                if (getNameHandler == null && GetNameSignal().Empty() == false)
                    GetNameSignal().Disconnect(getNameCallback);
            }
        }

        internal StringToVoidSignal GetNameSignal() {
            var handle = GetControl();
            StringToVoidSignal ret = new StringToVoidSignal(Interop.ControlDevel.DaliToolkitDevelControlAccessibilityGetNameSignal(handle), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        ///////////////////////////////////////////////////////////////////
        // **************** AccessibilityActivateSignal **************** //
        ///////////////////////////////////////////////////////////////////

        private delegate void VoidHandlerType();
        private VoidHandlerType activateCallback;
        private EventHandler activateHandler;

        private void OnActivateEvent() {
            activateHandler?.Invoke(this, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Activate {
            add {
                if (activateHandler == null) {
                    activateCallback = OnActivateEvent;
                    ActivateSignal().Connect(activateCallback);
                }
                activateHandler += value;
            }
            remove {
                activateHandler -= value;
                if (activateHandler == null && ActivateSignal().Empty() == false)
                    ActivateSignal().Disconnect(activateCallback);
            }
        }

        internal VoidSignal ActivateSignal() {
            var handle = GetControl();
            VoidSignal ret = new VoidSignal(Interop.ControlDevel.DaliToolkitDevelControlAccessibilityActivateSignal(handle), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        ///////////////////////////////////////////////////////////////////
        // ************ AccessibilityReadingSkippedSignal ************** //
        ///////////////////////////////////////////////////////////////////

        private VoidHandlerType readingSkippedCallback;
        private EventHandler readingSkippedHandler;

        private void OnReadingSkippedEvent() {
            readingSkippedHandler?.Invoke(this, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ReadingSkipped {
            add {
                if (readingSkippedHandler == null) {
                    readingSkippedCallback = OnReadingSkippedEvent;
                    ReadingSkippedSignal().Connect(readingSkippedCallback);
                }
                readingSkippedHandler += value;
            }
            remove {
                readingSkippedHandler -= value;
                if (readingSkippedHandler == null && ReadingSkippedSignal().Empty() == false)
                    ReadingSkippedSignal().Disconnect(readingSkippedCallback);
            }
        }

        internal VoidSignal ReadingSkippedSignal() {
            var handle = GetControl();
            VoidSignal ret = new VoidSignal(Interop.ControlDevel.DaliToolkitDevelControlAccessibilityReadingSkippedSignal(handle), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        ///////////////////////////////////////////////////////////////////
        // ************* AccessibilityReadingPausedSignal ************** //
        ///////////////////////////////////////////////////////////////////

        private VoidHandlerType readingPausedCallback;
        private EventHandler readingPausedHandler;

        private void OnReadingPausedEvent() {
            readingPausedHandler?.Invoke(this, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ReadingPaused {
            add {
                if (readingPausedHandler == null) {
                    readingPausedCallback = OnReadingPausedEvent;
                    ReadingPausedSignal().Connect(readingPausedCallback);
                }
                readingPausedHandler += value;
            }
            remove {
                readingPausedHandler -= value;
                if (readingPausedHandler == null && ReadingPausedSignal().Empty() == false)
                    ReadingPausedSignal().Disconnect(readingPausedCallback);
            }
        }

        internal VoidSignal ReadingPausedSignal() {
            var handle = GetControl();
            VoidSignal ret = new VoidSignal(Interop.ControlDevel.DaliToolkitDevelControlAccessibilityReadingPausedSignal(handle), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        ///////////////////////////////////////////////////////////////////
        // ************* AccessibilityReadingResumedSignal ************* //
        ///////////////////////////////////////////////////////////////////

        private VoidHandlerType readingResumedCallback;
        private EventHandler readingResumedHandler;

        private void OnReadingResumedEvent() {
            readingResumedHandler?.Invoke(this, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ReadingResumed  {
            add {
                if (readingResumedHandler == null) {
                    readingResumedCallback = OnReadingResumedEvent;
                    ReadingResumedSignal().Connect(readingResumedCallback);
                }
                readingResumedHandler += value;
            }
            remove {
                readingResumedHandler -= value;
                if (readingResumedHandler == null && ReadingResumedSignal().Empty() == false)
                    ReadingResumedSignal().Disconnect(readingResumedCallback);
            }
        }

        internal VoidSignal ReadingResumedSignal() {
            var handle = GetControl();
            VoidSignal ret = new VoidSignal(Interop.ControlDevel.DaliToolkitDevelControlAccessibilityReadingResumedSignal(handle), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        ///////////////////////////////////////////////////////////////////
        // ************ AccessibilityReadingCancelledSignal ************ //
        ///////////////////////////////////////////////////////////////////

        private VoidHandlerType readingCancelledCallback;
        private EventHandler readingCancelledHandler;

        private void OnReadingCancelledEvent() {
            readingCancelledHandler?.Invoke(this, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ReadingCancelled  {
            add {
                if (readingCancelledHandler == null) {
                    readingCancelledCallback = OnReadingCancelledEvent;
                    ReadingCancelledSignal().Connect(readingCancelledCallback);
                }
                readingCancelledHandler += value;
            }
            remove {
                readingCancelledHandler -= value;
                if (readingCancelledHandler == null && ReadingCancelledSignal().Empty() == false)
                    ReadingCancelledSignal().Disconnect(readingCancelledCallback);
            }
        }

        internal VoidSignal ReadingCancelledSignal() {
            var handle = GetControl();
            VoidSignal ret = new VoidSignal(Interop.ControlDevel.DaliToolkitDevelControlAccessibilityReadingCancelledSignal(handle), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        ///////////////////////////////////////////////////////////////////
        // ************* AccessibilityReadingStoppedSignal ************* //
        ///////////////////////////////////////////////////////////////////

        private VoidHandlerType readingStoppedCallback;
        private EventHandler readingStoppedHandler;

        private void OnReadingStoppedEvent() {
            readingStoppedHandler?.Invoke(this, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ReadingStopped  {
            add {
                if (readingStoppedHandler == null) {
                    readingStoppedCallback = OnReadingStoppedEvent;
                    ReadingStoppedSignal().Connect(readingStoppedCallback);
                }
                readingStoppedHandler += value;
            }
            remove {
                readingStoppedHandler -= value;
                if (readingStoppedHandler == null && ReadingStoppedSignal().Empty() == false)
                    ReadingStoppedSignal().Disconnect(readingStoppedCallback);
            }
        }

        internal VoidSignal ReadingStoppedSignal() {
            var handle = GetControl();
            VoidSignal ret = new VoidSignal(Interop.ControlDevel.DaliToolkitDevelControlAccessibilityReadingStoppedSignal(handle), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
