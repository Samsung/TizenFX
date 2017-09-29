/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// Widget data.
    /// </summary>
    public class WidgetData : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal WidgetData(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicManualPINVOKE.WidgetData_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WidgetData obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// To make Window instance be disposed.
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
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
                    NDalicManualPINVOKE.delete_WidgetData(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        internal static WidgetData GetWidgetDataFromPtr(global::System.IntPtr cPtr)
        {
            WidgetData ret = new WidgetData(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetData(string instanceId, SWIGTYPE_p_bundle args, string content) : this(NDalicManualPINVOKE.WidgetData_New(instanceId, SWIGTYPE_p_bundle.getCPtr(args), content), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal WidgetData(WidgetData widgetData) : this(NDalicManualPINVOKE.new_WidgetData__SWIG_1(WidgetData.getCPtr(widgetData)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal WidgetData Assign(WidgetData widgetData)
        {
            WidgetData ret = new WidgetData(NDalicManualPINVOKE.WidgetData_Assign(swigCPtr, WidgetData.getCPtr(widgetData)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Get widget instance id.
        /// </summary>
        /// <returns>Id of widget instance.</returns>
        /// <since_tizen> 4 </since_tizen>
        public string GetInstanceId()
        {
            string ret = NDalicManualPINVOKE.WidgetData_GetInstanceId(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_bundle GetArgs()
        {
            global::System.IntPtr cPtr = NDalicManualPINVOKE.WidgetData_GetArgs(swigCPtr);
            SWIGTYPE_p_bundle ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_bundle(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Get widget instance content.
        /// </summary>
        /// <returns>Content of widget instance.</returns>
        /// <since_tizen> 4 </since_tizen>
        public string GetContent()
        {
            string ret = NDalicManualPINVOKE.WidgetData_GetContent(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Get widget instance Window.
        /// </summary>
        /// <returns>Window of widget instance</returns>
        /// <since_tizen> 4 </since_tizen>
        public Window GetWindow()
        {
            Window ret = new Window(NDalicManualPINVOKE.WidgetData_GetWindow(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetArgs(SWIGTYPE_p_bundle args)
        {
            NDalicManualPINVOKE.WidgetData_SetArgs(swigCPtr, SWIGTYPE_p_bundle.getCPtr(args));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Set widget instance arguments.
        /// </summary>
        /// <param name="content">Content of widget instance</param>
        /// <since_tizen> 4 </since_tizen>
        public void SetContent(string content)
        {
            NDalicManualPINVOKE.WidgetData_SetContent(swigCPtr, content);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Set widget instance arguments.
        /// </summary>
        /// <param name="window">Window of widget instance.</param>
        /// <since_tizen> 4 </since_tizen>
        public void SetWindow(Window window)
        {
            NDalicManualPINVOKE.WidgetData_SetWindow(swigCPtr, Window.getCPtr(window));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}