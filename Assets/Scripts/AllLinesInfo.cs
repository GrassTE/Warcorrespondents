using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLinesInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int needCount;
    public int OKCount = 0;
    void Start()
    {
        needCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
