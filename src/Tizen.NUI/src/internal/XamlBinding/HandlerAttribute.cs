using System;

namespace Tizen.NUI.Binding
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal abstract class HandlerAttribute : Attribute
    {
        protected HandlerAttribute(Type handler, Type target)
        {
            TargetType = target;
            HandlerType = handler;
        }

        internal Type HandlerType { get; private set; }

        internal Type TargetType { get; private set; }

        public virtual bool ShouldRegister()
        {
            return true;
        }
    }
}