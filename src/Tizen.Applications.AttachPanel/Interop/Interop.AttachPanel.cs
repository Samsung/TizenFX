using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
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
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AttachPanelEventCallback(IntPtr attachPanel, int eventType, IntPtr eventInfo, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AttachPanelResultCallback(IntPtr attachPanel, int category, IntPtr result, int resultCode, IntPtr userData);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CreateAttachPanel(IntPtr conform, out IntPtr attach_panel);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode DestroyAttachPanel(IntPtr attach_panel);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_add_content_category", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AddCategory(IntPtr attach_panel, int content_category, IntPtr extraData);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_remove_content_category", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode RemoveCategory(IntPtr attach_panel, int content_category);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_set_extra_data", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode SetExtraData(IntPtr attach_panel, int content_category, IntPtr extraData);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_set_result_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode SetResultCb(IntPtr attach_panel, AttachPanelResultCallback callback, IntPtr userData);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_unset_result_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode UnsetResultCb(IntPtr attach_panel);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_set_event_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode SetEventCb(IntPtr attach_panel, AttachPanelEventCallback callback, IntPtr userData);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_unset_event_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode UnsetEventCb(IntPtr attach_panel);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_show", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode Show(IntPtr attach_panel);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_show_without_animation", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ShowWithoutAnimation(IntPtr attach_panel);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_hide", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode Hide(IntPtr attach_panel);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_hide_without_animation", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode HideWithoutAnimation(IntPtr attach_panel);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_get_visibility", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetVisibility(IntPtr attach_panel, out int visible);

        [LibraryImport(Libraries.AttachPanel, EntryPoint = "attach_panel_get_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetState(IntPtr attach_panel, out int state);
    }
}


