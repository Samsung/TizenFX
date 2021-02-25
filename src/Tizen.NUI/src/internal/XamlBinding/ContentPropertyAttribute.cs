//
// ContentPropertyAttribute.cs
//
// Author:
//       Stephane Delcroix <stephane@delcroix.org>
//
// Copyright (c) 2013 S. Delcroix
//

using System;

namespace Tizen.NUI.Binding
{
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class ContentPropertyAttribute : Attribute
    {
        internal static string[] ContentPropertyTypes = { "Tizen.NUI.Binding.ContentPropertyAttribute", "System.Windows.Markup.ContentPropertyAttribute" };

        public ContentPropertyAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
