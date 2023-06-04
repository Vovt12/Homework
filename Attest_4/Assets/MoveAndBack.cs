using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndBack : MonoBehaviour
{
    public Action tell;
    // Start is called before the first frame update
    public void Next()
    {
        tell.i = tell.i + 1;
    }
    public void Back()
    {
        tell.i = tell.i - 1;
    }
}
