#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

namespace Focus {

/// <summary>This defines the inheriting widget as Composition widget.
/// A composition widget is a widget that&apos;s the logical parent of another set of widgets which can be used for interaction.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Focus.CompositionConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IComposition : 
    Efl.Eo.IWrapper, IDisposable
{
}

/// <summary>This defines the inheriting widget as Composition widget.
/// A composition widget is a widget that&apos;s the logical parent of another set of widgets which can be used for interaction.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class CompositionConcrete :
    Efl.Eo.EoWrapper
    , IComposition
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(CompositionConcrete))
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
    private CompositionConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_focus_composition_mixin_get();

    /// <summary>Initializes a new instance of the <see cref="IComposition"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private CompositionConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Set the order of elements that will be used for composition
    /// Elements of the list can be either an <see cref="Efl.Ui.Widget"/>, an <see cref="Efl.Ui.Focus.IObject"/> or an <see cref="Efl.Gfx.IEntity"/>.
    /// 
    /// If the element is an <see cref="Efl.Ui.Widget"/> nothing is done and the widget is simply part of the order.
    /// 
    /// If the element is an <see cref="Efl.Ui.Focus.IObject"/>, then the mixin will take care of registering the element.
    /// 
    /// If the element is an <see cref="Efl.Gfx.IEntity"/>, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.</summary>
    /// <returns>The order to use</returns>
    protected Eina.List<Efl.Gfx.IEntity> GetCompositionElements() {
        var _ret_var = Efl.Ui.Focus.CompositionConcrete.NativeMethods.efl_ui_focus_composition_elements_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Gfx.IEntity>(_ret_var, true, false);

    }

    /// <summary>Set the order of elements that will be used for composition
    /// Elements of the list can be either an <see cref="Efl.Ui.Widget"/>, an <see cref="Efl.Ui.Focus.IObject"/> or an <see cref="Efl.Gfx.IEntity"/>.
    /// 
    /// If the element is an <see cref="Efl.Ui.Widget"/> nothing is done and the widget is simply part of the order.
    /// 
    /// If the element is an <see cref="Efl.Ui.Focus.IObject"/>, then the mixin will take care of registering the element.
    /// 
    /// If the element is an <see cref="Efl.Gfx.IEntity"/>, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.</summary>
    /// <param name="logical_order">The order to use</param>
    protected void SetCompositionElements(Eina.List<Efl.Gfx.IEntity> logical_order) {
        var _in_logical_order = logical_order.Handle;
logical_order.Own = false;
Efl.Ui.Focus.CompositionConcrete.NativeMethods.efl_ui_focus_composition_elements_set_ptr.Value.Delegate(this.NativeHandle,_in_logical_order);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <returns><c>true</c> or <c>false</c></returns>
    protected bool GetLogicalMode() {
        var _ret_var = Efl.Ui.Focus.CompositionConcrete.NativeMethods.efl_ui_focus_composition_logical_mode_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <param name="logical_mode"><c>true</c> or <c>false</c></param>
    protected void SetLogicalMode(bool logical_mode) {
        Efl.Ui.Focus.CompositionConcrete.NativeMethods.efl_ui_focus_composition_logical_mode_set_ptr.Value.Delegate(this.NativeHandle,logical_mode);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Mark this widget as dirty, the children can be considered to be changed after that call</summary>
    protected void Dirty() {
        Efl.Ui.Focus.CompositionConcrete.NativeMethods.efl_ui_focus_composition_dirty_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>A call to prepare the children of this element, called if marked as dirty
    /// You can use this function to call composition_elements.</summary>
    protected void Prepare() {
        Efl.Ui.Focus.CompositionConcrete.NativeMethods.efl_ui_focus_composition_prepare_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Set the order of elements that will be used for composition
    /// Elements of the list can be either an <see cref="Efl.Ui.Widget"/>, an <see cref="Efl.Ui.Focus.IObject"/> or an <see cref="Efl.Gfx.IEntity"/>.
    /// 
    /// If the element is an <see cref="Efl.Ui.Widget"/> nothing is done and the widget is simply part of the order.
    /// 
    /// If the element is an <see cref="Efl.Ui.Focus.IObject"/>, then the mixin will take care of registering the element.
    /// 
    /// If the element is an <see cref="Efl.Gfx.IEntity"/>, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.</summary>
    /// <value>The order to use</value>
    protected Eina.List<Efl.Gfx.IEntity> CompositionElements {
        get { return GetCompositionElements(); }
        set { SetCompositionElements(value); }
    }

    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <value><c>true</c> or <c>false</c></value>
    protected bool LogicalMode {
        get { return GetLogicalMode(); }
        set { SetLogicalMode(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.CompositionConcrete.efl_ui_focus_composition_mixin_get();
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
            return Efl.Ui.Focus.CompositionConcrete.efl_ui_focus_composition_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate System.IntPtr efl_ui_focus_composition_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_focus_composition_elements_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_get_api_delegate> efl_ui_focus_composition_elements_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_get_api_delegate>(Module, "efl_ui_focus_composition_elements_get");

        
        private delegate void efl_ui_focus_composition_elements_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr logical_order);

        
        public delegate void efl_ui_focus_composition_elements_set_api_delegate(System.IntPtr obj,  System.IntPtr logical_order);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_set_api_delegate> efl_ui_focus_composition_elements_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_set_api_delegate>(Module, "efl_ui_focus_composition_elements_set");

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_focus_composition_logical_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_focus_composition_logical_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_get_api_delegate> efl_ui_focus_composition_logical_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_get_api_delegate>(Module, "efl_ui_focus_composition_logical_mode_get");

        
        private delegate void efl_ui_focus_composition_logical_mode_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool logical_mode);

        
        public delegate void efl_ui_focus_composition_logical_mode_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool logical_mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_set_api_delegate> efl_ui_focus_composition_logical_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_set_api_delegate>(Module, "efl_ui_focus_composition_logical_mode_set");

        
        private delegate void efl_ui_focus_composition_dirty_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_composition_dirty_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_dirty_api_delegate> efl_ui_focus_composition_dirty_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_dirty_api_delegate>(Module, "efl_ui_focus_composition_dirty");

        
        private delegate void efl_ui_focus_composition_prepare_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_composition_prepare_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_prepare_api_delegate> efl_ui_focus_composition_prepare_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_prepare_api_delegate>(Module, "efl_ui_focus_composition_prepare");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Ui_FocusCompositionConcrete_ExtensionMethods {
    public static Efl.BindableProperty<Eina.List<Efl.Gfx.IEntity>> CompositionElements<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Focus.IComposition, T>magic = null) where T : Efl.Ui.Focus.IComposition {
        return new Efl.BindableProperty<Eina.List<Efl.Gfx.IEntity>>("composition_elements", fac);
    }

    public static Efl.BindableProperty<bool> LogicalMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Focus.IComposition, T>magic = null) where T : Efl.Ui.Focus.IComposition {
        return new Efl.BindableProperty<bool>("logical_mode", fac);
    }

}
#pragma warning restore CS1591
#endif
