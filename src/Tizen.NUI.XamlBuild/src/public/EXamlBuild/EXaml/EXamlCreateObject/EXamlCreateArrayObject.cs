using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.EXaml.Build.Tasks;

namespace Tizen.NUI.EXaml
{
    internal class EXamlCreateArrayObject : EXamlCreateObject
    {
        public EXamlCreateArrayObject(EXamlContext context, TypeReference type, List<object> items) : base(context, null, type)
        {
            this.items = items;
        }

        internal override string Write()
        {
            if (false == IsValid)
            {
                return "";
            }

            string itemsString = "";
            if (0 < items.Count)
            {
                itemsString += "(";

                foreach (var item in items)
                {
                    itemsString += $"{eXamlContext.GetValueString(item)} ";
                }

                itemsString += ")";
            }

            string ret = String.Format("({0} ({1} {2}))\n",
                         eXamlContext.GetValueString((int)EXamlOperationType.CreateArrayObject),
                         eXamlContext.GetValueString(eXamlContext.GetTypeIndex(Type)),
                         itemsString);

            return ret;
        }

        private List<object> items;
    }
}
