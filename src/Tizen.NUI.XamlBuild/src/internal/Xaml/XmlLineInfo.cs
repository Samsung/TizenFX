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
using System.Xml;

namespace Tizen.NUI.Xaml
{
    internal class XmlLineInfo : IXmlLineInfo
    {
        readonly bool _hasLineInfo;
        private int v1;
        private int v2;

        public XmlLineInfo()
        {
        }

        public XmlLineInfo(int linenumber, int lineposition)
        {
            _hasLineInfo = true;
            LineNumber = linenumber;
            LinePosition = lineposition;
        }

        public bool HasLineInfo()
        {
            return _hasLineInfo;
        }

        public int LineNumber { get; }

        public int LinePosition { get; }
    }
}
 
