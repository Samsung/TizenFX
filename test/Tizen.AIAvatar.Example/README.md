# Tizen AIAvatar Framework

## Overview
Tizen provides an AI Avatar Framework that makes it easy to create avatar services. This framework comes equipped with a variety of features to bring your avatars to life, including 3D character rendering, multi-language Text-to-Speech (TTS), and lip-sync animation. Additionally, it offers a flexible interface that lets you swap out built-in AI solutions for external ones. This flexibility enables AI avatars to adapt to different environments and meet varying needs.

## Resource Download Method
The 3D models used by Tizen AIAvatar support the AR Emoji format provided by Samsung. You can find sample resources here: https://developer.samsung.com/galaxy-ar-emoji/overview.html

Place the downloaded model files into the following directory structure: `/res/Model/`.

## How to Run
To use the framework, make sure you have .NET Core installed. Follow these steps:
1. Obtain NUI from the GitHub repository: https://github.com/Samsung/TizenFX
2. Clone this repository (`TizenFX/test/Tizen.AIAvatar.Example`) and execute `dotnet run` within the cloned folder.

## AI Services
Using AI services requires an active network connection. Sample implementations of popular AI service providers like Samsung, Google, and OpenAI are included in the codebase. However, please note that obtaining API keys for each service provider is necessary before using them.

## Lip-Sync
On-device lip sync technology is available through the AI Avatar framework. It uses the `/res/Intelligence/LipSync/audio2vowel_7.tflite` model to classify audio input into seven representative vowels. An accompanying module generates animations based on these classifications. When creating animations, the `LipSyncer` animator references `/res/Intelligence/LipSync/emoji_viseme_blendshapes.json`, which contains blend shape configurations for mouth movements. These configurations can be modified or extended as needed.

## Sentiment Analysis
Small Language Models (SLMs) offer sentiment classification functionality within the AI Avatar framework. Using a 1B size SLM, sentences can be analyzed for their emotional content. Positive sentiments include Joy, Surprise, Trust, and Anticipation, while negative sentiments encompass Sadness, Anger, Fear, and Disgust. These classifications correspond to Robert Plutchik¡¯s Wheel of Emotions.

An `EmotionAnimator` is also provided to generate facial expressions corresponding to the identified emotion. `/res/Intelligence/LLM/emoji_emotion_config.json` defines the facial animations associated with each emotion category. To exclude certain blend shapes during blending, set the `ignoreBlendShapes` option accordingly.
