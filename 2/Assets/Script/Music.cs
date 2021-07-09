using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup master;

    [SerializeField] private GameObject music, star;

    [SerializeField] private List<AudioClip> musics;

    [SerializeField] private Transform point;

    public static GameObject spawnedStar, spawnedMusic;

    void Start()
    {
        if (spawnedStar == null)
        {
            spawnedStar = Instantiate(star, point.position, Quaternion.Euler(90, 0, 0));
            DontDestroyOnLoad(spawnedStar);
        }
        if (spawnedMusic == null)
        {
            spawnedMusic = Instantiate(music, point.position, Quaternion.identity);
            DontDestroyOnLoad(spawnedMusic);
        }
    }
    void Update()
    {
  
    }
    public void Musics (float volume) 
    { 
        master.audioMixer.SetFloat("Volume", Mathf.Lerp(-80f, 10f, volume));
    }
    
}
