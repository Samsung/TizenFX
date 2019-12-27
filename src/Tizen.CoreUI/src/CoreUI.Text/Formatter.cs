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
namespace CoreUI.Text {
    /// <summary>Text Formatter API to manage text formatting(attributes). Use it to insert and remove style attributes (font, size, color, ...) using <see cref="CoreUI.Text.Cursor"/> on EFL Widgets.
    /// 
    /// Attributes can be assigned to character ranges, selected using two <see cref="CoreUI.Text.Cursor"/> instances. Cursor instances are already bound to a text object so there&apos;s no need to provide it to this class. Style is specified using format strings as described in <see cref="CoreUI.Canvas.TextBlock.ApplyStyle"/>.
    /// 
    /// There is no need to instantiate this class. Use directly the <see cref="CoreUI.Text.Formatter.InsertAttribute"/> and <see cref="CoreUI.Text.Formatter.ClearAttribute"/> static methods.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Text.Formatter.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class Formatter : CoreUI.Object
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Formatter))
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
            efl_text_formatter_class_get();

        /// <summary>Initializes a new instance of the <see cref="Formatter"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public Formatter(CoreUI.Object parent= null) : base(efl_text_formatter_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Formatter(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Formatter"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Formatter(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class FormatterRealized : Formatter
        {
            private FormatterRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="Formatter"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Formatter(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Inserts an attribute format in a specified range [<c>start</c>, <c>end</c> - 1].
        /// 
        /// The <c>format</c> will be applied to the given range. The passed cursors must belong to same text object, otherwise insertion will be ignored.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="start">Start of range.</param>
        /// <param name="end">End of range.</param>
        /// <param name="format">Format string. Uses same format as <c>style</c> in <see cref="CoreUI.Canvas.TextBlock.ApplyStyle"/>.</param>
        public static void InsertAttribute(CoreUI.Text.Cursor start, CoreUI.Text.Cursor end, System.String format) {
            CoreUI.Text.Formatter.NativeMethods.efl_text_formatter_attribute_insert_ptr.Value.Delegate(start, end, format);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Clear (remove) attributes in the specified range [<c>start</c>, <c>end</c> - 1].</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="start">Start of range.</param>
        /// <param name="end">End of range.</param>
        /// <returns>Number of removed attributes.</returns>
        public static uint ClearAttribute(CoreUI.Text.Cursor start, CoreUI.Text.Cursor end) {
            var _ret_var = CoreUI.Text.Formatter.NativeMethods.efl_text_formatter_attribute_clear_ptr.Value.Delegate(start, end);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Text.Formatter.efl_text_formatter_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Object.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Evas);

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
                return CoreUI.Text.Formatter.efl_text_formatter_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate void efl_text_formatter_attribute_insert_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor start, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor end, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String format);

            
            internal delegate void efl_text_formatter_attribute_insert_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor start, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor end, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String format);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_formatter_attribute_insert_api_delegate> efl_text_formatter_attribute_insert_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_formatter_attribute_insert_api_delegate>(Module, "efl_text_formatter_attribute_insert");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void attribute_insert(System.IntPtr obj, System.IntPtr pd, CoreUI.Text.Cursor start, CoreUI.Text.Cursor end, System.String format)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_formatter_attribute_insert was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        Formatter.InsertAttribute(start, end, format);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_text_formatter_attribute_insert_ptr.Value.Delegate(start, end, format);
                }
            }

            
            private delegate uint efl_text_formatter_attribute_clear_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor start, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor end);

            
            internal delegate uint efl_text_formatter_attribute_clear_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor start, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Text.Cursor end);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_formatter_attribute_clear_api_delegate> efl_text_formatter_attribute_clear_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_formatter_attribute_clear_api_delegate>(Module, "efl_text_formatter_attribute_clear");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static uint attribute_clear(System.IntPtr obj, System.IntPtr pd, CoreUI.Text.Cursor start, CoreUI.Text.Cursor end)
            {
                CoreUI.DataTypes.Log.Debug("function efl_text_formatter_attribute_clear was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    uint _ret_var = default(uint);
                    try
                    {
                        _ret_var = Formatter.ClearAttribute(start, end);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_text_formatter_attribute_clear_ptr.Value.Delegate(start, end);
                }
            }

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

