/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace Tizen.Multimedia.MediaCodec
{
    internal enum SupportedCodecType
    {
        // L16 = 0x1010,
        // ALaw = 0x1020,
        // ULaw = 0x1030,
        Amr = 0x1040,
        AmrNB = 0x1040,
        AmrWb = 0x1041,
        // G729 = 0x1050,
        Aac = 0x1060,
        AacLC = 0x1060,
        AacHE = 0x1061,
        AacHEPS = 0x1062,
        MP3 = 0x1070,
        Vorbis = 0x1080,
        Flac = 0x1090,
        Wma1 = 0x10A0,
        Wma2 = 0x10A1,
        WmaPro = 0x10A2,
        WmaLossless = 0x10A3,
        Opus = 0x10D0,

        H261 = 0x2010,
        H263 = 0x2020,
        H264 = 0x2030,
        MJpeg = 0x2040,
        Mpeg1 = 0x2050,
        Mpeg2 = 0x2060,
        Mpeg4 = 0x2070,
        // Hevc = 0x2080,
        // VP8 = 0x2090,
        // VP9 = 0x20A0,
        // VC1 = 0x20B0,
    }

    internal static class TypeConverter
    {
        private const int CodecTypeMask = 0xFFFF;

        internal static int ToPublic(SupportedCodecType type)
        {
            int ret = (int)type;

            switch (type)
            {
                case SupportedCodecType.Opus:
                    ret = (int)MediaFormatAudioMimeType.Opus & CodecTypeMask;
                    break;
            }

            return ret;
        }

        internal static int ToNative(MediaFormatAudioMimeType type)
        {
            int ret = (int)type & CodecTypeMask;
            switch (type)
            {
                case MediaFormatAudioMimeType.Opus:
                    ret = (int)SupportedCodecType.Opus;
                    break;
            }

            return ret;
        }

        internal static int ToNative(MediaFormatVideoMimeType type)
        {
            return (int)type & CodecTypeMask;
        }
    }
}
