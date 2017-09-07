using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D myRigidBody;

    public bool PhyisicsBased;

    void Start()
    {

        if (PhyisicsBased)
        {
            Initialize();
        }
    }
   

    public void Initialize()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.AddForce(transform.right * speed * 25,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

        if (!PhyisicsBased)
        {
            transform.Rotate(0, 0, 1 * Time.deltaTime);
            transform.Translate(0, Time.deltaTime * speed, 0);
            transform.Translate(Vector2.right * speed);
        }
    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    Destroy(gameObject);
    //}
    void OnCollisionEnter2D(Collision2D bullet)
    {
        Debug.Log("Bullet was destroyed");
        Destroy(gameObject);
        if (bullet.gameObject.CompareTag("box"))
        {
            
            
        }
    }

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //}

}
