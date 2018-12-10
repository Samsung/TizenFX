/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace GenDummy
{
    public class Converter
    {
        private AssemblyDefinition _asm;

        public Converter(string srcAssemblyPath)
        {
            _asm = AssemblyDefinition.ReadAssembly(srcAssemblyPath);
        }

        public void ConvertTo(string targetAssemblyPath)
        {
            VisitAssembly(_asm);
            _asm.Write(targetAssemblyPath);
        }

        private void VisitAssembly(AssemblyDefinition assembly)
        {
            Log.Verbose("Assembly: " + assembly.FullName);

            var attr = assembly.CustomAttributes.FirstOrDefault(a => a.AttributeType.FullName == "System.Runtime.CompilerServices.ReferenceAssemblyAttribute");
            if (attr != null) {
                assembly.CustomAttributes.Remove(attr);
            }

            foreach (var module in assembly.Modules)
            {
                VisitModule(module);
            }
        }

        private void VisitModule(ModuleDefinition module)
        {
            Log.Verbose("Module: " + module.Name);
            foreach (var type in module.Types)
            {
                VisitType(type);
            }
        }

        private void VisitType(TypeDefinition type)
        {
            Log.Verbose("Type: " + type.FullName);

            foreach (var prop in type.Properties)
            {
                VisitProperty(prop);
            }

            foreach (var method in type.Methods)
            {
                VisitMethod(method);
            }

            foreach (var ev in type.Events)
            {
                VisitEvent(ev);
            }

            foreach (var nested in type.NestedTypes)
            {
                VisitType(nested);
            }
        }

        private void VisitProperty(PropertyDefinition prop)
        {
            Log.Verbose("  Property: " + prop.FullName);
            if (prop.GetMethod != null)
            {
                Log.Verbose("    Getter:");
                ReplaceWithThrowPNSE(prop.GetMethod);
            }
            if (prop.SetMethod != null)
            {
                Log.Verbose("    Setter:");
                ReplaceWithThrowPNSE(prop.SetMethod);
            }
        }

        private void VisitMethod(MethodDefinition method)
        {
            Log.Verbose($"  Method: {method.FullName}");
            if (method.Name == "Finalize")
            {
                ReplaceWithVoidReturn(method);
            }
            else
            {
                ReplaceWithThrowPNSE(method);
            }
        }

        private void VisitEvent(EventDefinition ev)
        {
            Log.Verbose("  Event: " + ev.FullName);
            if (ev.AddMethod != null)
            {
                Log.Verbose("    Add:");
                ReplaceWithThrowPNSE(ev.AddMethod);
            }
            if (ev.RemoveMethod != null)
            {
                Log.Verbose("    Remove:");
                ReplaceWithThrowPNSE(ev.RemoveMethod);
            }
            foreach (var method in ev.OtherMethods)
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

        private bool ReplaceWithVoidReturn(MethodDefinition method)
        {
            if (method.HasBody && method.IsIL)
            {
                ClearMethodBody(method);

                var processor = method.Body.GetILProcessor();
                processor.Append(processor.Create(OpCodes.Nop));
                processor.Append(processor.Create(OpCodes.Ret));

                PrintMethodBody(method);

                return true;
            }
            return false;
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
                var iLProcessor = method.Body.GetILProcessor();
                foreach (var inst in method.Body.Instructions)
                {
                    Log.Verbose($"      {inst.ToString()}");
                }
            }
        }
    }

}