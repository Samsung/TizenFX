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
namespace CoreUI.UI {
    /// <summary>A drop-shadow or glow effect around any widget.
    /// 
    /// A simple drop-shadow effect can be applied to any widget by setting the color and blur radius on this part.
    /// 
    /// For instance, a blue glow can be achieved with: obj.shadow().color_set(0, 128, 255, 255); obj.shadow().grow_set(2); obj.shadow().radius_set(3, 3);
    /// 
    /// As another example, here&apos;s a black drop-shadow: obj.shadow().color_set(0, 0, 0, 255); obj.shadow().grow_set(1); obj.shadow().radius_set(5, 5); obj.shadow().offset_set(5, 5);
    /// 
    /// It is also possible to manually specify which <span class="text-muted">CoreUI.Gfx.IFilter (object still in beta stage)</span> program to use.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.WidgetPartShadow.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class WidgetPartShadow : CoreUI.UI.WidgetPart, CoreUI.Gfx.IColor
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(WidgetPartShadow))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_widget_part_shadow_class_get();

        /// <summary>Initializes a new instance of the <see cref="WidgetPartShadow"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public WidgetPartShadow(CoreUI.Object parent= null) : base(efl_ui_widget_part_shadow_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected WidgetPartShadow(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WidgetPartShadow"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal WidgetPartShadow(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WidgetPartShadow"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected WidgetPartShadow(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>The general/main color of the given Evas object.
        /// 
        /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
        /// 
        /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
        /// 
        /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
        /// 
        /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetColor(out int r, out int g, out int b, out int a) {
            CoreUI.Gfx.IColorNativeMethods.efl_gfx_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out r, out g, out b, out a);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The general/main color of the given Evas object.
        /// 
        /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
        /// 
        /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
        /// 
        /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
        /// 
        /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetColor(int r, int g, int b, int a) {
            CoreUI.Gfx.IColorNativeMethods.efl_gfx_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), r, g, b, a);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
        /// <returns>the hex color code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetColorCode() {
            var _ret_var = CoreUI.Gfx.IColorNativeMethods.efl_gfx_color_code_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
        /// <param name="colorcode">the hex color code.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetColorCode(System.String colorcode) {
            CoreUI.Gfx.IColorNativeMethods.efl_gfx_color_code_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), colorcode);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The general/main color of the given Evas object.
        /// 
        /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
        /// 
        /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
        /// 
        /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
        /// 
        /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
        /// <since_tizen> 6 </since_tizen>
        public (int, int, int, int) Color {
            get {
                int _out_r = default(int);
                int _out_g = default(int);
                int _out_b = default(int);
                int _out_a = default(int);
                GetColor(out _out_r, out _out_g, out _out_b, out _out_a);
                return (_out_r, _out_g, _out_b, _out_a);
            }
            set { SetColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
        }

        /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
        /// <value>the hex color code.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String ColorCode {
            get { return GetColorCode(); }
            set { SetColorCode(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.WidgetPartShadow.efl_ui_widget_part_shadow_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.WidgetPart.NativeMethods
        {
            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
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
                return CoreUI.UI.WidgetPartShadow.efl_ui_widget_part_shadow_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class WidgetPartShadowExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> ColorCode<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.WidgetPartShadow, T>magic = null) where T : CoreUI.UI.WidgetPartShadow {
            return new CoreUI.BindableProperty<System.String>("color_code", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

