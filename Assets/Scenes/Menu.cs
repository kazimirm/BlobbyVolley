﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class Menu : MonoBehaviour
{

    public AudioSource buttonHit;
    public GameObject menuScreen;
    public GameObject infoScreen;
    public GameObject settingsScreen;
    public GameObject pauseButton;
    public GameObject restartButton;
    public GameObject player1Wins;
    public GameObject player2Wins;

    public GameObject player1LeftControlButton;
    public GameObject player1RightControlButton;
    public GameObject player1JumpControlButton;
    public GameObject player2LeftControlButton;
    public GameObject player2RightControlButton;
    public GameObject player2JumpControlButton;

    Event keyEvent;
    Text buttonText;
    KeyCode newKey;
    bool waitingForKey;



    // Use this for initialization
    void Start()
    {
        GameObject blobbyLeft = GameObject.FindGameObjectWithTag("BlobbyLeft");
        GameObject blobbyRight = GameObject.FindGameObjectWithTag("BlobbyRight");


        if (PlayerPrefs.HasKey(player1LeftControlButton.name))
        { blobbyLeft.GetComponent<Blobby>().left = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(player1LeftControlButton.name)); }
        if (PlayerPrefs.HasKey(player1JumpControlButton.name))
        { blobbyLeft.GetComponent<Blobby>().jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(player1JumpControlButton.name)); }
        if (PlayerPrefs.HasKey(player1RightControlButton.name))
        { blobbyLeft.GetComponent<Blobby>().right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(player1RightControlButton.name)); }

        if (PlayerPrefs.HasKey(player2LeftControlButton.name))
        { blobbyRight.GetComponent<Blobby>().left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(player2LeftControlButton.name)); }
        if (PlayerPrefs.HasKey(player2JumpControlButton.name))
        { blobbyRight.GetComponent<Blobby>().jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(player2JumpControlButton.name)); }
        if (PlayerPrefs.HasKey(player2RightControlButton.name))
        { blobbyRight.GetComponent<Blobby>().right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(player2RightControlButton.name)); }

    }

    public void quitGameButton()
    {
        buttonHit.Play();
        Application.Quit();
        Debug.Log("Game is exiting with exit code 0");

    }

    public void showInGameButtons()
    {
        pauseButton.SetActive(true);
        restartButton.SetActive(true);
    }

    public void hideInGameButtons()
    {
        pauseButton.SetActive(false);
        restartButton.SetActive(false);
    }

    public void showMenuScreen()
    {
        buttonHit.Play();
        hideInGameButtons();
        menuScreen.SetActive(true);
        infoScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }

    public void closeMenuScreen()
    {
        showGameScreen();
    }

    public void showInfoScreen()
    {
        buttonHit.Play();
        hideInGameButtons();
        menuScreen.SetActive(true);
        infoScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void closeInfoScreen()
    {
        showMenuScreen();
    }

    public void restartGame()
    {
        buttonHit.Play();
        //PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
        player1Wins.SetActive(false);
        player2Wins.SetActive(false);
        showGameScreen();


    }

    public void showGameScreen()
    {
        buttonHit.Play();
        showInGameButtons();
        menuScreen.SetActive(false);
        infoScreen.SetActive(false);
        settingsScreen.SetActive(false);

    }
    public void startGame()
    {
        showGameScreen();

    }

    public void pauseGame()
    {
        buttonHit.Play();
        showMenuScreen();

    }

    public void continueGame()
    {

        showGameScreen();
    }

    public void showSettings()
    {
        buttonHit.Play();
        hideInGameButtons();
        menuScreen.SetActive(true);
        infoScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void closeSettings()
    {

        buttonHit.Play();
        hideInGameButtons();
        menuScreen.SetActive(true);
        infoScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }

    void OnGUI()
    {
        /*keyEvent dictates what key our user presses
		 * bt using Event.current to detect the current
		 * event
		 */
        keyEvent = Event.current;

        //Executes if a button gets pressed and
        //the user presses a key
        if (keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode; //Assigns newKey to the key user presses
            waitingForKey = false;
        }
    }

    /*Buttons cannot call on Coroutines via OnClick().
	 * Instead, we have it call startAssignment, which will
	 * call a coroutine in this script instead, only if we
	 * are not already waiting for a key to be pressed.
	 */
    public void startAssignment(Button button)
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(button));
    }

    //Assigns buttonText to the text component of
    //the button that was pressed
    public void SendText(Text text)
    {
        buttonText = text;
    }

    //Used for controlling the flow of our below Coroutine
    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
            yield return null;
    }

    /*AssignKey takes a keyName as a parameter. The
	 * keyName is checked in a switch statement. Each
	 * case assigns the command that keyName represents
	 * to the new key that the user presses, which is grabbed
	 * in the OnGUI() function, above.
	 */
    public IEnumerator AssignKey(Button button)
    {
        string b = button.name;
        waitingForKey = true;

        yield return WaitForKey(); //Executes endlessly until user presses a key
        GameObject blobbyLeft = GameObject.FindGameObjectWithTag("BlobbyLeft");
        GameObject blobbyRight = GameObject.FindGameObjectWithTag("BlobbyRight");
      

        if (player1LeftControlButton.name == button.name) 
        {
            blobbyLeft.GetComponent<Blobby>().left = newKey;
            PlayerPrefs.SetString(player1LeftControlButton.name, newKey.ToString());
            GameObject.Find(b).GetComponentInChildren<Text>().text = newKey.ToString(); 
        }
        else if (player1JumpControlButton.name == button.name)
        {
            blobbyLeft.GetComponent<Blobby>().jump = newKey;
            PlayerPrefs.SetString(player1JumpControlButton.name, newKey.ToString());
            GameObject.Find(b).GetComponentInChildren<Text>().text = newKey.ToString();
        }
        else if(player1RightControlButton.name == button.name)
        {

            blobbyLeft.GetComponent<Blobby>().right = newKey;
            PlayerPrefs.SetString(player1RightControlButton.name, newKey.ToString());
            GameObject.Find(b).GetComponentInChildren<Text>().text = newKey.ToString();
        }
        else if(player2LeftControlButton.name == button.name)
        {
            blobbyRight.GetComponent<Blobby>().left = newKey;
            PlayerPrefs.SetString(player2LeftControlButton.name, newKey.ToString());
            GameObject.Find(b).GetComponentInChildren<Text>().text = newKey.ToString();
        }
        else if(player2JumpControlButton.name == button.name)
        {
            blobbyRight.GetComponent<Blobby>().jump = newKey;
            PlayerPrefs.SetString(player2JumpControlButton.name, newKey.ToString());
            GameObject.Find(b).GetComponentInChildren<Text>().text = newKey.ToString();
        }
        else if(player2RightControlButton.name == button.name)
        {
            blobbyRight.GetComponent<Blobby>().right = newKey;
            PlayerPrefs.SetString(player2RightControlButton.name, newKey.ToString());
            GameObject.Find(b).GetComponentInChildren<Text>().text = newKey.ToString();
        }

        yield return null;
    }
}