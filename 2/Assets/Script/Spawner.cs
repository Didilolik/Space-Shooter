using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Sprite> meteors, enemies, stars;

    public GameObject star, enemy, meteor;

    public Transform borderLeft, borderRight;

    void Start()
    {
        StartCoroutine(Spawn(star, stars, 10f, 1.0f, 4.0f, 0));
        StartCoroutine(Spawn(meteor, meteors, 10f, 1.0f, 4.0f, 0));
        StartCoroutine(Spawn(enemy, enemies, 1000F, 2.0f, 2.0f, -180f));
    }
    void Update()
    {
        
    }
    private IEnumerator Spawn(GameObject obj, List<Sprite> list, float lifeTime, float minRate, float maxRate, float zAngle)
    {
        while (true)
        {
            obj.GetComponent<SpriteRenderer>().sprite = list[Random.Range(0, list.Count)];
            Vector3 rand_pos = new Vector3(Random.Range(borderLeft.position.x, borderRight.position.x), transform.position.y, 2);
            GameObject curObj = Instantiate(obj, rand_pos, Quaternion.Euler(0,0,zAngle));
            Destroy(curObj, lifeTime);
            yield return new WaitForSeconds(Random.Range(minRate, maxRate));
        }
    } 
}
