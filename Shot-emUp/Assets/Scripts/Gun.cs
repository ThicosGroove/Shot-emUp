using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public WeaponScriptableObject weapon;
    private float nextFire = 0.0f;

    private Vector2 newDirection;

    private float shoot;
    private InputControls inputControls;


    private void Awake()
    {
        inputControls = new InputControls();
    }

    private void OnEnable()
    {
        inputControls.Enable();
    }

    private void OnDisable()
    {
        inputControls.Disable();
    }

    private void Update()
    {
        newDirection = (transform.localRotation * Vector3.up).normalized;

        shoot = inputControls.SpaceShip.Shot.ReadValue<float>();

        if (shoot == 1 && Time.time > nextFire)
        {
            nextFire = Time.time + weapon._fireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(weapon.bulletType, transform.position, Quaternion.identity);
        BulletManager newBullet = bullet.GetComponent<BulletManager>();
        newBullet.direction = newDirection;
    }
}
