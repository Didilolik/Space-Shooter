using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketColor : MonoBehaviour
{
    private int b;

    [SerializeField] private GameObject rocket;

    public List<Sprite> rockets;

    void Start()
    {
        b = PlayerPrefs.GetInt("Rocket");

        switch (b)
        {
            case 1: rocket.GetComponent<SpriteRenderer>().sprite = rockets[0]; break;
            case 2: rocket.GetComponent<SpriteRenderer>().sprite = rockets[1]; break;
            case 3: rocket.GetComponent<SpriteRenderer>().sprite = rockets[2]; break;
            case 4: rocket.GetComponent<SpriteRenderer>().sprite = rockets[3]; break;
            case 5: rocket.GetComponent<SpriteRenderer>().sprite = rockets[4]; break;
            case 6: rocket.GetComponent<SpriteRenderer>().sprite = rockets[5]; break;
        }
    }
    void Update()
    {
        
    }
}
