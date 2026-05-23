# Changelog

## v0.2.0 — 2026

  - Modernized for current VRChat World SDK + Unity 2022.3.22f1
  - Migrated Udon Graph transparency-slider binding to UdonSharp
  - Added VPM `package.json` (VPM-listing-ready) so the SDK3 folder can be consumed by Creator Companion once a listing index is published
  - Marked SDK2 distribution as archive-only (VRChat dropped SDK2 support)
  - Added VRChat PlayerData persistence for the mirror toggle (`MirrorToggleState`) and the transparency slider (`MirrorTransparency`) — settings now survive across sessions per-player
  - `persistKey` is exposed as a public inspector field on both scripts, so the same components can be reused for multiple toggles / sliders in one world without their PlayerData slots colliding
  - Fixed a latent bug in `PlayersOnlyMirror.shader` where the distance-fade interpolator was uninitialized and compared across mismatched spaces; world-space position is now computed in vert and the fade works the moment the Distance Fade slider is raised above 0
  - Added `#pragma multi_compile_instancing` to both shaders so worlds with multiple mirror instances can GPU-batch them (SPS-I stereo macros were already correctly in place)
  - Repo now tracks Unity `.meta` files and ships the prefab pre-wired, so importing the folder no longer requires a `.unitypackage` or manual sprite/import-setting fixups

## 12th Sep 2022
  - Added Smooth Edge Toggle (Thanks to xiphia)

## 31st Aug 2022
  - As of VRCSDK3-WORLD-2022.08.29.20.48_Public, "TransparentBackground" mask is no longer needed, as VRCMirror allows setting of custom camera clear flags
  - For SDK3 only

## 16th May 2021
  - Switched from Toggle to ToggleUI in shaders to reduce shader keywords used

## 6th Feb 2021
  - Added Cutout variant. This version shouldn't have issues with transparent objects behind/in front of the mirror and should be used if you don't need transparency.
  - Added Ignore Effects toggle. Tries to ignore particle effects, lens flare and certain transparent effects which are read as zero alpha from mirror reflection render texture.
