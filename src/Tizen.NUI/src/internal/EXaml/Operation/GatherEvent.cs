using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class GatherEvent : Operation
    {
        public GatherEvent(int typeIndex, string eventName)
        {
            this.typeIndex = typeIndex;
            this.eventName = eventName;
        }

        public void Do()
        {
            var type = GatherType.GatheredTypes[typeIndex];
            GatheredEvents.Add(type.GetEvent(eventName));
        }

        private int typeIndex;
        private string eventName;
        internal static List<EventInfo> GatheredEvents = new List<EventInfo>();
    }
}
