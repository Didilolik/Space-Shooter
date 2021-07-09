using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Store : MonoBehaviour
{
    private int c, a;

    [SerializeField] private GameObject rocket;

    private SpriteRenderer b;

    public List<Sprite> rockets, storeV, storeE;

    public List<Image> buttons;

    private int score;

    private string path;

    private Save save = new Save();

    public Score score_;

    void Start()
    {
        path = save.CreatePath();

        if (File.Exists(path))
        {
            save = JsonUtility.FromJson<Save>(File.ReadAllText(path));

            for (int i = 0; i < buttons.Count; i++)
            {
                if (save.bought[i])
                {
                    if(save.v[i])
                    {
                        buttons[i].sprite = storeV[i];  
                    }
                    else
                    {
                        buttons[i].sprite = storeE[i];
                    }
                }
            }
        }
            
        b = rocket.GetComponent<SpriteRenderer>();

        c = PlayerPrefs.GetInt("Rocket");

        score = PlayerPrefs.GetInt("ScoreMenu");

        switch (c)
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
        switch (b.sprite.name)
        {
            case "RocketBlack": a = 1; break;
            case "RocketBlue": a = 2; break;
            case "RocketGreen": a = 3; break;
            case "RocketPurple": a = 4; break;
            case "RocketRed": a = 5; break;
            case "RocketViolet": a = 6; break;
        }
        PlayerPrefs.SetInt("Rocket", a);
    }
    public void RocketColour(Sprite b)
    {
        rocket.GetComponent<SpriteRenderer>().sprite = b;

    }
    public void PurchasingPower(Image button)
    {
        if(score>=1000 && !button.sprite.name.Contains("V") && !button.sprite.name.Contains("E"))
        {
            int color = -1;
            switch (button.gameObject.name)
            {
                case "Black": button.sprite = storeV[0]; color = 0; break;
                case "Blue": button.sprite = storeV[1]; color = 1; break;
                case "Green": button.sprite = storeV[2]; color = 2; break;
                case "Purple": button.sprite = storeV[3]; color = 3; break;
                case "Red": button.sprite = storeV[4]; color = 4; break;
                case "Default": button.sprite = storeV[5]; color = 5; break;
            }
            score -= 1000;
            PlayerPrefs.SetInt("ScoreMenu", score);
            score_.score.text = score.ToString();
            score_.scoreSkin.text = score.ToString();
            score_.scoreStar.text = score.ToString();
            save.bought[color] = true;

            for (int i = 0; i < buttons.Count; i++)
            {
                if (i == color)
                {
                    save.v[i] = true; continue;
                }

                if(buttons[i].sprite.name.Contains("V"))
                {
                    save.v[i] = false; buttons[i].sprite = storeE[i];
                }
            }
            save.SaveData(path, save);
        }
        else if (button.sprite.name.Contains("E"))
        {
            int color = -1;
            switch (button.gameObject.name)
            {
                case "Black": button.sprite = storeV[0]; color = 0; break;
                case "Blue": button.sprite = storeV[1]; color = 1; break;
                case "Green": button.sprite = storeV[2]; color = 2; break;
                case "Purple": button.sprite = storeV[3]; color = 3; break;
                case "Red": button.sprite = storeV[4]; color = 4; break;
                case "Default": button.sprite = storeV[5]; color = 5; break;
            }
            for (int i = 0; i < buttons.Count; i++)
            {
                if (i == color)
                {
                    save.v[i] = true; continue;
                }

                if (buttons[i].sprite.name.Contains("V"))
                {
                    save.v[i] = false; buttons[i].sprite = storeE[i];
                }
            }
            save.SaveData(path, save); 
        }

    }
}
