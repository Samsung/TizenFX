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
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal ScrollViewPagePathEffect(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.ScrollView.ScrollViewPagePathEffect_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ScrollViewPagePathEffect obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
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
                    Interop.ScrollView.delete_ScrollViewPagePathEffect(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
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
        public ScrollViewPagePathEffect(Path path, Vector3 forward, int inputPropertyIndex, Vector3 pageSize, uint pageCount) : this(Interop.ScrollView.ScrollViewPagePathEffect_New(Path.getCPtr(path), Vector3.getCPtr(forward), inputPropertyIndex, Vector3.getCPtr(pageSize), pageCount), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal static ScrollViewPagePathEffect DownCast(BaseHandle handle)
        {
            ScrollViewPagePathEffect ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as ScrollViewPagePathEffect;
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
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
            Interop.ScrollView.ScrollViewPagePathEffect_ApplyToPage(swigCPtr, View.getCPtr(page), pageOrder);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }
    }
}
