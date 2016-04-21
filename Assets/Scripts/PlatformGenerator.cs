﻿using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenhMin;
    public float distanceBetweenMax;

    public GameObject[] thePlatforms;

    private int platformSelector;

    //public ObjectPooler theObjectPool;


    // Use this for initialization
    void Start () {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;   //  get width of platform
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x)  //  if where we are right nw is more left than generation point
        {
            distanceBetween = Random.Range(distanceBetweenhMin, distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            platformSelector = Random.Range(0,thePlatforms.Length); //  length = amount of objects in array... select random platform in array

            Instantiate(/*thePlatform*/thePlatforms[platformSelector], transform.position, transform.rotation);

            /*
            GameObject newPlatform = theObjectPool.GetPooledObject();    //  create new platform object = free object from list
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);    //  every object in list is inactive, must set active
       */
        }
	}
}
