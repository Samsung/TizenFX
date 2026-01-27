using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.WindowSystem.Shell
{
    internal static partial class Interop
    {
        internal static partial class KVMService
        {
            const string lib = "libtzsh_kvm_service.so.0";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_kvm_service_create")]
            internal static extern IntPtr Create(IntPtr tzsh, uint win);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_kvm_service_destroy")]
            internal static extern int Destroy(IntPtr kvmService);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_kvm_service_perform_drop")]
            internal static extern int PerformDrop(IntPtr kvmService);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_kvm_service_cancel_drag")]
            internal static extern int CancelDrag(IntPtr kvmService);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_kvm_service_receive_drag_data")]
            internal static extern int ReceiveDragData(IntPtr kvmService, string mimeType);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_kvm_service_get_source_mimetypes")]
            internal static extern int GetSourceMimetypes(
                IntPtr kvmService,
                out string[] mimeTypes,
                out int count);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_kvm_service_secondary_selection_set")]
            internal static extern int SetSecondarySelection(IntPtr kvmService);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_kvm_service_secondary_selection_unset")]
            internal static extern int UnsetSecondarySelection(IntPtr kvmService);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_kvm_service_perform_drop_target")]
            internal static extern int PerformDropTarget(IntPtr kvmService, uint drop_target);

            internal delegate void KVMDragStartEventCallback(IntPtr data, IntPtr kvmService);
            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_kvm_service_drag_start_cb_set")]
            internal static extern int SetDragStartEventHandler(IntPtr kvmService, KVMDragStartEventCallback func, IntPtr data);

            internal delegate void KVMDragEndEventCallback(IntPtr data, IntPtr kvmService);
            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_kvm_service_drag_end_cb_set")]
            internal static extern int SetDragEndEventHandler(IntPtr kvmService, KVMDragEndEventCallback func, IntPtr data);
        }
    }
}
