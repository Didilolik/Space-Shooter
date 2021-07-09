using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;

public class Purch : MonoBehaviour
{
    public GameObject decline;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void SuccessfulS1(Product stars1)
    {
        int b = PlayerPrefs.GetInt("ScoreMenu");
        b += 100;
        PlayerPrefs.SetInt("ScoreMenu", b);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SuccessfulS3(Product stars3)
    {
        int b = PlayerPrefs.GetInt("ScoreMenu");
        b += 500;
        PlayerPrefs.SetInt("ScoreMenu", b);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SuccessfulS5(Product stars5)
    {
        int b = PlayerPrefs.GetInt("ScoreMenu");
        b += 1000;
        PlayerPrefs.SetInt("ScoreMenu", b);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Decline(Product stars, PurchaseFailureReason faile)
    {
        decline.SetActive(true);
    }
}
