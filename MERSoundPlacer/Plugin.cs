using Exiled.API.Enums;
using Exiled.API.Features;
using System;

using ServerEvent = Exiled.Events.Handlers.Server;

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

        public static Plugin Instance { get; private set; }

        public override void OnEnabled()
        {
            Instance = this;;

            ServerEvent.RoundStarted += API.OnRoundStarted;

            Log.Info("===========================================");
            Log.Info("      Thanks for using MERSoundPlacer");
            Log.Info("             By Mr. Baguetter");
            Log.Info("===========================================");

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerEvent.RoundStarted -= API.OnRoundStarted;

            API = null;
            Instance = null;
            base.OnDisabled();

        }
    }
}