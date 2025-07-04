/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
            if (!this.GetType().Equals(other.GetType()))
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
                if (IsInvalid)
                {
                    return true;
                }

                Interop.View.DeleteControlHandleView(handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    base.Dispose(true);
                }
                else
                {
                    Tizen.Log.Error("NUI", "Warning! ControlHandle is disposed by Unmanaged code. Don't forget to add 'using' keyword before use ControlHandle\n");
                    DisposeQueue.Instance.Add(this);
                }
            }
        }

        /// <summary>
        /// Gets the control handle.
        /// </summary>
        /// <remarks>
        /// We don't allow to keep ControlHandle in managed code.
        /// Don't forget to call Dispose() after using it.
        /// </remarks>
        /// <returns>The control handle of the view</returns>
        internal ControlHandle GetControl()
        {
            var result = new ControlHandle(Interop.BaseHandle.NewBaseHandle(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        ///////////////////////////////////////////////////////////////////
        // ***************** AccessiblityDoGestureSignal ****************//
        ///////////////////////////////////////////////////////////////////

        private delegate void GestureInfoHandlerType(IntPtr data);
        private GestureInfoHandlerType gestureInfoCallback;
        private EventHandler<GestureInfoEventArgs> gestureInfoHandler;

        private void OnAccessibilityGestureInfoEvent(IntPtr data)
        {
            if (data == IntPtr.Zero)
            {
                return;
            }

            if (Marshal.SizeOf<GestureInfoType>() != Interop.DoGestureSignal.GetSizeOfGestureInfo())
            {
                throw new global::System.ApplicationException("ABI mismatch SizeOf(C# GestureInfo) != SizeOf(c++ GestureInfo)");
            }

            var arg = new GestureInfoEventArgs()
            {
                Consumed = Interop.DoGestureSignal.GetResult(data),
                GestureInfo = (GestureInfoType)Marshal.PtrToStructure(data, typeof(GestureInfoType)),
            };
            gestureInfoHandler?.Invoke(this, arg);

            Interop.DoGestureSignal.SetResult(data, arg.Consumed);
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
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityDoGestureConnect(handle, gestureInfoCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                gestureInfoHandler += value;
            }
            remove
            {
                gestureInfoHandler -= value;
                if (gestureInfoHandler == null && gestureInfoCallback != null)
                {
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityDoGestureDisconnect(handle, gestureInfoCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    gestureInfoCallback = null;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////
        // ************** AccessiblityGetDescriptionSignal ************* //
        ///////////////////////////////////////////////////////////////////

        private delegate void GetDescriptionHandlerType(IntPtr data);
        private GetDescriptionHandlerType getDescriptionCallback;
        private EventHandler<GetDescriptionEventArgs> getDescriptionHandler;

        private void OnGetAccessibilityDescriptionEvent(IntPtr data)
        {
            if (data == IntPtr.Zero)
            {
                return;
            }

            var arg = new GetDescriptionEventArgs()
            {
                Description = Interop.StringToVoidSignal.GetResult(data)
            };
            getDescriptionHandler?.Invoke(this, arg);

            Interop.StringToVoidSignal.SetResult(data, arg.Description);
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
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityGetDescriptionConnect(handle, getDescriptionCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                getDescriptionHandler += value;
            }
            remove
            {
                getDescriptionHandler -= value;
                if (getDescriptionHandler == null && getDescriptionCallback != null)
                {
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityGetDescriptionDisconnect(handle, getDescriptionCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    getDescriptionCallback = null;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////
        // ***************** AccessiblityGetNameSignal ***************** //
        ///////////////////////////////////////////////////////////////////

        private delegate void GetNameHandlerType(IntPtr data);
        private GetNameHandlerType getNameCallback;
        private EventHandler<GetNameEventArgs> getNameHandler;

        private void OnGetAccessibilityNameEvent(IntPtr data)
        {
            if (data == IntPtr.Zero)
            {
                return;
            }

            var arg = new GetNameEventArgs()
            {
                Name = Interop.StringToVoidSignal.GetResult(data)
            };
            getNameHandler?.Invoke(this, arg);

            Interop.StringToVoidSignal.SetResult(data, arg.Name);
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
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityGetNameConnect(handle, getNameCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                getNameHandler += value;
            }
            remove
            {
                getNameHandler -= value;
                if (getNameHandler == null && getNameCallback != null)
                {
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityGetNameDisconnect(handle, getNameCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    getNameCallback = null;
                }
            }
        }

        internal bool IsAccessibilityNameSignalEmpty()
        {
            bool result = false;
            using var handle = GetControl();
            result = Interop.AccessibilitySignal.AccessibilityGetNameEmpty(handle);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return result;
        }

        // AccessibilityValueTextRequested

        [EditorBrowsable(EditorBrowsableState.Never)]
        public class AccessibilityValueTextRequestedEventArgs : EventArgs
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Text { get; set; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AccessibilityValueTextRequestedEventArgs> AccessibilityValueTextRequested;

        ///////////////////////////////////////////////////////////////////
        // **************** AccessibilityActivatedSignal **************** //
        ///////////////////////////////////////////////////////////////////

        private delegate void VoidHandlerType();
        private VoidHandlerType activateCallback;
        private EventHandler activateHandler;

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
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityActivateConnect(handle, activateCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                activateHandler += value;
            }
            remove
            {
                activateHandler -= value;
                if (activateHandler == null && activateCallback != null)
                {
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityActivateDisconnect(handle, activateCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    activateCallback = null;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////
        // ************ AccessibilityReadingSkippedSignal ************** //
        ///////////////////////////////////////////////////////////////////

        private VoidHandlerType readingSkippedCallback;
        private EventHandler readingSkippedHandler;

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
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityReadingSkippedConnect(handle, readingSkippedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                readingSkippedHandler += value;
            }
            remove
            {
                readingSkippedHandler -= value;
                if (readingSkippedHandler == null && readingSkippedCallback != null)
                {
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityReadingSkippedDisconnect(handle, readingSkippedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    readingSkippedCallback = null;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////
        // ************* AccessibilityReadingPausedSignal ************** //
        ///////////////////////////////////////////////////////////////////

        private VoidHandlerType readingPausedCallback;
        private EventHandler readingPausedHandler;

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
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityReadingPausedConnect(handle, readingPausedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                readingPausedHandler += value;
            }
            remove
            {
                readingPausedHandler -= value;
                if (readingPausedHandler == null && readingPausedCallback != null)
                {
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityReadingPausedDisconnect(handle, readingPausedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    readingPausedCallback = null;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////
        // ************* AccessibilityReadingResumedSignal ************* //
        ///////////////////////////////////////////////////////////////////

        private VoidHandlerType readingResumedCallback;
        private EventHandler readingResumedHandler;

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
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityReadingResumedConnect(handle, readingResumedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                readingResumedHandler += value;
            }
            remove
            {
                readingResumedHandler -= value;
                if (readingResumedHandler == null && readingResumedCallback != null)
                {
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityReadingResumedDisconnect(handle, readingResumedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    readingResumedCallback = null;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////
        // ************ AccessibilityReadingCancelledSignal ************ //
        ///////////////////////////////////////////////////////////////////

        private VoidHandlerType readingCancelledCallback;
        private EventHandler readingCancelledHandler;

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
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityReadingCancelledConnect(handle, readingCancelledCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                readingCancelledHandler += value;
            }
            remove
            {
                readingCancelledHandler -= value;
                if (readingCancelledHandler == null && readingCancelledCallback != null)
                {
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityReadingCancelledDisconnect(handle, readingCancelledCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    readingCancelledCallback = null;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////
        // ************* AccessibilityReadingStoppedSignal ************* //
        ///////////////////////////////////////////////////////////////////

        private VoidHandlerType readingStoppedCallback;
        private EventHandler readingStoppedHandler;

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
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityReadingStoppedConnect(handle, readingStoppedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                readingStoppedHandler += value;
            }
            remove
            {
                readingStoppedHandler -= value;
                if (readingStoppedHandler == null && readingStoppedCallback != null)
                {
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityReadingStoppedDisconnect(handle, readingStoppedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    readingStoppedCallback = null;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////
        // ***************** AccessibilityActionSignal ***************** //
        ///////////////////////////////////////////////////////////////////
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool AccessibilityActionReceivedHandlerType(IntPtr data);
        private AccessibilityActionReceivedHandlerType _accessibilityActionReceivedCallback;
        private EventHandler<AccessibilityActionReceivedEventArgs> _accessibilityActionReceivedHandler;

        private bool OnAccessibilityActionReceived(IntPtr data)
        {
            var info = (AccessibilityActionInfo)Marshal.PtrToStructure(data, typeof(AccessibilityActionInfo));
            var eventArgs = new AccessibilityActionReceivedEventArgs()
            {
                ActionType = info.ActionType,
                Handled = false
            };
            _accessibilityActionReceivedHandler?.Invoke(this, eventArgs);

            return eventArgs.Handled;
        }

        /// <summary>
        /// Occurs when the view receives an accessibility action.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AccessibilityActionReceivedEventArgs> AccessibilityActionReceived
        {
            add
            {
                if (_accessibilityActionReceivedHandler == null)
                {
                    _accessibilityActionReceivedCallback = OnAccessibilityActionReceived;
#if true
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityActionConnect(handle, _accessibilityActionReceivedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
#else
                    using var actionSignal = this.AccessibilityActionSignal();
                    actionSignal.Connect(_accessibilityActionReceivedCallback);
#endif
                }
                _accessibilityActionReceivedHandler += value;
            }
            remove
            {
                _accessibilityActionReceivedHandler -= value;
                if (_accessibilityActionReceivedHandler == null && _accessibilityActionReceivedCallback != null)
                {
#if true
                    using var handle = GetControl();
                    Interop.AccessibilitySignal.AccessibilityActionDisconnect(handle, _accessibilityActionReceivedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
#else
                    using var actionSignal = this.AccessibilityActionSignal();
                    actionSignal.Disconnect(_accessibilityActionReceivedCallback);
#endif
                    _accessibilityActionReceivedCallback = null;
                }
            }
        }

#if false
        private VoidSignal AccessibilityActionSignal()
        {
            var handle = GetControl();
            VoidSignal ret = new VoidSignal(Interop.ControlDevel.DaliToolkitDevelControlAccessibilityActionSignal(handle), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
#endif
    }
}
