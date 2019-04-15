// Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{

    /// <summary>
    /// A class encapsulating the input method map.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class InputMethod
    {
        private PanelLayoutType? _panelLayout = null;
        private ActionButtonTitleType? _actionButton = null;
        private AutoCapitalType? _autoCapital = null;
        private int? _variation = null;

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
            Unspecified,
            /// <summary>
            /// Nothing to do.
            /// </summary>
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
            /// Filename layout. sysbols such as '/' should be disabled.
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
                return _panelLayout ?? PanelLayoutType.Normal;
            }
            set
            {
                _panelLayout = value;
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
                return _actionButton ?? ActionButtonTitleType.Default;
            }
            set
            {
                _actionButton = value;
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
                return _autoCapital ?? AutoCapitalType.None;
            }
            set
            {
                _autoCapital = value;
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
                return _variation ?? 0;
            }
            set
            {
                _variation = value;
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
                return (NormalLayoutType) (_variation ?? 0);
            }
            set
            {
                _variation = (int)value;
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
                return (NumberOnlyLayoutType) (_variation ?? 0);
            }
            set
            {
                _variation = (int)value;
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
                return (PasswordLayoutType) (_variation ?? 0);
            }
            set
            {
                _variation = (int)value;
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
            PropertyMap _outputMap = new PropertyMap();
            if (_panelLayout != null) { _outputMap.Add("PANEL_LAYOUT", new PropertyValue((int)_panelLayout)); }
            if (_actionButton != null) { _outputMap.Add("BUTTON_ACTION", new PropertyValue((int)_actionButton)); }
            if (_autoCapital != null) { _outputMap.Add("AUTO_CAPITALIZE", new PropertyValue((int)_autoCapital)); }
            if (_variation != null) { _outputMap.Add("VARIATION", new PropertyValue((int)_variation)); }
            return _outputMap;
        }
    }
}