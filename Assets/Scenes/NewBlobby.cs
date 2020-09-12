using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBlobby : MonoBehaviour {
    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    public AudioSource BlopSound;

    // Use this for initialization
    void Start () {
        theRB = GetComponent<Rigidbody2D>();

	}

    /* 
     * Update is called once per frame
     * Players movement is handled here
     * 
     */
    void Update() {
        
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKey(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
    }

    //Sound effect of hitting the ball when collision with player occurs
    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Ball2" || col.tag == "Ball1")
        {
            BlopSound.Play();
        }
    }
}
