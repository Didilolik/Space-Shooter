using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    private string id = "4198179";

    public bool testMode = false;

    private static Ads ads;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if(ads == null)
        {
            ads = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Advertisement.Initialize(id, testMode);
    }
    public static IEnumerator showAds()
    {
        while(!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Show("Interstitial_Android");
    }
}
