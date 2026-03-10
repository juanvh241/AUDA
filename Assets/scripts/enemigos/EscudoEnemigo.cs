using UnityEngine;
using System.Collections;

public class EscudoEnemigo : MonoBehaviour
{
    private int Vida = 20;
    private bool enCooldown = false;

    // Referencias a los componentes que quieres "apagar"
    private SpriteRenderer spriteRenderer;
    private Collider2D col;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Vida <= 0 && !enCooldown)
        {
            StartCoroutine(Reaparecer());
        }
    }

    IEnumerator Reaparecer()
    {
        enCooldown = true;

        // "Desactivar" visualmente sin desactivar el GameObject
        spriteRenderer.enabled = false;
        col.enabled = false;

        yield return new WaitForSeconds(3f);

        // Reactivar
        Vida = 20;
        spriteRenderer.enabled = true;
        col.enabled = true;

        enCooldown = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerDisparo") && !enCooldown)
        {
            Vida -= 5;
        }
    }
}
