using UnityEngine;
using UnityEngine.InputSystem;

public class HachaPasiva : MonoBehaviour
{
    public GameObject hachaPrefab;
    public bool activa = false;        // Bool para activar/desactivar
    public float cooldown = 5f;
    private float timer = 0f;

    void Update()
    {
        // Activa o desactiva con la tecla X
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            activa = !activa;
            Debug.Log("Pasiva hacha: " + (activa ? "ACTIVADA" : "DESACTIVADA"));
        }

        if (!activa) return;  // Si está desactivada no hace nada

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            LanzarHachas();
            timer = cooldown;
        }
    }

    void LanzarHachas()
    {
        // Lanza un hacha a la izquierda y otra a la derecha
        Vector3 posIzquierda = transform.position + new Vector3(-1f, 1f, 0);
        Vector3 posDerecha = transform.position + new Vector3(1f, 1f, 0);

        Instantiate(hachaPrefab, posIzquierda, Quaternion.identity);
        Instantiate(hachaPrefab, posDerecha, Quaternion.identity);
    }
}