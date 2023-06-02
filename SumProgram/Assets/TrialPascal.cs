using System.Text;
using TMPro;
using UnityEngine;

public class TrialPascal : MonoBehaviour
{
    public int Number;
    public TextMeshProUGUI tm;
    // Start is called before the first frame update
    void Start()
    {
        TriallPascal();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TriallPascal()
    {
        string a = "";
        StringBuilder sr = new StringBuilder();
        for (int y = 0; y < Number; y++)
        {
            int c = 1;
            for (int q = 0; q < Number - y; q++)
            {
                sr.Append(a).Append("  ");
            }

            for (int x = 0; x <= y; x++)
            {
                sr.Append(a).Append($"  {c} ");
                c = c * (y - x) / (x + 1); ;
            }
            sr.Append(a).AppendLine();
            sr.Append(a).AppendLine();
        }
        sr.Append(a).AppendLine();
        tm.text = sr.ToString();
    }
}
