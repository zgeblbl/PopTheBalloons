using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject instructionUI;
    public GameObject menuUI;


    void Start()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void CloseInstructions()
    {
        instructionUI.SetActive(false);
        menuUI.SetActive(true);
    }
    public void OpenInstructions()
    {
        menuUI.SetActive(false);
        instructionUI.SetActive(true);
    }

}
