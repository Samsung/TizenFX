using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    class VariableDefinitionReference
    {
        public VariableDefinitionReference(VariableDefinition vardef)
        {
            VariableDefinition = vardef;
        }

        public VariableDefinition VariableDefinition { get; set; }

        public static implicit operator VariableDefinition(VariableDefinitionReference vardefref)
        {
            return vardefref.VariableDefinition;
        }
    }
}
