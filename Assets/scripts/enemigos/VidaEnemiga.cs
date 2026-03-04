using Unity.VisualScripting;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int VidaEnemiga = 20;
    private bool EnemigoVivo = true;

    private spawnDeEnemigos Spawn;



    void Start()
    {
        Spawn = GameObject.Find("spawn").GetComponent<spawnDeEnemigos>();


    }

    // Update is called once per frame
    void Update()
    {
    
        if (VidaEnemiga <= 0 && EnemigoVivo){
            Destroy(gameObject);
            Spawn.CantidadDeEnemigos -= 1;
            EnemigoVivo = false;    

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerDisparo") { 
                        VidaEnemiga -= 5;
        }

    }
}
