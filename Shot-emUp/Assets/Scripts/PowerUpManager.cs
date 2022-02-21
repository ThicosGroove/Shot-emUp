using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
     public float powerUpSpeed = 1.5f;
     public float _shieldPowerUpTimer = 8f;
     public float _speedPowerUpTimer = 8f;
     public float _bulletsPowerUpTimer = 12f;

    public GameObject shield;
    public PlayerMovement playerMovement;
    public GameObject[] gun;

    // ia colocar os 3 juntos, mas achei melhor separar para poder ajustar os tempos independentes
    public IEnumerator ShieldTimer()
    {
        shield.SetActive(true); 

        yield return new WaitForSeconds(_shieldPowerUpTimer);

        shield.SetActive(false);
    }

    public IEnumerator SpeedTimer()
    {
        playerMovement.moveSpeed *= powerUpSpeed;

        yield return new WaitForSeconds(_speedPowerUpTimer);

        playerMovement.moveSpeed /= powerUpSpeed;
    }

    public IEnumerator BulletTimer()
    {
        gun[0].SetActive(false);
        gun[1].SetActive(true);
        gun[2].SetActive(true);
        gun[3].SetActive(true);

        yield return new WaitForSeconds(_bulletsPowerUpTimer);

        gun[0].SetActive(true);
        gun[1].SetActive(false);
        gun[2].SetActive(false);
        gun[3].SetActive(false);

        //tentei de muitas formas fazer as armas funcionarem. mas esse foi o que eu consegui
        //o unico problema é que quando troca de arma o jogador precisa pressionar novamente o botao
    }
}
