using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float velocity = 5f;
    public Rigidbody2D myrb;
    public Animator anim;
    public SpriteRenderer sprender;
    public GameObject bullet;
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        myrb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        sprender = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (moveX < 0f)
        {
            sprender.flipX = true;
        }
        if (moveX > 0f)
        {
            sprender.flipX = false;
        }
       
        anim.SetFloat("animX", moveX);
        anim.SetFloat("animY", moveY);
        

        Vector3 totalMove = new Vector3(moveX, moveY, 0f);
        if (moveX != 0f || moveY != 0f)
        {
            anim.SetBool("isMove", true);
            anim.SetFloat("lastX", moveX);
            anim.SetFloat("lastY", moveY);

        }
        else
        {
            anim.SetBool("isMove", false);
        }
        myrb.velocity = totalMove.normalized * velocity;
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Shooting");
        }
    }

    void OnShoot()
    {
        Instantiate(bullet, fire.transform.position, fire.transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "cacto")
        {
            Debug.Log("Cacto!");
        }
    }
}
