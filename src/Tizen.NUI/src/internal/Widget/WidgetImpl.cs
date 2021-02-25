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

namespace Tizen.NUI
{
    internal class WidgetImpl : BaseObject
    {

        internal WidgetImpl() : this(Interop.WidgetImpl.New(), true)
        {
            SwigDirectorConnect();
        }

        internal WidgetImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WidgetImpl obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            //throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }

        public class WIdgetInstanceOnCreateArgs : EventArgs
        {
            private string contentInfo;
            private Window window;

            public string ContentInfo
            {
                get
                {
                    return contentInfo;
                }
                set
                {
                    contentInfo = value;
                }
            }

            public Window Window
            {
                get
                {
                    return window;
                }
                set
                {
                    window = value;
                }
            }
        }

        private EventHandler<WIdgetInstanceOnCreateArgs> widgetInstanceOnCreateEventHandler;
        public event EventHandler<WIdgetInstanceOnCreateArgs> WidgetInstanceCreated
        {
            add
            {
                widgetInstanceOnCreateEventHandler += value;
            }
            remove
            {
                widgetInstanceOnCreateEventHandler -= value;
            }
        }

        public class WIdgetInstanceOnDestroyArgs : EventArgs
        {
            private string contentInfo;
            private Widget.TerminationType terminateType;

            public string ContentInfo
            {
                get
                {
                    return contentInfo;
                }
                set
                {
                    contentInfo = value;
                }
            }

            public Widget.TerminationType TerminateType
            {
                get
                {
                    return terminateType;
                }
                set
                {
                    terminateType = value;
                }
            }
        }

        private EventHandler<WIdgetInstanceOnDestroyArgs> widgetInstanceOnDestroyEventHandler;
        public event EventHandler<WIdgetInstanceOnDestroyArgs> WidgetInstanceDestroyed
        {
            add
            {
                widgetInstanceOnDestroyEventHandler += value;
            }
            remove
            {
                widgetInstanceOnDestroyEventHandler -= value;
            }
        }

        public class WidgetInstanceOnResizeArgs : EventArgs
        {
            private Window window;

            public Window Window
            {
                get
                {
                    return window;
                }
                set
                {
                    window = value;
                }
            }
        }

        private EventHandler<WidgetInstanceOnResizeArgs> widgetInstanceOnResizeEventHandler;
        public event EventHandler<WidgetInstanceOnResizeArgs> WidgetInstanceResized
        {
            add
            {
                widgetInstanceOnResizeEventHandler += value;
            }
            remove
            {
                widgetInstanceOnResizeEventHandler -= value;
            }
        }

        private EventHandler widgetInstanceOnPauseEventHandler;
        public event EventHandler WidgetInstancePaused
        {
            add
            {
                widgetInstanceOnPauseEventHandler += value;
            }
            remove
            {
                widgetInstanceOnPauseEventHandler -= value;
            }
        }

        private EventHandler widgetInstanceOnResumeEventHandler;
        public event EventHandler WidgetInstanceResumed
        {
            add
            {
                widgetInstanceOnResumeEventHandler += value;
            }
            remove
            {
                widgetInstanceOnResumeEventHandler -= value;
            }
        }

        public class WidgetInstanceOnUpdateArgs : EventArgs
        {
            private string contentInfo;
            private int force;

            public string ContentInfo
            {
                get
                {
                    return contentInfo;
                }
                set
                {
                    contentInfo = value;
                }
            }

            public int Force
            {
                get
                {
                    return force;
                }
                set
                {
                    force = value;
                }
            }
        }

        private EventHandler<WidgetInstanceOnUpdateArgs> widgetInstanceOnUpdateEventHandler;
        public event EventHandler<WidgetInstanceOnUpdateArgs> WidgetInstanceUpdated
        {
            add
            {
                widgetInstanceOnUpdateEventHandler += value;
            }
            remove
            {
                widgetInstanceOnUpdateEventHandler -= value;
            }
        }

        public virtual void OnCreate(string contentInfo, Window window)
        {
            WIdgetInstanceOnCreateArgs args = new WIdgetInstanceOnCreateArgs();
            args.ContentInfo = contentInfo;
            args.Window = window;
            widgetInstanceOnCreateEventHandler?.Invoke(this, args);
        }

        public virtual void OnTerminate(string contentInfo, Widget.TerminationType type)
        {
            WIdgetInstanceOnDestroyArgs args = new WIdgetInstanceOnDestroyArgs();
            args.ContentInfo = contentInfo;
            args.TerminateType = type;
            widgetInstanceOnDestroyEventHandler?.Invoke(this, args);
        }

        public virtual void OnPause()
        {
            widgetInstanceOnPauseEventHandler?.Invoke(this, new EventArgs());
        }

        public virtual void OnResume()
        {
            widgetInstanceOnResumeEventHandler?.Invoke(this, new EventArgs());
        }

        public virtual void OnResize(Window window)
        {
            WidgetInstanceOnResizeArgs args = new WidgetInstanceOnResizeArgs();
            args.Window = window;
            widgetInstanceOnResizeEventHandler?.Invoke(this, args);
        }

        public virtual void OnUpdate(string contentInfo, int force)
        {
            WidgetInstanceOnUpdateArgs args = new WidgetInstanceOnUpdateArgs();
            args.ContentInfo = contentInfo;
            args.Force = force;
            widgetInstanceOnUpdateEventHandler?.Invoke(this, args);
        }

        internal virtual void SignalConnected(SlotObserver slotObserver, SWIGTYPE_p_Dali__CallbackBase callback)
        {
        }

        internal virtual void SignalDisconnected(SlotObserver slotObserver, SWIGTYPE_p_Dali__CallbackBase callback)
        {
        }

        public void SetContentInfo(string contentInfo)
        {
            Interop.WidgetImpl.SetContentInfo(SwigCPtr, contentInfo);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetImpl(SWIGTYPE_p_Dali__Widget__Impl impl)
        {
            Interop.WidgetImpl.SetImpl(SwigCPtr, SWIGTYPE_p_Dali__Widget__Impl.getCPtr(impl));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            Interop.WidgetImpl.DirectorConnect(SwigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
        }

        private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes)
        {
            global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
            bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(WidgetImpl));
            return hasDerivedMethod;
        }

        private void SwigDirectorOnCreate(string contentInfo, global::System.IntPtr window)
        {
            Window ret = Registry.GetManagedBaseHandleFromNativePtr(window) as Window;
            if (ret == null)
            {
                ret = new Window(window, true);
            }
            OnCreate(contentInfo, ret);
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
            Window ret = Registry.GetManagedBaseHandleFromNativePtr(window) as Window;
            if (ret == null)
            {
                ret = new Window(window, true);
            }
            OnResize(ret);
        }

        private void SwigDirectorOnUpdate(string contentInfo, int force)
        {
            OnUpdate(contentInfo, force);
        }

        private void SwigDirectorSignalConnected(global::System.IntPtr slotObserver, global::System.IntPtr callback)
        {
            SignalConnected((slotObserver == global::System.IntPtr.Zero) ? null : new SlotObserver(slotObserver, false), (callback == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_Dali__CallbackBase(callback));
        }

        private void SwigDirectorSignalDisconnected(global::System.IntPtr slotObserver, global::System.IntPtr callback)
        {
            SignalDisconnected((slotObserver == global::System.IntPtr.Zero) ? null : new SlotObserver(slotObserver, false), (callback == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_Dali__CallbackBase(callback));
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
    }
}
