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
    /// <summary>The look and layout of the text.
    /// 
    /// The text format can affect the geometry of the text object, as well as how characters are presented.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.ITextFormatNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface ITextFormat : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Controls automatic addition of ellipsis &quot;...&quot; to replace text which cannot be shown. The value must be a number indicating the position of the ellipsis inside the visible text. <c>0.0</c> means the beginning of the text, <c>1.0</c> means the end of the text, and values in between mean the proportional position inside the text. Any value smaller than 0 or greater than 1 disables ellipsis.</summary>
        /// <returns>Position of the ellipsis inside the text, from <c>0.0</c> to <c>1.0</c>.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetEllipsis();

        /// <summary>Controls automatic addition of ellipsis &quot;...&quot; to replace text which cannot be shown. The value must be a number indicating the position of the ellipsis inside the visible text. <c>0.0</c> means the beginning of the text, <c>1.0</c> means the end of the text, and values in between mean the proportional position inside the text. Any value smaller than 0 or greater than 1 disables ellipsis.</summary>
        /// <param name="value">Position of the ellipsis inside the text, from <c>0.0</c> to <c>1.0</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetEllipsis(double value);

        /// <summary>Wrapping policy for the text.
        /// 
        /// When text does not fit the widget in a single line, it can be automatically wrapped at character or word boundaries, for example.
        /// 
        /// Requires <see cref="CoreUI.ITextFormat.Multiline"/> to be <c>true</c>.</summary>
        /// <returns>Wrapping policy.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextFormatWrap GetWrap();

        /// <summary>Wrapping policy for the text.
        /// 
        /// When text does not fit the widget in a single line, it can be automatically wrapped at character or word boundaries, for example.
        /// 
        /// Requires <see cref="CoreUI.ITextFormat.Multiline"/> to be <c>true</c>.</summary>
        /// <param name="wrap">Wrapping policy.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetWrap(CoreUI.TextFormatWrap wrap);

        /// <summary>Enables text to span multiple lines.
        /// 
        /// When <c>false</c>, new-line characters are ignored and no text wrapping occurs.</summary>
        /// <returns><c>true</c> if multiple lines should be rendered.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetMultiline();

        /// <summary>Enables text to span multiple lines.
        /// 
        /// When <c>false</c>, new-line characters are ignored and no text wrapping occurs.</summary>
        /// <param name="enabled"><c>true</c> if multiple lines should be rendered.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetMultiline(bool enabled);

        /// <summary>Specifies when the text&apos;s horizontal alignment should be set automatically.</summary>
        /// <returns>Automatic horizontal alignment type.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextFormatHorizontalAlignmentAutoType GetTextHorizontalAlignAutoType();

        /// <summary>Specifies when the text&apos;s horizontal alignment should be set automatically.</summary>
        /// <param name="value">Automatic horizontal alignment type.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextHorizontalAlignAutoType(CoreUI.TextFormatHorizontalAlignmentAutoType value);

        /// <summary>Manual horizontal alignment of text. <c>0.0</c> means &quot;left&quot; and <c>1.0</c> means &quot;right&quot;. Setting this value also sets <see cref="CoreUI.ITextFormat.TextHorizontalAlignAutoType"/> to <see cref="CoreUI.TextFormatHorizontalAlignmentAutoType.None"/>. This value is ignored when <see cref="CoreUI.ITextFormat.TextHorizontalAlignAutoType"/> is set to anything other than <see cref="CoreUI.TextFormatHorizontalAlignmentAutoType.None"/>.</summary>
        /// <returns>Alignment value between <c>0.0</c> and <c>1.0</c>.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetTextHorizontalAlign();

        /// <summary>Manual horizontal alignment of text. <c>0.0</c> means &quot;left&quot; and <c>1.0</c> means &quot;right&quot;. Setting this value also sets <see cref="CoreUI.ITextFormat.TextHorizontalAlignAutoType"/> to <see cref="CoreUI.TextFormatHorizontalAlignmentAutoType.None"/>. This value is ignored when <see cref="CoreUI.ITextFormat.TextHorizontalAlignAutoType"/> is set to anything other than <see cref="CoreUI.TextFormatHorizontalAlignmentAutoType.None"/>.</summary>
        /// <param name="value">Alignment value between <c>0.0</c> and <c>1.0</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextHorizontalAlign(double value);

        /// <summary>Vertical alignment of text. <c>0.0</c> means &quot;top&quot; and <c>1.0</c> means &quot;bottom&quot;</summary>
        /// <returns>Alignment value between <c>0.0</c> and <c>1.0</c>.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetTextVerticalAlign();

        /// <summary>Vertical alignment of text. <c>0.0</c> means &quot;top&quot; and <c>1.0</c> means &quot;bottom&quot;</summary>
        /// <param name="value">Alignment value between <c>0.0</c> and <c>1.0</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextVerticalAlign(double value);

        /// <summary>Minimal line gap (top and bottom) for each line in the text.
        /// 
        /// <c>value</c> is absolute size.</summary>
        /// <returns>Line gap value, in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetLineGap();

        /// <summary>Minimal line gap (top and bottom) for each line in the text.
        /// 
        /// <c>value</c> is absolute size.</summary>
        /// <param name="value">Line gap value, in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetLineGap(double value);

        /// <summary>Relative line gap (top and bottom) for each line in the text.
        /// 
        /// The original line gap value is multiplied by <c>value</c>.</summary>
        /// <returns>Relative line gap value. <c>1.0</c> means original size.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetLineRelGap();

        /// <summary>Relative line gap (top and bottom) for each line in the text.
        /// 
        /// The original line gap value is multiplied by <c>value</c>.</summary>
        /// <param name="value">Relative line gap value. <c>1.0</c> means original size.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetLineRelGap(double value);

        /// <summary>Size (in pixels) of the tab character.</summary>
        /// <returns>Size in pixels, greater than 1.</returns>
        /// <since_tizen> 6 </since_tizen>
        int GetTabStops();

        /// <summary>Size (in pixels) of the tab character.</summary>
        /// <param name="value">Size in pixels, greater than 1.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTabStops(int value);

        /// <summary>Enabling this causes all characters to be replaced by <see cref="CoreUI.ITextFormat.ReplacementChar"/>.
        /// 
        /// This is useful for password input boxes.</summary>
        /// <returns><c>true</c> if the text is a password.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetPassword();

        /// <summary>Enabling this causes all characters to be replaced by <see cref="CoreUI.ITextFormat.ReplacementChar"/>.
        /// 
        /// This is useful for password input boxes.</summary>
        /// <param name="enabled"><c>true</c> if the text is a password.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetPassword(bool enabled);

        /// <summary>The character used to replace characters that can&apos;t be displayed.
        /// 
        /// Only used to replace characters if <see cref="CoreUI.ITextFormat.Password"/> is enabled.</summary>
        /// <returns>Replacement character.</returns>
        /// <since_tizen> 6 </since_tizen>
        System.String GetReplacementChar();

        /// <summary>The character used to replace characters that can&apos;t be displayed.
        /// 
        /// Only used to replace characters if <see cref="CoreUI.ITextFormat.Password"/> is enabled.</summary>
        /// <param name="repch">Replacement character.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetReplacementChar(System.String repch);

        /// <summary>Controls automatic addition of ellipsis &quot;...&quot; to replace text which cannot be shown. The value must be a number indicating the position of the ellipsis inside the visible text. <c>0.0</c> means the beginning of the text, <c>1.0</c> means the end of the text, and values in between mean the proportional position inside the text. Any value smaller than 0 or greater than 1 disables ellipsis.</summary>
        /// <value>Position of the ellipsis inside the text, from <c>0.0</c> to <c>1.0</c>.</value>
        /// <since_tizen> 6 </since_tizen>
        double Ellipsis {
            get;
            set;
        }

        /// <summary>Wrapping policy for the text.
        /// 
        /// When text does not fit the widget in a single line, it can be automatically wrapped at character or word boundaries, for example.
        /// 
        /// Requires <see cref="CoreUI.ITextFormat.Multiline"/> to be <c>true</c>.</summary>
        /// <value>Wrapping policy.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextFormatWrap Wrap {
            get;
            set;
        }

        /// <summary>Enables text to span multiple lines.
        /// 
        /// When <c>false</c>, new-line characters are ignored and no text wrapping occurs.</summary>
        /// <value><c>true</c> if multiple lines should be rendered.</value>
        /// <since_tizen> 6 </since_tizen>
        bool Multiline {
            get;
            set;
        }

        /// <summary>Specifies when the text&apos;s horizontal alignment should be set automatically.</summary>
        /// <value>Automatic horizontal alignment type.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextFormatHorizontalAlignmentAutoType TextHorizontalAlignAutoType {
            get;
            set;
        }

        /// <summary>Manual horizontal alignment of text. <c>0.0</c> means &quot;left&quot; and <c>1.0</c> means &quot;right&quot;. Setting this value also sets <see cref="CoreUI.ITextFormat.TextHorizontalAlignAutoType"/> to <see cref="CoreUI.TextFormatHorizontalAlignmentAutoType.None"/>. This value is ignored when <see cref="CoreUI.ITextFormat.TextHorizontalAlignAutoType"/> is set to anything other than <see cref="CoreUI.TextFormatHorizontalAlignmentAutoType.None"/>.</summary>
        /// <value>Alignment value between <c>0.0</c> and <c>1.0</c>.</value>
        /// <since_tizen> 6 </since_tizen>
        double TextHorizontalAlign {
            get;
            set;
        }

        /// <summary>Vertical alignment of text. <c>0.0</c> means &quot;top&quot; and <c>1.0</c> means &quot;bottom&quot;</summary>
        /// <value>Alignment value between <c>0.0</c> and <c>1.0</c>.</value>
        /// <since_tizen> 6 </since_tizen>
        double TextVerticalAlign {
            get;
            set;
        }

        /// <summary>Minimal line gap (top and bottom) for each line in the text.
        /// 
        /// <c>value</c> is absolute size.</summary>
        /// <value>Line gap value, in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        double LineGap {
            get;
            set;
        }

        /// <summary>Relative line gap (top and bottom) for each line in the text.
        /// 
        /// The original line gap value is multiplied by <c>value</c>.</summary>
        /// <value>Relative line gap value. <c>1.0</c> means original size.</value>
        /// <since_tizen> 6 </since_tizen>
        double LineRelGap {
            get;
            set;
        }

        /// <summary>Size (in pixels) of the tab character.</summary>
        /// <value>Size in pixels, greater than 1.</value>
        /// <since_tizen> 6 </since_tizen>
        int TabStops {
            get;
            set;
        }

        /// <summary>Enabling this causes all characters to be replaced by <see cref="CoreUI.ITextFormat.ReplacementChar"/>.
        /// 
        /// This is useful for password input boxes.</summary>
        /// <value><c>true</c> if the text is a password.</value>
        /// <since_tizen> 6 </since_tizen>
        bool Password {
            get;
            set;
        }

        /// <summary>The character used to replace characters that can&apos;t be displayed.
        /// 
        /// Only used to replace characters if <see cref="CoreUI.ITextFormat.Password"/> is enabled.</summary>
        /// <value>Replacement character.</value>
        /// <since_tizen> 6 </since_tizen>
        System.String ReplacementChar {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ITextFormatNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_text_format_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_text_ellipsis_get_static_delegate == null)
            {
                efl_text_ellipsis_get_static_delegate = new efl_text_ellipsis_get_delegate(ellipsis_get);
            }

            if (methods.Contains("GetEllipsis"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_ellipsis_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_get_static_delegate) });
            }

            if (efl_text_ellipsis_set_static_delegate == null)
            {
                efl_text_ellipsis_set_static_delegate = new efl_text_ellipsis_set_delegate(ellipsis_set);
            }

            if (methods.Contains("SetEllipsis"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_ellipsis_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_set_static_delegate) });
            }

            if (efl_text_wrap_get_static_delegate == null)
            {
                efl_text_wrap_get_static_delegate = new efl_text_wrap_get_delegate(wrap_get);
            }

            if (methods.Contains("GetWrap"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_wrap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_get_static_delegate) });
            }

            if (efl_text_wrap_set_static_delegate == null)
            {
                efl_text_wrap_set_static_delegate = new efl_text_wrap_set_delegate(wrap_set);
            }

            if (methods.Contains("SetWrap"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_wrap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_set_static_delegate) });
            }

            if (efl_text_multiline_get_static_delegate == null)
            {
                efl_text_multiline_get_static_delegate = new efl_text_multiline_get_delegate(multiline_get);
            }

            if (methods.Contains("GetMultiline"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_multiline_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_get_static_delegate) });
            }

            if (efl_text_multiline_set_static_delegate == null)
            {
                efl_text_multiline_set_static_delegate = new efl_text_multiline_set_delegate(multiline_set);
            }

            if (methods.Contains("SetMultiline"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_multiline_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_set_static_delegate) });
            }

            if (efl_text_horizontal_align_auto_type_get_static_delegate == null)
            {
                efl_text_horizontal_align_auto_type_get_static_delegate = new efl_text_horizontal_align_auto_type_get_delegate(text_horizontal_align_auto_type_get);
            }

            if (methods.Contains("GetTextHorizontalAlignAutoType"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_horizontal_align_auto_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_horizontal_align_auto_type_get_static_delegate) });
            }

            if (efl_text_horizontal_align_auto_type_set_static_delegate == null)
            {
                efl_text_horizontal_align_auto_type_set_static_delegate = new efl_text_horizontal_align_auto_type_set_delegate(text_horizontal_align_auto_type_set);
            }

            if (methods.Contains("SetTextHorizontalAlignAutoType"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_horizontal_align_auto_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_horizontal_align_auto_type_set_static_delegate) });
            }

            if (efl_text_horizontal_align_get_static_delegate == null)
            {
                efl_text_horizontal_align_get_static_delegate = new efl_text_horizontal_align_get_delegate(text_horizontal_align_get);
            }

            if (methods.Contains("GetTextHorizontalAlign"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_horizontal_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_horizontal_align_get_static_delegate) });
            }

            if (efl_text_horizontal_align_set_static_delegate == null)
            {
                efl_text_horizontal_align_set_static_delegate = new efl_text_horizontal_align_set_delegate(text_horizontal_align_set);
            }

            if (methods.Contains("SetTextHorizontalAlign"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_horizontal_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_horizontal_align_set_static_delegate) });
            }

            if (efl_text_vertical_align_get_static_delegate == null)
            {
                efl_text_vertical_align_get_static_delegate = new efl_text_vertical_align_get_delegate(text_vertical_align_get);
            }

            if (methods.Contains("GetTextVerticalAlign"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_vertical_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_vertical_align_get_static_delegate) });
            }

            if (efl_text_vertical_align_set_static_delegate == null)
            {
                efl_text_vertical_align_set_static_delegate = new efl_text_vertical_align_set_delegate(text_vertical_align_set);
            }

            if (methods.Contains("SetTextVerticalAlign"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_vertical_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_vertical_align_set_static_delegate) });
            }

            if (efl_text_line_gap_get_static_delegate == null)
            {
                efl_text_line_gap_get_static_delegate = new efl_text_line_gap_get_delegate(line_gap_get);
            }

            if (methods.Contains("GetLineGap"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_line_gap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_line_gap_get_static_delegate) });
            }

            if (efl_text_line_gap_set_static_delegate == null)
            {
                efl_text_line_gap_set_static_delegate = new efl_text_line_gap_set_delegate(line_gap_set);
            }

            if (methods.Contains("SetLineGap"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_line_gap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_line_gap_set_static_delegate) });
            }

            if (efl_text_line_rel_gap_get_static_delegate == null)
            {
                efl_text_line_rel_gap_get_static_delegate = new efl_text_line_rel_gap_get_delegate(line_rel_gap_get);
            }

            if (methods.Contains("GetLineRelGap"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_line_rel_gap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_line_rel_gap_get_static_delegate) });
            }

            if (efl_text_line_rel_gap_set_static_delegate == null)
            {
                efl_text_line_rel_gap_set_static_delegate = new efl_text_line_rel_gap_set_delegate(line_rel_gap_set);
            }

            if (methods.Contains("SetLineRelGap"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_line_rel_gap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_line_rel_gap_set_static_delegate) });
            }

            if (efl_text_tab_stops_get_static_delegate == null)
            {
                efl_text_tab_stops_get_static_delegate = new efl_text_tab_stops_get_delegate(tab_stops_get);
            }

            if (methods.Contains("GetTabStops"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_tab_stops_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tab_stops_get_static_delegate) });
            }

            if (efl_text_tab_stops_set_static_delegate == null)
            {
                efl_text_tab_stops_set_static_delegate = new efl_text_tab_stops_set_delegate(tab_stops_set);
            }

            if (methods.Contains("SetTabStops"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_tab_stops_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tab_stops_set_static_delegate) });
            }

            if (efl_text_password_get_static_delegate == null)
            {
                efl_text_password_get_static_delegate = new efl_text_password_get_delegate(password_get);
            }

            if (methods.Contains("GetPassword"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_password_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_get_static_delegate) });
            }

            if (efl_text_password_set_static_delegate == null)
            {
                efl_text_password_set_static_delegate = new efl_text_password_set_delegate(password_set);
            }

            if (methods.Contains("SetPassword"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_password_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_set_static_delegate) });
            }

            if (efl_text_replacement_char_get_static_delegate == null)
            {
                efl_text_replacement_char_get_static_delegate = new efl_text_replacement_char_get_delegate(replacement_char_get);
            }

            if (methods.Contains("GetReplacementChar"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_replacement_char_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_get_static_delegate) });
            }

            if (efl_text_replacement_char_set_static_delegate == null)
            {
                efl_text_replacement_char_set_static_delegate = new efl_text_replacement_char_set_delegate(replacement_char_set);
            }

            if (methods.Contains("SetReplacementChar"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_replacement_char_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_set_static_delegate) });
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
            return efl_text_format_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_text_ellipsis_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_text_ellipsis_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_ellipsis_get_api_delegate> efl_text_ellipsis_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_ellipsis_get_api_delegate>(Module, "efl_text_ellipsis_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double ellipsis_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_ellipsis_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((ITextFormat)ws.Target).GetEllipsis();
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
                return efl_text_ellipsis_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_ellipsis_get_delegate efl_text_ellipsis_get_static_delegate;

        
        private delegate void efl_text_ellipsis_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        internal delegate void efl_text_ellipsis_set_api_delegate(System.IntPtr obj,  double value);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_ellipsis_set_api_delegate> efl_text_ellipsis_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_ellipsis_set_api_delegate>(Module, "efl_text_ellipsis_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void ellipsis_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_ellipsis_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFormat)ws.Target).SetEllipsis(value);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_ellipsis_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), value);
            }
        }

        private static efl_text_ellipsis_set_delegate efl_text_ellipsis_set_static_delegate;

        
        private delegate CoreUI.TextFormatWrap efl_text_wrap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.TextFormatWrap efl_text_wrap_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_wrap_get_api_delegate> efl_text_wrap_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_wrap_get_api_delegate>(Module, "efl_text_wrap_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.TextFormatWrap wrap_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_wrap_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.TextFormatWrap _ret_var = default(CoreUI.TextFormatWrap);
                try
                {
                    _ret_var = ((ITextFormat)ws.Target).GetWrap();
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
                return efl_text_wrap_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_wrap_get_delegate efl_text_wrap_get_static_delegate;

        
        private delegate void efl_text_wrap_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TextFormatWrap wrap);

        
        internal delegate void efl_text_wrap_set_api_delegate(System.IntPtr obj,  CoreUI.TextFormatWrap wrap);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_wrap_set_api_delegate> efl_text_wrap_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_wrap_set_api_delegate>(Module, "efl_text_wrap_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void wrap_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TextFormatWrap wrap)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_wrap_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFormat)ws.Target).SetWrap(wrap);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_wrap_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), wrap);
            }
        }

        private static efl_text_wrap_set_delegate efl_text_wrap_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_multiline_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_text_multiline_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_multiline_get_api_delegate> efl_text_multiline_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_multiline_get_api_delegate>(Module, "efl_text_multiline_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool multiline_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_multiline_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextFormat)ws.Target).GetMultiline();
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
                return efl_text_multiline_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_multiline_get_delegate efl_text_multiline_get_static_delegate;

        
        private delegate void efl_text_multiline_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enabled);

        
        internal delegate void efl_text_multiline_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enabled);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_multiline_set_api_delegate> efl_text_multiline_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_multiline_set_api_delegate>(Module, "efl_text_multiline_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void multiline_set(System.IntPtr obj, System.IntPtr pd, bool enabled)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_multiline_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFormat)ws.Target).SetMultiline(enabled);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_multiline_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), enabled);
            }
        }

        private static efl_text_multiline_set_delegate efl_text_multiline_set_static_delegate;

        
        private delegate CoreUI.TextFormatHorizontalAlignmentAutoType efl_text_horizontal_align_auto_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.TextFormatHorizontalAlignmentAutoType efl_text_horizontal_align_auto_type_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_horizontal_align_auto_type_get_api_delegate> efl_text_horizontal_align_auto_type_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_horizontal_align_auto_type_get_api_delegate>(Module, "efl_text_horizontal_align_auto_type_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.TextFormatHorizontalAlignmentAutoType text_horizontal_align_auto_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_horizontal_align_auto_type_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.TextFormatHorizontalAlignmentAutoType _ret_var = default(CoreUI.TextFormatHorizontalAlignmentAutoType);
                try
                {
                    _ret_var = ((ITextFormat)ws.Target).GetTextHorizontalAlignAutoType();
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
                return efl_text_horizontal_align_auto_type_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_horizontal_align_auto_type_get_delegate efl_text_horizontal_align_auto_type_get_static_delegate;

        
        private delegate void efl_text_horizontal_align_auto_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TextFormatHorizontalAlignmentAutoType value);

        
        internal delegate void efl_text_horizontal_align_auto_type_set_api_delegate(System.IntPtr obj,  CoreUI.TextFormatHorizontalAlignmentAutoType value);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_horizontal_align_auto_type_set_api_delegate> efl_text_horizontal_align_auto_type_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_horizontal_align_auto_type_set_api_delegate>(Module, "efl_text_horizontal_align_auto_type_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_horizontal_align_auto_type_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TextFormatHorizontalAlignmentAutoType value)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_horizontal_align_auto_type_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFormat)ws.Target).SetTextHorizontalAlignAutoType(value);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_horizontal_align_auto_type_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), value);
            }
        }

        private static efl_text_horizontal_align_auto_type_set_delegate efl_text_horizontal_align_auto_type_set_static_delegate;

        
        private delegate double efl_text_horizontal_align_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_text_horizontal_align_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_horizontal_align_get_api_delegate> efl_text_horizontal_align_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_horizontal_align_get_api_delegate>(Module, "efl_text_horizontal_align_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double text_horizontal_align_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_horizontal_align_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((ITextFormat)ws.Target).GetTextHorizontalAlign();
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
                return efl_text_horizontal_align_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_horizontal_align_get_delegate efl_text_horizontal_align_get_static_delegate;

        
        private delegate void efl_text_horizontal_align_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        internal delegate void efl_text_horizontal_align_set_api_delegate(System.IntPtr obj,  double value);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_horizontal_align_set_api_delegate> efl_text_horizontal_align_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_horizontal_align_set_api_delegate>(Module, "efl_text_horizontal_align_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_horizontal_align_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_horizontal_align_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFormat)ws.Target).SetTextHorizontalAlign(value);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_horizontal_align_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), value);
            }
        }

        private static efl_text_horizontal_align_set_delegate efl_text_horizontal_align_set_static_delegate;

        
        private delegate double efl_text_vertical_align_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_text_vertical_align_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_vertical_align_get_api_delegate> efl_text_vertical_align_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_vertical_align_get_api_delegate>(Module, "efl_text_vertical_align_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double text_vertical_align_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_vertical_align_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((ITextFormat)ws.Target).GetTextVerticalAlign();
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
                return efl_text_vertical_align_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_vertical_align_get_delegate efl_text_vertical_align_get_static_delegate;

        
        private delegate void efl_text_vertical_align_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        internal delegate void efl_text_vertical_align_set_api_delegate(System.IntPtr obj,  double value);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_vertical_align_set_api_delegate> efl_text_vertical_align_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_vertical_align_set_api_delegate>(Module, "efl_text_vertical_align_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_vertical_align_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_vertical_align_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFormat)ws.Target).SetTextVerticalAlign(value);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_vertical_align_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), value);
            }
        }

        private static efl_text_vertical_align_set_delegate efl_text_vertical_align_set_static_delegate;

        
        private delegate double efl_text_line_gap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_text_line_gap_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_line_gap_get_api_delegate> efl_text_line_gap_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_line_gap_get_api_delegate>(Module, "efl_text_line_gap_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double line_gap_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_line_gap_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((ITextFormat)ws.Target).GetLineGap();
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
                return efl_text_line_gap_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_line_gap_get_delegate efl_text_line_gap_get_static_delegate;

        
        private delegate void efl_text_line_gap_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        internal delegate void efl_text_line_gap_set_api_delegate(System.IntPtr obj,  double value);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_line_gap_set_api_delegate> efl_text_line_gap_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_line_gap_set_api_delegate>(Module, "efl_text_line_gap_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void line_gap_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_line_gap_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFormat)ws.Target).SetLineGap(value);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_line_gap_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), value);
            }
        }

        private static efl_text_line_gap_set_delegate efl_text_line_gap_set_static_delegate;

        
        private delegate double efl_text_line_rel_gap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_text_line_rel_gap_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_line_rel_gap_get_api_delegate> efl_text_line_rel_gap_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_line_rel_gap_get_api_delegate>(Module, "efl_text_line_rel_gap_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double line_rel_gap_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_line_rel_gap_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((ITextFormat)ws.Target).GetLineRelGap();
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
                return efl_text_line_rel_gap_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_line_rel_gap_get_delegate efl_text_line_rel_gap_get_static_delegate;

        
        private delegate void efl_text_line_rel_gap_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        internal delegate void efl_text_line_rel_gap_set_api_delegate(System.IntPtr obj,  double value);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_line_rel_gap_set_api_delegate> efl_text_line_rel_gap_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_line_rel_gap_set_api_delegate>(Module, "efl_text_line_rel_gap_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void line_rel_gap_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_line_rel_gap_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFormat)ws.Target).SetLineRelGap(value);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_line_rel_gap_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), value);
            }
        }

        private static efl_text_line_rel_gap_set_delegate efl_text_line_rel_gap_set_static_delegate;

        
        private delegate int efl_text_tab_stops_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_text_tab_stops_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_tab_stops_get_api_delegate> efl_text_tab_stops_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_tab_stops_get_api_delegate>(Module, "efl_text_tab_stops_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int tab_stops_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_tab_stops_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((ITextFormat)ws.Target).GetTabStops();
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
                return efl_text_tab_stops_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_tab_stops_get_delegate efl_text_tab_stops_get_static_delegate;

        
        private delegate void efl_text_tab_stops_set_delegate(System.IntPtr obj, System.IntPtr pd,  int value);

        
        internal delegate void efl_text_tab_stops_set_api_delegate(System.IntPtr obj,  int value);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_tab_stops_set_api_delegate> efl_text_tab_stops_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_tab_stops_set_api_delegate>(Module, "efl_text_tab_stops_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void tab_stops_set(System.IntPtr obj, System.IntPtr pd, int value)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_tab_stops_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFormat)ws.Target).SetTabStops(value);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_tab_stops_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), value);
            }
        }

        private static efl_text_tab_stops_set_delegate efl_text_tab_stops_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_password_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_text_password_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_password_get_api_delegate> efl_text_password_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_password_get_api_delegate>(Module, "efl_text_password_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool password_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_password_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ITextFormat)ws.Target).GetPassword();
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
                return efl_text_password_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_password_get_delegate efl_text_password_get_static_delegate;

        
        private delegate void efl_text_password_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enabled);

        
        internal delegate void efl_text_password_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enabled);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_password_set_api_delegate> efl_text_password_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_password_set_api_delegate>(Module, "efl_text_password_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void password_set(System.IntPtr obj, System.IntPtr pd, bool enabled)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_password_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFormat)ws.Target).SetPassword(enabled);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_password_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), enabled);
            }
        }

        private static efl_text_password_set_delegate efl_text_password_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_replacement_char_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        internal delegate System.String efl_text_replacement_char_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_replacement_char_get_api_delegate> efl_text_replacement_char_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_replacement_char_get_api_delegate>(Module, "efl_text_replacement_char_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.String replacement_char_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_replacement_char_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((ITextFormat)ws.Target).GetReplacementChar();
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
                return efl_text_replacement_char_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_replacement_char_get_delegate efl_text_replacement_char_get_static_delegate;

        
        private delegate void efl_text_replacement_char_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String repch);

        
        internal delegate void efl_text_replacement_char_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String repch);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_replacement_char_set_api_delegate> efl_text_replacement_char_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_replacement_char_set_api_delegate>(Module, "efl_text_replacement_char_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void replacement_char_set(System.IntPtr obj, System.IntPtr pd, System.String repch)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_replacement_char_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextFormat)ws.Target).SetReplacementChar(repch);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_replacement_char_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), repch);
            }
        }

        private static efl_text_replacement_char_set_delegate efl_text_replacement_char_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class TextFormatExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> Ellipsis<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFormat, T>magic = null) where T : CoreUI.ITextFormat {
            return new CoreUI.BindableProperty<double>("ellipsis", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextFormatWrap> Wrap<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFormat, T>magic = null) where T : CoreUI.ITextFormat {
            return new CoreUI.BindableProperty<CoreUI.TextFormatWrap>("wrap", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Multiline<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFormat, T>magic = null) where T : CoreUI.ITextFormat {
            return new CoreUI.BindableProperty<bool>("multiline", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextFormatHorizontalAlignmentAutoType> TextHorizontalAlignAutoType<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFormat, T>magic = null) where T : CoreUI.ITextFormat {
            return new CoreUI.BindableProperty<CoreUI.TextFormatHorizontalAlignmentAutoType>("text_horizontal_align_auto_type", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> TextHorizontalAlign<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFormat, T>magic = null) where T : CoreUI.ITextFormat {
            return new CoreUI.BindableProperty<double>("text_horizontal_align", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> TextVerticalAlign<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFormat, T>magic = null) where T : CoreUI.ITextFormat {
            return new CoreUI.BindableProperty<double>("text_vertical_align", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> LineGap<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFormat, T>magic = null) where T : CoreUI.ITextFormat {
            return new CoreUI.BindableProperty<double>("line_gap", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> LineRelGap<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFormat, T>magic = null) where T : CoreUI.ITextFormat {
            return new CoreUI.BindableProperty<double>("line_rel_gap", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> TabStops<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFormat, T>magic = null) where T : CoreUI.ITextFormat {
            return new CoreUI.BindableProperty<int>("tab_stops", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Password<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFormat, T>magic = null) where T : CoreUI.ITextFormat {
            return new CoreUI.BindableProperty<bool>("password", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> ReplacementChar<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextFormat, T>magic = null) where T : CoreUI.ITextFormat {
            return new CoreUI.BindableProperty<System.String>("replacement_char", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI {
    /// <summary>Wrapping policy for the text.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum TextFormatWrap
    {
        /// <summary>No wrapping.</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>Wrap at character boundaries.</summary>
        /// <since_tizen> 6 </since_tizen>
        Char = 1,
        /// <summary>Wrap at word boundaries.</summary>
        /// <since_tizen> 6 </since_tizen>
        Word = 2,
        /// <summary>Wrap at word boundaries if possible, at any character if not.</summary>
        /// <since_tizen> 6 </since_tizen>
        Mixed = 3,
        /// <summary>Hyphenate if possible, otherwise try word boundaries or at any character.</summary>
        /// <since_tizen> 6 </since_tizen>
        Hyphenation = 4,
    }
}

namespace CoreUI {
    /// <summary>Automatic horizontal alignment setting for the text (Left-To-Right or Right-To-Left).</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum TextFormatHorizontalAlignmentAutoType
    {
        /// <summary>No auto-alignment rule: Horizontal Alignment is decided by <see cref="CoreUI.ITextFormat.TextHorizontalAlign"/></summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>Respects LTR/RTL (bidirectional) characters found inside the text content.</summary>
        /// <since_tizen> 6 </since_tizen>
        Auto = 1,
        /// <summary>Respects the system&apos;s language settings.</summary>
        /// <since_tizen> 6 </since_tizen>
        Locale = 2,
        /// <summary>Text is placed at opposite side of LTR/RTL (bidirectional) settings.</summary>
        /// <since_tizen> 6 </since_tizen>
        Opposite = 3,
    }
}

