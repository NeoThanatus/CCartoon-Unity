using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D myrb;
    public float velocity;
    void Start()
    {
        myrb = gameObject.GetComponent<Rigidbody2D>();
        myrb.velocity = transform.right * velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("BulletDestroy", 3f);
    }

    void BulletDestroy()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // && significa 'e'
        // || siginifica 'ou'
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "cacto" )
        {
            BulletDestroy();
        }
    }
}
