/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
using System.Threading;

namespace Tizen.NUI
{
    /// <summary>
    /// This is used to store a mapping between C++ base handle objects and it's C# instances.
    ///
    /// </summary>
    internal sealed class Registry
    {
        private static readonly Registry registry = new Registry();

        /// <summary>
        /// static initialization singleton
        /// </summary>
        internal static Registry Instance
        {
            get { return registry; }
        }

        /// <summary>
        /// Given a C++ object, the dictionary allows us to find which C# object it belongs to.
        /// By keeping the weak reference only, it will allow the object to be garbage collected.
        /// </summary>
        private Dictionary<IntPtr, WeakReference> _controlMap;

        private Registry()
        {
            _controlMap = new Dictionary<IntPtr, WeakReference>();
        }


        /// <summary>
        /// Stores the mapping between this instance of BaseHandle (C# base class) and native part.
        /// </summary>
        /// <param name="baseHandle">The instance of BaseHandle (C# base class).</param>
        internal static void Register(BaseHandle baseHandle)
        {

            // We store a pointer to the RefObject for the control
            RefObject refObj = baseHandle.GetObjectPtr();
            IntPtr refCptr = (IntPtr)RefObject.getCPtr(refObj);

            //NUILog.Debug("Storing ref object cptr in control map Hex: {0:X}" + refCptr);

            if (!Instance._controlMap.ContainsKey(refCptr))
            {
                Instance._controlMap.Add(refCptr, new WeakReference(baseHandle, false));
            }

            return;
        }

        /// <summary>
        /// Removes this instance of BaseHandle (C# base class) and native part from the mapping table.
        /// </summary>
        /// <param name="baseHandle"> The instance of BaseHandle (C# base class)</param>
        internal static void Unregister(BaseHandle baseHandle)
        {
            RefObject refObj = baseHandle.GetObjectPtr();
            IntPtr refCptr = (IntPtr)RefObject.getCPtr(refObj);

            if (Instance._controlMap.ContainsKey(refCptr))
            {
                Instance._controlMap.Remove(refCptr);
            }

            return;
        }

        internal static BaseHandle GetManagedBaseHandleFromNativePtr(BaseHandle baseHandle)
        {
            RefObject refObj = baseHandle.GetObjectPtr();
            IntPtr refObjectPtr = (IntPtr)RefObject.getCPtr(refObj);

            if (refObjectPtr != null)
            {
                // we store a dictionary of ref-obects (C++ land) to managed obects (C# land)
                return GetManagedBaseHandleFromRefObject(refObjectPtr);
            }
            else
            {
                NUILog.Error("NUI Registry RefObjectPtr is NULL!");
                return null;
            }
        }

        internal static BaseHandle GetManagedBaseHandleFromNativePtr(IntPtr cPtr)
        {
            IntPtr refObjectPtr = NDalicPINVOKE.GetRefObjectPtr(cPtr);

            if (refObjectPtr != null)
            {
                // we store a dictionary of ref-obects (C++ land) to managed obects (C# land)
                return GetManagedBaseHandleFromRefObject(refObjectPtr);
            }
            else
            {
                NUILog.Error("NUI Registry RefObjectPtr is NULL!");
                return null;
            }
        }

        internal static BaseHandle GetManagedBaseHandleFromRefObject(IntPtr refObjectPtr)
        {
            // we store a dictionary of ref-obects (C++ land) to managed obects (C# land)
            WeakReference weakReference;

            if (Instance._controlMap.TryGetValue(refObjectPtr, out weakReference))
            {
                if(weakReference == null) { throw new System.InvalidOperationException("Error! NUI Registry weakReference should not be NULL!"); }
                BaseHandle ret = weakReference.Target as BaseHandle;
                return ret;
            }
            else
            {
                return null;
            }
        }

        private static Thread savedApplicationThread;
        internal Thread SavedApplicationThread
        {
            get
            {
                return savedApplicationThread;
            }
            set
            {
                savedApplicationThread = value;
            }
        }

    }
}
