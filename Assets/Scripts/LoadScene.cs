using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            SceneManager.LoadScene(1,LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
