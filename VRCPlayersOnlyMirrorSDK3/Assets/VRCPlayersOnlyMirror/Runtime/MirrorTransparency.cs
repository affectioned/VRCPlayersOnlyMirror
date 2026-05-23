using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Persistence;
using VRC.SDKBase;
using VRC.Udon;

namespace VRCPlayersOnlyMirror
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [AddComponentMenu("VRCPlayersOnlyMirror/Mirror Transparency")]
    public class MirrorTransparency : UdonSharpBehaviour
    {
        [Tooltip("Slider that drives the mirror's _Transparency shader property in real time.")]
        public Slider uiSlider;

        [Tooltip("MeshRenderer using the PlayersOnlyMirror material to drive.")]
        public MeshRenderer Mirror;

        [Tooltip("Persist the slider value per-player via VRChat PlayerData so it survives across sessions.")]
        public bool persist = true;

        [Tooltip("PlayerData key used to persist the slider value. Give each instance a unique key when reusing this component on multiple sliders in the same world.")]
        public string persistKey = "vpom_transparency";

        public void OnValueChanged()
        {
            if (uiSlider == null || Mirror == null) return;
            float v = uiSlider.value;
            Mirror.material.SetFloat("_Transparency", v);
            if (persist && !string.IsNullOrEmpty(persistKey) && Networking.LocalPlayer != null)
            {
                PlayerData.SetFloat(persistKey, v);
            }
        }

        public override void OnPlayerRestored(VRCPlayerApi player)
        {
            if (!persist || string.IsNullOrEmpty(persistKey)) return;
            if (player == null || !player.isLocal) return;
            if (uiSlider == null || Mirror == null) return;
            if (!PlayerData.HasKey(player, persistKey)) return;

            float restored = PlayerData.GetFloat(player, persistKey);
            uiSlider.SetValueWithoutNotify(restored);
            Mirror.material.SetFloat("_Transparency", restored);
        }
    }
}
