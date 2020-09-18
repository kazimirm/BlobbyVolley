using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {


    public static GameManager gameManager;

    public GameObject player1;
    public GameObject player2;

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

    private string LEFT_BRACKET = "[";
    private string RIGHT_BRACKET = "]";
    private static string CONFIG = "config";
    private Dictionary<string, string> keyCodes;


    // Use this for initialization
    void Start () {

        player1Wins.SetActive(false);
        player2Wins.SetActive(false);

        blobbyRight = GameObject.FindGameObjectWithTag("BlobbyRight");
        blobbyLeft = GameObject.FindGameObjectWithTag("BlobbyLeft");

        keyCodes = new Dictionary<string, string>();
        bool configOK = ParseInputConfig(CONFIG);

        if (configOK) {
            string key;
            keyCodes.TryGetValue("player2LeftControlButton", out key);
            blobbyRight.GetComponent<Blobby>().left = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);
            keyCodes.TryGetValue("player2JumpControlButton", out key);
            blobbyRight.GetComponent<Blobby>().jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);
            keyCodes.TryGetValue("player2RightControlButton", out key);
            blobbyRight.GetComponent<Blobby>().right = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);

            keyCodes.TryGetValue("player1LeftControlButton", out key);
            blobbyLeft.GetComponent<Blobby>().left = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);
            keyCodes.TryGetValue("player1JumpControlButton", out key);
            blobbyLeft.GetComponent<Blobby>().jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);
            keyCodes.TryGetValue("player1RightControlButton", out key);
            blobbyLeft.GetComponent<Blobby>().right = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);


        }
        //blobbyRight.GetComponent<Blobby>().left = (KeyCode)System.Enum.Parse(typeof(KeyCode), GetLine("player2LeftControlButton"));
        //blobbyRight.GetComponent<Blobby>().jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), GetLine("player2JumpControlButton"));
        //blobbyRight.GetComponent<Blobby>().right = (KeyCode)System.Enum.Parse(typeof(KeyCode), GetLine("player2RightControlButton"));

        //blobbyLeft.GetComponent<Blobby>().left = (KeyCode)System.Enum.Parse(typeof(KeyCode), GetLine("player1LeftControlButton"));
        //blobbyLeft.GetComponent<Blobby>().jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), GetLine("player1JumpControlButton"));
        //blobbyLeft.GetComponent<Blobby>().right = (KeyCode)System.Enum.Parse(typeof(KeyCode), GetLine("player1RightControlButton"));

        blobbyRight.GetComponent<SpriteRenderer>().color = blobbyRightColor;
        blobbyLeft.GetComponent<SpriteRenderer>().color = blobbyLeftColor;
        
    }

    public string[] GetLines(string id)
    {
        Debug.Log("ID of line: " + id);
        ArrayList lines = new ArrayList();
        string line;
        TextAsset textFile = (TextAsset)Resources.Load(CONFIG, typeof(TextAsset));
        System.IO.StringReader textStream = new System.IO.StringReader(textFile.text);
        string lineID = LEFT_BRACKET + id + RIGHT_BRACKET;
        bool match = false;

        while ((line = textStream.ReadLine()) != null)
        {
            if (match)
            {
                if (line.StartsWith(LEFT_BRACKET))
                {
                    break;
                }
                if (line.Length > 0)
                {
                    Debug.Log("Reading config line: " + line);
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
        else 
        {
            Debug.LogWarning("Line ID: " + LEFT_BRACKET + id + RIGHT_BRACKET + "could not be found. Make sure the config file is correct.");
            return null;
        }
    }

    public string GetLine(string id)
    {
        string[] lines = GetLines(id);

        if (lines == null)
        {
            return string.Empty;
        }
        else
        {
            return GetLines(id)[0];
        }
    }

    public bool ParseInputConfig(string configName)
    {
        Debug.Log("Parse of config: " + configName + "started.");
        TextAsset textFile = (TextAsset)Resources.Load(configName, typeof(TextAsset));
        System.IO.StringReader textStream = new System.IO.StringReader(textFile.text);
        string line;

        while ((line = textStream.ReadLine()) != null)
        {

            if (line.StartsWith(LEFT_BRACKET))
            {
                string key = FindStringInBetween(line, LEFT_BRACKET, RIGHT_BRACKET);

                if ((line = textStream.ReadLine()) != null) 
                {
                    string value = line;
                    keyCodes.Add(key, value);
                }

            }
               
        }
        textStream.Close();

        int count = keyCodes.Count;

        if (count > 0) 
        {
            return true;
        }

        return false;
    }

    public string FindStringInBetween(string Text, string FirstString, string LastString)
    {
        string STR = Text;
        string STRFirst = FirstString;
        string STRLast = LastString;
        string FinalString;

        int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
        int Pos2 = STR.IndexOf(LastString);

        FinalString = STR.Substring(Pos1, Pos2 - Pos1);
        return FinalString;
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
