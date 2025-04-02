using Exiled.API.Interfaces;
using MERSoundPlacer.API.Data;
using System.Collections.Generic;
using System.ComponentModel;
namespace MERSoundPlacer
{
    public class Config : IConfig
    {
        [Description("Specifies whether the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Specifies whether developer (debug) mode is enabled.")]
        public bool Debug { get; set; } = true;

        [Description("Sound data.")]
        public virtual List<SoundList> AudioPathing { get; set; } = new List<SoundList>
        {
            new()
        };
    }
}
