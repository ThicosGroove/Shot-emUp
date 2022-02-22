using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cuida dos pontos e do spawn do jogador
public class GameSystemManager : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject[] Enemy;

    public bool isDead = false;
    private Vector2 spawnPosSpaceShip;

    void Start()
    {
        spawnPosSpaceShip = spaceShip.transform.position;
    }

    void Update()
    {
        if (isDead)
            SpaceShipRespawn();       
    }

    private void SpaceShipRespawn()
    {
        spaceShip.transform.position = spawnPosSpaceShip;
        Physics.SyncTransforms();

        isDead = false;
    }

}
