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
using System.Collections.Generic;

namespace Tizen.NUI
{
    internal class WidgetApplication : Application
    {
        private Dictionary<System.Type, string> widgetInfo;
        private List<Widget> widgetList = new List<Widget>();
        private delegate System.IntPtr CreateWidgetFunctionDelegate(ref string widgetName);
        private List<CreateWidgetFunctionDelegate> createWidgetFunctionDelegateList = new List<CreateWidgetFunctionDelegate>();

        internal WidgetApplication(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WidgetApplication obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WidgetApplication.DeleteWidgetApplication(swigCPtr);
        }

        public static WidgetApplication NewWidgetApplication(string[] args, string stylesheet)
        {
            WidgetApplication ret = New(args, stylesheet);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            instance = ret;
            return ret;
        }

        public static WidgetApplication New(string[] args, string stylesheet)
        {
            int argc = args.Length;
            string argvStr = string.Join(" ", args);

            IntPtr widgetIntPtr = Interop.WidgetApplication.New(argc, argvStr, stylesheet);

            WidgetApplication ret = new WidgetApplication(widgetIntPtr, false);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return ret;
        }

        internal WidgetApplication(WidgetApplication widgetApplication) : this(Interop.WidgetApplication.NewWidgetApplication(WidgetApplication.getCPtr(widgetApplication)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal WidgetApplication Assign(WidgetApplication widgetApplication)
        {
            WidgetApplication ret = new WidgetApplication(Interop.WidgetApplication.Assign(SwigCPtr, WidgetApplication.getCPtr(widgetApplication)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void RegisterWidgetCreatingFunction()
        {
            foreach (KeyValuePair<System.Type, string> widgetInfo in widgetInfo)
            {
                string widgetName = widgetInfo.Value;
                RegisterWidgetCreatingFunction(ref widgetName);
            }
        }

        internal void RegisterWidgetCreatingFunction(ref string widgetName)
        {
            CreateWidgetFunctionDelegate newDelegate = new CreateWidgetFunctionDelegate(WidgetCreateFunction);

            // Keep this delegate until WidgetApplication is terminated
            createWidgetFunctionDelegateList.Add(newDelegate);

            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(newDelegate);
            CreateWidgetFunction createWidgetFunction = new CreateWidgetFunction(ip);

            Interop.WidgetApplication.RegisterWidgetCreatingFunction(SwigCPtr, ref widgetName, CreateWidgetFunction.getCPtr(createWidgetFunction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddWidgetInstance(Widget widget)
        {
            widgetList.Add(widget);
        }

        public void RegisterWidgetInfo(Dictionary<System.Type, string> widgetInfo)
        {
            this.widgetInfo = widgetInfo;
        }

        public void AddWidgetInfo(Dictionary<Type, string> newWidgetInfo)
        {
            foreach (KeyValuePair<Type, string> widgetInfo in newWidgetInfo)
            {
                if (this.widgetInfo.ContainsKey(widgetInfo.Key) == false)
                {
                    this.widgetInfo.Add(widgetInfo.Key, widgetInfo.Value);
                    string widgetName = widgetInfo.Value;
                    RegisterWidgetCreatingFunction(ref widgetName);
                }
            }
        }

        public static System.IntPtr WidgetCreateFunction(ref string widgetName)
        {
            if ((Instance as WidgetApplication) == null)
            {
                return IntPtr.Zero;
            }

            Dictionary<System.Type, string> widgetInfo = (Instance as WidgetApplication).WidgetInfo;

            foreach (System.Type widgetType in widgetInfo.Keys)
            {
                if (widgetInfo[widgetType] == widgetName)
                {
                    Widget widget = Activator.CreateInstance(widgetType) as Widget;
                    if (widget != null)
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
                return widgetInfo;
            }
        }
    }
}
