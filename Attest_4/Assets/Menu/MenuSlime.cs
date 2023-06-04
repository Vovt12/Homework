using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSlime : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public bool f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }
    void Walk()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (rb.position.x >= 12) 
           transform.position = transform.TransformDirection(-12,-5,0);
    }
}
