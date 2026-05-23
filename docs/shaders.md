# Shader reference

Two shaders ship with the package, both selectable on the prefab's mirror material:

## Shader types

  - **PlayersOnlyMirror** — Regular version with transparency and distance fade.
  - **PlayersOnlyMirrorCutout** — Variant with just cutout, no transparency or distance fade.

## Shader settings

  - **Base (RBG)** — Overlays a texture onto the reflection, same behavior as the default mirror shader.
  - **Hide Background** — Hides the background, requires the TransparentBackground shader acting as a fake background for the mirror for this to work.
  - **Ignore Effects** — Attempts to ignore effects like particles, lens flare. Will still show up if they are in front of your character however.
  - **Transparency** — Adjust transparency of the mirror.
  - **Transparency Mask** — Texture mask that adjusts the transparency of the mirror, goes from white for fully opaque, to fully transparent with black.
  - **Distance Fade** — Distance before the mirror starts fading to zero alpha. Disabled at 0.
  - **Distance Fade Length** — The length of distance traveled needed to fade to zero alpha.
  - **Smooth Edge** — Make edge smoother and avoid transparent object being rendered opaque.
  - **Alpha Tweak Level** — Adjust smooth edge power.

## Caveats

  - If you turn on Smooth Edge:
    - Depending on shader used, transparent materials on avatars may cause certain parts of your avatar to be transparent incorrectly. (UTS has this problem)
  - If you turn off Smooth Edge:
    - Most transparent materials will appear opaque in the mirror
    - Particles, additive materials etc. will have black outlines
  - Transparent materials behind or in front of the mirror may overwrite or be overwritten by the mirror; adjusting the render queue can help, or as a last resort use stencils.

## Customizing the toggle / slider UI colors

The four UI sprites (`Textures/Slider.png`, `SliderFill.png`, `ToggleBox.png`, `ToggleCheckbox.png`) ship as **white shapes on transparent backgrounds**, with the default light-blue look applied via each `Image` component's `Color` field on the prefab (`r: 0.392, g: 0.498, b: 0.678` — except the slider's filled portion, which uses a darker `0.225, 0.286, 0.388` so it reads as a denser bar).

To recolor the UI, select the relevant `Image` GameObject under the prefab and pick any color from the `Color` field — no texture editing needed:

  - **Toggle outline** — `MirrorToggle/Background` Image
  - **Toggle checkmark** — `MirrorToggle/Background/Checkmark` Image
  - **Slider track / handle** — `TransparencySlider/Background`, `TransparencySlider/Handle Slide Area/Handle` Images
  - **Slider filled portion** — `TransparencySlider/Fill Area/Fill` Image

## "VRC Mirror Reflection" component setup

If the background is still visible in the mirror, double-check that the `VRC_MirrorReflection` component on the `Mirror` GameObject is configured the way the prefab ships it:

![vrcmirrorreflection](https://cdn.nyanpa.su/i/PiMX2EB0.jpg)
