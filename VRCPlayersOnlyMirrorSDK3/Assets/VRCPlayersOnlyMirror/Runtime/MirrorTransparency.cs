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
        const string PersistKey = "vpom_transparency";

        [Tooltip("Slider that drives the mirror's _Transparency shader property in real time.")]
        public Slider uiSlider;

        [Tooltip("MeshRenderer using the PlayersOnlyMirror material to drive.")]
        public MeshRenderer Mirror;

        [Tooltip("Persist the slider value per-player via VRChat PlayerData so it survives across sessions.")]
        public bool persist = true;

        public void OnValueChanged()
        {
            if (uiSlider == null || Mirror == null) return;
            float v = uiSlider.value;
            Mirror.material.SetFloat("_Transparency", v);
            if (persist && Networking.LocalPlayer != null)
            {
                PlayerData.SetFloat(PersistKey, v);
            }
        }

        public override void OnPlayerRestored(VRCPlayerApi player)
        {
            if (!persist || player == null || !player.isLocal) return;
            if (uiSlider == null || Mirror == null) return;
            if (!PlayerData.HasKey(player, PersistKey)) return;

            float restored = PlayerData.GetFloat(player, PersistKey);
            uiSlider.SetValueWithoutNotify(restored);
            Mirror.material.SetFloat("_Transparency", restored);
        }
    }
}
