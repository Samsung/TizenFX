
/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Runtime.CompilerServices;

namespace Tizen.NUI.StyleSheets
{
    internal static class CharExtensions
    {
        //w [ \t\r\n\f]*
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsW(this char c)
        {
            return c == ' '
                || c == '\t'
                || c == '\r'
                || c == '\n'
                || c == '\f';
        }

        //nmstart   [_a-z]|{nonascii}|{escape}
        //escape    {unicode}|\\[^\n\r\f0-9a-f]
        //nonascii  [^\0-\237]
        // TODO support escape and nonascii
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNmStart(this char c)
        {
            return c == '_' || char.IsLetter(c);
        }

        //nmchar    [_a-z0-9-]|{nonascii}|{escape}
        //unicode    \\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?
        //escape    {unicode}|\\[^\n\r\f0-9a-f]
        //nonascii    [^\0-\237]
        //TODO support escape, nonascii and unicode
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNmChar(this char c)
        {
            return c == '_'
                || c == '-'
                || char.IsLetterOrDigit(c);
        }
    }
}
 
