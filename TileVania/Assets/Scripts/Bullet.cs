using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float fltBulletSpeed = 20f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * fltBulletSpeed;



    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed,0f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
