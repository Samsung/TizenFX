using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Setters")]
    public sealed class MultiTrigger : TriggerBase
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MultiTrigger([TypeConverter(typeof(TypeTypeConverter))] [Parameter("TargetType")] Type targetType) : base(new MultiCondition(), targetType)
        {
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<Condition> Conditions
        {
            get { return ((MultiCondition)Condition).Conditions; }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new IList<Setter> Setters
        {
            get { return base.Setters; }
        }
    }
}