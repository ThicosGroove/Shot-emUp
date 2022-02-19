using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cuida dos pontos e do spawn do jogador
public class GameSystemManager : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject[] Enemy;

    private Vector2 spawnPosSpaceShip;

    void Start()
    {
        spawnPosSpaceShip = spaceShip.transform.position;
    }

    void Update()
    {
        if (spaceShip.gameObject.GetComponent<PlayerMovement>().IsDead)
        {
            SpaceShipRespawn();
        }
    }

    private void SpaceShipRespawn()
    {
        Debug.Log("Respawn");
        spaceShip.transform.position = spawnPosSpaceShip;
    }

}