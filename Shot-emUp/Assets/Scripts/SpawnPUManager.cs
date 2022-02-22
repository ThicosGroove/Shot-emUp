using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPUManager : MonoBehaviour
{
    [SerializeField] private float spawPowerUpRate = 10f;

    public GameObject[] powerUpPrefab;

    private float spawnRangeXMin = -7;
    private float spawnRangeXMax = 7;

    private float spawnRangeYMin = -3;
    private float spawnRangeYMax = 0.5f;

    void Start()
    {
        InvokeRepeating("SpawnPU", 5f, spawPowerUpRate);
    }

    void SpawnPU()
    {
        int powerUp = Random.Range(0, powerUpPrefab.Length);
        GameObject newPowerUP = Instantiate(powerUpPrefab[powerUp], GenerateRandomPosition(), Quaternion.identity);
    }


    Vector2 GenerateRandomPosition()
    {
        float spawnPosX = Random.Range(spawnRangeXMin, spawnRangeXMax);
        float spawnPosY = Random.Range(spawnRangeYMin, spawnRangeYMax);
        Vector3 randomPos = new Vector2(spawnPosX, spawnPosY);

        return randomPos;
    }
}
