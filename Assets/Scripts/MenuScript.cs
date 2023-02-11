using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject menupanel;

    public GameObject gameovermenupanel;

    public PlayerHealth playerHealth;

    public GameObject UIPanel;

    public GameObject healthBar;

    

    

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "SampleScene")
        {
            UIPanel.gameObject.SetActive(false);
            menupanel.gameObject.SetActive(true);//joystick'i açar menüyü kapatır
            gameovermenupanel.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
        }
        else if(currentScene.name == "Level1")
        {
            UIPanel.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(true);
            menupanel.gameObject.SetActive(false);
            gameovermenupanel.gameObject.SetActive(false);
        }
        /*UIPanel.gameObject.SetActive(false);
        menupanel.gameObject.SetActive(true);//joystick'i açar menüyü kapatır
        gameovermenupanel.gameObject.SetActive(false);
        healthBar.gameObject.SetActive(false);*/
    }

    private void Update()
    {
        if (playerHealth.isplayerdead == true)//eğer oyuncu ölürse ölüm menüsünü açar
        {
            
            gameovermenupanel.gameObject.SetActive(true);
            UIPanel.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
        }

       
    }
    public void StartGame()
    {
         menupanel.gameObject.SetActive(false);//oyun başlayınca menüyü kapatır
         UIPanel.gameObject.SetActive(false);
         healthBar.gameObject.SetActive(true);
    }

    public void RestartGame()//oyunu yeniden başlatır
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
    }
    

    public void ExitGame()//oyunu kapatır
    {
        Application.Quit();
    }
}
