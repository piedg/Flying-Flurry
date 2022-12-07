using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefabObj;
    public List<GameObject> instanceObj;
    public int initialInstance = 100;

    private void Start()
    {
        instanceObj = new List<GameObject>();
        GameObject tmpObj;
        for (int i = 0; i < initialInstance; i++)
        {
            InstantiateObject(out tmpObj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < instanceObj.Count; i++)
        {
            if (instanceObj[i].activeInHierarchy) { continue; }
            return instanceObj[i];
        }
        GameObject newObj;
        InstantiateObject(out newObj);
        return newObj;
    }

    protected virtual void InstantiateObject(out GameObject obj)
    {
        obj = Instantiate(prefabObj, transform);
        obj.SetActive(false);
        instanceObj.Add(obj);
    }
}
