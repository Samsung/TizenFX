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
using static Interop.InputMethod;

namespace Tizen.Uix.InputMethod
{
    /// <summary>
    /// Enumeration for Input Panel Layout
    /// </summary>
    public enum EcoreIMFInputPanelLayout
    {
        /// <summary>
        /// Normal
        /// </summary>
        LayoutNormal,
        /// <summary>
        /// Number
        /// </summary>
        LayoutNumber,
        /// <summary>
        /// Email
        /// </summary>
        LayoutEMail,
        /// <summary>
        /// URL
        /// </summary>
        LayoutURL,
        /// <summary>
        /// Phone Number
        /// </summary>
        LayoutPhoneNumber,
        /// <summary>
        /// IP
        /// </summary>
        LayoutIP,
        /// <summary>
        /// Month
        /// </summary>
        LayoutMonth,
        /// <summary>
        /// Number Only
        /// </summary>
        LayoutNumberOnly,
        /// <summary>
        /// Invalid
        /// </summary>
        LayoutInvalid,
        /// <summary>
        /// HEX
        /// </summary>
        LayoutHEX,
        /// <summary>
        /// Terminal
        /// </summary>
        LayoutTerminal,
        /// <summary>
        /// Password
        /// </summary>
        LayoutPassword,
        /// <summary>
        /// Date Time
        /// </summary>
        LayoutDateTime,
        /// <summary>
        /// Emoticon
        /// </summary>
        LayoutEmoticon,
        /// <summary>
        /// Voice
        /// </summary>
        LayoutVoice,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined
    };

    /// <summary>
    /// Enumeration for Layout Variation
    /// </summary>
    public enum ImeLayoutVariation
    {
        /// <summary>
        /// The plain normal layout
        /// </summary>
        NormalVariationNormal = 0,
        /// <summary>
        /// Filename layout; symbols such as '/', '\*', '\', '|', '&lt;', '&gt;', '?', '&quot;' and ':' should be disabled
        /// </summary>
        NormalVariationFileName,
        /// <summary>
        /// The name of a person
        /// </summary>
        NormalVariationPersonName,
        /// <summary>
        /// The plain normal number layout
        /// </summary>
        NumberOnlyVariationNormal = 0,
        /// <summary>
        /// The number layout to allow a negative sign
        /// </summary>
        NumberOnlyVariationSigned,
        /// <summary>
        /// The number layout to allow decimal point to provide fractional value
        /// </summary>
        NumberOnlyVariationDecimal,
        /// <summary>
        /// The number layout to allow decimal point and negative sign
        /// </summary>
        NumberOnlyVariationSignedAandDecimal,
        /// <summary>
        /// The normal password layout
        /// </summary>
        PasswordVariationNormal = 0,
        /// <summary>
        /// The password layout to allow only number
        /// </summary>
        PasswordVariationNumberOnly,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined
    };

    /// <summary>
    /// Enumeration for AutoCapital Type
    /// </summary>
    public enum EcoreIMFAutocapitalType
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// Word
        /// </summary>
        Word,
        /// <summary>
        /// Sentence
        /// </summary>
        Sentence,
        /// <summary>
        /// All Character
        /// </summary>
        AllCharacter,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined
    };

    /// <summary>
    /// Enumeration for InputPanel ReturnKey Type
    /// </summary>
    public enum EcoreIMFInputPanelReturnKeyType
    {
        /// <summary>
        /// Default
        /// </summary>
        Default,
        /// <summary>
        /// Done
        /// </summary>
        Done,
        /// <summary>
        /// Go
        /// </summary>
        Go,
        /// <summary>
        /// Join
        /// </summary>
        Join,
        /// <summary>
        /// Login
        /// </summary>
        Login,
        /// <summary>
        /// Next
        /// </summary>
        Next,
        /// <summary>
        /// Search
        /// </summary>
        Search,
        /// <summary>
        /// Send
        /// </summary>
        Send,
        /// <summary>
        /// SignIn
        /// </summary>
        SignIn,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined
    };

    /// <summary>
    /// Enumeration for InputHints
    /// </summary>
    public enum EcoreIMFInputHints
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// AutoComplete
        /// </summary>
        AutoComplete,
        /// <summary>
        /// SensitiveData
        /// </summary>
        SensitiveData,
        /// <summary>
        /// Multiline
        /// </summary>
        Multiline,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined
    };

    /// <summary>
    /// Enumeration for BiDi Direction
    /// </summary>
    public enum EcoreIMFBiDiDirection
    {
        /// <summary>
        /// Neutral
        /// </summary>
        Neutral,
        /// <summary>
        /// LTR
        /// </summary>
        LTR,
        /// <summary>
        /// RTL
        /// </summary>
        RTL,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined
    };

    /// <summary>
    /// Enumeration for InputPanel Language
    /// </summary>
    public enum EcoreIMFInputPanelLang
    {
        /// <summary>
        /// Automatic
        /// </summary>
        Automatic,
        /// <summary>
        /// Alphabet
        /// </summary>
        Alphabet,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined
    };

    /// <summary>
    /// This class represents the context of InputMethodEditor
    /// </summary>
    public class InputMethodContext
    {
        private IntPtr _handle;
        internal InputMethodContext(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Gets the layout information.
        /// </summary>
        public EcoreIMFInputPanelLayout Layout
        {
            get
            {
                EcoreIMFInputPanelLayout layout;
                ErrorCode error = ImeContextGetLayout(_handle, out layout);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetLayout Failed with error " + error);
                    return EcoreIMFInputPanelLayout.Undefined;
                }
                return layout;
            }
        }

        /// <summary>
        /// Gets the layout variation information.
        /// </summary>
        public ImeLayoutVariation LayoutVariation
        {
            get
            {
                ImeLayoutVariation layoutVariation;
                ErrorCode error = ImeContextGetLayoutVariation(_handle, out layoutVariation);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetLayoutVariation Failed with error " + error);
                    return ImeLayoutVariation.Undefined;
                }
                return layoutVariation;
            }
        }

        /// <summary>
        /// Gets the cursor position information.
        /// </summary>
        public int CursorPosition
        {
            get
            {
                int cursorPosition;
                ErrorCode error = ImeContextGetCursorPosition(_handle, out cursorPosition);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetCursorPosition Failed with error " + error);
                    return -1;
                }
                return cursorPosition;
            }
        }

        /// <summary>
        /// Gets the autocapital type information.
        /// </summary>
        public EcoreIMFAutocapitalType AutoCapitalType
        {
            get
            {
                EcoreIMFAutocapitalType autoCapitalType;
                ErrorCode error = ImeContextGetAutocapitalType(_handle, out autoCapitalType);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetAutoCapitalType Failed with error " + error);
                    return EcoreIMFAutocapitalType.Undefined;
                }
                return autoCapitalType;
            }
        }

        /// <summary>
        /// Gets the Return key label type information.
        /// </summary>
        public EcoreIMFInputPanelReturnKeyType ReturnKeyType
        {
            get
            {
                EcoreIMFInputPanelReturnKeyType returnKeyType;
                ErrorCode error = ImeContextGetReturnKeyType(_handle, out returnKeyType);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetReturnKeyType Failed with error " + error);
                    return EcoreIMFInputPanelReturnKeyType.Undefined;
                }
                return returnKeyType;
            }
        }

        /// <summary>
        /// Gets the Return key state information.
        /// </summary>
        public bool ReturnKeyState
        {
            get
            {
                bool returnKeyState;
                ErrorCode error = ImeContextGetReturnKeyState(_handle, out returnKeyState);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetReturnKeyState Failed with error " + error);
                    return false;
                }
                return returnKeyState;
            }
        }

        /// <summary>
        /// Gets the prediction mode information.
        /// </summary>
        public bool PredictionMode
        {
            get
            {
                bool predictionMode;
                ErrorCode error = ImeContextGetPredictionMode(_handle, out predictionMode);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetPredictionMode Failed with error " + error);
                    return false;
                }
                return predictionMode;
            }
        }

        /// <summary>
        /// Gets the password mode information.
        /// </summary>
        public bool PasswordMode
        {
            get
            {
                bool passwordMode;
                ErrorCode error = ImeContextGetPasswordMode(_handle, out passwordMode);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetPasswordMode Failed with error " + error);
                    return false;
                }
                return passwordMode;
            }
        }

        /// <summary>
        /// Gets the input hint information.
        /// </summary>
        public EcoreIMFInputHints InputHint
        {
            get
            {
                EcoreIMFInputHints inputHint;
                ErrorCode error = ImeContextGetInputHint(_handle, out inputHint);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetInputHint Failed with error " + error);
                    return EcoreIMFInputHints.Undefined;
                }
                return inputHint;
            }
        }

        /// <summary>
        /// Gets the text bidirectional information.
        /// </summary>
        public EcoreIMFBiDiDirection BiDiDirection
        {
            get
            {
                EcoreIMFBiDiDirection biDiDirection;
                ErrorCode error = ImeContextGetBidiDirection(_handle, out biDiDirection);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetBiDiDirection Failed with error " + error);
                    return EcoreIMFBiDiDirection.Undefined;
                }
                return biDiDirection;
            }
        }

        /// <summary>
        /// Gets the preferred language information.
        /// </summary>
        public EcoreIMFInputPanelLang Langauge
        {
            get
            {
                EcoreIMFInputPanelLang langauge;
                ErrorCode error = ImeContextGetLanguage(_handle, out langauge);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetLangauge Failed with error " + error);
                    return EcoreIMFInputPanelLang.Undefined;
                }
                return langauge;
            }
        }
    }
}
