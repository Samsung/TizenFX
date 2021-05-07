/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// It is a class for context menu item of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebContextMenuItem : Disposable
    {
        internal WebContextMenuItem(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebContextMenuItem.DeleteWebContextMenuItem(swigCPtr);
        }

        /// <summary>
        /// Enum that provides the tags of items for the context menu.
        /// </summary>
        public enum ItemTag
        {
            NoAction = 0,
            OpenLinkInNewWindow,
            DownloadLinkToDisk,
            CopyLinkToClipboard,
            OpenImageInNewWindow,
            OpenImageInCurrentWindow,
            DownloadImageToDisk,
            CopyImageToClipboard,
            OpenFrameInNewWindow,
            Copy,
            GoBack,
            GoForward,
            Stop,
            Share,
            Reload,
            Cut,
            Paste,
            SpellingGuess,
            NoGuessesFound,
            IgnoreSpelling,
            LearnSpelling,
            Other,
            SearchInSpotlight,
            SearchWeb,
            LookUpInDictionary,
            OpenWithDefaultApplication,
            PdfActualSize,
            PdfZoomIn,
            PdfZoomOut,
            PdfAutoSize,
            PdfSinglePage,
            PdfPaging,
            PdfContinuous,
            PdfNextPage,
            PdfPreviousPage,
            OpenLink,
            IgnoreGrammar,
            SpellingMenu,
            ShowSpellingPanel,
            CheckSpelling,
            CheckSpellingWhiteTyping,
            CheckGrammarWithSpelling,
            FontMenu,
            ShowFonts,
            Bold,
            Italic,
            Underline,
            Outline,
            Styles,
            ShowColors,
            SpeechMenu,
            StartSpeaking,
            StopSpeaking,
            WritingDirectionMenu,
            DefaultDirection,
            LeftToRight,
            RightToLeft,
            PdfSinglePageScrolling,
            PdfFacingPageScrolling,
            InspectElement,
            TextDirectionMenu,
            TextDirectionDefault,
            TextDirectionLeftToRight,
            TextDirectionRightToLeft,
            CorrectSpellingAutomatically,
            SubstitutionMenu,
            ShowSubstitutions,
            SmartCopyPaste,
            SmartQuotes,
            SmartDashes,
            SmartLinks,
            TextReplacement,
            TransformationMenu,
            MakeUpperCase,
            MakeLowerCase,
            Capitalize,
            ChangeBack,
            OpenMediaInNewWindow,
            CopyMediaLinkToClipboard,
            ToggleMediaControls,
            ToggleMediaLoop,
            EnterVideoFullscreen,
            MediaPlayPause,
            MediaMute,
            DictationAlternative,
            SelectAll,
            SelectWord,
            TextSelectionMode,
            Clipboard,
            Drag,
            Translate,
            CopyLinkData,
        }

        /// <summary>
        /// Enum that defines the types of the items for the context menu.
        /// </summary>
        public enum ItemType
        {
            Action,
            CheckableAction,
            Separator,
            Submenu,
        };

        /// <summary>
        /// Gets the tag of context menu item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemTag Tag
        {
            get
            {
                return (ItemTag)Interop.WebContextMenuItem.GetTag(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the type of context menu item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemType Type
        {
            get
            {
                return (ItemType)Interop.WebContextMenuItem.GetType(SwigCPtr);
            }
        }

        /// <summary>
        /// Checks if the item is enabled or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEnabled
        {
            get
            {
                return Interop.WebContextMenuItem.IsEnabled(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the link url of context menu item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LinkUrl
        {
            get
            {
                return Interop.WebContextMenuItem.GetLinkUrl(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the image url of context menu item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ImageUrl
        {
            get
            {
                return Interop.WebContextMenuItem.GetImageUrl(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the title of the item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Title
        {
            get
            {
                return Interop.WebContextMenuItem.GetTitle(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the parent menu for the item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebContextMenu ParentMenu
        {
            get
            {
                IntPtr result = Interop.WebContextMenuItem.GetParentMenu(SwigCPtr);
                return new WebContextMenu(result, true);
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WebContextMenuItem obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }
    }
}
