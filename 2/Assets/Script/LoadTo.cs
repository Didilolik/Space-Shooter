using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTo : MonoBehaviour
{
    [SerializeField] private int a; 
    void Start()
    {
        AudioSource musicMenu = GameObject.Find("Music(Clone)").GetComponent<AudioSource>();
        StartCoroutine(Player.VolumeChanger(1, musicMenu));

        a = PlayerPrefs.GetInt("adsCounter");
    }
    void Update()
    {
    }
    public void Game()
    {
        a++;
        Debug.Log(a);
        PlayerPrefs.SetInt("adsCounter", a);

        if (a == 3)
        {
            a = 0;
            StartCoroutine(Ads.showAds());
        }

        SceneManager.LoadScene("Game");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
