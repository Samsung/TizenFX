using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.EXaml
{
    internal class GatherTypeObject : Operation
    {
        public GatherTypeObject(GlobalDataList globalDataList, int typeIndex)
        {
            this.typeIndex = typeIndex;
            this.globalDataList = globalDataList;
        }

        public void Do()
        {
            var type = globalDataList.GatheredTypes[typeIndex];

            if (null != type)
            {
                globalDataList.GatheredInstances.Add(type);
            }
        }

        private int typeIndex;
        private GlobalDataList globalDataList;
    }
}
