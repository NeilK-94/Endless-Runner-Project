using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObject;
    public int pooledAmount;

    List<GameObject> pooledObjects;

    // Use this for initialization
    void Start () {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject); //  cast into gameobject
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
	}
	
	public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)   //  count how long pooled object list is
        {
            if (!pooledObjects[i].activeInHierarchy) //  if object found in list is active...
            {
                return pooledObjects[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject); //  cast into gameobject
        obj.SetActive(false);
        pooledObjects.Add(obj);

        return obj;
    }
}
