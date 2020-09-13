using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Menu : MonoBehaviour{

    public AudioSource buttonHit;
    public GameObject menuScreen;
    public GameObject infoScreen;
    public GameObject pauseButton;
    public GameObject restartButton;


    public void quitGameButton()
    {
        buttonHit.Play();
        Application.Quit();
        Debug.Log("Game is exiting with exit code 0");

    }

    public void showInGameButtons() {
        pauseButton.SetActive(true);
        restartButton.SetActive(true);
    }

    public void hideInGameButtons()
    {
        pauseButton.SetActive(false);
        restartButton.SetActive(false);
    }

    public void showMenuScreen() {
        buttonHit.Play();
        hideInGameButtons();
        menuScreen.SetActive(true);
        infoScreen.SetActive(false);
    }

    public void closeMenuScreen() {
        showGameScreen();
    }

    public void showInfoScreen() {
        buttonHit.Play();
        hideInGameButtons();
        menuScreen.SetActive(true);
        infoScreen.SetActive(true);
    }

    public void closeInfoScreen()
    {
        showMenuScreen();
    }

    public void restartGame()
    {
        buttonHit.Play();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
        showGameScreen();

    }

    public void showGameScreen() {
        buttonHit.Play();
        showInGameButtons();
        menuScreen.SetActive(false);
        infoScreen.SetActive(false);

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

    public void continueGame() {

        showGameScreen();
    }
}

