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

// This file specifies any assembly attributes.
// Note that InternalsVisibleToAttribute can be removed or added and needs to be Multimedia packages only.

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tizen.Content.MediaContent, " + PublicKey.Value)]

[assembly: InternalsVisibleTo("Tizen.Multimedia.AudioIO, " + PublicKey.Value)]

[assembly: InternalsVisibleTo("Tizen.Multimedia.Camera, " + PublicKey.Value)]

[assembly: InternalsVisibleTo("Tizen.Multimedia.MediaCodec, " + PublicKey.Value)]

[assembly: InternalsVisibleTo("Tizen.Multimedia.MediaPlayer, " + PublicKey.Value)]

[assembly: InternalsVisibleTo("Tizen.Multimedia.Recorder, " + PublicKey.Value)]

[assembly: InternalsVisibleTo("Tizen.Multimedia.StreamRecorder, " + PublicKey.Value)]

[assembly: InternalsVisibleTo("Tizen.Multimedia.Remoting, " + PublicKey.Value)]

[assembly: InternalsVisibleTo("Tizen.Multimedia.Util, " + PublicKey.Value)]

[assembly: InternalsVisibleTo("Tizen.Multimedia.Vision, " + PublicKey.Value)]

[assembly: InternalsVisibleTo("Tizen.Multimedia.Radio, " + PublicKey.Value)]

internal static class PublicKey
{
    internal const string Value =
        "PublicKey=0024000004800000940000000602000000240000525341310004000001000100d115b100424841" +
        "6b12d21b626cfb17149c9303fe394693fd3b32d7872e89559a4fa96c98110c2e62eea48aca693b" +
        "ddbe17094ca8ea2e2cd79970ca590fb672b9b371b5d7002076817321f62d6483ea50c56dbd1f37" +
        "b185a4c24c47718876e6ae6d266508c551170d4cbdda3f82edaff9405ee3d7857282d8269e8e518d2f0fb2";
}