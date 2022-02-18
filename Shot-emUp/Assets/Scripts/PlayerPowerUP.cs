using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Achei que ia ficar muita coisa num script só
public class PlayerPowerUP : MonoBehaviour
{
    
    [SerializeField] private float powerUpSpeed = 1.5f; //preferi deixar o jogador lidar com os power ups. Não sei se é a melhor decisão.
                                                        // mas me parece ser a mais fácil aqui

    [SerializeField] private float _shieldPowerUpTimer = 8f;
    [SerializeField] private float _speedPowerUpTimer = 8f;
    [SerializeField] private float _bulletsPowerUpTimer = 12f;

    public GameObject shield;
    public GameObject[] gun;

    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ShieldPU"))
        {
            shield.SetActive(true);

            StartCoroutine(ShieldTimer());
        }

        if (collision.gameObject.CompareTag("SpeedPU"))
        {
            playerMovement.moveSpeed *= powerUpSpeed;

            StartCoroutine(SpeedTimer());
        }

        if (collision.gameObject.CompareTag("BulletPU"))
        {
            gun[0].SetActive(false);
            gun[1].SetActive(true);
            gun[2].SetActive(true);
            gun[3].SetActive(true);

            StartCoroutine(BulletTimer());
        }

    }

    // ia colocar os 3 juntos, mas achei melhor separar para poder ajustar os tempos independentes
    IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(_shieldPowerUpTimer);

        shield.SetActive(false);
        playerMovement.moveSpeed /= powerUpSpeed;
    }

    IEnumerator SpeedTimer()
    {
        yield return new WaitForSeconds(_speedPowerUpTimer);

        shield.SetActive(false);
        playerMovement.moveSpeed /= powerUpSpeed;
    }

    IEnumerator BulletTimer()
    {
        yield return new WaitForSeconds(_bulletsPowerUpTimer);

        gun[0].SetActive(true);
        gun[1].SetActive(false);
        gun[2].SetActive(false);
        gun[3].SetActive(false);

        //tentei de muitas formas fazer as armas funcionarem. mas esse foi o que eu consegui
    }
}
