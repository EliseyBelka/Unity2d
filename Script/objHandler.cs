using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class objHandler
{
    public static Dictionary<string, GameObject> objRefs = new Dictionary<string, GameObject>();

    public static void AddReference(string name, GameObject obj)
    {
        if (!objRefs.ContainsKey(name))
            objRefs.Add(name, obj);
    }

}

