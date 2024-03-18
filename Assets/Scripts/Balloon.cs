using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balloon : MonoBehaviour
{
    
    public float wobbleAmount = 0.5f; 
    public float wobbleSpeed = 2f;
    public float forwardSpeed;
    private float originalX;
    public float balloonScore = 5f;
    private Camera mainCamera;
    private GameManager gameManager;
    private UIManager uiManager;

    public float minForwardSpeed = 1f;
    public float maxForwardSpeed = 3f;
    


    void Start()
    {
        originalX = transform.position.x;
        forwardSpeed = Random.Range(minForwardSpeed, maxForwardSpeed);
        mainCamera = Camera.main;
        gameManager = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        float wobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;
        transform.position = new Vector3(originalX + wobble, transform.position.y, transform.position.z);
        transform.Translate(Vector3.up * forwardSpeed * Time.deltaTime);

        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the object is outside the viewport bounds
        if (viewportPosition.x < 0 || viewportPosition.x > 1 ||
            viewportPosition.y < 0 || viewportPosition.y > 1 ||
            viewportPosition.z < 0)
        {
            if (gameObject.CompareTag("blueBalloon") || gameObject.CompareTag("redBalloon"))
            {
                gameManager.score -= 1;
                uiManager.UpdateScoreText();
            }
            // Object is outside the camera's view
            Destroy(gameObject);
        }
    }
    
}
