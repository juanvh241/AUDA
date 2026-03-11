using UnityEngine;
using System.Collections;
public class PoderesJugador : MonoBehaviour
{
    public GameObject Desestabilizador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DesestabilizadorInicio());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DesestabilizadorInicio()
    {
       
        yield return new WaitForSeconds(10);
        GameObject Instancia = Instantiate(Desestabilizador, gameObject.transform);
        yield return new WaitForSeconds(1);
        Destroy(Instancia);
        StartCoroutine(DesestabilizadorInicio());

    }
}
