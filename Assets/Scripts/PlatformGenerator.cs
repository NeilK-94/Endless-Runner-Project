using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;

    private int platformSelector;
    private float[] platformWidths;


    public ObjectPooler[] theObjectPools;


    // Use this for initialization
    void Start () {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;   //  get width of platform
        platformWidths = new float[theObjectPools.Length];
        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i]  = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;  //  at the width of element 0...
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x)  //  if where we are right nw is more left than generation point
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length); //  length = amount of objects in array... select random platform in array

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] /2) + distanceBetween, transform.position.y, transform.position.z);


           // Instantiate(/*thePlatform*/thePlatforms[platformSelector], transform.position, transform.rotation);

            
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();    //  create new platform object = free object from list

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);    //  every object in list is inactive, must set active

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }
    }
}
