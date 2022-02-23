using System.Collections.Generic;

using Mono.Cecil;
using Mono.Cecil.Cil;
using Tizen.NUI.Xaml.Build.Tasks;

namespace Tizen.NUI.Xaml
{
    interface ICompiledValueProvider
    {
        IEnumerable<Instruction> ProvideValue(VariableDefinitionReference vardefref, ModuleDefinition module, BaseNode node, ILContext context);
    }
}