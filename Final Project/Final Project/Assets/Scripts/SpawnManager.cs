using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrephab;
    private float SpawnRange = 9.0f ;
    private int score;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrephab;
    public TextMeshProUGUI scoreText;





    // Start is called before the first frame update
    void Start()
    {

        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrephab, GenerateSpawnPosistion(),
        powerupPrephab.transform.rotation);

        //Score
        score = 0;
        UpdateScore(0);

    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++; SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrephab, GenerateSpawnPosistion(),
            powerupPrephab.transform.rotation);
        }
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0;i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrephab,GenerateSpawnPosistion(),enemyPrephab.transform.rotation);
        }

        UpdateScore(5);
    }

    // Update is called once per frame


    private Vector3 GenerateSpawnPosistion()
    {
        float spawnPosX = Random.Range( -SpawnRange, SpawnRange);
        float spawnPosZ = Random.Range( -SpawnRange, SpawnRange);
       
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }


}
