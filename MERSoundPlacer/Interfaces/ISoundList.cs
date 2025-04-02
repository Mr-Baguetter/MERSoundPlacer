namespace MERSoundPlacer.Interfaces
{
    public interface ISoundList
    {
        public abstract string PrimitiveName { get; set; }
        public abstract string AudioPath { get; set; }
        public abstract float AudibleDistance { get; set; }
        public abstract float SoundVolume { get; set; }

    }
}
