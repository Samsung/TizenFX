using System;

namespace Tizen.NUI.Binding
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