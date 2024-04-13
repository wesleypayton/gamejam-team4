using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

// code referenced from Simple Sound Manager (Unity Tutorial) by Code Monkey
// https://www.youtube.com/watch?v=QL29aTa7J5Q

public class SoundAsset : MonoBehaviour
{
    private static SoundAsset _i;

    public static SoundAsset i {
        get {
            if(_i == null) _i = Instantiate(Resources.Load<SoundAsset>("SoundAsset")); return _i;
        }
    }

    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
