using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]
    private AudioSource _bgmAudioSource;
    [SerializeField]
    private AudioSource _sfxAudioSource;
}