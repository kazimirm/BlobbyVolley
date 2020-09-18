using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blobby : MonoBehaviour {
    //public static Logger LOGGER;
    public float moveSpeed = 5;
    public float jumpForce = 17;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.2F;
    public LayerMask whatIsGround;
    
    public bool isGrounded;

    public AudioSource BlopSound;

    // Use this for initialization
    void Start() 
    {
        theRB = GetComponent<Rigidbody2D>();
	}

    /* 
     * Update is called once per frame
     * Players movement is handled here
     * 
     */
    void Update() 
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        if (Time.timeScale != 0)
        {
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
    }

    //Sound effect of hitting the ball when collision with player occurs
    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Ball1" || col.tag == "Ball2")
        {
            BlopSound.Play();
        }
    }

    public void setLeft(KeyCode left) {
        this.left = left;
    }

    public void setRight(KeyCode right)
    {
        this.right = right;
    }

    public void setJump(KeyCode jump)
    {
        this.jump = jump;
    }
}
