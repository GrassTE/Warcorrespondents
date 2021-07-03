using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : Interactive
{
    // Start is called before the first frame update


    private Text codeTextView;
    private IndexRecoder indexRecoder;
    void Start()
    {
        //m_interface = GameObject.Find("MachinePanel");
        codeTextView = m_interface.GetComponentInChildren<Text>();
        indexRecoder = FindObjectOfType<IndexRecoder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //从Player类发消息来调用这个函数，temp为接受到的字符，可能是. || -。
    public override void Coding(string temp)
    {
        codeTextView.text += temp;//给当前输入总体加上刚输入的字符
        if(codeTextView.text.Length >= 8) ClearChecker(codeTextView.text);//当长度超过8位，每打一位就检查一下是否有连续的八个点
        if(codeTextView.text.Length % 4 == 0) Translate(codeTextView.text);//每输入四位就翻译一下
    }


    //译者函数。输入一串字符串，在这里会对照数值记录者中的codeBook翻译，没有的code会被翻译成X
    //每当输入总体的长度是四的倍数的时候，才会调用这个翻译函数，因为每个汉字单元都是4位
    private void Translate(string code)
    {
        string result = "";
        for(int i = 0; i < code.Length/4; i++)
        {
            string temp =  code.Substring(i*4,4);
            try{
                result += indexRecoder.codeBook[temp];
            }
            catch
            {
                //Debug.Log("字典里没找到这个字，我得给翻译结果里加个叉叉");
                result += "X";
            }
        }
        Debug.Log("翻译的结果是："+result);
    }

    //清除检查者函数。从自身Codeing函数调用，每次有新字符输入的时候就调用。
    //检查输入总体中是否存在连续的八个点，有则清空当前输入的所有东西
    private void ClearChecker(string code)
    {
        int hasClearer = code.IndexOf("........");
        if(hasClearer != -1)
        {
            codeTextView.text = "";
            Debug.Log("检查到连续的八个点，清除所有输入内容");
        }
    }


}
