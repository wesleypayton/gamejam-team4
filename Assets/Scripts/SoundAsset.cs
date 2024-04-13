using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class SoundAsset : MonoBehaviour
{
    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
