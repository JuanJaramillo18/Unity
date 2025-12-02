using UnityEngine;

public class PlayerShoot2D : MonoBehaviour
{
    public GameObject bulletPrefab;      // Prefab de la bala
    public Transform firePoint;          // Punto desde donde dispara
    public float bulletSpeed = 10f;      // Velocidad de la bala

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Presionar F
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Crear la bala
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Mover la bala hacia adelante (derecha del firePoint)
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.right * bulletSpeed;
    }
}

