using UnityEngine;

public class perseguirAlJugador : MonoBehaviour
{
    public GameObject jugador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = GameObject.Find("player");   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.up = jugador.transform.position - transform.position;
        transform.position += transform.up * Time.deltaTime;
    }
}
