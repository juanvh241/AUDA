using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    private GameObject jugador;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(jugador.transform.position.x, jugador.transform.position.y, -10);


    }
}
