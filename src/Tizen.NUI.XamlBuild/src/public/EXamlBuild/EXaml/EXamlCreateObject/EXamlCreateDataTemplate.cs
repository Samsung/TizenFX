using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.EXaml.Build.Tasks;

namespace Tizen.NUI.EXaml
{
    internal class EXamlCreateDataTemplate : EXamlCreateObject
    {
        public EXamlCreateDataTemplate(EXamlContext context, TypeReference type, string content) : base(context, null, type)
        {
            indexRangeOfContent = eXamlContext.GetLongStringIndexs(content);
        }

        private (int, int) indexRangeOfContent;

        internal override string Write()
        {
            if (false == IsValid)
            {
                return "";
            }

            string ret = String.Format("({0} ({1} {2} {3}))\n",
                         eXamlContext.GetValueString((int)EXamlOperationType.CreateDataTemplate),
                         eXamlContext.GetValueString(eXamlContext.GetTypeIndex(Type)),
                         eXamlContext.GetValueString(indexRangeOfContent.Item1),
                         eXamlContext.GetValueString(indexRangeOfContent.Item2));

            return ret;
        }
    }
}
