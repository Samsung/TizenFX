/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    class QuickPanelApplication : Application
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal QuickPanelApplication(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(QuickPanelApplication obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.QuickPanelApplication.delete_QuickPanelApplication(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }

        public static QuickPanelApplication NewQuickPanelApplication(string[] args, string styleSheet, NUIApplication.WindowMode windowMode = NUIApplication.WindowMode.Opaque, NUIQuickPanelApplication.ServiceType serviceType = NUIQuickPanelApplication.ServiceType.SYSTEM_DEFAULT, bool scrolling = false, Rectangle rectangle = null)
        {
            QuickPanelApplication ret = New(args, styleSheet, windowMode, serviceType, scrolling, rectangle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            _instance = ret;
            return ret;
        }

        public static QuickPanelApplication New(string[] args, string styleSheet, NUIApplication.WindowMode windowMode = NUIApplication.WindowMode.Opaque, NUIQuickPanelApplication.ServiceType serviceType = NUIQuickPanelApplication.ServiceType.SYSTEM_DEFAULT, bool scrolling = false, Rectangle rectangle = null)
        {
            int argc = args.Length;
            string argvStr = string.Join(" ", args);
			IntPtr applicationIntPtr;
            applicationIntPtr = Interop.QuickPanelApplication.QuickPanelApplication_New_2(argc, argvStr, styleSheet, (int)windowMode, (int)serviceType, scrolling, Rectangle.getCPtr(rectangle));
            QuickPanelApplication ret = new QuickPanelApplication(applicationIntPtr, false);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return ret;
        }

        internal QuickPanelApplication(QuickPanelApplication componentApplication) : this(Interop.QuickPanelApplication.new_QuickPanelApplication__SWIG_1(QuickPanelApplication.getCPtr(componentApplication)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal QuickPanelApplication Assign(QuickPanelApplication componentApplication)
        {
            QuickPanelApplication ret = new QuickPanelApplication(Interop.QuickPanelApplication.QuickPanelApplication_Assign(swigCPtr, QuickPanelApplication.getCPtr(componentApplication)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetScrollable(bool set)
        {
            Interop.QuickPanelApplication.CSharp_Dali_QuickPanelApplication_SetScrollable(swigCPtr, set);
        }

        public int GetServiceType()
        {
            return Interop.QuickPanelApplication.CSharp_Dali_QuickPanelApplication_GetServiceType(swigCPtr);
        }
    }
}
