using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour
{
    static AudioSource audioSrc;
    public static AudioClip jumpSound, clickSound, slideSound, crabDeathSound, meepDeathSound, hammerSound, dashSound;
    [SerializeField] Slider volumeSlider;

    // Use this for intialization
    void Start(){ //need to get to assets folder then sounds wrong path will fix

        if(!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        jumpSound = Resources.Load<AudioClip> ("JumpNoiseProcessed");
        clickSound = Resources.Load<AudioClip> ("ClickNoise");
        slideSound = Resources.Load<AudioClip> ("ShortSlide");
        crabDeathSound = Resources.Load<AudioClip> ("crabdeath");
        meepDeathSound = Resources.Load<AudioClip> ("meepdeath");
        hammerSound = Resources.Load<AudioClip> ("hammerSound");
        dashSound = Resources.Load<AudioClip> ("dashSound");
        
        audioSrc = GetComponent<AudioSource> ();
        
    }
    public void changeVolume(){
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load(){
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save(){
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public static void PlaySound(string clip){
        switch(clip){
            case "JumpNoiseProcessed":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "ClickNoise":
                audioSrc.PlayOneShot(clickSound);
                break;
            case "ShortSlide":
                audioSrc.PlayOneShot(slideSound);
                break;
            case "crabdeath":
                audioSrc.PlayOneShot(crabDeathSound);
                break;
            case "meepdeath":
                audioSrc.PlayOneShot(meepDeathSound);
                break;
            case "hammerSound":
                audioSrc.PlayOneShot(hammerSound);
                break;
            case "dashSound":
                audioSrc.PlayOneShot(dashSound);
                break;
        }
    }
}
