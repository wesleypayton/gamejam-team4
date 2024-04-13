using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    //collection of sounds
    public enum Sound {
        BeeLow,
        BeeMed,
        BeeHigh,
        EpiPenGet,
        FlowerHeal,
        Jump
    }

    //play simple sound once
    public static void PlaySound() {
        //create a gameobject with an audio component
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        
        //Plays sound once
        //audioSource.PlayOneShot();
    }


}
