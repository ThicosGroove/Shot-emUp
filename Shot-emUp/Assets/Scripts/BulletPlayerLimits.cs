using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerLimits : MonoBehaviour
{
    void Update()
    {
        var posY = transform.position;
        posY.y = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = posY;

        if (posY.y == 4.5f)
        {
            Destroy(gameObject);
            // tentar diminuir o alpha até 0
        }
    }
}
