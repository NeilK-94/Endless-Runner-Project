using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler coinPool;

    public float distanceBetweeCoins;

	public void SpawnCoins(Vector3 startPosition)   //  create coin, set position then activate
    {
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPooledObject();
        coin2.transform.position = new Vector3(startPosition.x - distanceBetweeCoins, startPosition.y, startPosition.z);    //  different position to coin 1. Left side
        coin2.SetActive(true);

        GameObject coin3 = coinPool.GetPooledObject();
        coin3.transform.position = new Vector3(startPosition.x - distanceBetweeCoins, startPosition.y, startPosition.z);    //  different position to coin 1
        coin3.SetActive(true);

    }
}
