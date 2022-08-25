using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCoins : MonoBehaviour
{
    public int coins = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coins++; 
            Destroy(other.gameObject);
        }
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10,10,200,200),"Score: "+coins.ToString());
    }
}
