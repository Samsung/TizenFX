using System;
using Tizen.NUI.XamlBinding.Internals;

namespace Tizen.NUI.XamlBinding
{
    internal interface IVisualElementController : IElementController
    {
        void NativeSizeChanged();
        void InvalidateMeasure(InvalidationTrigger trigger);
        bool Batched { get; }
        bool DisableLayout { get; set; }
        EffectiveFlowDirection EffectiveFlowDirection { get; }
        bool IsInNativeLayout { get; set; }
        bool IsNativeStateConsistent { get; set; }
        bool IsPlatformEnabled { get; set; }
        NavigationProxy NavigationProxy { get; }
        event EventHandler<EventArg<Element>> BatchCommitted;
        event EventHandler<Tizen.NUI.BaseHandle.FocusRequestArgs> FocusChangeRequested;
    }
}