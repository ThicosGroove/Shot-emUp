using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public float powerUpSpeed = 1.5f;
    public float _shieldPowerUpTimer = 8f;
    public float _speedPowerUpTimer = 8f;
    public float _bulletsPowerUpTimer = 12f;

    public GameObject shield; // tive que fazer public
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
    public IEnumerator PowerUpShieldTimer()
    {
        timerBar.SetTimer(_shieldPowerUpTimer);

        shield.SetActive(true); 

        yield return new WaitForSeconds(_shieldPowerUpTimer);

        shield.SetActive(false);
    }

    public IEnumerator PowerUpSpeedTimer()
    {
        timerBar.SetTimer(_speedPowerUpTimer);

        playerMovement.moveSpeed *= powerUpSpeed;

        yield return new WaitForSeconds(_speedPowerUpTimer);

        playerMovement.moveSpeed /= powerUpSpeed;
    }

    public IEnumerator PowerUpBulletTimer()
    {
        timerBar.SetTimer(_bulletsPowerUpTimer);


            Debug.Log("Pegou bala");
            gun[0].gameObject.SetActive(false);
            gun[1].gameObject.SetActive(false);
            gun[2].gameObject.SetActive(true);
            gun[3].gameObject.SetActive(true);
            gun[4].gameObject.SetActive(true);

            // gun[i].gameObject.SetActive(true) = !gun[i].gameObject.SetActive(false);
            // PAOLLA MIM AJUDA =�(

            //if (gun[i].gameObject.activeInHierarchy)
              //  gun[i].gameObject.SetActive(false);
       
        yield return new WaitForSeconds(_bulletsPowerUpTimer);

            gun[0].gameObject.SetActive(true);
            gun[1].gameObject.SetActive(true);
            gun[2].gameObject.SetActive(false);
            gun[3].gameObject.SetActive(false);
            gun[4].gameObject.SetActive(false);
        
        //tentei de muitas formas fazer as armas funcionarem. mas esse foi o que eu consegui
        //o problema � que quando troca de arma o jogador precisa pressionar novamente o botao
        //e n�o sei se 
    }
}
