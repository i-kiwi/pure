using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabFactory : MonoBehaviour
{
    public const string PREFAB = "Prefab/";

    public static Dictionary<string, GameObject> store;
    public static GameObject GetGameObject(string name)
    {
        if (store == null)
            store = new Dictionary<string, GameObject>();
        if (store.ContainsKey(name))
            return store[name];
        else
        {
            GameObject _object = Resources.Load<GameObject>(name);
            return _object;
        }
    }

    public static void SetGameObject(string name, GameObject gameObject)
    {
        if (!store.ContainsKey(name))
            store.Add(name, gameObject);
    }

}
