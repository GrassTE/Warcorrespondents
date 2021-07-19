using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : Interactive
{
    private Text codeTextView;//电码TextView，显示目前打了打码
    private IndexRecoder indexRecoder;//策划数值接口
    private AllLinesInfo linesChecker;//路线信息
    [Tooltip("把这台机器需要打的句子拖进来，在：抽象的东西->句子们。没有就自己建一个，创建新物体，加上Sentence组件")]
    public Sentence[] sentences;//这台机器需要的句子们
    private string code;//目前记录中已打的电码
    private string tempTranslateResult;//临时翻译结果，一般是数字序列
    [Tooltip("机器电码打完后的事件，由于不同的机器打完后触发的东西不一样，所以用事件像拼图一样把这个函数写在外面")]
    public Event m_Event;//机器电码打完后的事件，由于不同的机器打完后触发的东西不一样，所以用事件像拼图一样把这个函数写在外面
    [Tooltip("界面展示需要打的句子的TextView数组，请把对应的显示句子的TextView们拖进来。就算后面两行不够，也直接加就行。但是要记得和sentencs数组的长度相同！")]
    public Text[] sentencesTextView;//界面展示需要打的句子的TextView数组

    void Start()
    {
        codeTextView = m_interface.GetComponentInChildren<Text>();
        indexRecoder = FindObjectOfType<IndexRecoder>();
        linesChecker = FindObjectOfType<AllLinesInfo>();
    }

    //电报机界面被打开的时候调用
    public override void OnCall()
    {
        if(LinesCheck())//如果线路全通
        {
            m_interface.SetActive(true);//把这个交互对象的界面打开，这里是电报机界面
            ShwoTheSentencesInfo();//初始化展示电报机界面的需要打的句子
            UpdateTheSentencesTextViewStates();//更新一下显示句子TextView的颜色状态
        }
        else
        {
            Debug.Log("还有线路没通");
        }
    }

    //更新界面句子们的颜色信息的函数，黄色代表该句正在打，绿色代表该句已经完成，红色代表该句等待打
    private void UpdateTheSentencesTextViewStates()
    {
        bool firstFlag = true;//设立一个首次标记，因为首次碰到没打完的标记为黄色，表示正在打此句
        for(int i = 0; i < sentences.Length; i++)//便利每一个句子
        {
            if(sentences[i].IsThisFinished()) sentencesTextView[i].color = Color.green;//如果打完了，标记为绿色
            else if(firstFlag){sentencesTextView[i].color = Color.yellow;firstFlag = false;}//如果第一次碰到没打完的，标记为黄色，表示在打
            else sentencesTextView[i].color = Color.red;//此外代表没打的，标记为红色
        }
    }

    //初始化展示电报机界面的需要打的句子的函数，一般只在电报机界面启动的时候调用一次
    private void ShwoTheSentencesInfo()
    {
        for(int i = 0; i < sentences.Length; i++)//便利每一个句子，把句子的内容放到对应的TextView里面
        {
            sentencesTextView[i].text = //把对应textView的内容设置为
                                        sentences[i].content +//句子的中文加上
                                        "\n" +//换一行加上
                                        sentences[i].num;//句子对应的数字序列
                                        //粗鲁的写法，但是后期这个会更新，仅作debug使用
        }
    }

    //用来检查电话线的函数，如果电话线全通，返回true，否则返回false
    private bool LinesCheck()
    {
        if(linesChecker.needCount == linesChecker.OKCount) return true;
        else return false;
    }

    //从Player类发消息来调用这个函数，temp为接受到的字符，可能是. || -。
    public override void Coding(string temp)
    {
        code += temp;
        if(code.Length >= 5) ClearChecker(code);//当长度超过5位，每打一位就检查一下是否有特殊字符
        if(code.Length % 5 == 0) 
        {
            Translate(code);//每输入五位就翻译一下
            CompleteChecker();//每五位要检查一下句子是否打对了
        }
        codeTextView.text = code;//让TextVie更新
    }

    //每打五位电码调用一次，检查这个句子是否被打完
    private void CompleteChecker()
    {
        Sentence temp = null;//目前在打的句子
        foreach(Sentence i in sentences) if(!i.IsThisFinished()) {temp = i;break;}//找到最近的那个没有完成的句子，也就是目前在打的句子
        try{
            if(temp.num.Equals(tempTranslateResult))//如果这个句子的数字序列等于目前翻译出来的数字序列
            {
                temp.CompleteTheSentence();//说明这个句子完成了，修改它的标记
                UpdateTheSentencesTextViewStates();//有句子打完了，更新一下句子的颜色状态
                ClearTheInputAndTempResult();//有句子打完后，清除输入框和临时翻译结果
                if(AllSentenceClearChecker()) OnAllSentenceClear();//当所有句子都打完了，触发此函数
            }
        }
        catch(System.NullReferenceException e)  
        {
            Debug.Log("打完了，不要再打了，往后会出错误了");
            e.ToString();
        }
        
    }

    //当所有句子都被打完了,执行事件，事件代码请到事件类中去编写
    private void OnAllSentenceClear(){m_Event.OnCall();}

    //当确认打完一句的时候调用，检查一下是否所有句子都被打完了
    private bool AllSentenceClearChecker()
    {
        bool flag = true;//默认全部完成
        foreach(Sentence temp in sentences) if(!temp.IsThisFinished()) flag = false;//检查机器里的每一个句子，如果它有没完成的，把标记改成flase
        return flag;//返回标记
    }

    //译者函数。输入一串字符串，在这里会对照数值记录者中的codeBook翻译，没有的code会被翻译成X
    //每当输入总体的长度是五的倍数的时候，才会调用这个翻译函数，因为每个数字单元都是5位
    private void Translate(string code)
    {
        string result = "";
        for(int i = 0; i < code.Length/5; i++)
        {
            string temp =  code.Substring(i*5,5);
            try{
                result += indexRecoder.codeBook[temp];
            }
            catch
            {
                result += "X";
            }
        }
        Debug.Log("翻译的结果是："+result);
        tempTranslateResult = result;
    }

    //清除检查者函数。从自身Codeing函数调用，每次有新字符输入的时候就调用。
    //检查输入总体中是否存在连续的八个点，有则清空当前输入的所有东西
    private void ClearChecker(string code)
    {
        int hasClearer = code.IndexOf(".-.-.");
        if(hasClearer != -1)
        {
            Debug.Log("检查到特殊码，清除所有输入内容");
            // tempTranslateResult = "";
            // this.code = "";
            ClearTheInputAndTempResult();
        }
    }

    //清除目前输入框的内容、记录中的电码和临时翻译结果。在检查到清除特殊码和打完一句的时候调用
    private void ClearTheInputAndTempResult(){tempTranslateResult = "";code = "";}
}
