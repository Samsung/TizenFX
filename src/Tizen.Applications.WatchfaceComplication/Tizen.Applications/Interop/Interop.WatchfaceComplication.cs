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

        internal sealed class SafeComplicationHandle : SafeHandle
        {
            internal SafeComplicationHandle()
                : base(IntPtr.Zero, true)
            {
            }

            internal SafeComplicationHandle(IntPtr existingHandle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
            {
                SetHandle(existingHandle);
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                WatchfaceComplication.Destroy(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }        

        [DllImport(Libraries.Editable, EntryPoint = "watchface_editable_geometry_create")]
        internal static extern ComplicationError CreateGeometry(out IntPtr handle);

        [DllImport(Libraries.Editable, EntryPoint = "watchface_editable_geometry_destroy")]
        internal static extern ComplicationError DestroyGeometry(IntPtr handle);

        [DllImport(Libraries.Editable, EntryPoint = "watchface_editable_geometry_set")]
        internal static extern ComplicationError SetGeometry(IntPtr handle, int x, int y, int w, int h);

        [DllImport(Libraries.Editable, EntryPoint = "watchface_editable_geometry_get")]
        internal static extern ComplicationError GetGeometry(IntPtr handle, out int x, out int y, out int w, out int h);
        
        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_create")]
        internal static extern ComplicationError CreateComplication(int complicationId,
            string defaultProviderId, ComplicationType defaultType, int supportTypes, EditableShapeType shapeType, out SafeComplicationHandle handle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_destroy")]
        internal static extern ComplicationError Destroy(IntPtr handle);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_add_updated_cb")]
        internal static extern ComplicationError AddUpdatedCallback(SafeComplicationHandle handle, ComplicationUpdatedCallback callback, IntPtr userData);

        [DllImport(Libraries.Complication, EntryPoint = "watchface_complication_send_update_request")]
        internal static extern ComplicationError SendUpdateRequest(SafeComplicationHandle handle);

        [DllImport(Libraries.Editable, EntryPoint = "watchface_editable_get_current_data_idx")]
        internal static extern ComplicationError GetCurrentIdx(IntPtr handle, out int curIdx);

        [DllImport(Libraries.Editable, EntryPoint = "watchface_editable_get_editable_id")]
        internal static extern ComplicationError GetEditableId(IntPtr handle, out int editableId);
        

        [DllImport(Libraries.Editable, EntryPoint = "watchface_editable_add_complication")]
        internal static extern ComplicationError AddComplication(IntPtr container, int editId, IntPtr comp, IntPtr geo);

        [DllImport(Libraries.Editable, EntryPoint = "watchface_editable_add_design_element")]
        internal static extern ComplicationError AddDesignElement(IntPtr container, int editId, int curDataIdx, IntPtr listHandle, IntPtr geo, string editableName);

        [DllImport(Libraries.Editable, EntryPoint = "watchface_editable_candidates_list_create")]
        internal static extern ComplicationError CreateCandidatesList(out IntPtr listHandle);

        [DllImport(Libraries.Editable, EntryPoint = "watchface_editable_candidates_list_add")]
        internal static extern ComplicationError AddCandidatesListItem(IntPtr listHandle, SafeBundleHandle candidate);

        [DllImport(Libraries.Editable, EntryPoint = "watchface_editable_candidates_list_destroy")]
        internal static extern ComplicationError DestroyCandidatesList(IntPtr listHandle);

        [DllImport(Libraries.Editable, EntryPoint = "watchface_editable_request_edit")]
        internal static extern ComplicationError RequestEdit(IntPtr container, EditableUpdatedCallback callback, IntPtr userData);        

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ComplicationUpdatedCallback(int complicationId,
            string providerId, ComplicationType type, IntPtr data, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void EditableUpdatedCallback(IntPtr handle, int selectedIdx,
            int state, IntPtr userData);
    }
}
