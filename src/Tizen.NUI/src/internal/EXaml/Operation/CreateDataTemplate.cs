using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.Binding;

namespace Tizen.NUI.EXaml
{
    class CreateDataTemplate : Operation
    {
        public CreateDataTemplate(GlobalDataList globalDataList, List<object> operationInfo)
        {
            typeIndex = (int)operationInfo[0];
            indexRangeOfContent = ((int)operationInfo[1], (int)operationInfo[2]);
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;
        private int typeIndex;
        private (int, int) indexRangeOfContent;

        public void Do()
        {
            var content = globalDataList.LongStrings.Substring(indexRangeOfContent.Item1, indexRangeOfContent.Item2 - indexRangeOfContent.Item1 + 1);
            var dataTemplate = new DataTemplate(() =>
            {
                object ret = EXamlExtensions.CreateObjectFromEXaml(content);
                return ret;
            });

            globalDataList.GatheredInstances.Add(dataTemplate);

            if (null == globalDataList.Root)
            {
                globalDataList.Root = dataTemplate;
            }
        }
    }
}
