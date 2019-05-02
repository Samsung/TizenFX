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
using System.Collections.Generic;

namespace Tizen.NUI
{
    internal class WidgetApplication : Application
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private static WidgetApplication _instance; //singleton
        private Dictionary<System.Type, string> _widgetInfo;
        private List<Widget> _widgetList = new List<Widget>();
        private delegate System.IntPtr CreateWidgetFunctionDelegate(ref string widgetName);

        internal WidgetApplication(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WidgetApplication obj)
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
                    NDalicManualPINVOKE.delete_WidgetApplication(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }

        public new static WidgetApplication Instance
        {
            get
            {
                return _instance;
            }
        }

        public static WidgetApplication NewWidgetApplication(string[] args, string stylesheet)
        {
            WidgetApplication ret = New(args, stylesheet);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            _instance = ret;
            return ret;
        }

        public static WidgetApplication New(string[] args, string stylesheet)
        {
            int argc = args.Length;
            string argvStr = string.Join(" ", args);

            IntPtr widgetIntPtr = NDalicManualPINVOKE.WidgetApplication_New(argc, argvStr, stylesheet);

            WidgetApplication ret = new WidgetApplication(widgetIntPtr, false);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return ret;
        }

        internal WidgetApplication(WidgetApplication widgetApplication) : this(NDalicManualPINVOKE.new_WidgetApplication__SWIG_1(WidgetApplication.getCPtr(widgetApplication)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal WidgetApplication Assign(WidgetApplication widgetApplication)
        {
            WidgetApplication ret = new WidgetApplication(NDalicManualPINVOKE.WidgetApplication_Assign(swigCPtr, WidgetApplication.getCPtr(widgetApplication)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void RegisterWidgetCreatingFunction()
        {
            foreach (KeyValuePair<System.Type, string> widgetInfo in _widgetInfo)
            {
                string widgetName = widgetInfo.Value;
                RegisterWidgetCreatingFunction(ref widgetName);
            }
        }

        internal void RegisterWidgetCreatingFunction(ref string widgetName)
        {
            CreateWidgetFunctionDelegate newDelegate = new CreateWidgetFunctionDelegate(WidgetCreateFunction);

            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(newDelegate);
            CreateWidgetFunction createWidgetFunction = new CreateWidgetFunction(ip, true);

            NDalicManualPINVOKE.WidgetApplication_RegisterWidgetCreatingFunction(swigCPtr, ref widgetName, CreateWidgetFunction.getCPtr(createWidgetFunction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddWidgetInstance( Widget widget )
        {
            _widgetList.Add(widget);
        }

        public void RegisterWidgetInfo(Dictionary<System.Type, string> widgetInfo)
        {
            _widgetInfo = widgetInfo;
        }

        public static System.IntPtr WidgetCreateFunction(ref string widgetName)
        {
            Dictionary<System.Type, string> widgetInfo = Instance.WidgetInfo;

            foreach (System.Type widgetType in widgetInfo.Keys)
            {
                if (widgetInfo[widgetType] == widgetName)
                {
                    Widget widget = Activator.CreateInstance(widgetType) as Widget;
                    if (widget)
                    {
                        return widget.GetIntPtr();
                    }
                }
            }

            return IntPtr.Zero;
        }

        public Dictionary<System.Type, string> WidgetInfo
        {
            get
            {
                return _widgetInfo;
            }
        }
    }
}
