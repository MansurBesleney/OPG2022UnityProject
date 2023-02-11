using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPrefab;

    public GameObject muzzleFlashPrefab;

    Animator animator;

    public float bulletForce = 20f;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    public void Shoot()//ateş etmemeizi sağlar ve gerekli animasyonu çalıştırır
    {
        animator.SetTrigger("ShootTrigger");

        GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.right * bulletForce , ForceMode2D.Impulse);

        Destroy(muzzleFlash, 0.05f);
    }
}
