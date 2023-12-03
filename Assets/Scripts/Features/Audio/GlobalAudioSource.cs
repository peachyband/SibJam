using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SibJam.Features.Audio
{
    public sealed class GlobalAudioSource : MonoBehaviour
    {

        private static GlobalAudioSource s_instance;
        public static GlobalAudioSource Instance 
        {
            get
            {
                if (s_instance == null) 
                {
                    GlobalAudioSource prefab = Resources.Load<GlobalAudioSource>("GlobalAudioSource");

                    var gobj = Instantiate<GlobalAudioSource>(prefab);
                    gobj.name = "GlobalAudioSource";

                    s_instance = gobj;

                    s_instance._audioSource =  gobj.GetComponent<AudioSource>();
                    DontDestroyOnLoad(gobj);

                    SceneManager.sceneUnloaded += s_instance.OnSceneUnload;
                    SceneManager.sceneLoaded += s_instance.OnSceneLoad;
                }
                return s_instance;
            }
        }

        private AudioSource _audioSource;


        public void PlayClip(AudioClip clip, float volume = 1f) 
        {
            _audioSource.PlayOneShot(clip, volume);
        }

        private void OnSceneUnload(Scene scene) 
        {
            print("Unload!");
            _audioSource.enabled = false;
        }

        private void OnSceneLoad(Scene scene, LoadSceneMode mode) 
        {
            print("Load!");

            _audioSource.enabled = true;
        }

        
    }
}
