using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class coinCollect : MonoBehaviour
{
    private float coins = 0;

    public TextMeshProUGUI textcoin;  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "coin")
        {
            coins++;
            textcoin.text=coins.ToString();
        }
    }
}
