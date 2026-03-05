using UnityEngine;

public class Vida : MonoBehaviour
{
    public float vida = 30;
    public int monedas = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(AlmacenajeDeRecursos.Almacenaje != null)
        {
            CargarMonedas();
        }

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
        else if (other.gameObject.CompareTag("Monedas"))
        {
            monedas += 1;
        }

    }
    private void OnDestroy()
    {
        if (AlmacenajeDeRecursos.Almacenaje != null)
        {
            GuardarMonedas();
        }

    }
    void CargarMonedas()
    {
        monedas = AlmacenajeDeRecursos.Almacenaje.EntregarMonedasPlayer();
    }
    void GuardarMonedas()
    {
        AlmacenajeDeRecursos.Almacenaje.CargarmonedasPlayer(monedas);
    }
}