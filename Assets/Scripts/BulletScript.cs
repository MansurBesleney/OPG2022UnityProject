using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }*/


    
    void OnTriggerEnter2D(Collider2D col)//eğer mermi düşmana çarparsa düşmanı yok eder düşman dışında bir objeye çarparsa mermi yok olur 
    {
        Destroy(gameObject);
        /*if (col.tag == "Enemy")
        {
            Debug.Log("hit enemy");
            Destroy(col.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
    }
}
