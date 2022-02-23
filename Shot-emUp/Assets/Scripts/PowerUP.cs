using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    [SerializeField] private float despawnPowerUp = 5f;

    private void Start()
    {
        Destroy(this.gameObject, despawnPowerUp); // se o jogador n�o pegar o PowerUP ele desaparece
    }

    //se sobrar tempo fazer anima��o de flutuando no espa�o

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBody"))        
            Destroy(this.gameObject);        
    }
}
