using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

    public GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint"); //  find object that has name platform destruction point

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < platformDestructionPoint.transform.position.x)   //  if platform position is less than platform destructions x posisiotn
        {
            Destroy (gameObject);
        }
	}
}
