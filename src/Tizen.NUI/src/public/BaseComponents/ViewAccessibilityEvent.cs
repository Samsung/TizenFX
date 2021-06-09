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
    /// <summary>
    /// Gesture information type containing all values needed to AccessibilityDoGestureSignal.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [StructLayout(LayoutKind.Sequential)]
    public struct GestureInfoType : IEquatable<GestureInfoType>
    {
        /// <summary>
        /// Accessibility enumerated gesture type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityGesture Type { get; set; }

        /// <summary>
        /// The X position where the gesture begins.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int StartPositionX { get; set; }

        /// <summary>
        /// The X position where the gesture ends.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int EndPositionX { get; set; }

        /// <summary>
        /// The Y position where the gesture begins.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int StartPositionY { get; set; }

        /// <summary>
        /// The Y position where the gesture ends.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int EndPositionY { get; set; }

        /// <summary>
        /// The enumerated state of gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityGestureState State { get; set; }

        /// <summary>
        /// The time when event occured.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint EventTime { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object</param>
        /// <returns>True if the specified object is equal to the current object, otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(System.Object obj)
        {
            if (obj is GestureInfoType)
            {
                return this.Equals((GestureInfoType)obj);
            }
            return false;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The GestureInfoType to compare with the current GestureInfoType</param>
        /// <returns>True if equal GestureInfoType, otherwise false</returns>
        public bool Equals(GestureInfoType other)
        {
            if ((other == null) || !this.GetType().Equals(other.GetType()))
            {
                return false;
            }

            GestureInfoType compared = (GestureInfoType)other;
            // Return true if the fields match:
            return (Type == compared.Type &&
                    StartPositionX == compared.StartPositionX &&
                    EndPositionX == compared.EndPositionX &&
                    StartPositionY == compared.StartPositionY &&
                    EndPositionY == compared.EndPositionY &&
                    State == compared.State &&
                    EventTime == compared.EventTime);
        }

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="arg1">The first value</param>
        /// <param name="arg2">The second value</param>
        /// <returns>True if GestureInfoTypes are equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(GestureInfoType arg1, GestureInfoType arg2)
        {
            return arg1.Equals(arg2);
        }

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="arg1">The first value</param>
        /// <param name="arg2">The second value</param>
        /// <returns>True if GestureInfoTypes are not equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(GestureInfoType arg1, GestureInfoType arg2)
        {
            return !arg1.Equals(arg2);
        }

        /// <summary>
        /// Gets the hash code of this baseHandle.
        /// </summary>
        /// <returns>The Hash Code</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return Tuple.Create((int)Type, StartPositionX, EndPositionX, StartPositionY, EndPositionY, (int)State, EventTime).GetHashCode();
        }
    }

    /// <summary>
    /// Accessibility gesture information event arguments.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GestureInfoEventArgs : EventArgs
    {
        /// <summary>
        /// The gesture information type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GestureInfoType GestureInfo { get; internal set; }

        /// <summary>
        /// True if the event is consumed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Consumed { get; set; }
    }

    /// <summary>
    /// Accessibility description event arguments.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GetDescriptionEventArgs : EventArgs
    {
        /// <summary>
        /// Accessibility description.
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// Accessibility name event arguments.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GetNameEventArgs : EventArgs
    {
        /// <summary>
        /// Accessibility name.
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        internal class ControlHandle : SafeHandle
        {
            public ControlHandle() : base(IntPtr.Zero, true) { }

            public ControlHandle(IntPtr ptr) : base(ptr, true) { }

            public override bool IsInvalid
            {
                get
                {
                    return this.handle == IntPtr.Zero;
                }
            }

            protected override bool ReleaseHandle()
            {
                Interop.View.DeleteControlHandleView(handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }

        /// <summary>
        /// Gets the control handle.
        /// </summary>
        /// <returns>The control handle of the view</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ControlHandle GetControl()
        {
            var result = new ControlHandle(Interop.View.DownCast(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        ///////////////////////////////////////////////////////////////////
        // ***************** AccessiblityDoGestureSignal ****************//
        ///////////////////////////////////////////////////////////////////

        private delegate void GestureInfoHandlerType(IntPtr data);
        private GestureInfoHandlerType gestureInfoCallback;
        private EventHandler<GestureInfoEventArgs> gestureInfoHandler;
        private AccessibilityDoGestureSignal gestureInfoSignal;

        private void OnAccessibilityGestureInfoEvent(IntPtr data)
        {
            if (data == IntPtr.Zero)
            {
                return;
            }

            if (Marshal.SizeOf<GestureInfoType>() != AccessibilityDoGestureSignal.GetSizeOfGestureInfo())
            {
                throw new global::System.ApplicationException("ABI mismatch SizeOf(C# GestureInfo) != SizeOf(c++ GestureInfo)");
            }

            var arg = new GestureInfoEventArgs()
            {
                Consumed = AccessibilityDoGestureSignal.GetResult(data),
                GestureInfo = (GestureInfoType)Marshal.PtrToStructure(data, typeof(GestureInfoType)),
            };
            gestureInfoHandler?.Invoke(this, arg);

            AccessibilityDoGestureSignal.SetResult(data, arg.Consumed);
        }

        /// <summary>
        /// AccessibilityGestureInfo is received.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<GestureInfoEventArgs> AccessibilityGestureInfoReceived
        {
            // This uses DoGestureInfo signal from C++ API.
            add
            {
                if (gestureInfoHandler == null)
                {
                    gestureInfoCallback = OnAccessibilityGestureInfoEvent;
                    gestureInfoSignal = this.AccessibilityGestureInfoSignal();
                    gestureInfoSignal?.Connect(gestureInfoCallback);
                }
                gestureInfoHandler += value;
            }
            remove
            {
                gestureInfoHandler -= value;
                if (gestureInfoHandler == null && gestureInfoCallback != null)
                {
                    gestureInfoSignal?.Disconnect(gestureInfoCallback);
                    gestureInfoSignal?.Dispose();
                    gestureInfoSignal = null;
                }
            }
        }

        internal AccessibilityDoGestureSignal AccessibilityGestureInfoSignal()
        {
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
        private StringToVoidSignal getDescriptionSignal;

        private void OnGetAccessibilityDescriptionEvent(IntPtr data)
        {
            if (data == IntPtr.Zero)
            {
                return;
            }

            var arg = new GetDescriptionEventArgs()
            {
                Description = StringToVoidSignal.GetResult(data)
            };
            getDescriptionHandler?.Invoke(this, arg);

            StringToVoidSignal.SetResult(data, arg.Description);
        }

        /// <summary>
        /// AccessibilityDescription is requested.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<GetDescriptionEventArgs> AccessibilityDescriptionRequested
        {
            // This uses GetDescription signal from C++ API.
            add
            {
                if (getDescriptionHandler == null)
                {
                    getDescriptionCallback = OnGetAccessibilityDescriptionEvent;
                    getDescriptionSignal = this.GetAccessibilityDescriptionSignal();
                    getDescriptionSignal?.Connect(getDescriptionCallback);
                }
                getDescriptionHandler += value;
            }
            remove
            {
                getDescriptionHandler -= value;
                if (getDescriptionHandler == null && getDescriptionCallback != null)
                {
                    getDescriptionSignal?.Disconnect(getDescriptionCallback);
                    getDescriptionSignal?.Dispose();
                    getDescriptionSignal = null;
                }
            }
        }

        internal StringToVoidSignal GetAccessibilityDescriptionSignal()
        {
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
        private StringToVoidSignal getNameSignal;

        private void OnGetAccessibilityNameEvent(IntPtr data)
        {
            if (data == IntPtr.Zero)
            {
                return;
            }

            var arg = new GetNameEventArgs()
            {
                Name = StringToVoidSignal.GetResult(data)
            };
            getNameHandler?.Invoke(this, arg);

            StringToVoidSignal.SetResult(data, arg.Name);
        }

        /// <summary>
        /// AccessibilityName is requested.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<GetNameEventArgs> AccessibilityNameRequested
        {
            // This uses GetName signal from C++ API.
            add
            {
                if (getNameHandler == null)
                {
                    getNameCallback = OnGetAccessibilityNameEvent;
                    getNameSignal = this.GetAccessibilityNameSignal();
                    getNameSignal?.Connect(getNameCallback);
                }
                getNameHandler += value;
            }
            remove
            {
                getNameHandler -= value;
                if (getNameHandler == null && getNameCallback != null)
                {
                    getNameSignal?.Disconnect(getNameCallback);
                    getNameSignal?.Dispose();
                    getNameSignal = null;
                }
            }
        }

        internal StringToVoidSignal GetAccessibilityNameSignal()
        {
            var handle = GetControl();
            StringToVoidSignal ret = new StringToVoidSignal(Interop.ControlDevel.DaliToolkitDevelControlAccessibilityGetNameSignal(handle), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        ///////////////////////////////////////////////////////////////////
        // **************** AccessibilityActivatedSignal **************** //
        ///////////////////////////////////////////////////////////////////

        private delegate void VoidHandlerType();
        private VoidHandlerType activateCallback;
        private EventHandler activateHandler;
        internal VoidSignal ActivateSignal;

        private void OnAccessibilityActivatedEvent()
        {
            activateHandler?.Invoke(this, null);
        }

        /// <summary>
        /// Accessibility is activated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AccessibilityActivated
        {
            add
            {
                if (activateHandler == null)
                {
                    activateCallback = OnAccessibilityActivatedEvent;
                    ActivateSignal = this.AccessibilityActivatedSignal();
                    ActivateSignal?.Connect(activateCallback);
                }
                activateHandler += value;
            }
            remove
            {
                activateHandler -= value;
                if (activateHandler == null && activateCallback != null)
                {
                    ActivateSignal?.Disconnect(activateCallback);
                    ActivateSignal?.Dispose();
                    ActivateSignal = null;
                }
            }
        }

        internal VoidSignal AccessibilityActivatedSignal()
        {
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
        internal VoidSignal ReadingSkippedSignal;

        private void OnAccessibilityReadingSkippedEvent()
        {
            readingSkippedHandler?.Invoke(this, null);
        }

        /// <summary>
        /// AccessibilityReading is skipped.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AccessibilityReadingSkipped
        {
            add
            {
                if (readingSkippedHandler == null)
                {
                    readingSkippedCallback = OnAccessibilityReadingSkippedEvent;
                    ReadingSkippedSignal = this.AccessibilityReadingSkippedSignal();
                    ReadingSkippedSignal?.Connect(readingSkippedCallback);
                }
                readingSkippedHandler += value;
            }
            remove
            {
                readingSkippedHandler -= value;
                if (readingSkippedHandler == null && readingSkippedCallback != null)
                {
                    ReadingSkippedSignal?.Disconnect(readingSkippedCallback);
                    ReadingSkippedSignal?.Dispose();
                    ReadingSkippedSignal = null;
                }
            }
        }

        internal VoidSignal AccessibilityReadingSkippedSignal()
        {
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
        internal VoidSignal ReadingPausedSignal;

        private void OnAccessibilityReadingPausedEvent()
        {
            readingPausedHandler?.Invoke(this, null);
        }

        /// <summary>
        /// AccessibilityReading is paused.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AccessibilityReadingPaused
        {
            add
            {
                if (readingPausedHandler == null)
                {
                    readingPausedCallback = OnAccessibilityReadingPausedEvent;
                    ReadingPausedSignal = this.AccessibilityReadingPausedSignal();
                    ReadingPausedSignal?.Connect(readingPausedCallback);
                }
                readingPausedHandler += value;
            }
            remove
            {
                readingPausedHandler -= value;
                if (readingPausedHandler == null && readingPausedCallback != null)
                {
                    ReadingPausedSignal?.Disconnect(readingPausedCallback);
                    ReadingPausedSignal?.Dispose();
                    ReadingPausedSignal = null;
                }
            }
        }

        internal VoidSignal AccessibilityReadingPausedSignal()
        {
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
        internal VoidSignal ReadingResumedSignal;

        private void OnAccessibilityReadingResumedEvent()
        {
            readingResumedHandler?.Invoke(this, null);
        }

        /// <summary>
        /// AccessibilityReading is resumed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AccessibilityReadingResumed
        {
            add
            {
                if (readingResumedHandler == null)
                {
                    readingResumedCallback = OnAccessibilityReadingResumedEvent;
                    ReadingResumedSignal = this.AccessibilityReadingResumedSignal();
                    ReadingResumedSignal?.Connect(readingResumedCallback);
                }
                readingResumedHandler += value;
            }
            remove
            {
                readingResumedHandler -= value;
                if (readingResumedHandler == null && readingResumedCallback != null)
                {
                    ReadingResumedSignal?.Disconnect(readingResumedCallback);
                    ReadingResumedSignal?.Dispose();
                    ReadingResumedSignal = null;
                }
            }
        }

        internal VoidSignal AccessibilityReadingResumedSignal()
        {
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
        internal VoidSignal ReadingCancelledSignal;

        private void OnAccessibilityReadingCancelledEvent()
        {
            readingCancelledHandler?.Invoke(this, null);
        }

        /// <summary>
        /// AccessibilityReading is cancelled.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AccessibilityReadingCancelled
        {
            add
            {
                if (readingCancelledHandler == null)
                {
                    readingCancelledCallback = OnAccessibilityReadingCancelledEvent;
                    ReadingCancelledSignal = this.AccessibilityReadingCancelledSignal();
                    ReadingCancelledSignal?.Connect(readingCancelledCallback);
                }
                readingCancelledHandler += value;
            }
            remove
            {
                readingCancelledHandler -= value;
                if (readingCancelledHandler == null && readingCancelledCallback != null)
                {
                    ReadingCancelledSignal?.Disconnect(readingCancelledCallback);
                    ReadingCancelledSignal?.Dispose();
                    ReadingCancelledSignal = null;
                }
            }
        }

        internal VoidSignal AccessibilityReadingCancelledSignal()
        {
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
        internal VoidSignal ReadingStoppedSignal;

        private void OnAccessibilityReadingStoppedEvent()
        {
            readingStoppedHandler?.Invoke(this, null);
        }

        /// <summary>
        /// AccessibilityReading is stopped.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AccessibilityReadingStopped
        {
            add
            {
                if (readingStoppedHandler == null)
                {
                    readingStoppedCallback = OnAccessibilityReadingStoppedEvent;
                    ReadingStoppedSignal = this.AccessibilityReadingStoppedSignal();
                    ReadingStoppedSignal?.Connect(readingStoppedCallback);
                }
                readingStoppedHandler += value;
            }
            remove
            {
                readingStoppedHandler -= value;
                if (readingStoppedHandler == null && readingStoppedCallback != null)
                {
                    ReadingStoppedSignal?.Disconnect(readingStoppedCallback);
                    ReadingStoppedSignal?.Dispose();
                    ReadingStoppedSignal = null;
                }
            }
        }

        internal VoidSignal AccessibilityReadingStoppedSignal()
        {
            var handle = GetControl();
            VoidSignal ret = new VoidSignal(Interop.ControlDevel.DaliToolkitDevelControlAccessibilityReadingStoppedSignal(handle), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
