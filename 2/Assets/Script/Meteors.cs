using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors : MonoBehaviour
{
    float speed;

    private void Start()
    {
        speed = Random.Range(1.5f, 2.5f);
        float scale = Random.Range(3.0f, 5.0f);
        transform.localScale = new Vector3 (scale, scale, scale);
    }
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
        transform.Rotate(0, 0, 0.2f);
    }
}
