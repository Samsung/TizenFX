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
        private ViewAccessibilityData _accessibilityData;
        private ViewAccessibilityRareData _accessibilityRareData;

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

        private ViewAccessibilityData EnsureAccessibilityData() => _accessibilityData ??= new ViewAccessibilityData(this);

        private ViewAccessibilityRareData EnsureAccessibilityRareData() => _accessibilityRareData ??= new ViewAccessibilityRareData(this);

        ///////////////////////////////////////////////////////////////////
        // ***************** AccessiblityDoGestureSignal ****************//
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// AccessibilityGestureInfo is received.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<GestureInfoEventArgs> AccessibilityGestureInfoReceived
        {
            // This uses DoGestureInfo signal from C++ API.
            add => EnsureAccessibilityRareData().AddGestureInfoReceivedHandler(this, value);
            remove => _accessibilityRareData?.RemoveGestureInfoReceivedHandler(this, value);
        }

        ///////////////////////////////////////////////////////////////////
        // ************** AccessiblityGetDescriptionSignal ************* //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// AccessibilityDescription is requested.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<GetDescriptionEventArgs> AccessibilityDescriptionRequested
        {
            // This uses GetDescription signal from C++ API.
            add => EnsureAccessibilityData().AddDescriptionRequestedHandler(this, value);
            remove => _accessibilityData?.RemoveDescriptionRequestedHandler(this, value);
        }

        ///////////////////////////////////////////////////////////////////
        // ***************** AccessiblityGetNameSignal ***************** //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// AccessibilityName is requested.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<GetNameEventArgs> AccessibilityNameRequested
        {
            // This uses GetName signal from C++ API.
            add => EnsureAccessibilityData().AddNameRequestedHandler(this, value);
            remove => _accessibilityData?.RemoveNameRequestedHandler(this, value);
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

        /// <summary>
        /// Accessibility is activated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AccessibilityActivated
        {
            add => EnsureAccessibilityData().AddActivatedHandler(this, value);
            remove => _accessibilityData?.RemoveActivatedHandler(this, value);
        }

        ///////////////////////////////////////////////////////////////////
        // ************ AccessibilityReadingSkippedSignal ************** //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// AccessibilityReading is skipped.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AccessibilityReadingSkipped
        {
            add => EnsureAccessibilityRareData().AddReadingSkippedHandler(this, value);
            remove => _accessibilityRareData?.RemoveReadingSkippedHandler(this, value);
        }

        ///////////////////////////////////////////////////////////////////
        // ************* AccessibilityReadingPausedSignal ************** //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// AccessibilityReading is paused.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AccessibilityReadingPaused
        {
            add => EnsureAccessibilityRareData().AddReadingPausedHandler(this, value);
            remove => _accessibilityRareData?.RemoveReadingPausedHandler(this, value);
        }

        ///////////////////////////////////////////////////////////////////
        // ************* AccessibilityReadingResumedSignal ************* //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// AccessibilityReading is resumed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AccessibilityReadingResumed
        {
            add => EnsureAccessibilityRareData().AddReadingResumedHandler(this, value);
            remove => _accessibilityRareData?.RemoveReadingResumedHandler(this, value);
        }

        ///////////////////////////////////////////////////////////////////
        // ************ AccessibilityReadingCancelledSignal ************ //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// AccessibilityReading is cancelled.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AccessibilityReadingCancelled
        {
            add => EnsureAccessibilityRareData().AddReadingCancelledHandler(this, value);
            remove => _accessibilityRareData?.RemoveReadingCancelledHandler(this, value);
        }

        ///////////////////////////////////////////////////////////////////
        // ************* AccessibilityReadingStoppedSignal ************* //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// AccessibilityReading is stopped.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AccessibilityReadingStopped
        {
            add => EnsureAccessibilityRareData().AddReadingStoppedHandler(this, value);
            remove => _accessibilityRareData?.RemoveReadingStoppedHandler(this, value);
        }

        ///////////////////////////////////////////////////////////////////
        // ***************** AccessibilityActionSignal ***************** //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// Occurs when the view receives an accessibility action.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AccessibilityActionReceivedEventArgs> AccessibilityActionReceived
        {
            add => EnsureAccessibilityData().AddActionReceivedHandler(this, value);
            remove => _accessibilityData?.RemoveActionReceivedHandler(this, value);
        }

        ///////////////////////////////////////////////////////////////////
        // ************** AccessibilityHighlightedSignal *************** //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// Occurs when the view gets or losts an accessibility highlight.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AccessibilityHighlightChangedEventArgs> AccessibilityHighlightChanged
        {
            add => EnsureAccessibilityData().AddHighlightChangedHandler(this, value);
            remove => _accessibilityData?.RemoveHighlightChangedHandler(this, value);
        }
    }
}
