using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public PlayerController thePlayer;

    private Vector3 lastPlayerPosition; //  used to find player position
    private float distanceToMove;   //  how much to move camera

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();   //  keep camera on player
        lastPlayerPosition = thePlayer.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x; //  distance to move = current position - last position

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);    //  distance camera has to move 

        lastPlayerPosition = thePlayer.transform.position;  //  last player position is now current position
	}
}
