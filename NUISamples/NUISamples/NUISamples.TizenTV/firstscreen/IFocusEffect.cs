using Tizen.NUI;
using System;
using Tizen.NUI.BaseComponents;

namespace FirstScreen
{
    public enum FocusEffectDirection
    {
        TopToBottom,
        BottomToTop
    };

    public interface IFocusEffect
    {
        void FocusAnimation(View parentItem, Size itemSize, int duration, FocusEffectDirection direction);
    }
}
