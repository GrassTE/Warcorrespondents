using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentence : MonoBehaviour
{
    // Start is called before the first frame update
    //句子类，其对象是电报机中的一个句子
    [Tooltip("这个句子的内容是什么？")]
    public string content;
    [Tooltip("这个句子对应的数字序列是？")]
    public string num;
    private bool hasCompleted;//这个句子目前是否被完成
    void Start()
    {
        hasCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsThisFinished(){return hasCompleted;}
    public void CompleteTheSentence(){hasCompleted = true;}
}
