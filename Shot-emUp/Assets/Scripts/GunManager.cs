using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunManager : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletType;

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

    }

    private void FixedUpdate()
    {
        shoot = inputControls.SpaceShip.Shot.ReadValue<float>();

        if (shoot == 1)
            SpawnBullet(0);
    }

    //vai mudar de acordo com o power up OU o jogador pode selecionar hr que quiser
    private void SpawnBullet(int type)
    {
        Instantiate(bulletType[type].gameObject, transform.position, Quaternion.identity);
    }
}
