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
using System.Collections.Concurrent;
using System.Threading;

namespace Tizen.NUI
{
    /// <summary>
    /// This is used to store a mapping between C++ base handle objects and it's C# instances.
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
        private ConcurrentDictionary<IntPtr, WeakReference> _controlMap;

        private Registry()
        {
            _controlMap = new ConcurrentDictionary<IntPtr, WeakReference>();
        }

        /// <summary>
        /// Stores the mapping between this instance of BaseHandle (C# base class) and native part.
        /// </summary>
        /// <param name="baseHandle">The instance of BaseHandle (C# base class).</param>
        internal static void Register(BaseHandle baseHandle)
        {
            // We store a pointer to the RefObject for the control
            IntPtr refCptr = Interop.BaseHandle.GetObjectPtr(baseHandle.GetBaseHandleCPtrHandleRef);

            RegistryCurrentThreadCheck();

            if (Instance._controlMap.TryAdd(refCptr, new WeakReference(baseHandle, false)) != true)
            {
                NUILog.Debug("refCptr is already exist! OR something wrong!");
            }

            return;
        }

        /// <summary>
        /// Removes this instance of BaseHandle (C# base class) and native part from the mapping table.
        /// </summary>
        /// <param name="baseHandle"> The instance of BaseHandle (C# base class)</param>
        internal static void Unregister(BaseHandle baseHandle)
        {
            IntPtr refCptr = Interop.BaseHandle.GetObjectPtr(baseHandle.GetBaseHandleCPtrHandleRef);

            RegistryCurrentThreadCheck();
            WeakReference refe;
            if (Instance._controlMap.TryRemove(refCptr, out refe) != true)
            {
                NUILog.Debug("something wrong when removing refCptr!");
            }

            return;
        }

        internal static BaseHandle GetManagedBaseHandleFromNativePtr(BaseHandle baseHandle)
        {
            IntPtr refObjectPtr = Interop.BaseHandle.GetObjectPtr(baseHandle.GetBaseHandleCPtrHandleRef);

            // we store a dictionary of ref-objects (C++ land) to managed objects (C# land)
            return GetManagedBaseHandleFromRefObject(refObjectPtr);
        }

        internal static BaseHandle GetManagedBaseHandleFromNativePtr(IntPtr cPtr)
        {
            IntPtr refObjectPtr = Interop.RefObject.GetRefObjectPtr(cPtr);

            // we store a dictionary of ref-objects (C++ land) to managed objects (C# land)
            return GetManagedBaseHandleFromRefObject(refObjectPtr);
        }

        internal static BaseHandle GetManagedBaseHandleFromRefObject(IntPtr refObjectPtr)
        {
            if (refObjectPtr == global::System.IntPtr.Zero)
            {
                NUILog.Debug("Registry refObjectPtr is NULL! This means bind native object is NULL!");
                //return null;
            }
            else
            {
                NUILog.Debug($"refObjectPtr=0x{refObjectPtr.ToInt64():X}");
            }

            RegistryCurrentThreadCheck();

            // we store a dictionary of ref-objects (C++ land) to managed objects (C# land)
            WeakReference weakReference;

            if (Instance._controlMap.TryGetValue(refObjectPtr, out weakReference))
            {
                if (weakReference == null)
                {
                    throw new System.InvalidOperationException("Error! NUI Registry weakReference should not be NULL!");
                }

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

        private static void RegistryCurrentThreadCheck()
        {

            if (savedApplicationThread == null)
            {
                Tizen.Log.Fatal("NUI", $"Error! maybe main thread is created by other process\n");
                return;
            }
            int currentId = Thread.CurrentThread.ManagedThreadId;
            int mainThreadId = savedApplicationThread.ManagedThreadId;

            if (currentId != mainThreadId)
            {
                Tizen.Log.Fatal("NUI", $"Error! current thread({currentId}) which is NOT main thread({mainThreadId}) utilizes NUI object!");
            }
        }
    }
}
