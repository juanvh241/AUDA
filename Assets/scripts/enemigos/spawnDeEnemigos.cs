using UnityEngine;
using System.Collections;

public class spawnDeEnemigos : MonoBehaviour
{
    public GameObject enemigo;
    public GameObject Tirador;
    public GameObject jugador;
    

    private int X;
    private int Y;
    public float AleatorizadorDeEnemigos;
    public int SpawnMax;
    public int CantidadDeEnemigos = 0;
    

    private float valorY;
    private float valorX;

    private bool enfriamientoDeSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnMax = 3;
        enfriamientoDeSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(CantidadDeEnemigos < SpawnMax && !enfriamientoDeSpawn)
        {
            StartCoroutine(Cooldown());
        }
    }

    void Clonar()
    {
        // posicion del spawn en base a variables aleatorias
        X = Random.Range(-0, 2);
        Y = Random.Range(-0, 2);
        AleatorizadorDeEnemigos = Random.Range(-0, 2);

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


        //Determinar posición
        Vector2 posicion = new Vector2(valorX, valorY);
        transform.position = posicion;
        if(AleatorizadorDeEnemigos >= 1)
        {
            Instantiate(Tirador, gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemigo, gameObject.transform.position, Quaternion.identity);
        }

        CantidadDeEnemigos += 1;
    }
    IEnumerator Cooldown()
    {
        enfriamientoDeSpawn = true;
        yield return new WaitForSeconds(3);
        Clonar();
        enfriamientoDeSpawn = false;
    }
}
