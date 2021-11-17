using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public HealthBar healthbar;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private GameObject deathChunkParticle, deathBloodParticle;

    private float currentHealth;

    private GameManager GM;

    private void Start(){
        currentHealth=maxHealth;
        healthbar.setMaxHealth(maxHealth);
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void DecreaseHealth(float amount){
        currentHealth-=amount;
        healthbar.setHealth(currentHealth);

        if(currentHealth<=0.0f){
            Die();
        }
    }

    private void Die(){
        //Instantiate(deathChunkParticle,transform.position, deathChunkParticle.transform.rotation);
        //Instantiate(deathBloodParticle,transform.position, deathBloodParticle.transform.rotation);
        GM.Respawn();
    
        Destroy(gameObject);
        //wait(1);
        //loadscene(death);
       
        
        
    }
}
