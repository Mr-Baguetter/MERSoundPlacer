using Exiled.API.Features;
using MapEditorReborn.Events.EventArgs;
using MERSoundPlacer.Interfaces;

namespace MERSoundPlacer.API
{
    public class API
    {
        public void OnSchematicSpawned(SchematicSpawnedEventArgs ev)
        {
            if (ev.Schematic == null || ev.Schematic.AttachedBlocks == null)
                return;

            if (Plugin.Instance.AudioApi.SoundLists == null || Plugin.Instance.AudioApi.SoundLists.Count == 0)
            {
                Log.Error("SoundList is null or empty - audio will not play");
                return;
            }

            Plugin.Instance.AudioApi.PlayAudio(ev.Schematic);
        }
    }
}
