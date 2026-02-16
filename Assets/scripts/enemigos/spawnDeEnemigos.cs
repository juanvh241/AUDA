using UnityEngine;

public class spawnDeEnemigos : MonoBehaviour
{
    public GameObject enemigo;
    public GameObject jugador;

    public int X;
    public int Y;

    private float valorY;
    private float valorX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // posicion del spawn en base a variables aleatorias
        X = Random.Range(-0, 2);
        Y = Random.Range(-0, 2);

        if (Y == 1)
        {
            valorY = jugador.transform.position.y + Random.Range(5, 10);
        }
        else
        {
            valorY = jugador.transform.position.y + Random.Range(-5, -10);
        }

        if (X == 1)
        {
            valorX = jugador.transform.position.x + Random.Range(5, 10);
        }
        else
        {
            valorX = jugador.transform.position.x + Random.Range(-5, -10);
        }



        Vector2 posicion = new Vector2(valorX, valorY);
        transform.position = posicion;
        Instantiate(enemigo, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
