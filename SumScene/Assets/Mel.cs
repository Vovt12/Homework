using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mel : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed, rotZ;
    public bool Rotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        System.Random rd = new System.Random();
        speed = rd.Next(1, 2000);
        if(Rotation == false)
        {
            rotZ += Time.deltaTime * speed;
        }else
            rotZ += -Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(0,0, rotZ);
        
    }
}
