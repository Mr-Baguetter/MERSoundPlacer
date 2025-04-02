using Exiled.API.Enums;
using Exiled.API.Features;
using MERSoundPlacer.API;
using System;

using MEREvent = MapEditorReborn.Events.Handlers.Schematic;

namespace MERSoundPlacer
{
    public class Plugin : Plugin<Config>
    {
        public const bool IsPrerelease = true;
        public override string Name => "MERSoundPlacer";

        public override string Prefix => "MERSoundPlacer";

        public override string Author => "Mr. Baguetter";

        public override Version RequiredExiledVersion { get; } = new(9, 5, 1);

        public override Version Version { get; } = new(1, 0, 0);

        public override PluginPriority Priority => PluginPriority.First;

        internal API.API API;
        internal AudioApi AudioApi;

        public static Plugin Instance { get; private set; }

        public override void OnEnabled()
        {

            Instance = this;
            API = new();
            AudioApi = new();

            AudioApi.SetSoundLists(Config.AudioPathing);
            Log.Debug($"Initialized AudioApi with {Config.AudioPathing.Count} sound configurations");

            MEREvent.SchematicSpawned += API.OnSchematicSpawned;

            Log.Info("===========================================");
            Log.Info("      Thanks for using MERSoundPlacer");
            Log.Info("             By Mr. Baguetter");
            Log.Info("===========================================");

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            MEREvent.SchematicSpawned -= API.OnSchematicSpawned;

            AudioApi = null;
            API = null;
            Instance = null;
            base.OnDisabled();

        }
    }
}