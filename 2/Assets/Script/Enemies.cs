using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour, IGun
{
    private Vector3 target;

    public GameObject laserR;

    public Transform gunEnemies;

    public AudioClip hitSound;

    private AudioSource audioSource; 

    void Start()
    {
        target = RandomTarget();
        StartCoroutine(MachineGun(laserR));
        audioSource = GameObject.Find("ShotMusic").GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 3f * Time.deltaTime);

        if (transform.position == target)
        {
            target = RandomTarget();
        }
    }
    private Vector3 RandomTarget()
    {
        Vector3 randPos = new Vector3();
        randPos.x = Random.Range(-3f, 3f);
        randPos.y = Random.Range(0f, 5f);
        randPos.z = transform.position.z;
        return randPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "laserPlayer")
        {
            audioSource.PlayOneShot(hitSound);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
    public IEnumerator MachineGun(GameObject laser)
    {
        while (true)
        {
            GameObject ray = Instantiate(laser, gunEnemies.position, Quaternion.Euler(0,0,-180f));
            Destroy(ray, 5f);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
