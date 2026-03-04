using UnityEngine;

public class Hacha : MonoBehaviour
{
    private Rigidbody2D rb;
    public float fuerzaHorizontal = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Una cae a la izquierda y otra a la derecha dependiendo de su posición
        float direccion = transform.position.x > GameObject.FindWithTag("Player").transform.position.x ? 1f : -1f;
        rb.linearVelocity = new Vector2(direccion * fuerzaHorizontal, 0);

        Destroy(gameObject, 2f);
    }

    void Update()
    {
        // Rota más rápido mientras más velocidad tiene, da efecto realista
        transform.Rotate(0, 0, 400 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            VidaEnemigo vida = other.GetComponent<VidaEnemigo>();
            if (vida != null)
            {
                vida.VidaEnemiga -= 10;
            }
        }
    }
}