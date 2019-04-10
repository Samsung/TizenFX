using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ItemLayout
        {
            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_SWIGUpcast")]
            public static extern global::System.IntPtr ItemLayout_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ItemLayout")]
            public static extern void delete_ItemLayout(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_SetOrientation")]
            public static extern void ItemLayout_SetOrientation(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetOrientation")]
            public static extern int ItemLayout_GetOrientation(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_SetLayoutProperties")]
            public static extern void ItemLayout_SetLayoutProperties(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetLayoutProperties")]
            public static extern global::System.IntPtr ItemLayout_GetLayoutProperties(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetItemSize")]
            public static extern void ItemLayout_GetItemSize(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_SetItemSize")]
            public static extern void ItemLayout_SetItemSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetMinimumLayoutPosition")]
            public static extern float ItemLayout_GetMinimumLayoutPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetClosestAnchorPosition")]
            public static extern float ItemLayout_GetClosestAnchorPosition(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetItemScrollToPosition")]
            public static extern float ItemLayout_GetItemScrollToPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetItemsWithinArea")]
            public static extern global::System.IntPtr ItemLayout_GetItemsWithinArea(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetClosestOnScreenLayoutPosition")]
            public static extern float ItemLayout_GetClosestOnScreenLayoutPosition(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, float jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetReserveItemCount")]
            public static extern uint ItemLayout_GetReserveItemCount(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetDefaultItemSize")]
            public static extern void ItemLayout_GetDefaultItemSize(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetScrollDirection")]
            public static extern global::System.IntPtr ItemLayout_GetScrollDirection(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetScrollSpeedFactor")]
            public static extern float ItemLayout_GetScrollSpeedFactor(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetMaximumSwipeSpeed")]
            public static extern float ItemLayout_GetMaximumSwipeSpeed(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetItemFlickAnimationDuration")]
            public static extern float ItemLayout_GetItemFlickAnimationDuration(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetNextFocusItemID")]
            public static extern int ItemLayout_GetNextFocusItemID(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, int jarg4, bool jarg5);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetFlickSpeedFactor")]
            public static extern float ItemLayout_GetFlickSpeedFactor(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_ApplyConstraints")]
            public static extern void ItemLayout_ApplyConstraints(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ItemLayout_GetItemPosition")]
            public static extern global::System.IntPtr ItemLayout_GetItemPosition(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, float jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        }
    }
}
