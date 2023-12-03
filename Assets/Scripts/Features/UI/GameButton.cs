using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SibJam.Features.Audio;

namespace SibJam.Features.UI
{
    public sealed class GameButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private AudioClip _audioClip;

        [Range(0f, 1f)]
        [SerializeField]
        private float _volume = 1f;

        // Start is called before the first frame update
        void Start()
        {
            _button.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            if (_audioClip != null) 
            {
                GlobalAudioSource.Instance.PlayClip(_audioClip, _volume);
            }
        }
    }
}
