using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace SibJam.Features.Settings
{
    [CreateAssetMenu(fileName = "NewSettingsConfig", menuName = "Config/Settings")]
    public sealed class SettingsConfig : ScriptableObject
    {

        [field: SerializeField]
        public AudioMixer AudioMixer { get; private set; }

        [field: SerializeField]
        public string MasterVolumeParameterName { get; private set; }
        [field: SerializeField]
        public string BgmVolumeParameterName { get; private set; }
        [field: SerializeField]
        public string SfxVolumeParameterName { get; private set; }

        [SerializeField]
        [Range(0.0001f, 1)]
        public float m_defaultMasterVolume = 1f;
        [SerializeField]
        [Range(0.0001f, 1)]
        public float m_defaultBgmVolume = 1f;
        [SerializeField]
        [Range(0.0001f, 1)]
        public float m_defaultSfxVolume = 1f;

        public float DefaultMasterVolume => m_defaultMasterVolume;
        public float DefaultBgmVolume => m_defaultBgmVolume;
        public float DefaultSfxVolume => m_defaultSfxVolume;

    }
}
