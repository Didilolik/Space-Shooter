using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private int a;

    private int b;

    public Text scoreSkin, scoreStar, score;

    private void Awake()
    {
       score = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        a = PlayerPrefs.GetInt("Score");

        b = PlayerPrefs.GetInt("ScoreMenu");


        if (sceneName == "Menu")
        {
            score.text = b.ToString();
            scoreSkin.text = b.ToString();
            scoreStar.text = b.ToString();
        }
        else 
        {
            b += a;
            score.text = a.ToString();
            PlayerPrefs.SetInt("ScoreMenu", b);
        }
    }
    void Update()
    {

    }
}
    
