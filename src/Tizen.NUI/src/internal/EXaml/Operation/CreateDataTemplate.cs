using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.Binding;

namespace Tizen.NUI.EXaml
{
    class CreateDataTemplate : Operation
    {
        public CreateDataTemplate(GlobalDataList globalDataList, int typeIndex, (int, int) indexRangeOfContent)
        {
            this.typeIndex = typeIndex;
            this.indexRangeOfContent = indexRangeOfContent;
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
