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

/// <summary>Navigation_Bar widget.
/// Navigation_Bar widget provides a bar form useful for navigation. Navigation_Bar has a back button which is used to navigate to the previous content in the stack.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.NavigationBar.NativeMethods]
[Efl.Eo.BindingEntity]
public class NavigationBar : Efl.Ui.LayoutBase, Efl.IText
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(NavigationBar))
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
        efl_ui_navigation_bar_class_get();
    /// <summary>Initializes a new instance of the <see cref="NavigationBar"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public NavigationBar(Efl.Object parent
            , System.String style = null) : base(efl_ui_navigation_bar_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected NavigationBar(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="NavigationBar"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected NavigationBar(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="NavigationBar"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected NavigationBar(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Back button to navigate to the previous content in the stack.
    /// The back button works only if the Navigation_Bar widget is contained in the Stack widget(Efl.Ui.Stack class). e.g. The Navigation_Bar widget is set in the Navigation_Layout widget and the Navigation_Layout widget is pushed to the Stack widget.
    /// 
    /// The back button is hidden by default and it can be visible. e.g. efl_gfx_entity_visible_set(efl_part(navigation_bar, &quot;back_button&quot;), EINA_TRUE);</summary>
    public Efl.Ui.NavigationBarPartBackButton BackButtonPart
    {
        get
        {
            return GetPart("back_button") as Efl.Ui.NavigationBarPartBackButton;
        }
    }
    /// <summary>The text string to be displayed by the given text object.
    /// Do not release (free) the returned value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Text string to display on it.</returns>
    public virtual System.String GetText() {
         var _ret_var = Efl.TextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The text string to be displayed by the given text object.
    /// Do not release (free) the returned value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="text">Text string to display on it.</param>
    public virtual void SetText(System.String text) {
                                 Efl.TextConcrete.NativeMethods.efl_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),text);
        Eina.Error.RaiseIfUnhandledException();
                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.NavigationBar.efl_ui_navigation_bar_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.NavigationBar.efl_ui_navigation_bar_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiNavigationBar_ExtensionMethods {
    
        public static Efl.BindableFactoryPart<Efl.Ui.NavigationBarPartBackButton> BackButtonPart<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.NavigationBar, T> x=null) where T : Efl.Ui.NavigationBar
    {
        return new Efl.BindableFactoryPart<Efl.Ui.NavigationBarPartBackButton>("back_button" ,fac);
    }

}
#pragma warning restore CS1591
#endif
