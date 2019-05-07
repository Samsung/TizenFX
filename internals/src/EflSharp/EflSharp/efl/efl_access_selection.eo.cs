#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Access {

/// <summary>Elementary access selection interface</summary>
[Efl.Access.ISelectionConcrete.NativeMethods]
public interface ISelection : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Gets the number of currently selected children</summary>
/// <returns>Number of currently selected children</returns>
int GetSelectedChildrenCount();
    /// <summary>Gets child for given child index</summary>
/// <param name="selected_child_index">Index of child</param>
/// <returns>Child object</returns>
Efl.Object GetSelectedChild(int selected_child_index);
    /// <summary>Adds selection for given child index</summary>
/// <param name="child_index">Index of child</param>
/// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
bool ChildSelect(int child_index);
    /// <summary>Removes selection for given child index</summary>
/// <param name="child_index">Index of child</param>
/// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
bool SelectedChildDeselect(int child_index);
    /// <summary>Determines if child specified by index is selected</summary>
/// <param name="child_index">Index of child</param>
/// <returns><c>true</c> if child is selected, <c>false</c> otherwise</returns>
bool IsChildSelected(int child_index);
    /// <summary>Adds selection for all children</summary>
/// <returns><c>true</c> if selection was added to all children, <c>false</c> otherwise</returns>
bool AllChildrenSelect();
    /// <summary>Clears the current selection</summary>
/// <returns><c>true</c> if selection was cleared, <c>false</c> otherwise</returns>
bool ClearAccessSelection();
    /// <summary>Removes selection for given child index</summary>
/// <param name="child_index">Index of child</param>
/// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
bool ChildDeselect(int child_index);
                                    /// <summary>Called when selection has been changed.</summary>
    event EventHandler AccessSelectionChangedEvt;
    /// <summary>Gets the number of currently selected children</summary>
/// <value>Number of currently selected children</value>
    int SelectedChildrenCount {
        get ;
    }
}
/// <summary>Elementary access selection interface</summary>
sealed public class ISelectionConcrete : 

ISelection
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ISelectionConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    private Dictionary<(IntPtr desc, object evtDelegate), (IntPtr evtCallerPtr, Efl.EventCb evtCaller)> eoEvents = new Dictionary<(IntPtr desc, object evtDelegate), (IntPtr evtCallerPtr, Efl.EventCb evtCaller)>();
    private readonly object eventLock = new object();
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle
    {
        get { return handle; }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_access_selection_interface_get();
    /// <summary>Initializes a new instance of the <see cref="ISelection"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private ISelectionConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~ISelectionConcrete()
    {
        Dispose(false);
    }

    ///<summary>Releases the underlying native instance.</summary>
    private void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero)
        {
            IntPtr h = handle;
            handle = IntPtr.Zero;

            IntPtr gcHandlePtr = IntPtr.Zero;
            if (eoEvents.Count != 0)
            {
                GCHandle gcHandle = GCHandle.Alloc(eoEvents);
                gcHandlePtr = GCHandle.ToIntPtr(gcHandle);
            }

            if (disposing)
            {
                Efl.Eo.Globals.efl_mono_native_dispose(h, gcHandlePtr);
            }
            else
            {
                Monitor.Enter(Efl.All.InitLock);
                if (Efl.All.MainLoopInitialized)
                {
                    Efl.Eo.Globals.efl_mono_thread_safe_native_dispose(h, gcHandlePtr);
                }

                Monitor.Exit(Efl.All.InitLock);
            }
        }

    }

    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    ///<summary>Adds a new event handler, registering it to the native event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evtCaller">Delegate to be called by native code on event raising.</param>
    ///<param name="evtDelegate">Managed delegate that will be called by evtCaller on event raising.</param>
    private void AddNativeEventHandler(string lib, string key, Efl.EventCb evtCaller, object evtDelegate)
    {
        IntPtr desc = Efl.EventDescription.GetNative(lib, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
        }

        if (eoEvents.ContainsKey((desc, evtDelegate)))
        {
            Eina.Log.Warning($"Event proxy for event {key} already registered!");
            return;
        }

        IntPtr evtCallerPtr = Marshal.GetFunctionPointerForDelegate(evtCaller);
        if (!Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evtCallerPtr, IntPtr.Zero))
        {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return;
        }

        eoEvents[(desc, evtDelegate)] = (evtCallerPtr, evtCaller);
        Eina.Error.RaiseIfUnhandledException();
    }

    ///<summary>Removes the given event handler for the given event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evtDelegate">The delegate to be removed.</param>
    private void RemoveNativeEventHandler(string lib, string key, object evtDelegate)
    {
        IntPtr desc = Efl.EventDescription.GetNative(lib, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        var evtPair = (desc, evtDelegate);
        if (eoEvents.TryGetValue(evtPair, out var caller))
        {
            if (!Efl.Eo.Globals.efl_event_callback_del(handle, desc, caller.evtCallerPtr, IntPtr.Zero))
            {
                Eina.Log.Error($"Failed to remove event proxy for event {key}");
                return;
            }

            eoEvents.Remove(evtPair);
            Eina.Error.RaiseIfUnhandledException();
        }
        else
        {
            Eina.Log.Error($"Trying to remove proxy for event {key} when it is nothing registered.");
        }
    }

    /// <summary>Called when selection has been changed.</summary>
    public event EventHandler AccessSelectionChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_ACCESS_SELECTION_EVENT_ACCESS_SELECTION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_ACCESS_SELECTION_EVENT_ACCESS_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AccessSelectionChangedEvt.</summary>
    public void OnAccessSelectionChangedEvt(EventArgs e)
    {
        var key = "_EFL_ACCESS_SELECTION_EVENT_ACCESS_SELECTION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Gets the number of currently selected children</summary>
    /// <returns>Number of currently selected children</returns>
    public int GetSelectedChildrenCount() {
         var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_selected_children_count_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets child for given child index</summary>
    /// <param name="selected_child_index">Index of child</param>
    /// <returns>Child object</returns>
    public Efl.Object GetSelectedChild(int selected_child_index) {
                                 var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_selected_child_get_ptr.Value.Delegate(this.NativeHandle,selected_child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds selection for given child index</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
    public bool ChildSelect(int child_index) {
                                 var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_child_select_ptr.Value.Delegate(this.NativeHandle,child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Removes selection for given child index</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
    public bool SelectedChildDeselect(int child_index) {
                                 var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_selected_child_deselect_ptr.Value.Delegate(this.NativeHandle,child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Determines if child specified by index is selected</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if child is selected, <c>false</c> otherwise</returns>
    public bool IsChildSelected(int child_index) {
                                 var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_is_child_selected_ptr.Value.Delegate(this.NativeHandle,child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds selection for all children</summary>
    /// <returns><c>true</c> if selection was added to all children, <c>false</c> otherwise</returns>
    public bool AllChildrenSelect() {
         var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_all_children_select_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Clears the current selection</summary>
    /// <returns><c>true</c> if selection was cleared, <c>false</c> otherwise</returns>
    public bool ClearAccessSelection() {
         var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_clear_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes selection for given child index</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
    public bool ChildDeselect(int child_index) {
                                 var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_child_deselect_ptr.Value.Delegate(this.NativeHandle,child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Gets the number of currently selected children</summary>
/// <value>Number of currently selected children</value>
    public int SelectedChildrenCount {
        get { return GetSelectedChildrenCount(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Access.ISelectionConcrete.efl_access_selection_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_access_selection_selected_children_count_get_static_delegate == null)
            {
                efl_access_selection_selected_children_count_get_static_delegate = new efl_access_selection_selected_children_count_get_delegate(selected_children_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectedChildrenCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_selected_children_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_selected_children_count_get_static_delegate) });
            }

            if (efl_access_selection_selected_child_get_static_delegate == null)
            {
                efl_access_selection_selected_child_get_static_delegate = new efl_access_selection_selected_child_get_delegate(selected_child_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectedChild") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_selected_child_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_selected_child_get_static_delegate) });
            }

            if (efl_access_selection_child_select_static_delegate == null)
            {
                efl_access_selection_child_select_static_delegate = new efl_access_selection_child_select_delegate(child_select);
            }

            if (methods.FirstOrDefault(m => m.Name == "ChildSelect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_child_select"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_child_select_static_delegate) });
            }

            if (efl_access_selection_selected_child_deselect_static_delegate == null)
            {
                efl_access_selection_selected_child_deselect_static_delegate = new efl_access_selection_selected_child_deselect_delegate(selected_child_deselect);
            }

            if (methods.FirstOrDefault(m => m.Name == "SelectedChildDeselect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_selected_child_deselect"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_selected_child_deselect_static_delegate) });
            }

            if (efl_access_selection_is_child_selected_static_delegate == null)
            {
                efl_access_selection_is_child_selected_static_delegate = new efl_access_selection_is_child_selected_delegate(is_child_selected);
            }

            if (methods.FirstOrDefault(m => m.Name == "IsChildSelected") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_is_child_selected"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_is_child_selected_static_delegate) });
            }

            if (efl_access_selection_all_children_select_static_delegate == null)
            {
                efl_access_selection_all_children_select_static_delegate = new efl_access_selection_all_children_select_delegate(all_children_select);
            }

            if (methods.FirstOrDefault(m => m.Name == "AllChildrenSelect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_all_children_select"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_all_children_select_static_delegate) });
            }

            if (efl_access_selection_clear_static_delegate == null)
            {
                efl_access_selection_clear_static_delegate = new efl_access_selection_clear_delegate(access_selection_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearAccessSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_clear_static_delegate) });
            }

            if (efl_access_selection_child_deselect_static_delegate == null)
            {
                efl_access_selection_child_deselect_static_delegate = new efl_access_selection_child_deselect_delegate(child_deselect);
            }

            if (methods.FirstOrDefault(m => m.Name == "ChildDeselect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_child_deselect"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_child_deselect_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Access.ISelectionConcrete.efl_access_selection_interface_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate int efl_access_selection_selected_children_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_access_selection_selected_children_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_selected_children_count_get_api_delegate> efl_access_selection_selected_children_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_selected_children_count_get_api_delegate>(Module, "efl_access_selection_selected_children_count_get");

        private static int selected_children_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_selection_selected_children_count_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((ISelection)wrapper).GetSelectedChildrenCount();
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
                return efl_access_selection_selected_children_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_selection_selected_children_count_get_delegate efl_access_selection_selected_children_count_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_access_selection_selected_child_get_delegate(System.IntPtr obj, System.IntPtr pd,  int selected_child_index);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_access_selection_selected_child_get_api_delegate(System.IntPtr obj,  int selected_child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_selected_child_get_api_delegate> efl_access_selection_selected_child_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_selected_child_get_api_delegate>(Module, "efl_access_selection_selected_child_get");

        private static Efl.Object selected_child_get(System.IntPtr obj, System.IntPtr pd, int selected_child_index)
        {
            Eina.Log.Debug("function efl_access_selection_selected_child_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = ((ISelection)wrapper).GetSelectedChild(selected_child_index);
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
                return efl_access_selection_selected_child_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), selected_child_index);
            }
        }

        private static efl_access_selection_selected_child_get_delegate efl_access_selection_selected_child_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_child_select_delegate(System.IntPtr obj, System.IntPtr pd,  int child_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_child_select_api_delegate(System.IntPtr obj,  int child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_child_select_api_delegate> efl_access_selection_child_select_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_child_select_api_delegate>(Module, "efl_access_selection_child_select");

        private static bool child_select(System.IntPtr obj, System.IntPtr pd, int child_index)
        {
            Eina.Log.Debug("function efl_access_selection_child_select was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISelection)wrapper).ChildSelect(child_index);
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
                return efl_access_selection_child_select_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child_index);
            }
        }

        private static efl_access_selection_child_select_delegate efl_access_selection_child_select_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_selected_child_deselect_delegate(System.IntPtr obj, System.IntPtr pd,  int child_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_selected_child_deselect_api_delegate(System.IntPtr obj,  int child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_selected_child_deselect_api_delegate> efl_access_selection_selected_child_deselect_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_selected_child_deselect_api_delegate>(Module, "efl_access_selection_selected_child_deselect");

        private static bool selected_child_deselect(System.IntPtr obj, System.IntPtr pd, int child_index)
        {
            Eina.Log.Debug("function efl_access_selection_selected_child_deselect was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISelection)wrapper).SelectedChildDeselect(child_index);
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
                return efl_access_selection_selected_child_deselect_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child_index);
            }
        }

        private static efl_access_selection_selected_child_deselect_delegate efl_access_selection_selected_child_deselect_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_is_child_selected_delegate(System.IntPtr obj, System.IntPtr pd,  int child_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_is_child_selected_api_delegate(System.IntPtr obj,  int child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_is_child_selected_api_delegate> efl_access_selection_is_child_selected_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_is_child_selected_api_delegate>(Module, "efl_access_selection_is_child_selected");

        private static bool is_child_selected(System.IntPtr obj, System.IntPtr pd, int child_index)
        {
            Eina.Log.Debug("function efl_access_selection_is_child_selected was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISelection)wrapper).IsChildSelected(child_index);
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
                return efl_access_selection_is_child_selected_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child_index);
            }
        }

        private static efl_access_selection_is_child_selected_delegate efl_access_selection_is_child_selected_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_all_children_select_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_all_children_select_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_all_children_select_api_delegate> efl_access_selection_all_children_select_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_all_children_select_api_delegate>(Module, "efl_access_selection_all_children_select");

        private static bool all_children_select(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_selection_all_children_select was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISelection)wrapper).AllChildrenSelect();
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
                return efl_access_selection_all_children_select_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_selection_all_children_select_delegate efl_access_selection_all_children_select_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_clear_api_delegate> efl_access_selection_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_clear_api_delegate>(Module, "efl_access_selection_clear");

        private static bool access_selection_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_selection_clear was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISelection)wrapper).ClearAccessSelection();
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
                return efl_access_selection_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_selection_clear_delegate efl_access_selection_clear_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_child_deselect_delegate(System.IntPtr obj, System.IntPtr pd,  int child_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_child_deselect_api_delegate(System.IntPtr obj,  int child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_child_deselect_api_delegate> efl_access_selection_child_deselect_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_child_deselect_api_delegate>(Module, "efl_access_selection_child_deselect");

        private static bool child_deselect(System.IntPtr obj, System.IntPtr pd, int child_index)
        {
            Eina.Log.Debug("function efl_access_selection_child_deselect was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISelection)wrapper).ChildDeselect(child_index);
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
                return efl_access_selection_child_deselect_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child_index);
            }
        }

        private static efl_access_selection_child_deselect_delegate efl_access_selection_child_deselect_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

