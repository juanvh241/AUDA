using UnityEngine;
using System.Collections;
public class perseguirAlJugador : MonoBehaviour
{
    public bool Stun = false;

    public int Velocidad;

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
            if (Distancia > 1.7 && !Stun)
            {
                transform.up = jugador.transform.position - transform.position;
                transform.position += transform.up * Time.deltaTime * Velocidad;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Continuar()
    {
        yield return new WaitForSeconds(5);
        Stun = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stun"))
        {
            Stun = true;
            StartCoroutine(Continuar());
        }
    }
}
