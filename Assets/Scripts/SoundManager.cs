using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        PlayerMove,
        Click
    }

    //dictionary that keeps times of sounds to avoid sounds playing over itself
    private static Dictionary<Sound, float> soundTimerDict;

    public static void Initialize() {
        soundTimerDict = new Dictionary<Sound, float>();
        soundTimerDict[Sound.PlayerMove] = 0f;
    }

    //play simple sound once
    public static void PlaySound(Sound sound) {
        //check if you can play sound
        if(CanPlaySound(sound)) {
            //create a gameobject with an audio component
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();

            //Plays sound once
            audioSource.PlayOneShot(GetAudioClip(sound));
        }
        
    }

    private static bool CanPlaySound(Sound sound) {
        switch (sound) {
        default: 
                return true;
        case Sound.PlayerMove:
                if (soundTimerDict.ContainsKey(sound)) {
                    float lastTimePlayed = soundTimerDict[sound];
                    float playerMoveTimerMax = .05f;
                    if(lastTimePlayed + playerMoveTimerMax < Time.time) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return true;
                }
                //break;
        }
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
