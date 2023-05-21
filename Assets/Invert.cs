using System.Collections.Generic;
using UnityEngine;

public class Invert : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public int u;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        MyEnumerator en = new MyEnumerator();
        Rigidbody2D clone;
        clone = Instantiate(rb);
        foreach (var em in en)
        {
            if(em < 2)
                clone.velocity = transform.TransformDirection(Vector2.right * 10);
            else 
                clone.velocity = transform.TransformDirection(Vector2.left * 10);
            Destroy(this.gameObject,1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
public class MyEnumerator
{
    public IEnumerator<int> GetEnumerator()
    {
        yield return 0;
        yield return 1;
        yield return 2;
        yield return 3;
    }
}
