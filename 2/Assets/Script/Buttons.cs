using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private Player player;

    public int direction;
   
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        player.direction = direction;
    }
    private void OnMouseUp()
    {
        player.direction = 0;
    }
}
