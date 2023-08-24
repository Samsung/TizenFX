/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// Selects DataTemplate objects by data type and container.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class DataTemplateSelector : DataTemplate
    {
        Dictionary<Type, DataTemplate> _dataTemplates = new Dictionary<Type, DataTemplate>();

        /// <summary>
        /// Returns a DataTemplate for item by calling
        /// OnSelectTemplate(Object, BindableObject) and verifying its result.
        /// </summary>
        /// <param name="item">The data for which to return a template.</param>
        /// <param name="container">An optional container object in which
        /// the developer may have opted to store DataTemplateSelector objects.</param>
        /// <returns>A developer-defined DataTemplate that can be used to display item.</returns>
        /// <since_tizen> 9 </since_tizen>
        public DataTemplate SelectTemplate(object item, BindableObject container)
        {
            DataTemplate dataTemplate = null;
            if (_dataTemplates.TryGetValue(item.GetType(), out dataTemplate))
            {
                return dataTemplate;
            }

            dataTemplate = OnSelectTemplate(item, container);
            if (dataTemplate is DataTemplateSelector)
                throw new NotSupportedException(
                    "DataTemplateSelector.OnSelectTemplate must not return another DataTemplateSelector");

            return dataTemplate;
        }

        /// <summary>
        /// The developer overrides this method to return a valid data template for the specified item.
        /// This method is called by SelectTemplate(Object, BindableObject).
        /// </summary>
        /// <param name="item">The data for which to return a template.</param>
        /// <param name="container">An optional container object in which
        /// the developer may have opted to store DataTemplateSelector objects.</param>
        /// <returns>A developer-defined DataTemplate that can be used to display item.</returns>
        /// <since_tizen> 9 </since_tizen>
        protected abstract DataTemplate OnSelectTemplate(object item, BindableObject container);
    }
}
