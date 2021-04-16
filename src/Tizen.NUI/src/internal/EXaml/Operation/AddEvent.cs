using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class AddEvent : Operation
    {
        public AddEvent(int instanceIndex, int elementIndex, int eventIndex, int valueIndex)
        {
            this.instanceIndex = instanceIndex;
            this.elementIndex = elementIndex;
            this.eventIndex = eventIndex;
            this.valueIndex = valueIndex;
        }

        public void Do()
        {
            object instance = LoadEXaml.GatheredInstances[instanceIndex];
            object element = LoadEXaml.GatheredInstances[elementIndex];
            var eventInfo = GatherEvent.GatheredEvents[eventIndex];
            try
            {
                var methodInfo = GatherMethod.GatheredMethods[valueIndex];
                eventInfo.AddEventHandler(instance, methodInfo.CreateDelegate(eventInfo.EventHandlerType, element));
            }
            catch (ArgumentException ae)
            {
                Tizen.Log.Fatal("EXaml", ae.ToString());
            }
        }

        private int instanceIndex;
        private int elementIndex;
        private int eventIndex;
        private int valueIndex;
    }
}
