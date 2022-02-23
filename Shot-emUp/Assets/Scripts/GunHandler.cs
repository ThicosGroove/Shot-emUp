using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour
{
    public WeaponScriptableObject weapon;

    private GunHandlerSFX gunSFX;

    private InputControls inputControls;
    private float nextFire = 0.0f;
    private Vector2 newDirection;
    private float shoot;

    private void Awake()
    {
        inputControls = new InputControls();
    }

    private void OnEnable() => inputControls.Enable();

    private void OnDisable() => inputControls.Disable();

    private void Start()
    {
        gunSFX = GetComponentInParent<GunHandlerSFX>();
    }

    private void Update()
    {
        newDirection = (transform.localRotation * Vector3.up).normalized;

        shoot = inputControls.SpaceShip.Shot.ReadValue<float>();

        if (shoot == 1 && Time.time > nextFire)
        {
            nextFire = Time.time + weapon._fireRate;
            Shoot();
            PlayAudio();
        }
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(weapon.bulletType, transform.position, Quaternion.identity);
        BulletHandler newBulletDirection = newBullet.GetComponent<BulletHandler>();
        newBulletDirection.direction = newDirection;
    }

    private void PlayAudio() => gunSFX.PlaySFX();
}
