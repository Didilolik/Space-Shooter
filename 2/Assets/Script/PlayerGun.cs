using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour, IGun
{
    public GameObject laserY;

    void Start()
    {
        StartCoroutine(MachineGun(laserY));
    }
    public IEnumerator MachineGun(GameObject laser)
    {
        while (true)
        {
            GameObject ray = Instantiate(laser, transform.position, Quaternion.identity);
            Destroy(ray, 3f);
            yield return new WaitForSeconds(1f);
        }
    }
}
