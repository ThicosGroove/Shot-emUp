using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    [SerializeField] private float despawnPowerUp = 5f;

    private void Start()
    {
        Destroy(this.gameObject, despawnPowerUp); // se o jogador não pegar o PowerUP ele desaparece
    }

    //se sobrar tempo fazer animação de flutuando no espaço

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBody"))        
            Destroy(this.gameObject);        
    }
}
