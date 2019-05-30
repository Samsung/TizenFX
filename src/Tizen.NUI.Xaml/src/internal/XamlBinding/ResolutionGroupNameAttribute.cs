using System;

namespace Tizen.NUI.XamlBinding
{
    [AttributeUsage(AttributeTargets.Assembly)]
    internal class ResolutionGroupNameAttribute : Attribute
    {
        public ResolutionGroupNameAttribute(string name)
        {
            ShortName = name;
        }

        internal string ShortName { get; private set; }
    }
}