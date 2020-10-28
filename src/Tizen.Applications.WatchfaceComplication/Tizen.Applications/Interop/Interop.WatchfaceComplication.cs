using System;
using System.Runtime.InteropServices;
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

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_highlight_create")]
        internal static extern ComplicationError CreateHighlight(out IntPtr highlightHandle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_highlight_destroy")]
        internal static extern ComplicationError DestroyHighlight(IntPtr highlightHandle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_highlight_set_geometry")]
        internal static extern ComplicationError SetHighlightGeometry(IntPtr highlightHandle, int x, int y, int w, int h);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_highlight_get_geometry")]
        internal static extern ComplicationError GetHighlightGeometry(IntPtr highlightHandle, out int x, out int y, out int w, out int h);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_highlight_set_shape_type")]
        internal static extern ComplicationError SetHighlightShapeType(IntPtr highlightHandle, ShapeType shapeType);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_highlight_get_shape_type")]
        internal static extern ComplicationError GetHighlightShapeType(IntPtr highlightHandle, out ShapeType shapeType);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_get_highlight")]
        internal static extern ComplicationError GetHighlight(IntPtr handle, out IntPtr highlightHandle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_create")]
        internal static extern ComplicationError CreateComplication(int complicationId,
            string defaultProviderId, ComplicationTypes defaultType, int supportTypes, int supportEventTypes, out IntPtr handle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_destroy")]
        internal static extern ComplicationError Destroy(IntPtr handle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_get_current_provider_id")]
        internal static extern ComplicationError GetCurrentProviderId(IntPtr handle, out string curProviderId);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_get_current_type")]
        internal static extern ComplicationError GetCurrentType(IntPtr handle, out ComplicationTypes type);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_add_updated_cb")]
        internal static extern ComplicationError AddUpdatedCallback(IntPtr handle, ComplicationUpdatedCallback callback, ComplicationErrorCallback errCallback, IntPtr userData);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_remove_updated_cb")]
        internal static extern ComplicationError RemoveUpdatedCallback(IntPtr handle, ComplicationUpdatedCallback callback);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_send_update_request")]
        internal static extern ComplicationError SendUpdateRequest(IntPtr handle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_type")]
        internal static extern ComplicationError GetDataType(SafeBundleHandle handle, out ComplicationTypes type);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_short_text")]
        internal static extern ComplicationError GetShortText(SafeBundleHandle handle, out string shortText);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_long_text")]
        internal static extern ComplicationError GetLongText(SafeBundleHandle handle, out string longText);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_title")]
        internal static extern ComplicationError GetTitle(SafeBundleHandle handle, out string title);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_timestamp")]
        internal static extern ComplicationError GetTimestamp(SafeBundleHandle handle, out long timestamp);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_image_path")]
        internal static extern ComplicationError GetImagePath(SafeBundleHandle handle, out string imagePath);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_ranged_value")]
        internal static extern ComplicationError GetRangedValue(SafeBundleHandle handle, out double currentValue, out double minValue, out double maxValue);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_icon_path")]
        internal static extern ComplicationError GetIconPath(SafeBundleHandle handle, out string iconPath);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_extra_data")]
        internal static extern ComplicationError GetExtraData(SafeBundleHandle handle, out string extraData);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_screen_reader_text")]
        internal static extern ComplicationError GetScreenReaderText(SafeBundleHandle handle, out string screenReaderText);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_transfer_event")]
        internal static extern ComplicationError TransferEvent(IntPtr handle, EventTypes e);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_create")]
        internal static extern ComplicationError CreateAllowedList(out IntPtr allowedList);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_destroy")]
        internal static extern ComplicationError DestroyAllowedList(IntPtr allowedList);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_add")]
        internal static extern ComplicationError AddAllowedList(IntPtr allowedList, string providerId, int types);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_delete")]
        internal static extern ComplicationError DeleteAllowedList(IntPtr allowedList, string providerId);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_get_nth")]
        internal static extern ComplicationError GetNthAllowedListItem(IntPtr allowedList, int idx, out string providerId, out int types);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_apply")]
        internal static extern ComplicationError ApplyAllowedList(IntPtr handle, IntPtr allowedList);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_allowed_list_clear")]
        internal static extern ComplicationError ClearAllowedList(IntPtr handle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_add_edit_ready_cb")]
        internal static extern ComplicationError AddEditReadyCallback(EditReadyCallback callback, IntPtr userData);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_remove_edit_ready_cb")]
        internal static extern ComplicationError RemoveEditReadyCallback(EditReadyCallback callback);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_get_current_data_idx")]
        internal static extern ComplicationError GetCurrentIdx(IntPtr handle, out int curIdx);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_get_current_data")]
        internal static extern ComplicationError GetCurrentData(IntPtr handle, out SafeBundleHandle data);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_get_nth_data")]
        internal static extern ComplicationError GetNthData(IntPtr handle, out SafeBundleHandle data);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_get_editable_id")]
        internal static extern ComplicationError GetEditableId(IntPtr handle, out int editableId);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_get_editable_name")]
        internal static extern ComplicationError GetEditableName(IntPtr handle, out string editableName);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_set_editable_name")]
        internal static extern ComplicationError SetEditableName(IntPtr handle, string editableName);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_add_complication")]
        internal static extern ComplicationError AddComplication(IntPtr container, int editId, IntPtr comp, IntPtr highlight);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_add_design_element")]
        internal static extern ComplicationError AddDesignElement(IntPtr container, int editId, int curDataIdx, IntPtr listHandle, IntPtr highlight, string editableName);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_candidates_list_create")]
        internal static extern ComplicationError CreateCandidatesList(out IntPtr listHandle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_candidates_list_add")]
        internal static extern ComplicationError AddCandidatesListItem(IntPtr listHandle, SafeBundleHandle candidate);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_candidates_list_destroy")]
        internal static extern ComplicationError DestroyCandidatesList(IntPtr listHandle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_request_edit")]
        internal static extern ComplicationError RequestEdit(IntPtr container, EditableUpdateRequestedCallback callback, IntPtr userData);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_container_get")]
        internal static extern ComplicationError GetEditableContainer(out IntPtr container);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_load_current_data")]
        internal static extern ComplicationError LoadCurrentData(int editableId, out SafeBundleHandle data);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_add_update_requested_cb")]
        internal static extern ComplicationError AddUpdateRequestedCallback(string providerId, UpdateRequestedCallback callback, IntPtr userData);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_remove_update_requested_cb")]
        internal static extern ComplicationError RemoveUpdateRequestedCallback(string providerId, UpdateRequestedCallback callback);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_type")]
        internal static extern ComplicationError ProviderSetDataType(IntPtr sharedData, ComplicationTypes type);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_title")]
        internal static extern ComplicationError ProviderSetTitle(IntPtr sharedData, string title);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_short_text")]
        internal static extern ComplicationError ProviderSetShortText(IntPtr sharedData, string shortText);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_long_text")]
        internal static extern ComplicationError ProviderSetLongText(IntPtr sharedData, string longText);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_timestamp")]
        internal static extern ComplicationError ProviderSetTimestamp(IntPtr sharedData, Int32 timestamp);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_image_path")]
        internal static extern ComplicationError ProviderSetImagePath(IntPtr sharedData, string imagePath);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_ranged_value")]
        internal static extern ComplicationError ProviderSetRangedValue(IntPtr sharedData, double currentValue, double minValue, double maxValue);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_icon_path")]
        internal static extern ComplicationError ProviderSetIconPath(IntPtr sharedData, string iconPath);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_extra_data")]
        internal static extern ComplicationError ProviderSetExtraData(IntPtr sharedData, string extraData);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_screen_reader_text")]
        internal static extern ComplicationError ProviderSetScreenReaderText(IntPtr sharedData, string screenReaderText);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_is_valid")]
        internal static extern ComplicationError ProviderSharedDataIsValid(IntPtr sharedData, out bool isVaild);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_notify_update")]
        internal static extern ComplicationError NotifyUpdate(string updatedProviderId);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_event_get_type")]
        internal static extern ComplicationError GetEventType(SafeAppControlHandle handle, out EventTypes type);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_event_get_provider_id")]
        internal static extern ComplicationError GetEventProviderId(SafeAppControlHandle handle, out string providerId);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_event_get_complication_type")]
        internal static extern ComplicationError GetEventComplicationType(SafeAppControlHandle handle, out ComplicationTypes type);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_event_get_context")]
        internal static extern ComplicationError GetEventContext(SafeAppControlHandle handle, out SafeBundleHandle context);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_setup_reply_to_editor")]
        internal static extern ComplicationError SetupReplyToEditor(SafeAppControlHandle handle, SafeBundleHandle context);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_setup_is_editing")]
        internal static extern ComplicationError IsSetupEditing(SafeAppControlHandle handle, out bool isEditing);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_setup_get_context")]
        internal static extern ComplicationError GetSetupContext(SafeAppControlHandle handle, out SafeBundleHandle context);

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
