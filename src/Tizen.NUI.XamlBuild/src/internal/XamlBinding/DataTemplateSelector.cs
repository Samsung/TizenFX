/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
    internal abstract class DataTemplateSelector : DataTemplate
    {
        Dictionary<Type, DataTemplate> _dataTemplates = new Dictionary<Type, DataTemplate>();

        public DataTemplate SelectTemplate(object item, BindableObject container)
        {
            // var listView = container as ListView;

            // var recycle = listView == null ? false :
            //     (listView.CachingStrategy & ListViewCachingStrategy.RecycleElementAndDataTemplate) ==
            //         ListViewCachingStrategy.RecycleElementAndDataTemplate;

            DataTemplate dataTemplate = null;
            // if (recycle && _dataTemplates.TryGetValue(item.GetType(), out dataTemplate))
                // return dataTemplate;

            dataTemplate = OnSelectTemplate(item, container);
            if (dataTemplate is DataTemplateSelector)
                throw new NotSupportedException(
                    "DataTemplateSelector.OnSelectTemplate must not return another DataTemplateSelector");

            // if (recycle)
            // {
            //     if (!dataTemplate.CanRecycle)
            //         throw new NotSupportedException(
            //             "RecycleElementAndDataTemplate requires DataTemplate activated with ctor taking a type.");

            //     _dataTemplates[item.GetType()] = dataTemplate;
            // }

            return dataTemplate;
        }

        protected abstract DataTemplate OnSelectTemplate(object item, BindableObject container);
    }
}
 
