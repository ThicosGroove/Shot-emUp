using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Preferi separar os scripts do Body
//Esse lida apenas tomar o tiro do inimigo
public class PlayerBodyHandler : MonoBehaviour
{
    public GameSystemManager gameSystemManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("PlayerBody") && collision.gameObject.CompareTag("EnemyBullet"))
        {
            GamePointSystem.instance.UpdateScore(0);
            gameSystemManager.isDead = true;
        }
    }
}
