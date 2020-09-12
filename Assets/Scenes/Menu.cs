using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Menu : MonoBehaviour{

    public AudioSource buttonhit;
    public GameObject uvod;
    public GameObject informacie;
    public GameObject pauza;
    public GameObject restart;


    public void quitGame()
    {
        buttonhit.Play();
        Application.Quit();
        Debug.Log("Game is exiting with exit status 0");

    }
    public void restartGame()
    {
        buttonhit.Play();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
        uvod.SetActive(false);
        informacie.SetActive(false);
        pauza.SetActive(true);
        restart.SetActive(false);


    }
    public void startGame()
    {
        buttonhit.Play();
        //PlayerPrefs.DeleteAll();
        //SceneManager.LoadScene(0);
        uvod.SetActive(false);
        informacie.SetActive(false);
        pauza.SetActive(true);
        restart.SetActive(true);

    }
    public void showInfo()
    {
        buttonhit.Play();
        uvod.SetActive(true);
        pauza.SetActive(false);
        informacie.SetActive(true);
        restart.SetActive(false);

    }
    public void closeInfo()
    {
        buttonhit.Play();
        uvod.SetActive(true);
        informacie.SetActive(false);
        pauza.SetActive(false);
        restart.SetActive(false);

    }
    public void endGame()
    {
        buttonhit.Play();
        uvod.SetActive(true);
        informacie.SetActive(false);
        pauza.SetActive(false);
        restart.SetActive(false);

    }
}

