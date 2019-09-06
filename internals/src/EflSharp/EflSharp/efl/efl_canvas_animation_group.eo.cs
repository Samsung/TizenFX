#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Efl group animation abstract class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.AnimationGroup.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class AnimationGroup : Efl.Canvas.Animation
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(AnimationGroup))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_animation_group_class_get();
    /// <summary>Initializes a new instance of the <see cref="AnimationGroup"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public AnimationGroup(Efl.Object parent= null
            ) : base(efl_canvas_animation_group_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected AnimationGroup(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AnimationGroup"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected AnimationGroup(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class AnimationGroupRealized : AnimationGroup
    {
        private AnimationGroupRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="AnimationGroup"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected AnimationGroup(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Add the given animation to the animation group.</summary>
    /// <param name="animation">The animation which needs to be added to the animation group</param>
    virtual public void AddAnimation(Efl.Canvas.Animation animation) {
                                 Efl.Canvas.AnimationGroup.NativeMethods.efl_animation_group_animation_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),animation);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Delete the given animation from the animation group.</summary>
    /// <param name="animation">The animation which needs to be deleted from the animation group</param>
    virtual public void DelAnimation(Efl.Canvas.Animation animation) {
                                 Efl.Canvas.AnimationGroup.NativeMethods.efl_animation_group_animation_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),animation);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the animations of the animation group.</summary>
    /// <returns>The animations of the animation group</returns>
    virtual public Eina.List<Efl.Canvas.Animation> GetAnimations() {
         var _ret_var = Efl.Canvas.AnimationGroup.NativeMethods.efl_animation_group_animations_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Canvas.Animation>(_ret_var, false, false);
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.AnimationGroup.efl_canvas_animation_group_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Animation.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_animation_group_animation_add_static_delegate == null)
            {
                efl_animation_group_animation_add_static_delegate = new efl_animation_group_animation_add_delegate(animation_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddAnimation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_group_animation_add"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_group_animation_add_static_delegate) });
            }

            if (efl_animation_group_animation_del_static_delegate == null)
            {
                efl_animation_group_animation_del_static_delegate = new efl_animation_group_animation_del_delegate(animation_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelAnimation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_group_animation_del"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_group_animation_del_static_delegate) });
            }

            if (efl_animation_group_animations_get_static_delegate == null)
            {
                efl_animation_group_animations_get_static_delegate = new efl_animation_group_animations_get_delegate(animations_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAnimations") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_group_animations_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_group_animations_get_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.AnimationGroup.efl_canvas_animation_group_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_animation_group_animation_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Animation animation);

        
        public delegate void efl_animation_group_animation_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Animation animation);

        public static Efl.Eo.FunctionWrapper<efl_animation_group_animation_add_api_delegate> efl_animation_group_animation_add_ptr = new Efl.Eo.FunctionWrapper<efl_animation_group_animation_add_api_delegate>(Module, "efl_animation_group_animation_add");

        private static void animation_add(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Animation animation)
        {
            Eina.Log.Debug("function efl_animation_group_animation_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationGroup)ws.Target).AddAnimation(animation);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_animation_group_animation_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), animation);
            }
        }

        private static efl_animation_group_animation_add_delegate efl_animation_group_animation_add_static_delegate;

        
        private delegate void efl_animation_group_animation_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Animation animation);

        
        public delegate void efl_animation_group_animation_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Animation animation);

        public static Efl.Eo.FunctionWrapper<efl_animation_group_animation_del_api_delegate> efl_animation_group_animation_del_ptr = new Efl.Eo.FunctionWrapper<efl_animation_group_animation_del_api_delegate>(Module, "efl_animation_group_animation_del");

        private static void animation_del(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Animation animation)
        {
            Eina.Log.Debug("function efl_animation_group_animation_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationGroup)ws.Target).DelAnimation(animation);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_animation_group_animation_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), animation);
            }
        }

        private static efl_animation_group_animation_del_delegate efl_animation_group_animation_del_static_delegate;

        
        private delegate System.IntPtr efl_animation_group_animations_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_animation_group_animations_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_animation_group_animations_get_api_delegate> efl_animation_group_animations_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_group_animations_get_api_delegate>(Module, "efl_animation_group_animations_get");

        private static System.IntPtr animations_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_animation_group_animations_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.List<Efl.Canvas.Animation> _ret_var = default(Eina.List<Efl.Canvas.Animation>);
                try
                {
                    _ret_var = ((AnimationGroup)ws.Target).GetAnimations();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var.Handle;

            }
            else
            {
                return efl_animation_group_animations_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_animation_group_animations_get_delegate efl_animation_group_animations_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_CanvasAnimationGroup_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
