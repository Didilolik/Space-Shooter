using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour
{
    private int b;

    [SerializeField] private GameObject background;

    public List<Sprite> backgrounds;

    void Start()
    {
        b = PlayerPrefs.GetInt("Back");

        switch (b)
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
        
    }
}
