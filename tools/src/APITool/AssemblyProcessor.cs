/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Linq;
using Mono.Cecil;

namespace APITool
{
    public abstract class AssemblyProcessor
    {
        protected virtual void ProcessAssembly(AssemblyDefinition asmDef)
        {
            foreach (var module in asmDef.Modules.OrderBy(x => x.Name))
            {
                ProcessModule(module);
            }
        }

        protected virtual void ProcessModule(ModuleDefinition moduleDef)
        {
            foreach (var typedef in moduleDef.Types.OrderBy(x => x.FullName))
            {
                ProcessType(typedef);
            }
        }

        protected virtual void ProcessType(TypeDefinition typeDef)
        {
            foreach (var field in typeDef.Fields.OrderBy(x => x.FullName))
            {
                ProcessField(field);
            }

            foreach (var prop in typeDef.Properties.OrderBy(x => x.FullName))
            {
                ProcessProperty(prop);
            }

            foreach (var method in typeDef.Methods.OrderBy(x => x.FullName))
            {
                ProcessMethod(method);
            }

            foreach (var ev in typeDef.Events.OrderBy(x => x.FullName))
            {
                ProcessEvent(ev);
            }

            foreach (var nt in typeDef.NestedTypes.OrderBy(x => x.FullName))
            {
                ProcessType(nt);
            }
        }

        protected abstract void ProcessField(FieldDefinition fieldDef);

        protected abstract void ProcessProperty(PropertyDefinition propDef);

        protected abstract void ProcessEvent(EventDefinition eventDef);

        protected abstract void ProcessMethod(MethodDefinition methodDef);

    }
}
