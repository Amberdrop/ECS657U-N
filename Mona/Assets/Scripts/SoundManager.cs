using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{

   public static SoundManager instance;

//    [SerializeField] private AudioSource collectGemSoundEffect, collectUpgradeSoundEffect;
[SerializeField] private AudioSource backgroundSource;

   void Awake() {
        if (instance == null) {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
   }

   public void ChangeMasterVolume(float volume) {
    AudioListener.volume = volume;
   }

//    public void PlayGemSound(AudioClip clip) {
//         collectGemSoundEffect.Play();
//    }

//    public void PlayUpgradeSound(AudioClip clip) {
//         collectUpgradeSoundEffect.Play();
//    }
}
