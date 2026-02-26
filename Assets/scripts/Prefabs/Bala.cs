using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 7f;        // Velocidad de la bala (podés cambiar este número)
    private Vector2 direction;      // Hacia dónde va la bala (lo define el enemigo al dispararla)

    public void SetDirection(Vector2 dir)   // El enemigo llama esta función para decirle a la bala hacia dónde ir
    {
        direction = dir.normalized;         // "normalized" hace que la velocidad sea siempre la misma sin importar la distancia
    }

    void Update()                           // Se ejecuta en cada frame del juego
    {
        transform.Translate(direction * speed * Time.deltaTime);  // Mueve la bala en la dirección indicada
    }

    void OnBecameInvisible()               // Se ejecuta cuando la bala sale de la pantalla
    {
        Destroy(gameObject);               // Destruye la bala para no desperdiciar memoria
    }
}