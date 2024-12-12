using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Tizen;
using Tizen.AIAvatar;
using Tizen.NUI;
using Tizen.NUI.Scene3D;

namespace AIAvatar
{    
    public partial class AIAvatar : Model
    {
        private enum TaskID
        {
            Default,
            SamLLM,
            SamSLM
        }

        private SamsungAIService samsungAIService;
        private SamsungAIConfiguration samsungAIConfig;

        private int ttsStreamingAudioBytes = 0;
        
        public void InitializeAIServices()
        {
            samsungAIConfig = new SamsungAIConfiguration
            {
                ApiKey = "API_KEY",
                Model = "chat-65b-32k-1.1.2"
            };

            samsungAIService = new SamsungAIService(samsungAIConfig);
            samsungAIService.ResponseHandler += OnResponseReceived;
            

            samsungAIService.OnTtsStart += OnTtsStart;
            samsungAIService.OnTtsReceiving += OnTtsReceiving;
            samsungAIService.OnTtsFinish += OnTtsFinish;
        }

        public void TestSamsungAIService()
        {
            TestSamsungTextGeneration(samsungAIService);            
        }

        #region SamsungAI Services
            

        private void TestSamsungTextGeneration(SamsungAIService samsungAIService)
        {
            var task = Task.Run(async () =>
            {
                var options = new Dictionary<string, object> { { "TaskID", (int)TaskID.SamLLM } };
                await samsungAIService.GenerateTextAsync(Utils.TTSText, options).ConfigureAwait(true);
            });

        }

        private void TestSamsungTTS(string text)
        {
            var task = Task.Run(async () =>
            {
                var options = new Dictionary<string, object> {  { "voiceType", VoiceType.Female },
                                                                { "speechRate", 1.0f } };

                await samsungAIService.TextToSpeechStreamAsync(text, "en_US", options).ConfigureAwait(false);
            });
        }

        #endregion


        public void TestOpenAIServicesAsync()
        {
            var openAIConfig = new OpenAIConfiguration
            {
                ApiKey = "API_KEY",
                Model = "gpt-4o"
            };

            using (var openAIService = new OpenAIService(openAIConfig))
            {
                var task = Task.Run(async () =>
                {
                    await TestOpenAITextGeneration(openAIService);
                    await TestOpenAITTS(openAIService);
                });
            }
        }


        #region OpenAI Services


        private async Task TestOpenAITextGeneration(OpenAIService openAIService)
        {
            await openAIService.GenerateTextAsync("Hello?");
        }

        private async Task TestOpenAITTS(OpenAIService openAIService)
        {
            // Basic TTS test
            var speechBytes = await openAIService.TextToSpeechAsync(
                "Hello from OpenAI!", "alloy");
            await File.WriteAllBytesAsync("openai_speech.mp3", speechBytes);

           
            openAIService.OnTtsStart += OnTtsStart;
            openAIService.OnTtsReceiving += OnTtsReceiving;
            openAIService.OnTtsFinish += OnTtsFinish;

            await openAIService.TextToSpeechStreamAsync(
                "Hello from OpenAI!, I'm so excited to go on vacation!", "alloy");
        }
        #endregion

        public void TestGoogleAIServices()
        {

            var googleAIConfig = new GoogleAIConfiguration
            {
                ApiKey = "API_KEY",
                OAuth2Token = "TOKEN_API_KEY",
                Model = "gemini-1.5-flash"
            };

            using (var googleAIService = new GoogleAIService(googleAIConfig))
            {
                var task = Task.Run(async () =>
                {
                    await TestGoogleTextGeneration(googleAIService);
                    await TestGoogleTTS(googleAIService);
                    await TestGoogleSTT(googleAIService);
                });
            }
        }

        #region Google AI Services

        private async Task TestGoogleTextGeneration(GoogleAIService googleAIService)
        {
            var options = new Dictionary<string, object>
        {
            { "temperature", 1.0 },
            { "maxOutputTokens", 8192 },
            { "topP", 0.95 },
            { "topK", 40 }
        };

            await googleAIService.GenerateTextAsync("hello?", options);
        }

        private async Task TestGoogleTTS(GoogleAIService googleAIService)
        {
            // Basic TTS test
            var speechBytes = await googleAIService.TextToSpeechAsync(
                "Hello from Google AI!", "en-US-Standard-A");
                      
            googleAIService.OnTtsStart += OnTtsStart;
            googleAIService.OnTtsReceiving += OnTtsReceiving;
            googleAIService.OnTtsFinish += OnTtsFinish;

            var tts_options = new Dictionary<string, object>
            {
                ["audioEncoding"] = "LINEAR16",
                ["sampleRate"] = 24000,
            };

            await googleAIService.TextToSpeechStreamAsync(
                "Hello from Google!, I'm so excited to go on vacation!",
                "en-US-Standard-A",
                tts_options
            );
        }

        private async Task TestGoogleSTT(GoogleAIService googleAIService)
        {
            var stt_options = new Dictionary<string, object>
            {
                ["encoding"] = "LINEAR16",
                ["sampleRate"] = 24000,
                ["languageCode"] = "en-US",
                ["enablePunctuation"] = true
            };

            WaveData wavData = AudioUtils.LoadWave("GoogleTTS.wav");
            string result = await googleAIService.SpeechToTextAsync(wavData.RawAudioData, stt_options);
            Log.Info(Utils.LogTag, $"Text: {result}");
        }
        #endregion

        private void OnResponseReceived(object sender, llmResponseEventArgs e)
        {

            if (e.Error != null)
            {
                TestSamsungTTS(e.Error);
                Log.Info(Utils.LogTag, $"Error: {e.Error}");
                return;
            }

            switch ((TaskID)e.TaskID)
            {
                case TaskID.Default:
                    //default
                    break;
                case TaskID.SamLLM:
                    var task = Task.Run(async () =>
                    {
                        var options = new Dictionary<string, object> { { "promptFilePath", Utils.ResourcePath + "/Intelligence/LLM/emotion1B.json" }, {"TaskID", (int)TaskID.SamSLM } };
                        await samsungAIService.GenerateTextAsync(e.Text, options).ConfigureAwait(false);
                    }).ContinueWith(t => TestSamsungTTS(e.Text));
                    break;
                case TaskID.SamSLM:
                    emotionAnimator.Play(e.Text);
                    PlayRandomBodyAnimation();
                    break;
            }

            Log.Info(Utils.LogTag, $"Response[{e.TaskID}]: {e.Text}");

        }

        private void OnTtsStart(object sender, ttsStreamingEventArgs e)
        {
            lipSyncer.Stop();
            audioPlayer.Stop();

            audioPlayer.PrepareStreamAudio(e.SampleRate);
            audio2Vowels.SetSampleRate(e.SampleRate);

            ttsStreamingAudioBytes = e.AudioBytes;
            Log.Info(Utils.LogTag, $"Started TTS for text: {e.Text}");
        }

        private void OnTtsReceiving(object sender, ttsStreamingEventArgs e)
        {
            Span<byte> playAudioData = e.AudioData.AsSpan(0, ttsStreamingAudioBytes);
            audioPlayer.AddStream(playAudioData.ToArray());

            var predictVowels = audio2Vowels.PredictVowels(e.AudioData);

            Animation lipAnimation = lipSyncer.GenerateAnimationFromVowels(predictVowels, 0.08f, true);
            lipSyncer.Enqueue(lipAnimation);
        }

        private void OnTtsFinish(object sender, ttsStreamingEventArgs e)
        {
            Log.Info(Utils.LogTag, "TTS streaming completed");
        }

    }
}
