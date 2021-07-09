using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    float speed;
    void Start()
    {
        speed = Random.Range(1.5f, 3.0f);
    }
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }
}
