using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>(); //  search on player object for rigidbody2d
	}
	
	// Update is called once per frame
	void Update () {
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y); // movespeed bnut not jumpforce

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))   //  if any input (space key) do this 
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);  //  opposite to above

        }
    }
}
