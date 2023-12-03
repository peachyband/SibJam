using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SibJam.Features.Settings
{
    public static class SettingsManager
    {
        public enum VolumeType 
        {
            Master,
            BGM,
            SFX
        }

        private static SettingsConfig s_config;

        private static float s_masterVolume;
        private static float s_bgmVolume;
        private static float s_sfxVolume;

        private const string ConfigPath = "SettingsConfig";

        public static float MasterVolume => s_masterVolume;
        public static float BgmVolume => s_bgmVolume;
        public static float SfxVolume => s_sfxVolume;


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void Init() 
        {
            s_config = Resources.Load<SettingsConfig>(ConfigPath);

            s_masterVolume = PlayerPrefs.HasKey(s_config.MasterVolumeParameterName) 
                ? PlayerPrefs.GetFloat(s_config.MasterVolumeParameterName)
                : s_config.DefaultMasterVolume;
            s_bgmVolume = PlayerPrefs.HasKey(s_config.BgmVolumeParameterName)
                ? PlayerPrefs.GetFloat(s_config.BgmVolumeParameterName)
                : s_config.DefaultBgmVolume;
            s_sfxVolume = PlayerPrefs.HasKey(s_config.SfxVolumeParameterName)
                ? PlayerPrefs.GetFloat(s_config.SfxVolumeParameterName)
                : s_config.DefaultSfxVolume;

            SetMixerVolume(s_config.MasterVolumeParameterName, s_masterVolume);
            SetMixerVolume(s_config.BgmVolumeParameterName, s_bgmVolume);
            SetMixerVolume(s_config.SfxVolumeParameterName, s_sfxVolume);



        }

        private static void SetMixerVolume(string key, float value) 
        {
            s_config.AudioMixer.SetFloat(key, Mathf.Log10(value) * 20);
        }

        public static void SetVolume(VolumeType volumeType, float value) 
        {
            string key = null;
            switch (volumeType) 
            {
                case VolumeType.Master:
                    {
                        key = s_config.MasterVolumeParameterName;
                        s_masterVolume = value;
                    }
                    break;
                case VolumeType.BGM:
                    {
                        key = s_config.BgmVolumeParameterName;
                        s_bgmVolume = value;
                    }
                    break;
                case VolumeType.SFX:
                    {
                        key = s_config.SfxVolumeParameterName;
                        s_sfxVolume = value;
                    }
                    break;
            }

            PlayerPrefs.SetFloat(key, value);

            SetMixerVolume(key, value);
        }
    }
}
