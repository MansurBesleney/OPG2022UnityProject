using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 5;
    public int currentHealth;

    public int lastHealth;

    public int damage = 1;

    public HealthBarScript healthBar;
    public GameObject blood;

    void Start()
    {
        if(lastHealth!=0)
        {
            currentHealth = lastHealth;
        }
        else
        {
            currentHealth = maxHealth;  
        }
        

        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        lastHealth = currentHealth;
        Debug.Log(currentHealth+ " " +lastHealth);
    }
    public bool isplayerdead=false;
    void OnTriggerEnter2D(Collider2D col)//eğer mermi oyuncuya çarparsa bu bilgiye ulaşmamızı sağlar
    {
        if (col.tag == "EnemyBullet")
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            Instantiate(blood, transform.position, Quaternion.identity);
            //Destroy(blood, 1f);
            if (currentHealth==0)
            {
                Destroy(gameObject);
                isplayerdead = true;
            }
            //isplayerdead=true;
            Debug.Log("player hit");
            
        }  
    }
}
