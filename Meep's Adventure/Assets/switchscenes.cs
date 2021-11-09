using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchscenes : MonoBehaviour
{
    public string sceneToLoad;

    public void OnTriggerEnter(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
