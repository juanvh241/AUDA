using Unity.VisualScripting;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{

    public int VidaEnemiga = 20;

    private bool EnemigoVivo = true;


    private spawnDeEnemigos Spawn;

    public GameObject Monedas;
    public GameObject Cuerpo;


    void Start()
    {
        Spawn = GameObject.Find("spawn").GetComponent<spawnDeEnemigos>();
        

    }

    // Update is called once per frame
    void Update()
    {
    
        if (VidaEnemiga <= 0 && EnemigoVivo){
            Destroy(Cuerpo);
            Spawn.CantidadDeEnemigos -= 1;
            EnemigoVivo = false;    

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerDisparo") { 
                        VidaEnemiga -= 5;
        }

    }

    private void OnDestroy()
    {
        int Cantidad = Random.Range(0, 3);
        
        for (int i = Cantidad; i < 3; i++)
        {
            float Posicion = Random.Range(-0.5f, 0.5f);

            Vector2 PosicionFinal = new Vector2(transform.position.x + Posicion, transform.position.y + Posicion);
            Instantiate(Monedas,PosicionFinal,Quaternion.identity);
        }

    }
}
