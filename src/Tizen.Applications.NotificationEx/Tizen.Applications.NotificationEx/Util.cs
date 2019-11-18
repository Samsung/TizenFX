using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    internal static class Util
    {
        internal static IList<NotificationEx.AbstractItem> IntPtrToList(IntPtr unmanagedArray, int size)
        {
            IntPtr[] ptrArray = new IntPtr[size];
            Marshal.Copy(unmanagedArray, ptrArray, 0, size);
            IList<NotificationEx.AbstractItem> itemList = new List<NotificationEx.AbstractItem>();
            for (int iterator = 0; iterator < size; iterator++)
            {
                itemList.Add(FactoryManager.CreateItem(ptrArray[iterator]));
            }
            return itemList;
        }

        internal static string[] IntPtrToStringArray(IntPtr unmanagedArray, int size)
        {
            string[] managedArray = new string[size];
            IntPtr[] IntPtrArray = new IntPtr[size];
            Marshal.Copy(unmanagedArray, IntPtrArray, 0, size);
            for (int iterator = 0; iterator < size; iterator++)
            {
                managedArray[iterator] = Marshal.PtrToStringAnsi(IntPtrArray[iterator]);
            }
            return managedArray;
        }

        internal static IntPtr ListToIntPtr(IList<NotificationEx.AbstractItem> list)
        {
            IntPtr nativeList = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Marshal.WriteIntPtr(nativeList + Marshal.SizeOf<IntPtr>() * i, list[i].NativeHandle);
            }
            return nativeList;
        }

        internal static IntPtr ListToIntPtr(IList<NotificationEx.MultiLanguage> list)
        {
            IntPtr nativeList = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Marshal.WriteIntPtr(nativeList + Marshal.SizeOf<IntPtr>() * i, list[i].NativeHandle);
            }
            return nativeList;
        }
    }
}
