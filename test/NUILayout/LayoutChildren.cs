using Tizen.NUI;

namespace NUILayout
{
    internal class LayoutChildren
    {
        public static readonly int Count = 10;
        public static readonly Color[] Colors = new Color[Count];

        static LayoutChildren()
        {
            Colors[0] = Color.Blue;
            Colors[1] = Color.BlueViolet;
            Colors[2] = Color.SkyBlue;
            Colors[3] = Color.DarkBlue;
            Colors[4] = Color.DodgerBlue;
            Colors[5] = Color.CadetBlue;
            Colors[6] = Color.LightBlue;
            Colors[7] = Color.RoyalBlue;
            Colors[8] = Color.CadetBlue;
            Colors[9] = Color.SlateBlue;
        }
    }
}
