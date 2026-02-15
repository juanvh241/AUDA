using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovimiento : MonoBehaviour
{

    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private Vector2 movimiento;

    public int velocidad = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento = playerInput.actions["movimiento"].ReadValue<Vector2>();
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movimiento * velocidad * Time.deltaTime);
    }
}
