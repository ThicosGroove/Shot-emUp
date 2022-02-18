using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // muita gente só deixa public
    // prefiro usar serializeField para manipular a variavel no inspector
    // poq não vou usar em outra classe.  ta certo isso? acho que sim né
    [SerializeField] private float moveSpeed;

    private InputControls inputControls;

    private Rigidbody2D rb;
    private Vector2 moveDirection;


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
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDirection = inputControls.SpaceShip.Move.ReadValue<Vector2>();

        var posX = transform.position;
        posX.x = Mathf.Clamp(transform.position.x, -8.3f, 8.3f);
        transform.position = posX;

        var posY = transform.position;
        posY.y = Mathf.Clamp(transform.position.y, -4.4f, 4.4f);
        transform.position = posY;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
