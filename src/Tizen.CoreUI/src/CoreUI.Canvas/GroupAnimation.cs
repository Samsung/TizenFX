/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI.Canvas {
    /// <summary>Base class for combined animations (groups of animations that are played together).
    /// 
    /// This class provides methods to add, remove and retrieve individual animations from the group.
    /// 
    /// See for example <see cref="CoreUI.Canvas.ParallelGroupAnimation"/> and <see cref="CoreUI.Canvas.SequentialGroupAnimation"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Canvas.GroupAnimation.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class GroupAnimation : CoreUI.Canvas.Animation
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(GroupAnimation))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
            efl_canvas_group_animation_class_get();

        /// <summary>Initializes a new instance of the <see cref="GroupAnimation"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public GroupAnimation(CoreUI.Object parent= null) : base(efl_canvas_group_animation_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected GroupAnimation(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="GroupAnimation"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal GroupAnimation(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class GroupAnimationRealized : GroupAnimation
        {
            private GroupAnimationRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="GroupAnimation"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected GroupAnimation(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>All animations that are currently part of this group.</summary>
        /// <returns>The iterator carrying all animations of this group</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual IEnumerable<CoreUI.Canvas.Animation> GetAnimations() {
            var _ret_var = CoreUI.Canvas.GroupAnimation.NativeMethods.efl_animation_group_animations_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Canvas.Animation>(_ret_var);
        }

        /// <summary>Adds the given animation to the animation group.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="animation">Animation to add to the group.</param>
        public virtual void AddAnimation(CoreUI.Canvas.Animation animation) {
            CoreUI.Canvas.GroupAnimation.NativeMethods.efl_animation_group_animation_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), animation);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Removes the given animation from the animation group.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="animation">Animation to remove from the group.</param>
        public virtual void DelAnimation(CoreUI.Canvas.Animation animation) {
            CoreUI.Canvas.GroupAnimation.NativeMethods.efl_animation_group_animation_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), animation);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>All animations that are currently part of this group.</summary>
        /// <value>The iterator carrying all animations of this group</value>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<CoreUI.Canvas.Animation> Animations {
            get { return GetAnimations(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Canvas.GroupAnimation.efl_canvas_group_animation_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Canvas.Animation.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Evas);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_animation_group_animations_get_static_delegate == null)
                {
                    efl_animation_group_animations_get_static_delegate = new efl_animation_group_animations_get_delegate(animations_get);
                }

                if (methods.Contains("GetAnimations"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_group_animations_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_group_animations_get_static_delegate) });
                }

                if (efl_animation_group_animation_add_static_delegate == null)
                {
                    efl_animation_group_animation_add_static_delegate = new efl_animation_group_animation_add_delegate(animation_add);
                }

                if (methods.Contains("AddAnimation"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_group_animation_add"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_group_animation_add_static_delegate) });
                }

                if (efl_animation_group_animation_del_static_delegate == null)
                {
                    efl_animation_group_animation_del_static_delegate = new efl_animation_group_animation_del_delegate(animation_del);
                }

                if (methods.Contains("DelAnimation"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_group_animation_del"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_group_animation_del_static_delegate) });
                }

                if (includeInherited)
                {
                    var all_interfaces = type.GetInterfaces();
                    foreach (var iface in all_interfaces)
                    {
                        var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                        if (moredescs != null)
                            descs.AddRange(moredescs);
                    }
                }
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.Canvas.GroupAnimation.efl_canvas_group_animation_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate System.IntPtr efl_animation_group_animations_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate System.IntPtr efl_animation_group_animations_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_group_animations_get_api_delegate> efl_animation_group_animations_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_group_animations_get_api_delegate>(Module, "efl_animation_group_animations_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.IntPtr animations_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_group_animations_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    IEnumerable<CoreUI.Canvas.Animation> _ret_var = null;
                    try
                    {
                        _ret_var = ((GroupAnimation)ws.Target).GetAnimations();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return CoreUI.Wrapper.Globals.IEnumerableToIterator(_ret_var, true);
                }
                else
                {
                    return efl_animation_group_animations_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_animation_group_animations_get_delegate efl_animation_group_animations_get_static_delegate;

            
            private delegate void efl_animation_group_animation_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Animation animation);

            
            internal delegate void efl_animation_group_animation_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Animation animation);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_group_animation_add_api_delegate> efl_animation_group_animation_add_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_group_animation_add_api_delegate>(Module, "efl_animation_group_animation_add");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void animation_add(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Animation animation)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_group_animation_add was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((GroupAnimation)ws.Target).AddAnimation(animation);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_animation_group_animation_add_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), animation);
                }
            }

            private static efl_animation_group_animation_add_delegate efl_animation_group_animation_add_static_delegate;

            
            private delegate void efl_animation_group_animation_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Animation animation);

            
            internal delegate void efl_animation_group_animation_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Animation animation);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_group_animation_del_api_delegate> efl_animation_group_animation_del_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_group_animation_del_api_delegate>(Module, "efl_animation_group_animation_del");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void animation_del(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Animation animation)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_group_animation_del was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((GroupAnimation)ws.Target).DelAnimation(animation);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_animation_group_animation_del_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), animation);
                }
            }

            private static efl_animation_group_animation_del_delegate efl_animation_group_animation_del_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

