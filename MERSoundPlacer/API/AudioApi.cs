using Exiled.API.Features;
using Exiled.Loader;
using MapEditorReborn.API.Features.Objects;
using MERSoundPlacer.API.Data;
using MERSoundPlacer.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace MERSoundPlacer.API
{
    public class AudioApi
    {
        public List<SoundList> SoundLists { get; set; }

        public void SetSoundLists(List<SoundList> soundLists)
        {
            SoundLists = soundLists ?? new List<SoundList>();
            Log.Debug($"Set {SoundLists.Count} sound configurations in AudioApi");
        }
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

        public void PlayAudio(SchematicObject Schematic)
        {
            if (SoundLists == null || SoundLists.Count == 0)
            {
                Log.Error("SoundLists is null or empty.");
                return;
            }

            foreach (var SpawnedObject in Schematic.AttachedBlocks)
            {
                if (SpawnedObject == null)
                    continue;

                foreach (var soundList in SoundLists)
                {
                    if (SpawnedObject.name == soundList.PrimitiveName)
                    {
                        if (EnableAudioApi)
                        {
                            Log.Debug($"Audio API is enabled!");

                            if (string.IsNullOrEmpty(soundList.AudioPath))
                            {
                                Log.Error($"Audio path is null please fill out the config properly.");
                                continue;
                            }

                            Vector3 Coords = SpawnedObject.transform.position;
                            Log.Debug($"Successfully loaded audio path {soundList.AudioPath}");

                            AudioPlayer audioPlayer = AudioPlayer.CreateOrGet($"Global_Audio_{soundList.PrimitiveName}", onIntialCreation: (p) =>
                            {
                                Speaker speaker = p.AddSpeaker("Main", Coords, isSpatial: true, maxDistance: soundList.AudibleDistance);
                            });

                            float volume = Clamp(soundList.SoundVolume, 1f, 100f);
                            audioPlayer.AddClip($"sound_{soundList.PrimitiveName}", volume, soundList.Loop);
                            AudioClipStorage.LoadClip(soundList.AudioPath, $"sound_{soundList.PrimitiveName}");

                            Log.Debug($"Playing {Path.GetFileName(soundList.AudioPath)}");
                            Log.Debug($"Audio should have been played.");
                        }
                        else
                        {
                            Log.Error("You don't have AudioPlayerApi or its dependency NVorbis installed!");
                        }
                    }
                }
            }
        }
    }
}
