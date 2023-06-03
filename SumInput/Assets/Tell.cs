using System;
using System.IO;
using TMPro;
using UnityEngine;

public class Tell : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rb2;
    public TextMeshProUGUI SlimeTolk;
    public TextMeshProUGUI BrotherTolk;
    public bool Talking;
    public float speed;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SlimeTolk.text = " ";
        BrotherTolk.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        Telling();
    }
    void Telling()
    {
        if (Talking == false)
        {
            if (rb.position.x < -1 && rb2.position.x > 1)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                rb2.velocity = new Vector2(-speed, rb2.velocity.y);
            }
            else
            {
                speed = 0;
                Talking = true;
            }
        }
        else if (Talking == true)
        {
            using (FileStream fs = File.OpenRead("Assets\\script.text"))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string[] ted = { " : ", ". " };
                    string[] g = sr.ReadLine().Split(ted, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        if (g[i] == "Slime")
                        {
                            BrotherTolk.text = " ";
                            SlimeTolk.text = g[i + 1];
                        }
                        else if (g[i] == "Brother")
                        {
                            SlimeTolk.text = " ";
                            BrotherTolk.text = g[i + 1];
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Log(ex.Message);
                        if (i < 0)
                            i++;
                        else
                            i--;
                    }
                }
            }
        }
    }
}
