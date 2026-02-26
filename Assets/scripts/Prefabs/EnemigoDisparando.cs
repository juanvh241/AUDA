using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    private float timer;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        timer = fireRate;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Shoot();
            timer = fireRate;
        }
    }

    void Shoot()
    {
        Vector2 direction = (player.position - transform.position);

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        bullet.GetComponent<Bala>().SetDirection(direction);
    }
}