# VRCPlayersOnlyMirror — SDK3 / UdonSharp package

A simple VRChat world mirror prefab that shows players only without any background. This is the actual shipped asset folder; full documentation lives in the GitHub repo.

> 日本語版: [Readme-JP.md](Readme-JP.md)

## Quick start

  - Requires Unity **2022.3.22f1** with `com.vrchat.worlds` + `com.vrchat.udonsharp` (install via [Creator Companion](https://vcc.docs.vrchat.com/)).
  - Open `Example.unity`, or drop `VRCPlayersOnlyMirror.prefab` / `VRCPlayersOnlyMirrorCutout.prefab` into your scene.
  - The transparency slider and on/off toggle are pre-wired to UdonSharp behaviours in `Runtime/`; no manual setup needed.
  - Toggle and slider state are persisted per-player via VRChat PlayerData (default keys `vpom_mirror_enabled` and `vpom_transparency` — override each instance's `persistKey` field if you reuse the scripts on multiple controls).

## Full docs

See the repo for full reference, install options, and changelog:

  - **Repo**: <https://github.com/acertainbluecat/VRCPlayersOnlyMirror>
  - [Persistence](https://github.com/acertainbluecat/VRCPlayersOnlyMirror/blob/main/docs/persistence.md)
  - [Shader reference](https://github.com/acertainbluecat/VRCPlayersOnlyMirror/blob/main/docs/shaders.md) (shader types, every setting, caveats)
  - [Changelog](https://github.com/acertainbluecat/VRCPlayersOnlyMirror/blob/main/CHANGELOG.md)

The legacy `MirrorTransparency 1.asset` Udon Graph script remains alongside the UdonSharp version for backwards compatibility.
