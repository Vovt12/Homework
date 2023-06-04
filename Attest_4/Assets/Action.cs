using System;
using System.IO;
using TMPro;
using UnityEngine;

public class Action : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Vector2 v2;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI Vopros;
    public TextMeshProUGUI BrotherTolk;
    public TextMeshProUGUI SlimeTolk;
    public TextMeshProUGUI Life;
    public Canvas canvasTalk;
    public float DrtX, DrtY, ColJump, y, distante;
    public float Speed = 2f;
    public float jump = 10;
    public int money;
    public int i;
    public bool talking;
    public bool Jumper;
    public int life = 3;
    public Vrag vr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Text.text = $"Количество монет: {money}";
        Life.text = $"Количество жизней {life}";
        Vopros.text = " ";
        BrotherTolk.text = " ";
        SlimeTolk.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        Life.text = $"Количество жизней {life}";
        W();
        Talk();
        if (Jumper == false)
            y = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumper = true;
            if (ColJump < 2)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                ColJump++;
            }
        }
        if (rb.velocity.y == y)
        {
            Jumper = false;
            ColJump = 0;
        }
        if (rb.position.y <= -10)
        {
            transform.position = transform.TransformDirection(0, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (life == 0)
        {
            transform.position = new Vector3(0, 0);
            life = 3;
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
        if(Input.GetKey(KeyCode.X))
            transform.rotation = Quaternion.Euler(0, 0, 0); ;
    }
    void Talk()
    {
        if (talking == true)
        {
            canvasTalk.sortingOrder = 1;
            using (FileStream fs = File.OpenRead("Assets\\script.text"))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string[] ted = { " : ", ". " };
                    string[] g = sr.ReadLine().Split(ted, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        if (g[i] == "I")
                        {
                            BrotherTolk.text = " ";
                            SlimeTolk.text = g[i + 1];
                        }
                        else if (g[i] == "S")
                        {
                            SlimeTolk.text = " ";
                            BrotherTolk.text = g[i + 1];
                        }
                        else if (i == g.Length)
                        {
                            talking = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Log(ex.Message);
                        if (i >= g.Length || i <= g.Length)
                        {
                            talking = false;
                        }
                    }
                }
            }
        }
        else
        {
            SlimeTolk.text = " ";
            BrotherTolk.text = " ";
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Money")
        {
            money++;
            Text.text = $"Количество монет: {money}";
            Vopros.text = " ";
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "Talk")
        {
            talking = true;
        }
        else if (collision.gameObject.tag == "Apply")
        {
            life = 3;
            Life.text = $"Количество жизней {life}";
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "Vrag")
        {
            vr.life = vr.life - 2;
            life--;
            Life.text = $"Количество жизней {life}";
        }
        else if (collision.gameObject.tag != "Money" || collision.gameObject.tag != "Talk")
        {
            BrotherTolk.text = " ";
            SlimeTolk.text = " ";
        }
    }
}
