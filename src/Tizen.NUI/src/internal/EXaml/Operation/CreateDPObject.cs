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
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.EXaml
{
    internal class CreateDPObject : Operation
    {
        public CreateDPObject(GlobalDataList globalDataList, List<object> operationInfos)
        {
            this.valueStr = operationInfos[0] as string;
            this.typeIndex = (int)operationInfos[1];
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            if (0 > typeIndex)
            {
                object dpValue = null;

                switch (typeIndex)
                {
                    case -3:
                        dpValue = Convert.ToInt16(GraphicsTypeManager.Instance.ConvertScriptToPixel(valueStr));
                        break;

                    case -4:
                        dpValue = Convert.ToInt32(GraphicsTypeManager.Instance.ConvertScriptToPixel(valueStr));
                        break;

                    case -5:
                        dpValue = Convert.ToInt64(GraphicsTypeManager.Instance.ConvertScriptToPixel(valueStr));
                        break;

                    case -7:
                        dpValue = Convert.ToUInt16(GraphicsTypeManager.Instance.ConvertScriptToPixel(valueStr));
                        break;

                    case -8:
                        dpValue = Convert.ToUInt32(GraphicsTypeManager.Instance.ConvertScriptToPixel(valueStr));
                        break;

                    case -9:
                        dpValue = Convert.ToInt64(GraphicsTypeManager.Instance.ConvertScriptToPixel(valueStr));
                        break;

                    case -15:
                        dpValue = Convert.ToSingle(GraphicsTypeManager.Instance.ConvertScriptToPixel(valueStr));
                        break;

                    case -16:
                        dpValue = Convert.ToDouble(GraphicsTypeManager.Instance.ConvertScriptToPixel(valueStr));
                        break;
                }

                if (null == dpValue)
                {
                    throw new Exception($"Can't convert {valueStr} to DP value of typeIndex {typeIndex}");
                }

                globalDataList.GatheredInstances.Add(dpValue);
            }
            else
            {
                var type = globalDataList.GatheredTypes[typeIndex];
                throw new Exception($"Can't convert DP value of type {type.FullName}");
            }
        }

        private int typeIndex;
        private string valueStr;
    }
}
