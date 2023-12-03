using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SibJam.Features.Audio;

namespace SibJam
{
    public class Test : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audio;


        [SerializeField]
        private bool _playOnA;

        private void Start()
        {
            if (_playOnA)
                GlobalAudioSource.Instance.PlayClip(_audio.clip);


        }

        public void PlAy() 
        {
            GlobalAudioSource.Instance.PlayClip(_audio.clip);
        }
    }
}
