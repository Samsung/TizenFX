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

using System.Reflection;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class CustomAlgorithmInterface : Disposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal CustomAlgorithmInterface(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CustomAlgorithmInterface obj)
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
                    Interop.CustomAlgorithmInterface.delete_CustomAlgorithmInterface(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        public virtual View GetNextFocusableView(View current, View proposed, View.FocusDirection direction)
        {
            View ret = new View(Interop.CustomAlgorithmInterface.CustomAlgorithmInterface_GetNextFocusableActor(swigCPtr, View.getCPtr(current), View.getCPtr(proposed), (int)direction), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal CustomAlgorithmInterface() : this(Interop.CustomAlgorithmInterface.new_CustomAlgorithmInterface(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SwigDirectorConnect();
        }

        private void SwigDirectorConnect()
        {
            if (SwigDerivedClassHasMethod("GetNextFocusableView", swigMethodTypes0))
                swigDelegate0 = new SwigDelegateCustomAlgorithmInterface_0(SwigDirectorGetNextFocusableView);
            Interop.CustomAlgorithmInterface.CustomAlgorithmInterface_director_connect(swigCPtr, swigDelegate0);
        }

        private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes)
        {
            global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, methodTypes);
            bool hasDerivedMethod = this.GetType().GetTypeInfo().IsSubclassOf(typeof(CustomAlgorithmInterface));
            return hasDerivedMethod && (methodInfo != null);
        }

        private global::System.IntPtr SwigDirectorGetNextFocusableView(global::System.IntPtr current, global::System.IntPtr proposed, int direction)
        {
            View currentView = Registry.GetManagedBaseHandleFromNativePtr(current) as View;
            View proposedView = Registry.GetManagedBaseHandleFromNativePtr(proposed) as View;

            return View.getCPtr(GetNextFocusableView(currentView, proposedView, (View.FocusDirection)direction)).Handle;
        }

        internal delegate global::System.IntPtr SwigDelegateCustomAlgorithmInterface_0(global::System.IntPtr current, global::System.IntPtr proposed, int direction);

        private SwigDelegateCustomAlgorithmInterface_0 swigDelegate0;

        private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(View), typeof(View), typeof(View.FocusDirection) };
    }
}
