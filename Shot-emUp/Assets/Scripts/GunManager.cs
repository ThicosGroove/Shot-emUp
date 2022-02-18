using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunManager : MonoBehaviour
{
    private Gun[] gun;
    //public Weapon[] weapon;

    private InputControls inputControls;

    private float shoot;

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

    void Start()
    {
        gun = GetComponentsInChildren<Gun>();
    }

    private void FixedUpdate()
    {
        shoot = inputControls.SpaceShip.Shot.ReadValue<float>();

        if (shoot == 1) 
        {
            foreach (var guns in gun)
            {
                guns.Shoot();
            }
        }      
    }   
}
