using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "meteor")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().health -= 0.5f;
            Destroy(gameObject);
        }
    }
}
