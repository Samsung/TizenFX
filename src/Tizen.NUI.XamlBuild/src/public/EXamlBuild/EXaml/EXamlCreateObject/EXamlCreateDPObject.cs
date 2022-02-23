using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.EXaml.Build.Tasks;

namespace Tizen.NUI.EXaml
{
    internal class EXamlCreateDPObject : EXamlCreateObject
    {
        public EXamlCreateDPObject(EXamlContext context, object value, TypeReference type, string prefix) : base(context, null, type)
        {
            this.value = value;
            this.prefix = prefix;
        }

        internal override string Write()
        {
            if (false == IsValid)
            {
                return "";
            }

            string ret = String.Format("({0} ({1} {2}))\n",
                         eXamlContext.GetValueString((int)EXamlOperationType.CreateDPObject),
                         eXamlContext.GetValueString(value.ToString() + prefix),
                         eXamlContext.GetValueString(eXamlContext.GetTypeIndex(Type)));

            return ret;
        }

        private object value;
        private string prefix;
    }
}
