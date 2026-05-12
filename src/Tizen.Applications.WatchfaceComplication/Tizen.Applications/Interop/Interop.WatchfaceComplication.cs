using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using Tizen.Applications;
using Tizen;
using Tizen.Applications.WatchfaceComplication;

internal static partial class Interop
{
    internal static partial class WatchfaceComplication
    {
        internal enum ErrorType : int
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            InvalidParam = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            IO = Tizen.Internals.Errors.ErrorCode.IoError,
            NoData = Tizen.Internals.Errors.ErrorCode.NoData,
            PermissionDeny = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
            DB = -0x02FC0000 | 0x1,
            DBus = -0x02FC0000 | 0x2,
            EditNotReady = -0x02FC0000 | 0x3,
            ExistID = -0x02FC0000 | 0x4,
            NotExist = -0x02FC0000 | 0x5,
            NotAvailable = -0x02FC0000 | 0x6
        }

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_highlight_create")]
        internal static partial ComplicationError CreateHighlight(out IntPtr highlightHandle);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_highlight_destroy")]
        internal static partial ComplicationError DestroyHighlight(IntPtr highlightHandle);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_highlight_set_geometry")]
        internal static partial ComplicationError SetHighlightGeometry(IntPtr highlightHandle, int x, int y, int w, int h);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_highlight_get_geometry")]
        internal static partial ComplicationError GetHighlightGeometry(IntPtr highlightHandle, out int x, out int y, out int w, out int h);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_highlight_set_shape_type")]
        internal static partial ComplicationError SetHighlightShapeType(IntPtr highlightHandle, ShapeType shapeType);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_highlight_get_shape_type")]
        internal static partial ComplicationError GetHighlightShapeType(IntPtr highlightHandle, out ShapeType shapeType);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_get_highlight")]
        internal static partial ComplicationError GetHighlight(IntPtr handle, out IntPtr highlightHandle);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError CreateComplication(int complicationId,
            string defaultProviderId, ComplicationTypes defaultType, int supportTypes, int supportEventTypes, out IntPtr handle);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_destroy")]
        internal static partial ComplicationError Destroy(IntPtr handle);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_get_current_provider_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError GetCurrentProviderId(IntPtr handle, out string curProviderId);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_get_current_type")]
        internal static partial ComplicationError GetCurrentType(IntPtr handle, out ComplicationTypes type);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_add_updated_cb")]
        internal static partial ComplicationError AddUpdatedCallback(IntPtr handle, ComplicationUpdatedCallback callback, ComplicationErrorCallback errCallback, IntPtr userData);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_remove_updated_cb")]
        internal static partial ComplicationError RemoveUpdatedCallback(IntPtr handle, ComplicationUpdatedCallback callback);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_send_update_request")]
        internal static partial ComplicationError SendUpdateRequest(IntPtr handle);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_type")]
        internal static partial ComplicationError GetDataType(SafeBundleHandle handle, out ComplicationTypes type);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_short_text", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError GetShortText(SafeBundleHandle handle, out string shortText);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_long_text", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError GetLongText(SafeBundleHandle handle, out string longText);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_title", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError GetTitle(SafeBundleHandle handle, out string title);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_timestamp")]
        internal static partial ComplicationError GetTimestamp(SafeBundleHandle handle, out long timestamp);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_image_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError GetImagePath(SafeBundleHandle handle, out string imagePath);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_ranged_value")]
        internal static partial ComplicationError GetRangedValue(SafeBundleHandle handle, out double currentValue, out double minValue, out double maxValue);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_icon_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError GetIconPath(SafeBundleHandle handle, out string iconPath);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_extra_data", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError GetExtraData(SafeBundleHandle handle, out string extraData);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_screen_reader_text", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError GetScreenReaderText(SafeBundleHandle handle, out string screenReaderText);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_transfer_event")]
        internal static partial ComplicationError TransferEvent(IntPtr handle, EventTypes e);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_create")]
        internal static partial ComplicationError CreateAllowedList(out IntPtr allowedList);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_destroy")]
        internal static partial ComplicationError DestroyAllowedList(IntPtr allowedList);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_add", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError AddAllowedList(IntPtr allowedList, string providerId, int types);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_delete", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError DeleteAllowedList(IntPtr allowedList, string providerId);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_get_nth", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError GetNthAllowedListItem(IntPtr allowedList, int idx, out string providerId, out int types);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_apply")]
        internal static partial ComplicationError ApplyAllowedList(IntPtr handle, IntPtr allowedList);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_clear")]
        internal static partial ComplicationError ClearAllowedList(IntPtr handle);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_add_edit_ready_cb")]
        internal static partial ComplicationError AddEditReadyCallback(EditReadyCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_remove_edit_ready_cb")]
        internal static partial ComplicationError RemoveEditReadyCallback(EditReadyCallback callback);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_get_current_data_idx")]
        internal static partial ComplicationError GetCurrentIdx(IntPtr handle, out int curIdx);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_get_current_data")]
        internal static partial ComplicationError GetCurrentData(IntPtr handle, out SafeBundleHandle data);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_get_nth_data")]
        internal static partial ComplicationError GetNthData(IntPtr handle, out SafeBundleHandle data);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_get_editable_id")]
        internal static partial ComplicationError GetEditableId(IntPtr handle, out int editableId);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_get_editable_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError GetEditableName(IntPtr handle, out string editableName);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_set_editable_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError SetEditableName(IntPtr handle, string editableName);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_add_complication")]
        internal static partial ComplicationError AddComplication(IntPtr container, int editId, IntPtr comp, IntPtr highlight);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_add_design_element", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError AddDesignElement(IntPtr container, int editId, int curDataIdx, IntPtr listHandle, IntPtr highlight, string editableName);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_candidates_list_create")]
        internal static partial ComplicationError CreateCandidatesList(out IntPtr listHandle);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_candidates_list_add")]
        internal static partial ComplicationError AddCandidatesListItem(IntPtr listHandle, SafeBundleHandle candidate);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_candidates_list_destroy")]
        internal static partial ComplicationError DestroyCandidatesList(IntPtr listHandle);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_request_edit")]
        internal static partial ComplicationError RequestEdit(IntPtr container, EditableUpdateRequestedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_container_get")]
        internal static partial ComplicationError GetEditableContainer(out IntPtr container);

        [LibraryImport(Libraries.Complication, EntryPoint = "watchface_editable_load_current_data")]
        internal static partial ComplicationError LoadCurrentData(int editableId, out SafeBundleHandle data);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_add_update_requested_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError AddUpdateRequestedCallback(string providerId, UpdateRequestedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_remove_update_requested_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError RemoveUpdateRequestedCallback(string providerId, UpdateRequestedCallback callback);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_type")]
        internal static partial ComplicationError ProviderSetDataType(IntPtr sharedData, ComplicationTypes type);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_title", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError ProviderSetTitle(IntPtr sharedData, string title);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_short_text", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError ProviderSetShortText(IntPtr sharedData, string shortText);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_long_text", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError ProviderSetLongText(IntPtr sharedData, string longText);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_timestamp")]
        internal static partial ComplicationError ProviderSetTimestamp(IntPtr sharedData, Int32 timestamp);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_image_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError ProviderSetImagePath(IntPtr sharedData, string imagePath);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_ranged_value")]
        internal static partial ComplicationError ProviderSetRangedValue(IntPtr sharedData, double currentValue, double minValue, double maxValue);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_icon_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError ProviderSetIconPath(IntPtr sharedData, string iconPath);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_extra_data", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError ProviderSetExtraData(IntPtr sharedData, string extraData);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_screen_reader_text", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError ProviderSetScreenReaderText(IntPtr sharedData, string screenReaderText);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_is_valid")]
        internal static partial ComplicationError ProviderSharedDataIsValid(IntPtr sharedData, [MarshalAs(UnmanagedType.U1)] out bool isVaild);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_notify_update", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError NotifyUpdate(string updatedProviderId);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_event_get_type")]
        internal static partial ComplicationError GetEventType(SafeAppControlHandle handle, out EventTypes type);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_event_get_provider_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ComplicationError GetEventProviderId(SafeAppControlHandle handle, out string providerId);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_event_get_complication_type")]
        internal static partial ComplicationError GetEventComplicationType(SafeAppControlHandle handle, out ComplicationTypes type);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_event_get_context")]
        internal static partial ComplicationError GetEventContext(SafeAppControlHandle handle, out SafeBundleHandle context);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_setup_reply_to_editor")]
        internal static partial ComplicationError SetupReplyToEditor(SafeAppControlHandle handle, SafeBundleHandle context);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_setup_is_editing")]
        internal static partial ComplicationError IsSetupEditing(SafeAppControlHandle handle, [MarshalAs(UnmanagedType.U1)] out bool isEditing);

        [LibraryImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_setup_get_context")]
        internal static partial ComplicationError GetSetupContext(SafeAppControlHandle handle, out SafeBundleHandle context);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void EditReadyCallback(IntPtr handle, string editorAppId, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void UpdateRequestedCallback(string providerId, string reqAppId, ComplicationTypes type,
            IntPtr context, IntPtr sharedData, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ComplicationUpdatedCallback(int complicationId,
            string providerId, ComplicationTypes type, IntPtr data, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ComplicationErrorCallback(int complicationId,
            string providerId, ComplicationTypes type, ComplicationError error, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void EditableUpdateRequestedCallback(IntPtr handle, int selectedIdx,
            int state, IntPtr userData);
    }
}




