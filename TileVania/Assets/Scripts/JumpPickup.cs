using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    public bool powerUp = false;

    bool wasCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && wasCollected == false)
        {
            powerUp = true;
            wasCollected = true;
            


            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);

            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                playerMovement.ActivatePowerup();
            }

        }



    }
    /* private void Update()
    {
        if (powerUp == true)
        {
            PlayerMovement JumpSpeed  = GameObject.Find("Player").GetComponent<PlayerMovement>();
            JumpSpeed.fltJumpSpeed = 30f;
            Debug.Log("Power up active");
        }
    } */
}
