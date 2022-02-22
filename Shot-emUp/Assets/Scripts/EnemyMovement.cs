using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyHealth myHealth;

    // acho importante deixar no inspector alguns setups
    [SerializeField] private float moveSpeedMin = 2.5f;
    [SerializeField] private float moveSpeedMax = 5.5f;
    
    private Vector2 newPos;
    private float outOfBounds = -6.5f;

    private void Start()
    {
        newPos = transform.position;
    }

    private void Update()
    {
        ShouldDie();
    }

    private void FixedUpdate()
    {
        newPos.y -= RandomSpeedGenerator() * Time.deltaTime;

        transform.position = newPos;
    }

    private float RandomSpeedGenerator() //para gerar mais aleatoriedade nos inimigos
    {
        float randomSpeed = Random.Range(moveSpeedMin, moveSpeedMax);

        return randomSpeed;
    }

    private void ShouldDie()
    {
        if (newPos.y < outOfBounds)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            myHealth.TakeDemage();

            GamePointSystem.instance.UpdateScore(1);
        }
    }
}
