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
namespace CoreUI {
    /// <summary>Properties related to font handling.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.ITextFontPropertiesNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface ITextFontProperties : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The font family, filename for a given text object.
        /// 
        /// This property controls the font name of a text object. The font string has to follow fontconfig&apos;s convention for naming fonts, as it&apos;s the underlying library used to query system fonts by EFL (see the <c>fc-list</c> command&apos;s output, on your system, to get an idea). Alternatively, you can use the full path to a font file.
        /// 
        /// When reading it, the font name string is still owned by EFL and should not be freed. See also <see cref="CoreUI.ITextFontProperties.FontSource"/>.</summary>
        /// <returns>The font family name or filename.</returns>
        /// <since_tizen> 6 </since_tizen>
        System.String GetFontFamily();

        /// <summary>The font family, filename for a given text object.
        /// 
        /// This property controls the font name of a text object. The font string has to follow fontconfig&apos;s convention for naming fonts, as it&apos;s the underlying library used to query system fonts by EFL (see the <c>fc-list</c> command&apos;s output, on your system, to get an idea). Alternatively, you can use the full path to a font file.
        /// 
        /// When reading it, the font name string is still owned by EFL and should not be freed. See also <see cref="CoreUI.ITextFontProperties.FontSource"/>.</summary>
        /// <param name="font">The font family name or filename.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetFontFamily(System.String font);

        /// <summary>The font size to use, in points.
        /// 
        /// If the specified <see cref="CoreUI.ITextFontProperties.FontFamily"/> does not provide this particular size, it will be scaled.</summary>
        /// <returns>The font size, in points.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Font.Size GetFontSize();

        /// <summary>The font size to use, in points.
        /// 
        /// If the specified <see cref="CoreUI.ITextFontProperties.FontFamily"/> does not provide this particular size, it will be scaled.</summary>
        /// <param name="size">The font size, in points.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetFontSize(CoreUI.Font.Size size);

        /// <summary>The font (source) file to be used on a given text object.
        /// 
        /// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
        /// 
        /// See also <see cref="CoreUI.ITextFontProperties.FontFamily"/>.</summary>
        /// <returns>The font file&apos;s path.</returns>
        /// <since_tizen> 6 </since_tizen>
        System.String GetFontSource();

        /// <summary>The font (source) file to be used on a given text object.
        /// 
        /// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
        /// 
        /// See also <see cref="CoreUI.ITextFontProperties.FontFamily"/>.</summary>
        /// <param name="font_source">The font file&apos;s path.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetFontSource(System.String font_source);

        /// <summary>Comma-separated list of font fallbacks.
        /// 
        /// Will be used in case the primary font isn&apos;t available.</summary>
        /// <returns>List of fallback font names.</returns>
        /// <since_tizen> 6 </since_tizen>
        System.String GetFontFallbacks();

        /// <summary>Comma-separated list of font fallbacks.
        /// 
        /// Will be used in case the primary font isn&apos;t available.</summary>
        /// <param name="font_fallbacks">List of fallback font names.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetFontFallbacks(System.String font_fallbacks);

        /// <summary>Type of weight (e.g. bold or normal) of the displayed font
        /// 
        /// Default is <see cref="CoreUI.TextFontWeight.Normal"/>.</summary>
        /// <returns>Font weight.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextFontWeight GetFontWeight();

        /// <summary>Type of weight (e.g. bold or normal) of the displayed font
        /// 
        /// Default is <see cref="CoreUI.TextFontWeight.Normal"/>.</summary>
        /// <param name="font_weight">Font weight.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetFontWeight(CoreUI.TextFontWeight font_weight);

        /// <summary>Type of slant (e.g. italic or normal) of the displayed font.
        /// 
        /// Default is <see cref="CoreUI.TextFontSlant.Normal"/>.</summary>
        /// <returns>Font slant.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextFontSlant GetFontSlant();

        /// <summary>Type of slant (e.g. italic or normal) of the displayed font.
        /// 
        /// Default is <see cref="CoreUI.TextFontSlant.Normal"/>.</summary>
        /// <param name="style">Font slant.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetFontSlant(CoreUI.TextFontSlant style);

        /// <summary>Type of width (e.g. condensed, expanded or normal) of the displayed font.
        /// 
        /// Default is <see cref="CoreUI.TextFontWidth.Normal"/>.</summary>
        /// <returns>Font width.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextFontWidth GetFontWidth();

        /// <summary>Type of width (e.g. condensed, expanded or normal) of the displayed font.
        /// 
        /// Default is <see cref="CoreUI.TextFontWidth.Normal"/>.</summary>
        /// <param name="width">Font width.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetFontWidth(CoreUI.TextFontWidth width);

        /// <summary>Specific language of the displayed font
        /// 
        /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.</summary>
        /// <returns>Language code.</returns>
        /// <since_tizen> 6 </since_tizen>
        System.String GetFontLang();

        /// <summary>Specific language of the displayed font
        /// 
        /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.</summary>
        /// <param name="lang">Language code.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetFontLang(System.String lang);

        /// <summary>Bitmap fonts have fixed size glyphs for several available sizes. Other sizes need to be algorithmically scaled, resulting in blurry glyphs. This property controls whether scaling of non-provided sizes is allowed.
        /// 
        /// Default is <see cref="CoreUI.TextFontBitmapScalable.None"/>.</summary>
        /// <returns>When should bitmap fonts be scaled.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextFontBitmapScalable GetFontBitmapScalable();

        /// <summary>Bitmap fonts have fixed size glyphs for several available sizes. Other sizes need to be algorithmically scaled, resulting in blurry glyphs. This property controls whether scaling of non-provided sizes is allowed.
        /// 
        /// Default is <see cref="CoreUI.TextFontBitmapScalable.None"/>.</summary>
        /// <param name="scalable">When should bitmap fonts be scaled.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetFontBitmapScalable(CoreUI.TextFontBitmapScalable scalable);

        /// <summary>The font family, filename for a given text object.
        /// 
        /// This property controls the font name of a text object. The font string has to follow fontconfig&apos;s convention for naming fonts, as it&apos;s the underlying library used to query system fonts by EFL (see the <c>fc-list</c> command&apos;s output, on your system, to get an idea). Alternatively, you can use the full path to a font file.
        /// 
        /// When reading it, the font name string is still owned by EFL and should not be freed. See also <see cref="CoreUI.ITextFontProperties.FontSource"/>.</summary>
        /// <value>The font family name or filename.</value>
        /// <since_tizen> 6 </since_tizen>
        System.String FontFamily {
            get;
            set;
        }

        /// <summary>The font size to use, in points.
        /// 
        /// If the specified <see cref="CoreUI.ITextFontProperties.FontFamily"/> does not provide this particular size, it will be scaled.</summary>
        /// <value>The font size, in points.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Font.Size FontSize {
            get;
            set;
        }

        /// <summary>The font (source) file to be used on a given text object.
        /// 
        /// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
        /// 
        /// See also <see cref="CoreUI.ITextFontProperties.FontFamily"/>.</summary>
        /// <value>The font file&apos;s path.</value>
        /// <since_tizen> 6 </since_tizen>
        System.String FontSource {
            get;
            set;
        }

        /// <summary>Comma-separated list of font fallbacks.
        /// 
        /// Will be used in case the primary font isn&apos;t available.</summary>
        /// <value>List of fallback font names.</value>
        /// <since_tizen> 6 </since_tizen>
        System.String FontFallbacks {
            get;
            set;
        }

        /// <summary>Type of weight (e.g. bold or normal) of the displayed font
        /// 
        /// Default is <see cref="CoreUI.TextFontWeight.Normal"/>.</summary>
        /// <value>Font weight.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextFontWeight FontWeight {
            get;
            set;
        }

        /// <summary>Type of slant (e.g. italic or normal) of the displayed font.
        /// 
        /// Default is <see cref="CoreUI.TextFontSlant.Normal"/>.</summary>
        /// <value>Font slant.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextFontSlant FontSlant {
            get;
            set;
        }

        /// <summary>Type of width (e.g. condensed, expanded or normal) of the displayed font.
        /// 
        /// Default is <see cref="CoreUI.TextFontWidth.Normal"/>.</summary>
        /// <value>Font width.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextFontWidth FontWidth {
            get;
            set;
        }

        /// <summary>Specific language of the displayed font
        /// 
        /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.</summary>
        /// <value>Language code.</value>
        /// <since_tizen> 6 </since_tizen>
        System.String FontLang {
            get;
            set;
        }

        /// <summary>Bitmap fonts have fixed size glyphs for several available sizes. Other sizes need to be algorithmically scaled, resulting in blurry glyphs. This property controls whether scaling of non-provided sizes is allowed.
        /// 
        /// Default is <see cref="CoreUI.TextFontBitmapScalable.None"/>.</summary>
        /// <value>When should bitmap fonts be scaled.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextFontBitmapScalable FontBitmapScalable {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ITextFontPropertiesNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_text_font_properties_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_text_font_family_get_static_delegate == null)
            {
                efl_text_font_family_get_static_delegate = new efl_text_font_family_get_delegate(font_family_get);
            }

            if (methods.Contains("GetFontFamily"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_family_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_family_get_static_delegate) });
            }

            if (efl_text_font_family_set_static_delegate == null)
            {
                efl_text_font_family_set_static_delegate = new efl_text_font_family_set_delegate(font_family_set);
            }

            if (methods.Contains("SetFontFamily"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_family_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_family_set_static_delegate) });
            }

            if (efl_text_font_size_get_static_delegate == null)
            {
                efl_text_font_size_get_static_delegate = new efl_text_font_size_get_delegate(font_size_get);
            }

            if (methods.Contains("GetFontSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_size_get_static_delegate) });
            }

            if (efl_text_font_size_set_static_delegate == null)
            {
                efl_text_font_size_set_static_delegate = new efl_text_font_size_set_delegate(font_size_set);
            }

            if (methods.Contains("SetFontSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_size_set_static_delegate) });
            }

            if (efl_text_font_source_get_static_delegate == null)
            {
                efl_text_font_source_get_static_delegate = new efl_text_font_source_get_delegate(font_source_get);
            }

            if (methods.Contains("GetFontSource"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_get_static_delegate) });
            }

            if (efl_text_font_source_set_static_delegate == null)
            {
                efl_text_font_source_set_static_delegate = new efl_text_font_source_set_delegate(font_source_set);
            }

            if (methods.Contains("SetFontSource"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_set_static_delegate) });
            }

            if (efl_text_font_fallbacks_get_static_delegate == null)
            {
                efl_text_font_fallbacks_get_static_delegate = new efl_text_font_fallbacks_get_delegate(font_fallbacks_get);
            }

            if (methods.Contains("GetFontFallbacks"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_fallbacks_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_get_static_delegate) });
            }

            if (efl_text_font_fallbacks_set_static_delegate == null)
            {
                efl_text_font_fallbacks_set_static_delegate = new efl_text_font_fallbacks_set_delegate(font_fallbacks_set);
            }

            if (methods.Contains("SetFontFallbacks"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_fallbacks_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_set_static_delegate) });
            }

            if (efl_text_font_weight_get_static_delegate == null)
            {
                efl_text_font_weight_get_static_delegate = new efl_text_font_weight_get_delegate(font_weight_get);
            }

            if (methods.Contains("GetFontWeight"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_weight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_get_static_delegate) });
            }

            if (efl_text_font_weight_set_static_delegate == null)
            {
                efl_text_font_weight_set_static_delegate = new efl_text_font_weight_set_delegate(font_weight_set);
            }

            if (methods.Contains("SetFontWeight"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_weight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_set_static_delegate) });
            }

            if (efl_text_font_slant_get_static_delegate == null)
            {
                efl_text_font_slant_get_static_delegate = new efl_text_font_slant_get_delegate(font_slant_get);
            }

            if (methods.Contains("GetFontSlant"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_slant_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_get_static_delegate) });
            }

            if (efl_text_font_slant_set_static_delegate == null)
            {
                efl_text_font_slant_set_static_delegate = new efl_text_font_slant_set_delegate(font_slant_set);
            }

            if (methods.Contains("SetFontSlant"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_slant_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_set_static_delegate) });
            }

            if (efl_text_font_width_get_static_delegate == null)
            {
                efl_text_font_width_get_static_delegate = new efl_text_font_width_get_delegate(font_width_get);
            }

            if (methods.Contains("GetFontWidth"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_get_static_delegate) });
            }

            if (efl_text_font_width_set_static_delegate == null)
            {
                efl_text_font_width_set_static_delegate = new efl_text_font_width_set_delegate(font_width_set);
            }

            if (methods.Contains("SetFontWidth"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_set_static_delegate) });
            }

            if (efl_text_font_lang_get_static_delegate == null)
            {
                efl_text_font_lang_get_static_delegate = new efl_text_font_lang_get_delegate(font_lang_get);
            }

            if (methods.Contains("GetFontLang"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_lang_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_get_static_delegate) });
            }

            if (efl_text_font_lang_set_static_delegate == null)
            {
                efl_text_font_lang_set_static_delegate = new efl_text_font_lang_set_delegate(font_lang_set);
            }

            if (methods.Contains("SetFontLang"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_lang_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_set_static_delegate) });
            }

            if (efl_text_font_bitmap_scalable_get_static_delegate == null)
            {
                efl_text_font_bitmap_scalable_get_static_delegate = new efl_text_font_bitmap_scalable_get_delegate(font_bitmap_scalable_get);
            }

            if (methods.Contains("GetFontBitmapScalable"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_bitmap_scalable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_get_static_delegate) });
            }

            if (efl_text_font_bitmap_scalable_set_static_delegate == null)
            {
                efl_text_font_bitmap_scalable_set_static_delegate = new efl_text_font_bitmap_scalable_set_delegate(font_bitmap_scalable_set);
            }

            if (methods.Contains("SetFontBitmapScalable"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_bitmap_scalable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_set_static_delegate) });
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
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_text_font_properties_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_font_family_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        internal delegate System.String efl_text_font_family_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_family_get_api_delegate> efl_text_font_family_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_family_get_api_delegate>(Module, "efl_text_font_family_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.String font_family_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_family_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((ITextFontProperties)ws.Target).GetFontFamily();
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
                return efl_text_font_family_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_font_family_get_delegate efl_text_font_family_get_static_delegate;

        
        private delegate void efl_text_font_family_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String font);

        
        internal delegate void efl_text_font_family_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String font);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_family_set_api_delegate> efl_text_font_family_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_family_set_api_delegate>(Module, "efl_text_font_family_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void font_family_set(System.IntPtr obj, System.IntPtr pd, System.String font)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_family_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFontProperties)ws.Target).SetFontFamily(font);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_font_family_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), font);
            }
        }

        private static efl_text_font_family_set_delegate efl_text_font_family_set_static_delegate;

        
        private delegate CoreUI.Font.Size efl_text_font_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.Font.Size efl_text_font_size_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_size_get_api_delegate> efl_text_font_size_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_size_get_api_delegate>(Module, "efl_text_font_size_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Font.Size font_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_size_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Font.Size _ret_var = default(CoreUI.Font.Size);
                try
                {
                    _ret_var = ((ITextFontProperties)ws.Target).GetFontSize();
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
                return efl_text_font_size_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_font_size_get_delegate efl_text_font_size_get_static_delegate;

        
        private delegate void efl_text_font_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Font.Size size);

        
        internal delegate void efl_text_font_size_set_api_delegate(System.IntPtr obj,  CoreUI.Font.Size size);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_size_set_api_delegate> efl_text_font_size_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_size_set_api_delegate>(Module, "efl_text_font_size_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void font_size_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Font.Size size)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_size_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFontProperties)ws.Target).SetFontSize(size);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_font_size_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), size);
            }
        }

        private static efl_text_font_size_set_delegate efl_text_font_size_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_font_source_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        internal delegate System.String efl_text_font_source_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_source_get_api_delegate> efl_text_font_source_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_source_get_api_delegate>(Module, "efl_text_font_source_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.String font_source_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_source_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((ITextFontProperties)ws.Target).GetFontSource();
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
                return efl_text_font_source_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_font_source_get_delegate efl_text_font_source_get_static_delegate;

        
        private delegate void efl_text_font_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String font_source);

        
        internal delegate void efl_text_font_source_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String font_source);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_source_set_api_delegate> efl_text_font_source_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_source_set_api_delegate>(Module, "efl_text_font_source_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void font_source_set(System.IntPtr obj, System.IntPtr pd, System.String font_source)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_source_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFontProperties)ws.Target).SetFontSource(font_source);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_font_source_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), font_source);
            }
        }

        private static efl_text_font_source_set_delegate efl_text_font_source_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_font_fallbacks_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        internal delegate System.String efl_text_font_fallbacks_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_fallbacks_get_api_delegate> efl_text_font_fallbacks_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_fallbacks_get_api_delegate>(Module, "efl_text_font_fallbacks_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.String font_fallbacks_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_fallbacks_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((ITextFontProperties)ws.Target).GetFontFallbacks();
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
                return efl_text_font_fallbacks_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_font_fallbacks_get_delegate efl_text_font_fallbacks_get_static_delegate;

        
        private delegate void efl_text_font_fallbacks_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String font_fallbacks);

        
        internal delegate void efl_text_font_fallbacks_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String font_fallbacks);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_fallbacks_set_api_delegate> efl_text_font_fallbacks_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_fallbacks_set_api_delegate>(Module, "efl_text_font_fallbacks_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void font_fallbacks_set(System.IntPtr obj, System.IntPtr pd, System.String font_fallbacks)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_fallbacks_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFontProperties)ws.Target).SetFontFallbacks(font_fallbacks);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_font_fallbacks_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), font_fallbacks);
            }
        }

        private static efl_text_font_fallbacks_set_delegate efl_text_font_fallbacks_set_static_delegate;

        
        private delegate CoreUI.TextFontWeight efl_text_font_weight_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.TextFontWeight efl_text_font_weight_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_weight_get_api_delegate> efl_text_font_weight_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_weight_get_api_delegate>(Module, "efl_text_font_weight_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.TextFontWeight font_weight_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_weight_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.TextFontWeight _ret_var = default(CoreUI.TextFontWeight);
                try
                {
                    _ret_var = ((ITextFontProperties)ws.Target).GetFontWeight();
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
                return efl_text_font_weight_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_font_weight_get_delegate efl_text_font_weight_get_static_delegate;

        
        private delegate void efl_text_font_weight_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TextFontWeight font_weight);

        
        internal delegate void efl_text_font_weight_set_api_delegate(System.IntPtr obj,  CoreUI.TextFontWeight font_weight);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_weight_set_api_delegate> efl_text_font_weight_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_weight_set_api_delegate>(Module, "efl_text_font_weight_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void font_weight_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TextFontWeight font_weight)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_weight_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFontProperties)ws.Target).SetFontWeight(font_weight);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_font_weight_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), font_weight);
            }
        }

        private static efl_text_font_weight_set_delegate efl_text_font_weight_set_static_delegate;

        
        private delegate CoreUI.TextFontSlant efl_text_font_slant_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.TextFontSlant efl_text_font_slant_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_slant_get_api_delegate> efl_text_font_slant_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_slant_get_api_delegate>(Module, "efl_text_font_slant_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.TextFontSlant font_slant_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_slant_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.TextFontSlant _ret_var = default(CoreUI.TextFontSlant);
                try
                {
                    _ret_var = ((ITextFontProperties)ws.Target).GetFontSlant();
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
                return efl_text_font_slant_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_font_slant_get_delegate efl_text_font_slant_get_static_delegate;

        
        private delegate void efl_text_font_slant_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TextFontSlant style);

        
        internal delegate void efl_text_font_slant_set_api_delegate(System.IntPtr obj,  CoreUI.TextFontSlant style);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_slant_set_api_delegate> efl_text_font_slant_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_slant_set_api_delegate>(Module, "efl_text_font_slant_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void font_slant_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TextFontSlant style)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_slant_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFontProperties)ws.Target).SetFontSlant(style);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_font_slant_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), style);
            }
        }

        private static efl_text_font_slant_set_delegate efl_text_font_slant_set_static_delegate;

        
        private delegate CoreUI.TextFontWidth efl_text_font_width_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.TextFontWidth efl_text_font_width_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_width_get_api_delegate> efl_text_font_width_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_width_get_api_delegate>(Module, "efl_text_font_width_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.TextFontWidth font_width_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_width_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.TextFontWidth _ret_var = default(CoreUI.TextFontWidth);
                try
                {
                    _ret_var = ((ITextFontProperties)ws.Target).GetFontWidth();
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
                return efl_text_font_width_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_font_width_get_delegate efl_text_font_width_get_static_delegate;

        
        private delegate void efl_text_font_width_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TextFontWidth width);

        
        internal delegate void efl_text_font_width_set_api_delegate(System.IntPtr obj,  CoreUI.TextFontWidth width);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_width_set_api_delegate> efl_text_font_width_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_width_set_api_delegate>(Module, "efl_text_font_width_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void font_width_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TextFontWidth width)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_width_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFontProperties)ws.Target).SetFontWidth(width);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_font_width_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), width);
            }
        }

        private static efl_text_font_width_set_delegate efl_text_font_width_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_font_lang_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        internal delegate System.String efl_text_font_lang_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_lang_get_api_delegate> efl_text_font_lang_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_lang_get_api_delegate>(Module, "efl_text_font_lang_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.String font_lang_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_lang_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((ITextFontProperties)ws.Target).GetFontLang();
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
                return efl_text_font_lang_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_font_lang_get_delegate efl_text_font_lang_get_static_delegate;

        
        private delegate void efl_text_font_lang_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String lang);

        
        internal delegate void efl_text_font_lang_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String lang);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_lang_set_api_delegate> efl_text_font_lang_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_lang_set_api_delegate>(Module, "efl_text_font_lang_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void font_lang_set(System.IntPtr obj, System.IntPtr pd, System.String lang)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_lang_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFontProperties)ws.Target).SetFontLang(lang);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_font_lang_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), lang);
            }
        }

        private static efl_text_font_lang_set_delegate efl_text_font_lang_set_static_delegate;

        
        private delegate CoreUI.TextFontBitmapScalable efl_text_font_bitmap_scalable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.TextFontBitmapScalable efl_text_font_bitmap_scalable_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_bitmap_scalable_get_api_delegate> efl_text_font_bitmap_scalable_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_bitmap_scalable_get_api_delegate>(Module, "efl_text_font_bitmap_scalable_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.TextFontBitmapScalable font_bitmap_scalable_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_bitmap_scalable_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.TextFontBitmapScalable _ret_var = default(CoreUI.TextFontBitmapScalable);
                try
                {
                    _ret_var = ((ITextFontProperties)ws.Target).GetFontBitmapScalable();
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
                return efl_text_font_bitmap_scalable_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_font_bitmap_scalable_get_delegate efl_text_font_bitmap_scalable_get_static_delegate;

        
        private delegate void efl_text_font_bitmap_scalable_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TextFontBitmapScalable scalable);

        
        internal delegate void efl_text_font_bitmap_scalable_set_api_delegate(System.IntPtr obj,  CoreUI.TextFontBitmapScalable scalable);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_font_bitmap_scalable_set_api_delegate> efl_text_font_bitmap_scalable_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_font_bitmap_scalable_set_api_delegate>(Module, "efl_text_font_bitmap_scalable_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void font_bitmap_scalable_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TextFontBitmapScalable scalable)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_font_bitmap_scalable_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFontProperties)ws.Target).SetFontBitmapScalable(scalable);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_font_bitmap_scalable_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), scalable);
            }
        }

        private static efl_text_font_bitmap_scalable_set_delegate efl_text_font_bitmap_scalable_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class TextFontPropertiesExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> FontFamily<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFontProperties, T>magic = null) where T : CoreUI.ITextFontProperties {
            return new CoreUI.BindableProperty<System.String>("font_family", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Font.Size> FontSize<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFontProperties, T>magic = null) where T : CoreUI.ITextFontProperties {
            return new CoreUI.BindableProperty<CoreUI.Font.Size>("font_size", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> FontSource<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFontProperties, T>magic = null) where T : CoreUI.ITextFontProperties {
            return new CoreUI.BindableProperty<System.String>("font_source", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> FontFallbacks<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFontProperties, T>magic = null) where T : CoreUI.ITextFontProperties {
            return new CoreUI.BindableProperty<System.String>("font_fallbacks", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextFontWeight> FontWeight<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFontProperties, T>magic = null) where T : CoreUI.ITextFontProperties {
            return new CoreUI.BindableProperty<CoreUI.TextFontWeight>("font_weight", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextFontSlant> FontSlant<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFontProperties, T>magic = null) where T : CoreUI.ITextFontProperties {
            return new CoreUI.BindableProperty<CoreUI.TextFontSlant>("font_slant", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextFontWidth> FontWidth<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFontProperties, T>magic = null) where T : CoreUI.ITextFontProperties {
            return new CoreUI.BindableProperty<CoreUI.TextFontWidth>("font_width", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> FontLang<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFontProperties, T>magic = null) where T : CoreUI.ITextFontProperties {
            return new CoreUI.BindableProperty<System.String>("font_lang", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextFontBitmapScalable> FontBitmapScalable<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFontProperties, T>magic = null) where T : CoreUI.ITextFontProperties {
            return new CoreUI.BindableProperty<CoreUI.TextFontBitmapScalable>("font_bitmap_scalable", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI {
    /// <summary>The weight of a particular font is the thickness of the character outlines relative to their height. The given numerical values follow the TrueType scale (from 100 to 900) and are approximate. It is up to each font to provide all of them.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum TextFontWeight
    {
        /// <summary>Normal font weight (400).</summary>
        /// <since_tizen> 6 </since_tizen>
        Normal = 0,
        /// <summary>Thin font weight (100).</summary>
        /// <since_tizen> 6 </since_tizen>
        Thin = 1,
        /// <summary>Ultralight font weight (200).</summary>
        /// <since_tizen> 6 </since_tizen>
        Ultralight = 2,
        /// <summary>Extralight font weight (200).</summary>
        /// <since_tizen> 6 </since_tizen>
        Extralight = 3,
        /// <summary>Light font weight (300).</summary>
        /// <since_tizen> 6 </since_tizen>
        Light = 4,
        /// <summary>Book font weight (350).</summary>
        /// <since_tizen> 6 </since_tizen>
        Book = 5,
        /// <summary>Medium font weight (500).</summary>
        /// <since_tizen> 6 </since_tizen>
        Medium = 6,
        /// <summary>Semibold font weight (600).</summary>
        /// <since_tizen> 6 </since_tizen>
        Semibold = 7,
        /// <summary>Bold font weight (700).</summary>
        /// <since_tizen> 6 </since_tizen>
        Bold = 8,
        /// <summary>Ultrabold font weight (800).</summary>
        /// <since_tizen> 6 </since_tizen>
        Ultrabold = 9,
        /// <summary>Extrabold font weight (800).</summary>
        /// <since_tizen> 6 </since_tizen>
        Extrabold = 10,
        /// <summary>Black font weight (900).</summary>
        /// <since_tizen> 6 </since_tizen>
        Black = 11,
        /// <summary>Extrablack font weight (950).</summary>
        /// <since_tizen> 6 </since_tizen>
        Extrablack = 12,
    }
}

namespace CoreUI {
    /// <summary>Font width relative to its height. It is up to each font to provide all these widths.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum TextFontWidth
    {
        /// <summary>Normal font width.</summary>
        /// <since_tizen> 6 </since_tizen>
        Normal = 0,
        /// <summary>Ultracondensed font width.</summary>
        /// <since_tizen> 6 </since_tizen>
        Ultracondensed = 1,
        /// <summary>Extracondensed font width.</summary>
        /// <since_tizen> 6 </since_tizen>
        Extracondensed = 2,
        /// <summary>Condensed font width.</summary>
        /// <since_tizen> 6 </since_tizen>
        Condensed = 3,
        /// <summary>Semicondensed font width.</summary>
        /// <since_tizen> 6 </since_tizen>
        Semicondensed = 4,
        /// <summary>Semiexpanded font width.</summary>
        /// <since_tizen> 6 </since_tizen>
        Semiexpanded = 5,
        /// <summary>Expanded font width.</summary>
        /// <since_tizen> 6 </since_tizen>
        Expanded = 6,
        /// <summary>Extraexpanded font width.</summary>
        /// <since_tizen> 6 </since_tizen>
        Extraexpanded = 7,
        /// <summary>Ultraexpanded font width.</summary>
        /// <since_tizen> 6 </since_tizen>
        Ultraexpanded = 8,
    }
}

namespace CoreUI {
    /// <summary>Type of font slant.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum TextFontSlant
    {
        /// <summary>Normal font slant: Sets the text to the normal font (non-italicized).</summary>
        /// <since_tizen> 6 </since_tizen>
        Normal = 0,
        /// <summary>Oblique font slant: Sets the text to use a simulated version of an italic font, created by algorithmically slanting the normal version.</summary>
        /// <since_tizen> 6 </since_tizen>
        Oblique = 1,
        /// <summary>Italic font slant: Sets the text to use the italic version of the font if available. If not available, it will simulate italics with oblique instead.</summary>
        /// <since_tizen> 6 </since_tizen>
        Italic = 2,
    }
}

namespace CoreUI {
    /// <summary>When are bitmap fonts allowed to be scaled.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum TextFontBitmapScalable
    {
        /// <summary>Disable scaling for bitmap fonts.</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>Enable scaling for color bitmap fonts.</summary>
        /// <since_tizen> 6 </since_tizen>
        Color = 1,
    }
}

