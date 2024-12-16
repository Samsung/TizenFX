using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAvatar
{

    public class WaveData
    {
        public int SampleRate { get; set; }
        public short NumChannels { get; set; }
        public byte[] RawAudioData { get; set; }
    }

    public static class AudioUtils
    {
        public static WaveData LoadWave(string path)
        {
            using (var reader = new BinaryReader(File.OpenRead(path)))
            {
                // RIFF chunk identifier
                string riffChunkID = new string(reader.ReadChars(4));
                if (riffChunkID != "RIFF")
                {
                    throw new Exception("Invalid WAV file");
                }

                // RIFF chunk size
                reader.ReadInt32();

                // Format
                string format = new string(reader.ReadChars(4));
                if (format != "WAVE")
                {
                    throw new Exception("Invalid WAV file");
                }

                // FMT subchunk
                string fmtSubChunkID = new string(reader.ReadChars(4));
                if (fmtSubChunkID != "fmt ")
                {
                    throw new Exception("Invalid WAV file");
                }

                // FMT subchunk size
                int fmtSubChunkSize = reader.ReadInt32();

                // Audio format
                short audioFormat = reader.ReadInt16();
                if (audioFormat != 1)
                {
                    throw new Exception("Unsupported audio format");
                }

                // Number of channels
                short numChannels = reader.ReadInt16();

                // Sample rate
                int sampleRate = reader.ReadInt32();

                // Byte rate
                reader.ReadInt32();

                // Block align
                reader.ReadInt16();

                // Bits per sample
                short bitsPerSample = reader.ReadInt16();

                // Skip any extra bytes in the FMT subchunk
                if (fmtSubChunkSize > 16)
                {
                    reader.ReadBytes(fmtSubChunkSize - 16);
                }

                // Find the data subchunk
                int dataSubChunkSize = 0;
                while (true)
                {
                    string dataSubChunkID = new string(reader.ReadChars(4));
                    dataSubChunkSize = reader.ReadInt32();

                    if (dataSubChunkID == "data")
                    {
                        break;
                    }
                    else
                    {
                        reader.ReadBytes(dataSubChunkSize);
                    }
                }

                // Read the raw audio data
                byte[] rawAudioData = reader.ReadBytes(dataSubChunkSize);

                return new WaveData
                {
                    SampleRate = sampleRate,
                    NumChannels = numChannels,
                    RawAudioData = rawAudioData
                };
            }
        }
    }

    public class AudioProcessor : IDisposable
    {
        private readonly MemoryStream audioBuffer;
        private bool isDisposed;

        public AudioProcessor()
        {
            this.audioBuffer = new MemoryStream();
        }

        public void ProcessAudioChunk(byte[] chunk)
        {
            if (chunk != null && chunk.Length > 0)
            {
                audioBuffer.Write(chunk, 0, chunk.Length);
            }
        }

        public long getAudioBufferSize()
        {
            return audioBuffer.Length;
        }

        public async Task SaveToFileAsync(string outputFilePath)
        {
            // WAV 헤더 추가 (PCM 포맷용)
            using var fileStream = new FileStream(outputFilePath, FileMode.Create);
            var wavHeader = CreateWavHeader((int)audioBuffer.Length);
            await fileStream.WriteAsync(wavHeader, 0, wavHeader.Length);

            // 오디오 데이터 쓰기
            audioBuffer.Position = 0;
            await audioBuffer.CopyToAsync(fileStream);
        }

        private byte[] CreateWavHeader(int pcmDataLength)
        {
            const int headerSize = 44;
            const int formatChunkSize = 16;
            const short audioFormat = 1; // PCM
            const short numChannels = 1; // Mono
            const int sampleRate = 24000; // OpenAI TTS sample rate
            const short bitsPerSample = 16;
            var byteRate = sampleRate * numChannels * bitsPerSample / 8;
            var blockAlign = (short)(numChannels * bitsPerSample / 8);

            var header = new byte[headerSize];
            var writer = new BinaryWriter(new MemoryStream(header));

            // RIFF 청크
            writer.Write("RIFF".ToCharArray());
            writer.Write(pcmDataLength + headerSize - 8);
            writer.Write("WAVE".ToCharArray());

            // Format 청크
            writer.Write("fmt ".ToCharArray());
            writer.Write(formatChunkSize);
            writer.Write(audioFormat);
            writer.Write(numChannels);
            writer.Write(sampleRate);
            writer.Write(byteRate);
            writer.Write(blockAlign);
            writer.Write(bitsPerSample);

            // Data 청크
            writer.Write("data".ToCharArray());
            writer.Write(pcmDataLength);

            return header;
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                audioBuffer?.Dispose();
                isDisposed = true;
            }
        }
    }
}
