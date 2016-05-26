using System;

namespace Tizen.Multimedia
{
    internal static class MaxVolumeLog
    {
        internal const string Tag = "Tizen.Multimedia.MaxVolume";
    }

    public class MaxVolumeLevel
    {
       public int this[AudioVolumeType type]
        {
            get
            {
                if (type == AudioVolumeType.None)
                    throw new ArgumentException("Wrong Audio volume type. Cannot get max volume level for AudioVolumeType.None");
                int maxVolume;
                int ret = Interop.AudioVolume.GetMaxVolume(type, out maxVolume);
                if (ret != 0)
                {
                    Tizen.Log.Info(MaxVolumeLog.Tag, "Max Level Error: " + (AudioManagerError)ret);
                    return -1;
                }
                return maxVolume;
            }
        }
    }
}