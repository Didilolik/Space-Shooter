using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "meteor")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "enemies")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
