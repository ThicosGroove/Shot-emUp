using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public WeaponScriptableObject weapon;
    private Vector2 newDirection;

    private void Start()
    {
        InvokeRepeating("Shoot", 0.5f, weapon._fireRate);
    }

    private void Update()
    {
        newDirection = (transform.localRotation * Vector3.down).normalized;
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(weapon.bulletType, transform.position, Quaternion.identity);
        BulletHandler newBullet = bullet.GetComponent<BulletHandler>();
        newBullet.direction = newDirection;
    }
}
