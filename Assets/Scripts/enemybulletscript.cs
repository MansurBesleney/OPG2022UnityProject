using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybulletscript : MonoBehaviour
{
   
    
    


    void OnTriggerEnter2D(Collider2D col)//eğer düşmanın mermisi oyuncuya çarparsa oyuncu yok olur oyuncu dışında bir objeye çarparsa mermi yok olur
    {
        Destroy(gameObject);
    }
}
