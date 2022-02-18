using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyInfo
{
    public string name; //só pra que cada inimigo tenha um nome
    public GameObject prefab;
}

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private int enemyMaxSpawn = 3; // acho importante deixar no inspector alguns setups

    public EnemyInfo[] enemies;

    private float spawnRangeXMin = -7;
    private float spawnRangeXMax = 8;

    private float spawnRangeYMin = 7;
    private float spawnRangeYMax = 11;

    void Start()
    {
        InvokeRepeating("SpawningEnemy", 0f, 1.2f);
    }

    void Update()
    {
        
    }
 
    private void SpawningEnemy()
    {
        int enemyNumber = Random.Range(0, enemyMaxSpawn);

        for (int i = 0; i < enemyNumber; i++)
        {
            int enemy = Random.Range(0, enemies.Length);
            GameObject newEnemy = Instantiate(enemies[enemy].prefab, GenerateRandomPosition(), Quaternion.identity);
        }       
    }

    Vector3 GenerateRandomPosition()
    {
        float spawnPosX = Random.Range(spawnRangeXMin, spawnRangeXMax);
        float spawnPosY = Random.Range(spawnRangeYMin, spawnRangeYMax);
        Vector3 randomPos = new Vector2(spawnPosX, spawnPosY);

        return randomPos;
    }
}
