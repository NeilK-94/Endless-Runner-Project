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

    private float minHeight;
    private float maxHeight;
    public Transform maxHeightPoint;
    public float maxHeightChange;
    private float heightChange;


    // Use this for initialization
    void Start () {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;   //  get width of platform
        platformWidths = new float[theObjectPools.Length];
        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i]  = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;  //  at the width of element 0...
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x)  //  if where we are right nw is more left than generation point
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax); //  distance between is a value between minimum distance and maximum

            platformSelector = Random.Range(0, theObjectPools.Length); //  length = amount of objects in array... select random platform in array

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)   //  assures platforms stay within range ive set up. cant go off screen
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] /2) + distanceBetween, heightChange, transform.position.z);


           // Instantiate(/*thePlatform*/thePlatforms[platformSelector], transform.position, transform.rotation);

            
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();    //  create new platform object = free object from list

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);    //  every object in list is inactive, must set active

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }
    }
}
