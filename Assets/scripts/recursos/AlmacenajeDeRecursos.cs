using UnityEngine;

public class AlmacenajeDeRecursos : MonoBehaviour
{
    public static AlmacenajeDeRecursos Almacenaje;

    public int Monedas;
    public int Xp;

    public string NombreMonedas = "MonedasPlayer";
    public string NombreXp = "XpPlayer";
    void Awake()
    {
        if(Almacenaje == null)
        {
            CargarDatos();
            Almacenaje = this;
            DontDestroyOnLoad(Almacenaje);
        }
        else
        {
            if(Almacenaje != this)
            {
                Destroy(gameObject);
            }

        }
    }

    private void OnDestroy()
    {
        GuardarDatos();
    }

    void GuardarDatos()
    {
        PlayerPrefs.SetInt(NombreMonedas, Monedas);
        PlayerPrefs.SetInt(NombreXp, Xp);
    }

    void CargarDatos()
    {
        PlayerPrefs.GetInt(NombreMonedas, Monedas);
        PlayerPrefs.GetInt(NombreXp, Xp);
    }
    // Update is called once per frame
   public void CargarmonedasPlayer( int i)
    {
        Monedas = i;
    }

    public int EntregarMonedasPlayer()
    {
        return Monedas;
    }

}
