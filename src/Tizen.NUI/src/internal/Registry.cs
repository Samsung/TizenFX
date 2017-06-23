
//#define DOT_NET_CORE
#if (DOT_NET_CORE)
using System.Reflection;
#endif
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// This is used to store a mapping between C++ base handle objects and it's C# instances.
    ///
    /// </summary>
    internal sealed class Registry
    {
        /// <summary>
        /// Registry is a singleton
        /// </summary>
        private static Registry instance = null;

        /// <summary>
        /// Given a C++ object the dictionary allows us to find which C# object it belongs to.
        /// By keeping the weak reference only, it will allow the object to be garbage collected.
        /// </summary>
        private Dictionary<IntPtr, WeakReference> _controlMap;

        private Registry()
        {
            _controlMap = new Dictionary<IntPtr, WeakReference>();
        }


        /// <summary>
        /// Store the mapping between this instance of BaseHandle (C# base class) and native part.
        /// </summary>
        /// <param name="baseHandle"> The instance of BaseHandle (C# base class)</param>
        internal static void Register(BaseHandle baseHandle)
        {
            // We store a pointer to the RefObject for the control
            RefObject refObj = baseHandle.GetObjectPtr();
            IntPtr refCptr = (IntPtr)RefObject.getCPtr(refObj);

#if DEBUG_ON
            Tizen.Log.Debug("NUI", "________Storing ref object cptr in control map Hex: {0:X}" + refCptr);
#endif
            if (!Instance._controlMap.ContainsKey(refCptr))
            {
                Instance._controlMap.Add(refCptr, new WeakReference(baseHandle, false));
            }

            return;
        }

        /// <summary>
        /// Remove the this instance of BaseHandle (C# base class) and native part from the mapping table.
        /// </summary>
        /// <param name="view"> The instance of BaseHandle (C# base class)</param>
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

        private static Registry Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Registry();
                }
                return instance;
            }
        }

        internal static BaseHandle GetManagedBaseHandleFromNativePtr(BaseHandle baseHandle)
        {
            RefObject refObj = baseHandle.GetObjectPtr();
            IntPtr refObjectPtr = (IntPtr)RefObject.getCPtr(refObj);

            // we store a dictionary of ref-obects (C++ land) to managed obects (C# land)
            return GetManagedBaseHandleFromRefObject(refObjectPtr);
        }

        internal static BaseHandle GetManagedBaseHandleFromNativePtr(IntPtr cPtr)
        {
            IntPtr refObjectPtr = NDalicPINVOKE.GetRefObjectPtr(cPtr);

            // we store a dictionary of ref-obects (C++ land) to managed obects (C# land)
            return GetManagedBaseHandleFromRefObject(refObjectPtr);
        }

        internal static BaseHandle GetManagedBaseHandleFromRefObject(IntPtr refObjectPtr)
        {
            // we store a dictionary of ref-obects (C++ land) to managed obects (C# land)
            WeakReference weakReference;

            if (Instance._controlMap.TryGetValue(refObjectPtr, out weakReference))
            {
                BaseHandle ret = weakReference.Target as BaseHandle;
                return ret;
            }
            else
            {
                return null;
            }
        }

    }
}
