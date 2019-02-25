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
using System.Reflection;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace APITool
{
    public class DummyGenerator : AssemblyProcessor
    {
        public void Run(string srcPath, string targetPath)
        {
            var asm = AssemblyDefinition.ReadAssembly(srcPath);
            ProcessAssembly(asm);
            asm.Write(targetPath);
        }

        protected override void ProcessAssembly(AssemblyDefinition asmDef)
        {
            Log.Verbose("Assembly: " + asmDef.FullName);

            var attr = asmDef.CustomAttributes.FirstOrDefault(a => a.AttributeType.FullName == "System.Runtime.CompilerServices.ReferenceAssemblyAttribute");
            if (attr != null)
            {
                asmDef.CustomAttributes.Remove(attr);
            }

            base.ProcessAssembly(asmDef);
        }

        protected override void ProcessField(FieldDefinition fieldDef)
        {
            Log.Verbose("  Field: " + fieldDef.FullName);
        }

        protected override void ProcessMethod(MethodDefinition methodDef)
        {
            Log.Verbose($"  Method: {methodDef.FullName}");
            if (methodDef.Name == "Finalize")
            {
                ReplaceWithVoidReturn(methodDef);
            }
            else
            {
                ReplaceWithThrowPNSE(methodDef);
            }
        }

        protected override void ProcessProperty(PropertyDefinition propDef)
        {
            Log.Verbose("  Property: " + propDef.FullName);
            if (propDef.GetMethod != null)
            {
                Log.Verbose("    Getter:");
                ReplaceWithThrowPNSE(propDef.GetMethod);
            }
            if (propDef.SetMethod != null)
            {
                Log.Verbose("    Setter:");
                ReplaceWithThrowPNSE(propDef.SetMethod);
            }
        }

        protected override void ProcessEvent(EventDefinition eventDef)
        {
            Log.Verbose("  Event: " + eventDef.FullName);
            if (eventDef.AddMethod != null)
            {
                Log.Verbose("    Add:");
                ReplaceWithThrowPNSE(eventDef.AddMethod);
            }
            if (eventDef.RemoveMethod != null)
            {
                Log.Verbose("    Remove:");
                ReplaceWithThrowPNSE(eventDef.RemoveMethod);
            }
            foreach (var method in eventDef.OtherMethods)
            {
                Log.Verbose("    Other: " + method.FullName);
                ReplaceWithThrowPNSE(method);
            }
        }

        private bool ReplaceWithThrowPNSE(MethodDefinition method)
        {
            if (method.HasBody && method.IsIL)
            {
                ClearMethodBody(method);

                ConstructorInfo exceptionCtor = typeof(PlatformNotSupportedException).GetConstructor(new Type[] { typeof(System.String) });
                var exceptionCtorRef = method.Module.ImportReference(exceptionCtor);

                var processor = method.Body.GetILProcessor();
                processor.Append(processor.Create(OpCodes.Ldstr, "Not Supported Feature"));
                processor.Append(processor.Create(OpCodes.Newobj, exceptionCtorRef));
                processor.Append(processor.Create(OpCodes.Throw));

                PrintMethodBody(method);

                return true;
            }
            return false;
        }

        private void ReplaceWithVoidReturn(MethodDefinition method)
        {
            if (method.HasBody && method.IsIL)
            {
                ClearMethodBody(method);

                var processor = method.Body.GetILProcessor();
                processor.Append(processor.Create(OpCodes.Nop));
                processor.Append(processor.Create(OpCodes.Ret));

                PrintMethodBody(method);
            }
        }

        private void ClearMethodBody(MethodDefinition method)
        {
            var processor = method.Body.GetILProcessor();
            while (method.Body.Instructions.Count > 0)
            {
                processor.Remove(method.Body.Instructions[0]);
            }
        }

        private void PrintMethodBody(MethodDefinition method)
        {
            if (method.HasBody)
            {
                foreach (var inst in method.Body.Instructions)
                {
                    Log.Verbose($"      {inst.ToString()}");
                }
            }
        }
    }
}
