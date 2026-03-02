using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;

    private bool canShoot = true; // Disparando
    void Update()
    {
  

       // Dispara con clic izquierdo
        if (Mouse.current.leftButton.wasPressedThisFrame && canShoot)
        {
            Shoot();
                StartCoroutine(cooldown()); // Inicia el cooldown después de disparar
        }

    }
    IEnumerator cooldown() { 
        canShoot = false; // Desactiva el disparo   
        yield return new WaitForSeconds(0.5f); // Tiempo de espera entre disparos
        canShoot = true; // Vuelve a activar el disparo
    }


    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;

        Vector2 direction = (mousePos - shootPoint.position);

        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bullet.GetComponent<Bala>().SetDirection(direction);
    }
}