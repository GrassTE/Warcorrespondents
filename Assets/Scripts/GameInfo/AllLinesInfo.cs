using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLinesInfo : MonoBehaviour
{
    //总线信息类，用来存储场景中电话线断裂的总体信息，
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

    public bool AreYouOK(){return (needCount == OKCount);}//返回完成量是不是等于需求量
}
