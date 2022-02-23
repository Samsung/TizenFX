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
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Tizen.NUI.Binding;
using Tizen.NUI.EXaml.Build.Tasks;

namespace Tizen.NUI.EXaml
{
    //use &&
    internal class EXamlRegisterXName : EXamlOperation
    {
        internal override string Write()
        {
            string ret = String.Format("({0} ({1} {2}))\n",
                         eXamlContext.GetValueString((int)EXamlOperationType.RegisterXName),
                         eXamlContext.GetValueString(Instance),
                         eXamlContext.GetValueString(XName));

            return ret;
        }

        public EXamlRegisterXName(EXamlContext context, object @object, string xName)
            : base(context)
        {
            Instance = @object;
            XName = xName;
            eXamlContext.eXamlOperations.Add(this);

            eXamlContext.xNameToInstance.Add(xName, @object);
        }

        public object Instance
        {
            get;
        }

        public string XName
        {
            get;
        }
    }
}
