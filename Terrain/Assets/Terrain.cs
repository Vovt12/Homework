using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public Texture2D text;
    public Rigidbody2D rb, rb1;
    public int t;
    public float Seed, NoiseFreq, TerrFreq, Heighter;
    public Sprite Sprite2D;
    // Start is called b
    // fore the first frame update
    void NoiseGenerator()
    {
        text = new Texture2D(t, t);
        for (int i = 0; i < text.width; i++)
        {
            for (int j = 0; j < text.height; j++)
            {
                float p = Mathf.PerlinNoise((i + Seed) * NoiseFreq, (j + Seed) * NoiseFreq);
                text.SetPixel(i, j, new Color(p, p, p));
            }
        }
        text.Apply();
        Sprite2D = Sprite.Create(text, new Rect(0, 0, t, t), new Vector2(0, 0));
        GetComponent<SpriteRenderer>().sprite = Sprite2D;
    }
    void TerrainGeneratorAlg()
    {
        for (int i = 0; i < text.width; i++)
        {
            float height = Mathf.PerlinNoise((i + Seed) * NoiseFreq, Seed * TerrFreq) * Heighter;
            for (int j = 0; j < height; j++)
            {
                if (text.GetPixel(i, j).r < 0.457f)
                {
                    Sprite2D = Sprite.Create(text, new Rect(0, 0, t, t), new Vector2(0, 0));
                    GameObject go = new GameObject();
                    go.AddComponent<SpriteRenderer>();
                    go.AddComponent<Rigidbody2D>();
                    go.GetComponent<SpriteRenderer>().sprite = Sprite2D;
                    go.AddComponent<BoxCollider2D>();
                    rb = go.GetComponent<Rigidbody2D>();
                    rb.bodyType = RigidbodyType2D.Static;
                    go.transform.position = new Vector2(i, j);
                    if (go.transform.position.y >= rb1.transform.position.y)
                    {
                        Destroy(go);
                    }
                }
            }
        }
    }
    void Grain()
    {
        MyEnumerator me = new MyEnumerator();
        foreach (int i in me)
        {
            int corY = Random.Range(1, text.height);
            for (int j = 0; j < text.width/2 ; j++)
            {
                GameObject go1 = new GameObject();
                go1.AddComponent<SpriteRenderer>();
                go1.AddComponent<Rigidbody2D>();
                go1.GetComponent<SpriteRenderer>().sprite = Sprite2D;
                go1.AddComponent<BoxCollider2D>();
                rb1 = go1.GetComponent<Rigidbody2D>();
                rb1.bodyType = RigidbodyType2D.Static;
                if (i == 0)
                    go1.transform.position = new Vector2(0, j);
                else
                    go1.transform.position = new Vector2(text.height, j);
            }
            for (int y = 0; y < text.height; y++)
            {
                GameObject go1 = new GameObject();
                go1.AddComponent<SpriteRenderer>();
                go1.AddComponent<Rigidbody2D>();
                go1.GetComponent<SpriteRenderer>().sprite = Sprite2D;
                go1.AddComponent<BoxCollider2D>();
                rb1 = go1.GetComponent<Rigidbody2D>();
                rb1.bodyType = RigidbodyType2D.Static;
                if (i == 0)
                    go1.transform.position = new Vector2(y, 0);
                else
                    go1.transform.position = new Vector2(y, text.width / 2);
            }
        }

    }
    void Start()
    {
        Seed = Random.Range(-1000000, 1000000);
        NoiseGenerator();
        Grain();
        TerrainGeneratorAlg();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
public class MyEnumerator
{
    public IEnumerator GetEnumerator()
    {
        yield return 0;
        yield return 1;
    }
}
