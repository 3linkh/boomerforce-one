using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicPlayer", menuName = "Music/NewMusicPlayer", order = 0)]
public class MusicPlayerSO : ScriptableObject
{
    public string musicPlayerName;

    public string description;

    public AudioClip audioClip1;

    public AudioClip audioClip2;

    public AudioClip audioClip3;

    public AudioSource audioSource1;

    public AudioSource audioSource2;

    public AudioSource audioSource3;
}
