<div align="center"><a href="https://github.com/Mr-Baguetter/MERSoundPlacer/releases/latest"><img src="https://img.shields.io/github/v/release/Mr-Baguetter/MERSoundPlacer"></a> <a href="https://github.com/Mr-Baguetter/MERSoundPlacer/releases/latest"><img src="https://img.shields.io/github/downloads/Mr-Baguetter/MERSoundPlacer/total"></a> <a href="https://github.com/Mr-Baguetter/MERSoundPlacer/pulls"><img src="https://img.shields.io/github/issues-pr/Mr-Baguetter/MERSoundPlacer"></a> <a href="https://github.com/Mr-Baguetter/MERSoundPlacer/issues"><img src="https://img.shields.io/github/issues-pr-closed/Mr-Baguetter/MERSoundPlacer"></a> <a href="https://github.com/Mr-Baguetter/MERSoundPlacer/commits/main/"><img src="https://badgen.net/github/commits/Mr-Baguetter/MERSoundPlacer/main">
  <br><br>
  <br><br>
</div>

**[EXILED](https://github.com/ExMod-Team/EXILED)** >= `v9.5.1`
<br><br>

# MERSoundPlacer

## Description
MERSoundPlacer is an SCP:SL plugin that enables servers to place audio sources throughout their custom maps by associating sounds with specific primitive objects in a MER schematic. This plugin seamlessly bridges MER's visual building tools with AudioPlayerApi's sound capabilities, allowing for immersive environmental audio without any code.

## Features
- Associate audio files with specific primitive objects in MER
- Configure audio properties including:
  - Volume levels
  - Loop settings
  - Audible distance
- Automatic audio source placement when schematics spawn
- Easy-to-use configuration system
- Helpful diagnostic logging

## Dependencies
- [Map Editor Reborn](https://github.com/Michal78900/MapEditorReborn) - Custom map creation tool
- [AudioPlayerApi](https://github.com/Killers0992/AudioPlayerApi) - Audio processing and playback

## Installation
1. Install all dependencies listed above
2. Download the latest release of MERSoundPlacer
3. Place the DLL file in your EXILED plugins folder
4. Configure the plugin settings in your config file

## Usage
1. Create a schematic using MER
2. Add primitive objects that will serve as audio source locations
3. Configure the plugin to match primitive names with audio files
4. When the schematic spawns in-game, audio will automatically play at the specified locations

## Configuration
Configure sound lists in your config file with the following parameters:
```yaml
sound_lists:
  - primitive_name: "YourPrimitiveName"
    audio_path: "path/to/your/audiofile.ogg"
    sound_volume: 50
    loop: true
    audible_distance: 30
```
