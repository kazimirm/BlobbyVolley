using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public GameObject Ball1;
    public GameObject Ball2;
    public GameObject ball1;
    public GameObject ball2;

    public int pocitadloLeft, pocitadloRight;

    Vector3 originalPosLeft;
    Vector3 originalPosRight;

    // Use this for initialization
    void Start () {
        pocitadloLeft = 0;
        pocitadloRight = 0;
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    public void OnTriggerEnter2D(Collider2D col)
    { 
        //Pad lopty na stranu laveho hraca
        if (col.tag == "podlahaLeft")
        {

            FindObjectOfType<GameManager>().player1fault();
            Ball1 = Resources.Load("Ball1") as GameObject;
            Ball2 = Resources.Load("Ball2") as GameObject;
            Destroy(GameObject.Find("Ball1(Clone)"));
            Destroy(GameObject.Find("Ball2(Clone)"));
            ball2 = Instantiate(Ball2) as GameObject;
            Debug.Log("Player1 looses point");
            pocitadloLeft = 0;
            pocitadloRight = 0;

        }

        //Pad lopty na stranu praveho hraca
        if (col.tag == "podlahaRight")
        {

            FindObjectOfType<GameManager>().player2fault();
            Ball1 = Resources.Load("Ball1") as GameObject;
            Ball2 = Resources.Load("Ball2") as GameObject;
            Destroy(GameObject.Find("Ball1(Clone)"));
            Destroy(GameObject.Find("Ball2(Clone)"));
            ball1 = Instantiate(Ball1)as GameObject;
            Debug.Log("Player2 looses point");
            pocitadloLeft = 0;
            pocitadloRight = 0;

        }

        {
            //pocitadlo odbiti praveho hraca
            if (col.tag == "BlobbyRight")
            {
                if (pocitadloRight >= 3)
                {

                    FindObjectOfType<GameManager>().player2fault();
                    Ball1 = Resources.Load("Ball1") as GameObject;
                    Ball2 = Resources.Load("Ball2") as GameObject;
                    Destroy(GameObject.Find("Ball1(Clone)"));
                    Destroy(GameObject.Find("Ball2(Clone)"));
                    ball1 = Instantiate(Ball1) as GameObject;
                    Debug.Log("Player2 looses point");
                    pocitadloLeft = 0;
                    pocitadloRight = 0;

                }
                pocitadloRight += 1;
                pocitadloLeft = 0;
                
            }

            //pocitadlo odbiti laveho hraca
            if (col.tag == "BlobbyLeft")
            {
                if (pocitadloLeft >= 3)
                {

                    FindObjectOfType<GameManager>().player1fault();
                    Ball1 = Resources.Load("Ball1") as GameObject;
                    Ball2 = Resources.Load("Ball2") as GameObject;
                    Destroy(GameObject.Find("Ball1(Clone)"));
                    Destroy(GameObject.Find("Ball2(Clone)"));
                    ball2 = Instantiate(Ball2) as GameObject;
                    Debug.Log("Player1 looses point");
                    pocitadloLeft = 0;
                    pocitadloRight = 0;

                }
                pocitadloLeft += 1;
                pocitadloRight = 0;

            }
        }
    }
}
 

    

