using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public Weapon weapon;
    private Vector2 newDirection;

    private void Start()
    {
        InvokeRepeating("Shoot", 0.5f, 0.8f);
    }

    private void Update()
    {
        newDirection = (transform.localRotation * Vector3.down).normalized;
    }

    public void Shoot()
    {

        GameObject bullet = Instantiate(weapon.bulletType, transform.position, Quaternion.identity);
        BulletManager newBullet = bullet.GetComponent<BulletManager>();
        newBullet.direction = newDirection;

    }
}
