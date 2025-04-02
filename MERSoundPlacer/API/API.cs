using MapEditorReborn.Events.EventArgs;
using System.Collections.Generic;

namespace MERSoundPlacer.API
{
    public class API
    {
        

        public void OnSchematicSpawned(SchematicSpawnedEventArgs ev)
        {
            if (ev.Schematic == null)
                return;

            AudioApi AudioApi = new();
            AudioApi.PlayAudio();
        }
    }
}
