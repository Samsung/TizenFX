/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.NUI.BaseComponents
{
    internal class ViewAccessibilityRareData
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VoidHandlerType();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SingleDataType(IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void BooleanDataType(bool data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool AccessibilityActionReceivedHandlerType(IntPtr data);

        private View _owner;
        private SingleDataType _gestureInfoCallback;
        private EventHandler<GestureInfoEventArgs> _gestureInfoHandler;
        private VoidHandlerType _readingSkippedCallback;
        private EventHandler _readingSkippedHandler;
        private VoidHandlerType _readingPausedCallback;
        private EventHandler _readingPausedHandler;
        private VoidHandlerType _readingResumedCallback;
        private EventHandler _readingResumedHandler;
        private VoidHandlerType _readingCancelledCallback;
        private EventHandler _readingCancelledHandler;
        private VoidHandlerType _readingStoppedCallback;
        private EventHandler _readingStoppedHandler;
        private Dictionary<string, string> _attributes;
        private Dictionary<string, Func<string>> _dynamicAttributes;

        public Dictionary<string, string> Attributes => _attributes ??= new Dictionary<string, string>(1);

        public Dictionary<string, Func<string>> DynamicAttributes => _dynamicAttributes ??= new Dictionary<string, Func<string>>(1);

        public ViewAccessibilityRareData(View owner)
        {
            _owner = owner;
        }

        public void AddGestureInfoReceivedHandler(View view, EventHandler<GestureInfoEventArgs> value)
        {
            if (_gestureInfoHandler == null)
            {
                _gestureInfoCallback = OnAccessibilityGestureInfoEvent;
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityDoGestureConnect(handle, _gestureInfoCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            _gestureInfoHandler += value;
        }

        public void RemoveGestureInfoReceivedHandler(View view, EventHandler<GestureInfoEventArgs> value)
        {
            _gestureInfoHandler -= value;
            if (_gestureInfoHandler == null && _gestureInfoCallback != null)
            {
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityDoGestureDisconnect(handle, _gestureInfoCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                _gestureInfoCallback = null;
            }
        }

        public void AddReadingSkippedHandler(View view, EventHandler value)
        {
            if (_readingSkippedHandler == null)
            {
                _readingSkippedCallback = OnAccessibilityReadingSkippedEvent;
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingSkippedConnect(handle, _readingSkippedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            _readingSkippedHandler += value;
        }

        public void RemoveReadingSkippedHandler(View view, EventHandler value)
        {
            _readingSkippedHandler -= value;
            if (_readingSkippedHandler == null && _readingSkippedCallback != null)
            {
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingSkippedDisconnect(handle, _readingSkippedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                _readingSkippedCallback = null;
            }
        }

        public void AddReadingPausedHandler(View view, EventHandler value)
        {
            if (_readingPausedHandler == null)
            {
                _readingPausedCallback = OnAccessibilityReadingPausedEvent;
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingPausedConnect(handle, _readingPausedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            _readingPausedHandler += value;
        }

        public void RemoveReadingPausedHandler(View view, EventHandler value)
        {
            _readingPausedHandler -= value;
            if (_readingPausedHandler == null && _readingPausedCallback != null)
            {
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingPausedDisconnect(handle, _readingPausedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                _readingPausedCallback = null;
            }
        }

        public void AddReadingResumedHandler(View view, EventHandler value)
        {
            if (_readingResumedHandler == null)
            {
                _readingResumedCallback = OnAccessibilityReadingResumedEvent;
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingResumedConnect(handle, _readingResumedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            _readingResumedHandler += value;
        }

        public void RemoveReadingResumedHandler(View view, EventHandler value)
        {
            _readingResumedHandler -= value;
            if (_readingResumedHandler == null && _readingResumedCallback != null)
            {
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingResumedDisconnect(handle, _readingResumedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                _readingResumedCallback = null;
            }
        }

        public void AddReadingCancelledHandler(View view, EventHandler value)
        {
            if (_readingCancelledHandler == null)
            {
                _readingCancelledCallback = OnAccessibilityReadingCancelledEvent;
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingCancelledConnect(handle, _readingCancelledCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            _readingCancelledHandler += value;
        }

        public void RemoveReadingCancelledHandler(View view, EventHandler value)
        {
            _readingCancelledHandler -= value;
            if (_readingCancelledHandler == null && _readingCancelledCallback != null)
            {
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingCancelledDisconnect(handle, _readingCancelledCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                _readingCancelledCallback = null;
            }
        }

        public void AddReadingStoppedHandler(View view, EventHandler value)
        {
            if (_readingStoppedHandler == null)
            {
                _readingStoppedCallback = OnAccessibilityReadingStoppedEvent;
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingStoppedConnect(handle, _readingStoppedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            _readingStoppedHandler += value;
        }

        public void RemoveReadingStoppedHandler(View view, EventHandler value)
        {
            _readingStoppedHandler -= value;
            if (_readingStoppedHandler == null && _readingStoppedCallback != null)
            {
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingStoppedDisconnect(handle, _readingStoppedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                _readingStoppedCallback = null;
            }
        }

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
            _gestureInfoHandler?.Invoke(_owner, arg);

            Interop.DoGestureSignal.SetResult(data, arg.Consumed);
        }

        private void OnAccessibilityReadingSkippedEvent()
        {
            _readingSkippedHandler?.Invoke(_owner, null);
        }

        private void OnAccessibilityReadingPausedEvent()
        {
            _readingPausedHandler?.Invoke(_owner, null);
        }

        private void OnAccessibilityReadingResumedEvent()
        {
            _readingResumedHandler?.Invoke(_owner, null);
        }

        private void OnAccessibilityReadingCancelledEvent()
        {
            _readingCancelledHandler?.Invoke(_owner, null);
        }

        private void OnAccessibilityReadingStoppedEvent()
        {
            _readingStoppedHandler?.Invoke(_owner, null);
        }

        public void ClearSignal(View.ControlHandle handle)
        {
            // TODO Does it really need?
            // At least this should reuse return object of GetControl()
#if false
            if (_gestureInfoCallback != null)
            {
                NUILog.Debug($"[Dispose] gestureInfoCallback");

                using var handle = GetControl();
                Interop.AccessibilitySignal.AccessibilityDoGestureDisconnect(handle, _gestureInfoCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                gestureInfoCallback = null;
            }

            if (_readingSkippedCallback != null)
            {
                NUILog.Debug($"[Dispose] readingSkippedCallback");

                using var handle = GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingSkippedDisconnect(handle, _readingSkippedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                readingSkippedCallback = null;
            }

            if (_readingPausedCallback != null)
            {
                NUILog.Debug($"[Dispose] readingPausedCallback");

                using var handle = GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingPausedDisconnect(handle, _readingPausedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                readingPausedCallback = null;
            }

            if (_readingResumedCallback != null)
            {
                NUILog.Debug($"[Dispose] readingResumedCallback");

                using var handle = GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingResumedDisconnect(handle, _readingResumedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                readingResumedCallback = null;
            }

            if (_readingCancelledCallback != null)
            {
                NUILog.Debug($"[Dispose] readingCancelledCallback");

                using var handle = GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingCancelledDisconnect(handle, _readingCancelledCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                readingCancelledCallback = null;
            }

            if (_readingStoppedCallback != null)
            {
                NUILog.Debug($"[Dispose] readingStoppedCallback");

                using var handle = GetControl();
                Interop.AccessibilitySignal.AccessibilityReadingStoppedDisconnect(handle, _readingStoppedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                readingStoppedCallback = null;
            }
#endif
        }
    }
}
