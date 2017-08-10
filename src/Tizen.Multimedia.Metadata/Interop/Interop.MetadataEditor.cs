using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class MetadataEditor
    {
        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_create")]
        internal static extern MetadataEditorError Create(out IntPtr handle);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_set_path")]
        internal static extern MetadataEditorError SetPath(IntPtr handle, string path);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_destroy")]
        internal static extern MetadataEditorError Destroy(IntPtr handle);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_get_metadata")]
        internal static extern MetadataEditorError GetMetadata(IntPtr handle, MetadataEditorAttr attribute, out IntPtr value);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_set_metadata")]
        internal static extern MetadataEditorError SetMetadata(IntPtr handle, MetadataEditorAttr attribute, string value);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_update_metadata")]
        internal static extern MetadataEditorError UpdateMetadata(IntPtr handle);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_get_picture")]
        internal static extern MetadataEditorError GetPicture(IntPtr handle, int index, out IntPtr picture, out int size, out IntPtr mimeType);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_append_picture")]
        internal static extern MetadataEditorError AddPicture(IntPtr handle, string path);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_remove_picture")]
        internal static extern MetadataEditorError RemovePicture(IntPtr handle, int index);
    }
}
