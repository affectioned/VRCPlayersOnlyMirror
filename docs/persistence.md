# Persistence

The example prefab uses [VRChat PlayerData](https://creators.vrchat.com/worlds/udon/persistence/) to save UI state **per-player, per-world** so it survives across sessions and instances. No server / per-world database needed — VRChat stores it.

## Defaults

| Default key            | Type   | Set by                | What it remembers           |
|------------------------|--------|-----------------------|-----------------------------|
| `vpom_mirror_enabled`  | bool   | `MirrorToggleState`   | Whether the mirror is on    |
| `vpom_transparency`    | float  | `MirrorTransparency`  | The transparency slider value |

## How it works

Both UdonSharp scripts read PlayerData inside `OnPlayerRestored` (the safe entry point — PlayerData is not available before that event fires) and only persist data for the local player. Each script exposes two inspector fields:

  - `persist` — checkbox to disable PlayerData reads/writes on a per-component basis.
  - `persistKey` — the PlayerData slot name. Give each instance a unique key if you reuse these scripts on multiple toggles or sliders in the same world; leave it blank to disable persistence without unchecking `persist`.

## Budget

Each world can store up to 100KB of PlayerData per player; this prefab uses ~16 bytes.
