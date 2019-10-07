#define EFL_BETA
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
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Access.SelectionConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ISelection : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Called when selection has been changed.</summary>
    event EventHandler AccessSelectionChangedEvent;
}

/// <summary>Elementary access selection interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class SelectionConcrete :
    Efl.Eo.EoWrapper
    , ISelection
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(SelectionConcrete))
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
    private SelectionConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_access_selection_interface_get();

    /// <summary>Initializes a new instance of the <see cref="ISelection"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private SelectionConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Called when selection has been changed.</summary>
    public event EventHandler AccessSelectionChangedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_SELECTION_EVENT_ACCESS_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event AccessSelectionChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAccessSelectionChangedEvent(EventArgs e)
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


#pragma warning disable CS0628
    /// <summary>Gets the number of currently selected children</summary>
    /// <returns>Number of currently selected children</returns>
    protected int GetSelectedChildrenCount() {
        var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_selected_children_count_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Gets child for given child index</summary>
    /// <param name="selected_child_index">Index of child</param>
    /// <returns>Child object</returns>
    protected Efl.Object GetSelectedChild(int selected_child_index) {
        var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_selected_child_get_ptr.Value.Delegate(this.NativeHandle,selected_child_index);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Adds selection for given child index</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
    protected bool SelectChild(int child_index) {
        var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_child_select_ptr.Value.Delegate(this.NativeHandle,child_index);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Removes selection for given child index</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
    protected bool DeselectSelectedChild(int child_index) {
        var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_selected_child_deselect_ptr.Value.Delegate(this.NativeHandle,child_index);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Determines if child specified by index is selected</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if child is selected, <c>false</c> otherwise</returns>
    protected bool IsChildSelected(int child_index) {
        var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_is_child_selected_ptr.Value.Delegate(this.NativeHandle,child_index);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Adds selection for all children</summary>
    /// <returns><c>true</c> if selection was added to all children, <c>false</c> otherwise</returns>
    protected bool SelectAllChildren() {
        var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_all_children_select_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Clears the current selection</summary>
    /// <returns><c>true</c> if selection was cleared, <c>false</c> otherwise</returns>
    protected bool ClearAccessSelection() {
        var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_clear_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Removes selection for given child index</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
    protected bool DeselectChild(int child_index) {
        var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_child_deselect_ptr.Value.Delegate(this.NativeHandle,child_index);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Gets the number of currently selected children</summary>
    /// <value>Number of currently selected children</value>
    protected int SelectedChildrenCount {
        get { return GetSelectedChildrenCount(); }
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Access.SelectionConcrete.efl_access_selection_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Access.SelectionConcrete.efl_access_selection_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate int efl_access_selection_selected_children_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_access_selection_selected_children_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_selected_children_count_get_api_delegate> efl_access_selection_selected_children_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_selected_children_count_get_api_delegate>(Module, "efl_access_selection_selected_children_count_get");

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_access_selection_selected_child_get_delegate(System.IntPtr obj, System.IntPtr pd,  int selected_child_index);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_access_selection_selected_child_get_api_delegate(System.IntPtr obj,  int selected_child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_selected_child_get_api_delegate> efl_access_selection_selected_child_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_selected_child_get_api_delegate>(Module, "efl_access_selection_selected_child_get");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_child_select_delegate(System.IntPtr obj, System.IntPtr pd,  int child_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_child_select_api_delegate(System.IntPtr obj,  int child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_child_select_api_delegate> efl_access_selection_child_select_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_child_select_api_delegate>(Module, "efl_access_selection_child_select");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_selected_child_deselect_delegate(System.IntPtr obj, System.IntPtr pd,  int child_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_selected_child_deselect_api_delegate(System.IntPtr obj,  int child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_selected_child_deselect_api_delegate> efl_access_selection_selected_child_deselect_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_selected_child_deselect_api_delegate>(Module, "efl_access_selection_selected_child_deselect");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_is_child_selected_delegate(System.IntPtr obj, System.IntPtr pd,  int child_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_is_child_selected_api_delegate(System.IntPtr obj,  int child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_is_child_selected_api_delegate> efl_access_selection_is_child_selected_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_is_child_selected_api_delegate>(Module, "efl_access_selection_is_child_selected");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_all_children_select_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_all_children_select_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_all_children_select_api_delegate> efl_access_selection_all_children_select_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_all_children_select_api_delegate>(Module, "efl_access_selection_all_children_select");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_clear_api_delegate> efl_access_selection_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_clear_api_delegate>(Module, "efl_access_selection_clear");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_child_deselect_delegate(System.IntPtr obj, System.IntPtr pd,  int child_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_child_deselect_api_delegate(System.IntPtr obj,  int child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_child_deselect_api_delegate> efl_access_selection_child_deselect_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_child_deselect_api_delegate>(Module, "efl_access_selection_child_deselect");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_AccessSelectionConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
