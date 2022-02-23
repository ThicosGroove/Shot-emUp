using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    // uso no TimerBarManager
    public float _bulletsPowerUpTimer = 12f;
    public float _shieldPowerUpTimer = 8f;
    public float _speedPowerUpTimer = 8f;
    public float maxBulletTimer;
    public float maxShieldTimer;
    public float maxSpeedTimer;
    public bool hasPowerUp;       
    public string whichPowerUp;

    private float powerUpSpeed = 1.5f;
    private int secondBullet = 0;

    // tive que fazer public poq n�o come�a ativo 
    public GameObject shield; 
    public GunHandler[] gun;

    private PlayerMovement playerMovement;
    private TimerBarManager timerBar;

    private void Start()
    {
       // shield = GameObject.FindGameObjectWithTag("Shield");  // est� em outro GO e n�o tem nenhum componente especifico ... Poq precisa do GameObject ?
       // gun = FindObjectsOfType(typeof(GunHandler)) as GunHandler[]; // s�o varios GO, mas essa fun��o � bem estranha.

       // esses metodos de cima funcionariam se os objetos estivessem ativos na cena.
       // a forma que eu encontrei de fazer isso � com resources, mas me pareceu perigoso, poq mexe direto no prefab


        timerBar = GetComponent<TimerBarManager>(); // est� no mesmo GO, ent�o � s� buscar o componente
        playerMovement = FindObjectOfType<PlayerMovement>(); // est� em outro GO, mas tem um componente espec�fico, e � ele que eu quero.
    }


    // ia colocar os 3 juntos, mas achei melhor separar para poder ajustar os tempos independentes
    // s�o usados pelo PlayerBodyHandler
    public IEnumerator PowerUpBulletTimer()
    {
        maxBulletTimer = _bulletsPowerUpTimer;

        whichPowerUp = "Bullet";
        timerBar.GettingTimer(whichPowerUp);

        hasPowerUp = true;

        secondBullet++;

        if (secondBullet == 1)
        {
            for (int i = 0; i < gun.Length; i++)
            {
                gun[i].gameObject.SetActive(!gun[i].gameObject.activeInHierarchy);
            }
        }

        yield return new WaitForSeconds(maxBulletTimer); // nao consegui reiniciar o tempo 

        maxBulletTimer -= Time.deltaTime;


        for (int i = 0; i < gun.Length; i++)
        {
            gun[i].gameObject.SetActive(!gun[i].gameObject.activeInHierarchy);
        }

        hasPowerUp = false;

        secondBullet--;

        //tentei de muitas formas fazer as armas funcionarem. mas esse foi o que eu consegui
        //o problema � que quando troca de arma o jogador precisa pressionar novamente o botao
    }

    public IEnumerator PowerUpShieldTimer()
    {
        maxShieldTimer = _shieldPowerUpTimer;

        whichPowerUp = "Shield";
        timerBar.GettingTimer(whichPowerUp);

        hasPowerUp = true;

        shield.SetActive(true); 

        yield return new WaitForSeconds(maxShieldTimer);

        shield.SetActive(false);

        hasPowerUp = false;
    }

    public IEnumerator PowerUpSpeedTimer()
    {
        maxSpeedTimer = _speedPowerUpTimer;

        whichPowerUp = "Speed";
        timerBar.GettingTimer(whichPowerUp);

        hasPowerUp = true;

        playerMovement.moveSpeed *= powerUpSpeed;

        yield return new WaitForSeconds(maxSpeedTimer);

        playerMovement.moveSpeed /= powerUpSpeed;

        hasPowerUp = false;
    }

}
