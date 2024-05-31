/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace Tizen.AIAvatar
{
    internal class EmotionAnalyzer
    {
        private LipSyncController avatarTTS;
        private IRestClient restClient;
        private const string playgroundURL = "https://playground-api.sec.samsung.net";

        internal EmotionAnalyzer()
        {
        }

        internal void InitAvatarLLM(LipSyncController avatarTTS)
        {
            this.avatarTTS = avatarTTS;
            // Setup RestClinet
            var restClientFactory = new RestClientFactory();
            restClient = restClientFactory.CreateClient(playgroundURL);
        }

        internal async Task StartTTSWithLLMAsync(string text, string token)
        {
            var bearerToken = token;
            var jsonData = "{\"messages\": [{\"role\": \"user\", \"content\": \"" + text + "\"}]}";

            try
            {
                var postResponse = await restClient.SendRequestAsync(HttpMethod.Post, "/api/v1/chat/completions", bearerToken, jsonData);
                var responseData = JsonConvert.DeserializeObject<dynamic>(postResponse);
                string content = responseData["response"]["content"];
                Log.Info("Tizen.AIAvatar", content);

                //TTS 호출
                var voiceInfo = new VoiceInfo()
                {
                    Language = "en_US",
                    Type = VoiceType.Female,
                };

                avatarTTS.PlayTTSAsync(content, voiceInfo, (o, e) =>
                {

                });

            }
            catch (Exception ex)
            {
                Log.Error("Tizen.AIAvatar", "에러 발생: " + ex.Message);
            }
        }
    }
}
