using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class RegisterXName : Operation
    {
        public RegisterXName(object instance, string name)
        {
            this.instance = instance;
            this.name = name;
        }

        public void Do()
        {
            object realInstance = null;
            if (instance is Instance)
            {
                realInstance = LoadEXaml.GatheredInstances[(instance as Instance).Index];
            }
            else
            {
                realInstance = instance;
            }

            var namescope = NameScope.GetNameScope(CreateInstance.Root as BindableObject);
            namescope?.RegisterName(name, realInstance);
        }

        private object instance;
        private string name;
    }
}
