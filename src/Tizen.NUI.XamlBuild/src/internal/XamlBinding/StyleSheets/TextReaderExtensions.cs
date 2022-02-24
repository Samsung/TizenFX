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
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Tizen.NUI.StyleSheets
{
    internal static class TextReaderExtensions
    {
        //ident [-]?{nmstart}{nmchar}*
        public static string ReadIdent(this TextReader reader)
        {
            var sb = new StringBuilder();
            bool first = true;
            bool hasLeadingDash = false;
            int p;
            while ((p = reader.Peek()) > 0) {
                var c = unchecked((char)p);
                if (first && !hasLeadingDash && c == '-') {
                    sb.Append((char)reader.Read());
                    hasLeadingDash = true;
                } else if (first && c.IsNmStart()) {
                    sb.Append((char)reader.Read());
                    first = false;
                } else if (first) { //a nmstart is expected
                    throw new Exception();
                } else if (c.IsNmChar())
                    sb.Append((char)reader.Read());
                else
                    break;
            }
            return sb.ToString();
        }

        //name {nmchar}+
        public static string ReadName(this TextReader reader)
        {
            var sb = new StringBuilder();
            int p;
            while ((p = reader.Peek()) > 0) {
                var c = unchecked((char)p);
                if (c.IsNmChar())
                    sb.Append((char)reader.Read());
                else
                    break;
            }
            return sb.ToString();
        }

        public static string ReadUntil(this TextReader reader, params char[] limit)
        {
            var sb = new StringBuilder();
            int p;
            while ((p = reader.Peek()) > 0) {
                var c = unchecked((char)p);
                if (limit != null && limit.Contains(c))
                    break;
                reader.Read();
                sb.Append(c);
            }
            return sb.ToString();
        }

        //w [ \t\r\n\f]*
        public static void SkipWhiteSpaces(this TextReader reader)
        {
            int p;
            while ((p = reader.Peek()) > 0) {
                var c = unchecked((char)p);
                if (!c.IsW())
                    break;
                reader.Read();
            }
        }
    }
}
 
