using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public WeaponScriptableObject weapon;
    public Vector2 direction = new Vector2(0, 1);
    private Vector2 velocity;

    void Start()
    {
        Destroy(gameObject, 2.5f);
    }

    void Update()
    {
        velocity = direction * weapon._bulletSpeed;
    }

    private void FixedUpdate()
    {
        Vector2 newPos = transform.position;

        newPos += velocity * Time.fixedDeltaTime;

        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.CompareTag("EnemyBullet") && collision.gameObject.CompareTag("PlayerBody"))        
            Destroy(this.gameObject);      
        
        else if (this.gameObject.CompareTag("EnemyBullet") && collision.gameObject.CompareTag("Shield"))       
            Destroy(this.gameObject); 
        
        else if (this.gameObject.CompareTag("PlayerBullet") && collision.gameObject.CompareTag("Enemy"))       
            Destroy(this.gameObject);
       
    }
}
