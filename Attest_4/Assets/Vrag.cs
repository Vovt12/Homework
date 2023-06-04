using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vrag : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Transform tr;
    public float speed, agree;
    public int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist  = Vector2.Distance(transform.position,tr.position);
        if(dist < agree)
        {
            Ataca();
        }
        else
        {
            NoAtaca();
        }
        if(life <= 0)
        {
            Destroy(rb.gameObject);
        }
    }
    void Ataca()
    {
        if(tr.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y) ;
            sr.flipX = true;
        }
        else if (tr.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            sr.flipX = false;
        }
    }
    void NoAtaca()
    {
        rb.velocity = new Vector2(0, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Missile")
        {
            life--;
        }
    }
}
