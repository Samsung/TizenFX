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
using System.Runtime.InteropServices;

namespace Tizen.NUI.BaseComponents
{
    internal class ViewAccessibilityData
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
        private SingleDataType _getDescriptionCallback;
        private EventHandler<GetDescriptionEventArgs> _getDescriptionHandler;
        private SingleDataType _getNameCallback;
        private EventHandler<GetNameEventArgs> _getNameHandler;
        private VoidHandlerType _activateCallback;
        private EventHandler _activateHandler;
        private AccessibilityActionReceivedHandlerType _accessibilityActionReceivedCallback;
        private EventHandler<AccessibilityActionReceivedEventArgs> _accessibilityActionReceivedHandler;
        private BooleanDataType _accessibilityHighlightedCallback;
        private EventHandler<AccessibilityHighlightChangedEventArgs> _accessibilityHighlightChangedHandler;

        public ViewAccessibilityData(View owner)
        {
            _owner = owner;
        }

        public void AddDescriptionRequestedHandler(View view, EventHandler<GetDescriptionEventArgs> value)
        {
            if (_getDescriptionHandler == null)
            {
                _getDescriptionCallback = OnGetAccessibilityDescriptionEvent;
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityGetDescriptionConnect(handle, _getDescriptionCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            _getDescriptionHandler += value;
        }

        public void RemoveDescriptionRequestedHandler(View view, EventHandler<GetDescriptionEventArgs> value)
        {
            _getDescriptionHandler -= value;
            if (_getDescriptionHandler == null && _getDescriptionCallback != null)
            {
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityGetDescriptionDisconnect(handle, _getDescriptionCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                _getDescriptionCallback = null;
            }
        }

        public void AddNameRequestedHandler(View view, EventHandler<GetNameEventArgs> value)
        {
            if (_getNameHandler == null)
            {
                _getNameCallback = OnGetAccessibilityNameEvent;
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityGetNameConnect(handle, _getNameCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            _getNameHandler += value;
        }

        public void RemoveNameRequestedHandler(View view, EventHandler<GetNameEventArgs> value)
        {
            _getNameHandler -= value;
            if (_getNameHandler == null && _getNameCallback != null)
            {
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityGetNameDisconnect(handle, _getNameCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                _getNameCallback = null;
            }
        }

        public void AddActivatedHandler(View view, EventHandler value)
        {
            if (_activateHandler == null)
            {
                _activateCallback = OnAccessibilityActivatedEvent;
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityActivateConnect(handle, _activateCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            _activateHandler += value;
        }

        public void RemoveActivatedHandler(View view, EventHandler value)
        {
            _activateHandler -= value;
            if (_activateHandler == null && _activateCallback != null)
            {
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityActivateDisconnect(handle, _activateCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                _activateCallback = null;
            }
        }

        public void AddActionReceivedHandler(View view, EventHandler<AccessibilityActionReceivedEventArgs> value)
        {
            if (_accessibilityActionReceivedHandler == null)
            {
                _accessibilityActionReceivedCallback = OnAccessibilityActionReceived;
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityActionConnect(handle, _accessibilityActionReceivedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            _accessibilityActionReceivedHandler += value;
        }

        public void RemoveActionReceivedHandler(View view, EventHandler<AccessibilityActionReceivedEventArgs> value)
        {
            _accessibilityActionReceivedHandler -= value;
            if (_accessibilityActionReceivedHandler == null && _accessibilityActionReceivedCallback != null)
            {
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityActionDisconnect(handle, _accessibilityActionReceivedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                _accessibilityActionReceivedCallback = null;
            }
        }

        public void AddHighlightChangedHandler(View view, EventHandler<AccessibilityHighlightChangedEventArgs> value)
        {
            if (_accessibilityHighlightChangedHandler == null)
            {
                _accessibilityHighlightedCallback = OnAccessibilityHighlighed;
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityHighlightedConnect(handle, _accessibilityHighlightedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            _accessibilityHighlightChangedHandler += value;
        }

        public void RemoveHighlightChangedHandler(View view, EventHandler<AccessibilityHighlightChangedEventArgs> value)
        {
            _accessibilityHighlightChangedHandler -= value;
            if (_accessibilityHighlightChangedHandler == null && _accessibilityHighlightedCallback != null)
            {
                using var handle = view.GetControl();
                Interop.AccessibilitySignal.AccessibilityHighlightedDisconnect(handle, _accessibilityHighlightedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                _accessibilityHighlightedCallback = null;
            }
        }

        private void OnGetAccessibilityDescriptionEvent(IntPtr data)
        {
            if (data == IntPtr.Zero || _owner.IsDisposedOrQueued)
            {
                return;
            }

            var arg = new GetDescriptionEventArgs()
            {
                Description = Interop.StringToVoidSignal.GetResult(data)
            };
            _getDescriptionHandler?.Invoke(_owner, arg);

            Interop.StringToVoidSignal.SetResult(data, arg.Description ?? string.Empty);
        }

        private void OnGetAccessibilityNameEvent(IntPtr data)
        {
            if (data == IntPtr.Zero || _owner.IsDisposedOrQueued)
            {
                return;
            }

            var arg = new GetNameEventArgs()
            {
                Name = Interop.StringToVoidSignal.GetResult(data)
            };
            _getNameHandler?.Invoke(_owner, arg);

            Interop.StringToVoidSignal.SetResult(data, arg.Name ?? string.Empty);
        }

        private void OnAccessibilityActivatedEvent()
        {
            if (_owner.IsDisposedOrQueued)
            {
                return;
            }

            _activateHandler?.Invoke(_owner, null);
        }

        private bool OnAccessibilityActionReceived(IntPtr data)
        {
            if (_owner.IsDisposedOrQueued)
            {
                return false;
            }

            var info = (AccessibilityActionInfo)Marshal.PtrToStructure(data, typeof(AccessibilityActionInfo));
            var eventArgs = new AccessibilityActionReceivedEventArgs()
            {
                ActionType = info.ActionType,
                Target = Registry.GetManagedBaseHandleFromRefObject(info.target) as View,
                Handled = false
            };
            _accessibilityActionReceivedHandler?.Invoke(_owner, eventArgs);

            return eventArgs.Handled;
        }

        private void OnAccessibilityHighlighed(bool data)
        {
            if (_owner.IsDisposedOrQueued)
            {
                return;
            }

            _accessibilityHighlightChangedHandler?.Invoke(_owner, new AccessibilityHighlightChangedEventArgs()
            {
                IsHighlighted = data
            });
        }

        public void ClearSignal(View.ControlHandle handle)
        {
            // TODO Does it really need?
            // At least this should reuse return object of GetControl()
#if false
            if (_getDescriptionCallback != null)
            {
                NUILog.Debug($"[Dispose] getDescriptionCallback");

                using var handle = GetControl();
                Interop.AccessibilitySignal.AccessibilityGetDescriptionDisconnect(handle, _getDescriptionCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                getDescriptionCallback = null;
            }

            if (_getNameCallback != null)
            {
                NUILog.Debug($"[Dispose] getNameCallback");

                using var handle = GetControl();
                Interop.AccessibilitySignal.AccessibilityGetNameDisconnect(handle, _getNameCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                getNameCallback = null;
            }

            if (_activateCallback != null)
            {
                NUILog.Debug($"[Dispose] activateCallback");

                using var handle = GetControl();
                Interop.AccessibilitySignal.AccessibilityActivateDisconnect(handle, _activateCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                activateCallback = null;
            }
#endif
        }
    }
}
