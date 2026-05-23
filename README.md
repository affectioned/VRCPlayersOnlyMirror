# VRCPlayersOnlyMirror

Tired of having to choose between admiring the scenery in a nice map or staring at your own reflection? Now you can do both at the same time!
VRCPlayersOnlyMirror is a simple mirror prefab that shows players only without any background.
This is NOT a 2D camera cut out, it is a full 3D mirror.

  - Player reflections in mirrors without any background
  - Adjustable mirror transparency
  - Simple distance fade
  - Works on both PC and Quest worlds
  - Performance cost more or less the same as a LQ mirror

# v0.2.0 — modernized for the current VRChat World SDK

  - Distributed as a VPM package (Creator Companion compatible)
  - Udon Graph script replaced with [UdonSharp](https://udonsharp.docs.vrchat.com/) (`Runtime/MirrorTransparency.cs`); the legacy graph asset is kept inside the SDK3 folder for backwards compatibility
  - Per-player [Persistence](https://creators.vrchat.com/worlds/udon/persistence/) for the mirror toggle and transparency slider — settings survive across sessions and instances
  - Tracks the current [VRChat-supported Unity version (2022.3.22f1)](https://creators.vrchat.com/sdk/upgrade/current-unity-version)
  - SDK2 path is no longer supported by VRChat; the `VRCPlayersOnlyMirrorSDK2` folder is retained as an archive only

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

  - Pre-built `.unitypackage` downloads are attached to [Releases](https://github.com/acertainbluecat/VRCPlayersOnlyMirror/releases) for users who prefer a one-file drag-and-drop import.

## Option C — VCC / VPM listing (once published)

  - `VRCPlayersOnlyMirrorSDK3/package.json` is set up so this package can be served from a VPM listing and installed directly through Creator Companion. Publishing the VPM listing index is up to the upstream repo maintainer; until that listing exists, use Option A or B.

## SDK2 (archive only)

VRChat retired SDK2 years ago. The `VRCPlayersOnlyMirrorSDK2/` folder is preserved for historical reference and **will not work in current VRChat worlds**. Use the SDK3 package.

# How to use

  - Open the example scene at `Assets/VRCPlayersOnlyMirror/Example.unity`, or drop `VRCPlayersOnlyMirror.prefab` / `VRCPlayersOnlyMirrorCutout.prefab` into your scene.
  - The `Mirror` GameObject under the prefab carries a `VRC_MirrorReflection` component already configured with `cameraClearFlags = SolidColor` and a transparent clear color, plus the PlayersOnlyMirror shader — no `TransparentBackground` mask is needed.
  - The transparency slider and on/off toggle are pre-wired to `MirrorTransparency` and `MirrorToggleState` UdonSharp behaviours; no manual hooking up is required.

# Persistence

The example prefab uses [VRChat PlayerData](https://creators.vrchat.com/worlds/udon/persistence/) to save UI state **per-player, per-world** so it survives across sessions and instances. No server / per-world database needed — VRChat stores it.

| Default key            | Type   | Set by                | What it remembers           |
|------------------------|--------|-----------------------|-----------------------------|
| `vpom_mirror_enabled`  | bool   | `MirrorToggleState`   | Whether the mirror is on    |
| `vpom_transparency`    | float  | `MirrorTransparency`  | The transparency slider value |

Both UdonSharp scripts read PlayerData inside `OnPlayerRestored` (the safe entry point — PlayerData is not available before that event fires) and only persist data for the local player. Each script exposes two inspector fields:

  - `persist` — checkbox to disable PlayerData reads/writes on a per-component basis.
  - `persistKey` — the PlayerData slot name. Give each instance a unique key if you reuse these scripts on multiple toggles or sliders in the same world; leave it blank to disable persistence without unchecking `persist`.

Each world can store up to 100KB of PlayerData per player; this prefab uses ~16 bytes.

  Please make sure your "VRC Mirror Reflection" component looks like this if the background is still visible in the mirror:
  ![vrcmirrorreflection](https://cdn.nyanpa.su/i/PiMX2EB0.jpg)

# Shader Types

  - **PlayersOnlyMirror** — Regular version with transparency and distance fade
  - **PlayersOnlyMirrorCutout** — Variant with just cutout, no transparency or distance fade

# Shader Settings

  - **Base (RBG)** — Overlays a texture onto the reflection, same behavior as the default mirror shader
  - **Hide Background** — Hides the background, requires the TransparentBackground shader acting as a fake background for the mirror for this to work
  - **Ignore Effects** — Attempts to ignore effects like particles, lens flare. Will still show up if they are in front of your character however.
  - **Transparency** — Adjust transparency of the mirror
  - **Transparency Mask** — Texture mask that adjusts the transparency of the mirror, goes from white for fully opaque, to fully transparent with black.
  - **Distance Fade** — Distance before the mirror starts fading to zero alpha. Disabled at 0.
  - **Distance Fade Length** — The length of distance traveled needed to fade to zero alpha.
  - **Smooth Edge** — Make edge smoother and avoid transparent object being rendered opaque.
  - **Alpha Tweak Level** — Adjust smooth edge power.

# Caveats

  - If you turn on Smooth Edge:
    - Depending on shader used, transparent materials on avatars may cause certain parts of your avatar to be transparent incorrectly. (UTS has this problem)
  - If you turn off Smooth Edge:
    - Most transparent materials will appear opaque in the mirror
    - Particles, additive materials etc. will have black outlines
  - Transparent materials behind or in front of the mirror may overwrite or be overwritten by the mirror; adjusting the render queue can help, or as a last resort use stencils.

# Updates

#### v0.2.0 — 2026
  - Modernized for current VRChat World SDK + Unity 2022.3.22f1
  - Migrated Udon Graph transparency-slider binding to UdonSharp
  - Added VPM `package.json` (VPM-listing-ready) so the SDK3 folder can be consumed by Creator Companion once a listing index is published
  - Marked SDK2 distribution as archive-only (VRChat dropped SDK2 support)
  - Added VRChat PlayerData persistence for the mirror toggle (`MirrorToggleState`) and the transparency slider (`MirrorTransparency`) — settings now survive across sessions per-player
  - `persistKey` is exposed as a public inspector field on both scripts, so the same components can be reused for multiple toggles / sliders in one world without their PlayerData slots colliding
  - Fixed a latent bug in `PlayersOnlyMirror.shader` where the distance-fade interpolator was uninitialized and compared across mismatched spaces; world-space position is now computed in vert and the fade works the moment the Distance Fade slider is raised above 0
  - Added `#pragma multi_compile_instancing` to both shaders so worlds with multiple mirror instances can GPU-batch them (SPS-I stereo macros were already correctly in place)
  - Repo now tracks Unity `.meta` files and ships the prefab pre-wired, so importing the folder no longer requires a `.unitypackage` or manual sprite/import-setting fixups

#### 12th Sep 2022
  - Added Smooth Edge Toggle (Thanks to xiphia)

#### 31st Aug 2022
  - As of VRCSDK3-WORLD-2022.08.29.20.48_Public, "TransparentBackground" mask is no longer needed, as VRCMirror allows setting of custom camera clear flags
  - For SDK3 only

#### 16th May 2021
  - Switched from Toggle to ToggleUI in shaders to reduce shader keywords used

#### 6th Feb 2021
  - Added Cutout variant. This version shouldn't have issues with transparent objects behind/in front of the mirror and should be used if you don't need transparency.
  - Added Ignore Effects toggle. Tries to ignore particle effects, lens flare and certain transparent effects which are read as zero alpha from mirror reflection render texture.

# Demo

If you'd like to see this mirror in action you can find it in one of my public maps, Winter Solace.
https://vrchat.com/home/world/wrld_8899947f-8e19-4981-b327-a63be233706a

![demo1](https://nyanpa.su/i/MKH21bPq.jpg)
![demo2](https://nyanpa.su/i/gEzZ1bQD.jpg)

Credits appreciated but not required.
