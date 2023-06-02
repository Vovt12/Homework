using UnityEngine;

public class Clin : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sr;
    public SpriteRenderer sr0;

    void Start()
    {
        ClinPost();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ClinPost()
    {
        int poi = 0;
        int poi1 = 0;
        int[,] a = new int[8, 8] { { 0, 0, 0, 1, 1, 0, 0, 0 }, { 0, 0, 1, 1, 1, 1, 0, 0 }, { 0, 1, 1, 1, 1, 1, 1, 0 }, { 1, 1, 2, 2, 2, 2, 1, 1 }, { 1, 1, 2, 2, 2, 2, 1, 1 }, { 1, 1, 2, 2, 2, 2, 1, 1 }, { 1, 1, 2, 2, 2, 2, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1 } };
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                if (a[i, j] == 1)
                {
                    GameObject obj = new GameObject();
                    obj.AddComponent<SpriteRenderer>();
                    obj.GetComponent<SpriteRenderer>().sprite = sr.sprite;
                    obj.transform.position = new Vector2(-poi - j + 3, -poi1 - i + 3);
                }
                else if (a[i, j] == 2)
                {
                    GameObject obj = new GameObject();
                    obj.AddComponent<SpriteRenderer>();
                    obj.GetComponent<SpriteRenderer>().sprite = sr0.sprite;
                    obj.transform.position = new Vector2(-poi - j + 3, -poi1 - i + 3);
                }
            }
        }
    }
}
