using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public const int MAX_HITS = 3;
    public int counterLeft, counterRight;

    /* 
     * Initialization method which is called on start
     */
    void Start()
    {
        counterLeft = 0;
        counterRight = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /* 
     * Handles all the collisions between ball - players and ground
     */
    public void OnTriggerEnter2D(Collider2D col)
    {
        /*
         * Ball1 is Ball object that has init spawn value on left side (for player 1),
         * analogically Ball2 is Ball spawned on right.
         */
        GameObject Ball1 = Resources.Load("Ball1") as GameObject;
        GameObject Ball2 = Resources.Load("Ball2") as GameObject;
        
        //Ball collision with ground on the left side (player1's fault)
        if (col.tag == "GroundLeft")
        {

            FindObjectOfType<GameManager>().player1fault();
            Destroy(GameObject.Find("Ball1(Clone)"));
            Destroy(GameObject.Find("Ball2(Clone)"));
            GameObject ball2 = Instantiate(Ball2) as GameObject;
            Debug.Log("Player1 looses a point after ground hit");
            counterLeft = 0;
            counterRight = 0;

        }

        //Ball collision with ground on the right side (player2's fault)
        if (col.tag == "GroundRight")
        {

            FindObjectOfType<GameManager>().player2fault();
            Destroy(GameObject.Find("Ball1(Clone)"));
            Destroy(GameObject.Find("Ball2(Clone)"));
            GameObject ball1 = Instantiate(Ball1) as GameObject;
            Debug.Log("Player2 looses a point after ground hit");
            counterLeft = 0;
            counterRight = 0;

        }

        {
            //Hit counter for right player (player 2)
            if (col.tag == "BlobbyRight")
            {
                if (counterRight >= MAX_HITS)
                {

                    FindObjectOfType<GameManager>().player2fault();
                    Destroy(GameObject.Find("Ball1(Clone)"));
                    Destroy(GameObject.Find("Ball2(Clone)"));
                    GameObject ball1 = Instantiate(Ball1) as GameObject;
                    Debug.Log("Player2 looses a point");
                    counterLeft = 0;
                    counterRight = 0;

                }
                counterRight++;
                counterLeft = 0;

            }

            //Hit counter for left player (player 1)
            if (col.tag == "BlobbyLeft")
            {
                if (counterLeft >= MAX_HITS)
                {

                    FindObjectOfType<GameManager>().player1fault();
                    Destroy(GameObject.Find("Ball1(Clone)"));
                    Destroy(GameObject.Find("Ball2(Clone)"));
                    GameObject ball2 = Instantiate(Ball2) as GameObject;
                    Debug.Log("Player1 looses point");
                    counterLeft = 0;
                    counterRight = 0;

                }
                counterLeft++;
                counterRight = 0;

            }
        }
    }
}




