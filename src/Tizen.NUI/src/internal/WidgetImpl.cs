/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    internal class WidgetImpl : BaseObject
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal WidgetImpl() : this( Interop.WidgetImpl.WidgetImpl_New(), true )
        {
            SwigDirectorConnect();
        }

        internal WidgetImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.WidgetImpl.WidgetImpl_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WidgetImpl obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

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

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    //throw new global::System.MethodAccessException("C++ destructor does not have public access");
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        public class WIdgetInstanceOnCreateArgs : EventArgs
        {
            private string _contentInfo;
            private Window _window;

            public string ContentInfo
            {
                get
                {
                    return _contentInfo;
                }
                set
                {
                    _contentInfo = value;
                }
            }

            public Window Window
            {
                get
                {
                    return _window;
                }
                set
                {
                    _window = value;
                }
            }
        }

        private EventHandler<WIdgetInstanceOnCreateArgs> _widgetInstanceOnCreateEventHandler;
        public event EventHandler<WIdgetInstanceOnCreateArgs> WidgetInstanceCreated
        {
            add
            {
                _widgetInstanceOnCreateEventHandler += value;
            }
            remove
            {
                _widgetInstanceOnCreateEventHandler -= value;
            }
        }

        public class WIdgetInstanceOnDestroyArgs : EventArgs
        {
            private string _contentInfo;
            private Widget.TerminationType _terminateType;

            public string ContentInfo
            {
                get
                {
                    return _contentInfo;
                }
                set
                {
                    _contentInfo = value;
                }
            }

            public Widget.TerminationType TerminateType
            {
                get
                {
                    return _terminateType;
                }
                set
                {
                    _terminateType = value;
                }
            }
        }

        private EventHandler<WIdgetInstanceOnDestroyArgs> _widgetInstanceOnDestroyEventHandler;
        public event EventHandler<WIdgetInstanceOnDestroyArgs> WidgetInstanceDestroyed
        {
            add
            {
                _widgetInstanceOnDestroyEventHandler += value;
            }
            remove
            {
                _widgetInstanceOnDestroyEventHandler -= value;
            }
        }

        public class WidgetInstanceOnResizeArgs : EventArgs
        {
            private Window _window;

            public Window Window
            {
                get
                {
                    return _window;
                }
                set
                {
                    _window = value;
                }
            }
        }

        private EventHandler<WidgetInstanceOnResizeArgs> _widgetInstanceOnResizeEventHandler;
        public event EventHandler<WidgetInstanceOnResizeArgs> WidgetInstanceResized
        {
            add
            {
                _widgetInstanceOnResizeEventHandler += value;
            }
            remove
            {
                _widgetInstanceOnResizeEventHandler -= value;
            }
        }

        private EventHandler _widgetInstanceOnPauseEventHandler;
        public event EventHandler WidgetInstancePaused
        {
            add
            {
                _widgetInstanceOnPauseEventHandler += value;
            }
            remove
            {
                _widgetInstanceOnPauseEventHandler -= value;
            }
        }

        private EventHandler _widgetInstanceOnResumeEventHandler;
        public event EventHandler WidgetInstanceResumed
        {
            add
            {
                _widgetInstanceOnResumeEventHandler += value;
            }
            remove
            {
                _widgetInstanceOnResumeEventHandler -= value;
            }
        }

        public class WidgetInstanceOnUpdateArgs : EventArgs
        {
            private string _contentInfo;
            private int _force;

            public string ContentInfo
            {
                get
                {
                    return _contentInfo;
                }
                set
                {
                    _contentInfo = value;
                }
            }

            public int Force
            {
                get
                {
                    return _force;
                }
                set
                {
                    _force = value;
                }
            }
        }

        private EventHandler<WidgetInstanceOnUpdateArgs> _widgetInstanceOnUpdateEventHandler;
        public event EventHandler<WidgetInstanceOnUpdateArgs> WidgetInstanceUpdated
        {
            add
            {
                _widgetInstanceOnUpdateEventHandler += value;
            }
            remove
            {
                _widgetInstanceOnUpdateEventHandler -= value;
            }
        }

        public virtual void OnCreate(string contentInfo, Window window)
        {
            WIdgetInstanceOnCreateArgs args = new WIdgetInstanceOnCreateArgs();
            args.ContentInfo = contentInfo;
            args.Window = window;
            _widgetInstanceOnCreateEventHandler?.Invoke(this, args);
        }

        public virtual void OnTerminate(string contentInfo, Widget.TerminationType type)
        {
            WIdgetInstanceOnDestroyArgs args = new WIdgetInstanceOnDestroyArgs();
            args.ContentInfo = contentInfo;
            args.TerminateType = type;
            _widgetInstanceOnDestroyEventHandler?.Invoke(this,args);
        }

        public virtual void OnPause()
        {
            _widgetInstanceOnPauseEventHandler?.Invoke(this, new EventArgs());
        }

        public virtual void OnResume()
        {
            _widgetInstanceOnResumeEventHandler?.Invoke(this, new EventArgs());
        }

        public virtual void OnResize(Window window)
        {
            WidgetInstanceOnResizeArgs args = new WidgetInstanceOnResizeArgs();
            args.Window = window;
            _widgetInstanceOnResizeEventHandler?.Invoke(this, args);
        }

        public virtual void OnUpdate(string contentInfo, int force)
        {
            WidgetInstanceOnUpdateArgs args = new WidgetInstanceOnUpdateArgs();
            args.ContentInfo = contentInfo;
            args.Force = force;
            _widgetInstanceOnUpdateEventHandler?.Invoke(this, args);
        }

        internal virtual void SignalConnected(SlotObserver slotObserver, SWIGTYPE_p_Dali__CallbackBase callback)
        {
        }

        internal virtual void SignalDisconnected(SlotObserver slotObserver, SWIGTYPE_p_Dali__CallbackBase callback)
        {
        }

        public void SetContentInfo(string contentInfo)
        {
            Interop.WidgetImpl.WidgetImpl_SetContentInfo(swigCPtr, contentInfo);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal void SetImpl(SWIGTYPE_p_Dali__Widget__Impl impl)
        {
            Interop.WidgetImpl.WidgetImpl_SetImpl(swigCPtr, SWIGTYPE_p_Dali__Widget__Impl.getCPtr(impl));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        private void SwigDirectorConnect()
        {
            swigDelegate0 = new SwigDelegateWidgetImpl_0(SwigDirectorOnCreate);
            swigDelegate1 = new SwigDelegateWidgetImpl_1(SwigDirectorOnTerminate);
            swigDelegate2 = new SwigDelegateWidgetImpl_2(SwigDirectorOnPause);
            swigDelegate3 = new SwigDelegateWidgetImpl_3(SwigDirectorOnResume);
            swigDelegate4 = new SwigDelegateWidgetImpl_4(SwigDirectorOnResize);
            swigDelegate5 = new SwigDelegateWidgetImpl_5(SwigDirectorOnUpdate);
            swigDelegate6 = new SwigDelegateWidgetImpl_6(SwigDirectorSignalConnected);
            swigDelegate7 = new SwigDelegateWidgetImpl_7(SwigDirectorSignalDisconnected);
            Interop.WidgetImpl.WidgetImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
        }

        private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes)
        {
            global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
            bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(WidgetImpl));
            return hasDerivedMethod;
        }

        private void SwigDirectorOnCreate(string contentInfo, global::System.IntPtr window)
        {
            OnCreate(contentInfo, new Window(window, true));
        }

        private void SwigDirectorOnTerminate(string contentInfo, int type)
        {
            OnTerminate(contentInfo, (Widget.TerminationType)type);
        }

        private void SwigDirectorOnPause()
        {
            OnPause();
        }

        private void SwigDirectorOnResume()
        {
            OnResume();
        }

        private void SwigDirectorOnResize(global::System.IntPtr window)
        {
            OnResize(new Window(window, true));
        }

        private void SwigDirectorOnUpdate(string contentInfo, int force)
        {
            OnUpdate(contentInfo, force);
        }

        private void SwigDirectorSignalConnected(global::System.IntPtr slotObserver, global::System.IntPtr callback)
        {
            SignalConnected((slotObserver == global::System.IntPtr.Zero) ? null : new SlotObserver(slotObserver, false), (callback == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_Dali__CallbackBase(callback, false));
        }

        private void SwigDirectorSignalDisconnected(global::System.IntPtr slotObserver, global::System.IntPtr callback)
        {
            SignalDisconnected((slotObserver == global::System.IntPtr.Zero) ? null : new SlotObserver(slotObserver, false), (callback == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_Dali__CallbackBase(callback, false));
        }

        public delegate void SwigDelegateWidgetImpl_0(string contentInfo, global::System.IntPtr window);
        public delegate void SwigDelegateWidgetImpl_1(string contentInfo, int type);
        public delegate void SwigDelegateWidgetImpl_2();
        public delegate void SwigDelegateWidgetImpl_3();
        public delegate void SwigDelegateWidgetImpl_4(global::System.IntPtr window);
        public delegate void SwigDelegateWidgetImpl_5(string contentInfo, int force);
        public delegate void SwigDelegateWidgetImpl_6(global::System.IntPtr slotObserver, global::System.IntPtr callback);
        public delegate void SwigDelegateWidgetImpl_7(global::System.IntPtr slotObserver, global::System.IntPtr callback);

        private SwigDelegateWidgetImpl_0 swigDelegate0;
        private SwigDelegateWidgetImpl_1 swigDelegate1;
        private SwigDelegateWidgetImpl_2 swigDelegate2;
        private SwigDelegateWidgetImpl_3 swigDelegate3;
        private SwigDelegateWidgetImpl_4 swigDelegate4;
        private SwigDelegateWidgetImpl_5 swigDelegate5;
        private SwigDelegateWidgetImpl_6 swigDelegate6;
        private SwigDelegateWidgetImpl_7 swigDelegate7;

        private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(string), typeof(Window) };
        private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] { typeof(string), typeof(Widget.TerminationType) };
        private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { };
        private static global::System.Type[] swigMethodTypes3 = new global::System.Type[] { };
        private static global::System.Type[] swigMethodTypes4 = new global::System.Type[] { typeof(Window) };
        private static global::System.Type[] swigMethodTypes5 = new global::System.Type[] { typeof(string), typeof(int) };
        private static global::System.Type[] swigMethodTypes6 = new global::System.Type[] { typeof(SlotObserver), typeof(SWIGTYPE_p_Dali__CallbackBase) };
        private static global::System.Type[] swigMethodTypes7 = new global::System.Type[] { typeof(SlotObserver), typeof(SWIGTYPE_p_Dali__CallbackBase) };
    }
}
