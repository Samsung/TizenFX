using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.EXaml
{
    internal interface Action
    {
        void Init();

        void OnActive();

        Action DealChar(char c);
    }

    internal class Instance
    {
        internal Instance(int index)
        {
            Index = index;
        }
        internal int Index
        {
            get;
        }
    }
}
