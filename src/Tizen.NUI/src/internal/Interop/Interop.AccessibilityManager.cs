using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class AccessibilityManage
        {
            static AccessibilityManage()
            {
                Tizen.Log.Error("NUI", "AccessibilityManage");
            }


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_AccessibilityManager")]
            public static extern global::System.IntPtr new_AccessibilityManager();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_AccessibilityManager")]
            public static extern void delete_AccessibilityManager(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_Get")]
            public static extern global::System.IntPtr AccessibilityManager_Get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_SetAccessibilityAttribute")]
            public static extern void AccessibilityManager_SetAccessibilityAttribute(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, string jarg4);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_GetAccessibilityAttribute")]
            public static extern string AccessibilityManager_GetAccessibilityAttribute(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_SetFocusOrder")]
            public static extern void AccessibilityManager_SetFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_GetFocusOrder")]
            public static extern uint AccessibilityManager_GetFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_GenerateNewFocusOrder")]
            public static extern uint AccessibilityManager_GenerateNewFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_GetActorByFocusOrder")]
            public static extern global::System.IntPtr AccessibilityManager_GetActorByFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_SetCurrentFocusActor")]
            public static extern bool AccessibilityManager_SetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_GetCurrentFocusActor")]
            public static extern global::System.IntPtr AccessibilityManager_GetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_GetCurrentFocusGroup")]
            public static extern global::System.IntPtr AccessibilityManager_GetCurrentFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_GetCurrentFocusOrder")]
            public static extern uint AccessibilityManager_GetCurrentFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_MoveFocusForward")]
            public static extern bool AccessibilityManager_MoveFocusForward(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_MoveFocusBackward")]
            public static extern bool AccessibilityManager_MoveFocusBackward(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ClearFocus")]
            public static extern void AccessibilityManager_ClearFocus(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_Reset")]
            public static extern void AccessibilityManager_Reset(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_SetFocusGroup")]
            public static extern void AccessibilityManager_SetFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_IsFocusGroup")]
            public static extern bool AccessibilityManager_IsFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_SetGroupMode")]
            public static extern void AccessibilityManager_SetGroupMode(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_GetGroupMode")]
            public static extern bool AccessibilityManager_GetGroupMode(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_SetWrapMode")]
            public static extern void AccessibilityManager_SetWrapMode(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_GetWrapMode")]
            public static extern bool AccessibilityManager_GetWrapMode(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_SetFocusIndicatorActor")]
            public static extern void AccessibilityManager_SetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_GetFocusIndicatorActor")]
            public static extern global::System.IntPtr AccessibilityManager_GetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_GetFocusGroup")]
            public static extern global::System.IntPtr AccessibilityManager_GetFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_GetReadPosition")]
            public static extern global::System.IntPtr AccessibilityManager_GetReadPosition(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_FocusChangedSignal")]
            public static extern global::System.IntPtr AccessibilityManager_FocusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_FocusOvershotSignal")]
            public static extern global::System.IntPtr AccessibilityManager_FocusOvershotSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_FocusedActorActivatedSignal")]
            public static extern global::System.IntPtr AccessibilityManager_FocusedActorActivatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_StatusChangedSignal")]
            public static extern global::System.IntPtr AccessibilityManager_StatusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionNextSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionNextSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionPreviousSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionPreviousSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionActivateSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionActivateSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionReadSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionReadSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionOverSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionOverSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionReadNextSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionReadNextSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionReadPreviousSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionReadPreviousSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionUpSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionUpSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionDownSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionDownSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionClearFocusSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionClearFocusSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionBackSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionBackSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionScrollUpSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionScrollUpSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionScrollDownSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionScrollDownSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionPageLeftSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionPageLeftSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionPageRightSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionPageRightSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionPageUpSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionPageUpSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionPageDownSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionPageDownSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionMoveToFirstSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionMoveToFirstSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionMoveToLastSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionMoveToLastSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionReadFromTopSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionReadFromTopSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionReadFromNextSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionReadFromNextSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionZoomSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionZoomSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionReadIndicatorInformationSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionReadIndicatorInformationSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionReadPauseResumeSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionReadPauseResumeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionStartStopSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionStartStopSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_ActionScrollSignal")]
            public static extern global::System.IntPtr AccessibilityManager_ActionScrollSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityActionSignal_Empty")]
            public static extern bool AccessibilityActionSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityActionSignal_GetConnectionCount")]
            public static extern uint AccessibilityActionSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityActionSignal_Connect")]
            public static extern void AccessibilityActionSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityActionSignal_Disconnect")]
            public static extern void AccessibilityActionSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityActionSignal_Emit")]
            public static extern bool AccessibilityActionSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_AccessibilityActionSignal")]
            public static extern global::System.IntPtr new_AccessibilityActionSignal();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_AccessibilityActionSignal")]
            public static extern void delete_AccessibilityActionSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityFocusOvershotSignal_Empty")]
            public static extern bool AccessibilityFocusOvershotSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityFocusOvershotSignal_GetConnectionCount")]
            public static extern uint AccessibilityFocusOvershotSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityFocusOvershotSignal_Connect")]
            public static extern void AccessibilityFocusOvershotSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityFocusOvershotSignal_Disconnect")]
            public static extern void AccessibilityFocusOvershotSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityFocusOvershotSignal_Emit")]
            public static extern void AccessibilityFocusOvershotSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_AccessibilityFocusOvershotSignal")]
            public static extern global::System.IntPtr new_AccessibilityFocusOvershotSignal();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_AccessibilityFocusOvershotSignal")]
            public static extern void delete_AccessibilityFocusOvershotSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AccessibilityManager_SWIGUpcast")]
            public static extern global::System.IntPtr AccessibilityManager_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}
