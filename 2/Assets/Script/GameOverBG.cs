using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverBG : MonoBehaviour
{
    private int c;

    public List<Sprite> backgrounds;
    void Start()
    {
        c = PlayerPrefs.GetInt("Back");

        switch (c)
        {
            case 1: GetComponent<SpriteRenderer>().sprite = backgrounds[0]; break;
            case 2: GetComponent<SpriteRenderer>().sprite = backgrounds[1]; break;
            case 3: GetComponent<SpriteRenderer>().sprite = backgrounds[2]; break;
            case 4: GetComponent<SpriteRenderer>().sprite = backgrounds[3]; break;
            case 5: GetComponent<SpriteRenderer>().sprite = backgrounds[4]; break;
            case 6: GetComponent<SpriteRenderer>().sprite = backgrounds[5]; break;
            case 7: GetComponent<SpriteRenderer>().sprite = backgrounds[6]; break;
            case 8: GetComponent<SpriteRenderer>().sprite = backgrounds[7]; break;
        }
    }
    void Update()
    {
        
    }
}
