using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 13f;

    private Vector2 direction = new Vector2(0, 1);
    private Vector2 velocity;

    void Start()
    {
        Destroy(gameObject, 2.5f); //mudar no hit collision
    }

    void Update()
    {
        velocity = direction * bulletSpeed;
    }

    private void FixedUpdate()
    {
        Vector2 newPos = transform.position;

        newPos += velocity * Time.fixedDeltaTime;

        transform.position = newPos;
    }
}
