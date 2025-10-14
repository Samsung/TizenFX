/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ElmSharp
{
    /// <summary>
    /// Enumeration for describing the InputPanel layout types.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [Obsolete("This has been deprecated in API12")]
    public enum InputPanelLayout
    {
        /// <summary>
        /// The InputPanel layout type default.
        /// </summary>
        Normal,

        /// <summary>
        /// The InputPanel layout type number.
        /// </summary>
        Number,

        /// <summary>
        /// The InputPanel layout type email.
        /// </summary>
        Email,

        /// <summary>
        /// The InputPanel layout type URL.
        /// </summary>
        Url,

        /// <summary>
        /// The InputPanel layout type phone.
        /// </summary>
        PhoneNumber,

        /// <summary>
        /// The InputPanel layout type IP.
        /// </summary>
        Ip,

        /// <summary>
        /// The InputPanel layout type month.
        /// </summary>
        Month,

        /// <summary>
        /// The InputPanel layout type number.
        /// </summary>
        NumberOnly,

        /// <summary>
        /// The InputPanel layout type error type. Do not use it directly!
        /// </summary>
        Invalid,

        /// <summary>
        /// The InputPanel layout type hexadecimal.
        /// </summary>
        Hex,

        /// <summary>
        /// The InputPanel layout type terminal type: Esc, Alt, Ctrl, etc.
        /// </summary>
        Terminal,

        /// <summary>
        /// The InputPanel layout type password.
        /// </summary>
        Password,

        /// <summary>
        /// The keyboard layout type date and time.
        /// </summary>
        DateTime,

        /// <summary>
        /// The InputPanel layout type emoticons.
        /// </summary>
        Emoticon
    }

    /// <summary>
    /// Enumeration for defining the "Return" key types on the input panel (virtual keyboard).
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [Obsolete("This has been deprecated in API12")]
    public enum InputPanelReturnKeyType
    {
        /// <summary>
        /// The Default key type.
        /// </summary>
        Default,

        /// <summary>
        /// The Done key type.
        /// </summary>
        Done,

        /// <summary>
        /// The Go key type.
        /// </summary>
        Go,

        /// <summary>
        /// The Join key type.
        /// </summary>
        Join,

        /// <summary>
        /// The Login key type.
        /// </summary>
        Login,

        /// <summary>
        /// The Next key type.
        /// </summary>
        Next,

        /// <summary>
        /// The Search string or magnifier icon key type.
        /// </summary>
        Search,

        /// <summary>
        /// The Send key type.
        /// </summary>
        Send,

        /// <summary>
        /// The Sign-in key type.
        /// </summary>
        Signin
    }

    /// <summary>
    /// Enumeration for defining the autocapitalization types.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [Obsolete("This has been deprecated in API12")]
    public enum AutoCapital
    {
        /// <summary>
        /// No autocapitalization when typing.
        /// </summary>
        None,

        /// <summary>
        /// Autocapitalize each of the typed word.
        /// </summary>
        Word,

        /// <summary>
        /// Autocapitalize the start of each sentence.
        /// </summary>
        Sentence,

        /// <summary>
        /// Autocapitalize all the letters.
        /// </summary>
        All
    }

    /// <summary>
    /// Enumeration for defining the entry's copy and paste policy.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [Obsolete("This has been deprecated in API12")]
    public enum CopyAndPasteMode
    {
        /// <summary>
        /// Copy and paste text with a markup tag.
        /// </summary>
        Markup,

        /// <summary>
        /// Copy and paste text without an item (image) tag.
        /// </summary>
        NoImage,

        /// <summary>
        /// Copy and paste text without a markup tag.
        /// </summary>
        PlainText
    }

    /// <summary>
    /// Enumeration for the text format types.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [Obsolete("This has been deprecated in API12")]
    public enum TextFormat
    {
        /// <summary>
        /// Plain type.
        /// </summary>
        Plain,

        /// <summary>
        /// Markup type.
        /// </summary>
        Markup
    }

    /// <summary>
    /// Enumeration that defines the types of Input Hints.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [Obsolete("This has been deprecated in API12")]
    public enum InputHints
    {
        /// <summary>
        /// No active hints.
        /// </summary>
        None,

        /// <summary>
        /// Suggest word auto-completion.
        /// </summary>
        AutoComplete,

        /// <summary>
        /// The typed text should not be stored.
        /// </summary>
        SensitiveData,
    }

    /// <summary>
    /// Enumeration for defining the input panel (virtual keyboard) language modes.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [Obsolete("This has been deprecated in API12")]
    public enum InputPanelLanguage
    {
        /// <summary>
        /// Automatic language mode.
        /// </summary>
        Automatic,

        /// <summary>
        /// Alphabet language mode.
        /// </summary>
        Alphabet,
    }

    /// <summary>
    /// The Entry is a convenience widget that shows a box in which the user can enter text.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [Obsolete("This has been deprecated in API12")]
    public class Entry : Layout
    {
        SmartEvent _clicked;
        SmartEvent _changedByUser;
        SmartEvent _cursorChanged;
        SmartEvent _activated;

        Dictionary<Func<string, EvasObject>, Interop.Elementary.Elm_Entry_Item_Provider_Cb> _itemsProvider = new Dictionary<Func<string, EvasObject>, Interop.Elementary.Elm_Entry_Item_Provider_Cb>();
        Dictionary<Func<Entry, string, string>, Interop.Elementary.Elm_Entry_Filter_Cb> _textFilters = new Dictionary<Func<Entry, string, string>, Interop.Elementary.Elm_Entry_Filter_Cb>();

        /// <summary>
        /// Creates and initializes a new instance of the Entry class.
        /// </summary>
        /// <param name="parent">The EvasObject to which the new Entry will be attached as a child.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public Entry(EvasObject parent) : base(parent)
        {
            _clicked = new SmartEvent(this, this.RealHandle, "clicked");
            _clicked.On += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);

            _changedByUser = new SmartEvent(this, this.RealHandle, "changed,user");
            _changedByUser.On += (s, e) => ChangedByUser?.Invoke(this, EventArgs.Empty);

            _cursorChanged = new SmartEvent(this, this.RealHandle, "cursor,changed");
            _cursorChanged.On += (s, e) => CursorChanged?.Invoke(this, EventArgs.Empty);

            _activated = new SmartEvent(this, this.RealHandle, "activated");
            _activated.On += (s, e) => Activated?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Activated will be triggered when the entry is activated.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public event EventHandler Activated;

        /// <summary>
        /// Clicked will be triggered when the entry is clicked.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public event EventHandler Clicked;

        /// <summary>
        /// ChangedByUser will be triggered when the entry is changed by user.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public event EventHandler ChangedByUser;

        /// <summary>
        /// CursorChanged will be triggered when the cursor in the entry is changed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public event EventHandler CursorChanged;

        /// <summary>
        /// Sets or gets the entry to the single line mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool IsSingleLine
        {
            get
            {
                return Interop.Elementary.elm_entry_single_line_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_single_line_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the entry to the password mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool IsPassword
        {
            get
            {
                return Interop.Elementary.elm_entry_password_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_password_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether the entry is editable.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool IsEditable
        {
            get
            {
                return Interop.Elementary.elm_entry_editable_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_editable_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether the entry is empty.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool IsEmpty
        {
            get
            {
                return Interop.Elementary.elm_entry_is_empty(RealHandle);
            }
        }

        /// <summary>
        /// Sets or gets the text currently shown in the object entry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public override string Text
        {
            get
            {
                return Interop.Elementary.elm_entry_entry_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_entry_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the style on top of the user style stack.
        /// </summary>
        /// <remarks>If there are styles in the user style stack, the properties in the top style of the user style stack will replace the properties in current theme. The input style is specified in the format, tag='property=value' (i.e., DEFAULT='font=Sans font_size=60'hilight=' + font_weight=Bold').</remarks>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public string TextStyle
        {
            get
            {
                return Interop.Elementary.elm_entry_text_style_user_peek(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_text_style_user_push(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the current position of the cursor in the entry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public int CursorPosition
        {
            get
            {
                return Interop.Elementary.elm_entry_cursor_pos_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_cursor_pos_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the scrollable state of the entry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool Scrollable
        {
            get
            {
                return Interop.Elementary.elm_entry_scrollable_get(RealHandle);
            }
            set
            {
                // HACK: Enabling the scrollable property of an entry causes its internal
                //       hierarchy to change, making the internal edje object inaccessible.
                //       Access it before the property is set, to cache the edje object's handle.
                if (value)
                {
                    var dummy = EdjeObject;
                }
                Interop.Elementary.elm_entry_scrollable_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the autocapitalization type on the immodule.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public AutoCapital AutoCapital
        {
            get
            {
                return (AutoCapital)Interop.Elementary.elm_entry_autocapital_type_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_autocapital_type_set(RealHandle, (Interop.Elementary.AutocapitalType)value);
            }
        }

        /// <summary>
        /// Sets or gets the entry object's 'autosave' status.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool IsAutoSave
        {
            get
            {
                return Interop.Elementary.elm_entry_autosave_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_autosave_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the entry text paste/drop mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public CopyAndPasteMode CopyAndPasteMode
        {
            get
            {
                return (CopyAndPasteMode)Interop.Elementary.elm_entry_cnp_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_cnp_mode_set(RealHandle, (Interop.Elementary.CopyAndPasteMode)value);
            }
        }

        /// <summary>
        /// Gets the geometry of the cursor.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public Rect CursorGeometry
        {
            get
            {
                int x, y, w, h;
                Interop.Elementary.elm_entry_cursor_geometry_get(RealHandle, out x, out y, out w, out h);
                return new Rect(x, y, w, h);
            }
        }

        /// <summary>
        /// Gets whether a format node exists at the current cursor position.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool IsCursorFormat
        {
            get
            {
                return Interop.Elementary.elm_entry_cursor_is_format_get(RealHandle);
            }
        }

        /// <summary>
        /// Gets if the current cursor position holds a visible format node.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool IsCursorVisibelFormat
        {
            get
            {
                return Interop.Elementary.elm_entry_cursor_is_visible_format_get(RealHandle);
            }
        }

        /// <summary>
        /// Sets or gets the value of the input hint.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public InputHints InputHint
        {
            get
            {
                return (InputHints)Interop.Elementary.elm_entry_input_hint_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_input_hint_set(RealHandle, (Interop.Elementary.InputHints)value);
            }
        }

        /// <summary>
        ///  Sets or gets the language mode of the input panel.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public InputPanelLanguage InputPanelLanguage
        {
            get
            {
                return (InputPanelLanguage)Interop.Elementary.elm_entry_input_panel_language_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_input_panel_language_set(RealHandle, (Interop.Elementary.InputPanelLanguage)value);
            }
        }

        /// <summary>
        /// Sets or gets the input panel layout variation of the entry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public int InputPanelVariation
        {
            get
            {
                return Interop.Elementary.elm_entry_input_panel_layout_variation_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_input_panel_layout_variation_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the line wrap type to use on multiline entries.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public WrapType LineWrapType
        {
            get
            {
                return (WrapType)Interop.Elementary.elm_entry_line_wrap_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_line_wrap_set(RealHandle, (Interop.Elementary.WrapType)value);
            }
        }

        /// <summary>
        /// Sets or gets whether the entry should allow to use the text prediction.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool PredictionAllowed
        {
            get
            {
                return Interop.Elementary.elm_entry_prediction_allow_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_prediction_allow_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether the return key on the input panel should be disabled or not.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool InputPanelReturnKeyDisabled
        {
            get
            {
                return Interop.Elementary.elm_entry_input_panel_return_key_disabled_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_input_panel_return_key_disabled_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the attribute to show the input panel, in case of only an user's explicit Mouse Up event.
        /// It doesn't request to show the input panel even though it has focus.
        /// If true, the input panel will be shown only in case of the Mouse up event (Focus event will be ignored).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool InputPanelShowByOnDemand
        {
            get
            {
                return Interop.Elementary.elm_entry_input_panel_show_on_demand_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_input_panel_show_on_demand_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets the file (and implicitly loads it) for the text to display and then edit.
        /// </summary>
        /// <param name="file">The path to the file to load and save.</param>
        /// <param name="textFormat">The file format.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void SetFile(string file, TextFormat textFormat)
        {
            Interop.Elementary.elm_entry_file_set(RealHandle, file, (Interop.Elementary.TextFormat)textFormat);
        }

        /// <summary>
        /// Converts a markup (HTML-like) string into UTF-8.
        /// </summary>
        /// <param name="markup">The string (in markup) to be converted.</param>
        /// <returns>The converted string (in UTF-8).</returns>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public static string ConvertMarkupToUtf8(string markup)
        {
            return Interop.Elementary.elm_entry_markup_to_utf8(markup);
        }

        /// <summary>
        /// Moves the cursor by one position to the right within the entry.
        /// </summary>
        /// <returns></returns>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool MoveCursorNext()
        {
            return Interop.Elementary.elm_entry_cursor_next(RealHandle);
        }

        /// <summary>
        /// Moves the cursor one place to the left within the entry.
        /// </summary>
        /// <returns>TRUE on success, otherwise FALSE on failure.</returns>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool MoveCursorPrev()
        {
            return Interop.Elementary.elm_entry_cursor_prev(RealHandle);
        }

        /// <summary>
        /// Moves the cursor one line up within the entry.
        /// </summary>
        /// <returns>TRUE on success, otherwise FALSE on failure.</returns>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool MoveCursorUp()
        {
            return Interop.Elementary.elm_entry_cursor_up(RealHandle);
        }

        /// <summary>
        /// Moves the cursor one line down within the entry.
        /// </summary>
        /// <returns>TRUE on success, otherwise FALSE on failure.</returns>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool MoveCursorDown()
        {
            return Interop.Elementary.elm_entry_cursor_down(RealHandle);
        }

        /// <summary>
        /// Moves the cursor to the beginning of the entry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void MoveCursorBegin()
        {
            Interop.Elementary.elm_entry_cursor_begin_set(RealHandle);
        }

        /// <summary>
        /// Moves the cursor to the end of the entry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void MoveCursorEnd()
        {
            Interop.Elementary.elm_entry_cursor_end_set(RealHandle);
        }

        /// <summary>
        /// Moves the cursor to the beginning of the current line.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void MoveCursorLineBegin()
        {
            Interop.Elementary.elm_entry_cursor_line_begin_set(RealHandle);
        }

        /// <summary>
        /// Moves the cursor to the end of the current line.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void MoveCursorLineEnd()
        {
            Interop.Elementary.elm_entry_cursor_line_end_set(RealHandle);
        }

        /// <summary>
        /// Sets the input panel layout of the entry.
        /// </summary>
        /// <param name="layout">The layout type.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void SetInputPanelLayout(InputPanelLayout layout)
        {
            Interop.Elementary.elm_entry_input_panel_layout_set(RealHandle, (Interop.Elementary.InputPanelLayout)layout);
        }

        /// <summary>
        /// Sets the attribute to show the input panel automatically.
        /// </summary>
        /// <param name="enabled">If true, the input panel appears when the entry is clicked or has focus, otherwise false.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void SetInputPanelEnabled(bool enabled)
        {
            Interop.Elementary.elm_entry_input_panel_enabled_set(RealHandle, enabled);
        }

        /// <summary>
        /// Sets the "return" key type. This type is used to set the string or icon on the "return" key of the input panel.
        /// </summary>
        /// <param name="keyType">The type of "return" key on the input panel.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void SetInputPanelReturnKeyType(InputPanelReturnKeyType keyType)
        {
            Interop.Elementary.elm_entry_input_panel_return_key_type_set(RealHandle, (Interop.Elementary.ReturnKeyType)keyType);
        }

        /// <summary>
        /// Hides the input panel (virtual keyboard).
        /// </summary>
        /// <remarks>
        /// Note that the input panel is shown or hidden automatically according to the focus state of the entry widget.
        /// This API can be used in case of manually controlling by using SetInputPanelEnabled(false).
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void HideInputPanel()
        {
            Interop.Elementary.elm_entry_input_panel_hide(RealHandle);
        }

        /// <summary>
        /// Selects all the text within the entry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void SelectAll()
        {
            Interop.Elementary.elm_entry_select_all(RealHandle);
        }

        /// <summary>
        /// Drops any existing text selection within the entry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void SelectNone()
        {
            Interop.Elementary.elm_entry_select_none(RealHandle);
        }

        /// <summary>
        /// Forces calculation of the entry size and text layout.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void ForceCalculation()
        {
            Interop.Elementary.elm_entry_calc_force(RealHandle);
        }

        /// <summary>
        /// Gets the string by the cursor at its current position.
        /// </summary>
        /// <returns></returns>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public string GetCursorContent()
        {
            return Interop.Elementary.elm_entry_cursor_content_get(RealHandle);
        }

        /// <summary>
        /// Begins a selection within the entry, as though the user was holding down the mouse button to make a selection.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void BeginCursorSelection()
        {
            Interop.Elementary.elm_entry_cursor_selection_begin(RealHandle);
        }

        /// <summary>
        /// Appends the text of the entry.
        /// </summary>
        /// <param name="text">The text to be displayed.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void AppendText(string text)
        {
            Interop.Elementary.elm_entry_entry_append(RealHandle, text);
        }

        /// <summary>
        /// Sets or gets the value of the HorizontalScrollBarVisiblePolicy.
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means that the horizontal scrollbar is made visible if it is needed, or otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public virtual ScrollBarVisiblePolicy HorizontalScrollBarVisiblePolicy
        {
            get
            {
                int policy;
                Interop.Elementary.elm_scroller_policy_get(RealHandle, out policy, IntPtr.Zero);
                return (ScrollBarVisiblePolicy)policy;
            }
            set
            {
                ScrollBarVisiblePolicy v = VerticalScrollBarVisiblePolicy;
                Interop.Elementary.elm_scroller_policy_set(RealHandle, (int)value, (int)v);
            }
        }

        /// <summary>
        /// Sets or gets the value of VerticalScrollBarVisiblePolicy.
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means that the vertical scrollbar is made visible if it is needed, or otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public virtual ScrollBarVisiblePolicy VerticalScrollBarVisiblePolicy
        {
            get
            {
                int policy;
                Interop.Elementary.elm_scroller_policy_get(RealHandle, IntPtr.Zero, out policy);
                return (ScrollBarVisiblePolicy)policy;
            }
            set
            {
                ScrollBarVisiblePolicy h = HorizontalScrollBarVisiblePolicy;
                Interop.Elementary.elm_scroller_policy_set(RealHandle, (int)h, (int)value);
            }
        }

        /// <summary>
        /// Sets or gets the vertical bounce behavior.
        /// When scrolling, the scroller may "bounce" when reaching an edge of the content object.
        /// This is a visual way to indicate that the end has reached.
        /// This is enabled by default for both the axis.
        /// This API will be set if it is enabled for the given axis with boolean parameters for each axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool VerticalBounce
        {
            get
            {
                bool v, h;
                Interop.Elementary.elm_scroller_bounce_get(RealHandle, out h, out v);
                return v;
            }
            set
            {
                bool h = HorizontalBounce;
                Interop.Elementary.elm_scroller_bounce_set(RealHandle, h, value);
            }
        }

        /// <summary>
        /// Sets or gets the horizontal bounce behavior.
        /// When scrolling, the scroller may "bounce" when reaching an edge of the content object.
        /// This is a visual way to indicate that the end has reached.
        /// This is enabled by default for both the axis.
        /// This API will be set if it is enabled for the given axis with boolean parameters for each axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public bool HorizontalBounce
        {
            get
            {
                bool v, h;
                Interop.Elementary.elm_scroller_bounce_get(RealHandle, out h, out v);
                return h;
            }
            set
            {
                bool v = VerticalBounce;
                Interop.Elementary.elm_scroller_bounce_set(RealHandle, value, v);
            }
        }

        /// <summary>
        /// Inserts the given text into the entry at the current cursor position.
        /// </summary>
        /// <param name="text">The text to be inserted.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void InsertTextToCursor(string text)
        {
            Interop.Elementary.elm_entry_entry_insert(RealHandle, text);
        }

        /// <summary>
        /// Ends a selection within the entry as though the user had just released the mouse button while making a selection.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void EndCursorSelection()
        {
            Interop.Elementary.elm_entry_cursor_selection_end(RealHandle);
        }

        /// <summary>
        /// Writes any changes made to the file that is set by a file.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void SaveFile()
        {
            Interop.Elementary.elm_entry_file_save(RealHandle);
        }

        /// <summary>
        /// Show the input panel (virtual keyboard) based on the input panel property of the entry such as layout, autocapital types, and so on.
        /// </summary>
        /// <remarks>
        /// Note that the input panel is shown or hidden automatically according to the focus state of the entry widget.
        /// This API can be used in the case of manual control by using the SetInputPanelEnabled(false).
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void ShowInputPanel()
        {
            Interop.Elementary.elm_entry_input_panel_show(RealHandle);
        }

        /// <summary>
        /// This appends a custom item provider to the list for that entry.
        /// </summary>
        /// <param name="func">This function is used to provide items.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void AppendItemProvider(Func<string, EvasObject> func)
        {
            if (func != null)
            {
                if (!_itemsProvider.ContainsKey(func))
                {
                    Interop.Elementary.Elm_Entry_Item_Provider_Cb itemProviderCallback;

                    itemProviderCallback = (d, o, t) =>
                    {
                        return func?.Invoke(t);
                    };
                    Interop.Elementary.elm_entry_item_provider_append(RealHandle, itemProviderCallback, IntPtr.Zero);
                    _itemsProvider.Add(func, itemProviderCallback);
                }
            }
        }

        /// <summary>
        /// This prepends a custom item provider to the list for that entry.
        /// </summary>
        /// <param name="func">This function is used to provide items.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void PrependItemProvider(Func<string, EvasObject> func)
        {
            if (!_itemsProvider.ContainsKey(func))
            {
                Interop.Elementary.Elm_Entry_Item_Provider_Cb itemProviderCallback;

                itemProviderCallback = (d, o, t) =>
                {
                    return func?.Invoke(t);
                };
                Interop.Elementary.elm_entry_item_provider_prepend(RealHandle, itemProviderCallback, IntPtr.Zero);
                _itemsProvider.Add(func, itemProviderCallback);
            }
        }

        /// <summary>
        /// This removes a custom item provider to the list for that entry.
        /// </summary>
        /// <param name="func">This function is used to provide items.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void RemoveItemProvider(Func<string, EvasObject> func)
        {
            if (_itemsProvider.ContainsKey(func))
            {
                Interop.Elementary.Elm_Entry_Item_Provider_Cb itemProviderCallback;
                _itemsProvider.TryGetValue(func, out itemProviderCallback);

                Interop.Elementary.elm_entry_item_provider_remove(RealHandle, itemProviderCallback, IntPtr.Zero);
                _itemsProvider.Remove(func);
            }
        }

        /// <summary>
        /// Appends a markup filter function for text inserted in the entry.
        /// </summary>
        /// <param name="filter">This function type is used by entry filters to modify text.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void AppendMarkUpFilter(Func<Entry, string, string> filter)
        {
            if (!_textFilters.ContainsKey(filter))
            {
                Interop.Elementary.Elm_Entry_Filter_Cb textFilterCallback = (IntPtr d, IntPtr e, ref IntPtr t) =>
                {
                    var text = Marshal.PtrToStringAnsi(t);

                    var updateText = filter(this, text);

                    if (updateText != text)
                    {
                        Marshal.FreeHGlobal(t);
                        t = Marshal.StringToHGlobalAnsi(updateText);
                    }
                };
                Interop.Elementary.elm_entry_markup_filter_append(RealHandle, textFilterCallback, IntPtr.Zero);
                _textFilters.Add(filter, textFilterCallback);
            }
        }

        /// <summary>
        /// Prepends a markup filter function for text inserted in the entry.
        /// </summary>
        /// <param name="filter">This function type is used by entry filters to modify text.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void PrependMarkUpFilter(Func<Entry, string, string> filter)
        {
            if (!_textFilters.ContainsKey(filter))
            {
                Interop.Elementary.Elm_Entry_Filter_Cb textFilterCallback = (IntPtr d, IntPtr e, ref IntPtr t) =>
                {
                    var text = Marshal.PtrToStringAnsi(t);

                    var updateText = filter(this, text);

                    if (updateText != text)
                    {
                        Marshal.FreeHGlobal(t);
                        t = Marshal.StringToHGlobalAnsi(updateText);
                    }
                };
                Interop.Elementary.elm_entry_markup_filter_prepend(RealHandle, textFilterCallback, IntPtr.Zero);
                _textFilters.Add(filter, textFilterCallback);
            }
        }

        /// <summary>
        /// Removes a markup filter.
        /// </summary>
        /// <param name="filter">This function type is used by entry filters to modify text.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void RemoveMarkUpFilter(Func<Entry, string, string> filter)
        {
            if (_textFilters.ContainsKey(filter))
            {
                Interop.Elementary.Elm_Entry_Filter_Cb textFilterCallback;
                _textFilters.TryGetValue(filter, out textFilterCallback);

                Interop.Elementary.elm_entry_markup_filter_remove(RealHandle, textFilterCallback, IntPtr.Zero);
                _textFilters.Remove(filter);
            }
        }

        /// <summary>
        /// This executes a "copy" action on the selected text in the entry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void CopySelection()
        {
            Interop.Elementary.elm_entry_selection_copy(RealHandle);
        }

        /// <summary>
        /// This executes a "cut" action on the selected text in the entry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void CutSelection()
        {
            Interop.Elementary.elm_entry_selection_cut(RealHandle);
        }

        /// <summary>
        /// This executes a "paste" action in the entry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void PasteSelection()
        {
            Interop.Elementary.elm_entry_selection_paste(RealHandle);
        }

        /// <summary>
        /// This disables the entry's selection handlers.
        /// This works properly on the profile that provides selection handlers.
        /// </summary>
        /// <param name="disable">If true, the selection handlers are disabled.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void DisableSelection(bool disable)
        {
            Interop.Elementary.elm_entry_selection_handler_disabled_set(RealHandle, disable);
        }

        /// <summary>
        /// Gets any selected text within the entry.
        /// </summary>
        /// <returns>Selection's value.</returns>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public string GetSelection()
        {
            return Interop.Elementary.elm_entry_selection_get(RealHandle);
        }

        /// <summary>
        /// This selects a region of text within the entry.
        /// </summary>
        /// <param name="start">The start position.</param>
        /// <param name="end">The end position.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void SetSelectionRegion(int start, int end)
        {
            Interop.Elementary.elm_entry_select_region_set(RealHandle, start, end);
        }

        /// <summary>
        /// Sets the visibility of the left-side widget of the entry.
        /// </summary>
        /// <param name="isDisplay">true if the object should be displayed, otherwise false.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void SetIconVisible(bool isDisplay)
        {
            Interop.Elementary.elm_entry_icon_visible_set(RealHandle, isDisplay);
        }

        /// <summary>
        /// Sets whether the return key on the input panel is disabled automatically, when the entry has no text.
        /// </summary>
        /// <param name="enable">If enabled is true, the return key is automatically disabled when the entry has no text.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        public void SetInputPanelReturnKeyAutoEnable(bool enable)
        {
            Interop.Elementary.elm_entry_input_panel_return_key_autoenabled_set(RealHandle, enable);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This has been deprecated in API12")]
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_entry_add(parent.Handle);
        }
    }
}
