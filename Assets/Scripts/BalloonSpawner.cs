using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject redBalloon;
    public GameObject blueBalloon;
    public GameObject blackBalloon;

    private Camera mainCamera;
    public float minXViewport = 0.1f;
    public float maxXViewport = 0.9f;
    public float minYViewport = 0.1f;
    public float maxYViewport = 0.5f;
    public float spawnInterval = 1.0f;
    public float initialWaitTime = 2.0f;

    void Start()
    {
        
    }

    public void SpawnBalloons()
    {
        StartCoroutine(SpawnObjectsWithDelay());
        mainCamera = Camera.main;
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            spawnInterval = 0.5f;
        }
    }
    private IEnumerator SpawnObjectsWithDelay()
    {
        yield return new WaitForSeconds(initialWaitTime);
        while (true)
        {

            //materialToFade.DOFade(targetAlpha, fadeDuration);

            float randomXViewport_red = Random.Range(minXViewport, maxXViewport);
            float randomYViewport_red = Random.Range(minYViewport, maxYViewport);
            float randomZ = 10;
            // Convert viewport coordinates to world coordinates
            Vector3 randomPosition_red = mainCamera.ViewportToWorldPoint(new Vector3(randomXViewport_red, randomYViewport_red, randomZ));
            // Instantiate object at the random position
            Instantiate(redBalloon, randomPosition_red, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
            float randomXViewport_blue = Random.Range(minXViewport, maxXViewport);
            float randomYViewport_blue = Random.Range(minYViewport, maxYViewport);
            // Convert viewport coordinates to world coordinates
            Vector3 randomPosition_blue = mainCamera.ViewportToWorldPoint(new Vector3(randomXViewport_blue, randomYViewport_blue, randomZ));
            // Instantiate object at the random position
            Instantiate(blueBalloon, randomPosition_blue, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
            float randomXViewport_black = Random.Range(minXViewport, maxXViewport);
            float randomYViewport_black = Random.Range(minYViewport, maxYViewport);
            // Convert viewport coordinates to world coordinates
            Vector3 randomPosition_black = mainCamera.ViewportToWorldPoint(new Vector3(randomXViewport_black, randomYViewport_black, randomZ));
            // Instantiate object at the random position
            Instantiate(blackBalloon, randomPosition_black, Quaternion.identity);

            // Wait for the specified spawn interval before spawning the next object
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
