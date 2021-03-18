// Copyright (c) 2021 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
using System;

namespace Tizen.NUI
{
    /// <summary>
    /// A class encapsulating the input method map.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class InputMethod
    {
        private PanelLayoutType? panelLayout = null;
        private ActionButtonTitleType? actionButton = null;
        private AutoCapitalType? autoCapital = null;
        private int? variation = null;

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public InputMethod()
        {
        }

        /// <summary>
        /// SetType that can be changed in the system input method.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum CategoryType
        {
            /// <summary>
            /// Set the keyboard layout.
            /// </summary>
            PanelLayout,
            /// <summary>
            /// Set the action button title.
            /// </summary>
            ActionButtonTitle,
            /// <summary>
            /// Set the auto capitalise of input.
            /// </summary>
            AutoCapitalise,
            /// <summary>
            /// Set the variation.
            /// </summary>
            Variation
        }

        /// <summary>
        /// Autocapitalization Types.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum AutoCapitalType
        {
            /// <summary>
            /// No auto-capitalization when typing.
            /// </summary>
            None,
            /// <summary>
            /// Autocapitalize each word typed.
            /// </summary>
            Word,
            /// <summary>
            /// Autocapitalize the start of each sentence.
            /// </summary>
            Sentence,
            /// <summary>
            /// Autocapitalize all letters.
            /// </summary>
            Allcharacter
        }

        /// <summary>
        /// Input panel (virtual keyboard) layout types..
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum PanelLayoutType
        {
            /// <summary>
            /// Default layout.
            /// </summary>
            Normal,
            /// <summary>
            /// Number layout.
            /// </summary>
            Number,
            /// <summary>
            /// Email layout.
            /// </summary>
            Email,
            /// <summary>
            /// URL layout.
            /// </summary>
            URL,
            /// <summary>
            /// Phone number layout.
            /// </summary>
            PhoneNumber,
            /// <summary>
            /// IP layout.
            /// </summary>
            IP,
            /// <summary>
            /// Month layout.
            /// </summary>
            Month,
            /// <summary>
            /// Number layout.
            /// </summary>
            NumberOnly,
            /// <summary>
            /// Hexadecimal layout.
            /// </summary>
            HEX,
            /// <summary>
            /// Command-line terminal layout including Esc, Alt, Ctrl key, and so on (no auto-correct, no auto-capitalization).
            /// </summary>
            Terminal,
            /// <summary>
            /// Like normal, but no auto-correct, no auto-capitalization etc.
            /// </summary>
            Password,
            /// <summary>
            /// Date and time layout.
            /// </summary>
            Datetime,
            /// <summary>
            /// Emoticon layout.
            /// </summary>
            Emoticon
        }

        /// <summary>
        /// Specifies what the Input Method "action" button functionality is set to.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum ActionButtonTitleType
        {
            /// <summary>
            /// Default action.
            /// </summary>
            Default,
            /// <summary>
            /// Done.
            /// </summary>
            Done,
            /// <summary>
            /// Go action.
            /// </summary>
            Go,
            /// <summary>
            /// Join action.
            /// </summary>
            Join,
            /// <summary>
            /// Login action.
            /// </summary>
            Login,
            /// <summary>
            /// Next action.
            /// </summary>
            Next,
            /// <summary>
            /// Previous action.
            /// </summary>
            [Obsolete("Deprecated in API8, will be removed in API10.")]
            Previous,
            /// <summary>
            /// Search action.
            /// </summary>
            Search,
            /// <summary>
            /// Send action.
            /// </summary>
            Send,
            /// <summary>
            /// Sign in action.
            /// </summary>
            SignIn,
            /// <summary>
            /// Unspecified action.
            /// </summary>
            [Obsolete("Deprecated in API8, will be removed in API10.")]
            Unspecified,
            /// <summary>
            /// Nothing to do.
            /// </summary>
            [Obsolete("Deprecated in API8, will be removed in API10.")]
            None
        }

        /// <summary>
        /// Available variation for the normal layout.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum NormalLayoutType
        {
            /// <summary>
            /// The plain normal layout.
            /// </summary>
            Normal,
            /// <summary>
            /// Filename layout. symbols such as '/' should be disabled.
            /// </summary>
            WithFilename,
            /// <summary>
            /// The name of a person.
            /// </summary>
            WithPersonName
        }

        /// <summary>
        /// Available variation for the number only layout.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum NumberOnlyLayoutType
        {
            /// <summary>
            /// The plain normal number layout.
            /// </summary>
            Normal,
            /// <summary>
            /// The number layout to allow a positive or negative sign at the start.
            /// </summary>
            WithSigned,
            /// <summary>
            /// The number layout to allow decimal point to provide fractional value.
            /// </summary>
            WithDecimal,
            /// <summary>
            /// The number layout to allow decimal point and negative sign.
            /// </summary>
            WithSignedAndDecimal
        }

        /// <summary>
        /// Available variation for the password layout.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum PasswordLayoutType
        {
            /// <summary>
            /// The normal password layout.
            /// </summary>
            Normal,
            /// <summary>
            /// The password layout to allow only number.
            /// </summary>
            WithNumberOnly
        }

        /// <summary>
        /// Gets or sets the panel layout.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PanelLayoutType PanelLayout
        {
            get
            {
                return panelLayout ?? PanelLayoutType.Normal;
            }
            set
            {
                panelLayout = value;
            }
        }

        /// <summary>
        /// Gets or sets the action button.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ActionButtonTitleType ActionButton
        {
            get
            {
                return actionButton ?? ActionButtonTitleType.Default;
            }
            set
            {
                actionButton = value;
            }
        }

        /// <summary>
        /// Gets or sets the auto capital.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AutoCapitalType AutoCapital
        {
            get
            {
                return autoCapital ?? AutoCapitalType.None;
            }
            set
            {
                autoCapital = value;
            }
        }

        /// <summary>
        /// Gets or sets the variation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Variation
        {
            get
            {
                return variation ?? 0;
            }
            set
            {
                variation = value;
            }
        }

        /// <summary>
        /// Gets or sets the variation for normal layout.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public NormalLayoutType NormalVariation
        {
            get
            {
                return (NormalLayoutType)(variation ?? 0);
            }
            set
            {
                variation = (int)value;
            }
        }

        /// <summary>
        /// Gets or sets the variation for the number only layout.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public NumberOnlyLayoutType NumberOnlyVariation
        {
            get
            {
                return (NumberOnlyLayoutType)(variation ?? 0);
            }
            set
            {
                variation = (int)value;
            }
        }

        /// <summary>
        /// Gets or sets the variation for the password layout.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PasswordLayoutType PasswordVariation
        {
            get
            {
                return (PasswordLayoutType)(variation ?? 0);
            }
            set
            {
                variation = (int)value;
            }
        }

        /// <summary>
        /// Gets the input method map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap OutputMap
        {
            get
            {
                return ComposingInputMethodMap();
            }
        }

        private PropertyMap ComposingInputMethodMap()
        {
            PropertyMap outputMap = new PropertyMap();
            PropertyValue temp;
            if (panelLayout != null)
            {
                temp = new PropertyValue((int)panelLayout);
                outputMap.Add("PANEL_LAYOUT", temp);
                temp.Dispose();
            }
            if (actionButton != null)
            {
                // Temporarily specify the values to match the types of ecore_imf.
                if (actionButton == InputMethod.ActionButtonTitleType.Search) actionButton = (InputMethod.ActionButtonTitleType.Search - 1); // 6
                else if (actionButton == InputMethod.ActionButtonTitleType.Send) actionButton = (InputMethod.ActionButtonTitleType.Send - 1); // 7
                else if (actionButton == InputMethod.ActionButtonTitleType.SignIn) actionButton = (InputMethod.ActionButtonTitleType.SignIn - 1); // 8
                else if (actionButton == InputMethod.ActionButtonTitleType.Unspecified || actionButton == InputMethod.ActionButtonTitleType.None) actionButton = InputMethod.ActionButtonTitleType.Default;
                temp = new PropertyValue((int)actionButton);
                outputMap.Add("BUTTON_ACTION", temp);
                temp.Dispose();
            }
            if (autoCapital != null)
            {
                temp = new PropertyValue((int)autoCapital);
                outputMap.Add("AUTO_CAPITALIZE", temp);
                temp.Dispose();
            }
            if (variation != null)
            {
                temp = new PropertyValue((int)variation);
                outputMap.Add("VARIATION", temp);
                temp.Dispose();
            }
            return outputMap;
        }
    }
}
