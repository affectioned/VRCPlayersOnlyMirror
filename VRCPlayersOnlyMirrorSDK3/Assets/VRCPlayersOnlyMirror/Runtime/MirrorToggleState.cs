using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Persistence;
using VRC.SDKBase;
using VRC.Udon;

namespace VRCPlayersOnlyMirror
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [AddComponentMenu("VRCPlayersOnlyMirror/Mirror Toggle State")]
    public class MirrorToggleState : UdonSharpBehaviour
    {
        [Tooltip("UI Toggle that controls whether the mirror is active.")]
        public Toggle mirrorToggle;

        [Tooltip("GameObjects enabled/disabled by the toggle (e.g. the Mirror and the TransparencySlider).")]
        public GameObject[] targets;

        [Tooltip("Persist the toggle state per-player via VRChat PlayerData so it survives across sessions.")]
        public bool persist = true;

        [Tooltip("PlayerData key used to persist the toggle state. Give each instance a unique key when reusing this component on multiple toggles in the same world.")]
        public string persistKey = "vpom_mirror_enabled";

        public void OnToggleChanged()
        {
            if (mirrorToggle == null) return;
            bool on = mirrorToggle.isOn;
            ApplyTargets(on);
            if (persist && !string.IsNullOrEmpty(persistKey) && Networking.LocalPlayer != null)
            {
                PlayerData.SetBool(persistKey, on);
            }
        }

        public override void OnPlayerRestored(VRCPlayerApi player)
        {
            if (!persist || string.IsNullOrEmpty(persistKey)) return;
            if (player == null || !player.isLocal) return;
            if (mirrorToggle == null) return;
            if (!PlayerData.HasKey(player, persistKey)) return;

            bool restored = PlayerData.GetBool(player, persistKey);
            mirrorToggle.SetIsOnWithoutNotify(restored);
            ApplyTargets(restored);
        }

        void ApplyTargets(bool on)
        {
            if (targets == null) return;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] != null) targets[i].SetActive(on);
            }
        }
    }
}