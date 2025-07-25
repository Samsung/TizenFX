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
    internal class ViewEventRareData
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool WheelEventCallbackType(IntPtr view, IntPtr wheelEvent);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void LayoutDirectionChangedEventCallbackType(IntPtr data, ViewLayoutDirectionType type);

        private View _owner;
        private EventHandlerWithReturnType<object, View.WheelEventArgs, bool> _interceptWheelHandler;
        private WheelEventCallbackType _interceptWheelCallback;
        private EventHandlerWithReturnType<object, View.WheelEventArgs, bool> _wheelEventHandler;
        private WheelEventCallbackType _wheelEventCallback;
        private EventHandlerWithReturnType<object, View.TouchEventArgs, bool> _interceptTouchDataEventHandler;
        private View.TouchDataCallbackType _interceptTouchDataCallback;
        private EventHandler<View.LayoutDirectionChangedEventArgs> _layoutDirectionChangedEventHandler;
        private LayoutDirectionChangedEventCallbackType _layoutDirectionChangedEventCallback;
        private View.TouchDataCallbackType _hitTestResultDataCallback;

        public ViewEventRareData(View owner)
        {
            _owner = owner;
        }

        public event EventHandlerWithReturnType<object, View.TouchEventArgs, bool> InterceptTouchEvent
        {
            add
            {
                if (_interceptTouchDataEventHandler == null)
                {
                    _interceptTouchDataCallback = OnInterceptTouch;
                    Interop.ActorSignal.InterceptTouchConnect(_owner.SwigCPtr, _interceptTouchDataCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                _interceptTouchDataEventHandler += value;
            }

            remove
            {
                _interceptTouchDataEventHandler -= value;
                if (_interceptTouchDataEventHandler == null && _interceptTouchDataCallback != null)
                {
                    Interop.ActorSignal.InterceptTouchDisconnect(_owner.SwigCPtr, _interceptTouchDataCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    _interceptTouchDataCallback = null;
                }
            }
        }

        public event EventHandlerWithReturnType<object, View.WheelEventArgs, bool> InterceptWheelEvent
        {
            add
            {
                if (_interceptWheelHandler == null)
                {
                    _interceptWheelCallback = OnInterceptWheel;
                    Interop.ActorSignal.InterceptWheelConnect(_owner.SwigCPtr, _interceptWheelCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                _interceptWheelHandler += value;
            }

            remove
            {
                _interceptWheelHandler -= value;
                if (_interceptWheelHandler == null && _interceptWheelCallback != null)
                {
                    Interop.ActorSignal.InterceptWheelDisconnect(_owner.SwigCPtr, _interceptWheelCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    _interceptWheelCallback = null;
                }
            }
        }

        public event EventHandlerWithReturnType<object, View.WheelEventArgs, bool> WheelEvent
        {
            add
            {
                if (_wheelEventHandler == null)
                {
                    _wheelEventCallback = OnWheelEvent;
                    Interop.ActorSignal.WheelEventConnect(_owner.SwigCPtr, _wheelEventCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                _wheelEventHandler += value;
            }

            remove
            {
                _wheelEventHandler -= value;
                if (_wheelEventHandler == null && _wheelEventCallback != null)
                {
                    Interop.ActorSignal.WheelEventDisconnect(_owner.SwigCPtr, _wheelEventCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    _wheelEventCallback = null;
                }
            }
        }

        public event EventHandler<View.LayoutDirectionChangedEventArgs> LayoutDirectionChanged
        {
            add
            {
                if (_layoutDirectionChangedEventHandler == null)
                {
                    _layoutDirectionChangedEventCallback = OnLayoutDirectionChanged;
                    Interop.ActorSignal.LayoutDirectionChangedConnect(_owner.SwigCPtr, _layoutDirectionChangedEventCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }

                _layoutDirectionChangedEventHandler += value;
            }

            remove
            {
                _layoutDirectionChangedEventHandler -= value;

                if (_layoutDirectionChangedEventHandler == null && _layoutDirectionChangedEventCallback != null)
                {
                    Interop.ActorSignal.LayoutDirectionChangedDisconnect(_owner.SwigCPtr, _layoutDirectionChangedEventCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    _layoutDirectionChangedEventCallback = null;
                }
            }
        }

        public void RegisterHitTestCallback(View.TouchDataCallbackType callback)
        {
            if (_hitTestResultDataCallback == null)
            {
                _hitTestResultDataCallback = callback;
                Interop.ActorSignal.HitTestResultConnect(_owner.SwigCPtr, _hitTestResultDataCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
            }
        }

        public void UnregisterHitTestCallback()
        {
            if (_hitTestResultDataCallback != null)
            {
                Interop.ActorSignal.HitTestResultDisconnect(_owner.SwigCPtr, _hitTestResultDataCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                _hitTestResultDataCallback = null;
            }
        }

        public void ClearSignal()
        {
            HandleRef handle = _owner.GetBaseHandleCPtrHandleRef;

            if (_interceptWheelCallback != null)
            {
                NUILog.Debug($"[Dispose] interceptWheelCallback");

                Interop.ActorSignal.InterceptWheelDisconnect(handle, _interceptWheelCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                _interceptWheelCallback = null;
            }

            if (_wheelEventCallback != null)
            {
                NUILog.Debug($"[Dispose] wheelEventCallback");

                Interop.ActorSignal.WheelEventDisconnect(handle, _wheelEventCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                _wheelEventCallback = null;
            }

            if (_hitTestResultDataCallback != null)
            {
                NUILog.Debug($"[Dispose] hitTestResultDataCallback");

                Interop.ActorSignal.HitTestResultDisconnect(handle, _hitTestResultDataCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                _hitTestResultDataCallback = null;
            }

            if (_interceptTouchDataCallback != null)
            {
                NUILog.Debug($"[Dispose] interceptTouchDataCallback");

                Interop.ActorSignal.InterceptTouchDisconnect(handle, _interceptTouchDataCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                _interceptTouchDataCallback = null;
            }

            if (_layoutDirectionChangedEventCallback != null)
            {
                NUILog.Debug($"[Dispose] layoutDirectionChangedEventCallback");

                Interop.ActorSignal.LayoutDirectionChangedDisconnect(handle, _layoutDirectionChangedEventCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                _layoutDirectionChangedEventCallback = null;
            }
        }

        // Callback for View TouchSignal
        private bool OnInterceptTouch(IntPtr view, IntPtr touchData)
        {
            if (_owner.IsDisposedOrQueued)
            {
                // Ignore native callback if the view is disposed or queued for disposal.
                return false;
            }

            if (touchData == global::System.IntPtr.Zero)
            {
                NUILog.Error("touchData should not be null!");
                return true;
            }

            // DisallowInterceptTouchEvent prevents the parent from intercepting touch.
            if (_owner.DisallowInterceptTouchEvent)
            {
                return false;
            }

            View.TouchEventArgs e = new()
            {
                Touch = Touch.GetTouchFromPtr(touchData)
            };

            bool consumed = false;

            if (_interceptTouchDataEventHandler != null)
            {
                if (NUIApplication.IsGeometryHittestEnabled())
                {
                    Delegate[] delegateList = _interceptTouchDataEventHandler.GetInvocationList();
                    // Oring the result of each callback.
                    foreach (EventHandlerWithReturnType<object, View.TouchEventArgs, bool> del in delegateList)
                    {
                        consumed |= del(_owner, e);
                    }
                }
                else
                {
                    consumed = _interceptTouchDataEventHandler(_owner, e);
                }
            }

            return consumed;
        }

        // Callback for View InterceptWheel signal
        private bool OnInterceptWheel(IntPtr view, IntPtr wheelEvent)
        {
            if (_owner.IsDisposedOrQueued)
            {
                // Ignore native callback if the view is disposed or queued for disposal.
                return false;
            }

            if (wheelEvent == IntPtr.Zero)
            {
                NUILog.Error("wheelEvent should not be null!");
                return true;
            }

            // DisallowInterceptWheelEvent prevents the parent from intercepting wheel.
            if (_owner.DisallowInterceptWheelEvent)
            {
                return false;
            }

            View.WheelEventArgs e = new()
            {
                Wheel = Wheel.GetWheelFromPtr(wheelEvent)
            };

            bool consumed = false;

            if (_interceptWheelHandler != null)
            {
                consumed = _interceptWheelHandler(_owner, e);
            }

            return consumed;
        }

        // Callback for View Wheel signal
        private bool OnWheelEvent(IntPtr view, IntPtr wheelEvent)
        {
            if (_owner.IsDisposedOrQueued)
            {
                // Ignore native callback if the view is disposed or queued for disposal.
                return false;
            }

            if (wheelEvent == IntPtr.Zero)
            {
                NUILog.Error("wheelEvent should not be null!");
                return true;
            }

            if (_owner.DispatchWheelEvents == false)
            {
                NUILog.Debug("If DispatchWheelEvents is false, it can not dispatch.");
                return true;
            }

            View.WheelEventArgs e = new()
            {
                Wheel = Wheel.GetWheelFromPtr(wheelEvent)
            };

            bool consumed = false;

            if (_wheelEventHandler != null)
            {
                consumed = _wheelEventHandler(_owner, e);
            }

            if (_owner.DispatchParentWheelEvents == false && consumed == false)
            {
                NUILog.Debug("If DispatchParentWheelEvents is false, it can not dispatch to parent.");
                return true;
            }

            return consumed;
        }

        // Callback for View layout direction change signal
        private void OnLayoutDirectionChanged(IntPtr data, ViewLayoutDirectionType type)
        {
            if (_owner.IsDisposedOrQueued)
            {
                // Ignore native callback if the view is disposed or queued for disposal.
                return;
            }

            View.LayoutDirectionChangedEventArgs e = new();

            if (data != IntPtr.Zero)
            {
                e.View = Registry.GetManagedBaseHandleFromNativePtr(data) as View;
            }
            e.Type = type;

            _layoutDirectionChangedEventHandler?.Invoke(_owner, e);
        }
    }
}
