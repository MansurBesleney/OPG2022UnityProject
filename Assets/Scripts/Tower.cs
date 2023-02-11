using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public int maxHealth = 15;
    public int currentHealth;

    public int damage = 1;

    public GameObject spark;
    // Start is called before the first frame update
    void Start()
    {
         currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "PlayerBullet")
        {
            
            currentHealth -= damage;
            Instantiate(spark, transform.position, Quaternion.identity);
            if(currentHealth ==0)
            {
                Destroy(gameObject);
            }
        }
   }
}
