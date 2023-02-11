using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    public Animator anim;

    private float disToPlayer;

    public int maxHealth = 3;
    public int currentHealth;
    public int damage = 1;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float agroRange;

    public Transform firePoint;

    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private float nextFireTime = 0f;

    [SerializeField] private float fireRate = 2f;

    public GameObject blood;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player)
        {
            disToPlayer = Vector2.Distance(transform.position, player.position);//oyuncuyla düşman arasındaki mesafeyi alır
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (disToPlayer < agroRange)//eğer oyuncu düşmanın agro alanında ise düşman oyuncuya saldırmaya başlar
        {
            rb.rotation = angle + 90;
            
        }
        if (disToPlayer< agroRange && Time.time>nextFireTime)
        {
            nextFireTime = Time.time + 1 / fireRate;
            Shoot();
        }
        direction.Normalize();
        movement = direction;
        }
    }

    private void FixedUpdate()
    {
       
        if (disToPlayer < agroRange)
        {
            anim.SetBool("IsEnemyMoving", true);
            MoveEnemy(movement);
        }
        else
        {
            anim.SetBool("IsEnemyMoving", false);
        }
    }

    void MoveEnemy(Vector2 direction)//düşmanın hareket etmesini sağlar düşman oyuncuyu takip eder
    {
        
        rb.MovePosition((Vector2)transform.position + (direction.normalized * moveSpeed * Time.deltaTime));
    }

   void Shoot()//düşmanın ateş etmesini sağlar
   {
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
   }

   void OnTriggerEnter2D(Collider2D col)
   {
        if(col.tag == "PlayerBullet")
        {
            
            currentHealth -= damage;
            Instantiate(blood, transform.position, Quaternion.identity);
            //Destroy(blood, 1f);
            if(currentHealth ==0)
            {
                Destroy(gameObject);
            }
        }
   }
}
