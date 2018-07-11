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

        internal enum NativeResultType : int
        {
            Success = Tizen.Internals.Errors.ErrorCode.None,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            MaxExceed = -0x01190000 | 0x01,
        }

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_geometry_create")]
        internal static extern ComplicationError CreateGeometry(out IntPtr handle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_geometry_destroy")]
        internal static extern ComplicationError DestroyGeometry(IntPtr handle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_geometry_set")]
        internal static extern ComplicationError SetGeometry(IntPtr handle, int x, int y, int w, int h);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_geometry_get")]
        internal static extern ComplicationError GetGeometry(IntPtr handle, out int x, out int y, out int w, out int h);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_create")]
        internal static extern ComplicationError CreateComplication(int complicationId,
            string defaultProviderId, ComplicationType defaultType, int supportTypes, ShapeType shapeType, out IntPtr handle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_destroy")]
        internal static extern ComplicationError Destroy(IntPtr handle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_add_updated_cb")]
        internal static extern ComplicationError AddUpdatedCallback(IntPtr handle, ComplicationUpdatedCallback callback, IntPtr userData);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_send_update_request")]
        internal static extern ComplicationError SendUpdateRequest(IntPtr handle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_data_get_type")]
        internal static extern ComplicationError GetDataType(SafeBundleHandle handle, out ComplicationType type);

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

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_add_edit_ready_cb")]
        internal static extern ComplicationError AddEditReadyCallback(EditReadyCallback callback, IntPtr userData);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_remove_edit_ready_cb")]
        internal static extern ComplicationError RemoveEditReadyCallback(EditReadyCallback callback);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_get_current_data_idx")]
        internal static extern ComplicationError GetCurrentIdx(IntPtr handle, out int curIdx);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_get_current_data")]
        internal static extern ComplicationError GetCurrentData(IntPtr handle, out SafeBundleHandle data);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_get_editable_id")]
        internal static extern ComplicationError GetEditableId(IntPtr handle, out int editableId);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_add_complication")]
        internal static extern ComplicationError AddComplication(IntPtr container, int editId, IntPtr comp, IntPtr geo);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_add_design_element")]
        internal static extern ComplicationError AddDesignElement(IntPtr container, int editId, int curDataIdx, IntPtr listHandle, IntPtr geo, string editableName);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_candidates_list_create")]
        internal static extern ComplicationError CreateCandidatesList(out IntPtr listHandle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_candidates_list_add")]
        internal static extern ComplicationError AddCandidatesListItem(IntPtr listHandle, SafeBundleHandle candidate);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_candidates_list_destroy")]
        internal static extern ComplicationError DestroyCandidatesList(IntPtr listHandle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_request_edit")]
        internal static extern ComplicationError RequestEdit(IntPtr container, EditableUpdatedCallback callback, IntPtr userData);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_container_get")]
        internal static extern ComplicationError GetEditableContainer(out IntPtr container);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_editable_load_current_data")]
        internal static extern ComplicationError LoadCurrentData(int editableId, out SafeBundleHandle data);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_add_update_requested_cb")]
        internal static extern ComplicationError AddUpdateRequestedCallback(string providerId, UpdateRequestedCallback callback, IntPtr userData);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_add_update_requested_cb")]
        internal static extern ComplicationError RemoveUpdateRequestedCallback(string providerId, UpdateRequestedCallback callback);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_type")]
        internal static extern ComplicationError ProviderSetType(IntPtr sharedData, ComplicationType type);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_title")]
        internal static extern ComplicationError ProviderSetTitle(IntPtr sharedData, string title);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_short_text")]
        internal static extern ComplicationError ProviderSetShortText(IntPtr sharedData, string shortText);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_long_text")]
        internal static extern ComplicationError ProviderSetLongText(IntPtr sharedData, string longText);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_timestamp")]
        internal static extern ComplicationError ProviderSetTimestamp(IntPtr sharedData, long timestamp);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_image_path")]
        internal static extern ComplicationError ProviderSetImagePath(IntPtr sharedData, string imagePath);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_ranged_value")]
        internal static extern ComplicationError ProviderSetRangedValue(IntPtr sharedData, double currentValue, double minValue, double maxValue);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_icon_path")]
        internal static extern ComplicationError ProviderSetIconPath(IntPtr sharedData, string iconPath);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_data_set_extra_data")]
        internal static extern ComplicationError ProviderSetExtraData(IntPtr sharedData, string extraData);

        [DllImport(Libraries.ComplicationProvider, EntryPoint = "watchface_complication_provider_notify_update")]
        internal static extern ComplicationError NotifyUpdate(string updatedProviderId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void EditReadyCallback(IntPtr handle, string editorAppId, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void UpdateRequestedCallback(string providerId, string reqAppId, ComplicationType type,
            IntPtr context, IntPtr sharedData, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ComplicationUpdatedCallback(int complicationId,
            string providerId, ComplicationType type, IntPtr data, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void EditableUpdatedCallback(IntPtr handle, int selectedIdx,
            int state, IntPtr userData);
    }
}
