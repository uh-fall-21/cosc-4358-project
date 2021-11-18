using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private GameObject deathChunkParticle, deathBloodParticle;

    private float currentHealth;

    private GameManager GM;

    private void Start(){
        currentHealth=maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void DecreaseHealth(float amount){
        currentHealth-=amount;

        if(currentHealth<=0.0f){
            //GameOver();
            Die();
        }
    }
    /*
    public void PauseGame()
    {
        events.OnGamePaused.Invoke();
        paused = true;
        Time.timeScale = 0f;
    }
*/
/*
    public void GameOver()
    {
        PauseGame();
        events.OnGameOver.Invoke();
        SceneManager.LoadScene("GameOver");
    }
*/
    private void Die(){
        //Instantiate(deathChunkParticle,transform.position, deathChunkParticle.transform.rotation);
        //Instantiate(deathBloodParticle,transform.position, deathBloodParticle.transform.rotation);
        //GM.Respawn();
        //GameOver();
        //Destroy(gameObject);
        currentHealth = maxHealth;
        transform.position = new Vector2(-52, 15);

        //SceneManager.LoadScene("GameOver");
        //wait(1);
        //loadscene(death);
       
        
        
    }
}
