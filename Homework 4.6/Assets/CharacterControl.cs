using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Vector2 v2;
    public float DrtX, DrtY;
    public float Speed = 2f;
    public TextMeshProUGUI tmpu;
    public int cout;
    public int H = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tmpu.text = $"Количество звёзд: {cout}";
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D f;
        if (Input.GetKey("a"))
            H = -1;
        if (Input.GetKey("d"))
            H = 1;
        W();
    }
    void W()
    {
        DrtX = Input.GetAxis("Horizontal");
        DrtY = Input.GetAxis("Vertical");
        v2 = new Vector2(DrtX, DrtY);
        transform.Translate(v2* Speed * Time.deltaTime);
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
            if (collision.gameObject.tag == "Start")
            {
                Destroy(collision.gameObject);
                cout++;
                tmpu.text = $"Количество звёзд: {cout}";
            }
        }
    
}