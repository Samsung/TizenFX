/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;

namespace Tizen.WebView
{
    /// <summary>
    /// Enumeration for Context Menu Item Tag.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum ContextMenuItemTag
    {
        /// <summary>
        /// No action
        /// </summary>
        NoAction = 0,
        /// <summary>
        /// Open link in new window.
        /// </summary>
        OpenInNewWindow,
        /// <summary>
        /// Download link to disk.
        /// </summary>
        DownloadLinkToDisk,
        /// <summary>
        /// Copy link to clipboard.
        /// </summary>
        CopyLinkToClipboard,
        /// <summary>
        /// Open image in new window.
        /// </summary>
        OpenImageInNewWindow,
        /// <summary>
        /// Open image in current window.
        /// </summary>
        OpenImageInCurrentWindow,
        /// <summary>
        /// Download image to disk.
        /// </summary>
        DownloadImageToDisk,
        /// <summary>
        /// Copy image to clipboard.
        /// </summary>
        CopyImageToClipboard,
        /// <summary>
        /// Open frame in new window.
        /// </summary>
        OpenFrameInNewWindow,
        /// <summary>
        /// Copy.
        /// </summary>
        Copy,
        /// <summary>
        /// Go back.
        /// </summary>
        GoBack,
        /// <summary>
        /// Go forward.
        /// </summary>
        GoForward,
        /// <summary>
        /// Stop.
        /// </summary>
        Stop,
        /// <summary>
        /// Share.
        /// </summary>
        Share,
        /// <summary>
        /// Reload.
        /// </summary>
        Reload,
        /// <summary>
        /// Cut.
        /// </summary>
        Cut,
        /// <summary>
        /// Paste.
        /// </summary>
        Paste,
        /// <summary>
        /// Spelling guess.
        /// </summary>
        SpellingGuess,
        /// <summary>
        /// Guess found.
        /// </summary>
        NoGuessFound,
        /// <summary>
        /// Ignore spelling.
        /// </summary>
        IgnoreSpelling,
        /// <summary>
        /// Learn spelling.
        /// </summary>
        LearnSpelling,
        /// <summary>
        /// Other.
        /// </summary>
        Other,
        /// <summary>
        /// Search in spotlight.
        /// </summary>
        SearchInSpotlight,
        /// <summary>
        /// Search web.
        /// </summary>
        SearchWeb,
        /// <summary>
        /// Look up in dictionary.
        /// </summary>
        LookUpInDictionary,
        /// <summary>
        /// Open with default application.
        /// </summary>
        OpenWithDefaultApplication,
        /// <summary>
        /// PDF actual size.
        /// </summary>
        PdfActualSize,
        /// <summary>
        /// PDF zoom in.
        /// </summary>
        PdfZoomIn,
        /// <summary>
        /// PDF zoom out.
        /// </summary>
        PdfZoomOut,
        /// <summary>
        /// PDF auto size.
        /// </summary>
        PdfAutoSize,
        /// <summary>
        /// PDF single page.
        /// </summary>
        PdfSinglePage,
        /// <summary>
        /// PDF facting page.
        /// </summary>
        PdfFactingPage,
        /// <summary>
        /// PDF continuous.
        /// </summary>
        PdfContinuous,
        /// <summary>
        /// PDF next page.
        /// </summary>
        PdfNextPage,
        /// <summary>
        /// PDF previous page.
        /// </summary>
        PdfPreviousPage,
        /// <summary>
        /// Open link.
        /// </summary>
        OpenLink,
        /// <summary>
        /// Ignore grammar.
        /// </summary>
        IgnoreGrammar,
        /// <summary>
        /// Spelling menu.
        /// </summary>
        SpellingMenu,
        /// <summary>
        /// Show spelling panel.
        /// </summary>
        ShowSpellingPanel,
        /// <summary>
        /// Check spelling.
        /// </summary>
        CheckSpelling,
        /// <summary>
        /// Check spelling white typing.
        /// </summary>
        CheckSpellingWhileTyping,
        /// <summary>
        /// Check grammar with spelling.
        /// </summary>
        CheckGrammarWithSpelling,
        /// <summary>
        /// Font menu.
        /// </summary>
        FontMenu,
        /// <summary>
        /// Show fonts.
        /// </summary>
        ShowFonts,
        /// <summary>
        /// Bold.
        /// </summary>
        Bold,
        /// <summary>
        /// Italic.
        /// </summary>
        Italic,
        /// <summary>
        /// Underline.
        /// </summary>
        Underline,
        /// <summary>
        /// Outline.
        /// </summary>
        Outline,
        /// <summary>
        /// Style.
        /// </summary>
        Style,
        /// <summary>
        /// Show colors.
        /// </summary>
        ShowColors,
        /// <summary>
        /// Speech menu.
        /// </summary>
        SpeechMenu,
        /// <summary>
        /// Start speaking.
        /// </summary>
        StartSpeaking,
        /// <summary>
        /// Stop speaking.
        /// </summary>
        StopSpeaking,
        /// <summary>
        /// Writing direction menu.
        /// </summary>
        WritingDirectionMenu,
        /// <summary>
        /// Default direction.
        /// </summary>
        DefaultDirection,
        /// <summary>
        /// Left to right.
        /// </summary>
        LeftToRight,
        /// <summary>
        /// Right to left.
        /// </summary>
        RightToLeft,
        /// <summary>
        /// PDF single page scrolling.
        /// </summary>
        PdfSinglePageScrolling,
        /// <summary>
        /// PDF facing page scrolling.
        /// </summary>
        PdfFacingPageScrolling,
        /// <summary>
        /// Inspect element.
        /// </summary>
        InspectElement,
        /// <summary>
        /// Text direction menu.
        /// </summary>
        TextDirectionMenu,
        /// <summary>
        /// Text direction default.
        /// </summary>
        TextDirectionDefault,
        /// <summary>
        /// Text direction left to right.
        /// </summary>
        TextDirectionLeftToRight,
        /// <summary>
        /// Text direction right to left.
        /// </summary>
        TextDirectionRightToLeft,
        /// <summary>
        /// Correct spelling automatically.
        /// </summary>
        CorrectSpellingAutomatically,
        /// <summary>
        /// Substitutions menu.
        /// </summary>
        SubstitutionsMenu,
        /// <summary>
        /// Show substitutions.
        /// </summary>
        ShowSubstitutions,
        /// <summary>
        /// Smart copy paste.
        /// </summary>
        SmartCopyPaste,
        /// <summary>
        /// Smart quotes.
        /// </summary>
        SmartQuotes,
        /// <summary>
        /// Smart dashes.
        /// </summary>
        SmartDashes,
        /// <summary>
        /// Smart links.
        /// </summary>
        SmartLinks,
        /// <summary>
        /// Text replacement.
        /// </summary>
        TextReplacement,
        /// <summary>
        /// Transformation menu.
        /// </summary>
        TransformationMenu,
        /// <summary>
        /// Make upper case.
        /// </summary>
        MakeUpperCase,
        /// <summary>
        /// Make lower case.
        /// </summary>
        MakeLowerCase,
        /// <summary>
        /// Capitalize.
        /// </summary>
        Capitalize,
        /// <summary>
        /// Change back.
        /// </summary>
        ChangeBack,
        /// <summary>
        /// Open media in new window.
        /// </summary>
        OpenMediaInNewWindow,
        /// <summary>
        /// Copy media link to clipboard.
        /// </summary>
        CopyMediaLinkToClipboard,
        /// <summary>
        /// Toggle media controls.
        /// </summary>
        ToggleMediaControls,
        /// <summary>
        /// Toggle media loop.
        /// </summary>
        ToggleMediaLoop,
        /// <summary>
        /// Enter video fullscreen.
        /// </summary>
        EnterVideoFullscreen,
        /// <summary>
        /// Media play pause.
        /// </summary>
        MediaPlayPause,
        /// <summary>
        /// Media mute.
        /// </summary>
        MediaMute,
        /// <summary>
        /// Dictation alternative.
        /// </summary>
        DictationAlternative,
        /// <summary>
        /// Select all.
        /// </summary>
        SelectAll,
        /// <summary>
        /// Select word.
        /// </summary>
        SelectWord,
        /// <summary>
        /// Text selection mode.
        /// </summary>
        TextSelectonMode,
        /// <summary>
        /// Clipboard.
        /// </summary>
        Clipboard,
        /// <summary>
        /// Drag.
        /// </summary>
        Drag,
        /// <summary>
        /// Translate.
        /// </summary>
        Translate,
        /// <summary>
        /// Copy link data.
        /// </summary>
        CopyLinkData,
        /// <summary>
        /// If app want to add customized item, use enum value after BaseApplicationTag.
        /// </summary>
        BaseApplicationTag = 10000
    }

    /// <summary>
    /// This class provides the properties of Context Menu item.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class ContextMenuItem
    {
        private IntPtr _handle;

        internal ContextMenuItem(IntPtr handle)
        {
            _handle = handle;
        }

        internal IntPtr GetHandle()
        {
            return _handle;
        }

        /// <summary>
        /// Gets Tag of the context menu item.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ContextMenuItemTag ItemTag
        {
            get
            {
                return (ContextMenuItemTag) Interop.ChromiumEwk.ewk_context_menu_item_tag_get(_handle);
            }
        }
    }

    /// <summary>
    /// Arguments from the ContextMenuItem event.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class ContextMenuItemEventArgs : EventArgs
    {
        internal ContextMenuItemEventArgs(ContextMenuItem item)
        {
            Item = item;
        }

        /// <summary>
        /// Gets the context menu item.
        /// </summary>
        /// <returns>The context menu item.</returns>
        /// <since_tizen> 6 </since_tizen>
        public ContextMenuItem Item { get; }

        internal static ContextMenuItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            return new ContextMenuItemEventArgs(new ContextMenuItem(info));
        }
    }

    /// <summary>
    /// This class provides the properties of Context Menu.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class ContextMenu
    {
        private IntPtr _handle;

        internal ContextMenu(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Gets the context menu items count.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int ItemCount
        {
            get
            {
                return Interop.ChromiumEwk.ewk_context_menu_item_count(_handle);
            }
        }

        /// <summary>
        /// Gets Nth item of the context menu.
        /// </summary>
        /// <param name="n"> To get item at index n.</param>
        /// <returns>The context menu item.</returns>
        /// <since_tizen> 6 </since_tizen>
        public ContextMenuItem GetItemAtIndex(int n)
        {
            IntPtr itemHandle = Interop.ChromiumEwk.ewk_context_menu_nth_item_get(_handle, n);
            return new ContextMenuItem(itemHandle);
        }

        /// <summary>
        /// Removes item from the context menu.
        /// </summary>
        /// <param name="item"> The context menu item to be removed.</param>
        /// <since_tizen> 6 </since_tizen>
        public void RemoveItem(ContextMenuItem item)
        {
            IntPtr itemHandle = item.GetHandle();
            Interop.ChromiumEwk.ewk_context_menu_item_remove(_handle, itemHandle);
        }

        /// <summary>
        /// Appends item to the context menu.
        /// </summary>
        /// <param name="tag"> The tag of context menu item.</param>
        /// <param name="title"> The title of context menu item.</param>
        /// <param name="iconPath"> The path of icon to be set on context menu item.</param>
        /// <param name="enabled"> if true the context menu item is enabled else false.</param>
        /// <returns>Appended context menu item.</returns>
        /// <since_tizen> 6 </since_tizen>
        public ContextMenuItem AppendItem(ContextMenuItemTag tag, string title, string iconPath, bool enabled)
        {
            bool ret = false;
            if(string.IsNullOrEmpty(iconPath))
                ret = Interop.ChromiumEwk.ewk_context_menu_item_append_as_action(_handle, tag, title, enabled);
            else
                ret = Interop.ChromiumEwk.ewk_context_menu_item_append(_handle, tag, title, iconPath, enabled);

            return ret ? GetItemAtIndex(ItemCount - 1) : null;
        }
    }

    /// <summary>
    /// Arguments from the ContextMenu Item event.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    internal class ContextMenuCustomizeEventArgs : EventArgs
    {
        internal ContextMenuCustomizeEventArgs(ContextMenu menu)
        {
            Menu = menu;
        }

        internal ContextMenu Menu { get; }

        internal static ContextMenuCustomizeEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            return new ContextMenuCustomizeEventArgs(new ContextMenu(info));
        }
    }
}
