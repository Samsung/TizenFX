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
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// WidgetViewManager manages addition of WidgetView controls.
    /// This class provides the functionality of adding the widget views and controlling the widgets.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class WidgetViewManager : BaseHandle
    {

        /// <summary>
        /// Creates a new widgetView manager object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WidgetViewManager(NUIApplication nuiApplication, string appId) : this(Interop.WidgetViewManager.WidgetViewManager_New(Application.getCPtr(nuiApplication.ApplicationHandle), appId), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        internal WidgetViewManager(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.WidgetViewManager.WidgetViewManager_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        /// <summary>
        /// Creates a new widget view object.
        /// </summary>
        /// <param name="widgetId">The widget ID.</param>
        /// <param name="contentInfo">Contents that will be given to the widget instance.</param>
        /// <param name="width">The widget width.</param>
        /// <param name="height">The widget height.</param>
        /// <param name="updatePeriod">The period of updating contents of the widget.</param>
        /// <returns>A handle to WidgetView.</returns>
        /// <since_tizen> 3 </since_tizen>
        public WidgetView AddWidget(string widgetId, string contentInfo, int width, int height, float updatePeriod)
        {
            WidgetView ret = new WidgetView(Interop.WidgetViewManager.WidgetViewManager_AddWidget(swigCPtr, widgetId, contentInfo, width, height, updatePeriod), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WidgetViewManager obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static WidgetViewManager DownCast(BaseHandle handle)
        {
            WidgetViewManager ret = new WidgetViewManager(Interop.WidgetViewManager.WidgetViewManager_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetViewManager(WidgetViewManager handle) : this(Interop.WidgetViewManager.new_WidgetViewManager__SWIG_1(WidgetViewManager.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal WidgetViewManager Assign(WidgetViewManager handle)
        {
            WidgetViewManager ret = new WidgetViewManager(Interop.WidgetViewManager.WidgetViewManager_Assign(swigCPtr, WidgetViewManager.getCPtr(handle)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WidgetViewManager.delete_WidgetViewManager(swigCPtr);
        }
    }
}