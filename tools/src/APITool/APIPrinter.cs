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

using System;
using System.IO;
using System.Linq;
using Mono.Cecil;

namespace APITool
{
    public class APIPrinter : AssemblyProcessor
    {
        ListOptions _options;
        bool _isPrintAll;

        StreamWriter _writer;

        public APIPrinter(ListOptions options)
        {
            _options = options;
            _isPrintAll = !(options.PrintTypes | options.PrintFields | options.PrintProperties | options.PrintEvents | options.PrintMethods);

            if (!string.IsNullOrEmpty(options.OutputFile)) {
                _writer = new StreamWriter(options.OutputFile);
            } else {
                _writer = new StreamWriter(Console.OpenStandardOutput());
            }
        }

        public void Run(string filepath)
        {
            var asm = AssemblyDefinition.ReadAssembly(filepath);
            ProcessAssembly(asm);
        }

        protected override void ProcessType(TypeDefinition typeDef)
        {
            if (typeDef.IsPublic)
            {
                bool isHidden = IsHidden(typeDef.CustomAttributes);
                if (_options.PrintHiddens || !isHidden)
                {
                    if (_isPrintAll || _options.PrintTypes)
                    {
                        _writer.WriteLine("T: {0}{1}{2}",
                            isHidden ? "*hidden* " : string.Empty,
                            typeDef.FullName,
                            typeDef.BaseType != null ? " : " + typeDef.BaseType.FullName : string.Empty);
                        _writer.Flush();
                    }
                    base.ProcessType(typeDef);
                }
            }
        }

        protected override void ProcessField(FieldDefinition fieldDef)
        {
            if (fieldDef.IsPublic && fieldDef.IsLiteral)
            {
                bool isHidden = IsHidden(fieldDef.CustomAttributes);
                if ((_isPrintAll || _options.PrintFields) && (_options.PrintHiddens || !isHidden))
                {
                    _writer.WriteLine("F: {0}{1}{2}{3}",
                        isHidden ? "*hidden* " : string.Empty,
                        fieldDef.IsStatic ? "static " : string.Empty,
                        fieldDef.FullName,
                        fieldDef.HasConstant ? " = " + fieldDef.Constant : string.Empty);
                    _writer.Flush();
                }
            }
        }

        protected override void ProcessProperty(PropertyDefinition propDef)
        {
            bool isHidden = IsHidden(propDef.CustomAttributes);
            if ((_isPrintAll || _options.PrintProperties) && (_options.PrintHiddens || !isHidden))
            {
                _writer.WriteLine("P: {0}{1} {{ {2}{3} }}",
                    isHidden ? "*hidden* " : string.Empty,
                    propDef.FullName,
                    propDef.GetMethod != null ? "get;" : string.Empty,
                    propDef.SetMethod != null ? " set;" : string.Empty);
                _writer.Flush();
            }
        }

        protected override void ProcessEvent(EventDefinition eventDef)
        {
            bool isHidden = IsHidden(eventDef.CustomAttributes);
            if ((_isPrintAll || _options.PrintEvents) && (_options.PrintHiddens || !isHidden))
            {
                _writer.WriteLine("E: {0}{1}",
                    isHidden ? "*hidden* " : string.Empty,
                    eventDef.FullName);
                _writer.Flush();
            }
        }

        protected override void ProcessMethod(MethodDefinition methodDef)
        {
            if (methodDef.IsPublic && !methodDef.IsGetter && !methodDef.IsSetter && !methodDef.IsAddOn && !methodDef.IsRemoveOn)
            {
                bool isHidden = IsHidden(methodDef.CustomAttributes);
                if ((_isPrintAll || _options.PrintMethods) && (_options.PrintHiddens || !isHidden))
                {
                    _writer.WriteLine("M: {0}{1}",
                        isHidden ? "*hidden* " : string.Empty,
                        methodDef.FullName);
                    _writer.Flush();
                }
            }
        }

        bool IsHidden(Mono.Collections.Generic.Collection<CustomAttribute> attrs)
        {
            bool ret = false;
            var attr = attrs.FirstOrDefault(a => a.AttributeType.FullName == "System.ComponentModel.EditorBrowsableAttribute");
            if (attr != null)
            {
                if (attr.ConstructorArguments.Count > 0)
                {
                    ret = (int)attr.ConstructorArguments[0].Value == (int)System.ComponentModel.EditorBrowsableState.Never;
                }
            }
            return ret;
        }

    }
}
