using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float fltMoveSpeed = 1f;
    Rigidbody2D myRigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.velocity = new Vector2(fltMoveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        fltMoveSpeed = -fltMoveSpeed;
        FlipEnemyFacing();

    }
    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }
}
