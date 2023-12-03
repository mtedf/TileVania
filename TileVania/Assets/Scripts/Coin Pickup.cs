using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int coinValue = 125;

    bool wasCollected = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && wasCollected == false)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(coinValue);
            
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);

        }
        {

        }
    }




}
