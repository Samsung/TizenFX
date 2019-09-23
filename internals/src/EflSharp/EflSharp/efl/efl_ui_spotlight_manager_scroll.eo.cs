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

namespace Spotlight {

/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Spotlight.ManagerScroll.NativeMethods]
[Efl.Eo.BindingEntity]
public class ManagerScroll : Efl.Ui.Spotlight.Manager
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ManagerScroll))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_spotlight_manager_scroll_class_get();
    /// <summary>Initializes a new instance of the <see cref="ManagerScroll"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public ManagerScroll(Efl.Object parent= null
            ) : base(efl_ui_spotlight_manager_scroll_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected ManagerScroll(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ManagerScroll"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected ManagerScroll(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ManagerScroll"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ManagerScroll(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Blocking of scrolling
    /// This function will block scrolling movement (by input of a user). You can disable scrolling movement. The default value is <c>false</c>, where the scrolling movement is allowed.</summary>
    /// <returns><c>true</c> if block scrolling movement, <c>false</c> otherwise</returns>
    public virtual bool GetScrollBlock() {
         var _ret_var = Efl.Ui.Spotlight.ManagerScroll.NativeMethods.efl_ui_spotlight_manager_scroll_block_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Blocking of scrolling
    /// This function will block scrolling movement (by input of a user). You can disable scrolling movement. The default value is <c>false</c>, where the scrolling movement is allowed.</summary>
    /// <param name="scroll_block"><c>true</c> if block scrolling movement, <c>false</c> otherwise</param>
    public virtual void SetScrollBlock(bool scroll_block) {
                                 Efl.Ui.Spotlight.ManagerScroll.NativeMethods.efl_ui_spotlight_manager_scroll_block_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scroll_block);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Blocking of scrolling
    /// This function will block scrolling movement (by input of a user). You can disable scrolling movement. The default value is <c>false</c>, where the scrolling movement is allowed.</summary>
    /// <value><c>true</c> if block scrolling movement, <c>false</c> otherwise</value>
    public bool ScrollBlock {
        get { return GetScrollBlock(); }
        set { SetScrollBlock(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Spotlight.ManagerScroll.efl_ui_spotlight_manager_scroll_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Spotlight.Manager.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_spotlight_manager_scroll_block_get_static_delegate == null)
            {
                efl_ui_spotlight_manager_scroll_block_get_static_delegate = new efl_ui_spotlight_manager_scroll_block_get_delegate(scroll_block_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScrollBlock") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_manager_scroll_block_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_manager_scroll_block_get_static_delegate) });
            }

            if (efl_ui_spotlight_manager_scroll_block_set_static_delegate == null)
            {
                efl_ui_spotlight_manager_scroll_block_set_static_delegate = new efl_ui_spotlight_manager_scroll_block_set_delegate(scroll_block_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScrollBlock") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_manager_scroll_block_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_manager_scroll_block_set_static_delegate) });
            }

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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Spotlight.ManagerScroll.efl_ui_spotlight_manager_scroll_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_spotlight_manager_scroll_block_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_spotlight_manager_scroll_block_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_scroll_block_get_api_delegate> efl_ui_spotlight_manager_scroll_block_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_scroll_block_get_api_delegate>(Module, "efl_ui_spotlight_manager_scroll_block_get");

        private static bool scroll_block_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_spotlight_manager_scroll_block_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ManagerScroll)ws.Target).GetScrollBlock();
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
                return efl_ui_spotlight_manager_scroll_block_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_spotlight_manager_scroll_block_get_delegate efl_ui_spotlight_manager_scroll_block_get_static_delegate;

        
        private delegate void efl_ui_spotlight_manager_scroll_block_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool scroll_block);

        
        public delegate void efl_ui_spotlight_manager_scroll_block_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool scroll_block);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_scroll_block_set_api_delegate> efl_ui_spotlight_manager_scroll_block_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_scroll_block_set_api_delegate>(Module, "efl_ui_spotlight_manager_scroll_block_set");

        private static void scroll_block_set(System.IntPtr obj, System.IntPtr pd, bool scroll_block)
        {
            Eina.Log.Debug("function efl_ui_spotlight_manager_scroll_block_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ManagerScroll)ws.Target).SetScrollBlock(scroll_block);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_spotlight_manager_scroll_block_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), scroll_block);
            }
        }

        private static efl_ui_spotlight_manager_scroll_block_set_delegate efl_ui_spotlight_manager_scroll_block_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Ui_SpotlightManagerScroll_ExtensionMethods {
    public static Efl.BindableProperty<bool> ScrollBlock<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Spotlight.ManagerScroll, T>magic = null) where T : Efl.Ui.Spotlight.ManagerScroll {
        return new Efl.BindableProperty<bool>("scroll_block", fac);
    }

}
#pragma warning restore CS1591
#endif
