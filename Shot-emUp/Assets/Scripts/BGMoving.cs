using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMoving : MonoBehaviour
{
    [SerializeField] private MeshRenderer mat;

    [SerializeField] private float bgMoveSpeed = 1f;

    void Update()
    {
        mat.material.mainTextureOffset += new Vector2(0, bgMoveSpeed * Time.deltaTime);
    }
}
