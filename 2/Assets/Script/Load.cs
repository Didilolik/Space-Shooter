using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Load : MonoBehaviour
{
    [SerializeField] private Animator anim, rocketAnim;

    [SerializeField] private GameObject background, star;

    private int a, c;

    private SpriteRenderer b;

    public List<Sprite> backgrounds;
    void Start()
    {
        b = background.GetComponent<SpriteRenderer>();

        c = PlayerPrefs.GetInt("Back");

        rocketAnim = GameObject.Find("Rocket").GetComponent<Animator>();

        switch (c)
        {
            case 1: background.GetComponent<SpriteRenderer>().sprite = backgrounds[0]; break;
            case 2: background.GetComponent<SpriteRenderer>().sprite = backgrounds[1]; break;
            case 3: background.GetComponent<SpriteRenderer>().sprite = backgrounds[2]; break;
            case 4: background.GetComponent<SpriteRenderer>().sprite = backgrounds[3]; break;
            case 5: background.GetComponent<SpriteRenderer>().sprite = backgrounds[4]; break;
            case 6: background.GetComponent<SpriteRenderer>().sprite = backgrounds[5]; break;
            case 7: background.GetComponent<SpriteRenderer>().sprite = backgrounds[6]; break;
            case 8: background.GetComponent<SpriteRenderer>().sprite = backgrounds[7]; break;
        }
    }
    void Update()
    {
        switch (b.sprite.name) 
        {
            case "BackBlack": a = 1; break;
            case "BackGreen": a = 2; break;
            case "BackBlue": a = 3; break;
            case "BackDarkBlue": a = 4; break;
            case "BackViolet": a = 5; break;
            case "BackDarkViolet": a = 6; break;
            case "BackDarkPurple": a = 7; break;
            case "BackPurple": a = 8; break;
        }
        PlayerPrefs.SetInt("Back", a);
    }
    public void ToPlay()
    {
        StartCoroutine(Anim());
    }
    private IEnumerator Anim()
    {
        anim.SetTrigger("Animation");
        rocketAnim.SetTrigger("Anim");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Game");
    }
    public void BackSettings(GameObject b)
    {
        background.GetComponent<SpriteRenderer>().sprite = b.GetComponent<Image>().sprite;
    }
    public void Exit ()
    {
        Application.Quit();
    }

}
