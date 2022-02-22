using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //Preferi separar os scripts do Body
 //Esse lida apenas em pegar os Power Ups
public class PlayerPowerUP : MonoBehaviour
{
    public PowerUpManager powerUpManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //isso funiona?

        if (collision.gameObject.CompareTag("ShieldPU"))        
            StartCoroutine(powerUpManager.PowerUpShieldTimer());
        
        else if (collision.gameObject.CompareTag("SpeedPU"))        
            StartCoroutine(powerUpManager.PowerUpSpeedTimer());
                  
        else if (collision.gameObject.CompareTag("BulletPU"))       
            StartCoroutine(powerUpManager.PowerUpBulletTimer());        
    }
}
