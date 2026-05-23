# VRCPlayersOnlyMirror

Tired of having to choose between admiring the scenery in a nice map or staring at your own reflection? Now you can do both at the same time!
VRCPlayersOnlyMirror is a simple mirror prefab that shows players only without any background.
This is NOT a 2D camera cut out, it is a full 3D mirror.

  - Player reflections in mirrors without any background
  - Adjustable mirror transparency
  - Simple distance fade
  - Works on both PC and Quest worlds
  - Performance cost more or less the same as a LQ mirror
  - Per-player [Persistence](docs/persistence.md) for toggle + slider state via VRChat PlayerData

> 日本語版: [README_JP.md](README_JP.md)

# Requirements

  - Unity **2022.3.22f1** (the [current VRChat-supported Unity version](https://creators.vrchat.com/sdk/upgrade/current-unity-version))
  - [VRChat Creator Companion](https://vcc.docs.vrchat.com/) (VCC)
  - VPM packages (installed automatically by VCC):
    - `com.vrchat.worlds` — current VRChat World SDK
    - `com.vrchat.udonsharp` — UdonSharp

See the [VRChat Udon docs](https://creators.vrchat.com/worlds/udon/) for an overview of Udon, Udon Graph, and UdonSharp.

# Installation

The SDK3 folder is fully self-contained — `.meta` files, prefab wiring, UdonSharp program assets, texture import settings, and a VPM `package.json` are all checked in. Pick whichever install path fits your workflow:

## Option A — Direct folder copy (works today)

1. Set up a VRChat **World** project via the [Creator Companion](https://vcc.docs.vrchat.com/), and add `com.vrchat.udonsharp` to it from VCC's package list. VCC will pull in `com.vrchat.worlds` and the matching Unity version automatically.
2. Download this repo as a ZIP or `git clone` it, then copy `VRCPlayersOnlyMirrorSDK3/Assets/VRCPlayersOnlyMirror` into your project's `Assets/`. Unity reads the checked-in `.meta` files and the prefab resolves cleanly with no manual import-setting fixups.

## Option B — .unitypackage

Pre-built `.unitypackage` downloads are attached to [Releases](https://github.com/acertainbluecat/VRCPlayersOnlyMirror/releases) for users who prefer a one-file drag-and-drop import.

## Option C — VCC / VPM listing (once published)

`VRCPlayersOnlyMirrorSDK3/package.json` is set up so this package can be served from a VPM listing and installed directly through Creator Companion. Publishing the VPM listing index is up to the upstream repo maintainer; until that listing exists, use Option A or B.

## SDK2 (archive only)

VRChat retired SDK2 years ago. The `VRCPlayersOnlyMirrorSDK2/` folder is preserved for historical reference and **will not work in current VRChat worlds**. Use the SDK3 package.

# How to use

  - Open the example scene at `Assets/VRCPlayersOnlyMirror/Example.unity`, or drop `VRCPlayersOnlyMirror.prefab` / `VRCPlayersOnlyMirrorCutout.prefab` into your scene.
  - The `Mirror` GameObject under the prefab carries a `VRC_MirrorReflection` component already configured with `cameraClearFlags = SolidColor` and a transparent clear color, plus the PlayersOnlyMirror shader — no `TransparentBackground` mask is needed.
  - The transparency slider and on/off toggle are pre-wired to `MirrorTransparency` and `MirrorToggleState` UdonSharp behaviours; no manual hooking up is required.

# Docs

  - [Persistence](docs/persistence.md) — PlayerData keys, the `persist` / `persistKey` inspector fields, how to reuse the scripts across multiple toggles or sliders.
  - [Shader reference](docs/shaders.md) — shader types, every shader setting, caveats, and the `VRC_MirrorReflection` setup screenshot.
  - [Changelog](CHANGELOG.md) — full release history.

# Demo

If you'd like to see this mirror in action you can find it in one of my public maps, Winter Solace.
https://vrchat.com/home/world/wrld_8899947f-8e19-4981-b327-a63be233706a

![demo1](https://nyanpa.su/i/MKH21bPq.jpg)
![demo2](https://nyanpa.su/i/gEzZ1bQD.jpg)

Credits appreciated but not required.
