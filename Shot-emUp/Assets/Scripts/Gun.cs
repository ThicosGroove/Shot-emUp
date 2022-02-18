using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Weapon weapon;
    //[SerializeField] private float fireRate = 0.5f;
   // private float nextFire = 0.0f;

    private Vector2 newDirection;

    private bool isActive;


    private void Update()
    {
        newDirection = (transform.localRotation * Vector3.up).normalized;

        isActive = gameObject.activeInHierarchy; //POQ NAO FUNCIONA
    }

    public void Shoot()
    {
        if (this.gameObject.activeInHierarchy) //POQ NAO FUNCIONA
        {
            GameObject bullet = Instantiate(weapon.bulletType, transform.position, Quaternion.identity);
            BulletManager newBullet = bullet.GetComponent<BulletManager>();
            newBullet.direction = newDirection;
        }
        
    }
}
