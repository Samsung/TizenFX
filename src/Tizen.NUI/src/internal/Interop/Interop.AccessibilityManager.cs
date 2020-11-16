using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class AccessibilityManager
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AccessibilityManager")]
            public static extern global::System.IntPtr NewAccessibilityManager();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AccessibilityManager")]
            public static extern void DeleteAccessibilityManager(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_Get")]
            public static extern global::System.IntPtr AccessibilityManagerGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_SetAccessibilityAttribute")]
            public static extern void AccessibilityManagerSetAccessibilityAttribute(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, string jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_GetAccessibilityAttribute")]
            public static extern string AccessibilityManagerGetAccessibilityAttribute(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_SetFocusOrder")]
            public static extern void AccessibilityManagerSetFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_GetFocusOrder")]
            public static extern uint AccessibilityManagerGetFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_GenerateNewFocusOrder")]
            public static extern uint AccessibilityManagerGenerateNewFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_GetActorByFocusOrder")]
            public static extern global::System.IntPtr AccessibilityManagerGetActorByFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_SetCurrentFocusActor")]
            public static extern bool AccessibilityManagerSetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_GetCurrentFocusActor")]
            public static extern global::System.IntPtr AccessibilityManagerGetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_GetCurrentFocusGroup")]
            public static extern global::System.IntPtr AccessibilityManagerGetCurrentFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_GetCurrentFocusOrder")]
            public static extern uint AccessibilityManagerGetCurrentFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_MoveFocusForward")]
            public static extern bool AccessibilityManagerMoveFocusForward(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_MoveFocusBackward")]
            public static extern bool AccessibilityManagerMoveFocusBackward(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ClearFocus")]
            public static extern void AccessibilityManagerClearFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_Reset")]
            public static extern void AccessibilityManagerReset(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_SetFocusGroup")]
            public static extern void AccessibilityManagerSetFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_IsFocusGroup")]
            public static extern bool AccessibilityManagerIsFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_SetGroupMode")]
            public static extern void AccessibilityManagerSetGroupMode(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_GetGroupMode")]
            public static extern bool AccessibilityManagerGetGroupMode(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_SetWrapMode")]
            public static extern void AccessibilityManagerSetWrapMode(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_GetWrapMode")]
            public static extern bool AccessibilityManagerGetWrapMode(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_SetFocusIndicatorActor")]
            public static extern void AccessibilityManagerSetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_GetFocusIndicatorActor")]
            public static extern global::System.IntPtr AccessibilityManagerGetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_GetFocusGroup")]
            public static extern global::System.IntPtr AccessibilityManagerGetFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_GetReadPosition")]
            public static extern global::System.IntPtr AccessibilityManagerGetReadPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_FocusChangedSignal")]
            public static extern global::System.IntPtr AccessibilityManagerFocusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_FocusOvershotSignal")]
            public static extern global::System.IntPtr AccessibilityManagerFocusOvershotSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_FocusedActorActivatedSignal")]
            public static extern global::System.IntPtr AccessibilityManagerFocusedActorActivatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_StatusChangedSignal")]
            public static extern global::System.IntPtr AccessibilityManagerStatusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionNextSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionNextSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionPreviousSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionPreviousSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionActivateSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionActivateSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionReadSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionReadSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionOverSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionOverSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionReadNextSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionReadNextSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionReadPreviousSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionReadPreviousSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionUpSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionUpSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionDownSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionDownSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionClearFocusSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionClearFocusSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionBackSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionBackSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionScrollUpSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionScrollUpSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionScrollDownSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionScrollDownSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionPageLeftSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionPageLeftSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionPageRightSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionPageRightSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionPageUpSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionPageUpSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionPageDownSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionPageDownSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionMoveToFirstSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionMoveToFirstSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionMoveToLastSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionMoveToLastSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionReadFromTopSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionReadFromTopSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionReadFromNextSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionReadFromNextSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionZoomSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionZoomSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionReadPauseResumeSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionReadPauseResumeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionStartStopSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionStartStopSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_ActionScrollSignal")]
            public static extern global::System.IntPtr AccessibilityManagerActionScrollSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityActionSignal_Empty")]
            public static extern bool AccessibilityActionSignalEmpty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityActionSignal_GetConnectionCount")]
            public static extern uint AccessibilityActionSignalGetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityActionSignal_Connect")]
            public static extern void AccessibilityActionSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityActionSignal_Disconnect")]
            public static extern void AccessibilityActionSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityActionSignal_Emit")]
            public static extern bool AccessibilityActionSignalEmit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AccessibilityActionSignal")]
            public static extern global::System.IntPtr NewAccessibilityActionSignal();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AccessibilityActionSignal")]
            public static extern void DeleteAccessibilityActionSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityFocusOvershotSignal_Empty")]
            public static extern bool AccessibilityFocusOvershotSignalEmpty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityFocusOvershotSignal_GetConnectionCount")]
            public static extern uint AccessibilityFocusOvershotSignalGetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityFocusOvershotSignal_Connect")]
            public static extern void AccessibilityFocusOvershotSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityFocusOvershotSignal_Disconnect")]
            public static extern void AccessibilityFocusOvershotSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityFocusOvershotSignal_Emit")]
            public static extern void AccessibilityFocusOvershotSignalEmit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AccessibilityFocusOvershotSignal")]
            public static extern global::System.IntPtr NewAccessibilityFocusOvershotSignal();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AccessibilityFocusOvershotSignal")]
            public static extern void DeleteAccessibilityFocusOvershotSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AccessibilityManager_SWIGUpcast")]
            public static extern global::System.IntPtr AccessibilityManagerUpcast(global::System.IntPtr jarg1);
        }
    }
}
