using System;
using System.Collections.Generic;
using Tizen;
using Tizen.NUI;
using Tizen.NUI.Scene3D;
using Tizen.AIAvatar;
using Tizen.NUI.AIAvatar;


namespace AIAvatar
{
    public partial class AIAvatar : Model
    {

        private LipSyncer lipSyncer;
        private Audio2Vowels audio2Vowels;

        private WaveData waveData;
        private AudioPlayer audioPlayer;
        private AudioOptions audioOptions;

        private SerialAnimator bodyAnimator = new SerialAnimator();
        private ParallelAnimator faceAnimator = new ParallelAnimator();
        private EmotionAnimator emotionAnimator = new EmotionAnimator();

        private List<MotionInfo> faceMotions = new List<MotionInfo>();
        private List<MotionInfo> bodyMotions = new List<MotionInfo>();
        private List<MotionInfo> customMotions = new List<MotionInfo>();

        private readonly string BodyMotionResourcePath = "/Animation/Body/";
        private readonly string FaceMotionResourcePath = "/Animation/Face/";

        private string[] testVowels = { "sil", "A", "E", "I", "O", "U", "A", "E", "I", "O", "U", "sil", "ER", "HM", "sil", "sil" };




        public AIAvatar() : base()
        {
            LoadResources();
        }
        public AIAvatar(string avatarUrl, string resourceDirectoryUrl = "") : base(avatarUrl, resourceDirectoryUrl)
        {
            LoadResources();
        }
        public AIAvatar(AIAvatar avatar) : base(avatar)
        {
            LoadResources();
        }


        private void LoadResources()
        {
            LoadAnimationResource();
            LoadAudioResource();
        }

        private void LoadAnimationResource()
        {
            try
            {
                faceMotions.AddRange(
                    AnimationLoader.Instance.LoadFaceMotions(Utils.ResourcePath + FaceMotionResourcePath)
                    );

                bodyMotions.AddRange(
                    AnimationLoader.Instance.LoadBodyMotions(
                        Utils.ResourcePath + BodyMotionResourcePath,
                        true,
                        new Vector3(0.01f, 0.01f, 0.01f)
                        )
                    );

                emotionAnimator.LoadEmotionConfig(Utils.ResourcePath + "/Intelligence/LLM/emoji_emotion_config.json", Utils.ResourcePath + "/Animation/Expression");
            }
            catch (Exception e)
            {
                Log.Error(Utils.LogTag, $"LoadAnimationResource : {e.Message}");
            }

        }

        private void LoadAudioResource()
        {
            waveData = AudioUtils.LoadWave(Utils.ResourcePath + "/Voice/en_tts.wav");
            Log.Info(Utils.LogTag, $"{waveData.NumChannels}, {waveData.SampleRate}");
        }



        public void Initialize()
        {      
            InitializeBodyAnimations();
            InitializeFaceAnimations();
            InitializeCustomAnimations();
            InitializeEmotionAnimations();

            InitializeAudioPlayer();

            InitializeLipSync();
            InitializeAIServices();
        }

        public void PlayRandomBodyAnimation()
        {
            try
            {
                Random random = new Random();
                int index = random.Next(0, bodyAnimator.Count);
                uint key = bodyAnimator.GetKeyElementAt(index);
                bodyAnimator.Play(key);
            }
            catch (Exception ex)
            {
                Log.Error(Utils.LogTag, "An error occurred while Play the Body Animaton: " + ex.Message);
            }
        }

        public void PlayMultipleFacialAnimations()
        {
            try
            {
                uint blinkKey = faceAnimator.GetIndexByName("EyeBlink");
                uint key = faceAnimator.GetKeyElementAt(0);
                faceAnimator.Play(new List<uint> { key, blinkKey });
            }
            catch (Exception ex)
            {
                Log.Error(Utils.LogTag, "An unexpected exception occurred: " + ex.Message);
            }
        }

        public void PlayExpressionAniatmion()
        {
            List<string> emotions = new List<string> { "joy", "trust", "fear", "surprise", "sadness", "disgust", "anger", "anticipation", "normal", "garbage" };

            Random random = new Random();
            int index = random.Next(emotions.Count);
            string emotion = emotions[index];

            Log.Info(Utils.LogTag, $"PlayEmotion : {emotion}");
            try
            {
                emotionAnimator.Play(emotion);
            }
            catch (Exception ex)
            {
                Log.Error(Utils.LogTag, "emotionAnimator: " + ex.Message);
            }
        }




        public void PlayLipSync()
        {
            try
            {
                lipSyncer.Stop();
                Animation lipAnimation = lipSyncer.GenerateAnimationFromVowels(testVowels);
                lipAnimation.Play();
                lipSyncer.Enqueue(lipAnimation);
                lipSyncer.Play();

            }
            catch (Exception ex)
            {
                Log.Error(Utils.LogTag, "An unexpected exception occurred: " + ex.Message);
            }
        }

        public void PlayAudioLipSync()
        {
            audio2Vowels.SetSampleRate(waveData.SampleRate);
            testVowels = audio2Vowels.PredictVowels(waveData.RawAudioData);
            PlayLipSync();
            
            audioPlayer.Stop();
            audioPlayer.Play(waveData.RawAudioData, waveData.SampleRate);
            
            Log.Info(Utils.LogTag, $"{string.Join(", ", testVowels)}");
        }

        public void PauseAnimations()
        {
            bodyAnimator.Pause();
            faceAnimator.Pause();
            lipSyncer.Pause();
        }


        public void StopAnimations()
        {
            bodyAnimator.Stop();
            faceAnimator.Stop();
            lipSyncer.Stop();
        }

        public void StartEyeBlink()
        {
            try
            {
                faceAnimator.Play("EyeBlink");
            }
            catch (Exception ex)
            {
                Log.Error(Utils.LogTag, "An error occurred while Play the eye blink: " + ex.Message);
            }
        }

        private void InitializeFaceAnimations()
        {
            try
            {
                foreach (var motion in faceMotions)
                {
                    var faceAnim = GenerateMotionDataAnimation(motion.MotionData);
                    faceAnimator.Add(faceAnim, motion.MotionName);
                }

                faceAnimator.AnimatorStateChanged += OnAnimationStateChanged;
            }
            catch (Exception e)
            {
                Log.Error(Utils.LogTag, $"InitializeFaceAnimations : {e.Message}");
            }
        }

        private void InitializeEmotionAnimations()
        {
            try
            {
                emotionAnimator.GenerateExpressionDataAnimation(this);
                emotionAnimator.AnimatorStateChanged += OnAnimationStateChanged;
            }
            catch (Exception e)
            {
                Log.Error(Utils.LogTag, $"InitializeEmotionAnimations : {e.Message}");
            }
        }

        private void InitializeBodyAnimations()
        {
            try
            {
                foreach (var motion in bodyMotions)
                {
                    var bodyAnim = GenerateMotionDataAnimation(motion.MotionData);
                    bodyAnim.BlendPoint = 0.2f;
                    bodyAnimator.Add(bodyAnim, motion.MotionName);
                }

                bodyAnimator.AnimatorStateChanged += OnAnimationStateChanged;
            }
            catch (Exception e)
            {
                Log.Error(Utils.LogTag, $"Initialize : {e.Message}");
            }
        }

        private void InitializeCustomAnimations()
        {
            var eyeBlinkMotionData = new EyeBlinkMotionData();

            var eyeAnimation = GenerateMotionDataAnimation(eyeBlinkMotionData.GetMotionData(4000));

            if (eyeAnimation != null)
            {
                eyeAnimation.LoopCount = 0;
                faceAnimator.Add(eyeAnimation, "EyeBlink");
            }
            else
            {
                Log.Error(Utils.LogTag, "Failed to initialize custom animations for avatar.");
            }
        }

        private void InitializeLipSync()
        {
            lipSyncer = new LipSyncer();
            lipSyncer.Initialize(this, Utils.ResourcePath + "/Intelligence/LipSync/emoji_viseme_blendshapes.json");
            lipSyncer.AnimatorStateChanged += OnAnimationStateChanged;

            audio2Vowels = new Audio2Vowels(Utils.ResourcePath + "/Intelligence/LipSync/audio2vowel_7.tflite");
        }

        private void InitializeAudioPlayer()
        {
            audioOptions = new AudioOptions(24000, Tizen.Multimedia.AudioChannel.Mono, Tizen.Multimedia.AudioSampleType.S16Le, Tizen.Multimedia.AudioStreamType.System);
            audioOptions.DuckingOptions(Tizen.Multimedia.AudioStreamType.Media, 500, 0.2);

            audioPlayer = new AudioPlayer(audioOptions);
        }


        private void OnAnimationStateChanged(object sender, AnimatorChangedEventArgs e)
        {

            switch (e.Current)
            {
                case AnimatorState.Ready:
                    Tizen.Log.Info(Utils.LogTag, $"[{e.Message}]  {sender.ToString()} State is Ready");
                    break;

                case AnimatorState.Playing:
                    Tizen.Log.Info(Utils.LogTag, $"[{e.Message}]  {sender.ToString()} State is Playing");
                    break;

                case AnimatorState.Paused:
                    Tizen.Log.Info(Utils.LogTag, $"[{e.Message}]  {sender.ToString()} State is Paused");
                    break;

                case AnimatorState.Stopped:
                    Tizen.Log.Info(Utils.LogTag, $"[{e.Message}]  {sender.ToString()} State is Stopped");
                    break;

                case AnimatorState.AnimationFinished:
                    Tizen.Log.Info(Utils.LogTag, $"[{e.Message}]  {sender.ToString()} Play Completed");
                    break;
            }
        }

    }
}
