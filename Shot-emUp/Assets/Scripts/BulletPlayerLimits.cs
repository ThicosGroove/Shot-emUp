using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerLimits : MonoBehaviour
{
    [SerializeField] float bulletMaxRange = 4.5f;

    Color sprite;

    Transform firstPos;

    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>().color;

        firstPos = transform;
    }

    void Update()
    {
        var posY = transform.position;
        posY.y = Mathf.Clamp(transform.position.y, firstPos.position.y, bulletMaxRange);
        transform.position = posY;

        sprite.a = Mathf.Lerp(firstPos.position.y, bulletMaxRange, 0.5f);

        //sprite.GetComponent<SpriteRenderer>().color = sprite;

        if (posY.y == 4.5f)
        {
            Destroy(gameObject);
        }
    }
}
