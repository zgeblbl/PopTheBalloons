using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject winUI;
    public GameObject loseUI;
    public GameObject pauseUI;
    public GameObject inGameUI;
    public GameObject lvlUpUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI blueHits;
    public TextMeshProUGUI redHits;
    public TextMeshProUGUI blackHits;
    private GameManager gManager;

    void Start()
    {
        gManager = FindObjectOfType<GameManager>();
    }
    public void LoseUI()
    {
        Time.timeScale = 0;
        inGameUI.SetActive(false);
        loseUI.SetActive(true);
        finalScoreText.text = "FINAL SCORE: " + gManager.score;
        blueHits.text = "blue hits: " + gManager.blueCount;
        redHits.text = "red hits: " + gManager.redCount;
        blackHits.text = "black hits: " + gManager.blackCount;
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + gManager.score;
    }
    public void WinUI()
    {
        Time.timeScale = 0;
        inGameUI.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            winUI.SetActive(true);
        }
        else
        {
            lvlUpUI.SetActive(true);
        }
        finalScoreText.text = "FINAL SCORE: " + gManager.score;
        blueHits.text = "blue hits: " + gManager.blueCount;
        redHits.text = "red hits: " + gManager.redCount;
        blackHits.text = "black hits: " + gManager.blackCount;
    }
    public void PauseUI()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeUI()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }public void ReturnToMenuUI()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 0;
    }
}
