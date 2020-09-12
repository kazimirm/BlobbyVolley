using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Restart : MonoBehaviour{

    public AudioSource buttonhit;
    public GameObject uvod;
    public GameObject informacie;
    public GameObject pauza;
    public GameObject restart;


    public void QuitGame()
    {
        buttonhit.Play();
        Application.Quit();
        Debug.Log("Game is exiting");

    }
    public void RestartGame()
    {
        buttonhit.Play();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
        uvod.SetActive(false);
        informacie.SetActive(false);
        pauza.SetActive(true);
        restart.SetActive(false);


    }
    public void StarttGame()
    {
        buttonhit.Play();
        //PlayerPrefs.DeleteAll();
        //SceneManager.LoadScene(0);
        uvod.SetActive(false);
        informacie.SetActive(false);
        pauza.SetActive(true);
        restart.SetActive(true);

    }
    public void info()
    {
        buttonhit.Play();
        uvod.SetActive(true);
        pauza.SetActive(false);
        informacie.SetActive(true);
        restart.SetActive(false);

    }
    public void ZavriVysvetlivky()
    {
        buttonhit.Play();
        uvod.SetActive(true);
        informacie.SetActive(false);
        pauza.SetActive(false);
        restart.SetActive(false);

    }
    public void koniechry()
    {
        buttonhit.Play();
        uvod.SetActive(true);
        informacie.SetActive(false);
        pauza.SetActive(false);
        restart.SetActive(false);

    }
}

