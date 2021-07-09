using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public float health = 3;

    public Sprite heartEmpty, halfHeart;
    
    [SerializeField]private List<Image> hearts;

    public int score;

    private Text scoreTxt;

    public int direction { get; set; }

    [SerializeField] private int speed = 3;

    private Vector3 leftBorder, rightBorder;

    [SerializeField] private AudioSource musicMenu, music;
    void Start()
    {
        musicMenu = GameObject.Find("Music(Clone)").GetComponent<AudioSource>();

        music = GameObject.Find("Music").GetComponent<AudioSource>();

        StartCoroutine(VolumeChanger(-1, musicMenu));

        StartCoroutine(VolumeChanger(1, music));

        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));

        scoreTxt = GameObject.Find("ScoreText").GetComponent<Text>();

        GetImg();
    }
    private void GetImg ()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i] = GameObject.Find("Heart" + (i++).ToString()).GetComponent<Image>();
        }
    }
    void Update()
    {
        if(transform.position.x > leftBorder.x && transform.position.x < rightBorder.x)
        {
            transform.Translate(direction * speed * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x <= leftBorder.x)
        {
            transform.position = new Vector3(leftBorder.x + 0.01f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= rightBorder.x)
        {
            transform.position = new Vector3(rightBorder.x - 0.01f, transform.position.y, transform.position.z);
        }
        switch (health) 
        { 
            case 2.5f: hearts[0].sprite = halfHeart; break;
            case 2.0f: hearts[0].sprite = heartEmpty; break;
            case 1.5f: hearts[1].sprite = halfHeart; break;
            case 1.0f: hearts[1].sprite = heartEmpty; break;
            case 0.5f: hearts[2].sprite = halfHeart; break;
            case 0: hearts[2].sprite = heartEmpty; break;
        }
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
            StartCoroutine(VolumeChanger(-1, music));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "meteor")
        {
            health -= 0.5f;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "star")
        {
            score ++;
            scoreTxt.text = score.ToString();
            PlayerPrefs.SetInt("Score", score);
            Destroy(collision.gameObject);
        }
    }
     public static IEnumerator VolumeChanger (int k, AudioSource audio)
    {
        if (k == 1)
        {
            audio.Play();
        }
        for (int i = 0; i < 10; i++)
        {
            audio.volume += 0.1f * k;
            yield return new WaitForSeconds(0.05f);
        }
        if (k == -1)
        {
            audio.Pause();
        }
    }



}
