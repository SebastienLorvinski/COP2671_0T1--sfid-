using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrephab;
    private float SpawnRange = 9.0f ;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrephab;



    // Start is called before the first frame update
    void Start()
    {

        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrephab, GenerateSpawnPosistion(),
        powerupPrephab.transform.rotation);

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
    }

    // Update is called once per frame


    private Vector3 GenerateSpawnPosistion()
    {
        float spawnPosX = Random.Range( -SpawnRange, SpawnRange);
        float spawnPosZ = Random.Range( -SpawnRange, SpawnRange);
       
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

}
