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

    public Color blobbyRightColor = Color.blue;
    public Color blobbyLeftColor = Color.red;


    // Use this for initialization
    void Start () {
        player1Wins.SetActive(false);
        player2Wins.SetActive(false);

        blobbyRight = GameObject.FindGameObjectWithTag("BlobbyRight");
        blobbyLeft = GameObject.FindGameObjectWithTag("BlobbyLeft");

        blobbyRight.GetComponent<Blobby>().left = (KeyCode)System.Enum.Parse(typeof(KeyCode), GetLine("player2LeftControlButton"));
        blobbyRight.GetComponent<Blobby>().jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), GetLine("player2JumpControlButton"));
        blobbyRight.GetComponent<Blobby>().right = (KeyCode)System.Enum.Parse(typeof(KeyCode), GetLine("player2RightControlButton"));
        blobbyRight.GetComponent<SpriteRenderer>().color = blobbyRightColor;

        blobbyLeft.GetComponent<Blobby>().left = (KeyCode)System.Enum.Parse(typeof(KeyCode), GetLine("player1LeftControlButton"));
        blobbyLeft.GetComponent<Blobby>().jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), GetLine("player1JumpControlButton"));
        blobbyLeft.GetComponent<Blobby>().right = (KeyCode)System.Enum.Parse(typeof(KeyCode), GetLine("player1RightControlButton"));
        blobbyLeft.GetComponent<SpriteRenderer>().color = blobbyLeftColor;
        
    }

    public string[] GetLines(string id)
    {
        Debug.Log("ID of line: " + id);
        ArrayList lines = new ArrayList();
        string line;
        TextAsset textFile = (TextAsset)Resources.Load("English", typeof(TextAsset));
        System.IO.StringReader textStream = new System.IO.StringReader(textFile.text);
        string lineID = "[" + id + "]";
        bool match = false;
        while ((line = textStream.ReadLine()) != null)
        {
            if (match)
            {
                if (line.StartsWith("["))
                {
                    break;
                }
                if (line.Length > 0)
                {
                    Debug.Log("Read line: " + line);
                    lines.Add(line);
                }
            }
            else if (line.StartsWith(lineID))
            {
                match = true;
            }
        }
        textStream.Close();
        if (lines.Count > 0)
        {
            return (string[])lines.ToArray(typeof(string));
        }
        return new string[0];
    }

    public string GetLine(string id)
    {
        return GetLines(id)[0];
    }

    void Awake()
    {
      
    }

    // Update is called once per frame
    void Update() {      
       
    }


    //Method for taking a player's 1 life
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
            Debug.Log("Player2 wins");
        }

    }
    //Method for taking a player's 2 life
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
            Debug.Log("Player1 wins");
        }
        whistleSound.Play();
        smallapplaus.Play();
        hit.Play();

    }

}
