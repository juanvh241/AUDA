using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovimiento : MonoBehaviour
{

    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private Vector2 movimiento;

    public int velocidad = 7;
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
        // Rota el personaje hacia el cursor
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;
        Vector2 direction = (mousePos - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movimiento * velocidad * Time.deltaTime);
    }
}
