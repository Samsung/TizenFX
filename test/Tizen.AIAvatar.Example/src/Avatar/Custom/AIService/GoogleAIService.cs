using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Tizen.AIAvatar;

namespace AIAvatar
{
    public class GoogleAIConfiguration : AIServiceConfiguration
    {
        public GoogleAIConfiguration()
        {
            Endpoints = new ServiceEndpoints
            {
                LLMEndpoint = "https://generativelanguage.googleapis.com/v1beta/models/",
                TextToSpeechEndpoint = "https://texttospeech.googleapis.com",
                SpeechToTextEndpoint = "https://speech.googleapis.com"
            };
        }

        public string OAuth2Token { get; set; }
        public string Model { get; set; } = "gemini-1.5-flash";
    }


    public class GoogleAIService : BaseAIService, ITextToSpeechService, ISpeechToTextService, ILLMService
    {
        private readonly GoogleAIConfiguration config;
                
        public event EventHandler<llmResponseEventArgs> ResponseHandler;

        public event EventHandler<ttsStreamingEventArgs> OnTtsStart;
        public event EventHandler<ttsStreamingEventArgs> OnTtsReceiving;
        public event EventHandler<ttsStreamingEventArgs> OnTtsFinish;

        public event EventHandler<sttStreamingEventArgs> OnSttStart;
        public event EventHandler<sttStreamingEventArgs> OnSttReceiving;
        public event EventHandler<sttStreamingEventArgs> OnSttFinish;

        public override string ServiceName => "GoogleAI";

        public override ServiceCapabilities Capabilities =>
                                    ServiceCapabilities.TextToSpeech |
                                    ServiceCapabilities.SpeechToText |
                                    ServiceCapabilities.LargeLanguageModel;

        /// <summary>
        public GoogleAIService(GoogleAIConfiguration config) : base(config)
        {
            this.config = config;
        }

        public async Task GenerateTextAsync(string message, Dictionary<string, object> options = null)
        {
            // API 키가 포함된 전체 URL을 baseUrl로 사용
            var fullUrl = $"{config.Endpoints.LLMEndpoint}{config.Model}:generateContent?key={config.ApiKey}";
            var client = ClientManager.GetClient(fullUrl);

            var request = new RestRequest(Method.Post)
                .AddHeader("Content-Type", "application/json")
                .AddJsonBody(new
                {
                    contents = new[]
                    {
                    new
                    {
                        role = "user",
                        parts = new[]
                        {
                            new { text = message }
                        }
                    }
                    },
                    generationConfig = new
                    {
                        temperature = options?.GetValueOrDefault("temperature", 1.0),
                        maxOutputTokens = options?.GetValueOrDefault("maxOutputTokens", 8192),
                        topP = options?.GetValueOrDefault("topP", 0.95),
                        topK = options?.GetValueOrDefault("topK", 40),
                        responseMimeType = "text/plain"
                    }
                });

            var response = await client.ExecuteAsync(request).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                ResponseHandler?.Invoke(this, new llmResponseEventArgs { Error = response.ErrorMessage });
                return;
            }

            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(response.Content);
            string content = jsonResponse
                                .GetProperty("candidates")[0]
                                .GetProperty("content")
                                .GetProperty("parts")[0]
                                .GetProperty("text")
                                .GetString();

            ResponseHandler?.Invoke(this, new llmResponseEventArgs { Text = content });
        }


       
        public async Task<string> SpeechToTextAsync(
            byte[] audioData,
            Dictionary<string, object> options = null)
        {
            var client = ClientManager.GetClient(config.Endpoints.SpeechToTextEndpoint);

            var request = new RestRequest("/v1/speech:recognize", Method.Post)
                .AddHeader("Authorization", $"Bearer {config.OAuth2Token}")
                .AddJsonBody(new
                {
                    config = new
                    {
                        encoding = options?.GetValueOrDefault("encoding", "LINEAR16"),
                        sampleRateHertz = options?.GetValueOrDefault("sampleRate", 24000),
                        languageCode = options?.GetValueOrDefault("languageCode", "en-US"),
                        model = options?.GetValueOrDefault("model", "default"),
                        enableAutomaticPunctuation = options?.GetValueOrDefault("enablePunctuation", true)
                    },
                    audio = new
                    {
                        content = Convert.ToBase64String(audioData)
                    }
                });

            var response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
                throw new Exception($"Google STT Error: {response.ErrorMessage}");

            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(response.Content);
            return jsonResponse
                .GetProperty("results")[0]
                .GetProperty("alternatives")[0]
                .GetProperty("transcript")
                .GetString();
        }

     
        public async Task StreamSpeechToTextAsync(
            Stream audioStream,
            Dictionary<string, object> options = null)
        {
            const int CHUNK_SIZE = 1024 * 8; // 8KB chunks for audio processing
            var buffer = new byte[CHUNK_SIZE];

            try
            {
                OnSttStart?.Invoke(this, new sttStreamingEventArgs
                {
                    Interim = false,
                    Text = string.Empty
                });

                var ms = new MemoryStream();
                int bytesRead;
                int totalBytesRead = 0;

                // Read audio stream in chunks
                while ((bytesRead = await audioStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await ms.WriteAsync(buffer, 0, bytesRead);
                    totalBytesRead += bytesRead;

                    // Process intermediate results every 64KB
                    if (totalBytesRead >= 1024 * 64)
                    {
                        var intermediateAudio = ms.ToArray();
                        var intermediateText = await SpeechToTextAsync(intermediateAudio, options);

                        OnSttReceiving?.Invoke(this, new sttStreamingEventArgs
                        {
                            Interim = true,
                            Text = intermediateText
                        });

                        ms = new MemoryStream(); // Reset for next chunk
                        totalBytesRead = 0;
                    }
                }

                ms.Dispose();

                // Process final chunk if any remains
                if (totalBytesRead > 0)
                {
                    var finalAudio = ms.ToArray();
                    var finalText = await SpeechToTextAsync(finalAudio, options);

                    OnSttFinish?.Invoke(this, new sttStreamingEventArgs
                    {
                        Interim = false,
                        Text = finalText
                    });
                }
            }
            catch (Exception ex)
            {
                OnSttFinish?.Invoke(this, new sttStreamingEventArgs
                {
                    Error = ex.Message,
                    Text = string.Empty
                });
                throw;
            }
            finally
            {
                audioStream.Dispose();
            }
        }
             
        public async Task<byte[]> TextToSpeechAsync(string text, string voice = null, Dictionary<string, object> options = null)
        {
            var client = ClientManager.GetClient(config.Endpoints.TextToSpeechEndpoint);
            
            var request = new RestRequest("/v1/text:synthesize", Method.Post)
            .AddHeader("Authorization", $"Bearer {config.OAuth2Token}")
            .AddHeader("Content-Type", "application/json; charset=utf-8")
            .AddJsonBody(new
            {
                input = new { text = text },
                voice = new
                {
                    languageCode = options?.GetValueOrDefault("languageCode", "en-US") ?? "en-US",
                    name = voice ?? "en-US-Standard-A"
                },
                audioConfig = new
                {
                    audioEncoding = options?.GetValueOrDefault("audioEncoding", "MP3") ?? "MP3",
                    sampleRateHertz = options?.GetValueOrDefault("sampleRateHertz", 24000) ?? 24000
                }
            });

            var response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
                throw new Exception($"Google TTS Error: {response.ErrorMessage}");

            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(response.Content);
            var audioContent = jsonResponse.GetProperty("audioContent").GetString();
            return Convert.FromBase64String(audioContent);
        }

     
        public async Task TextToSpeechStreamAsync(string text, string voice = null, Dictionary<string, object> options = null)
        {
            const int SAMPLE_RATE = 24000;  
            const int FRAME_DURATION_MS = 160;
            const int TAIL_DURATION_MS = 15;
            const int BYTES_PER_SAMPLE = 2;
            const int CHUNK_SIZE = (SAMPLE_RATE * FRAME_DURATION_MS * BYTES_PER_SAMPLE) / 1000;
            const int TAIL_CHUNK_SIZE = (SAMPLE_RATE * TAIL_DURATION_MS * BYTES_PER_SAMPLE) / 1000;  

            var client = ClientManager.GetClient(config.Endpoints.TextToSpeechEndpoint);

            var request = new RestRequest("/v1/text:synthesize", Method.Post)
            .AddHeader("Authorization", $"Bearer {config.OAuth2Token}")
            .AddHeader("Content-Type", "application/json; charset=utf-8")
            .AddJsonBody(new
            {
                input = new { text = text },
                voice = new
                {
                    languageCode = options?.GetValueOrDefault("languageCode", "en-US") ?? "en-US",
                    name = voice ?? "en-US-Standard-A"
                },
                audioConfig = new
                {
                    audioEncoding = options?.GetValueOrDefault("audioEncoding", "LINEAR16") ?? "LINEAR16",
                    sampleRateHertz = options?.GetValueOrDefault("sampleRateHertz", 24000) ?? 24000
                }
            });

            try
            {
                OnTtsStart?.Invoke(this, new ttsStreamingEventArgs
                {
                    Text = text,
                    Voice = voice ?? "en-US-Standard-A",
                    SampleRate = SAMPLE_RATE,
                    TotalBytes = 0,
                    AudioData = Array.Empty<byte>()
                });

                var response = await client.ExecuteAsync(request);
                if (!response.IsSuccessful)
                    throw new Exception($"Google TTS Error: {response.ErrorMessage}");

                var jsonResponse = JsonSerializer.Deserialize<JsonElement>(response.Content);
                var audioContent = jsonResponse.GetProperty("audioContent").GetString();
                
                var audioData = Convert.FromBase64String(audioContent);
                var totalBytes = audioData.Length;
                var bytesProcessed = 0;

                while (bytesProcessed < totalBytes)
                {
                    var remainingBytes = totalBytes - bytesProcessed;
                    var currentChunkSize = Math.Min(CHUNK_SIZE + TAIL_CHUNK_SIZE, remainingBytes);
                    var chunk = new byte[currentChunkSize];
                    Array.Copy(audioData, bytesProcessed, chunk, 0, currentChunkSize);
                    bytesProcessed += Math.Min(CHUNK_SIZE, remainingBytes);

                    OnTtsReceiving?.Invoke(this, new ttsStreamingEventArgs
                    {
                        Text = text,
                        Voice = voice ?? "en-US-Standard-A",
                        TotalBytes = totalBytes,
                        ProcessedBytes = bytesProcessed,
                        ProgressPercentage = (double)bytesProcessed / totalBytes * 100,
                        AudioData = chunk
                    });
                }

                OnTtsFinish?.Invoke(this, new ttsStreamingEventArgs
                {
                    Text = text,
                    Voice = voice ?? "en-US-Standard-A",
                    TotalBytes = totalBytes,
                    ProcessedBytes = totalBytes,
                    ProgressPercentage = 100,
                    AudioData = Array.Empty<byte>()
                });
            }
            catch (Exception ex)
            {
                OnTtsFinish?.Invoke(this, new ttsStreamingEventArgs
                {
                    Text = text,
                    Voice = voice ?? "en-US-Standard-A",
                    Error = ex.Message,
                    AudioData = Array.Empty<byte>()
                });
                throw;
            }

        }
    }
}
