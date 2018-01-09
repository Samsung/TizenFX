using System;
using System.Runtime.InteropServices;
using Tizen.Applications;

/// <summary>
/// The Interoperability support class for the Tizen APIs.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// The Interoperability support class for the attach panel APIs.
    /// </summary>
    internal static partial class AttachPanel
    {
        internal enum ErrorCode : int
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            AlreadyExists = -0x02850000 | 0x01,
            NotInitialized = -0x02850000 | 0x02,
            UnsupportedContentCategory = -0x02850000 | 0x03,
            AlreadyDestroyed = -0x02850000 | 0x05,
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AttachPanelEventCallback(IntPtr attachPanel, int eventType, IntPtr eventInfo, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AttachPanelResultCallback(IntPtr attachPanel, int category, IntPtr result, int resultCode, IntPtr userData);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_create")]
        internal static extern ErrorCode CreateAttachPanel(IntPtr conform, ref IntPtr attach_panel);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_destroy")]
        internal static extern ErrorCode DestroyAttachPanel(IntPtr attach_panel);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_add_content_category")]
        internal static extern ErrorCode AddCategory(IntPtr attach_panel, int content_category, IntPtr extraData);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_remove_content_category")]
        internal static extern ErrorCode RemoveCategory(IntPtr attach_panel, int content_category);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_set_extra_data")]
        internal static extern ErrorCode SetExtraData(IntPtr attach_panel, int content_category, IntPtr extraData);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_set_result_cb")]
        internal static extern ErrorCode SetResultCb(IntPtr attach_panel, AttachPanelResultCallback callback, IntPtr userData);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_unset_result_cb")]
        internal static extern ErrorCode UnsetResultCb(IntPtr attach_panel);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_set_event_cb")]
        internal static extern ErrorCode SetEventCb(IntPtr attach_panel, AttachPanelEventCallback callback, IntPtr userData);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_unset_event_cb")]
        internal static extern ErrorCode UnsetEventCb(IntPtr attach_panel);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_show")]
        internal static extern ErrorCode Show(IntPtr attach_panel);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_show_without_animation")]
        internal static extern ErrorCode ShowWithoutAnimation(IntPtr attach_panel);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_hide")]
        internal static extern ErrorCode Hide(IntPtr attach_panel);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_hide_without_animation")]
        internal static extern ErrorCode HideWithoutAnimation(IntPtr attach_panel);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_get_visibility")]
        internal static extern ErrorCode GetVisibility(IntPtr attach_panel, out int visible);

        [DllImport(Libraries.AttachPanel, EntryPoint = "attach_panel_get_state")]
        internal static extern ErrorCode GetState(IntPtr attach_panel, out int state);
    }
}