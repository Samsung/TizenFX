using System;

namespace Tizen.Multimedia
{
    internal static class VolumeLevelLog
    {
        internal const string Tag = "Tizen.Multimedia.VolumeLevel";
    }

    public class VolumeLevel
    {
        public int this[AudioVolumeType type]
        {
            get
            {
                if (type == AudioVolumeType.None)
                    throw new ArgumentException("Wrong Audio volume type. Cannot get volume level for AudioVolumeType.None");
                int volume;
                int ret = Interop.AudioVolume.GetVolume(type, out volume);
                if (ret != 0)
                {
                    Tizen.Log.Info(VolumeLevelLog.Tag, "Get Level Error: " + (AudioManagerError)ret);
                    return -1;
                }
                return volume;
            }
            set
            {
                if (type == AudioVolumeType.None)
                    throw new ArgumentException("Wrong Audio volume type. Cannot set volume level for AudioVolumeType.None");
                int ret = Interop.AudioVolume.SetVolume(type, value);
                if (ret != 0)
                {
                    Tizen.Log.Info(VolumeLevelLog.Tag, "Set Level Error: " + (AudioManagerError)ret);
                    AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set level");
                }
            }
        }
    }
}