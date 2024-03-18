using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private GameManager gameManager;
    private UIManager uiManager;
    private AudioManager audioManager;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameManager.gameIsPaused)
            {
                gameManager.ResumeGame();
            }
            else
            {
                gameManager.PauseGame();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Check if the ray hits any object
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("redBalloon") || hit.collider.CompareTag("blueBalloon") || hit.collider.CompareTag("blackBalloon"))
                {
                    audioManager.popEffect.Play();
                    Destroy(hit.collider.gameObject);
                    if (hit.collider.CompareTag("redBalloon"))
                    {
                        gameManager.score += 5f;
                        gameManager.redCount++;
                    }
                    else if (hit.collider.CompareTag("blueBalloon"))
                    {
                        gameManager.score += 2f;
                        gameManager.blueCount++;
                    }
                    else if (hit.collider.CompareTag("blackBalloon"))
                    {
                        gameManager.score -= 3f;
                        gameManager.blackCount++;
                    }
                    uiManager.UpdateScoreText();
                }
            }
        }
    }
}
