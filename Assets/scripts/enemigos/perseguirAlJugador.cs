using UnityEngine;

public class perseguirAlJugador : MonoBehaviour
{
    private GameObject jugador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = GameObject.Find("player");   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if(jugador != null)
        {
            float Distancia = Vector2.Distance(jugador.transform.position, transform.position);
            if (Distancia > 1.7)
            {
                transform.up = jugador.transform.position - transform.position;
                transform.position += transform.up * Time.deltaTime;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
