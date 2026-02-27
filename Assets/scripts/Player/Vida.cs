using UnityEngine;

public class Vida : MonoBehaviour
{
    public float vida = 30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Arma"))
        {
            vida -= 5;
        }
        else if (other.gameObject.CompareTag("Bala"))
        {
            vida -= 5;
        }
    }
}