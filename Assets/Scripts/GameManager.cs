using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    //public Material materialToFade;
    
    public bool gameIsPaused;

    private BalloonSpawner bSpawner;
    private UIManager uiManager;
    private InputController inputController;
    private AudioManager audioManager;

    //public float fadeDuration = 5f;
    //public float targetAlpha = 1f;
    
    public int blueCount = 0;
    public int redCount = 0;
    public int blackCount = 0;
    [SerializeField] public float score = 0;

    void Start()
    {
        bSpawner = FindObjectOfType<BalloonSpawner>();
        uiManager = FindObjectOfType<UIManager>();
        inputController = FindObjectOfType<InputController>();
        audioManager = FindObjectOfType<AudioManager>();
        bSpawner.SpawnBalloons();
        Time.timeScale = 1;
    }

    void Update()
    {
        inputController.CheckInputs();
        if (score < 0)
        {
            LoseGame();
        }
        if (score >= 50)
        {
            WinGame();
        }
        
    }
    void WinGame()
    {
        audioManager.PlayWinAudio();
        uiManager.WinUI();
        gameIsPaused = true;
    }
    void LoseGame()
    {
        audioManager.PlayFailAudio();
        uiManager.LoseUI();
        gameIsPaused = true;
    }
    public void PauseGame()
    {
        uiManager.PauseUI();
        gameIsPaused = true;
    }
    public void ResumeGame()
    {
        uiManager.ResumeUI();
        gameIsPaused = false;
    }
    public void RestartGame()
    {
        audioManager.RestartSoundtrack();
        gameIsPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void RestartLevel()
    {
        gameIsPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReturnToMenu()
    {
        uiManager.ReturnToMenuUI();
        gameIsPaused = true;
        SceneManager.LoadScene(0);
    }
    public void LevelUp()
    {
        SceneManager.LoadScene(2);
    }

}
