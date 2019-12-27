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
    /// <summary>Decorations to add to the text.
    /// 
    /// Decorations include text color, glow, outline, underline, strike-through and shadows.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.ITextStyleNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface ITextStyle : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Color of text, excluding all other decorations. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetTextColor(out byte r, out byte g, out byte b, out byte a);

        /// <summary>Color of text, excluding all other decorations. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextColor(byte r, byte g, byte b, byte a);

        /// <summary>Type of background to use behind each line of text.</summary>
        /// <returns>Background type.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextStyleBackgroundType GetTextBackgroundType();

        /// <summary>Type of background to use behind each line of text.</summary>
        /// <param name="type">Background type.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextBackgroundType(CoreUI.TextStyleBackgroundType type);

        /// <summary>Color of the background behind each line of text. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetTextBackgroundColor(out byte r, out byte g, out byte b, out byte a);

        /// <summary>Color of the background behind each line of text. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextBackgroundColor(byte r, byte g, byte b, byte a);

        /// <summary>Type of underline to use for the text.</summary>
        /// <returns>Underline type.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextStyleUnderlineType GetTextUnderlineType();

        /// <summary>Type of underline to use for the text.</summary>
        /// <param name="type">Underline type.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextUnderlineType(CoreUI.TextStyleUnderlineType type);

        /// <summary>Color of the primary underline. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetTextUnderlineColor(out byte r, out byte g, out byte b, out byte a);

        /// <summary>Color of the primary underline. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextUnderlineColor(byte r, byte g, byte b, byte a);

        /// <summary>Width (in pixels) of the single underline when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Single"/>.</summary>
        /// <returns>Underline width in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetTextUnderlineHeight();

        /// <summary>Width (in pixels) of the single underline when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Single"/>.</summary>
        /// <param name="height">Underline width in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextUnderlineHeight(double height);

        /// <summary>Color of the dashed underline. Only valid when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Dashed"/>. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetTextUnderlineDashedColor(out byte r, out byte g, out byte b, out byte a);

        /// <summary>Color of the dashed underline. Only valid when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Dashed"/>. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextUnderlineDashedColor(byte r, byte g, byte b, byte a);

        /// <summary>Length (in pixels) of the dashes when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Dashed"/>.</summary>
        /// <returns>Dash length in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        int GetTextUnderlineDashedWidth();

        /// <summary>Length (in pixels) of the dashes when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Dashed"/>.</summary>
        /// <param name="width">Dash length in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextUnderlineDashedWidth(int width);

        /// <summary>Length (in pixels) of the gaps between the dashes when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Dashed"/>.</summary>
        /// <returns>Gap length in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        int GetTextUnderlineDashedGap();

        /// <summary>Length (in pixels) of the gaps between the dashes when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Dashed"/>.</summary>
        /// <param name="gap">Gap length in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextUnderlineDashedGap(int gap);

        /// <summary>Color of the secondary underline. Only valid when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Double"/>. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetTextSecondaryUnderlineColor(out byte r, out byte g, out byte b, out byte a);

        /// <summary>Color of the secondary underline. Only valid when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Double"/>. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextSecondaryUnderlineColor(byte r, byte g, byte b, byte a);

        /// <summary>Enables crossed-out text.</summary>
        /// <returns>Strike-through type.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextStyleStrikethroughType GetTextStrikethroughType();

        /// <summary>Enables crossed-out text.</summary>
        /// <param name="type">Strike-through type.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextStrikethroughType(CoreUI.TextStyleStrikethroughType type);

        /// <summary>Color of the line striking through the text. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetTextStrikethroughColor(out byte r, out byte g, out byte b, out byte a);

        /// <summary>Color of the line striking through the text. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextStrikethroughColor(byte r, byte g, byte b, byte a);

        /// <summary>Controls a number of decorations around the text, like shadow, outline and glow, including combinations of them.</summary>
        /// <returns>Effect type.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextStyleEffectType GetTextEffectType();

        /// <summary>Controls a number of decorations around the text, like shadow, outline and glow, including combinations of them.</summary>
        /// <param name="type">Effect type.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextEffectType(CoreUI.TextStyleEffectType type);

        /// <summary>Color of the text outline. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetTextOutlineColor(out byte r, out byte g, out byte b, out byte a);

        /// <summary>Color of the text outline. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextOutlineColor(byte r, byte g, byte b, byte a);

        /// <summary>Direction of the shadow effect.</summary>
        /// <returns>Shadow direction.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextStyleShadowDirection GetTextShadowDirection();

        /// <summary>Direction of the shadow effect.</summary>
        /// <param name="type">Shadow direction.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextShadowDirection(CoreUI.TextStyleShadowDirection type);

        /// <summary>Color of the text shadow. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetTextShadowColor(out byte r, out byte g, out byte b, out byte a);

        /// <summary>Color of the text shadow. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextShadowColor(byte r, byte g, byte b, byte a);

        /// <summary>Color of the text glow. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetTextGlowColor(out byte r, out byte g, out byte b, out byte a);

        /// <summary>Color of the text glow. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextGlowColor(byte r, byte g, byte b, byte a);

        /// <summary>Color of the secondary glow decoration. This is the color of the inner glow (where it touches the text) which gradually fades into <see cref="CoreUI.ITextStyle.TextGlowColor"/> as it reaches the outer edge. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetTextSecondaryGlowColor(out byte r, out byte g, out byte b, out byte a);

        /// <summary>Color of the secondary glow decoration. This is the color of the inner glow (where it touches the text) which gradually fades into <see cref="CoreUI.ITextStyle.TextGlowColor"/> as it reaches the outer edge. By default it is invisible.</summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextSecondaryGlowColor(byte r, byte g, byte b, byte a);

        /// <summary>Program that applies a special filter
        /// 
        /// See <span class="text-muted">CoreUI.Gfx.IFilter (object still in beta stage)</span>.</summary>
        /// <returns>Filter code.</returns>
        /// <since_tizen> 6 </since_tizen>
        System.String GetTextGfxFilter();

        /// <summary>Program that applies a special filter
        /// 
        /// See <span class="text-muted">CoreUI.Gfx.IFilter (object still in beta stage)</span>.</summary>
        /// <param name="code">Filter code.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetTextGfxFilter(System.String code);

        /// <summary>Color of text, excluding all other decorations. By default it is invisible.</summary>
        /// <value>Red component.</value>
        /// <since_tizen> 6 </since_tizen>
        (byte, byte, byte, byte) TextColor {
            get;
            set;
        }

        /// <summary>Type of background to use behind each line of text.</summary>
        /// <value>Background type.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextStyleBackgroundType TextBackgroundType {
            get;
            set;
        }

        /// <summary>Color of the background behind each line of text. By default it is invisible.</summary>
        /// <value>Red component.</value>
        /// <since_tizen> 6 </since_tizen>
        (byte, byte, byte, byte) TextBackgroundColor {
            get;
            set;
        }

        /// <summary>Type of underline to use for the text.</summary>
        /// <value>Underline type.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextStyleUnderlineType TextUnderlineType {
            get;
            set;
        }

        /// <summary>Color of the primary underline. By default it is invisible.</summary>
        /// <value>Red component.</value>
        /// <since_tizen> 6 </since_tizen>
        (byte, byte, byte, byte) TextUnderlineColor {
            get;
            set;
        }

        /// <summary>Width (in pixels) of the single underline when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Single"/>.</summary>
        /// <value>Underline width in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        double TextUnderlineHeight {
            get;
            set;
        }

        /// <summary>Color of the dashed underline. Only valid when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Dashed"/>. By default it is invisible.</summary>
        /// <value>Red component.</value>
        /// <since_tizen> 6 </since_tizen>
        (byte, byte, byte, byte) TextUnderlineDashedColor {
            get;
            set;
        }

        /// <summary>Length (in pixels) of the dashes when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Dashed"/>.</summary>
        /// <value>Dash length in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        int TextUnderlineDashedWidth {
            get;
            set;
        }

        /// <summary>Length (in pixels) of the gaps between the dashes when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Dashed"/>.</summary>
        /// <value>Gap length in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        int TextUnderlineDashedGap {
            get;
            set;
        }

        /// <summary>Color of the secondary underline. Only valid when <see cref="CoreUI.ITextStyle.TextUnderlineType"/> is <see cref="CoreUI.TextStyleUnderlineType.Double"/>. By default it is invisible.</summary>
        /// <value>Red component.</value>
        /// <since_tizen> 6 </since_tizen>
        (byte, byte, byte, byte) TextSecondaryUnderlineColor {
            get;
            set;
        }

        /// <summary>Enables crossed-out text.</summary>
        /// <value>Strike-through type.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextStyleStrikethroughType TextStrikethroughType {
            get;
            set;
        }

        /// <summary>Color of the line striking through the text. By default it is invisible.</summary>
        /// <value>Red component.</value>
        /// <since_tizen> 6 </since_tizen>
        (byte, byte, byte, byte) TextStrikethroughColor {
            get;
            set;
        }

        /// <summary>Controls a number of decorations around the text, like shadow, outline and glow, including combinations of them.</summary>
        /// <value>Effect type.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextStyleEffectType TextEffectType {
            get;
            set;
        }

        /// <summary>Color of the text outline. By default it is invisible.</summary>
        /// <value>Red component.</value>
        /// <since_tizen> 6 </since_tizen>
        (byte, byte, byte, byte) TextOutlineColor {
            get;
            set;
        }

        /// <summary>Direction of the shadow effect.</summary>
        /// <value>Shadow direction.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.TextStyleShadowDirection TextShadowDirection {
            get;
            set;
        }

        /// <summary>Color of the text shadow. By default it is invisible.</summary>
        /// <value>Red component.</value>
        /// <since_tizen> 6 </since_tizen>
        (byte, byte, byte, byte) TextShadowColor {
            get;
            set;
        }

        /// <summary>Color of the text glow. By default it is invisible.</summary>
        /// <value>Red component.</value>
        /// <since_tizen> 6 </since_tizen>
        (byte, byte, byte, byte) TextGlowColor {
            get;
            set;
        }

        /// <summary>Color of the secondary glow decoration. This is the color of the inner glow (where it touches the text) which gradually fades into <see cref="CoreUI.ITextStyle.TextGlowColor"/> as it reaches the outer edge. By default it is invisible.</summary>
        /// <value>Red component.</value>
        /// <since_tizen> 6 </since_tizen>
        (byte, byte, byte, byte) TextSecondaryGlowColor {
            get;
            set;
        }

        /// <summary>Program that applies a special filter
        /// 
        /// See <span class="text-muted">CoreUI.Gfx.IFilter (object still in beta stage)</span>.</summary>
        /// <value>Filter code.</value>
        /// <since_tizen> 6 </since_tizen>
        System.String TextGfxFilter {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ITextStyleNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_text_style_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_text_color_get_static_delegate == null)
            {
                efl_text_color_get_static_delegate = new efl_text_color_get_delegate(text_color_get);
            }

            if (methods.Contains("GetTextColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_color_get_static_delegate) });
            }

            if (efl_text_color_set_static_delegate == null)
            {
                efl_text_color_set_static_delegate = new efl_text_color_set_delegate(text_color_set);
            }

            if (methods.Contains("SetTextColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_color_set_static_delegate) });
            }

            if (efl_text_background_type_get_static_delegate == null)
            {
                efl_text_background_type_get_static_delegate = new efl_text_background_type_get_delegate(text_background_type_get);
            }

            if (methods.Contains("GetTextBackgroundType"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_background_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_background_type_get_static_delegate) });
            }

            if (efl_text_background_type_set_static_delegate == null)
            {
                efl_text_background_type_set_static_delegate = new efl_text_background_type_set_delegate(text_background_type_set);
            }

            if (methods.Contains("SetTextBackgroundType"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_background_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_background_type_set_static_delegate) });
            }

            if (efl_text_background_color_get_static_delegate == null)
            {
                efl_text_background_color_get_static_delegate = new efl_text_background_color_get_delegate(text_background_color_get);
            }

            if (methods.Contains("GetTextBackgroundColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_background_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_background_color_get_static_delegate) });
            }

            if (efl_text_background_color_set_static_delegate == null)
            {
                efl_text_background_color_set_static_delegate = new efl_text_background_color_set_delegate(text_background_color_set);
            }

            if (methods.Contains("SetTextBackgroundColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_background_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_background_color_set_static_delegate) });
            }

            if (efl_text_underline_type_get_static_delegate == null)
            {
                efl_text_underline_type_get_static_delegate = new efl_text_underline_type_get_delegate(text_underline_type_get);
            }

            if (methods.Contains("GetTextUnderlineType"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_get_static_delegate) });
            }

            if (efl_text_underline_type_set_static_delegate == null)
            {
                efl_text_underline_type_set_static_delegate = new efl_text_underline_type_set_delegate(text_underline_type_set);
            }

            if (methods.Contains("SetTextUnderlineType"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_set_static_delegate) });
            }

            if (efl_text_underline_color_get_static_delegate == null)
            {
                efl_text_underline_color_get_static_delegate = new efl_text_underline_color_get_delegate(text_underline_color_get);
            }

            if (methods.Contains("GetTextUnderlineColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_get_static_delegate) });
            }

            if (efl_text_underline_color_set_static_delegate == null)
            {
                efl_text_underline_color_set_static_delegate = new efl_text_underline_color_set_delegate(text_underline_color_set);
            }

            if (methods.Contains("SetTextUnderlineColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_set_static_delegate) });
            }

            if (efl_text_underline_height_get_static_delegate == null)
            {
                efl_text_underline_height_get_static_delegate = new efl_text_underline_height_get_delegate(text_underline_height_get);
            }

            if (methods.Contains("GetTextUnderlineHeight"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_height_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_get_static_delegate) });
            }

            if (efl_text_underline_height_set_static_delegate == null)
            {
                efl_text_underline_height_set_static_delegate = new efl_text_underline_height_set_delegate(text_underline_height_set);
            }

            if (methods.Contains("SetTextUnderlineHeight"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_height_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_set_static_delegate) });
            }

            if (efl_text_underline_dashed_color_get_static_delegate == null)
            {
                efl_text_underline_dashed_color_get_static_delegate = new efl_text_underline_dashed_color_get_delegate(text_underline_dashed_color_get);
            }

            if (methods.Contains("GetTextUnderlineDashedColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_get_static_delegate) });
            }

            if (efl_text_underline_dashed_color_set_static_delegate == null)
            {
                efl_text_underline_dashed_color_set_static_delegate = new efl_text_underline_dashed_color_set_delegate(text_underline_dashed_color_set);
            }

            if (methods.Contains("SetTextUnderlineDashedColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_set_static_delegate) });
            }

            if (efl_text_underline_dashed_width_get_static_delegate == null)
            {
                efl_text_underline_dashed_width_get_static_delegate = new efl_text_underline_dashed_width_get_delegate(text_underline_dashed_width_get);
            }

            if (methods.Contains("GetTextUnderlineDashedWidth"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_get_static_delegate) });
            }

            if (efl_text_underline_dashed_width_set_static_delegate == null)
            {
                efl_text_underline_dashed_width_set_static_delegate = new efl_text_underline_dashed_width_set_delegate(text_underline_dashed_width_set);
            }

            if (methods.Contains("SetTextUnderlineDashedWidth"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_set_static_delegate) });
            }

            if (efl_text_underline_dashed_gap_get_static_delegate == null)
            {
                efl_text_underline_dashed_gap_get_static_delegate = new efl_text_underline_dashed_gap_get_delegate(text_underline_dashed_gap_get);
            }

            if (methods.Contains("GetTextUnderlineDashedGap"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_gap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_get_static_delegate) });
            }

            if (efl_text_underline_dashed_gap_set_static_delegate == null)
            {
                efl_text_underline_dashed_gap_set_static_delegate = new efl_text_underline_dashed_gap_set_delegate(text_underline_dashed_gap_set);
            }

            if (methods.Contains("SetTextUnderlineDashedGap"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_gap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_set_static_delegate) });
            }

            if (efl_text_secondary_underline_color_get_static_delegate == null)
            {
                efl_text_secondary_underline_color_get_static_delegate = new efl_text_secondary_underline_color_get_delegate(text_secondary_underline_color_get);
            }

            if (methods.Contains("GetTextSecondaryUnderlineColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_secondary_underline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_secondary_underline_color_get_static_delegate) });
            }

            if (efl_text_secondary_underline_color_set_static_delegate == null)
            {
                efl_text_secondary_underline_color_set_static_delegate = new efl_text_secondary_underline_color_set_delegate(text_secondary_underline_color_set);
            }

            if (methods.Contains("SetTextSecondaryUnderlineColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_secondary_underline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_secondary_underline_color_set_static_delegate) });
            }

            if (efl_text_strikethrough_type_get_static_delegate == null)
            {
                efl_text_strikethrough_type_get_static_delegate = new efl_text_strikethrough_type_get_delegate(text_strikethrough_type_get);
            }

            if (methods.Contains("GetTextStrikethroughType"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_strikethrough_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_get_static_delegate) });
            }

            if (efl_text_strikethrough_type_set_static_delegate == null)
            {
                efl_text_strikethrough_type_set_static_delegate = new efl_text_strikethrough_type_set_delegate(text_strikethrough_type_set);
            }

            if (methods.Contains("SetTextStrikethroughType"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_strikethrough_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_set_static_delegate) });
            }

            if (efl_text_strikethrough_color_get_static_delegate == null)
            {
                efl_text_strikethrough_color_get_static_delegate = new efl_text_strikethrough_color_get_delegate(text_strikethrough_color_get);
            }

            if (methods.Contains("GetTextStrikethroughColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_strikethrough_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_get_static_delegate) });
            }

            if (efl_text_strikethrough_color_set_static_delegate == null)
            {
                efl_text_strikethrough_color_set_static_delegate = new efl_text_strikethrough_color_set_delegate(text_strikethrough_color_set);
            }

            if (methods.Contains("SetTextStrikethroughColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_strikethrough_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_set_static_delegate) });
            }

            if (efl_text_effect_type_get_static_delegate == null)
            {
                efl_text_effect_type_get_static_delegate = new efl_text_effect_type_get_delegate(text_effect_type_get);
            }

            if (methods.Contains("GetTextEffectType"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_effect_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_get_static_delegate) });
            }

            if (efl_text_effect_type_set_static_delegate == null)
            {
                efl_text_effect_type_set_static_delegate = new efl_text_effect_type_set_delegate(text_effect_type_set);
            }

            if (methods.Contains("SetTextEffectType"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_effect_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_set_static_delegate) });
            }

            if (efl_text_outline_color_get_static_delegate == null)
            {
                efl_text_outline_color_get_static_delegate = new efl_text_outline_color_get_delegate(text_outline_color_get);
            }

            if (methods.Contains("GetTextOutlineColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_outline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_get_static_delegate) });
            }

            if (efl_text_outline_color_set_static_delegate == null)
            {
                efl_text_outline_color_set_static_delegate = new efl_text_outline_color_set_delegate(text_outline_color_set);
            }

            if (methods.Contains("SetTextOutlineColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_outline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_set_static_delegate) });
            }

            if (efl_text_shadow_direction_get_static_delegate == null)
            {
                efl_text_shadow_direction_get_static_delegate = new efl_text_shadow_direction_get_delegate(text_shadow_direction_get);
            }

            if (methods.Contains("GetTextShadowDirection"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_shadow_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_get_static_delegate) });
            }

            if (efl_text_shadow_direction_set_static_delegate == null)
            {
                efl_text_shadow_direction_set_static_delegate = new efl_text_shadow_direction_set_delegate(text_shadow_direction_set);
            }

            if (methods.Contains("SetTextShadowDirection"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_shadow_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_set_static_delegate) });
            }

            if (efl_text_shadow_color_get_static_delegate == null)
            {
                efl_text_shadow_color_get_static_delegate = new efl_text_shadow_color_get_delegate(text_shadow_color_get);
            }

            if (methods.Contains("GetTextShadowColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_shadow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_get_static_delegate) });
            }

            if (efl_text_shadow_color_set_static_delegate == null)
            {
                efl_text_shadow_color_set_static_delegate = new efl_text_shadow_color_set_delegate(text_shadow_color_set);
            }

            if (methods.Contains("SetTextShadowColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_shadow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_set_static_delegate) });
            }

            if (efl_text_glow_color_get_static_delegate == null)
            {
                efl_text_glow_color_get_static_delegate = new efl_text_glow_color_get_delegate(text_glow_color_get);
            }

            if (methods.Contains("GetTextGlowColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_glow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_get_static_delegate) });
            }

            if (efl_text_glow_color_set_static_delegate == null)
            {
                efl_text_glow_color_set_static_delegate = new efl_text_glow_color_set_delegate(text_glow_color_set);
            }

            if (methods.Contains("SetTextGlowColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_glow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_set_static_delegate) });
            }

            if (efl_text_secondary_glow_color_get_static_delegate == null)
            {
                efl_text_secondary_glow_color_get_static_delegate = new efl_text_secondary_glow_color_get_delegate(text_secondary_glow_color_get);
            }

            if (methods.Contains("GetTextSecondaryGlowColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_secondary_glow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_secondary_glow_color_get_static_delegate) });
            }

            if (efl_text_secondary_glow_color_set_static_delegate == null)
            {
                efl_text_secondary_glow_color_set_static_delegate = new efl_text_secondary_glow_color_set_delegate(text_secondary_glow_color_set);
            }

            if (methods.Contains("SetTextSecondaryGlowColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_secondary_glow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_secondary_glow_color_set_static_delegate) });
            }

            if (efl_text_gfx_filter_get_static_delegate == null)
            {
                efl_text_gfx_filter_get_static_delegate = new efl_text_gfx_filter_get_delegate(text_gfx_filter_get);
            }

            if (methods.Contains("GetTextGfxFilter"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_gfx_filter_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_get_static_delegate) });
            }

            if (efl_text_gfx_filter_set_static_delegate == null)
            {
                efl_text_gfx_filter_set_static_delegate = new efl_text_gfx_filter_set_delegate(text_gfx_filter_set);
            }

            if (methods.Contains("SetTextGfxFilter"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_gfx_filter_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_set_static_delegate) });
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
            return efl_text_style_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_text_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        internal delegate void efl_text_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_color_get_api_delegate> efl_text_color_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_color_get_api_delegate>(Module, "efl_text_color_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_color_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(byte);g = default(byte);b = default(byte);a = default(byte);
                try
                {
                    ((ITextStyle)ws.Target).GetTextColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_color_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_color_get_delegate efl_text_color_get_static_delegate;

        
        private delegate void efl_text_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        internal delegate void efl_text_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_color_set_api_delegate> efl_text_color_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_color_set_api_delegate>(Module, "efl_text_color_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_color_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_color_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), r, g, b, a);
            }
        }

        private static efl_text_color_set_delegate efl_text_color_set_static_delegate;

        
        private delegate CoreUI.TextStyleBackgroundType efl_text_background_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.TextStyleBackgroundType efl_text_background_type_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_background_type_get_api_delegate> efl_text_background_type_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_background_type_get_api_delegate>(Module, "efl_text_background_type_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.TextStyleBackgroundType text_background_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_background_type_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.TextStyleBackgroundType _ret_var = default(CoreUI.TextStyleBackgroundType);
                try
                {
                    _ret_var = ((ITextStyle)ws.Target).GetTextBackgroundType();
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
                return efl_text_background_type_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_background_type_get_delegate efl_text_background_type_get_static_delegate;

        
        private delegate void efl_text_background_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TextStyleBackgroundType type);

        
        internal delegate void efl_text_background_type_set_api_delegate(System.IntPtr obj,  CoreUI.TextStyleBackgroundType type);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_background_type_set_api_delegate> efl_text_background_type_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_background_type_set_api_delegate>(Module, "efl_text_background_type_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_background_type_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TextStyleBackgroundType type)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_background_type_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextBackgroundType(type);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_background_type_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), type);
            }
        }

        private static efl_text_background_type_set_delegate efl_text_background_type_set_static_delegate;

        
        private delegate void efl_text_background_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        internal delegate void efl_text_background_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_background_color_get_api_delegate> efl_text_background_color_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_background_color_get_api_delegate>(Module, "efl_text_background_color_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_background_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_background_color_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(byte);g = default(byte);b = default(byte);a = default(byte);
                try
                {
                    ((ITextStyle)ws.Target).GetTextBackgroundColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_background_color_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_background_color_get_delegate efl_text_background_color_get_static_delegate;

        
        private delegate void efl_text_background_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        internal delegate void efl_text_background_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_background_color_set_api_delegate> efl_text_background_color_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_background_color_set_api_delegate>(Module, "efl_text_background_color_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_background_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_background_color_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextBackgroundColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_background_color_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), r, g, b, a);
            }
        }

        private static efl_text_background_color_set_delegate efl_text_background_color_set_static_delegate;

        
        private delegate CoreUI.TextStyleUnderlineType efl_text_underline_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.TextStyleUnderlineType efl_text_underline_type_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_underline_type_get_api_delegate> efl_text_underline_type_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_underline_type_get_api_delegate>(Module, "efl_text_underline_type_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.TextStyleUnderlineType text_underline_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_underline_type_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.TextStyleUnderlineType _ret_var = default(CoreUI.TextStyleUnderlineType);
                try
                {
                    _ret_var = ((ITextStyle)ws.Target).GetTextUnderlineType();
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
                return efl_text_underline_type_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_underline_type_get_delegate efl_text_underline_type_get_static_delegate;

        
        private delegate void efl_text_underline_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TextStyleUnderlineType type);

        
        internal delegate void efl_text_underline_type_set_api_delegate(System.IntPtr obj,  CoreUI.TextStyleUnderlineType type);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_underline_type_set_api_delegate> efl_text_underline_type_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_underline_type_set_api_delegate>(Module, "efl_text_underline_type_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_underline_type_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TextStyleUnderlineType type)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_underline_type_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextUnderlineType(type);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_underline_type_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), type);
            }
        }

        private static efl_text_underline_type_set_delegate efl_text_underline_type_set_static_delegate;

        
        private delegate void efl_text_underline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        internal delegate void efl_text_underline_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_underline_color_get_api_delegate> efl_text_underline_color_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_underline_color_get_api_delegate>(Module, "efl_text_underline_color_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_underline_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_underline_color_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(byte);g = default(byte);b = default(byte);a = default(byte);
                try
                {
                    ((ITextStyle)ws.Target).GetTextUnderlineColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_underline_color_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_underline_color_get_delegate efl_text_underline_color_get_static_delegate;

        
        private delegate void efl_text_underline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        internal delegate void efl_text_underline_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_underline_color_set_api_delegate> efl_text_underline_color_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_underline_color_set_api_delegate>(Module, "efl_text_underline_color_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_underline_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_underline_color_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextUnderlineColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_underline_color_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), r, g, b, a);
            }
        }

        private static efl_text_underline_color_set_delegate efl_text_underline_color_set_static_delegate;

        
        private delegate double efl_text_underline_height_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_text_underline_height_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_underline_height_get_api_delegate> efl_text_underline_height_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_underline_height_get_api_delegate>(Module, "efl_text_underline_height_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double text_underline_height_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_underline_height_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((ITextStyle)ws.Target).GetTextUnderlineHeight();
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
                return efl_text_underline_height_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_underline_height_get_delegate efl_text_underline_height_get_static_delegate;

        
        private delegate void efl_text_underline_height_set_delegate(System.IntPtr obj, System.IntPtr pd,  double height);

        
        internal delegate void efl_text_underline_height_set_api_delegate(System.IntPtr obj,  double height);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_underline_height_set_api_delegate> efl_text_underline_height_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_underline_height_set_api_delegate>(Module, "efl_text_underline_height_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_underline_height_set(System.IntPtr obj, System.IntPtr pd, double height)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_underline_height_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextUnderlineHeight(height);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_underline_height_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), height);
            }
        }

        private static efl_text_underline_height_set_delegate efl_text_underline_height_set_static_delegate;

        
        private delegate void efl_text_underline_dashed_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        internal delegate void efl_text_underline_dashed_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_underline_dashed_color_get_api_delegate> efl_text_underline_dashed_color_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_underline_dashed_color_get_api_delegate>(Module, "efl_text_underline_dashed_color_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_underline_dashed_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_underline_dashed_color_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(byte);g = default(byte);b = default(byte);a = default(byte);
                try
                {
                    ((ITextStyle)ws.Target).GetTextUnderlineDashedColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_underline_dashed_color_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_underline_dashed_color_get_delegate efl_text_underline_dashed_color_get_static_delegate;

        
        private delegate void efl_text_underline_dashed_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        internal delegate void efl_text_underline_dashed_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_underline_dashed_color_set_api_delegate> efl_text_underline_dashed_color_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_underline_dashed_color_set_api_delegate>(Module, "efl_text_underline_dashed_color_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_underline_dashed_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_underline_dashed_color_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextUnderlineDashedColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_underline_dashed_color_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), r, g, b, a);
            }
        }

        private static efl_text_underline_dashed_color_set_delegate efl_text_underline_dashed_color_set_static_delegate;

        
        private delegate int efl_text_underline_dashed_width_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_text_underline_dashed_width_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_underline_dashed_width_get_api_delegate> efl_text_underline_dashed_width_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_underline_dashed_width_get_api_delegate>(Module, "efl_text_underline_dashed_width_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int text_underline_dashed_width_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_underline_dashed_width_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((ITextStyle)ws.Target).GetTextUnderlineDashedWidth();
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
                return efl_text_underline_dashed_width_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_underline_dashed_width_get_delegate efl_text_underline_dashed_width_get_static_delegate;

        
        private delegate void efl_text_underline_dashed_width_set_delegate(System.IntPtr obj, System.IntPtr pd,  int width);

        
        internal delegate void efl_text_underline_dashed_width_set_api_delegate(System.IntPtr obj,  int width);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_underline_dashed_width_set_api_delegate> efl_text_underline_dashed_width_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_underline_dashed_width_set_api_delegate>(Module, "efl_text_underline_dashed_width_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_underline_dashed_width_set(System.IntPtr obj, System.IntPtr pd, int width)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_underline_dashed_width_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextUnderlineDashedWidth(width);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_underline_dashed_width_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), width);
            }
        }

        private static efl_text_underline_dashed_width_set_delegate efl_text_underline_dashed_width_set_static_delegate;

        
        private delegate int efl_text_underline_dashed_gap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_text_underline_dashed_gap_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_underline_dashed_gap_get_api_delegate> efl_text_underline_dashed_gap_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_underline_dashed_gap_get_api_delegate>(Module, "efl_text_underline_dashed_gap_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int text_underline_dashed_gap_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_underline_dashed_gap_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((ITextStyle)ws.Target).GetTextUnderlineDashedGap();
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
                return efl_text_underline_dashed_gap_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_underline_dashed_gap_get_delegate efl_text_underline_dashed_gap_get_static_delegate;

        
        private delegate void efl_text_underline_dashed_gap_set_delegate(System.IntPtr obj, System.IntPtr pd,  int gap);

        
        internal delegate void efl_text_underline_dashed_gap_set_api_delegate(System.IntPtr obj,  int gap);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_underline_dashed_gap_set_api_delegate> efl_text_underline_dashed_gap_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_underline_dashed_gap_set_api_delegate>(Module, "efl_text_underline_dashed_gap_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_underline_dashed_gap_set(System.IntPtr obj, System.IntPtr pd, int gap)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_underline_dashed_gap_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextUnderlineDashedGap(gap);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_underline_dashed_gap_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), gap);
            }
        }

        private static efl_text_underline_dashed_gap_set_delegate efl_text_underline_dashed_gap_set_static_delegate;

        
        private delegate void efl_text_secondary_underline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        internal delegate void efl_text_secondary_underline_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_secondary_underline_color_get_api_delegate> efl_text_secondary_underline_color_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_secondary_underline_color_get_api_delegate>(Module, "efl_text_secondary_underline_color_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_secondary_underline_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_secondary_underline_color_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(byte);g = default(byte);b = default(byte);a = default(byte);
                try
                {
                    ((ITextStyle)ws.Target).GetTextSecondaryUnderlineColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_secondary_underline_color_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_secondary_underline_color_get_delegate efl_text_secondary_underline_color_get_static_delegate;

        
        private delegate void efl_text_secondary_underline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        internal delegate void efl_text_secondary_underline_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_secondary_underline_color_set_api_delegate> efl_text_secondary_underline_color_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_secondary_underline_color_set_api_delegate>(Module, "efl_text_secondary_underline_color_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_secondary_underline_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_secondary_underline_color_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextSecondaryUnderlineColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_secondary_underline_color_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), r, g, b, a);
            }
        }

        private static efl_text_secondary_underline_color_set_delegate efl_text_secondary_underline_color_set_static_delegate;

        
        private delegate CoreUI.TextStyleStrikethroughType efl_text_strikethrough_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.TextStyleStrikethroughType efl_text_strikethrough_type_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_strikethrough_type_get_api_delegate> efl_text_strikethrough_type_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_strikethrough_type_get_api_delegate>(Module, "efl_text_strikethrough_type_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.TextStyleStrikethroughType text_strikethrough_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_strikethrough_type_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.TextStyleStrikethroughType _ret_var = default(CoreUI.TextStyleStrikethroughType);
                try
                {
                    _ret_var = ((ITextStyle)ws.Target).GetTextStrikethroughType();
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
                return efl_text_strikethrough_type_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_strikethrough_type_get_delegate efl_text_strikethrough_type_get_static_delegate;

        
        private delegate void efl_text_strikethrough_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TextStyleStrikethroughType type);

        
        internal delegate void efl_text_strikethrough_type_set_api_delegate(System.IntPtr obj,  CoreUI.TextStyleStrikethroughType type);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_strikethrough_type_set_api_delegate> efl_text_strikethrough_type_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_strikethrough_type_set_api_delegate>(Module, "efl_text_strikethrough_type_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_strikethrough_type_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TextStyleStrikethroughType type)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_strikethrough_type_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextStrikethroughType(type);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_strikethrough_type_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), type);
            }
        }

        private static efl_text_strikethrough_type_set_delegate efl_text_strikethrough_type_set_static_delegate;

        
        private delegate void efl_text_strikethrough_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        internal delegate void efl_text_strikethrough_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_strikethrough_color_get_api_delegate> efl_text_strikethrough_color_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_strikethrough_color_get_api_delegate>(Module, "efl_text_strikethrough_color_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_strikethrough_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_strikethrough_color_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(byte);g = default(byte);b = default(byte);a = default(byte);
                try
                {
                    ((ITextStyle)ws.Target).GetTextStrikethroughColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_strikethrough_color_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_strikethrough_color_get_delegate efl_text_strikethrough_color_get_static_delegate;

        
        private delegate void efl_text_strikethrough_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        internal delegate void efl_text_strikethrough_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_strikethrough_color_set_api_delegate> efl_text_strikethrough_color_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_strikethrough_color_set_api_delegate>(Module, "efl_text_strikethrough_color_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_strikethrough_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_strikethrough_color_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextStrikethroughColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_strikethrough_color_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), r, g, b, a);
            }
        }

        private static efl_text_strikethrough_color_set_delegate efl_text_strikethrough_color_set_static_delegate;

        
        private delegate CoreUI.TextStyleEffectType efl_text_effect_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.TextStyleEffectType efl_text_effect_type_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_effect_type_get_api_delegate> efl_text_effect_type_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_effect_type_get_api_delegate>(Module, "efl_text_effect_type_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.TextStyleEffectType text_effect_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_effect_type_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.TextStyleEffectType _ret_var = default(CoreUI.TextStyleEffectType);
                try
                {
                    _ret_var = ((ITextStyle)ws.Target).GetTextEffectType();
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
                return efl_text_effect_type_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_effect_type_get_delegate efl_text_effect_type_get_static_delegate;

        
        private delegate void efl_text_effect_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TextStyleEffectType type);

        
        internal delegate void efl_text_effect_type_set_api_delegate(System.IntPtr obj,  CoreUI.TextStyleEffectType type);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_effect_type_set_api_delegate> efl_text_effect_type_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_effect_type_set_api_delegate>(Module, "efl_text_effect_type_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_effect_type_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TextStyleEffectType type)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_effect_type_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextEffectType(type);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_effect_type_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), type);
            }
        }

        private static efl_text_effect_type_set_delegate efl_text_effect_type_set_static_delegate;

        
        private delegate void efl_text_outline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        internal delegate void efl_text_outline_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_outline_color_get_api_delegate> efl_text_outline_color_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_outline_color_get_api_delegate>(Module, "efl_text_outline_color_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_outline_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_outline_color_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(byte);g = default(byte);b = default(byte);a = default(byte);
                try
                {
                    ((ITextStyle)ws.Target).GetTextOutlineColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_outline_color_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_outline_color_get_delegate efl_text_outline_color_get_static_delegate;

        
        private delegate void efl_text_outline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        internal delegate void efl_text_outline_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_outline_color_set_api_delegate> efl_text_outline_color_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_outline_color_set_api_delegate>(Module, "efl_text_outline_color_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_outline_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_outline_color_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextOutlineColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_outline_color_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), r, g, b, a);
            }
        }

        private static efl_text_outline_color_set_delegate efl_text_outline_color_set_static_delegate;

        
        private delegate CoreUI.TextStyleShadowDirection efl_text_shadow_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.TextStyleShadowDirection efl_text_shadow_direction_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_shadow_direction_get_api_delegate> efl_text_shadow_direction_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_shadow_direction_get_api_delegate>(Module, "efl_text_shadow_direction_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.TextStyleShadowDirection text_shadow_direction_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_shadow_direction_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.TextStyleShadowDirection _ret_var = default(CoreUI.TextStyleShadowDirection);
                try
                {
                    _ret_var = ((ITextStyle)ws.Target).GetTextShadowDirection();
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
                return efl_text_shadow_direction_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_shadow_direction_get_delegate efl_text_shadow_direction_get_static_delegate;

        
        private delegate void efl_text_shadow_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TextStyleShadowDirection type);

        
        internal delegate void efl_text_shadow_direction_set_api_delegate(System.IntPtr obj,  CoreUI.TextStyleShadowDirection type);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_shadow_direction_set_api_delegate> efl_text_shadow_direction_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_shadow_direction_set_api_delegate>(Module, "efl_text_shadow_direction_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_shadow_direction_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TextStyleShadowDirection type)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_shadow_direction_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextShadowDirection(type);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_shadow_direction_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), type);
            }
        }

        private static efl_text_shadow_direction_set_delegate efl_text_shadow_direction_set_static_delegate;

        
        private delegate void efl_text_shadow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        internal delegate void efl_text_shadow_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_shadow_color_get_api_delegate> efl_text_shadow_color_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_shadow_color_get_api_delegate>(Module, "efl_text_shadow_color_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_shadow_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_shadow_color_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(byte);g = default(byte);b = default(byte);a = default(byte);
                try
                {
                    ((ITextStyle)ws.Target).GetTextShadowColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_shadow_color_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_shadow_color_get_delegate efl_text_shadow_color_get_static_delegate;

        
        private delegate void efl_text_shadow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        internal delegate void efl_text_shadow_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_shadow_color_set_api_delegate> efl_text_shadow_color_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_shadow_color_set_api_delegate>(Module, "efl_text_shadow_color_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_shadow_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_shadow_color_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextShadowColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_shadow_color_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), r, g, b, a);
            }
        }

        private static efl_text_shadow_color_set_delegate efl_text_shadow_color_set_static_delegate;

        
        private delegate void efl_text_glow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        internal delegate void efl_text_glow_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_glow_color_get_api_delegate> efl_text_glow_color_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_glow_color_get_api_delegate>(Module, "efl_text_glow_color_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_glow_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_glow_color_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(byte);g = default(byte);b = default(byte);a = default(byte);
                try
                {
                    ((ITextStyle)ws.Target).GetTextGlowColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_glow_color_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_glow_color_get_delegate efl_text_glow_color_get_static_delegate;

        
        private delegate void efl_text_glow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        internal delegate void efl_text_glow_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_glow_color_set_api_delegate> efl_text_glow_color_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_glow_color_set_api_delegate>(Module, "efl_text_glow_color_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_glow_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_glow_color_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextGlowColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_glow_color_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), r, g, b, a);
            }
        }

        private static efl_text_glow_color_set_delegate efl_text_glow_color_set_static_delegate;

        
        private delegate void efl_text_secondary_glow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        internal delegate void efl_text_secondary_glow_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_secondary_glow_color_get_api_delegate> efl_text_secondary_glow_color_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_secondary_glow_color_get_api_delegate>(Module, "efl_text_secondary_glow_color_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_secondary_glow_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_secondary_glow_color_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(byte);g = default(byte);b = default(byte);a = default(byte);
                try
                {
                    ((ITextStyle)ws.Target).GetTextSecondaryGlowColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_secondary_glow_color_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_secondary_glow_color_get_delegate efl_text_secondary_glow_color_get_static_delegate;

        
        private delegate void efl_text_secondary_glow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        internal delegate void efl_text_secondary_glow_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_secondary_glow_color_set_api_delegate> efl_text_secondary_glow_color_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_secondary_glow_color_set_api_delegate>(Module, "efl_text_secondary_glow_color_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_secondary_glow_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_secondary_glow_color_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextSecondaryGlowColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_secondary_glow_color_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), r, g, b, a);
            }
        }

        private static efl_text_secondary_glow_color_set_delegate efl_text_secondary_glow_color_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_gfx_filter_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        internal delegate System.String efl_text_gfx_filter_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_gfx_filter_get_api_delegate> efl_text_gfx_filter_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_gfx_filter_get_api_delegate>(Module, "efl_text_gfx_filter_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.String text_gfx_filter_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_gfx_filter_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((ITextStyle)ws.Target).GetTextGfxFilter();
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
                return efl_text_gfx_filter_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_gfx_filter_get_delegate efl_text_gfx_filter_get_static_delegate;

        
        private delegate void efl_text_gfx_filter_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String code);

        
        internal delegate void efl_text_gfx_filter_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String code);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_gfx_filter_set_api_delegate> efl_text_gfx_filter_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_gfx_filter_set_api_delegate>(Module, "efl_text_gfx_filter_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_gfx_filter_set(System.IntPtr obj, System.IntPtr pd, System.String code)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_gfx_filter_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ITextStyle)ws.Target).SetTextGfxFilter(code);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_gfx_filter_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), code);
            }
        }

        private static efl_text_gfx_filter_set_delegate efl_text_gfx_filter_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class TextStyleExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextStyleBackgroundType> TextBackgroundType<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextStyle, T>magic = null) where T : CoreUI.ITextStyle {
            return new CoreUI.BindableProperty<CoreUI.TextStyleBackgroundType>("text_background_type", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextStyleUnderlineType> TextUnderlineType<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextStyle, T>magic = null) where T : CoreUI.ITextStyle {
            return new CoreUI.BindableProperty<CoreUI.TextStyleUnderlineType>("text_underline_type", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> TextUnderlineHeight<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextStyle, T>magic = null) where T : CoreUI.ITextStyle {
            return new CoreUI.BindableProperty<double>("text_underline_height", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> TextUnderlineDashedWidth<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextStyle, T>magic = null) where T : CoreUI.ITextStyle {
            return new CoreUI.BindableProperty<int>("text_underline_dashed_width", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> TextUnderlineDashedGap<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextStyle, T>magic = null) where T : CoreUI.ITextStyle {
            return new CoreUI.BindableProperty<int>("text_underline_dashed_gap", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextStyleStrikethroughType> TextStrikethroughType<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextStyle, T>magic = null) where T : CoreUI.ITextStyle {
            return new CoreUI.BindableProperty<CoreUI.TextStyleStrikethroughType>("text_strikethrough_type", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextStyleEffectType> TextEffectType<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextStyle, T>magic = null) where T : CoreUI.ITextStyle {
            return new CoreUI.BindableProperty<CoreUI.TextStyleEffectType>("text_effect_type", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextStyleShadowDirection> TextShadowDirection<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextStyle, T>magic = null) where T : CoreUI.ITextStyle {
            return new CoreUI.BindableProperty<CoreUI.TextStyleShadowDirection>("text_shadow_direction", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> TextGfxFilter<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.ITextStyle, T>magic = null) where T : CoreUI.ITextStyle {
            return new CoreUI.BindableProperty<System.String>("text_gfx_filter", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI {
    /// <summary>Type of background to use behind each line of text.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum TextStyleBackgroundType
    {
        /// <summary>Do not use background.</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>Use a solid-color rectangle as background. Requires <see cref="CoreUI.ITextStyle.TextBackgroundColor"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        SolidColor = 1,
    }
}

namespace CoreUI {
    /// <summary>Whether to add a strike-through decoration to the displayed text or not.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum TextStyleStrikethroughType
    {
        /// <summary>Do not use strike-through.</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>Strike-through with a single line. Requires <see cref="CoreUI.ITextStyle.TextStrikethroughColor"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        Single = 1,
    }
}

namespace CoreUI {
    /// <summary>Effect to apply to the displayed text.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum TextStyleEffectType
    {
        /// <summary>No effect.</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>Shadow effect. Uses <see cref="CoreUI.ITextStyle.TextShadowColor"/> and <see cref="CoreUI.ITextStyle.TextShadowDirection"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        Shadow = 1,
        /// <summary>Far shadow effect. Uses <see cref="CoreUI.ITextStyle.TextShadowColor"/> and <see cref="CoreUI.ITextStyle.TextShadowDirection"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        FarShadow = 2,
        /// <summary>Soft shadow effect. Uses <see cref="CoreUI.ITextStyle.TextShadowColor"/> and <see cref="CoreUI.ITextStyle.TextShadowDirection"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        SoftShadow = 3,
        /// <summary>Far and soft shadow effect. Uses <see cref="CoreUI.ITextStyle.TextShadowColor"/> and <see cref="CoreUI.ITextStyle.TextShadowDirection"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        FarSoftShadow = 4,
        /// <summary>Glow effect. Uses <see cref="CoreUI.ITextStyle.TextGlowColor"/> and <see cref="CoreUI.ITextStyle.TextSecondaryGlowColor"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        Glow = 5,
        /// <summary>Outline effect. Uses <see cref="CoreUI.ITextStyle.TextOutlineColor"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        Outline = 6,
        /// <summary>Soft outline effect. Uses <see cref="CoreUI.ITextStyle.TextOutlineColor"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        SoftOutline = 7,
        /// <summary>Outline + shadow effect. Uses <see cref="CoreUI.ITextStyle.TextShadowColor"/>, <see cref="CoreUI.ITextStyle.TextShadowDirection"/> and <see cref="CoreUI.ITextStyle.TextOutlineColor"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        OutlineShadow = 8,
        /// <summary>Outline + soft shadow effect. Uses <see cref="CoreUI.ITextStyle.TextShadowColor"/>, <see cref="CoreUI.ITextStyle.TextShadowDirection"/> and <see cref="CoreUI.ITextStyle.TextOutlineColor"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        OutlineSoftShadow = 9,
    }
}

namespace CoreUI {
    /// <summary>Direction of the shadow effect.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum TextStyleShadowDirection
    {
        /// <summary>Shadow towards bottom right.</summary>
        /// <since_tizen> 6 </since_tizen>
        BottomRight = 0,
        /// <summary>Shadow towards bottom.</summary>
        /// <since_tizen> 6 </since_tizen>
        Bottom = 1,
        /// <summary>Shadow towards bottom left.</summary>
        /// <since_tizen> 6 </since_tizen>
        BottomLeft = 2,
        /// <summary>Shadow towards left.</summary>
        /// <since_tizen> 6 </since_tizen>
        Left = 3,
        /// <summary>Shadow towards top left.</summary>
        /// <since_tizen> 6 </since_tizen>
        TopLeft = 4,
        /// <summary>Shadow towards top.</summary>
        /// <since_tizen> 6 </since_tizen>
        Top = 5,
        /// <summary>Shadow towards top right.</summary>
        /// <since_tizen> 6 </since_tizen>
        TopRight = 6,
        /// <summary>Shadow towards right.</summary>
        /// <since_tizen> 6 </since_tizen>
        Right = 7,
    }
}

namespace CoreUI {
    /// <summary>Type of underline for the displayed text.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum TextStyleUnderlineType
    {
        /// <summary>Text without underline.</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>Underlined with a single line. Requires <see cref="CoreUI.ITextStyle.TextUnderlineColor"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        Single = 1,
        /// <summary>Underlined with a double line. Requires <see cref="CoreUI.ITextStyle.TextUnderlineColor"/> and <see cref="CoreUI.ITextStyle.TextSecondaryUnderlineColor"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        Double = 2,
        /// <summary>Underlined with a dashed line. Requires <see cref="CoreUI.ITextStyle.TextUnderlineDashedColor"/>, <see cref="CoreUI.ITextStyle.TextUnderlineDashedWidth"/> and <see cref="CoreUI.ITextStyle.TextUnderlineDashedGap"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        Dashed = 3,
    }
}

