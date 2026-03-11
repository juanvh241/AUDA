using UnityEngine;

public class Monedas : MonoBehaviour
{
    private GameObject Player;

    void Start()
    {
         Player = GameObject.Find("Player");
    }


    void Update()
    {
       if(Player == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
