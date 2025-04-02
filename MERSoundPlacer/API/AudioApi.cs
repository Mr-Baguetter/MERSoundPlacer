using Exiled.API.Features;
using Exiled.Loader;
using MERSoundPlacer.Interfaces;
using System.IO;
using System.Linq;
using UnityEngine;

namespace MERSoundPlacer.API
{
    public class AudioApi
    {

        /// <summary>
        /// If true it enables access to the custom sound custom flag.
        /// </summary>
        public bool EnableAudioApi { get; set; } = false;
        public AudioApi()
        {
            if (!CheckForNVorbisDependency())
            {
                Log.Error("You don't have the AudioPlayerApi dependency NVorbis installed!\nInstall it to use the custom sound custom flag.\nInstall it from https://github.com/Killers0992/AudioPlayerApi");
                EnableAudioApi = false;
            }
            if (!CheckForAudioPlayerApiDependency())
            {
                Log.Error("You don't have the dependency AudioPlayerApi installed!\nInstall it to use the custom sound custom flag.\nInstall it from https://github.com/Killers0992/AudioPlayerApi");
                EnableAudioApi = false;
            }
            else
                EnableAudioApi = true;
        }
        private bool CheckForAudioPlayerApiDependency() => Loader.Dependencies.Any(assembly => assembly.GetName().Name == "AudioPlayerApi");
        private bool CheckForNVorbisDependency() => Loader.Dependencies.Any(assembly => assembly.GetName().Name == "NVorbis");
        public static float Clamp(float? value, float min, float max)
        {
            return (float)((value < min) ? min : (value > max) ? max : value);
        }

        ISoundList SoundList = Plugin.Instance.Config.AudioPathing as ISoundList;

        public void PlayAudio()
        {
            GameObject primitive = GameObject.Find($"{SoundList.PrimitiveName}");
            foreach (var PrimitiveName in SoundList.PrimitiveName)
            {
                if (primitive != null)
                {
                    if (EnableAudioApi != false)
                    {
                        Log.Debug($"Audio API is enabled!");
                        if (!string.IsNullOrEmpty(SoundList.AudioPath))
                        {
                            Vector3 Coords = primitive.transform.position;
                            Log.Debug($"Succesfully loaded audio path {SoundList.AudioPath}");
                            AudioPlayer audioPlayer = AudioPlayer.CreateOrGet($"Global_Audio_{SoundList.PrimitiveName}", onIntialCreation: (p) =>
                            {
                                Speaker speaker = p.AddSpeaker("Main", Coords, isSpatial: true, maxDistance: SoundList.AudibleDistance);
                            });
                            float volume = Clamp(SoundList.SoundVolume, 1f, 100f);
                            audioPlayer.AddClip($"sound_{SoundList.PrimitiveName}", volume);
                            AudioClipStorage.LoadClip(SoundList.AudioPath, $"sound_{SoundList.PrimitiveName}");
                            Log.Debug($"Playing {Path.GetFileName(SoundList.AudioPath)}");
                            Log.Debug($"Audio should have been played.");
                        }
                        else
                            Log.Error($"Audio path is null please fill out the config properly.");
                    }
                    else
                    {
                        Log.Error("You don't have AudioPlayerApi or its dependency NVorbis installed!\nInstall it to use the custom sound custom flag.\nIf you need support join our Discord server: https://discord.gg/5StRGu8EJV");
                    }
                }
            }
        }
    }
}
