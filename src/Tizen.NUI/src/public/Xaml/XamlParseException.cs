/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Diagnostics;
using System.Text;
using System.Xml;

namespace Tizen.NUI.Xaml
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class XamlParseException : Exception
    {
        readonly string unformattedMessage;

        static private StringBuilder GetStackInfo()
        {
            StringBuilder ret = new StringBuilder("\nStack:\n");

            StackTrace st = new StackTrace();

            for (int i = 2; i < st.FrameCount; i++)
            {
                StackFrame sf = st.GetFrame(i);
                ret.AppendFormat("File:{0}, Method:{1}, Line:{2}\n", sf.GetFileName(), sf.GetMethod().Name, sf.GetFileLineNumber());
            }

            return ret;
        }

        /// <summary> Initializes a new instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlParseException()
        {
        }

        /// <summary> Initializes a new instance with message. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlParseException(string message) : base(message)
        {
            unformattedMessage = message;
        }

        /// <summary> Initializes a new instance with message and inner exception. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlParseException(string message, Exception innerException = null) : base(message, innerException)
        {
            unformattedMessage = message;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlParseException(string message, IXmlLineInfo xmlInfo, Exception innerException = null) : base(FormatMessage(message + GetStackInfo(), xmlInfo), innerException)
        {
            unformattedMessage = message;
            XmlInfo = xmlInfo;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IXmlLineInfo XmlInfo { get; private set; }

        internal string UnformattedMessage
        {
            get { return unformattedMessage ?? Message; }
        }

        static string FormatMessage(string message, IXmlLineInfo xmlinfo)
        {
            if (xmlinfo == null || !xmlinfo.HasLineInfo())
                return message;
            return string.Format("Position {0}:{1}. {2}", xmlinfo.LineNumber, xmlinfo.LinePosition, message);
        }
    }
}
