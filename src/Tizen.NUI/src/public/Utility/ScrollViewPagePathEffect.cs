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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// ScrollView Page Path Effect.
    /// This effect causes Views to follow a given path. The opacity of the view will be 0.0 at
    /// the beginning of the path and will go to 1.0 as it is approximating to half of the path to return
    /// to 0.0 at the end of the path.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScrollViewPagePathEffect : ScrollViewEffect
    {

        internal ScrollViewPagePathEffect(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.ScrollView.ScrollViewPagePathEffectUpcast(cPtr), cMemoryOwn)
        {
        }


        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ScrollView.DeleteScrollViewPagePathEffect(swigCPtr);
        }

        /// <summary>
        /// Creates an initialized ScrollViewPagePathEffect.
        /// </summary>
        /// <param name="path">The path that will be used by the scroll effect.</param>
        /// <param name="forward">Vector in page object space which will be aligned with the tangent of the path.</param>
        /// <param name="inputPropertyIndex">Index of a property of the scroll-view which will be used as the input for the path.</param>
        /// <param name="pageSize">Size of a page in the scrollview.</param>
        /// <param name="pageCount">Total number of pages in the scrollview.</param>
        /// <returns>A handle to a newly allocated Dali resource.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollViewPagePathEffect(Path path, Vector3 forward, int inputPropertyIndex, Vector3 pageSize, uint pageCount) : this(Interop.ScrollView.ScrollViewPagePathEffectNew(Path.getCPtr(path), Vector3.getCPtr(forward), inputPropertyIndex, Vector3.getCPtr(pageSize), pageCount), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static ScrollViewPagePathEffect DownCast(BaseHandle handle)
        {
            ScrollViewPagePathEffect ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as ScrollViewPagePathEffect;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Manually apply effect to a page in the scroll-view.
        /// </summary>
        /// <param name="page">The page to be affected by this effect.</param>
        /// <param name="pageOrder">The order of the page in the scroll view.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyToPage(View page, uint pageOrder)
        {
            Interop.ScrollView.ScrollViewPagePathEffectApplyToPage(SwigCPtr, View.getCPtr(page), pageOrder);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
