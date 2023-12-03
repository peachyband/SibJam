
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SibJam.Features.Settings;

namespace SibJam.Features.UI
{
    public sealed class SettingsSubWindow : SubWindow
    {
        [SerializeField]
        private Slider _masterVolumeSlider;
        [SerializeField]
        private Slider _bgmVolumeSlider;
        [SerializeField]
        private Slider _sfxVolumeSlider;

        protected override void Start()
        {
            base.Start();

            _masterVolumeSlider.value = SettingsManager.MasterVolume;
            _bgmVolumeSlider.value = SettingsManager.BgmVolume;
            _sfxVolumeSlider.value = SettingsManager.SfxVolume;

            _masterVolumeSlider.onValueChanged.AddListener(HandleMasterSlider);
            _bgmVolumeSlider.onValueChanged.AddListener(HandleBgmSlider);
            _sfxVolumeSlider.onValueChanged.AddListener(HandleSfxSlider);

            //SettingsManager.SetVolume(SettingsManager.VolumeType.SFX, SettingsManager.SfxVolume);

        }

        //private void OnDestroy()
        //{
        //    _mas
        //}

        private void HandleMasterSlider(float value)
        {
            SettingsManager.SetVolume(SettingsManager.VolumeType.Master, value);
        }

        private void HandleBgmSlider(float value)
        {
            SettingsManager.SetVolume(SettingsManager.VolumeType.BGM, value);
        }

        private void HandleSfxSlider(float value)
        {
            SettingsManager.SetVolume(SettingsManager.VolumeType.SFX, value);
        }
    }
}
