using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    public GameObject player1;
    public GameObject player2;

    Vector3 originalPos1;
    Vector3 originalPos2;

    public int Player1Life;
    public int Player2Life;

    public GameObject player1Wins;
    public GameObject player2Wins;

    public GameObject[] player1Lifes;
    public GameObject[] player2Lifes;

    public AudioSource whistleSound;
    public AudioSource win;
    public AudioSource smallapplaus;
    public AudioSource hit;

    public GameObject blobbyRight;
    public GameObject blobbyLeft;

    
    // Use this for initialization
    void Start () {
        player1Wins.SetActive(false);
        player2Wins.SetActive(false);
        blobbyRight = GameObject.FindGameObjectWithTag("BlobbyRight");
        blobbyLeft = GameObject.FindGameObjectWithTag("BlobbyLeft");

        blobbyRight.GetComponent<Blobby>().left = KeyCode.LeftArrow;
        blobbyRight.GetComponent<Blobby>().jump = KeyCode.UpArrow;
        blobbyRight.GetComponent<Blobby>().right = KeyCode.RightArrow;

        blobbyLeft.GetComponent<Blobby>().left = KeyCode.A;
        blobbyLeft.GetComponent<Blobby>().jump = KeyCode.W;
        blobbyLeft.GetComponent<Blobby>().right = KeyCode.D;
    }

    void Awake()
    {
        //Singleton pattern
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() {      
       
    }


    //Odobranie zivota Hracovi 1
    public void player1fault()
    {
        Player1Life -= 1;
        for (int i = 0; i < player1Lifes.Length; i++)
        {
            if ( Player1Life > i)
            {
                player1Lifes[i].SetActive(true);
            }
            else
            {
                player1Lifes[i].SetActive(false);
            }
            whistleSound.Play();
            smallapplaus.Play();
            hit.Play();

        }
        if (Player1Life <= 0)
        {
            win.Play();
            player1.SetActive(false);
            player2Wins.SetActive(true);
        }

    }
    //Odobranie zivota Hracovi 2
    public void player2fault()
    {
        Player2Life -= 1;
        for (int i = 0; i < player2Lifes.Length; i++)
        {
            if (Player2Life > i)
            {
                player2Lifes[i].SetActive(true);
            }
            else
            {
                player2Lifes[i].SetActive(false);
            }
        }
        if (Player2Life <= 0)
        {
            win.Play();
            player2.SetActive(false);
            player1Wins.SetActive(true);
        }
        whistleSound.Play();
        smallapplaus.Play();
        hit.Play();

    }

    void OnTriggerEnter(Collider col)
    {  
        //Ak padne lopta na stranu hraca 1, je to chyba hraca 1.
        player1fault();
        Debug.Log(gameObject.name + "bum");

        //Ak padne lopta na stranu hraca 2, je to chyba hraca 2.
        player2fault();
        Debug.Log(gameObject.name + "bum");     
    }
   
}
