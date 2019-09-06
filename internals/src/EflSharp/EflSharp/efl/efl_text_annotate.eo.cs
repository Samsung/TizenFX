#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Cursor API</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.ITextAnnotateConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ITextAnnotate : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>A new format for <c>annotation</c>.
/// This will replace the format applied by <c>annotation</c> with <c>format</c>. Assumes that <c>annotation</c> is a handle for an existing annotation, i.e. one that was added using <see cref="Efl.ITextAnnotate.AnnotationInsert"/> to this object. Otherwise, this will fail and return <c>false</c>.</summary>
/// <param name="annotation">Given annotation</param>
/// <returns>The new format for the given annotation</returns>
System.String GetAnnotation(Efl.TextAnnotateAnnotation annotation);
    /// <summary>A new format for <c>annotation</c>.
/// This will replace the format applied by <c>annotation</c> with <c>format</c>. Assumes that <c>annotation</c> is a handle for an existing annotation, i.e. one that was added using <see cref="Efl.ITextAnnotate.AnnotationInsert"/> to this object. Otherwise, this will fail and return <c>false</c>.</summary>
/// <param name="annotation">Given annotation</param>
/// <param name="format">The new format for the given annotation</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
bool SetAnnotation(Efl.TextAnnotateAnnotation annotation, System.String format);
    /// <summary>The object-item annotation at the cursor&apos;s position.</summary>
/// <param name="cur">Cursor object</param>
/// <returns>Annotation</returns>
Efl.TextAnnotateAnnotation GetCursorItemAnnotation(Efl.TextCursorCursor cur);
    /// <summary>Returns an iterator of all the handles in a range.</summary>
/// <param name="start">Start of range</param>
/// <param name="end">End of range</param>
/// <returns>Handle of the Annotation</returns>
Eina.Iterator<Efl.TextAnnotateAnnotation> GetRangeAnnotations(Efl.TextCursorCursor start, Efl.TextCursorCursor end);
    /// <summary>Inserts an annotation format in a specified range [<c>start</c>, <c>end</c> - 1].
/// The <c>format</c> will be applied to the given range, and the <c>annotation</c> handle will be returned for further handling.</summary>
/// <param name="start">Start of range</param>
/// <param name="end">End of range</param>
/// <param name="format">Annotation format</param>
/// <returns>Handle of inserted annotation</returns>
Efl.TextAnnotateAnnotation AnnotationInsert(Efl.TextCursorCursor start, Efl.TextCursorCursor end, System.String format);
    /// <summary>Deletes given annotation.
/// All formats applied by <c>annotation</c> will be removed and it will be deleted.</summary>
/// <param name="annotation">Annotation to be removed</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
bool DelAnnotation(Efl.TextAnnotateAnnotation annotation);
    /// <summary>Sets given cursors to the start and end positions of the annotation.
/// The cursors <c>start</c> and <c>end</c> will be set to the start and end positions of the given annotation <c>annotation</c>.</summary>
/// <param name="annotation">Annotation handle to query</param>
/// <param name="start">Cursor to be set to the start position of the annotation in the text</param>
/// <param name="end">Cursor to be set to the end position of the annotation in the text</param>
void GetAnnotationPositions(Efl.TextAnnotateAnnotation annotation, Efl.TextCursorCursor start, Efl.TextCursorCursor end);
    /// <summary>Whether this is an &quot;item&quot; type of annotation. Should be used before querying the annotation&apos;s geometry, as only &quot;item&quot; annotations have a geometry.
/// see <see cref="Efl.ITextAnnotate.CursorItemInsert"/> see <see cref="Efl.ITextAnnotate.GetItemGeometry"/></summary>
/// <param name="annotation">Given annotation</param>
/// <returns><c>true</c> if given annotation is an object item, <c>false</c> otherwise</returns>
bool AnnotationIsItem(Efl.TextAnnotateAnnotation annotation);
    /// <summary>Queries a given object item for its geometry.
/// Note that the provided annotation should be an object item type.</summary>
/// <param name="an">Given annotation to query</param>
/// <param name="x">X coordinate of the annotation</param>
/// <param name="y">Y coordinate of the annotation</param>
/// <param name="w">Width of the annotation</param>
/// <param name="h">Height of the annotation</param>
/// <returns><c>true</c> if given annotation is an object item, <c>false</c> otherwise</returns>
bool GetItemGeometry(Efl.TextAnnotateAnnotation an, out int x, out int y, out int w, out int h);
    /// <summary>Inserts a object item at specified position.
/// This adds a placeholder to be queried by higher-level code, which in turn place graphics on top of it. It essentially places an OBJECT REPLACEMENT CHARACTER and set a special annotation to it.</summary>
/// <param name="cur">Cursor object</param>
/// <param name="item">Item key to be used in higher-up code to query and decided what image, emoticon etc. to embed.</param>
/// <param name="format">Size format of the inserted item. This hints how to size the item in the text.</param>
/// <returns>The annotation handle of the inserted item.</returns>
Efl.TextAnnotateAnnotation CursorItemInsert(Efl.TextCursorCursor cur, System.String item, System.String format);
                                        }
/// <summary>Cursor API</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
sealed public  class ITextAnnotateConcrete :
    Efl.Eo.EoWrapper
    , ITextAnnotate
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ITextAnnotateConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private ITextAnnotateConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_text_annotate_interface_get();
    /// <summary>Initializes a new instance of the <see cref="ITextAnnotate"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ITextAnnotateConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>A new format for <c>annotation</c>.
    /// This will replace the format applied by <c>annotation</c> with <c>format</c>. Assumes that <c>annotation</c> is a handle for an existing annotation, i.e. one that was added using <see cref="Efl.ITextAnnotate.AnnotationInsert"/> to this object. Otherwise, this will fail and return <c>false</c>.</summary>
    /// <param name="annotation">Given annotation</param>
    /// <returns>The new format for the given annotation</returns>
    public System.String GetAnnotation(Efl.TextAnnotateAnnotation annotation) {
                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_annotation_get_ptr.Value.Delegate(this.NativeHandle,annotation);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>A new format for <c>annotation</c>.
    /// This will replace the format applied by <c>annotation</c> with <c>format</c>. Assumes that <c>annotation</c> is a handle for an existing annotation, i.e. one that was added using <see cref="Efl.ITextAnnotate.AnnotationInsert"/> to this object. Otherwise, this will fail and return <c>false</c>.</summary>
    /// <param name="annotation">Given annotation</param>
    /// <param name="format">The new format for the given annotation</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public bool SetAnnotation(Efl.TextAnnotateAnnotation annotation, System.String format) {
                                                         var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_annotation_set_ptr.Value.Delegate(this.NativeHandle,annotation, format);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>The object-item annotation at the cursor&apos;s position.</summary>
    /// <param name="cur">Cursor object</param>
    /// <returns>Annotation</returns>
    public Efl.TextAnnotateAnnotation GetCursorItemAnnotation(Efl.TextCursorCursor cur) {
                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_cursor_item_annotation_get_ptr.Value.Delegate(this.NativeHandle,cur);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns an iterator of all the handles in a range.</summary>
    /// <param name="start">Start of range</param>
    /// <param name="end">End of range</param>
    /// <returns>Handle of the Annotation</returns>
    public Eina.Iterator<Efl.TextAnnotateAnnotation> GetRangeAnnotations(Efl.TextCursorCursor start, Efl.TextCursorCursor end) {
                                                         var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_range_annotations_get_ptr.Value.Delegate(this.NativeHandle,start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return new Eina.Iterator<Efl.TextAnnotateAnnotation>(_ret_var, true);
 }
    /// <summary>Inserts an annotation format in a specified range [<c>start</c>, <c>end</c> - 1].
    /// The <c>format</c> will be applied to the given range, and the <c>annotation</c> handle will be returned for further handling.</summary>
    /// <param name="start">Start of range</param>
    /// <param name="end">End of range</param>
    /// <param name="format">Annotation format</param>
    /// <returns>Handle of inserted annotation</returns>
    public Efl.TextAnnotateAnnotation AnnotationInsert(Efl.TextCursorCursor start, Efl.TextCursorCursor end, System.String format) {
                                                                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_annotation_insert_ptr.Value.Delegate(this.NativeHandle,start, end, format);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Deletes given annotation.
    /// All formats applied by <c>annotation</c> will be removed and it will be deleted.</summary>
    /// <param name="annotation">Annotation to be removed</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public bool DelAnnotation(Efl.TextAnnotateAnnotation annotation) {
                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_annotation_del_ptr.Value.Delegate(this.NativeHandle,annotation);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Sets given cursors to the start and end positions of the annotation.
    /// The cursors <c>start</c> and <c>end</c> will be set to the start and end positions of the given annotation <c>annotation</c>.</summary>
    /// <param name="annotation">Annotation handle to query</param>
    /// <param name="start">Cursor to be set to the start position of the annotation in the text</param>
    /// <param name="end">Cursor to be set to the end position of the annotation in the text</param>
    public void GetAnnotationPositions(Efl.TextAnnotateAnnotation annotation, Efl.TextCursorCursor start, Efl.TextCursorCursor end) {
                                                                                 Efl.ITextAnnotateConcrete.NativeMethods.efl_text_annotation_positions_get_ptr.Value.Delegate(this.NativeHandle,annotation, start, end);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Whether this is an &quot;item&quot; type of annotation. Should be used before querying the annotation&apos;s geometry, as only &quot;item&quot; annotations have a geometry.
    /// see <see cref="Efl.ITextAnnotate.CursorItemInsert"/> see <see cref="Efl.ITextAnnotate.GetItemGeometry"/></summary>
    /// <param name="annotation">Given annotation</param>
    /// <returns><c>true</c> if given annotation is an object item, <c>false</c> otherwise</returns>
    public bool AnnotationIsItem(Efl.TextAnnotateAnnotation annotation) {
                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_annotation_is_item_ptr.Value.Delegate(this.NativeHandle,annotation);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Queries a given object item for its geometry.
    /// Note that the provided annotation should be an object item type.</summary>
    /// <param name="an">Given annotation to query</param>
    /// <param name="x">X coordinate of the annotation</param>
    /// <param name="y">Y coordinate of the annotation</param>
    /// <param name="w">Width of the annotation</param>
    /// <param name="h">Height of the annotation</param>
    /// <returns><c>true</c> if given annotation is an object item, <c>false</c> otherwise</returns>
    public bool GetItemGeometry(Efl.TextAnnotateAnnotation an, out int x, out int y, out int w, out int h) {
                                                                                                                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_item_geometry_get_ptr.Value.Delegate(this.NativeHandle,an, out x, out y, out w, out h);
        Eina.Error.RaiseIfUnhandledException();
                                                                                        return _ret_var;
 }
    /// <summary>Inserts a object item at specified position.
    /// This adds a placeholder to be queried by higher-level code, which in turn place graphics on top of it. It essentially places an OBJECT REPLACEMENT CHARACTER and set a special annotation to it.</summary>
    /// <param name="cur">Cursor object</param>
    /// <param name="item">Item key to be used in higher-up code to query and decided what image, emoticon etc. to embed.</param>
    /// <param name="format">Size format of the inserted item. This hints how to size the item in the text.</param>
    /// <returns>The annotation handle of the inserted item.</returns>
    public Efl.TextAnnotateAnnotation CursorItemInsert(Efl.TextCursorCursor cur, System.String item, System.String format) {
                                                                                 var _ret_var = Efl.ITextAnnotateConcrete.NativeMethods.efl_text_cursor_item_insert_ptr.Value.Delegate(this.NativeHandle,cur, item, format);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.ITextAnnotateConcrete.efl_text_annotate_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_text_annotation_get_static_delegate == null)
            {
                efl_text_annotation_get_static_delegate = new efl_text_annotation_get_delegate(annotation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAnnotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_annotation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_get_static_delegate) });
            }

            if (efl_text_annotation_set_static_delegate == null)
            {
                efl_text_annotation_set_static_delegate = new efl_text_annotation_set_delegate(annotation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAnnotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_annotation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_set_static_delegate) });
            }

            if (efl_text_cursor_item_annotation_get_static_delegate == null)
            {
                efl_text_cursor_item_annotation_get_static_delegate = new efl_text_cursor_item_annotation_get_delegate(cursor_item_annotation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCursorItemAnnotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_item_annotation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_item_annotation_get_static_delegate) });
            }

            if (efl_text_range_annotations_get_static_delegate == null)
            {
                efl_text_range_annotations_get_static_delegate = new efl_text_range_annotations_get_delegate(range_annotations_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRangeAnnotations") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_range_annotations_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_range_annotations_get_static_delegate) });
            }

            if (efl_text_annotation_insert_static_delegate == null)
            {
                efl_text_annotation_insert_static_delegate = new efl_text_annotation_insert_delegate(annotation_insert);
            }

            if (methods.FirstOrDefault(m => m.Name == "AnnotationInsert") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_annotation_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_insert_static_delegate) });
            }

            if (efl_text_annotation_del_static_delegate == null)
            {
                efl_text_annotation_del_static_delegate = new efl_text_annotation_del_delegate(annotation_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelAnnotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_annotation_del"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_del_static_delegate) });
            }

            if (efl_text_annotation_positions_get_static_delegate == null)
            {
                efl_text_annotation_positions_get_static_delegate = new efl_text_annotation_positions_get_delegate(annotation_positions_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAnnotationPositions") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_annotation_positions_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_positions_get_static_delegate) });
            }

            if (efl_text_annotation_is_item_static_delegate == null)
            {
                efl_text_annotation_is_item_static_delegate = new efl_text_annotation_is_item_delegate(annotation_is_item);
            }

            if (methods.FirstOrDefault(m => m.Name == "AnnotationIsItem") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_annotation_is_item"), func = Marshal.GetFunctionPointerForDelegate(efl_text_annotation_is_item_static_delegate) });
            }

            if (efl_text_item_geometry_get_static_delegate == null)
            {
                efl_text_item_geometry_get_static_delegate = new efl_text_item_geometry_get_delegate(item_geometry_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetItemGeometry") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_item_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_item_geometry_get_static_delegate) });
            }

            if (efl_text_cursor_item_insert_static_delegate == null)
            {
                efl_text_cursor_item_insert_static_delegate = new efl_text_cursor_item_insert_delegate(cursor_item_insert);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorItemInsert") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_cursor_item_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_text_cursor_item_insert_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.ITextAnnotateConcrete.efl_text_annotate_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_annotation_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_annotation_get_api_delegate(System.IntPtr obj,  Efl.TextAnnotateAnnotation annotation);

        public static Efl.Eo.FunctionWrapper<efl_text_annotation_get_api_delegate> efl_text_annotation_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_annotation_get_api_delegate>(Module, "efl_text_annotation_get");

        private static System.String annotation_get(System.IntPtr obj, System.IntPtr pd, Efl.TextAnnotateAnnotation annotation)
        {
            Eina.Log.Debug("function efl_text_annotation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((ITextAnnotate)ws.Target).GetAnnotation(annotation);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        return _ret_var;

            }
            else
            {
                return efl_text_annotation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), annotation);
            }
        }

        private static efl_text_annotation_get_delegate efl_text_annotation_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_annotation_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String format);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_annotation_set_api_delegate(System.IntPtr obj,  Efl.TextAnnotateAnnotation annotation, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String format);

        public static Efl.Eo.FunctionWrapper<efl_text_annotation_set_api_delegate> efl_text_annotation_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_annotation_set_api_delegate>(Module, "efl_text_annotation_set");

        private static bool annotation_set(System.IntPtr obj, System.IntPtr pd, Efl.TextAnnotateAnnotation annotation, System.String format)
        {
            Eina.Log.Debug("function efl_text_annotation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextAnnotate)ws.Target).SetAnnotation(annotation, format);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        return _ret_var;

            }
            else
            {
                return efl_text_annotation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), annotation, format);
            }
        }

        private static efl_text_annotation_set_delegate efl_text_annotation_set_static_delegate;

        
        private delegate Efl.TextAnnotateAnnotation efl_text_cursor_item_annotation_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur);

        
        public delegate Efl.TextAnnotateAnnotation efl_text_cursor_item_annotation_get_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_item_annotation_get_api_delegate> efl_text_cursor_item_annotation_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_item_annotation_get_api_delegate>(Module, "efl_text_cursor_item_annotation_get");

        private static Efl.TextAnnotateAnnotation cursor_item_annotation_get(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur)
        {
            Eina.Log.Debug("function efl_text_cursor_item_annotation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.TextAnnotateAnnotation _ret_var = default(Efl.TextAnnotateAnnotation);
                try
                {
                    _ret_var = ((ITextAnnotate)ws.Target).GetCursorItemAnnotation(cur);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        return _ret_var;

            }
            else
            {
                return efl_text_cursor_item_annotation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur);
            }
        }

        private static efl_text_cursor_item_annotation_get_delegate efl_text_cursor_item_annotation_get_static_delegate;

        
        private delegate System.IntPtr efl_text_range_annotations_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end);

        
        public delegate System.IntPtr efl_text_range_annotations_get_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end);

        public static Efl.Eo.FunctionWrapper<efl_text_range_annotations_get_api_delegate> efl_text_range_annotations_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_range_annotations_get_api_delegate>(Module, "efl_text_range_annotations_get");

        private static System.IntPtr range_annotations_get(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor start, Efl.TextCursorCursor end)
        {
            Eina.Log.Debug("function efl_text_range_annotations_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            Eina.Iterator<Efl.TextAnnotateAnnotation> _ret_var = default(Eina.Iterator<Efl.TextAnnotateAnnotation>);
                try
                {
                    _ret_var = ((ITextAnnotate)ws.Target).GetRangeAnnotations(start, end);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_text_range_annotations_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, end);
            }
        }

        private static efl_text_range_annotations_get_delegate efl_text_range_annotations_get_static_delegate;

        
        private delegate Efl.TextAnnotateAnnotation efl_text_annotation_insert_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String format);

        
        public delegate Efl.TextAnnotateAnnotation efl_text_annotation_insert_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String format);

        public static Efl.Eo.FunctionWrapper<efl_text_annotation_insert_api_delegate> efl_text_annotation_insert_ptr = new Efl.Eo.FunctionWrapper<efl_text_annotation_insert_api_delegate>(Module, "efl_text_annotation_insert");

        private static Efl.TextAnnotateAnnotation annotation_insert(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor start, Efl.TextCursorCursor end, System.String format)
        {
            Eina.Log.Debug("function efl_text_annotation_insert was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    Efl.TextAnnotateAnnotation _ret_var = default(Efl.TextAnnotateAnnotation);
                try
                {
                    _ret_var = ((ITextAnnotate)ws.Target).AnnotationInsert(start, end, format);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        return _ret_var;

            }
            else
            {
                return efl_text_annotation_insert_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, end, format);
            }
        }

        private static efl_text_annotation_insert_delegate efl_text_annotation_insert_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_annotation_del_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_annotation_del_api_delegate(System.IntPtr obj,  Efl.TextAnnotateAnnotation annotation);

        public static Efl.Eo.FunctionWrapper<efl_text_annotation_del_api_delegate> efl_text_annotation_del_ptr = new Efl.Eo.FunctionWrapper<efl_text_annotation_del_api_delegate>(Module, "efl_text_annotation_del");

        private static bool annotation_del(System.IntPtr obj, System.IntPtr pd, Efl.TextAnnotateAnnotation annotation)
        {
            Eina.Log.Debug("function efl_text_annotation_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextAnnotate)ws.Target).DelAnnotation(annotation);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        return _ret_var;

            }
            else
            {
                return efl_text_annotation_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), annotation);
            }
        }

        private static efl_text_annotation_del_delegate efl_text_annotation_del_static_delegate;

        
        private delegate void efl_text_annotation_positions_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end);

        
        public delegate void efl_text_annotation_positions_get_api_delegate(System.IntPtr obj,  Efl.TextAnnotateAnnotation annotation,  Efl.TextCursorCursor start,  Efl.TextCursorCursor end);

        public static Efl.Eo.FunctionWrapper<efl_text_annotation_positions_get_api_delegate> efl_text_annotation_positions_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_annotation_positions_get_api_delegate>(Module, "efl_text_annotation_positions_get");

        private static void annotation_positions_get(System.IntPtr obj, System.IntPtr pd, Efl.TextAnnotateAnnotation annotation, Efl.TextCursorCursor start, Efl.TextCursorCursor end)
        {
            Eina.Log.Debug("function efl_text_annotation_positions_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((ITextAnnotate)ws.Target).GetAnnotationPositions(annotation, start, end);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_text_annotation_positions_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), annotation, start, end);
            }
        }

        private static efl_text_annotation_positions_get_delegate efl_text_annotation_positions_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_annotation_is_item_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation annotation);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_annotation_is_item_api_delegate(System.IntPtr obj,  Efl.TextAnnotateAnnotation annotation);

        public static Efl.Eo.FunctionWrapper<efl_text_annotation_is_item_api_delegate> efl_text_annotation_is_item_ptr = new Efl.Eo.FunctionWrapper<efl_text_annotation_is_item_api_delegate>(Module, "efl_text_annotation_is_item");

        private static bool annotation_is_item(System.IntPtr obj, System.IntPtr pd, Efl.TextAnnotateAnnotation annotation)
        {
            Eina.Log.Debug("function efl_text_annotation_is_item was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextAnnotate)ws.Target).AnnotationIsItem(annotation);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        return _ret_var;

            }
            else
            {
                return efl_text_annotation_is_item_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), annotation);
            }
        }

        private static efl_text_annotation_is_item_delegate efl_text_annotation_is_item_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_item_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextAnnotateAnnotation an,  out int x,  out int y,  out int w,  out int h);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_item_geometry_get_api_delegate(System.IntPtr obj,  Efl.TextAnnotateAnnotation an,  out int x,  out int y,  out int w,  out int h);

        public static Efl.Eo.FunctionWrapper<efl_text_item_geometry_get_api_delegate> efl_text_item_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_item_geometry_get_api_delegate>(Module, "efl_text_item_geometry_get");

        private static bool item_geometry_get(System.IntPtr obj, System.IntPtr pd, Efl.TextAnnotateAnnotation an, out int x, out int y, out int w, out int h)
        {
            Eina.Log.Debug("function efl_text_item_geometry_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                        x = default(int);        y = default(int);        w = default(int);        h = default(int);                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextAnnotate)ws.Target).GetItemGeometry(an, out x, out y, out w, out h);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        return _ret_var;

            }
            else
            {
                return efl_text_item_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), an, out x, out y, out w, out h);
            }
        }

        private static efl_text_item_geometry_get_delegate efl_text_item_geometry_get_static_delegate;

        
        private delegate Efl.TextAnnotateAnnotation efl_text_cursor_item_insert_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextCursorCursor cur, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String item, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String format);

        
        public delegate Efl.TextAnnotateAnnotation efl_text_cursor_item_insert_api_delegate(System.IntPtr obj,  Efl.TextCursorCursor cur, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String item, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String format);

        public static Efl.Eo.FunctionWrapper<efl_text_cursor_item_insert_api_delegate> efl_text_cursor_item_insert_ptr = new Efl.Eo.FunctionWrapper<efl_text_cursor_item_insert_api_delegate>(Module, "efl_text_cursor_item_insert");

        private static Efl.TextAnnotateAnnotation cursor_item_insert(System.IntPtr obj, System.IntPtr pd, Efl.TextCursorCursor cur, System.String item, System.String format)
        {
            Eina.Log.Debug("function efl_text_cursor_item_insert was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    Efl.TextAnnotateAnnotation _ret_var = default(Efl.TextAnnotateAnnotation);
                try
                {
                    _ret_var = ((ITextAnnotate)ws.Target).CursorItemInsert(cur, item, format);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        return _ret_var;

            }
            else
            {
                return efl_text_cursor_item_insert_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur, item, format);
            }
        }

        private static efl_text_cursor_item_insert_delegate efl_text_cursor_item_insert_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflITextAnnotateConcrete_ExtensionMethods {
    
    
}
#pragma warning restore CS1591
#endif
