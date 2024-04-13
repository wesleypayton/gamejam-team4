using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code referenced from Simple Sound Manager (Unity Tutorial) by Code Monkey
// https://www.youtube.com/watch?v=QL29aTa7J5Q

public static class SoundManager
{
    //collection of sounds
    public enum Sound {
        Bee,
        EpiPenGet,
        FlowerHeal,
        Jump,
        Click
    }

    //play simple sound once
    public static void PlaySound(Sound sound) {
        //create a gameobject with an audio component
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();

        //Plays sound once
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound) {
        foreach (SoundAsset.SoundAudioClip soundAudioClip in SoundAsset.i.soundAudioClipArray) {
            if(soundAudioClip.sound == sound) {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found");
        return null;
        
    }

    

}
