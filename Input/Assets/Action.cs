using UnityEngine;

public class Action : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Vector2 v2;
    public float DrtX, DrtY, ColJump, y;
    public float Speed = 2f;
    public float jump = 10;
    public bool Jumper;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        W();
        if (Jumper == false)
            y = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumper = true;
            if (ColJump < 2)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                Debug.Log("Space");
                ColJump++;
            }
        }
        if (rb.velocity.y == y)
        {
            Jumper = false;
            ColJump = 0;
        }
    }
    void W()
    {
        DrtX = Input.GetAxis("Horizontal");
        DrtY = Input.GetAxis("Vertical");
        v2 = new Vector2(DrtX, DrtY);
        transform.Translate(v2 * Speed * Time.deltaTime);
        if (DrtX < 0)
        {
            sr.flipX = true;
        }
        else if (DrtX > 0)
        {
            sr.flipX = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Return")
        {
            transform.position = transform.TransformDirection(0, -3, 0);
        }
    }
}
