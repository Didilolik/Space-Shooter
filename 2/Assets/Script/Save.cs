using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save
{
    public List <bool> bought = new List<bool>(){false,false,false,false,false, true};
    public List <bool> v = new List<bool>(){false,false,false,false,false, true};

    public string CreatePath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return Path.Combine(Application.persistentDataPath, "shop.json");
#else
        return Path.Combine(Application.dataPath, "shop.json");
#endif
    }

    public void SaveData(string path, Save save)
    {
        File.WriteAllText(path, JsonUtility.ToJson(save));
    }

}
