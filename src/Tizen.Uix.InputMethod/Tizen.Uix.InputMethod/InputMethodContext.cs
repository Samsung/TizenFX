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
    /// Enumeration for the input panel layout.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum InputPanelLayout
    {
        /// <summary>
        /// Normal.
        /// </summary>
        LayoutNormal,
        /// <summary>
        /// Number.
        /// </summary>
        LayoutNumber,
        /// <summary>
        /// Email.
        /// </summary>
        LayoutEMail,
        /// <summary>
        /// URL.
        /// </summary>
        LayoutURL,
        /// <summary>
        /// Phone Number.
        /// </summary>
        LayoutPhoneNumber,
        /// <summary>
        /// IP.
        /// </summary>
        LayoutIP,
        /// <summary>
        /// Month.
        /// </summary>
        LayoutMonth,
        /// <summary>
        /// Number Only.
        /// </summary>
        LayoutNumberOnly,
        /// <summary>
        /// Invalid.
        /// </summary>
        LayoutInvalid,
        /// <summary>
        /// HEX.
        /// </summary>
        LayoutHEX,
        /// <summary>
        /// Terminal.
        /// </summary>
        LayoutTerminal,
        /// <summary>
        /// Password.
        /// </summary>
        LayoutPassword,
        /// <summary>
        /// Date and time.
        /// </summary>
        LayoutDateTime,
        /// <summary>
        /// Emoticon.
        /// </summary>
        LayoutEmoticon,
        /// <summary>
        /// Voice.
        /// </summary>
        LayoutVoice,
        /// <summary>
        /// Undefined.
        /// </summary>
        Undefined
    };

    /// <summary>
    /// Enumeration for the layout variation.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum LayoutVariation
    {
        /// <summary>
        /// The plain normal layout.
        /// </summary>
        NormalNormal = 0,
        /// <summary>
        /// Filename layout; symbols such as '/', '\*', '\', '|', '&lt;', '&gt;', '?', '&quot;', and ':' should be disabled.
        /// </summary>
        NormalFileName,
        /// <summary>
        /// The name of a person.
        /// </summary>
        NormalPersonName,
        /// <summary>
        /// The plain normal number layout.
        /// </summary>
        NumberOnlyNormal = 0,
        /// <summary>
        /// The number layout to allow a negative sign.
        /// </summary>
        NumberOnlySigned,
        /// <summary>
        /// The number layout to allow a decimal point to provide fractional value.
        /// </summary>
        NumberOnlyDecimal,
        /// <summary>
        /// The number layout to allow a decimal point and negative sign.
        /// </summary>
        NumberOnlySignedAndDecimal,
        /// <summary>
        /// The normal password layout.
        /// </summary>
        PasswordNormal = 0,
        /// <summary>
        /// The password layout to allow only a number.
        /// </summary>
        PasswordNumberOnly,
        /// <summary>
        /// Undefined.
        /// </summary>
        Undefined
    };

    /// <summary>
    /// Enumeration for the AutoCapital types.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum AutoCapitalization
    {
        /// <summary>
        /// None.
        /// </summary>
        None,
        /// <summary>
        /// Word.
        /// </summary>
        Word,
        /// <summary>
        /// Sentence.
        /// </summary>
        Sentence,
        /// <summary>
        /// All characters.
        /// </summary>
        AllCharacter,
        /// <summary>
        /// Undefined.
        /// </summary>
        Undefined
    };

    /// <summary>
    /// Enumeration for the InputPanel ReturnKey types.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum InputPanelReturnKey
    {
        /// <summary>
        /// Default.
        /// </summary>
        Default,
        /// <summary>
        /// Done.
        /// </summary>
        Done,
        /// <summary>
        /// Go.
        /// </summary>
        Go,
        /// <summary>
        /// Join.
        /// </summary>
        Join,
        /// <summary>
        /// Login.
        /// </summary>
        Login,
        /// <summary>
        /// Next.
        /// </summary>
        Next,
        /// <summary>
        /// Search.
        /// </summary>
        Search,
        /// <summary>
        /// Send.
        /// </summary>
        Send,
        /// <summary>
        /// SignIn.
        /// </summary>
        SignIn,
        /// <summary>
        /// Undefined.
        /// </summary>
        Undefined
    };

    /// <summary>
    /// Enumeration for the InputHints.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Flags]
    public enum InputHints
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// AutoComplete.
        /// </summary>
        AutoComplete = 1 << 0,
        /// <summary>
        /// SensitiveData.
        /// </summary>
        SensitiveData = 1 << 1,
        /// <summary>
        /// Multiline.
        /// </summary>
        Multiline = 1 << 2,
        /// <summary>
        /// Undefined.
        /// </summary>
        Undefined = 0
    };

    /// <summary>
    /// Enumeration for the BiDirection.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum BiDirection
    {
        /// <summary>
        /// Neutral.
        /// </summary>
        Neutral,
        /// <summary>
        /// LTR.
        /// </summary>
        LTR,
        /// <summary>
        /// RTL.
        /// </summary>
        RTL,
        /// <summary>
        /// Undefined.
        /// </summary>
        Undefined
    };

    /// <summary>
    /// Enumeration for the InputPanel language.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum InputPanelLanguage
    {
        /// <summary>
        /// Automatic.
        /// </summary>
        Automatic,
        /// <summary>
        /// Alphabet.
        /// </summary>
        Alphabet,
        /// <summary>
        /// Undefined.
        /// </summary>
        Undefined
    };

    /// <summary>
    /// This class represents the context of the InputMethodEditor.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        public InputPanelLayout Layout
        {
            get
            {
                InputPanelLayout layout;
                ErrorCode error = ImeContextGetLayout(_handle, out layout);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetLayout Failed with error " + error);
                    return InputPanelLayout.Undefined;
                }
                return layout;
            }
        }

        /// <summary>
        /// Gets the layout variation information.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public LayoutVariation LayoutVariation
        {
            get
            {
                LayoutVariation layoutVariation;
                ErrorCode error = ImeContextGetLayoutVariation(_handle, out layoutVariation);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetLayoutVariation Failed with error " + error);
                    return LayoutVariation.Undefined;
                }
                return layoutVariation;
            }
        }

        /// <summary>
        /// Gets the cursor position information.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        public AutoCapitalization AutoCapitalization
        {
            get
            {
                AutoCapitalization autoCapitalType;
                ErrorCode error = ImeContextGetAutocapitalType(_handle, out autoCapitalType);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetAutoCapitalization Failed with error " + error);
                    return AutoCapitalization.Undefined;
                }
                return autoCapitalType;
            }
        }

        /// <summary>
        /// Gets the Return key label type information.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public InputPanelReturnKey ReturnKey
        {
            get
            {
                InputPanelReturnKey returnKeyType;
                ErrorCode error = ImeContextGetReturnKey(_handle, out returnKeyType);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetReturnKey Failed with error " + error);
                    return InputPanelReturnKey.Undefined;
                }
                return returnKeyType;
            }
        }

        /// <summary>
        /// Gets the Return key state information.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        public InputHints InputHint
        {
            get
            {
                InputHints inputHint;
                ErrorCode error = ImeContextGetInputHint(_handle, out inputHint);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetInputHint Failed with error " + error);
                    return InputHints.Undefined;
                }
                return inputHint;
            }
        }

        /// <summary>
        /// Gets the text bidirectional information.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public BiDirection BiDirection
        {
            get
            {
                BiDirection biDiDirection;
                ErrorCode error = ImeContextGetBidiDirection(_handle, out biDiDirection);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetBiDirection Failed with error " + error);
                    return BiDirection.Undefined;
                }
                return biDiDirection;
            }
        }

        /// <summary>
        /// Gets the preferred language information.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public InputPanelLanguage Language
        {
            get
            {
                InputPanelLanguage langauge;
                ErrorCode error = ImeContextGetLanguage(_handle, out langauge);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetLanguage Failed with error " + error);
                    return InputPanelLanguage.Undefined;
                }
                return langauge;
            }
        }
    }
}
