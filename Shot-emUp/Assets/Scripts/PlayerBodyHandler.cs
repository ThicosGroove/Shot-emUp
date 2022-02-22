using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Preferi separar os scripts do Body
//Esse lida apenas em tomar o tiro do inimigo
public class PlayerBodyHandler : MonoBehaviour
{
    private PlayerSpawnManager spawnManager;

    private void Start()
    {
        spawnManager = FindObjectOfType<PlayerSpawnManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("PlayerBody") && collision.gameObject.CompareTag("EnemyBullet"))
        {
            GamePointSystem.instance.UpdateScore(0);
            spawnManager.isDead = true;
        }
    }
}
