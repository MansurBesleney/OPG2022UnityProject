using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform player;

    public Transform firePoint;

    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private float nextFireTime = 0f;

    [SerializeField] private float fireRate = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TurnCannon();

        if (Time.time>nextFireTime)
        {
            nextFireTime = Time.time + 1 / fireRate;
            Shoot();
        }
    }

    void TurnCannon()
    {
        if(player)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle + 270;
        }
        

        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

   
}
