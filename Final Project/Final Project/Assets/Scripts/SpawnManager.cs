using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrephab;
    private float SpawnRange = 9.0f;
    private int score;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrephab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button pauseButton;

    private bool isGameOver = false;
    private bool isPaused = false;
    private float fallThreshold = -15f; // y position to trigger game over

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrephab, GenerateSpawnPosistion(),
        powerupPrephab.transform.rotation);

        // Score
        score = 0;
        UpdateScore(0);

        // Set Game Over UI elements to inactive initially
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);

        // Assign button listeners
        restartButton.onClick.AddListener(RestartGame);
        pauseButton.onClick.AddListener(TogglePause);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        // Check if the player falls off the platform (below fallThreshold)
        if (GameObject.Find("Player")?.transform.position.y < fallThreshold)
        {
            GameOver();
        }

        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0 && !isPaused)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrephab, GenerateSpawnPosistion(), powerupPrephab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrephab, GenerateSpawnPosistion(), enemyPrephab.transform.rotation);
        }

        UpdateScore(5);
    }

    private Vector3 GenerateSpawnPosistion()
    {
        float spawnPosX = Random.Range(-SpawnRange, SpawnRange);
        float spawnPosZ = Random.Range(-SpawnRange, SpawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over!";
        restartButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        Time.timeScale = 0; // Freeze the game when game over
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Unfreeze the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1; // Freeze time if paused, resume if unpaused
        pauseButton.GetComponentInChildren<Text>().text = isPaused ? "Resume" : "Pause";
    }
}
