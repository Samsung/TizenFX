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
using System.Diagnostics;

namespace Tizen.NUI.Xaml
{
    [DebuggerDisplay("{NamespaceURI}:{LocalName}")]
    internal struct XmlName : IEquatable<XmlName>
    {
        public static readonly XmlName _CreateContent = new XmlName("_", "CreateContent");
        public static readonly XmlName xKey = new XmlName("x", "Key");
        public static readonly XmlName xName = new XmlName("x", "Name");
        public static readonly XmlName xTypeArguments = new XmlName("x", "TypeArguments");
        public static readonly XmlName xArguments = new XmlName("x", "Arguments");
        public static readonly XmlName xFactoryMethod = new XmlName("x", "FactoryMethod");
        public static readonly XmlName xDataType = new XmlName("x", "DataType");
        public static readonly XmlName Empty = new XmlName();

        public string NamespaceURI { get; }
        public string LocalName { get; }

        public XmlName(string namespaceUri, string localName)
        {
            NamespaceURI = namespaceUri;
            LocalName = localName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != typeof(XmlName))
                return false;
            var other = (XmlName)obj;
            return NamespaceURI == other.NamespaceURI && LocalName == other.LocalName;
        }

        public bool Equals(XmlName other)
            => NamespaceURI == other.NamespaceURI && LocalName == other.LocalName;

        public bool Equals(string namespaceUri, string localName)
            => Equals(new XmlName(namespaceUri, localName));

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                if (NamespaceURI != null)
                    hashCode = NamespaceURI.GetHashCode();
                if (LocalName != null)
                    hashCode = (hashCode * 397) ^ LocalName.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(XmlName x1, XmlName x2)
            => x1.NamespaceURI == x2.NamespaceURI && x1.LocalName == x2.LocalName;

        public static bool operator !=(XmlName x1, XmlName x2)
            => !(x1 == x2);
    }
}
