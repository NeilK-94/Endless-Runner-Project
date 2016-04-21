using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    public bool grounded;
    public LayerMask whatIsGround;   //  selection of layers available

    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;

    private Animator myAnimator;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>(); //  search on player object for rigidbody2d
        myCollider = GetComponent<Collider2D>();    //  search on player object, and find collider attached
        myAnimator = GetComponent<Animator>();  //  same concept as above

        jumpTimeCounter = jumpTime;
    }
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);    //  if player collider si touchng another collider(ground)
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y); // movespeed bnut not jumpforce

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))   //  if any input (space key) do this 
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);  //  opposite to above
            }   //  close inner if
        }   //  close outer if

        if(Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;  //  jump time counter always ticking down
            }
        }

        if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0))    //  prevents constant jumping glitch
        {
            jumpTimeCounter = 0;
        }

        if (grounded)   //  reset value of jumptimecounter
        {
            jumpTimeCounter = jumpTime;
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);   //  speed for animator
        myAnimator.SetBool("Grounded", grounded);

    }
}
