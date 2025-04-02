using MERSoundPlacer.Interfaces;

namespace MERSoundPlacer.API.Data
{
    public class SoundList : ISoundList
    {
        public string PrimitiveName { get; set; } = "";
        public string AudioPath { get; set; } = "";
        public float AudibleDistance { get; set; } = 1f;
        public float SoundVolume { get; set; } = 1f;
    }
}
