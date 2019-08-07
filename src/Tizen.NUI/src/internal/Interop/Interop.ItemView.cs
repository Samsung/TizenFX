using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ItemView
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_Property_MINIMUM_SWIPE_SPEED_get")]
            public static extern int ItemView_Property_MINIMUM_SWIPE_SPEED_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_Property_MINIMUM_SWIPE_DISTANCE_get")]
            public static extern int ItemView_Property_MINIMUM_SWIPE_DISTANCE_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_Property_WHEEL_SCROLL_DISTANCE_STEP_get")]
            public static extern int ItemView_Property_WHEEL_SCROLL_DISTANCE_STEP_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_Property_SNAP_TO_ITEM_ENABLED_get")]
            public static extern int ItemView_Property_SNAP_TO_ITEM_ENABLED_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_Property_REFRESH_INTERVAL_get")]
            public static extern int ItemView_Property_REFRESH_INTERVAL_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_Property_LAYOUT_POSITION_get")]
            public static extern int ItemView_Property_LAYOUT_POSITION_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_Property_SCROLL_SPEED_get")]
            public static extern int ItemView_Property_SCROLL_SPEED_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_Property_OVERSHOOT_get")]
            public static extern int ItemView_Property_OVERSHOOT_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_Property_SCROLL_DIRECTION_get")]
            public static extern int ItemView_Property_SCROLL_DIRECTION_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_Property_LAYOUT_ORIENTATION_get")]
            public static extern int ItemView_Property_LAYOUT_ORIENTATION_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_Property_SCROLL_CONTENT_SIZE_get")]
            public static extern int ItemView_Property_SCROLL_CONTENT_SIZE_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ItemView_Property")]
            public static extern global::System.IntPtr new_ItemView_Property();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ItemView_Property")]
            public static extern void delete_ItemView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ItemView__SWIG_0")]
            public static extern global::System.IntPtr new_ItemView__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ItemView__SWIG_1")]
            public static extern global::System.IntPtr new_ItemView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_Assign")]
            public static extern global::System.IntPtr ItemView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ItemView")]
            public static extern void delete_ItemView(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_New")]
            public static extern global::System.IntPtr ItemView_New(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_DownCast")]
            public static extern global::System.IntPtr ItemView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetLayoutCount")]
            public static extern uint ItemView_GetLayoutCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_AddLayout")]
            public static extern void ItemView_AddLayout(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_RemoveLayout")]
            public static extern void ItemView_RemoveLayout(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetLayout")]
            public static extern global::System.IntPtr ItemView_GetLayout(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetActiveLayout")]
            public static extern global::System.IntPtr ItemView_GetActiveLayout(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetCurrentLayoutPosition")]
            public static extern float ItemView_GetCurrentLayoutPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_ActivateLayout")]
            public static extern void ItemView_ActivateLayout(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, float jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_DeactivateCurrentLayout")]
            public static extern void ItemView_DeactivateCurrentLayout(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_SetMinimumSwipeSpeed")]
            public static extern void ItemView_SetMinimumSwipeSpeed(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetMinimumSwipeSpeed")]
            public static extern float ItemView_GetMinimumSwipeSpeed(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_SetMinimumSwipeDistance")]
            public static extern void ItemView_SetMinimumSwipeDistance(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetMinimumSwipeDistance")]
            public static extern float ItemView_GetMinimumSwipeDistance(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_SetWheelScrollDistanceStep")]
            public static extern void ItemView_SetWheelScrollDistanceStep(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetWheelScrollDistanceStep")]
            public static extern float ItemView_GetWheelScrollDistanceStep(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_SetAnchoring")]
            public static extern void ItemView_SetAnchoring(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetAnchoring")]
            public static extern bool ItemView_GetAnchoring(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_SetAnchoringDuration")]
            public static extern void ItemView_SetAnchoringDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetAnchoringDuration")]
            public static extern float ItemView_GetAnchoringDuration(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_ScrollToItem")]
            public static extern void ItemView_ScrollToItem(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_SetRefreshInterval")]
            public static extern void ItemView_SetRefreshInterval(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetRefreshInterval")]
            public static extern float ItemView_GetRefreshInterval(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_Refresh")]
            public static extern void ItemView_Refresh(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetItem")]
            public static extern global::System.IntPtr ItemView_GetItem(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetItemId")]
            public static extern uint ItemView_GetItemId(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_InsertItem")]
            public static extern void ItemView_InsertItem(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_InsertItems")]
            public static extern void ItemView_InsertItems(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_RemoveItem")]
            public static extern void ItemView_RemoveItem(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_RemoveItems")]
            public static extern void ItemView_RemoveItems(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_ReplaceItem")]
            public static extern void ItemView_ReplaceItem(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_ReplaceItems")]
            public static extern void ItemView_ReplaceItems(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_SetItemsParentOrigin")]
            public static extern void ItemView_SetItemsParentOrigin(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetItemsParentOrigin")]
            public static extern global::System.IntPtr ItemView_GetItemsParentOrigin(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_SetItemsAnchorPoint")]
            public static extern void ItemView_SetItemsAnchorPoint(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetItemsAnchorPoint")]
            public static extern global::System.IntPtr ItemView_GetItemsAnchorPoint(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_GetItemsRange")]
            public static extern void ItemView_GetItemsRange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_LayoutActivatedSignal")]
            public static extern global::System.IntPtr ItemView_LayoutActivatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ItemView_Property_LAYOUT_get")]
            public static extern int ItemView_Property_LAYOUT_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemView_SWIGUpcast")]
            public static extern global::System.IntPtr ItemView_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}