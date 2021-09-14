using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.Devel.Tests
{
    [AttributeUsage(AttributeTargets.All)]
    public class PreserveAttribute : Attribute
    {
        public bool AllMembers;
        public bool Conditional;

        public PreserveAttribute()
        {
        }

        public PreserveAttribute(bool allMembers, bool conditional)
        {
            AllMembers = allMembers;
            Conditional = conditional;
        }
    }
}
