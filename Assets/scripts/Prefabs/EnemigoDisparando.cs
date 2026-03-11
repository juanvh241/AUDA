using UnityEngine;
using System.Collections;
public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    public Transform Puntodisparo;
    public float timer;
    private bool Stun;

    public bool probar;

    private Transform player;
    

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        timer = fireRate;
    }

    void Update()
    {
        if (player == null) return;
        float Distancia = Vector2.Distance(player.transform.position, transform.position);
        if (!Stun)
        {
            if (Distancia >= 2.5f)
            {
                Vector2 direction = (player.position - transform.position);
                transform.up = direction;
                transform.position += transform.up * Time.deltaTime;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
                timer -= Time.deltaTime;

                if (timer <= 0f)
                {
                    Shoot();
                    timer = fireRate;
                }

            }
            else
            {
                Vector2 direction = (player.position - transform.position);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
                timer -= Time.deltaTime;

                if (timer <= 0f)
                {
                    Shoot();
                    timer = fireRate;

                }
            }
        }
 

    }

    void Shoot()
    {
        if (player != null)
        {
            probar = false;
            Vector2 direction = (player.position - Puntodisparo.position);

            GameObject bullet = Instantiate(bulletPrefab, Puntodisparo.position, Quaternion.identity);

            bullet.GetComponent<Bala>().SetDirection(direction);

        }

    }

    IEnumerator Continuar()
    {
        yield return new WaitForSeconds(5);
        Stun = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stun"))
        {
            Stun = true;
            StartCoroutine(Continuar());
        }
    }
}