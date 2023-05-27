using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public MusicPlayerSO musicPlayerSO;
    public AudioClip backgroundMusicClip;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicPlayerSO.audioClip1; 

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
