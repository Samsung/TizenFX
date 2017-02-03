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
using static Interop.InputMethod;

namespace Tizen.Uix.InputMethod
{
    public enum EcoreIMFInputPanelLayout
    {
        LayoutNormal,
        LayoutNumber,
        LayoutEMail,
        LayoutURL,
        LayoutPhoneNumber,
        LayoutIP,
        LayoutMonth,
        LayoutNumberOnly,
        LayoutInvalid,
        LayoutHEX,
        LayoutTerminal,
        LayoutPassword,
        LayoutDateTime,
        LayoutEmoticon,
        LayoutVoice,
        Undefined
    };

    public enum ImeLayoutVariation
    {
        NormalVariationNormal = 0, /**< The plain normal layout */
        NormalVariationFileName, /**< Filename layout; symbols such as '/', '\*', '\', '|', '&lt;', '&gt;', '?', '&quot;' and ':' should be disabled */
        NormalVariationPersonName, /**< The name of a person */
        NumberOnlyVariationNormal = 0, /**< The plain normal number layout */
        NumberOnlyVariationSigned, /**< The number layout to allow a negative sign */
        NumberOnlyVariationDecimal, /**< The number layout to allow decimal point to provide fractional value */
        NumberOnlyVariationSignedAandDecimal, /**< The number layout to allow decimal point and negative sign */
        PasswordVariationNormal = 0, /**< The normal password layout */
        PasswordVariationNumberOnly, /**< The password layout to allow only number */
        Undefined
    };

    public enum EcoreIMFAutocapitalType
    {
        None,
        Word,
        Sentence,
        AllCharacter,
        Undefined
    };

    public enum EcoreIMFInputPanelReturnKeyType
    {
        Default,
        Done,
        Go,
        Join,
        Login,
        Next,
        Search,
        Send,
        SignIn,
        Undefined
    };

    public enum EcoreIMFInputHints
    {
        None,
        AutoComplete,
        SensitiveData,
        Multiline,
        Undefined
    };

    public enum EcoreIMFBiDiDirection
    {
        Neutral,
        LTR,
        RTL,
        Undefined
    };

    public enum EcoreIMFInputPanelLang
    {
        Automatic,
        Alphabet,
        Undefined
    };
}